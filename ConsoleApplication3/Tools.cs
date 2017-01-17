using System;

namespace RawInput {

    class Tools {


        static Tools() {

            initDeviceClassNames();
            initDeviceClasses();
            initDeviceClassGUIDs();
        }

        #region Hamming Weight

        public static int hammingWeight(ulong val) {
            return hammingWeight((uint) val) + hammingWeight((uint) (val >> 32));
        }

        public static int hammingWeight(uint val) {
            val = val - ((val >> 1) & 0x55555555);
            val = (val & 0x33333333) + ((val >> 2) & 0x33333333);
            return (int) (((val + (val >> 4) & 0x0F0F0F0F) * 0x01010101) >> 24);
        }

        public static int hammingWeight(ushort val) {
            return hammingWeight((uint)val);
        }

        public static int hammingWeight(byte val) {
            return hammingWeight((uint) val);
        }

        #endregion Hamming Weight

        #region Device Classes

        private static string[] deviceClassNames = new string[48];
        
        private static void initDeviceClassNames() {
            int i = 0;
            deviceClassNames[i++] = "Battery Devices";
            deviceClassNames[i++] = "Biometric Device";
            deviceClassNames[i++] = "Bluetooth Devices";
            deviceClassNames[i++] = "CD-ROM Drives";
            deviceClassNames[i++] = "Disk Drives";
            deviceClassNames[i++] = "Display Adapters";
            deviceClassNames[i++] = "Floppy Disk Controllers";
            deviceClassNames[i++] = "Floppy Disk Drives";
            deviceClassNames[i++] = "Global Positioning System/Global Navigation Satellite System";
            deviceClassNames[i++] = "Hard Disk Controllers";
            deviceClassNames[i++] = "Human Interface Devices (HID)";
            deviceClassNames[i++] = "IEEE 1284.4 Devices";
            deviceClassNames[i++] = "IEEE 1284.4 Print Functions";
            deviceClassNames[i++] = "IEEE 1394 Devices That Support the 61883 Protocol";
            deviceClassNames[i++] = "IEEE 1394 Devices That Support the AVC Protocol";
            deviceClassNames[i++] = "IEEE 1394 Devices That Support the SBP2 Protocol";
            deviceClassNames[i++] = "IEEE 1394 Host Bus Controller";
            deviceClassNames[i++] = "Imaging Device";
            deviceClassNames[i++] = "IrDA Devices";
            deviceClassNames[i++] = "Keyboard";
            deviceClassNames[i++] = "Media Changers";
            deviceClassNames[i++] = "Memory Technology Driver";
            deviceClassNames[i++] = "Modem";
            deviceClassNames[i++] = "Monitor";
            deviceClassNames[i++] = "Mouse";
            deviceClassNames[i++] = "Multifunction Devices";
            deviceClassNames[i++] = "Multimedia";
            deviceClassNames[i++] = "Multiport Serial Adapters";
            deviceClassNames[i++] = "Network Adapter";
            deviceClassNames[i++] = "Network Client";
            deviceClassNames[i++] = "Network Service";
            deviceClassNames[i++] = "Network Transport";
            deviceClassNames[i++] = "PCI SSL Accelerator";
            deviceClassNames[i++] = "PCMCIA Adapters";
            deviceClassNames[i++] = "Ports (COM & LPT ports)";
            deviceClassNames[i++] = "Printers";
            deviceClassNames[i++] = "Printers, Bus-specific class drivers";
            deviceClassNames[i++] = "Processors";
            deviceClassNames[i++] = "SCSI and RAID Controllers";
            deviceClassNames[i++] = "Sensors";
            deviceClassNames[i++] = "Smart Card Readers";
            deviceClassNames[i++] = "Storage Volumes";
            deviceClassNames[i++] = "System Devices";
            deviceClassNames[i++] = "Tape Drives";
            deviceClassNames[i++] = "USB Device";
            deviceClassNames[i++] = "Windows CE USB ActiveSync Devices";
            deviceClassNames[i++] = "Windows Portable Devices (WPD)";
            deviceClassNames[i++] = "Windows SideShow";
        }

        private static string[] deviceClasses = new string[48];

        private static void initDeviceClasses() {
            int i = 0;
            deviceClasses[i++] = "Battery";
            deviceClasses[i++] = "Biometric";
            deviceClasses[i++] = "Bluetooth";
            deviceClasses[i++] = "CDROM";
            deviceClasses[i++] = "DiskDrive";
            deviceClasses[i++] = "Display";
            deviceClasses[i++] = "FDC";
            deviceClasses[i++] = "FloppyDisk";
            deviceClasses[i++] = "GPS";
            deviceClasses[i++] = "HDC";
            deviceClasses[i++] = "HIDClass";
            deviceClasses[i++] = "Dot4";
            deviceClasses[i++] = "Dot4Print";
            deviceClasses[i++] = "61883";
            deviceClasses[i++] = "AVC";
            deviceClasses[i++] = "SBP2";
            deviceClasses[i++] = "1394";
            deviceClasses[i++] = "Image";
            deviceClasses[i++] = "Infrared";
            deviceClasses[i++] = "Keyboard";
            deviceClasses[i++] = "MediumChanger";
            deviceClasses[i++] = "MTD";
            deviceClasses[i++] = "Modem";
            deviceClasses[i++] = "Monitor";
            deviceClasses[i++] = "Mouse";
            deviceClasses[i++] = "Multifunction";
            deviceClasses[i++] = "Media";
            deviceClasses[i++] = "MultiportSerial";
            deviceClasses[i++] = "Net";
            deviceClasses[i++] = "NetClient";
            deviceClasses[i++] = "NetService";
            deviceClasses[i++] = "NetTrans";
            deviceClasses[i++] = "SecurityAccelerator";
            deviceClasses[i++] = "PCMCIA";
            deviceClasses[i++] = "Ports";
            deviceClasses[i++] = "Printer";
            deviceClasses[i++] = "PNPPrinters";
            deviceClasses[i++] = "Processor";
            deviceClasses[i++] = "SCSIAdapter";
            deviceClasses[i++] = "Sensor";
            deviceClasses[i++] = "SmartCardReader";
            deviceClasses[i++] = "Volume";
            deviceClasses[i++] = "System";
            deviceClasses[i++] = "TapeDrive";
            deviceClasses[i++] = "USBDevice";
            deviceClasses[i++] = "WCEUSBS";
            deviceClasses[i++] = "WPD";
            deviceClasses[i++] = "SideShow";
        }

        private static string[] deviceClassGUIDs = new string[48];

        private static void initDeviceClassGUIDs() {
            int i = 0;
            deviceClassGUIDs[i++] = "{72631e54-78a4-11d0-bcf7-00aa00b7b32a}";
            deviceClassGUIDs[i++] = "{53D29EF7-377C-4D14-864B-EB3A85769359}";
            deviceClassGUIDs[i++] = "{e0cbf06c-cd8b-4647-bb8a-263b43f0f974}";
            deviceClassGUIDs[i++] = "{4d36e965-e325-11ce-bfc1-08002be10318}";
            deviceClassGUIDs[i++] = "{4d36e967-e325-11ce-bfc1-08002be10318}";
            deviceClassGUIDs[i++] = "{4d36e968-e325-11ce-bfc1-08002be10318}";
            deviceClassGUIDs[i++] = "{4d36e969-e325-11ce-bfc1-08002be10318}";
            deviceClassGUIDs[i++] = "{4d36e980-e325-11ce-bfc1-08002be10318}";
            deviceClassGUIDs[i++] = "{6bdd1fc3-810f-11d0-bec7-08002be2092f}";
            deviceClassGUIDs[i++] = "{4d36e96a-e325-11ce-bfc1-08002be10318}";
            deviceClassGUIDs[i++] = "{745a17a0-74d3-11d0-b6fe-00a0c90f57da}";
            deviceClassGUIDs[i++] = "{48721b56-6795-11d2-b1a8-0080c72e74a2}";
            deviceClassGUIDs[i++] = "{49ce6ac8-6f86-11d2-b1e5-0080c72e74a2}";
            deviceClassGUIDs[i++] = "{7ebefbc0-3200-11d2-b4c2-00a0C9697d07}";
            deviceClassGUIDs[i++] = "{c06ff265-ae09-48f0-812c-16753d7cba83}";
            deviceClassGUIDs[i++] = "{d48179be-ec20-11d1-b6b8-00c04fa372a7}";
            deviceClassGUIDs[i++] = "{6bdd1fc1-810f-11d0-bec7-08002be2092f}";
            deviceClassGUIDs[i++] = "{6bdd1fc6-810f-11d0-bec7-08002be2092f}";
            deviceClassGUIDs[i++] = "{6bdd1fc5-810f-11d0-bec7-08002be2092f}";
            deviceClassGUIDs[i++] = "{4d36e96b-e325-11ce-bfc1-08002be10318}";
            deviceClassGUIDs[i++] = "{ce5939ae-ebde-11d0-b181-0000f8753ec4}";
            deviceClassGUIDs[i++] = "{4d36e970-e325-11ce-bfc1-08002be10318}";
            deviceClassGUIDs[i++] = "{4d36e96d-e325-11ce-bfc1-08002be10318}";
            deviceClassGUIDs[i++] = "{4d36e96e-e325-11ce-bfc1-08002be10318}";
            deviceClassGUIDs[i++] = "{4d36e96f-e325-11ce-bfc1-08002be10318}";
            deviceClassGUIDs[i++] = "{4d36e971-e325-11ce-bfc1-08002be10318}";
            deviceClassGUIDs[i++] = "{4d36e96c-e325-11ce-bfc1-08002be10318}";
            deviceClassGUIDs[i++] = "{50906cb8-ba12-11d1-bf5d-0000f805f530}";
            deviceClassGUIDs[i++] = "{4d36e972-e325-11ce-bfc1-08002be10318}";
            deviceClassGUIDs[i++] = "{4d36e973-e325-11ce-bfc1-08002be10318}";
            deviceClassGUIDs[i++] = "{4d36e974-e325-11ce-bfc1-08002be10318}";
            deviceClassGUIDs[i++] = "{4d36e975-e325-11ce-bfc1-08002be10318}";
            deviceClassGUIDs[i++] = "{268c95a1-edfe-11d3-95c3-0010dc4050a5}";
            deviceClassGUIDs[i++] = "{4d36e977-e325-11ce-bfc1-08002be10318}";
            deviceClassGUIDs[i++] = "{4d36e978-e325-11ce-bfc1-08002be10318}";
            deviceClassGUIDs[i++] = "{4d36e979-e325-11ce-bfc1-08002be10318}";
            deviceClassGUIDs[i++] = "{4658ee7e-f050-11d1-b6bd-00c04fa372a7}";
            deviceClassGUIDs[i++] = "{50127dc3-0f36-415e-a6cc-4cb3be910b65}";
            deviceClassGUIDs[i++] = "{4d36e97b-e325-11ce-bfc1-08002be10318}";
            deviceClassGUIDs[i++] = "{5175d334-c371-4806-b3ba-71fd53c9258d}";
            deviceClassGUIDs[i++] = "{50dd5230-ba8a-11d1-bf5d-0000f805f530}";
            deviceClassGUIDs[i++] = "{71a27cdd-812a-11d0-bec7-08002be2092f}";
            deviceClassGUIDs[i++] = "{4d36e97d-e325-11ce-bfc1-08002be10318}";
            deviceClassGUIDs[i++] = "{6d807884-7d21-11cf-801c-08002be10318}";
            deviceClassGUIDs[i++] = "{88BAE032-5A81-49f0-BC3D-A4FF138216D6}";
            deviceClassGUIDs[i++] = "{25dbce51-6c8f-4a72-8a6d-b54c2b4fc835}";
            deviceClassGUIDs[i++] = "{eec5ad98-8080-425f-922a-dabf3de3f69a}";
            deviceClassGUIDs[i++] = "{997b5d8d-c442-4f2e-baf3-9c8e671e9e21}";
        }

        public static string getDeviceClassName(string guid) {
            for(int i = 0; i < deviceClassGUIDs.Length; i++) {
                if(deviceClassGUIDs[i] == guid) return deviceClassNames[i];
            }
            return "Unknown";
        }

        public static string getDeviceClass(string guid) {
            for(int i = 0; i < deviceClassGUIDs.Length; i++) {
                if(deviceClassGUIDs[i] == guid) return deviceClasses[i];
            }
            return "Unknown";
        }

        public static string getDeviceClassGUID(string deviceClass) {
            for(int i = 0; i < deviceClassGUIDs.Length; i++) {
                if(deviceClasses[i] == deviceClass) return deviceClassGUIDs[i];
            }
            return "Unknown";
        }

        #endregion Device Classes

    }

}