using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace GM3305Config
{
    public class DeviceMonitor : NativeWindow, IDisposable
    {
        private IntPtr notifyHandle_ = IntPtr.Zero;

        #region Constructors

        public DeviceMonitor(IntPtr handle)
        {
            AssignHandle(handle);

            var dbdi = new DEV_BROADCAST_DEVICEINTERFACE();

            dbdi.dbcc_devicetype = DBT_DEVTYP_DEVICEINTERFACE;
            dbdi.dbcc_reserved = 0u;
            dbdi.dbcc_classguid = GUID_DEVINTERFACE_USB_DEVICE;
            dbdi.dbcc_name = string.Empty;
            dbdi.dbcc_size = (uint)Marshal.SizeOf(dbdi);

            var dbdi_ptr = Marshal.AllocHGlobal((int)dbdi.dbcc_size);
            try {
                Marshal.StructureToPtr(dbdi, dbdi_ptr, false);
                notifyHandle_ = RegisterDeviceNotification(handle, dbdi_ptr, DEVICE_NOTIFY_WINDOW_HANDLE);
            } finally {
                Marshal.FreeHGlobal(dbdi_ptr);
            }
        }

        #endregion

        #region Window procedure

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_DEVICECHANGE) {
                var evt = (uint)m.WParam.ToInt32();
                if (evt == DBT_DEVICEARRIVAL) {
                    var bh = (DEV_BROADCAST_HDR)Marshal.PtrToStructure(m.LParam, typeof(DEV_BROADCAST_HDR));
                    if (bh.dbch_DeviceType == DBT_DEVTYP_DEVICEINTERFACE) {
                        var di = (DEV_BROADCAST_DEVICEINTERFACE)Marshal.PtrToStructure(m.LParam, typeof(DEV_BROADCAST_DEVICEINTERFACE));

                        RaiseDeviceArrived(di.dbcc_name);
                    }
                }
            }

            base.WndProc(ref m);
        }

        #endregion

        #region Events

        public delegate void DeviceArrivedHandler(DeviceMonitor mon, string name);

        public event DeviceArrivedHandler DeviceArrived;

        private void RaiseDeviceArrived(string name)
        {
            DeviceArrived?.Invoke(this, name);
        }

        #endregion

        #region Windows SDK definitions

        private const uint DBT_DEVICEARRIVAL = 0x8000;

        private const uint DBT_DEVTYP_DEVICEINTERFACE = 0x5;

        [StructLayout(LayoutKind.Sequential)]
        struct DEV_BROADCAST_HDR
        {
#pragma warning disable 0649
            public uint dbch_Size;
            public uint dbch_DeviceType;
            public uint dbch_Reserved;
#pragma warning restore 0649
        }

        private const int WM_DEVICECHANGE = 0x219;

        private Guid GUID_DEVINTERFACE_USB_DEVICE = new Guid(0xA5DCBF10, 0x6530, 0x11D2, 0x90, 0x1F, 0x00, 0xC0, 0x4F, 0xB9, 0x51, 0xED);

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public struct DEV_BROADCAST_DEVICEINTERFACE
        {
#pragma warning disable 0649
            public uint dbcc_size;
            public uint dbcc_devicetype;
            public uint dbcc_reserved;
            public Guid dbcc_classguid;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 255)]
            public string dbcc_name;
#pragma warning restore 0649
        }

        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr RegisterDeviceNotification(
            IntPtr Recipient,
            IntPtr NotificationFilter,
            uint Flags);

        private const uint DEVICE_NOTIFY_WINDOW_HANDLE = 0x0;

        [DllImport("user32.dll", SetLastError = true)]
        static extern bool UnregisterDeviceNotification(IntPtr Handle);

        #endregion

        #region IDisposable Support

        private bool disposedValue_ = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue_) {
                if (notifyHandle_ != IntPtr.Zero) {
                    UnregisterDeviceNotification(notifyHandle_);
                    notifyHandle_ = IntPtr.Zero;
                }

                disposedValue_ = true;
            }
        }

        ~DeviceMonitor()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
