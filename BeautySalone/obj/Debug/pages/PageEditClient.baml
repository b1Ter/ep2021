   M S B A M L   `   `   `  ����G  CBeautySalone, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:BeautySalone.pagesBeautySalone.pages  5      '    !BeautySalone.pages.PageEditClient   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      2local clr-namespace:BeautySalone.pages     5        N� Title$$  Данные о клиенте��5	      .��5      �  � ColumnDefinitions 5   
   �� 5      �� 5       � RowDefinitions 5   
   �� 5      �� 5      $��80 �6   .+�5   
   �� $��0��6   .+�5      A�  A� Columns$ 2��6   $
��Left=�6&   .+�5      ��    Simple_textBlock#��[  6   ID:6K   �� 5      #��[  60   ��6   �� *ID+60   �� 5      #��[  6   First name:6S   �� 5        Simple_TextBox#��[ 5      ��5      �� *	FirstName+5      �� 5      #��[  6   
Last name:6R   �� 5      #��[ 5       ��5      �� *
LastName+5       �� 5"      #��[  6   Patronymic:6S   �� 5#      #��[ 5$      ��5#      �� *
Patronymic+5$      �� 5&      #��[  6   	Birthday:6Q   (  "System.Windows.Controls.DatePicker  5'      $	��190��6      SelectedDate 6)   �� *
Birthday+�� 5)      #��[  6   Registration date:6Z     5*      $	��190��6    6)   �� *RegistrationDate+�� 5,      #��[  6   	E-mail:6O   �� 5-      #��[ 5.      ��5-      �� *Email+5.      �� 50      #��[  6   Gender6N   �� 51      -   5         ��Name$ 	cmbGender��52   3    �� DisplayMemberPath$
 Name��51   ?   $	��190��52      $��46��6'    �� SelectedItem 51      �� *
GenderCode+ �� SelectedValue 6X   �� *
GenderCode+52   3   54      55      �� 56   
   $��1��6   	 �� Orientation$	 Vertical=�57      .+�58      �� -   5        
 ��Name$
 btnChooseImage��58   U     accent_button#��[ 6   $!��Загрузить фото��6<   $	��210��59      $��10q�6!   �� 5:      -   5         ��Name$ clientImage��5:   1   $	��280��6F   $	��280��6R   $��10q�6_   ��6   �� *	PhotoPath+6m   5;      �� 5<   
   $��2��6   $��2��6)   $	 
Horizontal=�5=      $��Center=�6.   $��Center=�6K   .+�5>      �� -   5        $
 	btnCancel��5>      #��[ 6(   $��Cancel��5?   -   $��10q�6>   �� 5@      -   5        $
 btnSave��5@      #��[ 6&   $
��Save��5A   +   $��10q�6:   5B      5C      5D      