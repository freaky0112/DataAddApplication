using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common {
    /// <summary>
    /// 农转用数据
    /// </summary>
    class NZYData:Data {
        public NZYData() {
            this.guid = Methods.getGUID();
        }
        private Guid guid;
        private List<NZYDKData> dk;
        /// <summary>
        /// 农转用项目GUID
        /// </summary>
        public Guid Guid {
            get {
                return guid;
            }
        }
        /// <summary>
        /// 批次所含地块
        /// </summary>
        internal List<NZYDKData> Dk {
            get {
                return dk;
            }

            set {
                dk = value;
            }
        }

    }

    class NZYDKData:Data {
        public NZYDKData() { }


    }
}
