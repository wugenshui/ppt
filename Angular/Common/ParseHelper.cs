using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common
{
    public class ParseHelper
    {
        /// <summary>
        /// 字符串转整型，若字符串为空则为0
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int GetInt(string value)
        {
            int result = 0;
            if (!string.IsNullOrWhiteSpace(value))
            {
                int.TryParse(value, out result);
            }

            return result;
        }

        /// <summary>
        /// 字符串转时间，若字符串为空则时间为空
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static DateTime? GetDate(string date)
        {
            DateTime? result = null;
            DateTime parseDate = new DateTime();
            if (!string.IsNullOrWhiteSpace(date))
            {
                DateTime.TryParse(date, out parseDate);
                // 小于最小时间不现实
                if (parseDate.Year < 1900)
                {
                    result = null;
                }
                else
                {
                    result = parseDate;
                }
            }

            return result;
        }
    }
}
