   M S B A M L   `   `   `  ����K  GPanuon.UI.Silver, Version=1.1.3.0, Culture=neutral, PublicKeyToken=nullM8clr-namespace:Panuon.UI.Silver;assembly=Panuon.UI.SilverPanuon.UI.Silver  5   	   c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity 5   	   L HPositioningSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:PositioningSystemPositioningSystem 5   	   "   PositioningSystem.MainWindow   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Gpu8clr-namespace:Panuon.UI.Silver;assembly=Panuon.UI.Silver     5   	   ^iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity     5   	   1localclr-namespace:PositioningSystem     5   	   b ^GalaSoft.MvvmLight.Platform, Version=5.4.1.0, Culture=neutral, PublicKeyToken=5f873c45e98af8a1+mvvm http://www.galasoft.ch/mvvmlight  5	   	   -   5          � 
ResizeMode$  CanMinimize=�5   	    � WindowStartupLocation$ CenterScreen=�5   	      NeteaseMusicWindow#��[  5   	    � Title$ Service��5   	   $	��250��6   $	��400��6&   .  (System.Windows.Interactivity.Interaction   Triggers 5      /  )System.Windows.Interactivity.EventTrigger  5   
      	EventName$ Loaded��6   .  (System.Windows.Interactivity.TriggerBase   Actions. 5      /  )GalaSoft.MvvmLight.Command.EventToCommand     Command 6"   �� *WindowLoadedCommand+5      %   Panuon.UI.Silver.WindowXCaption   Header 5      �� 5   
    �� Orientation$ 
Horizontal=�6   .+�5      �� $��20(�6   $��Light"�5      $��Center=�5      $��	15,0,30,0q�5      
�������$��Service��5      5      	 � DataContext	 5      �� 5    
     Locator
 �� Source#
 [ 6    �� Path$
 Main�64   .��5"      � .+�5#   
   �� $ Vertical=�6   .+�5$      �� $��	10 10 0 0q�6   $ 
Horizontal=�6-   .+�5%      �� $��上班时间范围��6   $��Center=�6*   
�������$��15(�6W   $��Roman)�6e   �� 5'      ���	#96FFED00$��10 0 0 0q�60    �� CornerRadius$ 5��6B   ._�5(      �� $��Roman)�6;   ���	#96FF0000$
��10 2q�6e   $��17(�6s   ��6    �� *	WorkHours+6s   5)      5*      �� 5+      $��	10 10 0 0q�6   $ 
Horizontal=�6-   .+�5,      �� $$��上班范围更新数据间隔��6   $��Center=�6.   
�������$��15(�6[   $��Roman)�6i   �� 5.      ���	#96FFED00$��2 0 2 0q�60   $ 5��6A   ._�5/      �� $��Roman)�6A   ���	#96FF0000$
��10 2q�6k   $��17(�6y   ��6    �� *WorkHoursUpdate+6y   50      �� 51      $	��秒��6   $��Center=�6%   $��Center=�6B   
�������$��15(�6o   $��Roman)�6}   52      �� 53      $��	10 10 0 0q�6   $ 
Horizontal=�6-   .+�54      �� $'��!非上班范围更新数据间隔��6   $��Center=�6/   
�������$��15(�6\   $��Roman)�6j   �� 56      ���	#96FFED00$��2 0 2 0q�60   $ 5��6A   ._�57      �� $��Roman)�6D   ���	#96FF0000$
��10 2q�6n   $��17(�6|   ��6    �� *NotWorkHoursUpdate+6|   58      �� 59      $	��秒��6   $��Center=�6%   $��Center=�6B   
�������$��15(�6o   $��Roman)�6}   5:      �� 5;      $��	10 10 0 0q�6   $ 
Horizontal=�6-   .+�5<      �� $	��280��6[   $
��Wrap=�6j   $��Center=�6~   $��15(�6�   $��Roman)�6�   ��6   �� *WorkMessage+��69   �� *
Foreground+6�      Panuon.UI.Silver.Loading  5=         LoadingStyle$ Classic=�6   $��40��64   $��40��6?      	IsRunning 6K   �� *LoadingIsRuning+5>      5?      5@      5A      