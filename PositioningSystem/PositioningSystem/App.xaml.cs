using GalaSoft.MvvmLight.Threading;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace PositioningSystem
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        static App()
        {
            
            InitDBConnectionStr();
            ReadAPILine();
        }

        public static string ConnStr { get; private set; }
        private static void InitDBConnectionStr()
        {
            var setting = ConfigurationManager.AppSettings;
            var datasource = setting.Get("DataSource");
            var uid = setting.Get("uid");
            var pwd = setting.Get("pwd");
            var InitialCatalog = setting.Get("InitialCatalog");
            ConnStr = $"Data Source={datasource};uid={uid};pwd={pwd};Initial Catalog={InitialCatalog};MultipleActiveResultSets=true";
        }

        public static string APIAdress { get; private set; }
        private static void ReadAPILine()
        {
            APIAdress = ConfigurationManager.AppSettings.Get("APIIpAddress");
        }
    }
}
