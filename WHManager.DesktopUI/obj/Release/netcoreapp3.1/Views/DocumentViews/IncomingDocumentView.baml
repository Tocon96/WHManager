   M S B A M L   `   `   `  ���� N  JWHManager.DesktopUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulla5clr-namespace:WHManager.DesktopUI.Views.DocumentViews'WHManager.DesktopUI.Views.DocumentViews  B    <WHManager.DesktopUI.Views.DocumentViews.IncomingDocumentView   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     Glocal5clr-namespace:WHManager.DesktopUI.Views.DocumentViews       � 	Resources   �� 
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
 ������� "  .���  � �� �� "  .R�� #��z��.+��� $��Center=��� $��Center=���  � ��$ Stretch=���  � ��$ 18(�.���  � RowDefinitions �� $
��auto ��� $��* �	 � ColumnDefinitions	 �� $��* �.+�� $��0��	 �� $	��100 ��� $��* ��� $	��100 �.+�� $��0�� �� $��* ��� $
��auto ��� $
��auto �.+��� -   $��0��$��75��#��[  .��	Wyczyść� $��1�� �� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $��10 �	 �� $��* ��� $��* ��� $��* ��� $��* �.+��� $��0��$��1��ID dokumentu:�� $��2��$��1��$��2��Nazwa dostawcy:�� $��0��$��1��$y�Hidden=�Nazwa dostawcy:�� $��0��$��2��ID zamówienia:�� $��4��$��1��Od:�� $��4��$��2��Do:�� -   $��textBoxDocumentId��$��1��$��1���� -   $��textBoxProviderName��$��3��$��1��$��2���� -   $��textBoxDeliveryId��$��1��$��2���� $��3��$��1��$y�Hidden=�(  "System.Windows.Controls.DatePicker  -   
  Name$
 datePickerEarlierDate��$��1��$��5��  -   $
 datePickerLaterDate��$��2��$��5��� $��2�� �� $
��auto ��� $��* ��� $
��auto �.+��� -   $��1��$��75��#��[  .��
Wyszukaj� $��1�� �� $��* ��� $
��auto �	 �� $��* ��� $
��auto ��� $��* �.+�  -     Name$ gridDocuments��#��[    	CellStyle# [ $��0��$��0��$��3��   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ ID��   Width$ 30 1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *Id+  $ ID zamówienia�� �� *
DeliveryId+  $ Nazwa dostawcy�� �� *Provider.Name+  $ Data złożenia�� �� *DateReceived+ �� StringFormat$ {0:yyyy-MM-dd}��4	  .System.Windows.Controls.DataGridTemplateColumn	  $ 50  	  CellTemplate �� .R��� -	   $��50��#��[  .��	Pobierz