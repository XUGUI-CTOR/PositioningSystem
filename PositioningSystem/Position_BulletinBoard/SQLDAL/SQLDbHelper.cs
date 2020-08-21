using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Position_BulletinBoard.SQLDAL
{
    public static class SQLDbHelper
    {
        /// <summary>
        /// 编写ExecuteDataTable方法，数据库非连接式查询方法，用于获取多条查询记录
        /// </summary>
        /// <param name="commandText"></param>
        /// <param name="commandType"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static DataTable ExecuteDataTable(string commandText, CommandType commandType, SqlParameter[] parameters)
        {
            DataTable data = new DataTable();//实例化DataTable, 用于装载查询结果集
            using (SqlConnection connection = new SqlConnection(App.ConnStr))
            {
                using (SqlCommand command = new SqlCommand(commandText, connection))
                {
                    //设置Command的CommandType为指定的CommandType
                    command.CommandType = commandType;
                    //增加40s查询限制
                    command.CommandTimeout = 40;
                    //如果同时传入参数，则添加这些参数
                    if (parameters != null)
                    {
                        foreach (SqlParameter parameter in parameters)
                        {
                            command.Parameters.Add(parameter);
                        }
                    }
                    //通过包含查询SQL的SqlCommand实例来实例化SqlDataAdapter
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(data);//填充DataTable
                }
            }
            return data;
        }
        //为了方便调用，编写两个重载的ExecuteDataTable方法
        public static DataTable ExecuteDataTable(string commandText)
        {
            return ExecuteDataTable(commandText, CommandType.Text, null);
        }
        public static DataTable ExecuteDataTable(string commandText, CommandType commandType)
        {
            return ExecuteDataTable(commandText, commandType, null);
        }
        /// <summary>
        /// 编写ExecuteReader方法，数据库连接式查询方法，用于获取多条查询记录
        /// </summary>
        /// <param name="commandText"></param>
        /// <param name="commandType"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static SqlDataReader ExecuteReader(string commandText, CommandType commandType, SqlParameter[] parameters)
        {
            SqlConnection connection = new SqlConnection(App.ConnStr);
            SqlCommand command = new SqlCommand(commandText, connection);
            //设置command的CommandType为指定的CommandType
            command.CommandType = commandType;
            //如果同时传入了参数，则添加这些参数
            if (parameters != null)
            {
                foreach (SqlParameter parameter in parameters)
                {
                    command.Parameters.Add(parameter);
                }
            }
            connection.Open();
            //CommandBehavitor.CloseConnection参数指示关闭Reader对象时关闭与其关联的Connection对象
            return command.ExecuteReader(CommandBehavior.CloseConnection);
        }
        //为了方便调用，编写两个重载的ExecuteReader方法
        public static SqlDataReader ExecuteReader(string commandText)
        {
            return ExecuteReader(commandText, CommandType.Text, null);
        }
        public static SqlDataReader ExecuteReader(string commandText, CommandType commandType)
        {
            return ExecuteReader(commandText, commandType, null);
        }
        /// <summary>
        /// 编写ExecuteScalar方法，从数据库中检索单个值
        /// </summary>
        /// <param name="commandText"></param>
        /// <param name="commandType"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static Object ExecuteScalar(string commandText, CommandType commandType, SqlParameter[] parameters)
        {
            object result = null;
            using (SqlConnection connection = new SqlConnection(App.ConnStr))
            {
                using (SqlCommand command = new SqlCommand(commandText, connection))
                {
                    //设置command的CommandType为指定的CommandType
                    command.CommandType = commandType;
                    if (parameters != null)
                    {
                        foreach (SqlParameter parameter in parameters)
                        {
                            command.Parameters.Add(parameter);
                        }
                    }
                    connection.Open();//打开数据库连接
                    result = command.ExecuteScalar();
                }
            }
            return result;//返回查询结果中的第一行第一列，忽略其他行和列
        }
        //为了方便调用，编写两个重载的ExecuteScalar方法
        public static Object ExecuteScalar(string commandText)
        {
            return ExecuteScalar(commandText, CommandType.Text, null);
        }
        public static Object ExecuteScalar(string commandText, CommandType commandType)
        {
            return ExecuteScalar(commandText, commandType, null);
        }
        /// <summary>
        /// 编写ExecuteNonQuery方法，对数据库执行增、删、改操作
        /// </summary>
        /// <param name="commandText"></param>
        /// <param name="commandType"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static int ExecuteNonQuery(string commandText, CommandType commandType, SqlParameter[] parameters)
        {
            int count = 0;
            using (SqlConnection connection = new SqlConnection(App.ConnStr))
            {
                using (SqlCommand command = new SqlCommand(commandText, connection))
                {
                    //设置command的CommandType为指定的CommandType
                    command.CommandType = commandType;
                    //如果同时传入了参数，则添加这些参数
                    if (parameters != null)
                    {
                        foreach (SqlParameter parameter in parameters)
                        {
                            command.Parameters.Add(parameter);
                        }
                    }
                    connection.Open();//打开数据库连接
                    count = command.ExecuteNonQuery();
                }
            }
            return count;//返回执行增、删、改操作之后，数据库中受影响的行数
        }
        //为了方便调用，编写两个重载的ExecuteNonQuery方法
        public static int ExecuteNonQuery(string commandText)
        {
            return ExecuteNonQuery(commandText, CommandType.Text, null);
        }
        public static int ExecuteNonQuery(string commandText, CommandType commandType)
        {
            return ExecuteNonQuery(commandText, commandType, null);
        }
        /// <summary>
        /// 编写ExecuteNonQuery方法，对数据库直接执行DataTable整体Update操作
        /// </summary>
        /// <param name="adapterText"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static bool ExecuteUpdate(string adapterText, DataTable dt)//传入参数：需要对比的DataTable的查询语句，修改后的DataTable
        {
            bool result = false;
            using (SqlConnection connection = new SqlConnection(App.ConnStr))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(adapterText, connection);
                SqlCommandBuilder cmdbd = new SqlCommandBuilder(adapter);
                cmdbd.GetDeleteCommand();//自动生成数据表操作的delete语句
                cmdbd.GetInsertCommand();//自动生成数据表操作的Insert语句
                cmdbd.GetUpdateCommand();//自动生成数据表操作的Update语句
                try
                {
                    //第一步执行删除
                    adapter.Update(dt.Select(null, null, DataViewRowState.Deleted)); //自动匹配DataTable与前面查询结果中的不同，多余的执行删除
                    //第二步执行更新
                    adapter.Update(dt.Select(null, null, DataViewRowState.ModifiedCurrent));//自动匹配DataTable与前面查询结果中的不同，变动的执行更新
                    //第三步执行新增
                    adapter.Update(dt.Select(null, null, DataViewRowState.Added));//自动匹配DataTable与前面查询结果中的不同，新增的执行新增
                }
                catch (Exception ex)
                {
                    result = false;
                }
            }
            return result;
        }
    }
}
