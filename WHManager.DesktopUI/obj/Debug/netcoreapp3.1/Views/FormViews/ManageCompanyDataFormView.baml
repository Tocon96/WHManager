   M S B A M L   `   `   `  ����N  JWHManager.DesktopUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullY1clr-namespace:WHManager.DesktopUI.Views.FormViews#WHManager.DesktopUI.Views.FormViews  5   	   C    =WHManager.DesktopUI.Views.FormViews.ManageCompanyDataFormView   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Clocal1clr-namespace:WHManager.DesktopUI.Views.FormViews     5   	     � Title$   ��5   	    � SizeToContent$ WidthAndHeight=�6    � 
ResizeMode$ NoResize=�61    � WindowStyle$
 None=�6G    � 	Resources 5	       �� 
TargetType �� Property �� Value   ButtonStyle �� 
TargetType	 �� Triggers
 P� Property P� Value��%U  '��       &	  �     �� 5
   
   " ��6   .�5      ��  � �� �#1976d26+   �� 5       � ��
 �����6+   �� 5       � ��$ Stretch=�64   �� 5       �@��TextAlignment$ Center=�6.   6?   5      �� 5   
   " ��6$   .�5      ��  �@�OverridesDefaultStyle$
 True��66   �� 5       �@�Cursor$ Arrow��6'   �� 5       � ��$ 30��6'   �� 5       � �� �#1565c06+   �� 5       � ��
 �����6+   �� 5       � ��$ 16(�6)   �� 5       � �� 5      �� 5      " ��6&   .R�5      �� $��border��6!   $��0q�6/   
���   �#��z��6W   ._�5      �� $��Center=�6/   $��Center=�6L   5      	 5      P� 5      
 �@J�IsMouseOver$
 True��6=   . �5   "   ��  � ��
 �����6?   5       5"      5$      5%      5&      .��5'      �  � ColumnDefinitions 5(   
   �� 5)      $��* �6   6+   �� 5*      $
��auto �6   6.   �� 5+      $��* �6   6+    � RowDefinitions 5-   
   �� 5.      $
��auto �6   6,   �� 5/      $
��auto �6   6,   �� 50      $
��auto �6   6,   �� 51      $
��auto �6   6,   �� 52      $
��auto �6   6,   �� 53      $
��auto �6   6,   �� 54      $
��auto �6   6,   �� 55      $��* �6   6)   .+�59   
   �� -   5         ��Name$ textBlockManageClient��59      $��3��63   $��0��6G   $��30��6T   $��18(�6`   Edytuj dane firmy6�   �� 5:   
   $��0��6   $��3��6$   $��1��68   Nazwa firmy6R   �� 5;   
   -   5        $��textBoxCompanyName��5;   C   $��0��6   $��3��6"   $��2��66   6_   �� 5<   
   $��0��6   $��3��6$   $��3��68   Numer telefonu firmy6[   �� 5=   
   -   5        $��textBoxCompanyPhoneNumber��5=   C   $��0��6   $��3��6"   $��4��66   6f   �� 5>   
   $��0��6   $��3��6$   $��5��68   	NIP firmy6P   �� 5?   
   -   5        $��textBoxCompanyNip��5?   C   $��0��6   $��3��6"   $��6��66   6^   �� 5A   
   -   5         ��Name$ buttonCancel��5A      $��0��6;   $��7��6K   $	��150��6X   #��[  6d   .��6�   Anuluj6�   �� 5B   
   $��7��6   $��1��6"    �� Orientation$ 
Horizontal=�62   .+�5C      �� #��["�6   5D      �� 5E   
   -   5        $ buttonConfirm��5E      $��2��6C   $��7��6S   $	��150��6`   #��[  6l   .��6�   
Zatwierdź6�   5F      5G      