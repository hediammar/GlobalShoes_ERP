   M S B A M L   `   `   `  ����  WpfAppGlobalShoes#    WpfAppGlobalShoes.LoginWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   X TXceed.Wpf.Toolkit, Version=4.6.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5   	     � Title$  Login��5   	   $
��1080��6   $
��1920��6%    � 	Resources 5         FadeOutStoryboard �� TargetProperty W� From	 W� To g� Duration��%t   &	        �� 5	   
   .��5
      W� $ Opacity�6    1.05       0.06)   $ 0:0:1D�62   5      5      .��5      � -   5        $��	LoginGrid��5      ��5   
   �� 5       �� ImageSource$9 3pack://application:,,,/Images/login_background3.jpg��6    j� Stretch$ UniformToFill=�6[   .+�5   
   �� $.��(pack://application:,,,/Images/GSLogo.png��6   $��70��6B   $��50q�6N   $	��Top=�6Z   $
��Left=�6r   �� 5   
   
������� �� CornerRadius$ 50��6$   	 �� Padding$	 20q�66   $	��300��6C   $	��400��6O   $��Center=�5      $��Center=�6,   
 J� Effect
 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         
BlurRadius$ 10Q�6#      ShadowDepth$ 5Q�63      Opacity$	 0.5Q�6C   ._�5       �� $��Center=�6   $��Center=�64   $	��400��6Q   $	��300��6^   .+�5!      �� $��Welcome Back��6   $��30(�60   $��Calibri)�6>   $��50q�6S   $��Center=�6_   ���	#FF481D4B$
��Bold"�6�   �� 5#      
�������$ 10��6,   ���#CCCCCC$��1q�6T   $��
50,0,50,50q�6h   ._�5$      (  "Xceed.Wpf.Toolkit.WatermarkTextBox  -   5        $��UsernameTextBox��5$   ,   $��20(�6C      	Watermark$ Username��6Q   $��50��5%   ,   $��5q�68   5&      �� 5(      
�������$ 10��6,   ���#CCCCCC$��1q�6T   $��	50,0,50,0q�6h   ._�5)      ,  &Xceed.Wpf.Toolkit.WatermarkPasswordBox  -   5        $��PasswordBox��5)   0   $��20(�6C   $ Password��6Q   $��50��5*   0   $��5q�6<   5+      �� 5-      -   5        $��Login��5-      $��50��6C   ���	#FF471C4D
�������$��30q�5.   C   $��5q�6O   $��Calibri)�6[   $��30(�6p   $
��Bold"�6~   ��5/      �� 50       �� 
TargetType" ��6    .�51      ��  �� Property � �� �� Value
 ���� 6<   �� 52       � ��$ 0q�6@   �� 53       �@�Cursor$
 Hand��67   �� 54       � �� 55   "   �� 56   &    �� 
TargetType" ��66   .R�57   *   �� #��z��61   $ 10��58   1   ._�5:   .   �� $��Center=�6?   $��Center=�5;   ?   5<   +   5=   '   5?       �� Triggers 5@      P� 5A   "    P� Property �@J�IsMouseOver P� Value$
 True��6A   . �5B   &   ��  � �� �#005F996C   5C   #   5E      5G      5H      5I      5J      5K      