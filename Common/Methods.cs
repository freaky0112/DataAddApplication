using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common {
    public class Methods {
        /// <summary>
        /// 生成GUID
        /// </summary>
        /// <returns>GUID</returns>
        public static Guid setGUID() {
            System.Guid guid = new Guid();
            guid = Guid.NewGuid();
            return guid;
        }

        /// <summary>
        /// 判断是否为数字
        /// </summary>
        /// <param name="strNumber">数字</param>
        /// <returns></returns>
        public static bool IsNumber(string strNumber) {
            //看要用哪種規則判斷，自行修改strValue即可

            //strValue = @"^\d+[.]?\d*$";//非負數字
            string strValue = @"^\d+(\.)?\d*$";//數字
            //strValue = @"^\d+$";//非負整數
            //strValue = @"^-?\d+$";//整數
            //strValue = @"^-[0-9]*[1-9][0-9]*$";//負整數
            //strValue = @"^[0-9]*[1-9][0-9]*$";//正整數
            //strValue = @"^((-\d+)|(0+))$";//非正整數

            System.Text.RegularExpressions.Regex r = new System.Text.RegularExpressions.Regex(strValue);
            return r.IsMatch(strNumber);
        }

    }
}
