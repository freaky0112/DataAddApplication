using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DataAddApplication {
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window {

        private DataTable dt;
        public MainWindow() {
            InitializeComponent();
        }

        private void btnConnectMySQL_Click(object sender, RoutedEventArgs e) {
            foreach(DataRow row in dt.Rows) {
                Data data = new Data();
                data.Name = row[1].ToString();
                data.Acceptance = row[2].ToString();
                data.Record = row[3].ToString();
                data.TotalArea = double.Parse(row[4].ToString());
                data.Amount = decimal.Parse(row[6].ToString());
                data.PaddyArea = double.Parse(row[7].ToString());
                data.DryArea = data.TotalArea - data.PaddyArea;
                DataOperator.InsertData(data);
            }
            MessageBox.Show("上传完成");
        }

        private void btnImport_Click(object sender, RoutedEventArgs e) {
            string filename = openFile();
            ExcelHelper eh = new ExcelHelper(filename);
            dt = eh.ExcelToDataTable("Sheet1", true);
            MessageBox.Show("导入完成！共计导入"+dt.Rows.Count+"个数据","",MessageBoxButton.OK);

        }

        /// <summary>
        /// 打开文件
        /// </summary>
        /// <returns>文件路径</returns>
        private string openFile() {
            OpenFileDialog op = new OpenFileDialog();
            op.Filter = "Excel文件(*.xlsx;*.xls)|*.xlsx;*xls|所有文件(*.*)|*.*";

            if (op.ShowDialog() == true) {
                return op.FileName;
            } else {
                return "openfaild";
            }
        }
    }
}
