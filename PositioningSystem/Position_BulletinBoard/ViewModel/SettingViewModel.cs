using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Threading;
using Panuon.UI.Silver;
using Panuon.UI.Silver.Core;
using Position_BulletinBoard.DBModel;
using Position_BulletinBoard.SQLDAL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Position_BulletinBoard.ViewModel
{
    public class SettingViewModel:ViewModelBase
    {

        public SettingViewModel()
        {
            InitDataSource();
        }

        private void InitDataSource()
        {
            KQZBXXB = toObserable(new CK_KQZBXXBMamager().GetList());
            YXSJSZs = toObserable(new CP_YXSJSZBMamager().GetList());
        }

        public static ObservableCollection<T> toObserable<T>(List<T> list)
        {
            ObservableCollection<T> rets = new ObservableCollection<T>();
            foreach (var item in list)
            {
                rets.Add(item);
            }
            return rets;
        }

        #region 库区坐标信息
        private ObservableCollection<CK_KQZBXXB> kqzbxxb = new ObservableCollection<CK_KQZBXXB>();
        private List<CK_KQZBXXB> kqzxxbDelete = new List<CK_KQZBXXB>();
        public ObservableCollection<CK_KQZBXXB> KQZBXXB
        {
            get => kqzbxxb;
            set => Set(ref kqzbxxb, value);
        }
        private CK_KQZBXXB _SelectedKQXX;
        public CK_KQZBXXB SelectedKQXX
        {
            get => _SelectedKQXX;
            set => Set(ref _SelectedKQXX, value);
        }


        #endregion

        #region 运行时间配置
        private ObservableCollection<CP_YXSJSZ> _YXSJSZs;
        private ObservableCollection<CP_YXSJSZ> yxsjszDelete = new ObservableCollection<CP_YXSJSZ>();
        public ObservableCollection<CP_YXSJSZ> YXSJSZs
        {
            get { return _YXSJSZs; }
            set => Set(ref _YXSJSZs, value);
        }

        private CP_YXSJSZ _SelectYXSJ;
        public CP_YXSJSZ SelectYXSJ
        {
            get => _SelectYXSJ;
            set => Set(ref _SelectYXSJ, value);
        }
        #endregion

        private RelayCommand<TabItem> addNew;
        public RelayCommand<TabItem> AddNew
        {
            get
            {
                if (addNew == null)
                    addNew = new RelayCommand<TabItem>(Add);
                return addNew;
            }
            set
            {
                addNew = value;
            }
        }
        private RelayCommand<TabItem> removeCmd;
        public RelayCommand<TabItem> RemoveCommand
        {
            get
            {
                if (removeCmd == null)
                    removeCmd = new RelayCommand<TabItem>(Remove);
                return removeCmd;
            }
            set => removeCmd = value;
        }

        public void Add(TabItem tabItem)
        {
            switch (tabItem.Name)
            {
                case "tab_AreaPosition":
                    KQZBXXB.Add(new CK_KQZBXXB());
                    break;
                case "tab_RunTime":
                    YXSJSZs.Add(new CP_YXSJSZ());
                    break;
            }
        }

        public void Remove(TabItem tabItem)
        {
            switch (tabItem.Name)
            {
                case "tab_AreaPosition":
                    if (_SelectedKQXX == null)
                    {
                        ShowMessageBoxX("", "请先选择要要移除的库区信息");
                        return;
                    };
                    kqzxxbDelete.Add(SelectedKQXX);
                    kqzbxxb.Remove(SelectedKQXX);
                    break;
                case "tab_RunTime":
                    if (_SelectYXSJ == null)
                    {
                        ShowMessageBoxX("", "请选择要移除的配置信息");
                        return;
                    }
                    _YXSJSZs.Remove(_SelectYXSJ);
                    yxsjszDelete.Add(_SelectYXSJ);
                    break;
            }
        }
        public void ShowMessageBoxX(string mes, string title, MessageBoxIcon icon = MessageBoxIcon.None, Window thiswindow = null, MessageBoxButton button = MessageBoxButton.OK)
        {
            if (!(DispatcherHelper.UIDispatcher.Thread.ManagedThreadId == Thread.CurrentThread.ManagedThreadId))
            {
                DispatcherHelper.UIDispatcher.Invoke(new Action<string, string, MessageBoxIcon, Window, MessageBoxButton>(ShowMessageBoxX), mes, title, icon, thiswindow, button);
            }
            else
            {
                MessageBoxX.Show(mes, title, thiswindow, button, new MessageBoxXConfigurations()
                {
                    MessageBoxIcon = icon,
                    ButtonBrush = "#F1C825".ToColor().ToBrush()
                });
            }
        }
        private bool _WaitPross = false;
        public bool WaitPross
        {
            get => _WaitPross;
            set => Set(ref _WaitPross, value);
        }

        private Visibility _WaitProssVis = Visibility.Collapsed;
        public Visibility WaitProssVis
        {
            get => _WaitProssVis;
            set => Set(ref _WaitProssVis, value);
        }
        #region 保存，关闭按钮命令
        private RelayCommand _saveCmd;
        public RelayCommand SaveCommand
        {
            get
            {
                if (_saveCmd == null)
                    _saveCmd = new RelayCommand(SaveFunc);
                return _saveCmd;
            }
            set => _saveCmd = value;
        }
        public async void SaveFunc()
        {
            WaitPross = true;
            WaitProssVis = Visibility.Visible;
            await Task.Run(SaveDBInfo);
            WaitPross = false;
            WaitProssVis = Visibility.Collapsed;
        }

        private void SaveDBInfo()
        {
            try
            {
                SaveKQZBXXB();
                SaveYXSJPZ();
            }
            catch(Exception)
            {
            }
        }
        /// <summary>
        /// 保存库区坐标信息
        /// </summary>
        private void SaveKQZBXXB()
        {
            CK_KQZBXXBMamager mamager = null;
            foreach (var item in kqzbxxb)
            {
                try
                {
                    if (mamager == null)
                        mamager = new CK_KQZBXXBMamager();
                    if (item.nID == -1)
                    {
                        item.ValidationModel();
                        if (mamager.CurrentDb.GetSingle(m => m.cCKBH == item.cCKBH && m.cKuq == item.cKuq) != null)
                            throw new Exception("当前库区已存在，不可重复添加");
                        mamager.CurrentDb.AsInsertable(item).ExecuteCommand();
                    }
                    else
                    {
                        item.ValidationModel();
                        mamager.CurrentDb.AsUpdateable(item).ExecuteCommandHasChange();
                    }

                }
                catch (Exception ex)
                {
                    ShowMessageBoxX("", ex.Message, MessageBoxIcon.Error);
                    SelectedKQXX = item;
                    throw ex;
                }
            }
            foreach (var item in kqzxxbDelete)
            {
                if (item.nID > 0)
                    mamager.Delete(item.nID);
            }
            kqzxxbDelete.Clear();
        }
        /// <summary>
        /// 保存运行时间配置
        /// </summary>
        private void SaveYXSJPZ()
        {
            CP_YXSJSZBMamager mamager = null;
            if (mamager == null)
                mamager = new CP_YXSJSZBMamager();
            foreach (var item in YXSJSZs)
            {
                try
                {
                    if (item.nID <= 0)
                    {
                        item.ValidationModel();
                        if (new CP_YXSJSZBMamager().GetById(item.nID) != null)
                            throw new Exception("当前项唯一索引已存在");
                        mamager.CurrentDb.AsInsertable(item).ExecuteCommand();
                    }
                    else
                    {
                        item.ValidationModel();
                        mamager.CurrentDb.AsUpdateable(item).ExecuteCommandHasChange();
                    }
                }
                catch (Exception ex)
                {
                    ShowMessageBoxX("", ex.Message, MessageBoxIcon.Error);
                    SelectYXSJ = item;
                    throw ex;
                }
            }
            foreach (var item in yxsjszDelete)
            {
                if (item.nID > 0)
                    mamager.Delete(item.nID);
            }
            yxsjszDelete.Clear();
        }
        #endregion
    }
}
