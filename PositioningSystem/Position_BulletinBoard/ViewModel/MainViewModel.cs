using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using PropertyChanged;

namespace Position_BulletinBoard.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private RelayCommand _SetOpen;
        /// <summary>
        /// ������ģ������
        /// </summary>
        public RelayCommand SetOpen
        {
            get => _SetOpen ?? (_SetOpen = new RelayCommand(SetOpenCommand));
            set => Set(ref _SetOpen, value);
        }

        public MainViewModel()
        {
        }
        /// <summary>
        /// ������ģ��
        /// </summary>
        private void SetOpenCommand()
        {
            var window = new SettingWindow();
            window.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            window.ShowDialog();
        }
    }
}