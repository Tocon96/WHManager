   M S B A M L   `   `   `  ���� N  JWHManager.DesktopUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullc6clr-namespace:WHManager.DesktopUI.Views.WarehouseViews(WHManager.DesktopUI.Views.WarehouseViews  :    4WHManager.DesktopUI.Views.WarehouseViews.ProductView   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     Hlocal6clr-namespace:WHManager.DesktopUI.Views.WarehouseViews       � 	Resources   �� 
TargetType �� Property �� Value   ButtonStyle �� 
TargetType �� Triggers P� Property P� Value  DataGridStyle&   System.Windows.Controls.DataGrid5  /System.Windows.Controls.DataGridLengthConverter=  7System.Windows.Controls.Primitives.DataGridColumnHeader # Body_Content_DataGrid_Centering*  $System.Windows.Controls.DataGridCell��%�  '��       &	  \     &	 �    '  �    &	     �� " ��.���  � �� �#1565c0��  � ��
 �������  � ��$ Stretch=��� " ��.���  �@�OverridesDefaultStyle$
 True����  �@�Cursor$ Arrow����  � ��$ 30����  � �� �#1565c0��  � ��
 �������  � ��$ 12(���  � �� �� " ��.R��� $��border��$��0q�
���   �#��z��._��� $��Center=�$��Center=� P�  �@J�IsMouseOver$
 True��. ���  � ��
 ������� "  .���  � ��$ Stretch=���  �@ AutoGenerateColumns$ False����  �@ CanUserAddRows$ False����  �@ 
IsReadOnly$
 True����  �@ ColumnWidth$ * �� "  .���  � ��$ Center=���  � ��$ Center=���  � �� �#1565c0��  � ��$ 30����  � ��
 ������� "  .���  � �� �� "  .R�� #��z��.+��� $��Center=��� $��Center=���  � ��$ 18(�.���  � RowDefinitions �� $
��auto ��� $��* �	 � ColumnDefinitions	 �� $��* �.+�� $��0��	 �� $	��100 ��� $��* ��� $	��100 �.+�� $��0�� �� $��* ��� $
��auto ��� $
��auto �.+��� -   $��0��$��75��#��[  .��	Wyczyść� $��1�� �� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $��10 �	 �� $��* ��� $��* ��� $��* ��� $��* �.+��� $��0��$��0��	Nazwa/ID:�� $��0��$��1��Typ Produktu:�� $��2��$��0��
Producent:�� $��2��$��1��
Podatek:�� $��0��$��2��Cena kupna minimalna:�� $��0��$��3��Cena kupna maksymalna:�� $��2��$��2��Cena sprzedaży minimalna:�� $��2��$��3��Cena sprzedaży maksymalna:�� -   $��idNameTextBox��$��1��$��0���� -   $��productTypeComboBox��$��1��$��1���� -   $��manufacturerComboBox��$��3��$��0���� -   $��taxComboBox��$��3��$��1���� -   $��priceBuyMinTextBox��$��1��$��2���� -   $��priceBuyMaxTextBox��$��1��$��3���� -   $��priceSellMinTextBox��$��3��$��2���� -	   $��priceSellMaxTextBox��$��3��$��3��� $��2�� �� $
��auto ��� $��* ��� $
��auto �.+��� -
   $��1��$��75��#��[  .��
Wyszukaj� $��1�� �� $��* ��� $
��auto �	 �� $��* ��� $
��auto ��� $��* �.+�  -   
  Name$
 gridProduct��#��[    	CellStyle# [ $��0��$��0��$��3��   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Width$ 25    Header$ ID��1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *Id+  $ Nazwa�� �� *Name+  $ Typ produktu�� �� *	Type.Name+  $ 75 $ Podatek�� �� *	Tax.Value+  $ 	Producent�� �� *Manufacturer.Name+  $	 100 $ 
Cena kupna�� �� *
PriceBuy+  $	 100 $ Cena sprzedaży�� �� *	PriceSell+4  .System.Windows.Controls.DataGridCheckBoxColumn  $ 75 $ Dostępność�� �� *	InStock+4	  .System.Windows.Controls.DataGridTemplateColumn	  $ 50  	  CellTemplate �� .R��� -   #��[  $��50��.��Edytuj	  $ 50  �� .R��� -   #��[  $��50��.��Usuń � ContextMenu �� .@�m� -   $��Przedmioty w magazynie��m� -   $��Przedmioty historyczne��� $��2��$��10�� �� �� �� 	 �� �� �� .+��� -   $��0��$��3��$��60��$��1��$	��200��#��[  .��Dodaj�� -   $��1��$��2��$	��100��$��Right=�#��[  .��Usuń wybrane