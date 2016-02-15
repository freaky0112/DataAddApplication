using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common {
    class Methods {
        public static Guid setGUID() {
            System.Guid guid = new Guid();
            guid = Guid.NewGuid();
            return guid;
        }
    }
}
