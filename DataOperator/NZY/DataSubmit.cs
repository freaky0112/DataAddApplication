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

        public static void dataAdd(NZYData data) {
            StringBuilder sql = new StringBuilder();

            #region 更新农转用表

            #region 判断是否存在数据
            sql.Append("select count(*) from ");
            sql.Append(Constant.NZY_TABLE);
            sql.Append(" where guid=@guid ");///如果存在数据
            MySqlParameter[] pt = new MySqlParameter[] {
                new MySqlParameter("@guid", data.Guid)
            };
            string result = string.Empty;
            try {
                result = ToolsHelper.MySqlHelper.ExecuteScalar(Constant.getMySqlConntection(), CommandType.Text, sql.ToString(), pt).ToString();
            } catch (Exception ex) {
                throw ex;
            }
            #endregion

            #region 删除原有农转用地块数据
            sql = new StringBuilder();
            sql.Append("delete from ");
            sql.Append(Constant.NZYDK_TABLE);
            sql.Append(" where NZYGuid = @guid");
            try {
                ToolsHelper.MySqlHelper.ExecuteNonQuery(Constant.getMySqlConntection(), CommandType.Text, sql.ToString(), pt);
            } catch (MySqlException ex) {
                throw ex;
            }

            #endregion


            #region 参数赋值
            sql = new StringBuilder();
            pt = new MySqlParameter[]{
                new MySqlParameter("@guid",data.Guid),
                new MySqlParameter("@name",data.Name),
                new MySqlParameter("@paddyarea",data.PaddyArea),
                new MySqlParameter("@paddylevel",data.PaddyLevel),
                new MySqlParameter("@dryarea",data.DryArea),
                new MySqlParameter("@drylevel",data.DryLevel),
                new MySqlParameter("@summary",data.Summary)
            };
            #endregion
            try {
                if (result.Equals("1")) {
                    #region 更新数据
                    sql.Append("update ");
                    sql.Append(Constant.NZY_TABLE);
                    sql.Append("set ");
                    sql.Append("NAME=@name, ");
                    sql.Append("PADDYAREA=@paddyarea, ");
                    sql.Append("PADDYLEVEL=@paddylevel, ");
                    sql.Append("DRYAREA=@dryarea, ");
                    sql.Append("DRYLEVEL=@drylevel, ");
                    sql.Append("SUMMARY=@summary ");
                    sql.Append("where ");
                    sql.Append("GUID= @guid ");
                    ToolsHelper.MySqlHelper.ExecuteNonQuery(Constant.getMySqlConntection(), CommandType.Text, sql.ToString(), pt);
                    #endregion
                } else {
                    #region 插入新数据
                    sql.Append("insert into ");
                    sql.Append(Constant.NZY_TABLE);
                    sql.Append(" (");
                    sql.Append("GUID, ");
                    sql.Append("NAME,");
                    sql.Append("PADDYAREA, ");
                    sql.Append("PADDYLEVEL, ");
                    sql.Append("DRYAREA, ");
                    sql.Append("DRYLEVEL, ");
                    sql.Append("SUMMARY ");
                    sql.Append(") values (");
                    sql.Append("@guid, ");
                    sql.Append("@name, ");
                    sql.Append("@paddyarea, ");
                    sql.Append("@paddylevel, ");
                    sql.Append("@dryarea, ");
                    sql.Append("@drylevel, ");
                    sql.Append("@summary)");
                    ToolsHelper.MySqlHelper.ExecuteNonQuery(Constant.getMySqlConntection(), CommandType.Text, sql.ToString(), pt);
                    #endregion
                }
            } catch (MySqlException ex) {
                throw ex;
            }
            #endregion

            #region 更新农转用地块信息
            foreach(NZYDKData dkdata in data.Dk) {
                sql = new StringBuilder();
                sql.Append("insert into ");
                sql.Append(Constant.NZYDK_TABLE);
                sql.Append(" (");
                sql.Append("Name, ");
                sql.Append("NZYGuid, ");
                sql.Append("PaddyArea, ");
                sql.Append("PaddyLevel, ");
                sql.Append("DryArea, ");
                sql.Append("DryLevel, ");
                sql.Append("Summary ");
                sql.Append(") values (");
                sql.Append("@name, ");
                sql.Append("@guid, ");
                sql.Append("@paddyarea, ");
                sql.Append("@paddylevel, ");
                sql.Append("@dryarea, ");
                sql.Append("@drylevel, ");
                sql.Append("@summary)");
                pt = new MySqlParameter[]{
                    new MySqlParameter("@guid",data.Guid),
                    new MySqlParameter("@name",dkdata.Name),
                    new MySqlParameter("@paddyarea",dkdata.PaddyArea),
                    new MySqlParameter("@paddylevel",dkdata.PaddyLevel),
                    new MySqlParameter("@dryarea",dkdata.DryArea),
                    new MySqlParameter("@drylevel",dkdata.DryLevel),
                    new MySqlParameter("@summary",dkdata.Summary)
                };
                try {
                    ToolsHelper.MySqlHelper.ExecuteNonQuery(Constant.getMySqlConntection(), CommandType.Text, sql.ToString(), pt);
                } catch (MySqlException ex) {
                    throw ex;
                }
            }
            #endregion



        }


    }
}
