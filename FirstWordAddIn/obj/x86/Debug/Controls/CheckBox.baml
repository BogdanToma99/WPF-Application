   M S B A M L   `   `   `  ����I  EFirstWordAddIn, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:Regy2.ControlsRegy2.Controls  5          Regy2.Controls.CheckBox   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .localclr-namespace:Regy2.Controls     5      -   5          >�Name$  uc��5       � 	Resources 5	         RegyCheckStyle �� 
TargetType �� BasedOn �� Property �� Value �� 
TargetType � ColumnDefinitions ��Name	 �� CornerRadius
 ��Name J� Opacity �� Triggers P� Property P� Value �� 
TargetName��%,  &	        7���� 5
      " ��6!   8   .�5      ��  � �� 5      �� 5      " ��6   .R�5      �  5   	   �� 5   
   $
��Auto �6   6*   �� 5   
   6   .+�5   	   �� $ TriggerBorder��6   ���#85A5C8
������ $��16��5   	   $��16��5   	   $��1,1,6,1q�5   	   $	 3��5   	   $��1q�5   	   ._�5   
   �� $
 TriggerImage��6   $��0��5   
   $
��10.5��5   
   $��8��5   
   $��../Resources/tick.png��5   
   $ 0Q�5    
   5!   
   �� 5"   	   $��1��5#   	   $��
0, 0, 0, 0q�5$   	   $
��Left=�5%   	   $��Roboto)�5&   	   $��16(�5'   	   5(   
   5)   	    5*      P� 5+   	    �@d�	IsChecked$
 TrueY�6&   . �5,   
   �� $ TriggerBorder��6'    � �� �#85A5C86B   �� 5-   
   $ TriggerImage��6$    �@J�Opacity$ 1Q�6>   5.   
   P� 5/   	    �@d�	IsChecked$ FalseY�6&   . �50   
   �� $ TriggerBorder��6'    � ��
 ���� 6B   �� 51   
   $ TriggerImage��6$    �@J�Opacity$ 0Q�6>   52   
   54      56      57      58      .��59      �� #���   5<      ��5:      ��  �� Path$ CheckedCommand� �� ElementName$ uc����5;      �� $ IdStr�$ uc����5=      �� $ TextStr� �� Mode$ TwoWay=�$ uc�� �� UpdateSourceTrigger$ PropertyChanged=�5>      5?      