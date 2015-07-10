using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace OOP_labx
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public struct ModuleEntry32
        //{
        //    public int dwSize;
        //    public int th32ModuleID;
        //    public int th32ProcessID;
        //    public int GlblcntUsage;
        //    public int ProccntUsage;
        //    IntPtr modBaseAddr;
        //    public int modBaseSize;
        //    IntPtr hModule;
        //    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
        //    public string szModule;
        //    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
        //    public string szExePath;
        //};
    {
        private const int MAX_PATH = 255;
        internal uint dwSize; //размер структуры в байтах
        internal uint th32ModuleID; //ID модуля
        internal uint th32ProcessID; //ID процесса модуля
        internal uint GlblcntUsage; //общее для системы количество обращений к модулю
        internal uint ProccntUsage; //количество обращений к модулю, сделанных из текущего процесса
        internal IntPtr modBaseAddr; //адрес модуля в адресном пространстве процесса
        internal uint modBaseSize; //размер модуля
        internal IntPtr hModule; //дескриптор модуля в контексте процесса
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_PATH + 1)] internal string szModule; //имя модуля
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_PATH + 5)] internal string szExePath; //полный путь к файлу
    };
}
