   M S B A M L   `   `   `  ����O  KSaleOfRailWayTickets, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:lab4_5.Viewlab4_5.View  5   	       lab4_5.View.ClientWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:lab4_5.View     5   	     � WindowState$  	Maximized=�61    � Title$ ClientWindow��5   	   $
��1080��6   $
��1920��6,   ��5	      �� 5
   
   -   5        BackgroundImg�� �� ImageSource$# /Resources/img/background.png��5
   ,    j� Stretch$
 Fill=�6X   .��5      �  � RowDefinitions 5   
   �� 5      $	��93* �6   �� 5      $��7* �6   .+�5   
    � -   5          �Name$ 	MainFrame��5      $��0��6#     � NavigationUIVisibility$ Hidden=�60   6R   �� 5   
   $��1��6   ���#FF98006"   � 5   
   $��1��6   $
��10 0q�6    � ColumnDefinitions 5      �� 5      $	��25* �6#   �� 5      $	��25* �6#   �� 5      $	��25* �6#   �� 5      $	��25* �6#   .+�5      �� -   5         ��Name$
 Home��5      $��0��6$   $��0��61   $��Center=�6A   $��Center=�6^   .��5      �� 	 �� Orientation$	 
Horizontal=�6   
 � Cursor$
  ��66   .+�5       �� $��/Resources/img/home.png��6   $��18��6=   $��20��6H   5!      5"      �� 5$      -   5        $ Schulde��5$      $��0��6'   $��1��64   $��Center=�6D   $��Center=�6a   .��5%      �� $	 
Horizontal=�6   $
  ��66   .+�5&      �� $��/Resources/img/ticket.png��6   $��18��6?   $��20��6J   5'      5(      �� 5*      -   5        $ StatusTickets��5*      $��0��6,   $��2��69   $��Center=�6I   $��Center=�6f   .��5+      �� $	 
Horizontal=�6   $
  ��66   .+�5,      �� $ ��/Resources/img/schulde.png��6   $��18��6@   $��20��6K   5-      5.      �� 50      -   5        $ Account��50      $��0��6&   $��3��63   $��Center=�6C   $��Center=�6`   .��51      �� $	 
Horizontal=�6   $
  ��66   .+�52      �� $ ��/Resources/img/account.png��6   $��18��6@   $��20��6K   53      54      55      56      57      