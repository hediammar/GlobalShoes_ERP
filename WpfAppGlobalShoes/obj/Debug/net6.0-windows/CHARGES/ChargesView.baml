   M S B A M L   `   `   `  ����  WpfAppGlobalShoes+    %WpfAppGlobalShoes.CHARGES.ChargesView   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      -   5          >�Name$  ChargesViewControl��5      .��5      �� 
������ .+�5   
   �� $��Filter by Charge Type:��6   �� 5   
   -   5         ��Name$ ChargeTypeComboBox��5      .@�5      �� $	��All��6   �� 5	      $��Electricity Bill��6   �� 5
      $��Water��6   �� 5      $��	Materials��6   �� 5      $��Employee Payments��6   5      �� 5   
   $��Sort by:��6   �� 5   
   -   5        $ SortByComboBox��5      .@�5      �� $��Amount Ascending��6   �� 5      $��Amount Descending��6   �� 5      $��Date Ascending��6   �� 5      $��Date Descending��6   5      &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ ChargesDataGrid��5         AutoGenerateColumns$ False��6,      CanUserAddRows$ False��6H   $
��auto��6_      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ 	Charge ID��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 68   �� *
ChargeID+  5      $ Charge Type��6%    6:   �� *
ChargeType+  5      $ Amount��6%    65   �� *Amount+  5      $ Charge Date��6%    6:   �� *
ChargeDate+  5      $ Description��6%    6:   �� *Description+  5      $ Paid Status��6%    6:   �� *
PaidStatus+  5      $ Due Date��6%    67   �� *	DueDate+  5       $ Payment Date��6%    6;   �� *PaymentDate+5"      �� 5$   
   $��Right=�6    �� Orientation$ 
Horizontal=�62   $��	0,10,0,10q�6K   .+�5%      �� -   5        $��
Add Charge��5%      6*   �� 5&      -   5        $��Edit Charge��5&      $��5,0,0,0q�6J   �� 5'      -   5        $��Delete Charge��5'      $��5,0,0,0q�6N   5(      5)      5*      