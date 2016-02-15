using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common {
    /// <summary>
    /// 农转用数据
    /// </summary>
    public class NZYData:Data {
        public NZYData(string name) {
            this.Name = name;
            this.guid = Methods.setGUID();
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
        public List<NZYDKData> Dk {
            get {
                return dk;
            }

            set {
                dk = value;
            }
        }

        public override string ToString() {
            StringBuilder sb = new StringBuilder();
            sb.Append("该批次包含耕地");
            sb.Append(this.PaddyArea + this.DryArea);
            sb.Append("平方米，其中");
            if (PaddyArea>0) {
                sb.Append("水田");
                sb.Append(PaddyArea);
                sb.Append("平方米，平均等级");
                sb.Append(PaddyLevel);
                sb.Append("级");
                if (DryArea>0) {
                    sb.Append("，");
                }
            }
            if (DryArea>0) {
                sb.Append("旱地");
                sb.Append(DryArea);
                sb.Append("平方米，平均等级");
                sb.Append(DryLevel);
                sb.Append("级");
            }
            sb.Append("。");
            return sb.ToString();
        }

    }

    public class NZYDKData:Data {
        public NZYDKData(string name) {
            this.Name = name;
        }

    }
}
