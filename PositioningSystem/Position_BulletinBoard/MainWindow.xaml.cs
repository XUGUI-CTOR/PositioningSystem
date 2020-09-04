using Panuon.UI.Silver;
using Position_BulletinBoard.SQLDAL;
using Position_BulletinBoard.UserControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Position_BulletinBoard
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : WindowX
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += MainWindow_Loaded;
        }
        public double CanvasWidth { get; set; }
        public double CanvasHeight { get; set; }
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            CanvasHeight = canvas.ActualHeight;
            CanvasWidth = canvas.ActualWidth;
            MessageBox.Show($"");
        }
        private decimal LeftTopX, LeftTopY, RightBottomX, RightBottomY;
        /// <summary>
        /// 绘制库区
        /// </summary>
        public void DrawRAreas()
        {
            var Areas = new CK_KQZBXXBMamager().GetList();
            if (Areas is null || Areas.Count == 0)
                return;
            LeftTopX = Areas.Min(x => x.nKQZB_X1);
            LeftTopY = Areas.Min(x => x.nKQZB_Y1);
            RightBottomX = Areas.Max(x => x.nKQZB_X4);
            RightBottomY = Areas.Max(x => x.nKQZB_Y4);
            var emtor = Areas.GetEnumerator();
            while (emtor.MoveNext())
            {
                var cur = emtor.Current;
                ReservoirArea area = new ReservoirArea();

            }
        }
    }
}
