   M S B A M L   `   `   `  ����K  GPanuon.UI.Silver, Version=1.1.3.0, Culture=neutral, PublicKeyToken=nullM8clr-namespace:Panuon.UI.Silver;assembly=Panuon.UI.SilverPanuon.UI.Silver  5   	   Q MPosition_BulletinBoard, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:Position_BulletinBoardPosition_BulletinBoard 5   	   W0clr-namespace:Position_BulletinBoard.UserControl"Position_BulletinBoard.UserControl 5   	   K*clr-namespace:Position_BulletinBoard.UtilsPosition_BulletinBoard.Utils 5	   	   '   !Position_BulletinBoard.MainWindow   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Gpu8clr-namespace:Panuon.UI.Silver;assembly=Panuon.UI.Silver     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:Position_BulletinBoard     5   	   ?uc0clr-namespace:Position_BulletinBoard.UserControl     5   	   ;winx*clr-namespace:Position_BulletinBoard.Utils     5	   	   2  ,Position_BulletinBoard.Utils.MyWindowXHelper    MinButtonVis$  	Collapsed=�5
   	      MaxButtonVis$ 	Collapsed=�5   	    � WindowState$ 	Maximized=�5   	    � Title$ PositionBulletinBoard��5         NeteaseMusicWindow#��[  5   	    � DataContext 5      �� 5   
     Locator �� Source# [ 6    �� Path$
 Main�64   %   Panuon.UI.Silver.WindowXCaption   Header 5      �� 5   
    �� Orientation$ 
Horizontal=�6   .+�5      �� $��20(�6   $��Light"�5      $��Center=�5      $��	15,0,30,0q�5      
���������5      �� $ Title�	 �� RelativeSource	 �� 
 �� AncestorType   Panuon.UI.Silver.WindowX"
   �� Mode$ FindAncestor=��� 5      #   Panuon.UI.Silver.ButtonHelper   ButtonStyle$
 Link=�6   ���#EAEAEA$
��30 0q�6M    � ToolTip$ 设置��6[   $(��"/Resouces/NeteaseExample/#iconfont)�5      $��20(�6E      
HoverBrush
 �����   
ClickStyle$
 Sink=�5   <   $	����6^   $��Center=�6q   ��5   S   �� *	SetOpen+5   q   5      .��5      �� -   5         ��Name$ canvas��5      $��5q�6   5!      5"      