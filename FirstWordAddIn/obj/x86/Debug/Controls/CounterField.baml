   M S B A M L   `   `   `  ����I  EFirstWordAddIn, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:Regy2.ControlsRegy2.Controls  5      !    Regy2.Controls.CounterField   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .localclr-namespace:Regy2.Controls     5      -   5          >�Name$  uc��5       � 	Resources 5	         ComboBox.Static.Background �� EndPoint �� 
StartPoint � Color � Offset  ComboBox.Static.Border �� Color  ComboBox.Static.Glyph ' #ComboBox.Static.Editable.Background # ComboBox.Static.Editable.Border . *ComboBox.Static.Editable.Button.Background * &ComboBox.Static.Editable.Button.Border ! ComboBox.MouseOver.Background  ComboBox.MouseOver.Border 	 ComboBox.MouseOver.Glyph *
 &ComboBox.MouseOver.Editable.Background & "ComboBox.MouseOver.Editable.Border 1 -ComboBox.MouseOver.Editable.Button.Background - )ComboBox.MouseOver.Editable.Button.Border  ComboBox.Pressed.Background  ComboBox.Pressed.Border  ComboBox.Pressed.Glyph ( $ComboBox.Pressed.Editable.Background $  ComboBox.Pressed.Editable.Border / +ComboBox.Pressed.Editable.Button.Background + 'ComboBox.Pressed.Editable.Button.Border   ComboBox.Disabled.Background  ComboBox.Disabled.Border  ComboBox.Disabled.Glyph ) %ComboBox.Disabled.Editable.Background % !ComboBox.Disabled.Editable.Border 0 ,ComboBox.Disabled.Editable.Button.Background , (ComboBox.Disabled.Editable.Button.Border  ComboBoxToggleButton �� 
TargetType �� Property	 �� Value
 �� 
TargetType ��Name J� SnapsToDevicePixels F�Name �� Triggers ^� 
Conditions �� Binding �� RelativeSource �� AncestorType �� Value �� 
TargetName P� Property P� Value  RegyComboBox �Name � ColumnDefinitions �Name � AllowsTransparency �� Mode ��Name �� ClearTypeHint ��Name ��Name  �� ElementName! ��Name-  'System.Windows.Input.KeyboardNavigation"   DirectionalNavigation# d�Name$ d� 	IsChecked% ��Name& �� SelectionBoxItemTemplate' �� SelectionBoxItem#( �� SelectionBoxItemStringFormat) �� ContentStringFormat* J� IsHitTestVisible+ ]� 
Conditions, �� Property- P� 
SourceName��%+  &	        &	 �     &	 �     &	 �     &	     &	 (    &	 M    &	 r    &	     &		 1    &	
 T    &	 w    &	 �    &	 6    &	 Y    &	 �    &	     &	 ;    &	 ^    &	 �    &	     &	 @    &	 c    &	 �    &	 �    &	 �    &	 �    &	     &	 9    7  7  7  7  7  7  7 	 7  7  7 
 7  7  7  7  7  7  7  7  7  7  7  7  7  7  7  7  7  &	 ]    7  �� 5
      $	 0,1&�6;   $	 0,0&�6J   .��5      � $ 	#FFF0F0F0��6   $	 0.0Q�6$   � 5      $ 	#FFE5E5E5��6   $	 1.0Q�6$   5      �� 5      $ 	#FFACACAC��63   �� 5      $ 	#FF606060��62   �� 5      $ 	#FFFFFFFF��6@   �� 5      $ 	#FFABADB3��6<   �� 5      $ Transparent��6G   �� 5      $ Transparent��6C   �� 5      $	 0,1&�6>   $	 0,0&�6M   .��5      � $ 	#FFECF4FC��6   $	 0.0Q�6$   � 5      $ 	#FFDCECFC��6   $	 1.0Q�6$   5      �� 5      $ 	#FF7EB4EA��66   �� 5      $ 	#FF000000��65   �� 5      $ 	#FFFFFFFF��6C   �� 5      $ 	#FF7EB4EA��6?   �� 5      $	 0,1&�6N   $	 0,0&�6]   .��5      � $ 	#FFEBF4FC��6   $	 0.0Q�6$   � 5      $ 	#FFDCECFC��6   $	 1.0Q�6$   5      �� 5       $ 	#FF7EB4EA��6F   �� 5!      $	 0,1&�6<   $	 0,0&�6K   .��5"      � $ 	#FFDAECFC��6   $	 0.0Q�6$   � 5#      $ 	#FFC4E0FC��6   $	 1.0Q�6$   5$      �� 5%      $ 	#FF569DE5��64   �� 5&      $ 	#FF000000��63   �� 5'      $ 	#FFFFFFFF��6A   �� 5(      $ 	#FF569DE5��6=   �� 5)      $	 0,1&�6L   $	 0,0&�6[   .��5*      � $ 	#FFDAEBFC��6   $	 0.0Q�6$   � 5+      $ 	#FFC4E0FC��6   $	 1.0Q�6$   5,      �� 5-      $ 	#FF569DE5��6D   �� 5.      $ 	#FFF0F0F0��69   �� 5/      $ 	#FFD9D9D9��65   �� 50      $ 	#FFBFBFBF��64   �� 51      $ 	#FFFFFFFF��6B   �� 52      $ 	#FFBFBFBF��6>   �� 53      $ Transparent��6I   �� 54      $ Transparent��6E   �� 55      " d�6'   .�56      ��  �@�OverridesDefaultStyle	 . 6-   �� 57       � ��	 .  6!   �� 58       � |�	 .  6!   �� 59       �@��	ClickMode$	 Press=�6!   �� 5:       � ��	 5;      �� 5<      "
 d�6   .R�5=      �� $ templateRoot��6   
�������#��z��68   8��   . ._�5>   	   �� $ splitBorder��6   $��1q�6%   
������ $��Right=�6S   $��0q�6o    . #��� r�6�   ._�5?   
   F� $ arrow��6   F����        ���( ��( јaQ     јaQ P����̰( � �    P����        8�� $��Center=�6�   $��0q�6�   $��Center=�6�   5@   
   5A   	    5B      ^� 5C   	    5D   
   �� 5E       6   �� *
IsEditable+ �� " �� true6t   �� 5F       6   �� *IsMouseOver+ �� *Self+	 false6[   �� 5G       6   �� *	IsPressed+ �� *Self+	 false6Y   �� 5H       6   �� *	IsEnabled+ �� *Self+ true6Y   .0�5J   
   �� $ templateRoot��6'   8	   � ��6A   �� 5K   
   $ templateRoot��6(   8	   � ��6B   �� 5L   
   $ splitBorder��6'   8	   � ��6@   �� 5M   
   $ splitBorder��6(   8	   � ��6A   5N   
   P� 5O   	    �@J�IsMouseOver . . �5P   
   �� $ arrow��6!   8	   � ��64   5Q   
   ^� 5R   	    5S   
   �� 5T       6   �� *IsMouseOver+ �� *Self+ true6[   �� 5U       6   �� *
IsEditable+ �� " ��	 false6t   .0�5W   
   �� $ templateRoot��6'   8	   � ��6A   �� 5X   
   $ templateRoot��6(   8	   � ��6B   5Y   
   ^� 5Z   	    5[   
   �� 5\       6   �� *IsMouseOver+ �� *Self+ true6[   �� 5]       6   �� *
IsEditable+ �� " �� true6t   .0�5_   
   �� $ templateRoot��6'   8	 	  � ��6A   �� 5`   
   $ templateRoot��6(   8	 
  � ��6B   �� 5a   
   $ splitBorder��6'   8	   � ��6@   �� 5b   
   $ splitBorder��6(   8	   � ��6A   5c   
   P� 5d   	    � �� . . �5e   
   �� $ arrow��6!   8	   � ��64   5f   
   ^� 5g   	    5h   
   �� 5i       6   �� *	IsPressed+ �� *Self+ true6Y   �� 5j       6   �� *
IsEditable+ �� " ��	 false6t   .0�5l   
   �� $ templateRoot��6'   8	   � ��6A   �� 5m   
   $ templateRoot��6(   8	   � ��6B   5n   
   ^� 5o   	    5p   
   �� 5q       6   �� *	IsPressed+ �� *Self+ true6Y   �� 5r       6   �� *
IsEditable+ �� " �� true6t   .0�5t   
   �� $ templateRoot��6'   8	   � ��6A   �� 5u   
   $ templateRoot��6(   8	   � ��6B   �� 5v   
   $ splitBorder��6'   8	   � ��6@   �� 5w   
   $ splitBorder��6(   8	   � ��6A   5x   
   P� 5y   	    � {� .  . �5z   
   �� $ arrow��6!   8	   � ��64   5{   
   ^� 5|   	    5}   
   �� 5~       6   �� *	IsEnabled+ �� *Self+	 false6Y   �� 5       6   �� *
IsEditable+ �� " ��	 false6t   .0�5�   
   �� $ templateRoot��6'   8	   � ��6A   �� 5�   
   $ templateRoot��6(   8	   � ��6B   5�   
   ^� 5�   	    5�   
   �� 5�       6   �� *	IsEnabled+ �� *Self+	 false6Y   �� 5�       6   �� *
IsEditable+ �� " �� true6t   .0�5�   
   �� $ templateRoot��6'   8	   � ��6A   �� 5�   
   $ templateRoot��6(   8	   � ��6B   �� 5�   
   $ splitBorder��6'   8	   � ��6@   �� 5�   
   $ splitBorder��6(   8	   � ��6A   5�   
   5�      5�      5�      �� 5�      "
 ��6)   .R�5�      � $ templateRoot��6
    .  5�      �� 5�      $��* �6   �� 5�      #��� r�6   $��0 �6k   .+�5�      � $ 
PART_Popup��6    . $��2��6:   $��1q�6�   $��Bottom=�6�   #��� .�6�   ��6N   �� *IsDropDownOpen+$ TwoWay=� �� *TemplatedParent+.��5�      �� $ dropDownBorder��6   #��� ��6&   $��1q�6l   #��� ��6�   ._�5�      �� $ DropDownScrollViewer��6   .��5�   	   � $
 grid��6   $ Enabled=�6   .+�5�   
   �� $ canvas��6   $
��Left=�6!   $��0��6<   $	��Top=�6G   $��0��6_   .+�5�      �� $ 
opaqueRect��6   ��6)   �� *
Background+$  dropDownBorder����6a   �� *ActualHeight+$  dropDownBorder����6�   �� *ActualWidth+$  dropDownBorder��5�      �� 5�   
   $! ItemsPresenter��6   $" 	Contained=�61   # z 6f   5�   
   5�   	   5�      5�      d� 5�      $# toggleButton��6   #��z��6)   #��z��6S   #��z��6�   $��2��6�   8��  $ 6�   �� *IsDropDownOpen+$ TwoWay=� �� *TemplatedParent+6*  �� 5�      $% contentPresenter��6   #��z& 61   #��z' 6n   #��z��6�   #) z( 6�   #��z��6!  * .  #��z��6}  # z 6�  #��z��6�  5�       5�      P� 5�       �@��HasItems .  . �5�      �� $ dropDownBorder��6     � ��$	 95��6<   5�      ]� 5�      + 5�      �� 5�      , �@��
IsGrouping . 6(   �� 5�      ", �@%�IsVirtualizingWhenGrouping .  6J   ./�5�      ��  � ��	 .  67   5�      P� 5�      $- DropDownScrollViewer��67    � �� .  . �5�      �� $ 
opaqueRect��6$   	 6<   �� *VerticalOffset+$  DropDownScrollViewer�� �@��Top�� 5�      $ 
opaqueRect��6%   	 6=   �� *HorizontalOffset+$  DropDownScrollViewer�� �@��Left5�      5�      5�      .��5�      �� -   5        . ��Name$. panel��5�      6   5�      