using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RawInput {

    class Constants {

        #region const definitions

        // The following constants are defined in Windows.h

        public const int RIDEV_INPUTSINK = 0x00000100;
        public const int RID_INPUT = 0x10000003;

        public const int FAPPCOMMAND_MASK = 0xF000;
        public const int FAPPCOMMAND_MOUSE = 0x8000;
        public const int FAPPCOMMAND_OEM = 0x1000;

        public const int RIM_TYPEMOUSE = 0;
        public const int RIM_TYPEKEYBOARD = 1;
        public const int RIM_TYPEHID = 2;

        public const int RIDI_DEVICENAME = 0x20000007;

        public const int WM_KEYDOWN = 0x0100;
        public const int WM_SYSKEYDOWN = 0x0104;
        public const int WM_INPUT = 0x00FF;
        public const int VK_OEM_CLEAR = 0xFE;
        public const int VK_LAST_KEY = VK_OEM_CLEAR; // this is a made up value used as a sentinel

        #endregion const definitions

    }
}
