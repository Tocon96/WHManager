   M S B A M L   `   `   `  ���� N  JWHManager.DesktopUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullm;clr-namespace:WHManager.DesktopUI.Views.AdministrationViews-WHManager.DesktopUI.Views.AdministrationViews  <    6WHManager.DesktopUI.Views.AdministrationViews.RoleView   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     Mlocal;clr-namespace:WHManager.DesktopUI.Views.AdministrationViews       � 	Resources   �� 
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
 �   � �� 	 �� *Id+
 1.a���  � {�$ False��.���  � RowDefinitions �� $
��auto ��� $��* � � ColumnDefinitions �� $��* �.+�� $��0�� �� $	��100 ��� $��* ��� $	��100 �.+�� $��0�� �� $��* ��� $
��auto ��� $
��auto �.+��� -   $��0��$��75��#��[  .��	Wyczyść� $��1�� �� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $��10 � �� $��* ��� $��* ��� $��* ��� $��* �.+��� $��1��$��1��$��2��	Nazwa/ID:�� $��0��$��1��$y�Hidden=�	Nazwa/ID:�� -   $��textBoxIdName��$��2��$��1��$��2���� $��3��$��1��$y�Hidden=�� $��2�� �� $
��auto ��� $��* ��� $
��auto �.+��� -   $��1��$��75��#��[  .��
Wyszukaj� $��1�� �� $��* ��� $
��auto � �� $��* ��� $
��auto ��� $��* �.+�  -     Name$ 	gridRoles��#��[    	CellStyle# [ $��0��$��0��$��3��   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Width$ 25    Header$ ID��1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *Id+  $ 
Nazwa roli�� �� *Name+4  .System.Windows.Controls.DataGridCheckBoxColumn  $ Administracja�� �� *Admin+  $ 	Dokumenty�� �� *	Documents+  $ Biznes�� �� *
Business+  $ Kontrahenci�� �� *Contractors+  $ Produkty�� �� *	Warehouse+4	  .System.Windows.Controls.DataGridTemplateColumn	  $ 50  	  CellTemplate �� .R��� -   $��50��#��[ .��Edytuj	  $ 50  �� .R��� -   $��50��#��[ .��Usuń� $��2��$��10�� �� �� ��  �� �� �� .+��� -   $��0��$��3��$��60��$��1��$	��200��#��[  .��Dodaj�� -   $��0��$��2��$	��100��$��Right=�#��[  .��Usuń wszystkie�� $��2��$��1��$	��100��$��Right=��� -	   $��2��$��2��$	��100��$��Right=�#��[  .��Usuń wybrane