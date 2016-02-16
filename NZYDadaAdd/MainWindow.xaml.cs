using Common;
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

        private void Dlg_BtnOK_Click(object sender, RoutedEventArgs e) {
            ShowAddNZYDataDialog(false);
            nzydata = new NZYData(tbxNZYName.Text);
            NZYDataGrid.DataContext = nzydata;
            NZYDKData dt = new NZYDKData("aaa");
            nzydata.Dk.Add(dt);
            dkGrid.DataContext = nzydata.Dk;

            //dkGrid.ItemsSource = nzydata.Dk;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e) {
            nzydata.Clear();
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e) {
            MessageBox.Show(nzydata.ToString());
        }
    }


}
