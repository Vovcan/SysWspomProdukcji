   M S B A M L   `   `   `  ����E  ASWPProjekt, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:SWPProjekt.ViewSWPProjekt.View  5      7 clr-namespace:SWPProjekt.HelpersSWPProjekt.Helpers  5      !    SWPProjekt.View.HoursScreen   5      W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      /localclr-namespace:SWPProjekt.View     5      4helpers clr-namespace:SWPProjekt.Helpers     5        � 	Resources  5
      )   #SWPProjekt.Helpers.DataContextProxy   DataContextProxy   
DataSource  BooleanToVisibility��%C   &	        &	        5   
    6<   �� �� 5   
   6'   5      .��5      � .+�5   
   �� .+�5      �� $	��Top=�6   $
��Left=�62    �� Orientation$ 
Horizontal=�6M   .+�5      �� $��Ustawienie godzin��6   $��18(�65   $	��Top=�6D   $
��Left=�6\   6y   5      �� 5      $	��Top=�6   $
��Left=�61   .+�5      &   System.Windows.Controls.DataGrid     
IsReadOnly$
 True��6      AutoGenerateColumns$ False��5      $	��712��6]   ��5   -   �� *combinedUsers+ �� UpdateSourceTrigger$ PropertyChanged=���5   5   �� *MainModel.FontSize+   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Imię��6-      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6T   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 6;   �� *Name+6T     5      $ Nazwisko��6-   $ * 6[   	 6?   �� *	Surname+6[     5      $
 Rola��6-   $ * 6[   	 6;   �� *
JobTitleid+6[     5      $ Nazwa zadania��6-   $ * 6b   	 6D   �� *
TaskName+6b   4  .System.Windows.Controls.DataGridTemplateColumn  5      $ Godziny pracy��61   
   CellTemplate
 5      �� 5   "   .R�5   &   �� $��50��6o   ��6.   �� *HoursNumber+$ PropertyChanged=�6o   5   #   5!      5#      5$      5&      �� 5'   
   $��1400,10,0,0q�6   $	��Top=�6*   $
��Left=�6B   $ Vertical=�6]   .+�5(      �� $ Vertical=�6   .+�5)      �� $��Dzisiejsza data: ��6   $��18(�65   $	��Top=�6D   $
��Left=�6\   6y   �� 5*      $��18(�6Q   $	��Top=�6`   $
��Left=�6x   ��6   �� *	TodayDate+ �� StringFormat$ 
yyyy-MM-dd��6�   5+      �� 5,   
   .+�5-      �� $	��128��6   $��32��6%   ���#0078D4$��Zapisz zmiany��6G   $��5q�6_   ���#0078D4��5.      �� *CreateNewWorkingHours+6?   5/      50      51      52      