using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RawInput {
    abstract class InputDevice {

        private string deviceClassGUID;

        public string DeviceClassGUID {
            get {
                return deviceClassGUID;
            }
        }

    }
}
