using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common {
    /// <summary>
    /// 农转用数据
    /// </summary>
    public class NZYData:Data {
        
       
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="name">批次名称</param>
        public NZYData(string name) {
            this.Name = name;
            this.guid = Methods.setGUID();
            this.dk = new ObservableCollection<NZYDKData>();
            this.dk.CollectionChanged += Dk_CollectionChanged;
        }

        private void Dk_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e) {
            //throw new NotImplementedException();
            foreach(NZYDKData data in dk) {
                data.ID = dk.IndexOf(data) + 1;
                data.PropertyChanged += Data_PropertyChanged;
            }
            
        }
        
        private void Data_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e) {
            throw new NotImplementedException();
        }

        private Guid guid;
        private ObservableCollection<NZYDKData> dk;
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
        public ObservableCollection<NZYDKData> Dk {
            get {
                return dk;
            }

            set {
                dk = value;
                this.NotifyPropertyChanged("Dk");
            }
        }
        /// <summary>
        /// 清除所有元素
        /// </summary>
        public override void Clear() {
            Name = string.Empty;
            Summary = string.Empty;
            dk.Clear();
        }

        public string Text {
            get { return this.ToString(); }
        }

        public override string ToString() {
            StringBuilder sb = new StringBuilder();
            sb.Append(this.Name);
            sb.Append("批次包含耕地");
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

        private int id;

        public int ID {
            get {
                return id;
            }

            set {
                id = value; 
            }
        }
    }
}
