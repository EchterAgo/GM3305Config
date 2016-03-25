using System;
using System.IO;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using System.Security;

namespace GM3305Comm
{
    class Native
    {
        public static IntPtr INVALID_HANDLE_VALUE = new IntPtr(-1);

        [Flags]
        public enum ACCESS_MASK : uint
        {
            GENERIC_READ = 0x80000000,
            GENERIC_WRITE = 0x40000000,
            GENERIC_EXECUTE = 0x20000000,
            GENERIC_ALL = 0x10000000,
        }

        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern IntPtr CreateFileW(
            [MarshalAs(UnmanagedType.LPWStr)] string filename,
            [MarshalAs(UnmanagedType.U4)] ACCESS_MASK access,
            [MarshalAs(UnmanagedType.U4)] FileShare share,
            IntPtr securityAttributes,
            [MarshalAs(UnmanagedType.U4)] FileMode creationDisposition,
            [MarshalAs(UnmanagedType.U4)] FileAttributes flagsAndAttributes,
            IntPtr templateFile
            );

        [DllImport("kernel32.dll", SetLastError = true)]
        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
        [SuppressUnmanagedCodeSecurity]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool CloseHandle(
            IntPtr hObject
            );

        [DllImport("kernel32.dll", ExactSpelling = true, SetLastError = true, CharSet = CharSet.Auto)]
        public static extern bool DeviceIoControl(
            IntPtr hDevice,
            uint dwIoControlCode,
            IntPtr lpInBuffer,
            uint nInBufferSize,
            IntPtr lpOutBuffer,
            uint nOutBufferSize,
            out uint lpBytesReturned,
            IntPtr lpOverlapped
            );

        public static bool DeviceIoControl(
            IntPtr device,
            uint ioControlCode,
            byte[] inBuffer,
            byte[] outBuffer,
            out uint bytesReturned
            )
        {
            IntPtr hib = IntPtr.Zero;
            IntPtr hob = IntPtr.Zero;

            if (inBuffer.Length > 0) {
                hib = Marshal.AllocHGlobal(inBuffer.Length);
                Marshal.Copy(inBuffer, 0, hib, inBuffer.Length);
            }

            if (outBuffer.Length > 0) {
                hob = Marshal.AllocHGlobal(outBuffer.Length);
            }

            var res = DeviceIoControl(device, ioControlCode, hib, (uint)inBuffer.Length, hob, (uint)outBuffer.Length, out bytesReturned, IntPtr.Zero);

            if (inBuffer.Length > 0) {
                Marshal.FreeHGlobal(hib);
            }

            if (outBuffer.Length > 0) {
                Marshal.Copy(hob, outBuffer, 0, outBuffer.Length);
                Marshal.FreeHGlobal(hob);
            }

            return res;
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern IntPtr CreateSemaphore(
            IntPtr lpSemaphoreAttributes,
            int lInitialCount,
            int lMaximumCount,
            IntPtr lpName);
    }
}
