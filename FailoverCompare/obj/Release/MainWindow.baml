   M S B A M L   `   `   `  ����   VibeStatusCompare"    VibeStatusCompare.MainWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Edxe5http://schemas.devexpress.com/winfx/2008/xaml/editors       � Title$  Vibe Status Compare�� � UseLayoutRounding . $��Stretch=�$��Stretch=�$��Calibri)� � Topmost .  � WindowStartupLocation$ CenterScreen=� � Icon$ Vibe_logo.ico��.��� -    �Name$ MainGrid�� � RowDefinitions �� �� $��60 �.+��� $��5��$��Stretch=�$��0q�$	��Top=� �� ResizeDirection$
 Rows=� �� ShowsPreview . $��1��� -   $ 	ChildGrid��$��0��	 � ColumnDefinitions	 �� �� .+��� $��5��$
��Left=�$��0q�$��Stretch=�$ Columns=� . $��1��� -   $ OriginalContainer��$��0q�$��0�� �� $��22 ��� $��22 ��� $��22 ��� .+��� $��Source URL : ��$��Right=�$
��Left=�$��9,0.4,0,0.4q�$��0��$��93��$��Center=�$��15��$��Center=�$��0q�$��Calibri)��� -   
 ��Name$
 SouceURL�� �� TextWrapping$
 Wrap=�$��0��$��114,4,9.8,3.4q�$��0q�$��Calibri)�$��Center=��� $��
User ID : ��$��Right=�$
��Left=�$��9,2.6,0,4.8q�$��1��$��93��$��Center=�$��15��$��Center=�$��0q�$��Calibri)��� -   $
 UserID��$
 Wrap=�$��1��$��114,2.6,128.8,4.8q�$��0q�$��Calibri)�$��Center=��� $��Password : ��$��Right=�$
��Left=�$��9,2.2,0,5.2q�$��2��$��93��$��Center=�$��15��$��Center=�$��0q�$��Calibri)�G� -    G�Name$ Password��$��2��$��114,2.2,128.8,5.2q�$��0q�$��Calibri)�$��Center=�&   System.Windows.Controls.DataGrid  -     Name$ SourceDataGrid��   HeadersVisibility$	 All=�$��0q�$��3��   CanUserAddRows .     CanUserDeleteRows .     
IsReadOnly .    RowStyle ��  �� 
TargetType)  #System.Windows.Controls.DataGridRow"   �� Triggers ��  �� Binding �� *Error+ �� Value True.a���  �� Property � �� �� Value
 �  ����  �� *Error+	 False.a���  � ��
 ������� -   $��OriginalLoad��$
��Load��$��2��$��Right=�$��75��$��0,4.2,9.8,0.2q�� -	   $ TargetContainer_Copy��$��5.2,0,-5.4,-0.4q�$��1�� �� $��22 ��� $��22 ��� $��22 ��� .+��� $��Source URL : ��$��Right=�$
��Left=�$��9,0.4,0,0.4q�$��0��$��93��$��Center=�$��15��$��Center=�$��0q�$��Calibri)��� -
   $
 	targetURL��$
 Wrap=�$��0��$��114,4,9.8,3.4q�$��0q�$��Calibri)�$��Center=��� $��
User ID : ��$��Right=�$
��Left=�$��9,2.6,0,4.8q�$��1��$��93��$��Center=�$��15��$��Center=�$��0q�$��Calibri)��� -   $
 targetUserID��$
 Wrap=�$��1��$��114,2.6,128.8,4.8q�$��0q�$��Calibri)�$��Center=��� $��Password : ��$��Right=�$
��Left=�$��9,2.2,0,5.2q�$��2��$��93��$��Center=�$��15��$��Center=�$��0q�$��Calibri)�G� -   $ targetPassword��$��2��$��114,2.2,128.8,5.2q�$��0q�$��Calibri)�$��Center=�  -   $ TargetDataGrid��$��0q�$��3�� .   .   .  �� "   ��  �� *Error+ True.a���  � ��
 �  ����  �� *Error+	 False.a���  � ��
 ������� -   $��
TargetLoad��$��Load & Compare��$��Right=�$��2��$	��Top=�$��90��$��
0,5.2,10,0q�{�.    -   $��messageGrid��$��1��$��0,4,-0.4,-0.4q�