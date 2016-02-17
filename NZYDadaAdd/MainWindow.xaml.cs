using Common;
using DataOperator.NZY;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
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

namespace NZYDadaAdd {
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }

        private NZYData nzydata;

        private void ShowAddNZYDataDialog(bool bShow) {
            this.AddNZYDataDialog.IsOpen = bShow;
            this.MainGrid.IsEnabled = !bShow;
            this.tbxNZYName.Focus();
        }

        private void btnAddNZYData_Click(object sender, RoutedEventArgs e) {
            ShowAddNZYDataDialog(true);
        }

        private void Dlg_BtnClose_Click(object sender, RoutedEventArgs e) {
            ShowAddNZYDataDialog(false);
        }
        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Dlg_BtnOK_Click(object sender, RoutedEventArgs e) {
            ShowAddNZYDataDialog(false);
            nzydata = new NZYData(tbxNZYName.Text);
            NZYDataGrid.DataContext = nzydata;
            //NZYDKData dt = new NZYDKData("aaa");
            //nzydata.Dk.Add(dt);
            dkGrid.DataContext = nzydata.Dk;
            dkGrid.CanUserAddRows = true;
            btnImport.IsEnabled = true;
            
            //dkGrid.ItemsSource = nzydata.Dk;
        }
        /// <summary>
        /// 取消提交并清除数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, RoutedEventArgs e) {
            dkGrid.CanUserAddRows = false;
            nzydata.Clear();
        }
        /// <summary>
        /// 提交数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSubmit_Click(object sender, RoutedEventArgs e) {
            //MessageBox.Show(nzydata.ToString());
            DataSubmit.dataAdd(nzydata);
        }
        #region 添加数据已不需要
        private void btnAddNZYDKData_Click(object sender, RoutedEventArgs e) {
            Button button = sender as Button;
            int index;
            if (int.TryParse(button.Tag.ToString(),out index)) {
                DataGridRow row = (DataGridRow)dkGrid.ItemContainerGenerator.ContainerFromIndex(index);
                row.Focus();
            }
        }
        #endregion
        /// <summary>
        /// 删除地块数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDeleteNZYDKData_Click(object sender, RoutedEventArgs e) {
            Button button = sender as Button;
            int index;
            if (int.TryParse(button.Tag.ToString(), out index)) {
                nzydata.DeleteNZYDKData(index);
            }
        }
        /// <summary>
        /// 导入数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnImport_Click(object sender, RoutedEventArgs e) {
            string filename = openFile();
            if (!filename.Equals("openfaild")) {
                try {
                    DataRead.ImportDkFromExcel(filename, nzydata);
                    MessageBox.Show("提交成功");
                } catch (Exception ex) {
                    MessageBox.Show(ex.Message);
                }
            }
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
