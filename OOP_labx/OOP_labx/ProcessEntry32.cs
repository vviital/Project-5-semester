using System;
using System.Runtime.InteropServices;

namespace OOP_labx
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public struct ProcessEntry32
    {
            public const int MAX_PATH = 260;
            public int dwSize;
            public int cntUsage;
            private int th32ProcessID;
            public IntPtr th32DefaultHeapID;
            public int th32ModuleID;
            public int cntThreads;
            public int th32ParentProcessID;
            public int pcPriClassBase;
            public int dwFlags;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_PATH)]
            private string szExeFile;
            
            

            public int Th32ProcessID
            {
                set
                {
                    th32ProcessID = value; 
                }
                get 
                {
                    return th32ProcessID;
                }
            }
            public string SzExeFile
            {
                set 
                {
                    szExeFile = value; 
                }
                get
                {
                    return szExeFile; 
                }
            }
    }
}
