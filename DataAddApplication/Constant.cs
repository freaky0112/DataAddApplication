﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAddApplication {
   public  class Constant {
        #region mysql数据库链接
        private const string SERVER = "freaky0112.eicp.net";

        private const uint PORT = 3306;

        private const string DATABASE = "Work";

        private const string UID = "root";

        private const string PWD = "admin";

        private const string CHARSET = "'utf8'";

        public const string TABLE = "LandDevelopmentProject";

        /// <summary>
        /// 返回数据库连接字符串
        /// </summary>
        /// <returns></returns>
        public static string strConntection() {
            StringBuilder conn = new StringBuilder();
            conn.Append("server=");
            conn.Append(SERVER);
            conn.Append(";port=");
            conn.Append(PORT);
            conn.Append(";database=");
            conn.Append(DATABASE);
            conn.Append(";uid=");
            conn.Append(UID);
            conn.Append(";pwd=");
            conn.Append(PWD);
            conn.Append(";charset=");
            conn.Append(CHARSET);
            return conn.ToString();

        }
        #endregion
    }
    public class Common {
        public static Guid getGUID() {
            System.Guid guid = new Guid();
            guid = Guid.NewGuid();
            return guid;
        }
    }

}
