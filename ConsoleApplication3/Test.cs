using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace RawInput {
    class Test {

        #region const definitions

        // The following constants are defined in Windows.h

        private const int RIDEV_INPUTSINK = 0x00000100;
        private const int RID_INPUT = 0x10000003;

        private const int FAPPCOMMAND_MASK = 0xF000;
        private const int FAPPCOMMAND_MOUSE = 0x8000;
        private const int FAPPCOMMAND_OEM = 0x1000;

        private const int RIM_TYPEMOUSE = 0;
        private const int RIM_TYPEKEYBOARD = 1;
        private const int RIM_TYPEHID = 2;

        private const int RIDI_DEVICENAME = 0x20000007;

        private const int WM_KEYDOWN = 0x0100;
        private const int WM_SYSKEYDOWN = 0x0104;
        private const int WM_INPUT = 0x00FF;
        private const int VK_OEM_CLEAR = 0xFE;
        private const int VK_LAST_KEY = VK_OEM_CLEAR; // this is a made up value used as a sentinel

        #endregion const definitions

        #region structs & enums

        /// <summary>
        /// An enum representing the different types of input devices.
        /// </summary>
        public enum DeviceType {
            Key,
            Mouse,
            OEM
        }

        /// <summary>
        /// Class encapsulating the information about a
        /// keyboard event, including the device it
        /// originated with and what key was pressed
        /// </summary>
        public class DeviceInfo {
            public string deviceName;
            public string deviceType;
            public IntPtr deviceHandle;
            public string Name;
            public string source;
            public ushort key;
            public string vKey;
        }

        #region Windows.h structure declarations

        // The following structures are defined in Windows.h

        [StructLayout(LayoutKind.Sequential)]
        internal struct RAWINPUTDEVICELIST {
            public IntPtr hDevice;
            [MarshalAs(UnmanagedType.U4)]
            public int dwType;
        }

        [StructLayout(LayoutKind.Explicit)]
        internal struct RAWINPUT {
            [FieldOffset(0)]
            public RAWINPUTHEADER header;
            [FieldOffset(16)]
            public RAWMOUSE mouse;
            [FieldOffset(16)]
            public RAWKEYBOARD keyboard;
            [FieldOffset(16)]
            public RAWHID hid;
        }

        [StructLayout(LayoutKind.Sequential)]
        internal struct RAWINPUTHEADER {
            [MarshalAs(UnmanagedType.U4)]
            public int dwType;
            [MarshalAs(UnmanagedType.U4)]
            public int dwSize;
            public IntPtr hDevice;
            [MarshalAs(UnmanagedType.U4)]
            public int wParam;
        }

        [StructLayout(LayoutKind.Sequential)]
        internal struct RAWHID {
            [MarshalAs(UnmanagedType.U4)]
            public int dwSizHid;
            [MarshalAs(UnmanagedType.U4)]
            public int dwCount;
        }

        [StructLayout(LayoutKind.Sequential)]
        internal struct BUTTONSSTR {
            [MarshalAs(UnmanagedType.U2)]
            public ushort usButtonFlags;
            [MarshalAs(UnmanagedType.U2)]
            public ushort usButtonData;
        }

        [StructLayout(LayoutKind.Explicit)]
        internal struct RAWMOUSE {
            [MarshalAs(UnmanagedType.U2)]
            [FieldOffset(0)]
            public ushort usFlags;
            [MarshalAs(UnmanagedType.U4)]
            [FieldOffset(4)]
            public uint ulButtons;
            [FieldOffset(4)]
            public BUTTONSSTR buttonsStr;
            [MarshalAs(UnmanagedType.U4)]
            [FieldOffset(8)]
            public uint ulRawButtons;
            [FieldOffset(12)]
            public int lLastX;
            [FieldOffset(16)]
            public int lLastY;
            [MarshalAs(UnmanagedType.U4)]
            [FieldOffset(20)]
            public uint ulExtraInformation;
        }

        [StructLayout(LayoutKind.Sequential)]
        internal struct RAWKEYBOARD {
            [MarshalAs(UnmanagedType.U2)]
            public ushort MakeCode;
            [MarshalAs(UnmanagedType.U2)]
            public ushort Flags;
            [MarshalAs(UnmanagedType.U2)]
            public ushort Reserved;
            [MarshalAs(UnmanagedType.U2)]
            public ushort VKey;
            [MarshalAs(UnmanagedType.U4)]
            public uint Message;
            [MarshalAs(UnmanagedType.U4)]
            public uint ExtraInformation;
        }

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


        #endregion structs & enums

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

        public static void test1() {

            uint deviceCount = 0;
            int dwSize = (Marshal.SizeOf(typeof(RAWINPUTDEVICELIST)));

            // Get the number of raw input devices in the list,
            // then allocate sufficient memory and get the entire list
            if(GetRawInputDeviceList(IntPtr.Zero, ref deviceCount, (uint) dwSize) == 0) {
                IntPtr pRawInputDeviceList = Marshal.AllocHGlobal((int) (dwSize * deviceCount));
                GetRawInputDeviceList(pRawInputDeviceList, ref deviceCount, (uint) dwSize);

                // Iterate through the list, discarding undesired items
                // and retrieving further information on keyboard devices

                Console.WriteLine("DeviceCount: " + deviceCount);

                for(int i = 0; i < deviceCount; i++) {
                    DeviceInfo dInfo;
                    string deviceName;
                    uint pcbSize = 0;

                    RAWINPUTDEVICELIST rid = (RAWINPUTDEVICELIST) Marshal.PtrToStructure(
                                               new IntPtr((pRawInputDeviceList.ToInt32() + (dwSize * i))),
                                               typeof(RAWINPUTDEVICELIST));

                    GetRawInputDeviceInfo(rid.hDevice, RIDI_DEVICENAME, IntPtr.Zero, ref pcbSize);

                    if(pcbSize > 0) {
                        IntPtr pData = Marshal.AllocHGlobal((int) pcbSize);
                        GetRawInputDeviceInfo(rid.hDevice, RIDI_DEVICENAME, pData, ref pcbSize);
                        deviceName = (string) Marshal.PtrToStringAnsi(pData);

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("DeviceName: ");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine(deviceName);

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("dwType: ");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine(rid.dwType);


                        if(deviceName.Length > 0 && deviceName.StartsWith("\\\\?\\")) {

                            deviceName = deviceName.Substring(4);
                            string[] split = deviceName.Split('#');

                            string id_01 = split[0];    // ACPI (Class code)
                            string id_02 = split[1];    // PNP0303 (SubClass code)
                            string id_03 = split[2];    // 3&13c0b0c5&0 (Protocol code)
                                                        //The final part is the class GUID and is not needed here

                            //Open the appropriate key as read-only so no permissions
                            //are needed.
                            RegistryKey OurKey = Registry.LocalMachine;

                            string findme = string.Format(@"System\CurrentControlSet\Enum\{0}\{1}\{2}", id_01, id_02, id_03);

                            OurKey = OurKey.OpenSubKey(findme, false);

                            //Retrieve the desired information and set isKeyboard
                            string deviceDesc = (string) OurKey.GetValue("DeviceDesc");
                            deviceDesc = deviceDesc.Substring(deviceDesc.LastIndexOf("%;")+2);

                            string deviceClass = (string) OurKey.GetValue("ClassGUID");

                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write("DeviceDescShort: ");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine(deviceDesc);

                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write("ClassGUID: ");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine(deviceClass + " | " + Tools.getDeviceClass(deviceClass));
                               
                        }

                        Console.BackgroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("----------------------------");
                        Console.BackgroundColor = ConsoleColor.Black;

                    }
                }
            }
        }

        public static void test2() {
            Console.WriteLine(Tools.getDeviceClassGUID("Biometric"));
            Console.WriteLine(Tools.getDeviceClassGUID("GPS"));
            Console.WriteLine(Tools.getDeviceClassGUID("1394"));
            Console.WriteLine(Tools.getDeviceClassGUID("Processor"));
        }

    }
}
