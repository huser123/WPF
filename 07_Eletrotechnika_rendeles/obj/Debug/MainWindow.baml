   M S B A M L   `   `   `  ����D  @Rendelés, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:Rendelés	Rendelés  5   	       Rendelés.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:Rendelés     5   	     � Title$  Elektro bolt��5   	   $	��500��6   $	��500��6+   ���	#FF4157D4 � 	Resources 5	      ��%    5      .��5      �  � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $��* �6   .+�5   
   �� $��kep.jpg��6   $��0��6!   $��2��6.   $	��Top=�6B   �� 5   
   -   5         ��Name$ lboxArucikkek��5      $��1��6   $��0��66   $
��auto��6F   $	��150��6S   $��5,5,5,5q�6`   $	��Top=�6q   �� 5   
   -   5        $ lboxKivalasztott��5      $��1��6   $��2��69   $
��auto��6I   $	��150��6V   $��5,5,5,5q�6c   $	��Top=�6t   �� 5   
   $��0��6   $��bottom=�6%   $
��auto��6@   $��Center=�6O    �� Orientation$ 
Horizontal=�6l   $��0,5,0,50q�6�   $��1��6�   .+�5      �� -   5         ��Name$ 
btnHozzaad��5      $��Hozzáad��6)   $��60��6;   $	��100��6G   $��20(�6S   $
��bold"�6a   6s   5      �� 5   
   $��2��6   $��bottom=�6%   $
��auto��6@   $��Center=�6O   $ 
Horizontal=�6l   $��0,5,0,50q�6�   $��1��6�   .+�5       �� -   5        $ btnTorol��5       $��Töröl��6'   $��60��67   $	��100��6C   $��20(�6O   $
��bold"�6]   $��5q�6o   6z   �� 5!      -   5        $ 	btnRendel��5!      $��Rendel��6(   $��60��69   $	��100��6E   $��20(�6Q   $
��bold"�6_   $��5q�6q   6|   5"      �� 5#   
   -   5         ��Name$ lblAr��5#      $��
Ár eddig:��6   $��15(�63   $��Bottom=�6A   $��1��6\   $��1��6l   
���  ��6y   5%      5&      