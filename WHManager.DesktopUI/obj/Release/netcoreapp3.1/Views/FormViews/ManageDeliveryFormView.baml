   M S B A M L   `   `   `  ���� N  JWHManager.DesktopUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullY1clr-namespace:WHManager.DesktopUI.Views.FormViews#WHManager.DesktopUI.Views.FormViews  @    :WHManager.DesktopUI.Views.FormViews.ManageDeliveryFormView   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     Clocal1clr-namespace:WHManager.DesktopUI.Views.FormViews       � Title$   �� � SizeToContent$ WidthAndHeight=� � 
ResizeMode$ NoResize=� � WindowStyle$
 None=� � 	Resources  �� 
TargetType �� Property �� Value   ButtonStyle �� 
TargetType	 �� Triggers
 P� Property P� Value  ButtonGridStyle  DataGridStyle&   System.Windows.Controls.DataGrid5  /System.Windows.Controls.DataGridLengthConverter=  7System.Windows.Controls.Primitives.DataGridColumnHeader # Body_Content_DataGrid_Centering*  $System.Windows.Controls.DataGridCell��%T  '��       &	  �     &	 �    &	 X    '      &	 �    �� " ��.���  � �� �#1976d2��  � ��
 �������  � ��$ Stretch=���  �@��TextAlignment$ Center=��� " ��.���  �@�OverridesDefaultStyle$
 True����  �@�Cursor$ Arrow����  � ��$ 30����  � �� �#1565c0��  � ��
 �������  � ��$ 16(���  � �� �� " ��.R��� $��border��$��0q�
���   �#��z��._��� $��Center=�$��Center=�	 P� 
 �@J�IsMouseOver$
 True��. ���  � ��
 ������� " ��.���  �@�OverridesDefaultStyle$
 True����  �@�Cursor$ Arrow����  � ��$ 20����  � �� �#1565c0��  � ��
 �������  � ��$ 14(���  � �� �� " ��.R��� $��border��$��0q�
���   �#��z��._��� $��Center=�$��Center=�	 P� 
 �@J�IsMouseOver$
 True��. ���  � ��
 ������� "  .���  � ��$ Stretch=���  �@ AutoGenerateColumns$ False����  �@ CanUserAddRows$ False����  �@ 
IsReadOnly$
 True����  �@ ColumnWidth$ * �� "  .���  � ��$ Center=���  � ��$ Center=���  � �� �#1565c0��  � ��$ 30����  � ��
 ������� "  .���  � �� �� "  .R�� #��z��.+��� $��Center=��� $��Center=���  � ��$ 14(�.���  � ColumnDefinitions �� $
��auto ��� $
��auto ��� $
��auto ��� $��* � � RowDefinitions �� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $��5 ��� $
��auto �.+��� -    ��Name$ textBlockManageDelivery��$��4��$��0��$��30��$��18(�Dodaj Nowe Zamówienie�� $��1��$��0��$��3��Data złożenia�� $��3��$��0��$��3��
Dostawca�� $��5��$��0��$��3��	Produkt�� $��7��$��0��$��3��	Ilość(  "System.Windows.Controls.DatePicker  -     Name$ datepickerDeliveryDate��$��0��$��3��$��2��   SelectedDateFormat$ Short=��� -    ��Name$! comboBoxDeliveriesProviders��$��0��$��4��$��3�� �� DisplayMemberPath$
 Name���� -   $  comboBoxDeliveriesProducts��$��0��$��6��$��3��$
 Name���� -    ��Name$! textBoxDeliveryProductCount��$��0��$��8��$��3���� -   $��0��$��3��$��9��#��[  .��Dodaj przedmioty�� -   $��0��$��11��$	��150��#��[  .��Anuluj�� $��11��$��1�� �� Orientation$ 
Horizontal=�.+��� #��["��� -   $��2��$��11��$	��150��#��[  .��
Zatwierdź  -	   $��	gridItems��$��1��$��11��$��3��   SelectionMode$ Single=�   AutoGenerateColumns$ False��   CanUserAddRows$ False��   
IsReadOnly$
 True��$
��True��$
��Auto=�$
��Auto=�$	��215��$	��Top=�   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ Produkt��   Width$	 150    	CellStyle# [ 1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *Name+  $ Ilość��$	 150 # [  �� *Count+4	  .System.Windows.Controls.DataGridTemplateColumn	  $ 50  	  CellTemplate �� .R��� -
   #��[ .��Usuń