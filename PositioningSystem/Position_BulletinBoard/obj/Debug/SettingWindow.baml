   M S B A M L   `   `   `  ����K  GPanuon.UI.Silver, Version=1.1.3.0, Culture=neutral, PublicKeyToken=nullM8clr-namespace:Panuon.UI.Silver;assembly=Panuon.UI.SilverPanuon.UI.Silver  5   	   Q MPosition_BulletinBoard, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullQ-clr-namespace:Position_BulletinBoard.CommandsPosition_BulletinBoard.Commands 5   	   K*clr-namespace:Position_BulletinBoard.UtilsPosition_BulletinBoard.Utils 5   	   ?$clr-namespace:Position_BulletinBoardPosition_BulletinBoard 5	   	   K*clr-namespace:Position_BulletinBoard.UtilsPosition_BulletinBoard.Utils 5
   	   *   $Position_BulletinBoard.SettingWindow   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   Gpu8clr-namespace:Panuon.UI.Silver;assembly=Panuon.UI.Silver     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   =cmd-clr-namespace:Position_BulletinBoard.Commands     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   >convert*clr-namespace:Position_BulletinBoard.Utils     5   	   6local$clr-namespace:Position_BulletinBoard     5	   	   ;util*clr-namespace:Position_BulletinBoard.Utils     5
   	   -   5           Panuon.UI.Silver.WindowX   Name$  window��5   	      NeteaseMusicWindow#��[  5   	    � Title$ 设置��5   	   $	��720��6   $
��1280��6!    � 	Resources 5      3  -Position_BulletinBoard.Utils.DecimalConverter  decimalConvert;  5Position_BulletinBoard.Utils.NullableDecimalConverter  nullableDecimalConverter��%:   &	       &	        5   
   6#     5   
   6+   5       � DataContext 5      �� 5   
    �� Path$ Setting�6     Locator �� Source# [ 6!   %   Panuon.UI.Silver.WindowXCaption   Header 5      �� 5   
    �� Orientation$ 
Horizontal=�6   .+�5      �� $��20(�6   $��Light"�5      $��Center=�5      $��	15,0,30,0q�5      
���������5      �� $ Title� �� RelativeSource �� 	 �� AncestorType"	  
 �� Mode$
 FindAncestor=�5      .��5       � ���	#FF333333 � RowDefinitions 5!   
   �� 5"      $��* �6   �� 5#      $��40 �6   .+�5%   
   �� -   5         ��Name$ LeftTabControl��5%      '   !Panuon.UI.Silver.TabControlHelper   
ItemHeight$ 65Q�5&         ItemPadding$
 20 0q�5'         SelectedForeground
 �����   TabControlStyle$ Classic=�5)       �� TabStripPlacement$
 Left=�5+       �� SelectedIndex 5*      �� *SelectTabIndex+ �� Mode$ TwoWay=�@�5,      �� 5-      -   5         ��Name$ tab_AreaPosition��5-      $��库区坐标信息��64   
�������$��25(�6V   .��5.      �  5/      �� 50      $��50 �6,   �� 51      $��* �6,   .+�53      �� $��20 0 0 0q�6%   $ 
Horizontal=�67   .+�54      �� ���	#C800FF35$��Center=�55   %   $��20(�58      $
��10 5q�6+   #   Panuon.UI.Silver.ButtonHelper   
HoverBrush �#97F8A5��56   %   �� *AddNew+��57   %   ��  �� ElementName$ tab_AreaPosition��$ .���5:   "   �� 5;   &   $ 
Horizontal=�61   .+�5<   *   �� $	����64   $��25(�6D   $(��"/Resouces/NeteaseExample/#iconfont)�6R   �� 5=   *   $��10 0 0 0q�64   $��新增��6F   $��20(�6P   5>   '   5@      �� 5A      ���	#C8F64E34$��Center=�5D   %   $��20(�5E      $��30 0 0 0q�6+   $
��10 5q�6=    �#F64E34��5B   %   �� *RemoveCommand+��5C   %   �� $ tab_AreaPosition��$ .���5G   "   �� 5H   &   $ 
Horizontal=�61   .+�5I   *   �� $	����64   $��25(�6D   $(��"/Resouces/NeteaseExample/#iconfont)�6R   �� 5J   *   $��10 0 0 0q�64   $��删除��6F   $��20(�6P   5K   '   5M      5N      &   System.Windows.Controls.DataGrid  5O      $��10 0 2 0q�6#   $��1��65      AutoGenerateColumns .     CanUserAddRows .     CanUserSortColumns .  %   Panuon.UI.Silver.DataGridHelper   CellPadding$ 0q�5V   #      HeaderMinHeight$ 40Q�5W   #      ResizeThumbThickness$ 1Q�5X   #      SelectedBackground �	#44B5B5B5   HoverBackground �	#22B5B5B5��5S   #   �� *	KQZBXXB+ �� SelectedItem 5T   #   �� *SelectedKQXX+    Columns  5[      0	  *System.Windows.Controls.DataGridTextColumn	  5\   "   ,
  &System.Windows.Controls.DataGridColumn! 
  Header$! 仓库编号��65   1  +System.Windows.Controls.DataGridBoundColumn"   Binding" 6D   �� *cCKBH+$ TwoWay=�# �� UpdateSourceTrigger$# PropertyChanged=�	  5]   "   $! 库区编号��65   " 6D   �� *cKuq+$ TwoWay=�$# PropertyChanged=�	  5^   "   $! 库区顶1_X��65   " 5_   "   �� *
nKQZB_X1+$ TwoWay=�$# PropertyChanged=�$ �� 	Converter#$ [ 	  5`   "   $! 库区顶1_Y��65   " 5a   "   �� *
nKQZB_Y1+$ TwoWay=�$# PropertyChanged=�#$ [ 	  5b   "   $! 库区顶2_X��65   " 5c   "   �� *
nKQZB_X2+$ TwoWay=�$# PropertyChanged=�#$ [ 	  5d   "   $! 库区顶2_Y��65   " 5e   "   �� *
nKQZB_Y2+$ TwoWay=�$# PropertyChanged=�#$ [ 	  5f   "   $! 库区顶3_X��65   " 5g   "   �� *
nKQZB_X3+$ TwoWay=�$# PropertyChanged=�#$ [ 	  5h   "   $! 库区顶3_Y��65   " 5i   "   �� *
nKQZB_Y3+$ TwoWay=�$# PropertyChanged=�#$ [ 	  5j   "   $! 库区顶4_X��65   " 5k   "   �� *
nKQZB_X4+$ TwoWay=�$# PropertyChanged=�#$ [ 	  5l   "   $! 库区顶4_Y��65   " 5m   "   �� *
nKQZB_Y4+$ TwoWay=�$# PropertyChanged=�#$ [ 5o      5p      5q      �� 5r      -   5        $ tab_BaseStation��5r      $��基站信息登记��63   
�������$��25(�6U   .��5s      �  5t      �� 5u      $��50 �6,   �� 5v      $��* �6,   .+�5x      �� $��20 0 0 0q�6%   $ 
Horizontal=�67   .+�5y      �� ���	#C800FF35$��Center=�5z   %   $��20(�5}      $
��10 5q�6+    �#97F8A5��5{   %   �� *AddNew+��5|   %   �� $ tab_BaseStation��$ .���5   "   �� 5�   &   $ 
Horizontal=�61   .+�5�   *   �� $	����64   $��25(�6D   $(��"/Resouces/NeteaseExample/#iconfont)�6R   �� 5�   *   $��10 0 0 0q�64   $��新增��6F   $��20(�6P   5�   '   5�      �� 5�      ���	#C8F64E34$��Center=�5�   %   $��20(�5�      $��30 0 0 0q�6+   $
��10 5q�6=    �#F64E34��5�   %   �� *RemoveCommand+��5�   %   �� $ tab_BaseStation��$ .���5�   "   �� 5�   &   $ 
Horizontal=�61   .+�5�   *   �� $	����64   $��25(�6D   $(��"/Resouces/NeteaseExample/#iconfont)�6R   �� 5�   *   $��10 0 0 0q�64   $��删除��6F   $��20(�6P   5�   '   5�      5�        5�      $��10 0 2 0q�6#   $��1��65    .   .   .  $ 0q�5�   #   $ 40Q�5�   #   %   	RowHeight$% 35Q�5�   #   $ 1Q�5�   #    �	#44B5B5B5 �	#22B5B5B5��5�   #   �� *JZXXB+ 5�   #   �� *
SelectJZXX+  5�      4  .System.Windows.Controls.DataGridTemplateColumn  5�   "   $! 仓库编号��69   & 
  MinWidth$& 80Q�6G   ' 
  Width5  /System.Windows.Controls.DataGridLengthConverter$
' Auto 6U   (   CellTemplate( 5�   &   �� 5�   *   .R�5�   .   �� $��0q�67   ) �� DisplayMemberPath$) cCKBH��5�   7   * �� SelectedValuePath$* cCKBH��6Q   + �� SelectedValue+ 5�   B   �� *cCKBH+$ TwoWay=�$# PropertyChanged=���5�   7   ��  �� $	 DataGridL�$ DataContext.KQZBXXB���5�   7   ��  �� $	 DataGridL�$ 	RowHeight�5�   +   5�   #   	  5�   "   $! 基站编号��65   " 6D   �� *cJZBH+$ TwoWay=�$# PropertyChanged=�	  5�   "   $! 基站X坐标��65   " 5�   "   �� *	nJZZB_X+$ TwoWay=�$# PropertyChanged=�#$ [ 	  5�   "   $! 基站Y坐标��65   " 5�   "   �� *	nJZZB_Y+$ TwoWay=�$# PropertyChanged=�#$ [ 	  5�   "   $! 基站安装高度��65   " 5�   "   �� *	nJZAZGD+$ TwoWay=�$# PropertyChanged=�#$ [ 	  5�   "   $! 基站检测最大距离��65   " 5�   "   �� *	nJZJCZDJL+$ TwoWay=�$# PropertyChanged=�#$ [ 	  5�   "   $! 基站可检测半径��65   " 5�   "   �� *
nJZKJCBJ+$ TwoWay=�$# PropertyChanged=�#$ [ 	  5�   "   $! 备注��65   $' * 6A   " 5�   "   �� *cBeiz+$ TwoWay=�$# PropertyChanged=�5�      5�      5�      �� 5�      -   5        $ tab_Master_Slave��5�      $��主从基站设置��64   
�������$��25(�6V   .��5�      �  5�      �� 5�      $��50 �6,   �� 5�      $��* �6,   .+�5�      �� $��20 0 0 0q�6%   $ 
Horizontal=�67   .+�5�      �� ���	#C800FF35$��Center=�5�   %   $��20(�5�      $
��10 5q�6+    �#97F8A5��5�   %   �� *AddNew+��5�   %   �� $ tab_Master_Slave��$ .���5�   "   �� 5�   &   $ 
Horizontal=�61   .+�5�   *   �� $	����64   $��25(�6D   $(��"/Resouces/NeteaseExample/#iconfont)�6R   �� 5�   *   $��10 0 0 0q�64   $��新增��6F   $��20(�6P   5�   '   5�      �� 5�      ���	#C8F64E34$��Center=�5�   %   $��20(�5�      $��30 0 0 0q�6+   $
��10 5q�6=    �#F64E34��5�   %   �� *RemoveCommand+��5�   %   �� $ tab_Master_Slave��$ .���5�   "   �� 5�   &   $ 
Horizontal=�61   .+�5�   *   �� $	����64   $��25(�6D   $(��"/Resouces/NeteaseExample/#iconfont)�6R   �� 5�   *   $��10 0 0 0q�64   $��删除��6F   $��20(�6P   5�   '   5�      5�        5�      $��10 0 2 0q�6#   $��1��65    .   .   .  $ 0q�5�   #   $ 40Q�5�   #   $% 35Q�5�   #   $ 1Q�5�   #    �	#44B5B5B5 �	#22B5B5B5��5�   #   �� *MasterSlave+ 5�   #   �� *SelectMasterSlave+  5�        5�   "   $! 主基站号��69   $	& 150Q�6G   $
' Auto 6V   ( 5�   &   �� 5�   *   .R�5�   .   �� $��0q�67   $) cJZBH��5�   7   $* cJZBH��6Q   + 5�   B   �� *cZJZH+$ TwoWay=�$# PropertyChanged=���5�   7   ��  �� $	 DataGridL�$ DataContext.JZXXB���5�   7   ��  �� $	 DataGridL�$ 	RowHeight�5�   +   5�   #     5�   "   $! 相关基站号��69   $	& 150Q�6H   $
' Auto 6W   ( 5�   &   �� 5�   *   .R�5�   .   �� $��0q�67   $) cJZBH��5�   7   $* cJZBH��6Q   + 5�   B   �� *cXGJZH+$ TwoWay=�$# PropertyChanged=���5�   7   ��  �� $	 DataGridL�$ DataContext.JZXXB���5�   7   ��  �� $	 DataGridL�$ 	RowHeight�5   +   5  #   	  5  "   $! 基站X轴重叠区间1��65   " 5  "   �� *
nJZCDQJ1+$ TwoWay=�$# PropertyChanged=�#$ [ 	  5  "   $! 基站X轴重叠区间2��65   " 5  "   �� *
nJZCDQJ2+$ TwoWay=�$# PropertyChanged=�#$ [ 5     5	     5
     �� 5     -   5        $ tab_StorageLocation��5     $��成品库位设置��67   
�������$��25(�6Y   .��5     �  5     �� 5     $��50 �6,   �� 5     $��* �6,   .+�5     �� $��20 0 0 0q�6%   $ 
Horizontal=�67   .+�5     �� ���	#C800FF35$��Center=�5  %   $��20(�5     $
��10 5q�6+    �#97F8A5��5  %   �� *AddNew+��5  %   �� $ tab_StorageLocation��$ .���5  "   �� 5  &   $ 
Horizontal=�61   .+�5  *   �� $	����64   $��25(�6D   $(��"/Resouces/NeteaseExample/#iconfont)�6R   �� 5  *   $��10 0 0 0q�64   $��新增��6F   $��20(�6P   5  '   5     �� 5     ���	#C8F64E34$��Center=�5"  %   $��20(�5#     $��30 0 0 0q�6+   $
��10 5q�6=    �#F64E34��5   %   �� *RemoveCommand+��5!  %   �� $ tab_StorageLocation��$ .���5%  "   �� 5&  &   $ 
Horizontal=�61   .+�5'  *   �� $	����64   $��25(�6D   $(��"/Resouces/NeteaseExample/#iconfont)�6R   �� 5(  *   $��10 0 0 0q�64   $��删除��6F   $��20(�6P   5)  '   5+     5,       5.     $��10 0 2 0q�6#   $��1��65    .   .   .  $ 0q�54  #   $ 40Q�55  #   $% 35Q�56  #   $ 1Q�57  #    �	#44B5B5B5 �	#22B5B5B5��51  #   �� *
Storages+ 52  #   �� *SelectStorage+  5:       5;  "   $! 仓库编号��69   $	& 150Q�6G   $
' Auto 6V   ( 5<  &   �� 5=  *   .R�5>  .   �� $��0q�67   $) cCKBH��5?  7   $* cCKBH��6Q   + 5>  B   �� *cCKBH+$ TwoWay=�$# PropertyChanged=���5@  7   ��  �� $	 DataGridL�$ DataContext.KQZBXXB���5A  7   ��  �� $	 DataGridL�$ 	RowHeight�5B  +   5D  #     5E  "   $! 库区编号��69   $	& 150Q�6G   $
' Auto 6V   ( 5F  &   �� 5G  *   .R�5H  .   �� $��0q�67   $
) cKuq��5I  7   $
* cKuq��6P   + 5H  B   �� *cKQBH+$ TwoWay=�$# PropertyChanged=���5J  7   ��  �� $	 DataGridL�$ DataContext.KQZBXXB���5K  7   ��  �� $	 DataGridL�$ 	RowHeight�5L  +   5N  #   	  5O  "   $! 库位编号��65   " 5P  "   �� *cKWBH+$ TwoWay=�$# PropertyChanged=�	  5Q  "   $! 最大堆放数��65   " 5R  "   �� *nZDDFS+$ TwoWay=�$# PropertyChanged=�	  5S  "   $! 库位描述��65   " 5T  "   �� *cKWMS+$ TwoWay=�$# PropertyChanged=�5V     5W     5X     �� 5Y     -   5        $ tab_RunTime��5Y     $��运行时间配置��6/   
�������$��25(�6Q   .��5Z     �  5[     �� 5\     $��50 �6,   �� 5]     .+�5_     �� $��20 0 0 0q�6%   $ 
Horizontal=�67   .+�5`     �� ���	#C800FF35$��Center=�5a  %   $��20(�5d     $
��10 5q�6+    �#97F8A5��5b  %   �� *AddNew+��5c  %   �� $ tab_RunTime��$ .���5f  "   �� 5g  &   $ 
Horizontal=�61   .+�5h  *   �� $	����64   $��25(�6D   $(��"/Resouces/NeteaseExample/#iconfont)�6R   �� 5i  *   $��10 0 0 0q�64   $��新增��6F   $��20(�6P   5j  '   5l     �� 5m     ���	#C8F64E34$��Center=�5p  %   $��20(�5q     $��30 0 0 0q�6+   $
��10 5q�6=    �#F64E34��5n  %   �� *RemoveCommand+��5o  %   �� $ tab_RunTime��$ .���5s  "   �� 5t  &   $ 
Horizontal=�61   .+�5u  *   �� $	����64   $��25(�6D   $(��"/Resouces/NeteaseExample/#iconfont)�6R   �� 5v  *   $��10 0 0 0q�64   $��删除��6F   $��20(�6P   5w  '   5y     5z       5{     $��10 0 2 0q�6#   $��1��65    .   .   .  $ 40Q�5�  #   $ 1Q�5�  #    �	#44B5B5B5 �	#22B5B5B5��5  #   �� *	YXSJSZs+ 5�  #   �� *
SelectYXSJ+  5�     	  5�  "   $! 	唯一键��65   $
' Auto 6B   $	& 200Q�6O   " 5�  "   �� *CKEY+$ TwoWay=�$# PropertyChanged=�	  5�  "   $! 	当前值��65   $
' Auto 6B   $	& 150Q�6O   " 5�  "   �� *CVALUE+$ TwoWay=�$# PropertyChanged=�	  5�  "   $! 说明��65   $' * 6A   " 5�  "   �� *
CEXPLAIN+$ TwoWay=�$# PropertyChanged=�5�     5�     5�     5�     �� 5�  
   $ 
Horizontal=�6   $��1��6.   $��Center=�6;   $��Right=�6V   .+�5�     �� ���	#C800FF35$��Center=�5�     $��20(�5�     $
��10 4q�6+    �#97F8A5��5�     �� *SaveCommand+��5�     �� 5�     $ 
Horizontal=�6!   .+�5�     �� $	����6$   $��25(�64   $(��"/Resouces/NeteaseExample/#iconfont)�6B   �� 5�     $��10 0 0 0q�6$   $��保存��66   $��20(�6@   5�     5�     �� 5�     ���	#C8FF0000$��Center=�5�     4  .Position_BulletinBoard.Commands.WindowCommands,   CloseWindow#��Z, 5�     $��20(�5�     $
��10 4q�6+   $��	10 0 10 0q�5�      �#FF0000��5�     �� - �� Self# Z- ��5�     �� 5�     $ 
Horizontal=�6!   .+�5�     �� $	����6$   $��25(�64   $(��"/Resouces/NeteaseExample/#iconfont)�6B   �� 5�     $��10 0 0 0q�6$   $��关闭��66   $��20(�6@   5�     5�     5�     � 5�  
   -   5        . �Name$. 	waitPross��5�     
�������/ J� Opacity$	/ 0.3Q�6X   $��2��6f   y�6"   �� *WaitProssVis+.+�5�        Panuon.UI.Silver.Loading  $	��100��6   $��Center=�6%   $��Center=�5�     $	��100��68   0   LoadingStyle$
0 Wave=�5�     
���   �1   	IsRunning1 5�     �� *	WaitPross+5�     5�     5�     