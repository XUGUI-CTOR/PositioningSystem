using Panuon.UI.Silver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Position_BulletinBoard.Utils
{
    public class MyWindowXHelper
    {

        #region 最小化按钮显示


        public static Visibility GetMinButtonVis(DependencyObject obj)
        {
            return (Visibility)obj.GetValue(MinButtonVisProperty);
        }

        public static void SetMinButtonVis(DependencyObject obj, Visibility value)
        {
            obj.SetValue(MinButtonVisProperty, value);
        }

        // Using a DependencyProperty as the backing store for MinButtonVis.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MinButtonVisProperty =
            DependencyProperty.RegisterAttached("MinButtonVis", typeof(Visibility), typeof(MyWindowXHelper), new PropertyMetadata(Visibility.Visible));


        #endregion

        #region 最大化按钮显示


        public static Visibility GetMaxButtonVis(DependencyObject obj)
        {
            return (Visibility)obj.GetValue(MaxButtonVisProperty);
        }

        public static void SetMaxButtonVis(DependencyObject obj, Visibility value)
        {
            obj.SetValue(MaxButtonVisProperty, value);
        }

        // Using a DependencyProperty as the backing store for MaxButtonVis.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MaxButtonVisProperty =
            DependencyProperty.RegisterAttached("MaxButtonVis", typeof(Visibility), typeof(MyWindowXHelper), new PropertyMetadata(Visibility.Visible));


        #endregion

    }
}
