   M S B A M L   `   `   `  ����F  BSlotMachine, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:SlotMachineSlotMachine  5   	       SlotMachine.MainWindow   5   	   W SPresentationCore, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:SlotMachine     5   	     � Title$  
MainWindow��5   	   $	��678��6   $
��1200��6)   .��5	      � .+�5   
   �� -   5         ��Name$ explanationText��5   $   $
��30px(�6   $��Center=�6=   $��	0,450,0,0q�6Z   $
��Wrap=�6m   $��	TextBlock��6�   $	��Top=�6�   �� 5   
   -   5         ��Name$ 
RollButton��5      $
��Roll��6%   $��100px��64   $��200px��6C   $��Center=�6Q   $��	0,500,0,0q�6n   $	��Top=�6�   6�   �� 5   
   -   5        $ balanceText��5   $   $
��30px(�6   $
��Left=�69   $��	607,0,0,0q�6T   $
��Wrap=�6g   $��	TextBlock��6{   $	��Top=�6�   $	��193��6�   �� 5   
   
���   �$��3q�6%   $��142,69,513,185q�69   $	��200��6Q   $	��200��6]   ._�5      �� -   5         ��Name$ canvas��5   )   $
}�True��6   .+�5      �� -   5         ��Name$ Reel1��5   ?   $	��Top=�6   
 �� Top$ 0��60   $
��None=�6N   $��	1,-1,-1,1q�6_   5      5      �� 5   
   
���   �$��3q�6%   $��328,69,328,185q�69   $	��200��6Q   $	��200��6]   ._�5      �� -   5        $ canvas1��5   )   $
}�True��6   .+�5      �� -   5        $ Reel2��5   @   $	��Top=�6   $ 0��61   $
��None=�6O   $��	1,-1,-1,1q�6^   5      5      �� 5   
   
���   �$��3q�6%   $��513,69,142,185q�69   $	��200��6Q   $	��200��6]   ._�5      �� -   5        $ canvas2��5   )   $
}�True��6   .+�5      �� -	   5        $ Reel3��5   @   $	��Top=�6   $ 0��61   $
��None=�6O   $��	1,-1,-1,1q�6^   5      5!      �� 5#   
   -
   5        $ betSizeText��5#   =   $
��18px(�6   $��Current Betsize: ��6$   $
��Left=�6S   $��	15,10,0,0q�6n   $
��Wrap=�6�   $	��Top=�6�   �� 5$   
   -   5        $ IncreaseBet��5$      $��+��6&   $
��Left=�62   $��	35,40,0,0q�6M   $	��Top=�6`   $��30��6x   $��30��6�   6�   �� 5%   
   -   5        $ DecreaseBet��5%      $��-��6&   $
��Left=�62   $��	70,40,0,0q�6M   $	��Top=�6`   $��30��6x   $��30��6�   6�   5(      5)      