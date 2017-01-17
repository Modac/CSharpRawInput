using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace RawInput {

    class RawInput {

        public const byte MOUSE = 0x80;
        public const byte KEYBOARD = 0x40;
        public const byte JOYSTICK = 0x20;
        public const byte GAMEPAD = 0x10;
        public const byte KEYPAD = 0x8;
        public const byte POINTER = 0x4;
        public const byte SYSTEM_CONTROL = 0x2;
        public const byte CONSUMER_AUDIO_CONTROL = 0x1;

        
        public RawInput(IntPtr hwndTarget, byte deviceMask) {
            RAWINPUTDEVICE[] rid = new RAWINPUTDEVICE[Tools.hammingWeight(deviceMask)];
            if(rid.Length == 0) return;

            int i;
            for(i=0;i<rid.Length;i++) {
                rid[i].usUsagePage = 0x01;
                rid[i].dwFlags = Constants.RIDEV_INPUTSINK;
                rid[i].hwndTarget = hwndTarget;
            }

            i = 0;

            if((deviceMask & MOUSE) == MOUSE) {
                rid[i++].usUsage = 0x02;
            }
            if((deviceMask & KEYBOARD) == KEYBOARD) {
                rid[i++].usUsage = 0x06;
            }
            if((deviceMask & JOYSTICK) == JOYSTICK) {
                rid[i++].usUsage = 0x04;
            }
            if((deviceMask & GAMEPAD) == GAMEPAD) {
                rid[i++].usUsage = 0x05;
            }
            if((deviceMask & KEYPAD) == KEYPAD) {
                rid[i++].usUsage = 0x07;
            }
            if((deviceMask & POINTER) == POINTER) {
                rid[i++].usUsage = 0x01;
            }
            if((deviceMask & SYSTEM_CONTROL) == SYSTEM_CONTROL) {
                rid[i++].usUsage = 0x80;
            }
            if((deviceMask & CONSUMER_AUDIO_CONTROL) == CONSUMER_AUDIO_CONTROL) {
                rid[i].usUsagePage = 0x0C;
                rid[i++].usUsage = 0x01;
            }


            if(!RegisterRawInputDevices(rid, (uint) rid.Length, (uint) Marshal.SizeOf(rid[0]))) {
                throw new ApplicationException("Failed to register raw input device(s).");
            }
        }



        #region Windows.h structure declarations

        [StructLayout(LayoutKind.Sequential)]
        internal struct RAWINPUTDEVICE {
            [MarshalAs(UnmanagedType.U2)]
            public ushort usUsagePage;
            [MarshalAs(UnmanagedType.U2)]
            public ushort usUsage;
            [MarshalAs(UnmanagedType.U4)]
            public int dwFlags;
            public IntPtr hwndTarget;
        }

        #endregion Windows.h structure declarations

        #region DllImports

        [DllImport("User32.dll")]
        extern static uint GetRawInputDeviceList(IntPtr pRawInputDeviceList, ref uint uiNumDevices, uint cbSize);

        [DllImport("User32.dll")]
        extern static uint GetRawInputDeviceInfo(IntPtr hDevice, uint uiCommand, IntPtr pData, ref uint pcbSize);

        [DllImport("User32.dll")]
        extern static bool RegisterRawInputDevices(RAWINPUTDEVICE[] pRawInputDevice, uint uiNumDevices, uint cbSize);

        [DllImport("User32.dll")]
        extern static uint GetRawInputData(IntPtr hRawInput, uint uiCommand, IntPtr pData, ref uint pcbSize, uint cbSizeHeader);

        #endregion DllImports
    }
}
