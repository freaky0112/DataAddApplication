using Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolsHelper;

namespace DataOperator.NZY {
    public class DataRead {
        public static bool ImportDkFromExcel(string filename,NZYData nzydata) {
            //ObservableCollection<NZYDKData> dk = new ObservableCollection<NZYDKData>();
            ExcelHelper eh = new ExcelHelper(filename);
            DataTable dt;
            try {
                dt = eh.ExcelToDataTable("sheet1", true); }
            catch(Exception ex) {
                throw ex;
            }
            foreach(DataRow row in dt.Rows) {
                if (Methods.IsNumber(row[0].ToString())){
                    NZYDKData data = new NZYDKData(row[1].ToString());
                    data.PaddyArea =double.Parse(row[8].ToString());
                    data.PaddyLevel = double.Parse(row[9].ToString());
                    data.DryArea = double.Parse(row[10].ToString());
                    data.DryLevel = double.Parse(row[11].ToString());
                    nzydata.Dk.Add(data);
                }
            }
            return true;
        }
    }
}
