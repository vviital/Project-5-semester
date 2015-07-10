using System;
using System.Linq;
using System.Management;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Collections.Generic;
using System.Text;
using Microsoft.Win32;
namespace OOP_labx
{
    public struct ProcessHandler
    {
        public static ManagementEventWatcher eventStartWatcher;
        public static ManagementEventWatcher eventEndWatcher;

        #region Flags and DllImport

        [Flags]
        private enum SnapshotFlags : uint
        {
            HeapList = 0x00000001,
            Process = 0x00000002,
            Thread = 0x00000004,
            Module = 0x00000008,
            Module32 = 0x00000010,
            Inherit = 0x80000000,
            All = 0x0000001F,
            NoHeaps = 0x40000000
        }

        [Flags]
        enum ProcessAccessFlags : int
        {
            All = 0x001F0FFF,
            Terminate = 0x00000001,
            CreateThread = 0x00000002,
            VMOperation = 0x00000008,
            VMRead = 0x00000010,
            VMWrite = 0x00000020,
            DupHandle = 0x00000040,
            SetInformation = 0x00000200,
            QueryInformation = 0x00000400,
            Synchronize = 0x00100000
        }

        [DllImport("kernel32", SetLastError = true, CharSet = System.Runtime.InteropServices.CharSet.Auto)]
        static extern IntPtr CreateToolhelp32Snapshot([In]UInt32 dwFlags, [In]UInt32 th32ProcessID);

        [DllImport("kernel32", SetLastError = true, CharSet = System.Runtime.InteropServices.CharSet.Auto)]
        static extern bool Process32First([In]IntPtr hSnapshot, ref ProcessEntry32 lppe);

        [DllImport("kernel32", SetLastError = true, CharSet = System.Runtime.InteropServices.CharSet.Auto)]
        static extern bool Process32Next([In]IntPtr hSnapshot, ref ProcessEntry32 lppe);

        [DllImport("kernel32.dll")]
        static public extern bool Module32First([In]IntPtr hSnapshot, ref ModuleEntry32 lpme);

        [DllImport("kernel32.dll")]
        static public extern bool Module32Next([In]IntPtr hSnapshot, ref ModuleEntry32 lpme);

        [DllImport("kernel32", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool CloseHandle([In] IntPtr hObject);

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool TerminateProcess(IntPtr hProcess, int uExitCode);

        [DllImport("kernel32.dll")]
        static extern IntPtr OpenProcess(ProcessAccessFlags dwDesiredAccess, [MarshalAs(UnmanagedType.Bool)] bool bInheritHandle, int dwProcessId);

        [DllImport("kernel32.dll", SetLastError = true)]
        [PreserveSig]
        public static extern uint GetModuleFileName
        ([In]IntPtr hModule, [Out]StringBuilder lpFilename, [In][MarshalAs(UnmanagedType.U4)]int nSize);

        #endregion

        public static void EventCreater()
        {
            string queryStringEnd = "SELECT * FROM Win32_ProcessStopTrace";
            string queryStringStart = "SELECT * FROM Win32_ProcessStartTrace";
            eventStartWatcher = new ManagementEventWatcher(new WqlEventQuery(queryStringStart));
            eventEndWatcher = new ManagementEventWatcher(new WqlEventQuery(queryStringEnd));
            eventStartWatcher.Start();
            eventEndWatcher.Start();
        }

        public static List<ProcessData> GetProcessList()
        {
            List<ProcessData> processesList = new List<ProcessData>();
            IntPtr snapshotHandle = IntPtr.Zero;
            try
            {
                ProcessEntry32 processEntry32 = new ProcessEntry32();
                processEntry32.dwSize = (int)Marshal.SizeOf(typeof(ProcessEntry32));
                snapshotHandle = CreateToolhelp32Snapshot((int)SnapshotFlags.Process, 0);
                while (Process32Next(snapshotHandle, ref processEntry32))
                {
                    processesList.Add(GetData(ref processEntry32));
                }

            }
            catch (Exception ex)
            {
                throw new ApplicationException("proc err", ex);
            }
            finally
            {
                CloseHandle(snapshotHandle);
            }
            return processesList;
        }

        public static void KillProcess(int id)
        {
            try
            {
                TerminateProcess(OpenProcess(ProcessAccessFlags.Terminate, false, id), 2);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static ProcessData GetData(ref ProcessEntry32 processEntry32)
        {
            ProcessData processData = new ProcessData();
            processData.Name = processEntry32.SzExeFile;
            processData.Id = processEntry32.Th32ProcessID;
            try
            {
                Process process = Process.GetProcessById(processData.Id);
                processData.FilePath = process.MainModule.FileName;
            }
            catch (Exception)
            {
                //		Name	"[System Process]" id = 0
                //      Name    "System" id = 4
            }
            if (processData.FilePath != null)
                processData.CheckSum = CheckSum.ComputeMD5Checksum(processData.FilePath);
            //processData.ModuleList = GetModules(processData.Id);
            return processData;
        }

        public static ProcessData GetData(int id)
        {
            IntPtr snapshotHandle = IntPtr.Zero;
            try
            {
                ProcessEntry32 processEntry32 = new ProcessEntry32();
                processEntry32.dwSize = (int)Marshal.SizeOf(typeof(ProcessEntry32));
                snapshotHandle = CreateToolhelp32Snapshot((int)SnapshotFlags.Process, 0);
                while (Process32Next(snapshotHandle, ref processEntry32))
                {
                    if (processEntry32.Th32ProcessID == id)
                        return GetData(ref processEntry32);
                }

            }
            catch (Exception ex)
            {
                throw new ApplicationException("proc err 2", ex);
            }
            finally
            {
                CloseHandle(snapshotHandle);
            }
            return new ProcessData();
        }

        public static ProcessData GetData(string name)
        {
            IntPtr snapshotHandle = IntPtr.Zero;
            try
            {
                ProcessEntry32 processEntry32 = new ProcessEntry32();
                processEntry32.dwSize = (int)Marshal.SizeOf(typeof(ProcessEntry32));
                snapshotHandle = CreateToolhelp32Snapshot((int)SnapshotFlags.Process, 0);
                while (Process32Next(snapshotHandle, ref processEntry32))
                {
                    if (processEntry32.SzExeFile == name)
                        return GetData(ref processEntry32);
                }

            }
            catch (Exception ex)
            {
                throw new ApplicationException("proc err 2", ex);
            }
            finally
            {
                CloseHandle(snapshotHandle);
            }
            return new ProcessData();
        }

        public static string ConvertDataToString(string processName)
        {
            string str = string.Empty;
            ProcessData data = ProcessHandler.GetData(processName);
            List<ModuleData> modules =ProcessHandler.GetModules(data.Id);
   
            str += data.Name +" "+data.CheckSum +"|";
            foreach (ModuleData item in modules)
            {
                str += item.FilePath + " " + item.CheckSum + "|";
            }
            return str;
        }

        public static ProcessData ConvertStringToData(string input)
        {
            ProcessData data = new ProcessData();
            try
            {
              string[] strList =  input.Split('|');
                string[] process = strList[0].Split(' ');
               data.Name = process[0];
                data.CheckSum = process[1];
                for (int i = 1; i < strList.Length;i++)
                {
                    if (i==strList.Length-1) break;
                    string[] moduleString = strList[i].Split(' ');
                    ModuleData module = new ModuleData();
                    module.FilePath = moduleString[0];
                    module.CheckSum = moduleString[1];
                    data.ModuleList.Add(module);
                }
            }
            catch (Exception)
            {
                
                throw;
            }
            return data;
        }

        public static List<ModuleData> GetModules(int id)
        {
            List<ModuleData> listModules = new List<ModuleData>();
            IntPtr snapshotHandle = IntPtr.Zero;

            try
            {
                ModuleEntry32 moduleEntry32 = new ModuleEntry32();
                moduleEntry32.dwSize = (uint)Marshal.SizeOf(typeof(ModuleEntry32));
                snapshotHandle = CreateToolhelp32Snapshot((int)SnapshotFlags.Module, (uint)id);

                if (Module32First(snapshotHandle, ref moduleEntry32))
                {
                    do
                    {
                        StringBuilder moduleBuilder = new StringBuilder(256);
                        GetModuleFileName(moduleEntry32.modBaseAddr, moduleBuilder, moduleBuilder.Capacity);
                        ModuleData moduleData = new ModuleData();
                        moduleData.FilePath = moduleBuilder.ToString();
                        if (moduleData.FilePath != null)
                        {
                            moduleData.CheckSum = CheckSum.ComputeMD5Checksum(moduleData.FilePath);
                            if (moduleData.FilePath != null && moduleData.FilePath != ""
                               && moduleData.CheckSum!=null && moduleData.CheckSum !="")
                            listModules.Add(moduleData);
                        }

                    } while (Module32Next(snapshotHandle, ref moduleEntry32));
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("proc err 2", ex);
            }
            finally
            {
                CloseHandle(snapshotHandle);
            }
            return listModules;

        }

        public static void AddToAutorun(string processDirectory)
        {
            RegistryKey reg = Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Run\\");
            try
            {
                reg.SetValue("LabXXXXXX", processDirectory);
                reg.Flush();
                reg.Close();
            }
            catch
            {

            }
        }

        public static void RemoveFromAutorun()
        {
            RegistryKey reg = Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Run\\");
            try
            {
                reg.DeleteValue("LabXXXXXX");
                reg.Flush();
                reg.Close();
            }
            catch
            {

            }
        }
     
    }
}
