   M S B A M L   `   `   `  ���� N  JWHManager.DesktopUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullm;clr-namespace:WHManager.DesktopUI.Views.AdministrationViews-WHManager.DesktopUI.Views.AdministrationViews  C    =WHManager.DesktopUI.Views.AdministrationViews.CompanyDataView   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     Mlocal;clr-namespace:WHManager.DesktopUI.Views.AdministrationViews       � 	Resources   �� 
TargetType   BlueBackground �� Property �� Value  WhiteBackground  ButtonStyle �� 
TargetType �� Triggers P� Property P� Value  DataGridStyle&   System.Windows.Controls.DataGrid5  /System.Windows.Controls.DataGridLengthConverter=  7System.Windows.Controls.Primitives.DataGridColumnHeader # Body_Content_DataGrid_Centering*  $System.Windows.Controls.DataGridCell  ButtonsToDisable �� Triggers	 �� Binding
 �� Value��%  &	        &	 \     &	 �     &	     '  �    &	 j    &	 �    �� " ��.���  � �� �#1565c0��  � ��
 �������  � ��$ Stretch=��� " ��.���  � ��
 �������  � ��
 �   ���  � ��$ Stretch=��� " ��.���  �@�OverridesDefaultStyle$
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
��auto ��� $��* � � ColumnDefinitions �� $��* �.+�� $��1�� �� $��* ��� $
��auto � �� $��* ��� $
��auto ��� $��* �.+�� $��0��$��4�� �� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto �.+��� $��0��#��[  Nazwa:�� -   $��textBlockCompanyName��$��1��#��[ �� $��2��#��[  Numer telefonu:�� -   $��textBlockCompanyNumber��$��3��#��[ �� $��4��#��[  NIP:�� -   $��textBlockCompanyNip��$��5��#��[ � $��2��$��10�� �� �� ��  �� �� �� .+��� -   $��0��$��3��$��60��$��1��$	��200��#��[ .��Edytuj