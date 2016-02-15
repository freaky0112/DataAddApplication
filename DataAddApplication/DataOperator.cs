using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace DataAddApplication {
    public abstract class DataOperator {
        StringBuilder sb = new StringBuilder();

        public static bool InsertData(Data data) {
            StringBuilder sqlInsert = new StringBuilder();
            sqlInsert.Append("insert into ");
            sqlInsert.Append(Constant.TABLE);
            sqlInsert.Append(" (");
            sqlInsert.Append("`LandDevelopmentProject`.`GUID`,");
            sqlInsert.Append("`LandDevelopmentProject`.`NAME`,");
            sqlInsert.Append("`LandDevelopmentProject`.`RECORD`,");
            sqlInsert.Append("`LandDevelopmentProject`.`ACCEPTANCE`,");
            sqlInsert.Append("`LandDevelopmentProject`.`AMOUNT`,");
            sqlInsert.Append("`LandDevelopmentProject`.`TOTALAREA`,");
            sqlInsert.Append("`LandDevelopmentProject`.`PADDYAREA`,");
            sqlInsert.Append("`LandDevelopmentProject`.`DRYAREA`");
            sqlInsert.Append(") values (");
            sqlInsert.Append("@GUID,");
            sqlInsert.Append("@NAME,");
            sqlInsert.Append("@RECORD,");
            sqlInsert.Append("@ACCEPTANCE,");
            sqlInsert.Append("@AMOUNT,");
            sqlInsert.Append("@TOTALAREA,");
            sqlInsert.Append("@PADDYAREA,");
            sqlInsert.Append("@DRYAREA)");
            MySqlParameter[] pt = new MySqlParameter[]            {
                new MySqlParameter("@GUID",data.Guid),
                new MySqlParameter("@NAME", data.Name),
                new MySqlParameter("@RECORD", data.Record),
                new MySqlParameter("@ACCEPTANCE", data.Acceptance),
                new MySqlParameter("@AMOUNT", data.Amount),
                new MySqlParameter("@TOTALAREA", data.TotalArea),
                new MySqlParameter("@PADDYAREA", data.PaddyArea),
                new MySqlParameter("@DRYAREA", data.DryArea)
            };
            try {
                MySqlHelper.ExecuteNonQuery(Constant.strConntection(), CommandType.Text, sqlInsert.ToString(), pt);
            } catch (Exception ex) {
                return false;
                throw ex;
            }
            return true;
        }
    }
}
