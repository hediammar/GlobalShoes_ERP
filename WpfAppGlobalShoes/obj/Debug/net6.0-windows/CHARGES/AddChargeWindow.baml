   M S B A M L   `   `   `  ����  WpfAppGlobalShoes/    )WpfAppGlobalShoes.CHARGES.AddChargeWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Add New Charge��5   	   $
��Auto��6    $	��400��6.   .��5      � $��10q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5	      $
��Auto �6   �� 5
      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   �� $��Charge Type��6   $��0��6'   $��Center=�64   �� 5   
   -   5         ��Name$ ChargeTypeTextBox��5      $��0��6-   $��	120,0,0,0q�6:   �� 5   
   $��Amount��6   $��1��6"   $��Center=�6/   �� 5   
   -   5        $ AmountTextBox��5      $��1��6)   $��	120,0,0,0q�66   �� 5   
   $��Charge Date��6   $��2��6'   $��Center=�64   (  "System.Windows.Controls.DatePicker  5   
   -   5          Name$ ChargeDatePicker��5      $��2��6/   $��	120,0,0,0q�6<   �� 5   
   $��Description��6   $��3��6'   $��Center=�64   �� 5   
   -   5        $ DescriptionTextBox��5      $��3��6.   $��	120,0,0,0q�6;   �� 5   
   $��Paid Status��6   $��4��6'   $��Center=�64   �� 5   
   -   5         ��Name$ PaidStatusComboBox��5      $��4��6/   $��	120,0,0,0q�6<   .@�5      �� $
��Paid��6   �� 5      $��Pending��6   5       �� 5"   
   $��Due Date��6   $��5��6$   $��Center=�61     5#   
   -   5        $ DueDatePicker��5#      $��5��6,   $��	120,0,0,0q�69   �� 5%   
   $��6��6    �� Orientation$ 
Horizontal=�6"   $��Right=�6;   $��0,10,0,0q�6W   .+�5&      �� -   5        $
��Save��5&      $��20��6$   $	��100��60   6<   �� 5'      -   5        $��Cancel��5'      $	��100��6&   $��10,0,0,0q�62   6D   5(      5)      5*      