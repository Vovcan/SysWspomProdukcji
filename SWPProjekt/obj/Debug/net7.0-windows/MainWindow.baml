   M S B A M L   `   `   `  ����E  ASWPProjekt, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:SWPProjekt
SWPProjekt  5   	   1clr-namespace:SWPProjekt.ViewSWPProjekt.View  5   	   7 clr-namespace:SWPProjekt.HelpersSWPProjekt.Helpers  5   	       SWPProjekt.MainWindow   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:SWPProjekt     5   	   2userViewclr-namespace:SWPProjekt.View     5   	   4helpers clr-namespace:SWPProjekt.Helpers     5   	   _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5
   	      MaterialDesignBody#���   5   
   $��Regular"�5   
   &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5   
      TextRenderingMode$
 Auto=�5   
     MaterialDesignPaper#���  5        MaterialDesignFont#���  5       � Title$ 
MainWindow��5   	   $	��450��6   $	��800��6)    � WindowState$ 	Maximized=�5   	   ��5   
   �� *
FontSize+ � 	Resources 5      )   #SWPProjekt.Helpers.DataContextProxy  DataContextProxy   
DataSource��%&   &	         5   
    6<   �� 5      .��5      �  � RowDefinitions 5   
   �� 5      $��40 �6   �� 5      .+�5   
   �� -   5        $��TopBar��5      $��0��6#   
������.+�5       �� 
������  �� Orientation$ 
Horizontal=�62   $��Right=�6K   $��40��6g   .+�5!      �� $��	Interfejs��6   
�������$��Center=�6@   $��17��6[   d� 5"      $��16��6q   $��65��6}    J� RenderTransformOrigin$ 0.608,0.354&�6�   	 d� 	IsChecked	 6   �� *InterfaceChecked+��6F   �� *ChangeInterfaceCommand+6�   �� 5#      $��SettingsScreen��6?   ���#0078D4���#0078D4$��0q�6�   ��6   �� *UpdateViewCommand+.��5$      �� $��20��6   $��20��6'   ��5%      �� 5&      
 �� DecodePixelWidth$	
 300��6*    �� 	UriSource$ /Images/String-icon.png?�6A   5(      5)      �� 5*      $��EmployeeScreen��6?   $��50��6a   $��32��6l   
������ 
������ $��0q�6�   ��6   �� *UpdateViewCommand+.��5+      �� $��20��6   $��20��6'   ��63   �� *ImageSource+5,      5-      5.      � 50   
   $��1��6    � ColumnDefinitions 51      �� 52      $
��Auto �6#   �� 53      $��* �6#   .+�55      �� $
��Auto=�6   .��56      o� $��0��6   ��6#   �� *
FontSize+��58      �� 5:      .R�5;      $�  $� Orientation$ Vertical=�61   5<      .@�5>      �� $ 
Horizontal=�6   .+�5?      �� $��20��6   $��20��6'   ��5@      �� 5A      $	
 300��6*   $ /Images/inbox.png?�6A   5C      m� 5D      $��Lista magazynów��6    m� CommandParameter$ WarehouseList��6^    m� Command 68   �� *UpdateViewCommand+6^   5E      �� 5F      $ 
Horizontal=�6   .+�5G      �� $��20��6   $��20��6'   ��5H      �� 5I      $	
 300��6*   $! /Images/symbol-property.png?�6A   5K      m� 5L      $��	Produkcja��6   $ ProductionList��6X    62   �� *UpdateViewCommand+6X   5M      �� 5N      $ 
Horizontal=�6   .+�5O      �� $��20��6   $��20��6'   ��5P      �� 5Q      $	
 300��6*   $ /Images/Vector.png?�6A   5S      m� 5T      $��Projekty��6   $ ProjectsScreen��6W    61   �� *UpdateViewCommand+6W   5U      �� 5V      $ 
Horizontal=�6   .+�5W      �� $��20��6   $��20��6'   ��5X      �� 5Y      $	
 300��6*   $ /Images/output.png?�6A   5[      m� 5\      $��Lista Zadań��6   $ TasksScreen��6Z    64   �� *UpdateViewCommand+6Z   5]      �� 5^      $ 
Horizontal=�6   .+�5_      �� $��20��6   $��20��6'   ��5`      �� 5a      $	
 300��6*   $ /Images/account.png?�6A   5c      m� 5d      $��Lista pracowników��6   $ EmployeeListScreen��6`    6:   �� *UpdateViewCommand+6`   5e      �� 5f      $ 
Horizontal=�6   .+�5g      �� $��20��6   $��20��6'   ��5h      �� 5i      $	
 300��6*   $ /Images/graph.png?�6A   5k      m� 5l      $��	Sprzedaż��6   $ 
SaleScreen��6W    61   �� *UpdateViewCommand+6W   5m      �� 5n      $ 
Horizontal=�6!   .+�5o      �� $��20��6    $��20��6+   ��5p      �� 5q   "   $	
 300��6.   $ /Images/Union.png?�6E   5s      m� 5t      $��Utracone surowce��6#   $ LostProducts��6c    6=   �� *UpdateViewCommand+6c   5u      �� 5v      $ 
Horizontal=�6!   .+�5w      �� $��20��6   $��20��6'   ��5x      �� 5y      $	
 300��6*   $ /Images/history.png?�6A   5{      m� 5|      $��Ustawienie godzin��6   $ HoursScreen��6`    6:   �� *UpdateViewCommand+6`   5}      �� 5~      $ 
Horizontal=�6   .+�5      �� $��20��6   $��20��6'   ��5�      �� 5�      $	
 300��6*   $ /Images/output.png?�6A   5�      m� 5�      $��Historia godzin pracy��6   $ HistoryHoursScreen��6d    6>   �� *UpdateViewCommand+6d   5�      �� 5�      $ 
Horizontal=�6   .+�5�      �� $��20��6   $��20��6'   ��5�      �� 5�      $	
 300��6*   $ /Images/folder-opened.png?�6A   5�      m� 5�      $��Archiwum��6   $ ArchiveListScreen��6W    61   �� *UpdateViewCommand+6W   5�      �� 5�      $ 
Horizontal=�6   .+�5�      �� $��20��6   $��20��6'   ��5�      �� 5�      $	
 300��6*   $ /Images/skarga.png?�6A   5�      m� 5�      $��Skargi��6   $ ComplaintsListScreen��6U    6/   �� *UpdateViewCommand+6U   5�      5�      5�      � 5�      $��1��6   .+�5�      �� $
��Auto=�6   .��5�      �� ��6!   �� *SelectedViewModel+5�      5�      5�      5�      5�      