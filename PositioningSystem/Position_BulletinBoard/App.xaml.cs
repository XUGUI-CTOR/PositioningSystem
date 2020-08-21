using GalaSoft.MvvmLight.Threading;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Position_BulletinBoard
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            DispatcherHelper.Initialize();
            InitDBConnectionStr();
        }
        public static string ConnStr { get; private set; }
        private void InitDBConnectionStr()
        {
            var setting = ConfigurationManager.AppSettings;
            var datasource = setting.Get("DataSource");
            var uid = setting.Get("uid");
            var pwd = setting.Get("pwd");
            var InitialCatalog = setting.Get("InitialCatalog");
            ConnStr = $"Data Source={datasource};uid={uid};pwd={pwd};Initial Catalog={InitialCatalog};MultipleActiveResultSets=true";
        }
    }
}
