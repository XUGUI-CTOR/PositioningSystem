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
using uc = System.Windows.Controls.UserControl;
namespace Position_BulletinBoard.UserControl
{
    /// <summary>
    /// ReservoirArea.xaml 的交互逻辑
    /// </summary>
    public partial class ReservoirArea : uc
    {
        public ReservoirArea()
        {
            InitializeComponent();
        }
        public Border this[int index]
        {
            get
            {
                if (index < 1 || index > 9)
                    throw new IndexOutOfRangeException("下标必须在1到9之间");
                return (Border)grid.Children[index - 1];
            }
        }

        public void SetBorderClor(int Index, Color color)
        {
            Border SelectBorder = this[Index];
            SelectBorder.Background = new SolidColorBrush(color);
        }
        public static Dictionary<string, ReservoirArea> AreaCollection { get; } = new Dictionary<string, ReservoirArea>();
    }
}
