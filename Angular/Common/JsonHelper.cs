using System;
using System.Data;
using System.Text;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Common
{
    public class JsonHelper
    {
        /// <summary>
        /// 对象序列化为Json字符串
        /// </summary>
        /// <param name="obj">对象</param>
        /// <returns>Json字符串</returns>
        public static string ObjectToJson(object obj, string dateTimeFormat = "yyyy-MM-dd")
        {
            IsoDateTimeConverter convert = new IsoDateTimeConverter();
            convert.DateTimeFormat = dateTimeFormat;
            string jsonString = JsonConvert.SerializeObject(obj, Formatting.None, convert);

            return jsonString;
        }

        /// <summary>
        /// 对象序列化为Json字符串
        /// </summary>
        /// <param name="obj">对象</param>
        /// <param name="formatting">格式化参数</param>
        /// <param name="settings">Json 转换设置参数</param>
        /// <returns>Json字符串</returns>
        public static string ObjectToJson(object obj, Formatting formatting, JsonSerializerSettings settings)
        {
            string jsonString = JsonConvert.SerializeObject(obj, formatting, settings);

            return jsonString;
        }

        /// <summary>
        /// Json字符串反序列化为对象
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="jsonString">Json字符串</param>
        /// <returns>序列化后的对象</returns>
        public static T JsonToObject<T>(string jsonString)
        {
            T t = default(T);
            t = JsonConvert.DeserializeObject<T>(jsonString);

            return t;
        }

        /// <summary>
        /// DataTable序列化为Json字符串
        /// </summary>
        /// <param name="table">需要序列化的DataTable</param>
        /// <returns>Json字符串</returns>
        public static string DataTableToJson(DataTable table)
        {
            if (table.Rows.Count == 0) return "";

            StringBuilder sbJson = new StringBuilder();
            sbJson.Append("[");
            for (int i = 0; i < table.Rows.Count; i++)
            {
                sbJson.Append("{");
                for (int j = 0; j < table.Columns.Count; j++)
                {
                    string colName = table.Columns[j].ColumnName.ToString();
                    string colData = table.Rows[i][j].ToString();
                    if (table.Columns[j].DataType.ToString() == "System.DateTime")
                    {
                        colData = Convert.ToDateTime(colData).ToString("yyyy-MM-dd HH:mm:ss");
                    }
                    sbJson.Append("\"" + colName + "\":\"" + colData + "\"");
                    if (j < table.Columns.Count - 1)
                    {
                        sbJson.Append(",");
                    }
                }
                sbJson.Append("}");
                if (i < table.Rows.Count - 1)
                {
                    sbJson.Append(",");
                }
            }
            sbJson.Append("]");

            return sbJson.ToString();
        }

        /// <summary>
        /// 序列化对象(包括DataTable)为Json字符串
        /// </summary>
        /// <returns>Json字符串</returns>
        public static string SerializeToJson(object obj)
        {
            Newtonsoft.Json.JsonSerializerSettings setting = new Newtonsoft.Json.JsonSerializerSettings()
            {
                ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            };
            Newtonsoft.Json.Converters.IsoDateTimeConverter timeConverter = new Newtonsoft.Json.Converters.IsoDateTimeConverter();
            timeConverter.DateTimeFormat = "yyyy-MM-dd HH:mm:ss";
            return Newtonsoft.Json.JsonConvert.SerializeObject(obj, Newtonsoft.Json.Formatting.Indented, timeConverter);
        }
    }
}