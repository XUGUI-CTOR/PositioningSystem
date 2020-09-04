using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Threading;
using Panuon.UI.Silver;
using Panuon.UI.Silver.Core;
using Position_BulletinBoard.DBModel;
using Position_BulletinBoard.SQLDAL;
using PropertyChanged;
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
    [DoNotNotify]
    public class SettingViewModel:ViewModelBase
    {

        public SettingViewModel()
        {
            InitDataSource();
        }

        private int _SelectTabIndex;
        public int SelectTabIndex
        {
            get => _SelectTabIndex;
            set => Set(ref _SelectTabIndex, value);
        }

        private void InitDataSource()
        {
            KQZBXXB = toObserable(new CK_KQZBXXBMamager().GetList());
            YXSJSZs = toObserable(new CP_YXSJSZBMamager().GetList());
            JZXXB = toObserable(new CP_JZXXBMamager().GetList());
            MasterSlave = toObserable(new CK_JZXGXXBMamager().GetList());
            Storages = toObserable(new CP_CKKWBMamager().GetList());
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

        #region 基站信息登记
        private ObservableCollection<CK_JZXXB> jzxxb = new ObservableCollection<CK_JZXXB>();
        private List<CK_JZXXB> jzxxDelete = new List<CK_JZXXB>();
        public ObservableCollection<CK_JZXXB> JZXXB
        {
            get => jzxxb;
            set => Set(ref jzxxb, value);
        }
        private CK_JZXXB _SelectJZXX;
        public CK_JZXXB SelectJZXX
        {
            get => _SelectJZXX;
            set => Set(ref _SelectJZXX, value);
        }
        #endregion

        #region 主从登记
        private ObservableCollection<CK_JZXGXXB> _MasterSlave = new ObservableCollection<CK_JZXGXXB>();
        private ObservableCollection<CK_JZXGXXB> MasterSlaveDelete = new ObservableCollection<CK_JZXGXXB>();
        public ObservableCollection<CK_JZXGXXB> MasterSlave
        {
            get => _MasterSlave;
            set => Set(ref _MasterSlave, value);
        }
        private CK_JZXGXXB _SelectMasterSlave;
        public CK_JZXGXXB SelectMasterSlave
        {
            get => _SelectMasterSlave;
            set => Set(ref _SelectMasterSlave, value);
        }
        #endregion

        #region 成品库位设置
        private ObservableCollection<CP_CKKWB> _Storages = new ObservableCollection<CP_CKKWB>();
        private List<CP_CKKWB> StorageDelete = new List<CP_CKKWB>();
        public ObservableCollection<CP_CKKWB> Storages
        {
            get => _Storages;
            set => Set(ref _Storages, value);
        }
        private CP_CKKWB _SelectStorags;
        public CP_CKKWB SelectStorage
        {
            get => _SelectStorags;
            set => Set(ref _SelectStorags, value);
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
                case "tab_BaseStation":
                    JZXXB.Add(new CK_JZXXB());
                    break;
                case "tab_Master_Slave":
                    MasterSlave.Add(new CK_JZXGXXB());
                    break;
                case "tab_StorageLocation":
                    Storages.Add(new CP_CKKWB());
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
                    yxsjszDelete.Add(_SelectYXSJ);
                    _YXSJSZs.Remove(_SelectYXSJ);
                    break;
                case "tab_BaseStation":
                    if (_SelectJZXX == null)
                    {
                        ShowMessageBoxX("", "请选择要移除的基站");
                        return;
                    }
                    jzxxDelete.Add(_SelectJZXX);
                    jzxxb.Remove(_SelectJZXX);
                    break;
                case "tab_Master_Slave":
                    if (SelectMasterSlave == null)
                    {
                        ShowMessageBoxX("", "请选择要删除的行");
                        return;
                    }
                    MasterSlaveDelete.Add(SelectMasterSlave);
                    MasterSlave.Remove(SelectMasterSlave);
                    break;
                case "tab_StorageLocation":
                    if(SelectStorage == null)
                    {
                        ShowMessageBoxX("", "请选择要删除的行");
                        return;
                    }
                    StorageDelete.Add(SelectStorage);
                    Storages.Remove(SelectStorage);
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
            int index = default;
            try
            {
                index = 0;
                SaveKQZBXXB();
                index = 1;
                SaveJZXX();
                index = 2;
                SaveMasterSlave();
                index = 3;
                SaveStorages();
                index = 4;
                SaveYXSJPZ();
            }
            catch(Exception)
            {
                SelectTabIndex = index;
            }
        }
        /// <summary>
        /// 保存成品库位设置
        /// </summary>
        private void SaveStorages()
        {
            CP_CKKWBMamager mamager = new CP_CKKWBMamager();
            foreach (var item in Storages)
            {
                try
                {
                    item.ValidationModel();
                    if (item.nID <= 0)
                    {
                        if (Storages.Where(x => x.cCKBH == item.cCKBH && x.cKQBH == item.cKQBH).Count() > 1)
                            throw new Exception("设置重复的仓库和库区");
                        item.cKWM = $"{item.cCKBH}-{item.cKQBH}-{item.cKWBH??string.Empty}";
                        item.nID = (short)mamager.CurrentDb.AsInsertable(item).ExecuteReturnIdentity();
                    }
                    else
                    {
                        if (Storages.Where(x => x.cCKBH == item.cCKBH && x.cKQBH == item.cKQBH&&x.nID>0).Count() > 1)
                            throw new Exception("设置重复的仓库和库区");
                        mamager.CurrentDb.AsUpdateable(item).ExecuteCommandHasChange();
                    }

                }
                catch (Exception ex)
                {
                    ShowMessageBoxX("", ex.Message, MessageBoxIcon.Error);
                    SelectStorage = item;
                    throw ex;
                }
            }
        }

        /// <summary>
        /// 保存主从关系
        /// </summary>
        private void SaveMasterSlave()
        {
            CK_JZXGXXBMamager mamager = new CK_JZXGXXBMamager();
            foreach (var item in MasterSlave)
            {
                try
                {
                    item.ValidationModel();
                    if (item.nID <= 0)
                    {
                        if (MasterSlave.Where(x => (x.cZJZH == item.cZJZH && x.cXGJZH == item.cXGJZH) || (x.cZJZH == item.cXGJZH && x.cXGJZH == item.cZJZH)).Count() > 1)
                            throw new Exception("当前主从关系已存在，或者从主关系已存在");
                        item.nID = (short)mamager.CurrentDb.AsInsertable(item).ExecuteReturnIdentity();
                    }
                    else
                    {
                        if (MasterSlave.Where(x => (x.cZJZH == item.cZJZH && x.cXGJZH == item.cXGJZH) || (x.cZJZH == item.cXGJZH && x.cXGJZH == item.cZJZH)&&x.nID>0).Count() > 1)
                            throw new Exception("当前主从关系已存在，或者从主关系已存在");
                        mamager.CurrentDb.AsUpdateable(item).ExecuteCommandHasChange();
                    }

                }
                catch (Exception ex)
                {
                    ShowMessageBoxX("", ex.Message, MessageBoxIcon.Error);
                    SelectMasterSlave = item;
                    throw ex;
                }
            }
            foreach (var item in MasterSlaveDelete)
            {
                if (item.nID > 0)
                    mamager.Delete(item.nID);
            }
            MasterSlaveDelete.Clear();
        }

        /// <summary>
        /// 保存库区坐标信息
        /// </summary>
        private void SaveKQZBXXB()
        {
            CK_KQZBXXBMamager mamager = null;
            if (mamager == null)
                mamager = new CK_KQZBXXBMamager();
            foreach (var item in kqzbxxb)
            {
                try
                {
                    item.ValidationModel();
                    if (item.nID == -1)
                    {
                        
                        if (kqzbxxb.Where(x => x.cKuq == item.cKuq&&x.cCKBH == item.cCKBH).Count() > 1)
                            throw new Exception("当前库区已存在，不可重复添加");
                        item.nID = (short)mamager.CurrentDb.AsInsertable(item).ExecuteReturnIdentity();
                    }
                    else
                    {
                        if (kqzbxxb.Where(x => x.cKuq == item.cKuq && x.cCKBH == item.cCKBH&&x.nID>0).Count() > 1)
                            throw new Exception("当前库区已存在，不可重复添加");
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
                    item.ValidationModel();
                    if (item.nID <= 0)
                    {
                        
                        if (YXSJSZs.Where(x => x.CKEY == item.CKEY).Count() > 1)
                            throw new Exception("当前项唯一索引已存在");
                       item.nID = (short)mamager.CurrentDb.AsInsertable(item).ExecuteReturnIdentity();
                    }
                    else
                    {
                        if (YXSJSZs.Where(x => x.CKEY == item.CKEY&&x.nID>0).Count() > 1)
                            throw new Exception("当前项唯一索引已存在");
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
        /// <summary>
        /// 保存基站信息
        /// </summary>
        private void SaveJZXX()
        {
            CP_JZXXBMamager mamager = null;
            if (mamager == null)
                mamager = new CP_JZXXBMamager();
            foreach (var item in JZXXB)
            {
                try
                {
                    item.ValidationModel();
                    if (item.nID <= 0)
                    {
                        if (JZXXB.Where(x => x.cJZBH == item.cJZBH).Count() > 1)
                            throw new Exception("当前机台班号已存在");
                        item.nID = (short)mamager.CurrentDb.AsInsertable(item).ExecuteReturnIdentity();
                    }
                    else
                    {
                        if (JZXXB.Where(x => x.cJZBH == item.cJZBH&&x.nID>0).Count() > 1)
                            throw new Exception("当前机台班号已存在");
                        mamager.CurrentDb.AsUpdateable(item).ExecuteCommandHasChange();
                    }
                }
                catch (Exception ex)
                {
                    ShowMessageBoxX("", ex.Message, MessageBoxIcon.Error);
                    SelectJZXX = item;
                    throw ex;
                }
            }
            foreach (var item in jzxxDelete)
            {
                if (item.nID > 0)
                    mamager.Delete(item.nID);
            }
            jzxxDelete.Clear();
        }
        #endregion
    }
}
