using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common {
    public class Data: INotifyPropertyChanged {

        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged(String info) {
            if (PropertyChanged != null) {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }

        public Data() {
            //this.guid = Methods.getGUID();
            this.dryArea = 0;
            this.dryLevel = 0;
            this.paddyArea = 0;
            this.paddyLevel = 0;
        }


        private string name;
        private double paddyArea;
        private double dryArea;
        private double paddyLevel;
        private double dryLevel;
        private string summary;

        /// <summary>
        /// 名称
        /// </summary>
        public string Name {
            get {
                return name;
            }

            set {
                name = value;
                this.NotifyPropertyChanged("Name");
            }
        }
        /// <summary>
        /// 水田面积 
        /// </summary>
        public double PaddyArea {
            get {
                return Math.Round(paddyArea,4);
            }

            set {
                paddyArea = value;
                this.NotifyPropertyChanged("PaddyArea");
            }
        }
        /// <summary>
        /// 旱地面积
        /// </summary>
        public double DryArea {
            get {
                return Math.Round(dryArea,4);
            }

            set {
                dryArea = value;
                this.NotifyPropertyChanged("DryArea");
            }
        }
        /// <summary>
        /// 水田等级
        /// </summary>
        public double PaddyLevel {
            get {
                return paddyLevel;
            }

            set {
                paddyLevel = value;
                this.NotifyPropertyChanged("PaddyLevel");
            }
        }

        public double DryLevel {
            get {
                return dryLevel;
            }

            set {
                dryLevel = value;
                this.NotifyPropertyChanged("DryLevel");
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
                this.NotifyPropertyChanged("Summary");
            }
        }

        public virtual  void Clear() {
            this.name = string.Empty;
            this.summary = string.Empty;
        }
    }
}
