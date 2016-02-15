using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common {
    class Data {

        public Data() {
            //this.guid = Methods.getGUID();
        }


        protected string name;
        protected double paddyArea;
        protected double dryArea;
        protected double paddyLevel;
        protected double dryLevel;
        protected string summary;

        /// <summary>
        /// 名称
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
        /// <summary>
        /// 水田等级
        /// </summary>
        public double PaddyLevel {
            get {
                return PaddyLevel;
            }

            set {
                PaddyLevel = value;
            }
        }

        public double DryLevel {
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
    }
}
