   M S B A M L   `   `   `  ����N  JWHManager.DesktopUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullY1clr-namespace:WHManager.DesktopUI.Views.FormViews#WHManager.DesktopUI.Views.FormViews  5   	   C    =WHManager.DesktopUI.Views.FormViews.ManageProductTypeFormView   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Clocal1clr-namespace:WHManager.DesktopUI.Views.FormViews     5   	     � Title$   ��5   	    � SizeToContent$ WidthAndHeight=�6    � 
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
 �����6?   5       5"      5$      5%      5&      .��5'      �  � RowDefinitions 5(   
   �� 5)      $
��auto �6   6,   �� 5*      $
��auto �6   6,   �� 5+      $
��auto �6   6,   �� 5,      $��* �6   6)    � ColumnDefinitions 5.   
   �� 5/      $��* �6   6+   �� 50      $
��auto �6   6.   �� 51      $��* �6   6+   .+�54   
   �� -   5         ��Name$  textBlockManageProductType��54      $��3��68   $��0��6L   $��30��6Y   $��18(�6e   ���#1565c0Dodaj Nowy Typ Produktu6�   �� 56   
   $��1��6   $��3��6!   Nazwa6<   �� 57   
   -   5         ��Name$ textBoxProductTypeName��57   b   $��2��6   $��3��6   .��6�   Nazwa6�   �� 58   
   -   5        $��3��58      $��0��6   $
��Left=�6.   #��[  6I   $	��150��6n   .��6�   Anuluj6�   �� 59   
   $��13��6   $��1��6#    �� Orientation$ Vertical=�63   .+�5:      �� #��["�6   5;      �� 5<   
   -   5        $��3��5<      $��2��6   $��Right=�6.   #��[  6J   $	��150��6o   .��6�   
Zatwierdź6�   5>      5?      