   M S B A M L   `   `   `  ����H  DTimeManagment, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:TimeManagmentTimeManagment  5      %    TimeManagment.EmployeeManagment   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -localclr-namespace:TimeManagment     5        N� Title$  EmployeeManagment��5	      .��5      ]� .+�5   
   �  � RowDefinitions 5      �� 5      $
��0.6* �6    �� 5      �� 5      $
��0.3* �6    .+�5      �� -   5        $��2��5   "   .��6/   
Выход66   �� 5      -   5         ��Name$ avatar��5      $	��150��6$   $	��150��60   �� 5      -   5         ��Name$ WorkList��5   #   $��1��6   ��5      �� 5      .R�5      �� .+�5      �� $��начал:��6'   .��5   "   �� 
���   ���6?   �� *	startWork+6\   5      �� 5      $��Закончил:��6'   .��5   "   �� 
���   ���6?   �� *	endwork+6Z   5      �� 5      $��Статус��6'   .��5   "   �� 
���   ���6?   �� *status1.name+5       5!      5"      5$      5%      � 5&   
    5'      �� 5(      $
��0.4* �6    �� 5)      �� 5*      .+�5,      �� -   5        $
��info��5,   A   $��Center=�6   $��1��61   $��Center=�6M   $��20(�6h   .��6v   *(Учет рабочего времени6�   �� 5-      -   5         ��Name$ Startbt��5-      $��1��6&   $	��100��63   $	��300��6@   
��� � �$��20(�6_   .��6{   Начать6�   �� 5.      -   5        $ Stopbt��5.   &   
���  ��{�.  $��2��6H   $	��100��6U   $	��300��6b   $��20(�6n   .��6�   Закончить6�   5/      50      51      