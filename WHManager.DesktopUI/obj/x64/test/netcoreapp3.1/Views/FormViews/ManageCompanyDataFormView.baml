   M S B A M L   `   `   `  ���� N  JWHManager.DesktopUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullY1clr-namespace:WHManager.DesktopUI.Views.FormViews#WHManager.DesktopUI.Views.FormViews  C    =WHManager.DesktopUI.Views.FormViews.ManageCompanyDataFormView   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     Clocal1clr-namespace:WHManager.DesktopUI.Views.FormViews       � Title$   �� � SizeToContent$ WidthAndHeight=� � 
ResizeMode$ NoResize=� � WindowStyle$
 None=� � 	Resources  �� 
TargetType �� Property �� Value   ButtonStyle �� 
TargetType	 �� Triggers
 P� Property P� Value��%  '��       &	  �     �� " ��.���  � �� �#1976d2��  � ��
 �������  � ��$ Stretch=���  �@��TextAlignment$ Center=��� " ��.���  �@�OverridesDefaultStyle$
 True����  �@�Cursor$ Arrow����  � ��$ 30����  � �� �#1565c0��  � ��
 �������  � ��$ 16(���  � �� �� " ��.R��� $��border��$��0q�
���   �#��z��._��� $��Center=�$��Center=�	 P� 
 �@J�IsMouseOver$
 True��. ���  � ��
 �����.���  � ColumnDefinitions �� $��* ��� $
��auto ��� $��* � � RowDefinitions �� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $��* �.+��� -    ��Name$ textBlockManageClient��$��3��$��0��$��30��$��18(�Edytuj dane firmy�� $��0��$��3��$��1��Nazwa firmy�� -   $��textBoxCompanyName��$��0��$��3��$��2���� $��0��$��3��$��3��Numer telefonu firmy�� -   $��textBoxCompanyPhoneNumber��$��0��$��3��$��4���� $��0��$��3��$��5��	NIP firmy�� -   $��textBoxCompanyNip��$��0��$��6���� -    ��Name$ buttonCancel��$��0��$��7��$	��150��#��[  .��Anuluj�� $��7��$��1�� �� Orientation$ 
Horizontal=�.+��� #��["��� -   $ buttonConfirm��$��2��$��7��$	��150��#��[  .��
Zatwierdź