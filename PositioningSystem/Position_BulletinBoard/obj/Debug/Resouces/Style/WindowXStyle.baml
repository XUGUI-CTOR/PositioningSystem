   M S B A M L   `   `   `  ����Q  MPosition_BulletinBoard, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:Position_BulletinBoard.UtilsPosition_BulletinBoard.Utils  5      K GPanuon.UI.Silver, Version=1.1.3.0, Culture=neutral, PublicKeyToken=nullM8clr-namespace:Panuon.UI.Silver;assembly=Panuon.UI.SilverPanuon.UI.Silver 5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089   	GridBrush  j� Viewport j� ViewportUnits j� Stretch j� TileMode L� Drawing � Brush � Geometry �� Rect3   -System.Windows.Media.Effects.DropShadowEffect  
DropShadow    Color	    ShadowDepth
    
BlurRadius    Opacity  ColorSelectorBrush � Color � Offset  NeteaseMusicWindow �� 
TargetType  Panuon.UI.Silver.WindowX �� BasedOn �� Property �� Value%  Panuon.UI.Silver.WindowXCaption2   ,Position_BulletinBoard.Utils.MyWindowXHelper#  Panuon.UI.Silver.ButtonHelper �� Triggers �� Binding �� Path �� RelativeSource �� Mode �� Value �� AncestorType�� 5      D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    :x,http://schemas.microsoft.com/winfx/2006/xaml     5      3winx*clr-namespace:Position_BulletinBoard.Utils  5      ?pu8clr-namespace:Panuon.UI.Silver;assembly=Panuon.UI.Silver  5      %3  &	        &	     &	 �    &	 �    7 7��7��7��L� 5      $  	0,0,12,12�5      $ Absolute=�5      $
 None=�5      $
 Tile=�5	       5
   
   I� 5      .��5      �  �	#44D0CEC7 5      � 5      .��5      �� $ 0,0,6,6�60   �� 5      $ 6,6,6,6�60   5      5      � 5       �	#44E7E7E2 5      �� 5      $ 0,6,12,0�6,   5      5      5         5      $ 	LightGray��5      $	 2Q�5      $
 20Q�5       $	 0.5Q�5!      �� 5#      .��5$   
   � $ #ff0000��6   � 5%   
   $ #ff00ff��6   $ 0.571Q�5&      � 5'   
   $ #0000ff��6   $
 0.45Q�5(      � 5)   
   $ #00ffff��6   $ 0.3426Q�5*      � 5+   
   $ #00ff00��6   $ 0.2285Q�5,      � 5-   
   $ #ffff00��6   $ 0.114Q�5.      � 5/   
   $ #ff0000��6   $ 0.7994Q�50      � 51   
   $ White��6   $ 0.7995Q�52      � 53   
   $ Black��6   $ 1Q�54      55      �� 57      "  58      8   .�5:   
   ��  � ��$ 14(�5;      �� 5<   
    � ��$ 0q�5=      �� 5>   
    �@ Height$ 35Q�5?      �� 5@   
    �@ 
Background �	#FF5F61615A      �� 5B   
    �@ MinButtonVis$ Visible=�6>   �� 5C   
    �@ MaxButtonVis$ Visible=�6>   �� 5D   
    �@ MinimizeButtonStyle 5E      �� 5F      " ��6   8  .�5H      ��  �@ ButtonStyle$
 Link=�5I       5J      �� 5K       6&   �� $# (pu:ButtonHelper.ButtonStyle)� �� *Self+$ OneWay=� Link5L   &   .a�5M      ��  � ��$	 ��5N   %   �� 5O       � ��$( "/Resouces/NeteaseExample/#iconfont)�5P   %   �� 5Q       � ��$ 28��5R   %   �� 5S       � ��$ 28��5T   %   �� 5U       � ��$ 16(�5V   %   �� 5W       � ��$ Center=�5X   %   �� 5Y       � y� 6;   �� *%#(winx:MyWindowXHelper.MinButtonVis)+ �� $ 
pu:WindowXL��� 5Z       � �� �#EAEAEA5[   %   �� 5\       �@ 
HoverBrush �#FFFFFF5]   %   5^      5`      5b      �� 5c   
    �@ MaximizeButtonStyle 5d      �� 5e      " ��6   8  .�5g      ��  �@ ButtonStyle$
 Link=�5h       5i      �� 5j       6&   �� $# (pu:ButtonHelper.ButtonStyle)� �� *Self+$ OneWay=� Link5k   &   .a�5l      ��  � ��$	 ��5m   %   �� 5n       � ��$ 28��5o   %   �� 5p       � ��$ 28��5q   %   �� 5r       � ��$ 16(�5s   %   �� 5t       � ��$( "/Resouces/NeteaseExample/#iconfont)�5u   %   �� 5v       � ��$ Center=�5w   %   �� 5x       � �� �#EAEAEA5y   %   �� 5z       �@ 
HoverBrush �#FFFFFF5{   %   �� 5|       � y� 6;   �� $) #(winx:MyWindowXHelper.MaxButtonVis)� �� $ 
pu:WindowXL�5}      5      5�      �� 5�   
    �@ CloseButtonStyle 5�      �� 5�      " ��6   8  .�5�      ��  �@ ButtonStyle$
 Link=�5�       5�      �� 5�       6&   �� $# (pu:ButtonHelper.ButtonStyle)� �� *Self+$ OneWay=� Link5�   &   .a�5�      ��  � ��$	 ��5�   %   �� 5�       � ��$( "/Resouces/NeteaseExample/#iconfont)�5�   %   �� 5�       � ��$ 28��5�   %   �� 5�       � ��$ 28��5�   %   �� 5�       � ��$ 16(�5�   %   �� 5�       � ��$ 0,0,5,0q�5�   %   �� 5�       � ��$ Center=�5�   %   �� 5�       � �� �#EAEAEA5�   %   �� 5�       �@ 
HoverBrush �#FFFFFF5�   %   5�      5�      5�      5�      5�      