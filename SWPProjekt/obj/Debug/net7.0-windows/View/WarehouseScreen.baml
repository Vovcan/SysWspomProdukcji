   M S B A M L   `   `   `  ����E  ASWPProjekt, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:SWPProjekt.ViewSWPProjekt.View  5      ;"clr-namespace:SWPProjekt.ViewModelSWPProjekt.ViewModel  5      7 clr-namespace:SWPProjekt.HelpersSWPProjekt.Helpers  5      %    SWPProjekt.View.WarehouseScreen   5      W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      /localclr-namespace:SWPProjekt.View     5      8	viewModel"clr-namespace:SWPProjekt.ViewModel     5      4helpers clr-namespace:SWPProjekt.Helpers     5        � 	Resources  5      )   #SWPProjekt.Helpers.DataContextProxy   DataContextProxy   
DataSource  BooleanToVisibility��%C   &	        &	        5   
    6<   �� �� 5   
   6'   5      .��5      �   5   
    �� 
TargetType �� Property �� Value��%�   '��       '�� Q     �� 5      " ��6   .�5      ��  � ��$ 10,10,10,10q�6+   5      �� 5      " ��6   .�5      ��  � ��
 �����60   �� 5       � ��$ 	0,0,0,0.5q�64   5      5      .+�5   
   �� $��Right=�6   .+�5      �� $	��128��6   $��32��6!   
������$��	+ Dostawa��6F   $��5q�6Z   ��5      �� *CreateNewDelivery+��6;   �� *ButtonDeliveryBackground+��6k   �� *TextDeliveryForeground+�� 5      $	��128��6   $��32��6!   
������$��+ Jednostka��5   .   $��5q�6D   ��5   -   �� *ButtonUnitBackground+��6Y   �� *TextUnitForeground+��5   O   �� *CreateNewUnit+�� 5      $��50��6@    �� 	MaxLength$ 50��6N   $��5q�6]   $	��128��5   `   y�5      �� *UnitFormVisibility+��5      �� *	NewUnit+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�6`   5       �� 5!   
   $	��Top=�6   $
��Left=�6.    �� Orientation$ 
Horizontal=�6I   .+�5"      �� $��Lista magazynów > ��6   $	��Top=�62   $
��Left=�6J   6g   �� 5#      ��6   �� *CurrentWarehouse.Name+5$      �� 5%   
   $	��Top=�6   $
��Left=�6-   $ Vertical=�6H   $
��1103��6_   $��0,43,0,0q�6l   .+�5&      �� ._�5'      �� $ 
Horizontal=�6   .+�5(      �� $��Nazwa : ��6   $	��Top=�6-   $
��Left=�6E   6c   �� 5)      $	��Top=�6E   $
��Left=�6]   ��6   �� *CurrentWarehouse.Name+6{   5*      5+      �� 5,      ._�5-      �� $ 
Horizontal=�6   .+�5.      �� $
��Id: ��6   $	��Top=�6)   $
��Left=�6A   6_   �� 5/      $	��Top=�6D   $
��Left=�6\   ��6   �� *CurrentWarehouse.Id+6z   50      51      �� 52      ._�53      �� $ 
Horizontal=�6   .+�54      �� $��Adres: ��6   $	��Top=�6,   $
��Left=�6D   6a   �� 55      $	��Top=�6H   $
��Left=�6`   ��6   �� *CurrentWarehouse.Address+6~   56      57      �� 58      ._�59      �� $ 
Horizontal=�6   .+�5:      �� $��Kod pocztowy: ��6   $	��Top=�62   $
��Left=�6J   6h   �� 5;      $	��Top=�6E   $
��Left=�6]   ��6   �� *CurrentWarehouse.Zip+6{   5<      5=      �� 5>      ._�5?      �� $ 
Horizontal=�6   .+�5@      �� $��	Zajęty: ��6    $	��Top=�62   $
��Left=�6J   6h   �� 5A      $	��Top=�6"   $
��Left=�6:   ��5B      �� 5C      " ��6$   	 �� Triggers	 5D   "   �� 5E   &   
 �� Binding
 62   �� *CurrentWarehouse.Full+ �� Value 06\   .a�5F   *   ��  � ��$	 nie��6A   5G   '   �� 5H   &   
 62   �� *CurrentWarehouse.Full+ 16\   .a�5I   *   ��  � ��$	 tak��6A   5J   '   5L      5N      5O      5P      �� 5Q      $ 
Horizontal=�6   .+�5R      �� $��	Surowce: ��6   $	��Top=�6/   $
��Left=�6G   6e   �� 5S      $	��Top=�6   $
��Left=�66   6T   �� 5T      $	��150��6<    �� DisplayMemberPath$
 Name��6K   ��6   �� *
Products+ �� SelectedItem 6d   �� *SelectedProduct+$ PropertyChanged=�5U      �� 5V      ._�5W      �� $ Vertical=�6   $	��520��60   .+�5X      &   System.Windows.Controls.DataGrid     
IsReadOnly$
 True��6      AutoGenerateColumns$ False��6{   $
��1100��6�   ��6.   �� *CombinedDelivery+$ PropertyChanged=���6�   �� *MainModel.FontSize+   Columns 5Y      0  *System.Windows.Controls.DataGridTextColumn  5Z      ,  &System.Windows.Controls.DataGridColumn   Header$ Id��6-      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6P   1  +System.Windows.Controls.DataGridBoundColumn   Binding 69   �� *Id+6P     5[      $ Termin ważności��6-   $ * 6g    6F   �� *DeliveryDate+6g     5\      $ Data dostarczenia��6-   $ * 6k    6H   �� *ExpirationDate+6k     5]      $ 	Producent��6-   $ * 6a    6@   �� *ProducerName+6a     5^      $ Ilość��6-   $ * 6W    6<   �� *Amount+6W     5_      $ Obecna ilość��6-   $ * 6e    6C   �� *CurrentAmount+6e     5`      $ Pełna cena��6-   $ * 6_    6A   �� *	FullPrice+6_     5a      $ 	Jednostka��6-   $ * 6]    6@   �� *
UnitName+6]   5c      �� 5d      $ 
Horizontal=�6   y�66   �� *StackPanelVisibility+.+�5e      �� $	��150��6    6.   (  "System.Windows.Controls.DatePicker  5f      $	��120��6!      SelectedDate 6-   �� *Newexpirationdate+$ TwoWay=�$ PropertyChanged=��� 5g      $��20��6    6-     5h      $	��120��6!    6-   �� *NewDeliveryDate+$ TwoWay=�$ PropertyChanged=��� 5i      $��20��6    6-   �� 5j      $	��100��6   $ Producer��6R   ��6.   �� *ProductList+ 6o   �� *SelectedProducer+$ PropertyChanged=��� 5k      $��35��6    6-   �� 5l      $��50��6   $ 50��6,   ��6;   �� *	NewAmount+$ TwoWay=�$ PropertyChanged=��� 5m      $	��230��6    6.   �� 5n      $��50��6   $ 50��6,   ��6;   �� *NewFullPrice+$ TwoWay=�$ PropertyChanged=��� 5o      $��70��6    6-   �� 5p      $	��100��6   $
 Name��6L   ��6.   �� *Units+ 6e   �� *SelectedUnit+$ PropertyChanged=�5q      5r      5s      5t      5v      5x      