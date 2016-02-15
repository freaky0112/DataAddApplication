using Common;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolsHelper;

namespace DataOperator.NZY {
    public class DataSubmit {
        public static List<NZYData> dataQuery() {
            List<NZYData> list = new List<NZYData>();
            StringBuilder sql = new StringBuilder();
            sql.Append("select * from ");
            sql.Append(Constant.NZY_TABLE);
            MySqlDataReader reader;
            try {
               reader = ToolsHelper.MySqlHelper.ExecuteReader(Constant.getMySqlConntection(), CommandType.Text, sql.ToString(), null);
            } catch (Exception) {

                throw;
            }
            return list;
        }
    }
}
