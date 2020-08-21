using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Position_BulletinBoard.SQLDAL
{
    public class DbContext<T> where T:class,new()
    {
        public DbContext()
        {
            Db = new SqlSugarClient(new ConnectionConfig
            {
                ConnectionString = App.ConnStr,
                DbType = DbType.SqlServer,
                InitKeyType = InitKeyType.Attribute,
                IsAutoCloseConnection = true
            });  
        }
        private SqlSugarClient Db;

        public SimpleClient<T> CurrentDb
        {
            get => new SimpleClient<T>(Db);
        }

        public virtual List<T> GetList() => CurrentDb.GetList();

        public virtual bool Delete(dynamic id) => CurrentDb.DeleteById(id);

        public virtual bool Insert(T model) => CurrentDb.Insert(model);

        public virtual bool Update(T model) => CurrentDb.Update(model);
    }
}
