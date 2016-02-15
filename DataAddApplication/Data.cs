using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAddApplication {
    public class Data {

        public Data() {
            this.guid = Common.getGUID();
        }

        private Guid guid;
        private int id;
        private string name;
        private string record;
        private string acceptance;
        private decimal amount;
        private double totalArea;
        private double paddyArea;
        private int paddyLevel;
        private double dryArea;
        private int dryLevel;
        private string summary;

        /// <summary>
        /// GUID
        /// </summary>
        public Guid Guid {
            get {
                return guid;
            }

            set {
                guid = value;
            }
        }
        /// <summary>
        /// ID
        /// </summary>
        public int Id {
            get {
                return id;
            }

            set {
                id = value;
            }
        }
        /// <summary>
        /// 项目名称
        /// </summary>
        public string Name {
            get {
                return name;
            }

            set {
                name = value;
            }
        }
        /// <summary>
        /// 部备案号
        /// </summary>
        public string Record {
            get {
                return record;
            }

            set {
                record = value;
            }
        }
        /// <summary>
        /// 投资总额
        /// </summary>
        public decimal Amount {
            get {
                return amount;
            }

            set {
                amount = value;
            }
        }
        /// <summary>
        /// 水田面积
        /// </summary>
        public double PaddyArea {
            get {
                return paddyArea;
            }

            set {
                paddyArea = value;
            }
        }
        /// <summary>
        /// 总面积
        /// </summary>
        public double TotalArea {
            get {
                return totalArea;
            }

            set {
                totalArea = value;
            }
        }
        /// <summary>
        /// 水田等级
        /// </summary>
        public int PaddyLevel {
            get {
                return paddyLevel;
            }

            set {
                paddyLevel = value;
            }
        }
        /// <summary>
        /// 旱地等级
        /// </summary>
        public int DryLevel {
            get {
                return dryLevel;
            }

            set {
                dryLevel = value;
            }
        }
        /// <summary>
        /// 备注
        /// </summary>
        public string Summary {
            get {
                return summary;
            }

            set {
                summary = value;
            }
        }
        /// <summary>
        /// 验收文号
        /// </summary>
        public string Acceptance {
            get {
                return acceptance;
            }

            set {
                acceptance = value;
            }
        }
        /// <summary>
        /// 旱地面积
        /// </summary>
        public double DryArea {
            get {
                return dryArea;
            }

            set {
                dryArea = value;
            }
        }
    }
}
