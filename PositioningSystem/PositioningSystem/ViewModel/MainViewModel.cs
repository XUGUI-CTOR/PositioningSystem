using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PositioningSystem.Command;
using PositioningSystem.Model;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Media;

namespace PositioningSystem.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            try
            {
                var list = SQLDB.Queryable<CP_YXSJSZ>().ToList();
                WorkHours = list.Find(x => x.CKEY == "WorkHours")?.CVALUE ?? string.Empty;
                WorkHoursUpdate = int.Parse(list.Find(x => x.CKEY == "WorkHoursUpdate")?.CVALUE ?? "30");
                NotWorkHoursUpdate = int.Parse(list.Find(x => x.CKEY == "NotWorkHoursUpdate")?.CVALUE ?? "30");
                Foreground = GrayColor;
            }
            catch (System.Exception ex)
            {
                Foreground = RedColor;
                ShowMessage($"ERROE: {ex.Message}");
            }
        }

        public static SqlSugarClient SQLDB = new SqlSugarClient(new ConnectionConfig()
                {
                    ConnectionString = App.ConnStr,
                    DbType = DbType.SqlServer,
                    InitKeyType = InitKeyType.SystemTable //初始化主键和自增列信息到ORM的方式
                }
        );

        #region MainViewModel属性
        private string _WorkHours;
        public string WorkHours
        {
            get { return _WorkHours; }
            set { _WorkHours = value; RaisePropertyChanged(); }
        }

        private int _WorkHoursUpdate;
        public int WorkHoursUpdate
        {
            get => _WorkHoursUpdate;
            set => Set(ref _WorkHoursUpdate, value);
        }

        private int _NotWorkHoursUpdate;
        public int NotWorkHoursUpdate
        {
            get => _NotWorkHoursUpdate;
            set => Set(ref _NotWorkHoursUpdate, value);
        }

        private string _WorkMessage;
        public string WorkMessage
        {
            get => _WorkMessage;
            set => Set(ref _WorkMessage, value);
        }
        private bool _LoadingIsRuning = false;
        public bool LoadingIsRuning
        {
            get => _LoadingIsRuning;
            set => Set(ref _LoadingIsRuning, value);
        }
        private Brush GrayColor = new SolidColorBrush(Colors.Gray);
        private Brush RedColor = new SolidColorBrush(Colors.Red);
        private Brush _Forebackground;
        public Brush Foreground
        {
            get => _Forebackground;
            set => Set(ref _Forebackground, value);
        }
        #endregion

        #region MianViewModel命令
        private RelayCommand _windowLoadedCommand;
        public RelayCommand WindowLoadedCommand
        {
            get
            {
                if (_windowLoadedCommand == null)
                    _windowLoadedCommand = new RelayCommand(LoadedEvent);
                return _windowLoadedCommand;
            }
            set
            {
                _windowLoadedCommand = value;
            }
        }
        #endregion
        public void ShowMessage(string msg)
        {
            if (App.Current.Dispatcher.Thread.ManagedThreadId == Thread.CurrentThread.ManagedThreadId)
                WorkMessage = msg;
            else
                App.Current.Dispatcher.Invoke((Action<string>)ShowMessage, msg);
        }

        public void LoadedEvent()
        {
            Task.Run(TimeConsumingOperation);
        }
        private DateTime GoWorkStart;
        private DateTime GoWorkEnd;
        public void TimeConsumingOperation()
        {
            while (true)
            {
                try
                {
                    Foreground = GrayColor;
                    ShowMessage("正在更新");
                    LoadingIsRuning = true;
                    var list = AccessAPI();
                    foreach (var XPJCJLB in list)
                    {
                        var result = SQLDB.Queryable<CP_XPJCJLB>().Where(x => x.CXPH == XPJCJLB.CXPH && x.CJZH == XPJCJLB.CJZH).Single();
                        if (result != null)
                        {
                            int success = SQLDB.Updateable(result).ExecuteCommand();
                            if (success <= 0)
                                throw new Exception($"{JsonConvert.ToString(XPJCJLB)} 更新数据库失败");
                        }
                        else
                        {
                            int success = SQLDB.Insertable(XPJCJLB).ExecuteCommand();
                            if (success <= 0)
                                throw new Exception($"{JsonConvert.ToString(XPJCJLB)} 插入数据库失败");
                        }
                    }
                    ShowMessage("更新完成");
                    LoadingIsRuning = false;
                }
                catch (Exception ex)
                {
                    Foreground = RedColor;
                    LoadingIsRuning = false;
                    ShowMessage(ex.Message);
                }
                ProcessingTime();
                var DateNow = DateTime.Now;
                if (DateNow >= GoWorkStart && DateNow <= GoWorkEnd)
                    Thread.Sleep(TimeSpan.FromSeconds(WorkHoursUpdate));
                else
                    Thread.Sleep(TimeSpan.FromSeconds(NotWorkHoursUpdate));
            }
        }

        private List<CP_XPJCJLB> AccessAPI()
        {
            string result = new BasicClient().sendHttpRequest(App.APIAdress, "");
            JObject jObj = JObject.Parse(result);
            return jObj.GetValue("list").ToObject<List<CP_XPJCJLB>>();
        }

        public void ProcessingTime()
        {
            var now = DateTime.Now;
            try
            {
                var times = WorkHours.Split('-');
                GoWorkStart = DateTime.Parse($"{now.Year}-{now.Month}-{now.Day} {times[0]}");
                GoWorkEnd = DateTime.Parse($"{now.Year}-{now.Month}-{now.Day} {times[1]}");
            }
            catch (Exception)
            {
                GoWorkStart = DateTime.Parse($"{now.Year}-{now.Month}-{now.Day} 08:00");
                GoWorkEnd = DateTime.Parse($"{now.Year}-{now.Month}-{now.Day} 17:30");
            }
        }
    }
}