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
    public class NZYData : Data {


        /// <summary>
        /// 初始化新数据
        /// </summary>
        /// <param name="name">批次名称</param>
        public NZYData(string name) {
            this.Name = name;
            //初始化GUID
            this.guid = Methods.setGUID();
            this.Initialize();
        }
        /// <summary>
        /// 设置已有数据
        /// </summary>
        /// <param name="name">批次名称</param>
        /// <param name="guid">GUID</param>
        public NZYData(string name,Guid guid) {
            this.Name = name;
            //初始化GUID
            this.guid = guid;
            this.Initialize();
        }
        /// <summary>
        /// 初始化数据
        /// </summary>
        private void Initialize() {
            this.dk = new ObservableCollection<NZYDKData>();
            //地块变化数据监听
            this.dk.CollectionChanged += Dk_CollectionChanged;
            //this.dk.Add(new NZYDKData(""));
        }
        /// <summary>
        /// 地块数变化监听
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Dk_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e) {
            //throw new NotImplementedException();
            foreach (NZYDKData data in dk) {
                data.ID = dk.IndexOf(data) + 1;
                data.PropertyChanged += Data_PropertyChanged;
            }
        }
        /// <summary>
        /// 添加数据
        /// </summary>
        /// <param name="index">第几个数据后插入数据（从1开始）</param>
        /// <returns>新建数据序号（从0开始）</returns>
        public int AddNZYDKData(int index) {
            //bool hasNull = false;
            foreach(NZYDKData data in dk) {
                if (!string.IsNullOrWhiteSpace(data.Name) ){
                    return index = dk.IndexOf(data);
                }
            }
            dk.Insert(index, new NZYDKData());
            return index;
        }
        /// <summary>
        /// 删除地块数据
        /// </summary>
        /// <param name="index">删除第几个数据（从1开始）</param>
        /// <returns>是否成功</returns>
        public bool DeleteNZYDKData(int index) {
            try {
                this.dk.RemoveAt(index - 1);

            } catch (Exception) {
                return false;
                throw;
            }
            return true;
        }
        /// <summary>
        /// 单个地块属性变化监听，自动计算平均等级
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Data_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e) {
            //throw new Exception("在这");
            double sumproduct_dry = 0;
            double sumproduct_paddy = 0;
            this.PaddyArea = 0;
            this.DryArea = 0;
            foreach (NZYDKData data in dk) {
                sumproduct_dry += data.DryArea * data.DryLevel;
                sumproduct_paddy += data.PaddyArea * data.PaddyLevel;
                this.DryArea += data.DryArea;
                this.PaddyArea += data.PaddyArea;
            }
            #region 保留两位小数
            this.DryLevel = Math.Round(sumproduct_dry / this.DryArea,2);
            this.PaddyLevel =Math.Round(sumproduct_paddy / this.PaddyArea,2);
            #endregion
        }

        private Guid guid;
        private ObservableCollection<NZYDKData> dk;
        private string text;
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
            get {
                text = this.ToString();
                return text;
            }
            set { text = value;
                this.NotifyPropertyChanged("Text");
            }
        }

        public override string ToString() {
            StringBuilder sb = new StringBuilder();
            sb.Append(this.Name);
            sb.Append("批次包含耕地");
            sb.Append(this.PaddyArea + this.DryArea);
            sb.Append("平方米，其中");
            if (PaddyArea > 0) {
                sb.Append("水田");
                sb.Append(PaddyArea);
                sb.Append("平方米，水田平均等级");
                sb.Append(PaddyLevel);
                sb.Append("级");
                if (DryArea > 0) {
                    sb.Append("，");
                }
            }
            if (DryArea > 0) {
                sb.Append("旱地");
                sb.Append(DryArea);
                sb.Append("平方米，旱地平均等级");
                sb.Append(DryLevel);
                sb.Append("级");
            }
            sb.Append("。");
            return sb.ToString();
        }

    }

    public class NZYDKData : Data {

        public NZYDKData() {
            this.Name = string.Empty;
        }

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
                this.NotifyPropertyChanged("ID");
            }
        }
    }
}
