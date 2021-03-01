using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DAL
{
    public class NewDBHelper
    {
        //连接数据库
        public static SqlConnection getConn()
        {
            //数据库连接字符串
            string connStr = "Data Source=GAOLEI\\SQLEXPRESS;Initial Catalog=Register;Integrated Security=True";
            return new SqlConnection(connStr);
        }
        /// <summary>
        /// 返回受影响行数  
        /// 添加、删除、修改
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static int ExecuteNonQuery(string sql,CommandType type=CommandType.Text,params SqlParameter[] par)
        {
            using (SqlConnection conn = getConn())
            {
                conn.Open();                
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.CommandType = type;
                cmd.Parameters.AddRange(par);
                return cmd.ExecuteNonQuery();
            }
        }
        /// <summary>
        /// 返回首行首列
        /// 登录
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static object ExecuteScalar(string sql, CommandType type = CommandType.Text, params SqlParameter[] par)
        {
            using (SqlConnection conn = getConn())
            {
                conn.Open();
                //命令对象
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.CommandType = type;
                cmd.Parameters.AddRange(par);
                return cmd.ExecuteScalar();
            }
        }
        //调用存储过程或sql语句返回DATATABLE
        public static DataTable GetTable(string sql, CommandType type = CommandType.Text, params SqlParameter[] parameter)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = getConn())
            {
                //打开数据库
                conn.Open();
                //执行sql对象
                SqlCommand cmd = new SqlCommand(sql, conn);
                //定义类型
                cmd.CommandType = type;
                //添加参数
                cmd.Parameters.AddRange(parameter);
                //sqldataAdapt
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                //填充数据
                adapter.Fill(dt);
                return dt;
            }
        }

        public static List<T> GetList<T>(string sql, CommandType type = CommandType.Text, params SqlParameter[] parameter)
        {
            var dt = GetTable(sql, type, parameter);
            var json = JsonConvert.SerializeObject(dt);
            return JsonConvert.DeserializeObject<List<T>>(json);
        }

        #region 反射 

        ///// <summary>
        ///// 获取数据流  查询、显示、绑定下拉
        ///// </summary>
        ///// <param name="sql"></param>
        ///// <returns></returns>
        //private static SqlDataReader GetDataReader(string sql)
        //{
        //    using (SqlConnection conn = getConn())
        //    {
        //        conn.Open();
        //        //命令对象
        //        SqlCommand cmd = new SqlCommand(sql, conn);
        //        SqlDataReader sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
        //        return sdr;
        //    }
        //}
        ///// <summary>
        ///// 数据流转List
        ///// </summary>
        ///// <typeparam name="T"></typeparam>
        ///// <param name="sdr"></param>
        ///// <returns></returns>
        //private static List<T> DataReaderToList<T>(SqlDataReader sdr)
        //{
        //    Type t = typeof(T);//获取类型
        //                       //获取所有属性
        //    PropertyInfo[] p = t.GetProperties();
        //    //定义集合
        //    List<T> list = new List<T>();
        //    //遍历数据流
        //    while (sdr.Read())
        //    {
        //        //创建对象
        //        T obj = (T)Activator.CreateInstance(t);
        //        //数据流列数
        //        string[] sdrFileName = new string[sdr.FieldCount];
        //        for (int i = 0; i < sdr.FieldCount; i++)
        //        {
        //            sdrFileName[i] = sdr.GetName(i).Trim();
        //        }
        //        foreach (PropertyInfo item in p)
        //        {
        //            //判断Model中的属性是否在流的列名中
        //            if (sdrFileName.ToList().IndexOf(item.Name) > -1)
        //            {
        //                if (sdr[item.Name] != System.DBNull.Value)
        //                {
        //                    item.SetValue(obj, sdr[item.Name]);//对象属性赋值
        //                }
        //                else
        //                {
        //                    item.SetValue(obj, null);//对象属性赋值
        //                }
        //            }
        //            else
        //            {
        //                item.SetValue(obj, null);//对象属性赋值
        //            }

        //        }
        //        list.Add(obj);
        //    }
        //    return list;
        //}

        ///// <summary>
        ///// 获取list集合
        /////  查询、显示、绑定下拉
        ///// </summary>
        ///// <typeparam name="T"></typeparam>
        ///// <returns></returns>
        //public static List<T> GetToList<T>(string sql)
        //{
        //    //获取流数据
        //    SqlDataReader sdr = GetDataReader(sql);
        //    List<T> list = DataReaderToList<T>(sdr);
        //    if (!sdr.IsClosed)//数据流关闭
        //    {
        //        sdr.Close();
        //    }
        //    return list;
        //}

        ///// <summary>
        ///// 获取Model
        ///// </summary>
        ///// <typeparam name="T"></typeparam>
        ///// <param name="sql"></param>
        ///// <returns></returns>
        //public static T Get<T>(string sql)
        //{
        //    List<T> list = GetToList<T>(sql);
        //    if (list.Count > 0)
        //    {
        //        return list.FirstOrDefault();
        //    }
        //    return default(T);
        //}
        #endregion
    }
}

