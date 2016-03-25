using System;
using System.IO;

namespace GM3305Comm
{
    public class Device : IDisposable
    {
        public Device()
        {
            waitHandle_ = Native.CreateSemaphore(IntPtr.Zero, 0, 100, IntPtr.Zero);
        }

        public bool Open()
        {
            devHandle_ = Native.CreateFileW(
                @"\\.\GM3305Fltr",
                Native.ACCESS_MASK.GENERIC_READ | Native.ACCESS_MASK.GENERIC_WRITE,
                FileShare.Read,
                IntPtr.Zero,
                FileMode.Open,
                0,
                IntPtr.Zero
                );

            if (devHandle_ == Native.INVALID_HANDLE_VALUE) {
                Close();
                return false;
            }

            var buf = BitConverter.GetBytes(waitHandle_.ToInt32());
            uint count;
            if (!Native.DeviceIoControl(devHandle_, 0x222400, buf, new byte[] { }, out count)) {
                Close();
                return false;
            }

            return true;
        }

        public void Close()
        {
            if (devHandle_ != IntPtr.Zero) {
                uint count;
                Native.DeviceIoControl(devHandle_, 0x222404, new byte[] { }, new byte[] { }, out count);
                Native.CloseHandle(devHandle_);
                devHandle_ = IntPtr.Zero;
            }
        }

        private bool SetValue(byte id, int value)
        {
            if (devHandle_ == IntPtr.Zero)
                return false;

            var buffer = new byte[] { 0x00, 0x03, 0x00, 0x00, id, 0x01, (byte)value, 0x00, 0x00, 0x00, 0x00, 0x00 };
            uint count;
            if (!Native.DeviceIoControl(devHandle_, 0x222478, buffer, new byte[] { }, out count))
                return false;

            return true;
        }

        public bool SetLEDEnabled(bool on)
        {
            return SetValue(0x53, on ? 0x01 : 0x00);
        }

        public enum Strength : int
        {
            Low = 1,
            Middle,
            High
        }

        public bool SetLEDStrength(Strength strength)
        {
            return SetValue(0x54, (int)strength);
        }

        public enum BlinkSpeed : int
        {
            Off = 0,
            Slow,
            Middle,
            Fast
        }

        public bool SetLEDBlinkSpeed(BlinkSpeed speed)
        {
            return SetValue(0x55, (int)speed);
        }

        public enum DPI : int
        {
            DPI400 = 0,
            DPI800,
            DPI1600,
            DPI3200
        }

        public bool SetDPI(DPI dpi)
        {
            return SetValue(0x51, (int)dpi);
        }

        public enum Hz : int
        {
            Hz125 = 0,
            Hz250,
            Hz500,
            Hz1000
        }

        public bool SetHz(Hz hz)
        {
            return SetValue(0x52, (int)hz);
        }

        private IntPtr devHandle_;
        private IntPtr waitHandle_;

        #region IDisposable Support

        private bool disposedValue_ = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue_) {
                Close();

                Native.CloseHandle(waitHandle_);
                waitHandle_ = IntPtr.Zero;

                disposedValue_ = true;
            }
        }

        ~Device()
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
