   M S B A M L   `   `   `  ����E  ASWPProjekt, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:SWPProjekt.ViewSWPProjekt.View  5   	   7 clr-namespace:SWPProjekt.HelpersSWPProjekt.Helpers  5   	   ;"clr-namespace:SWPProjekt.ViewModelSWPProjekt.ViewModel  5   	   =#clr-namespace:SWPProjekt.ComponentsSWPProjekt.Components  5	   	       SWPProjekt.View.Login   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:SWPProjekt.View     5   	   4helpers clr-namespace:SWPProjekt.Helpers     5   	   8	viewModel"clr-namespace:SWPProjekt.ViewModel     5   	   :
components#clr-namespace:SWPProjekt.Components     5	   	   _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	      MaterialDesignBody#���   5   
   $��Regular"�5   
   &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5   
      TextRenderingMode$
 Auto=�5   
     MaterialDesignPaper#���  5        MaterialDesignFont#���  5       � Title$ Login��5   	   $	��450��6   $	��800��6$   ��5   
   �� *
FontSize+ � 	Resources 5      )   #SWPProjekt.Helpers.DataContextProxy  DataContextProxy   
DataSource��%&   &	         5   
    6<   �� 5      .��5      � .+�5   
   �� $
��1920��6   $��48��6!   
������$	��Top=�6I   6c   �� 5   
   $��48��6    �� Orientation$ 
Horizontal=�6&   $��Right=�6?   $	��Top=�6[   .+�5      �� $��	Interfejs��6   
�������$��Center=�6<   d� 5      $��16q�6n    d� 	IsChecked 6   �� *InterfaceChecked+��6B   �� *ChangeInterfaceCommand+6n   5      � 5   
   $��0,48,0,0q�6   .+�5      �� ��6   �� *CurrentView+5       5!      5"      