   M S B A M L   `   `   `  ����B  >Program, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Program.ViewProgram.View  5   	   !    Program.View.DataBaseWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	    vmProgram.ViewModel     5   	   ,localclr-namespace:Program.View     5   	     � DataContext$  vm:DataBaseViewModel.cs��5   	    � Title$ DataBaseWindow��5
   	   $	��450��6    $	��800��6-   .��5      � $��0,91,0,0q�6   .+�5   
   �� $
��Back��6   $
��Left=�6    $	��Top=�6;   $��739,-77,0,0q�6q   ��6S   �� *	ClickBack+6q   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ dataGrid��5         AutoGenerateColumns . ��6@   �� *Items+�� 5   
   $
��Left=�6   $��
11,-79,0,0q�6.   $	��Top=�6B   $	��120��6Z   ��6f   �� *ComboBoxItems+ �� SelectedItem 6�   �� *SelectedComboBoxItem+5      5      