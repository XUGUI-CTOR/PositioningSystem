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
        private RelayCommand addNew;
        public RelayCommand AddNew
        {
            get
            {
                if (addNew == null)
                    addNew = new RelayCommand(()=> { KQZBXXB.Add(new CK_KQZBXXB()); });
                return addNew;
            }
            set
            {
                addNew = value;
            }
        }
        private RelayCommand removeCmd;
        public RelayCommand RemoveCommand
        {
            get
            {
                if (removeCmd == null)
                    removeCmd = new RelayCommand(() =>
                    {
                        if (_SelectedKQXX == null) 
                        {
                            ShowMessageBoxX("", "请先选择要要移除的库区信息");
                            return;
                        };
                        kqzxxbDelete.Add(SelectedKQXX);
                        kqzbxxb.Remove(SelectedKQXX);
                    });
                return removeCmd;
            }
            set => removeCmd = value;
        }

        #endregion

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

        #endregion
    }
}
