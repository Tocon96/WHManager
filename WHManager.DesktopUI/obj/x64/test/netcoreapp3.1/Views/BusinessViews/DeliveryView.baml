   M S B A M L   `   `   `  ���� N  JWHManager.DesktopUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulla5clr-namespace:WHManager.DesktopUI.Views.BusinessViews'WHManager.DesktopUI.Views.BusinessViews  :    4WHManager.DesktopUI.Views.BusinessViews.DeliveryView   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     Glocal5clr-namespace:WHManager.DesktopUI.Views.BusinessViews       � 	Resources   �� 
TargetType �� Property �� Value   ButtonStyle �� 
TargetType �� Triggers P� Property P� Value  DataGridStyle&   System.Windows.Controls.DataGrid5  /System.Windows.Controls.DataGridLengthConverter=  7System.Windows.Controls.Primitives.DataGridColumnHeader # Body_Content_DataGrid_Centering*  $System.Windows.Controls.DataGridCell  ButtonsToDisable �� Triggers	 �� Binding
 �� Value��%�  '��       &	  \     &	 �    '  �    &	     &	 �    �� " ��.���  � �� �#1565c0��  � ��
 �������  � ��$ Stretch=��� " ��.���  �@�OverridesDefaultStyle$
 True����  �@�Cursor$ Arrow����  � ��$ 30����  � �� �#1565c0��  � ��
 �������  � ��$ 12(���  � �� �� " ��.R��� $��border��$��0q�
���   �#��z��._��� $��Center=�$��Center=� P�  �@J�IsMouseOver$
 True��. ���  � ��
 ������� "  .���  � ��$ Stretch=���  �@ AutoGenerateColumns$ False����  �@ CanUserAddRows$ False����  �@ 
IsReadOnly$
 True����  �@ ColumnWidth$ * �� "  .���  � ��$ Center=���  � ��$ Center=���  � �� �#1565c0��  � ��$ 30����  � ��
 ������� "  .���  � �� �� "  .R�� #��z��.+��� $��Center=��� $��Center=���  � ��$ 18(��� " ��.���  �@�OverridesDefaultStyle$
 True����  �@�Cursor$ Arrow����  � ��$ 30����  � �� �#1565c0��  � ��
 �������  � ��$ 12(���  � �� �� " ��.R��� $��border��$��0q�
���   �#��z��._��� $��Center=�$��Center=� P�  �@J�IsMouseOver$
 True��. ���  � ��
 �����P�  � {�$ False��. ���  � ��
 �������  � ��
 �   � �� 	 �� *
Realized+
 True.a���  � {�$ False��.���  � RowDefinitions �� $
��auto ��� $��* � � ColumnDefinitions �� $��* �.+�� $��0�� �� $	��100 ��� $��* ��� $	��100 �.+�� $��0�� �� $��* ��� $
��auto ��� $
��auto �.+��� -   $��0��$��75��#��[  .��	Wyczyść� $��1�� �� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $��10 � �� $��* ��� $��* ��� $��* ��� $��* ��� $��* ��� $��* ��� $��* ��� $��* �.+��� $��0��$��1��$��2��ID zamówienia:�� $��0��$��3��$��2��Nazwa dostawcy:�� $��0��$��5��$��2��Realizacja:�� $��0��$��1��$��2��$y�Hidden=�Nazwa dostawcy:�� $��2��$��2��$��2��Od: (Data złożenia)�� $��2��$��4��$��2��Do: (Data złożenia)�� $��4��$��2��$��2��Od: (Data realizacji)�� $��4��$��4��$��2��Do: (Data realizacji)�� -   $��textBoxDeliveryId��$��1��$��1��$��2���� -   $��textBoxProviderName��$��1��$��3��$��2���� $��3��$��1��$y�Hidden=��� -   $��comboBoxRealized��$��5��$��1��$��2��(  "System.Windows.Controls.DatePicker  -     Name$" datePickerEarlierDateOrdered��$��2��$��2��$��3��  -   $  datePickerLaterDateOrdered��$��4��$��2��$��3��  -   $# datePickerEarlierDateRealized��$��2��$��2��$��5��  -   $! datePickerLaterDateRealized��$��4��$��2��$��5��� $��2�� �� $
��auto ��� $��* ��� $
��auto �.+��� -	   $��1��$��75��#��[  .��
Wyszukaj� $��1�� �� $��* ��� $
��auto � �� $��* ��� $
��auto ��� $��* �.+�  -
     Name$ gridDeliveries��#��[    	CellStyle# [ $��0��$��0��$��3��   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Width$ 30    Header$ ID��1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *Id+  $ Nazwa klienta�� �� *Provider.Name+  $	 100 $ Data złożenia�� �� *DateCreated+ �� StringFormat$ {0:yyyy-MM-dd}��  $	 100 $ Data zrealizowania�� �� *DateRealized+$ {0:yyyy-MM-dd}��4	  .System.Windows.Controls.DataGridCheckBoxColumn	  $ 70 $ Zrealizowane��-   Realized�� �� *
Realized+4
  .System.Windows.Controls.DataGridTemplateColumn
  $ 50  
  CellTemplate �� .R��� -   #��[ $��50��.��Edytuj
  $ 50  �� .R��� -   #��[ $��50��.��Usuń � ContextMenu �� .@�m� -   $��Zrealizuj zamówienie��m� -   $��Wyświetl przedmioty��m� -   $&�� Wyświetl dokument przychodzący��� $��2��$��10�� �� �� ��  �� �� �� .+��� -   $��0��$��3��$��60��$��1��$	��200��#��[  .��Dodaj