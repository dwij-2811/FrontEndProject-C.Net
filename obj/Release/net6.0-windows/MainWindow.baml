   M S B A M L   `   `   `  ���� U  QLiveCharts.Wpf, Version=0.9.7.0, Culture=neutral, PublicKeyToken=0bc1f845d1ebb8dfG4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.WpfLiveCharts.Wpf  E ASoledoutUI, Version=1.0.0.8, Culture=neutral, PublicKeyToken=null'clr-namespace:SoledoutUI
SoledoutUI    SoledoutUI.MainWindow   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QScottPlot.WPF, Version=4.1.45.0, Culture=neutral, PublicKeyToken=e53b06131e34a3aae aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     Dlvc4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.Wpf     *localclr-namespace:SoledoutUI       � WindowStyle$
  None=� � AllowsTransparency$
 True�� � Title$ SoledOut AIO | GUI��$	��780��$
��1520�����	#FF151019
������� � Icon$ /Soledout_Discord.png�� � 
ResizeMode$ NoResize=� � 	Resources    TransparentStyle �� 
TargetType �� Property �� Value	 �� 
TargetType
 �� Triggers P� Property P� Value  TransparentStyle1 :� RoutedEvent �� TargetProperty W� From	 W� To ��Name �� Padding J� SnapsToDevicePixels �� Triggers ]� 
Conditions �� Property �� Value �� 
TargetName ��Name  ComboBoxToggleButton � ColumnDefinitions �� CornerRadius F�Name  ComboBoxTextBox �� 	ClickMode d� 	IsChecked �� Path  �� Mode! �� RelativeSource" J� IsHitTestVisible# �� SelectionBoxItem$ �� SelectionBoxItemTemplate% ��Name& �� 
IsReadOnly' �� 
IsReadOnly( �� IsDropDownOpen) � AllowsTransparency* � ActualWidth+ �� MaxDropDownHeight, K� IsItemsHost-  'System.Windows.Input.KeyboardNavigation-   DirectionalNavigation. P� 
SourceName  ScrollThumbs/ �Name0 � RowDefinitions1 ]�Name2 ]� Thumb3 n�Name4 ]� IncreaseRepeatButton5 ��Name6 J� Opacity7 ]� DecreaseRepeatButton  ButtonSelectBrush  	DarkBrush8 �� Angle��%  &	        &	 �     '�� �    '�� �    &	 �    &	     '�� H    7  7  '�� �    &	 $    '�� t    �� " ��.���  � �� �� "	 ��.R��� ���� " ��
 P�  �@J�IsMouseOver$
 True��. ���  � �� �	#FFAB3C65P�  �@J�	IsFocused$
 True��. ���  � �� �	#FFAB3C65._�� 
������ .+��� �� " ��
 P�  �@J�IsMouseOver$ False��. ���  � �� �	#FF420606��  �@J�Opacity$	 1.0Q�:� $ 
MouseLeave��.[��� .���� .��W� $ Opacity� 0.2 1:� $ 
MouseEnter��.[��� .���� .��W� $ Opacity� 0.2 0.2�� " ��.���  � ��
 ���� ��  � �� �� "	 ��.R��� $ Bd��#��z��#��z��#��z��# z��$
 true��._��� #��z��# z #��z�� P�  �@J�IsMouseCaptured$
 True��. ���  �@��
IsSelected$
 True��P�  �@��
IsSelected$
 true��. ���  � ��
 ���� ��  � ��$
 Bold"�]�  ��  �@��
IsSelected$
 true����  �@��IsSelectionActive$ false��./��� $ Bd�� � ��
 ���� ��  � ��
 ���� P�  � {�$ false��. ��� # � �� � ���� " ��.���  � �� �� "	 ��.R��� $ Border��#��z��#��z��#��z��._��� $ PART_ContentHost��$|�false��$��Hidden=�$��Hidden=� P�  �@J�	IsFocused$
 true��. ��� $ Border�� � ��
 ���� �� "	 d�.R��  �� �� $��20 �.+��� $ Border��$��2��$ 8�����	#FF86274B���	#FFAB3C65$��1q��� $��0��$ 8��$��1q����	#FFAB3C65$��0,0,1,0q���Z� F� $ Arrow��$��1��
���   �$��Center=�$��Center=�=����        �    �� � 	= ��[ � z �� � z     � 	=  	= 	�� "	 ��.R��� $ PART_ContentHost��$|�False��#��z���� " ��.���  �@J�SnapsToDevicePixels$
 true����  �@�OverridesDefaultStyle$
 true����  � ��$
 Auto=���  � ��$
 Auto=���  � ��$
 true����  � ��$ 20����  � ��
 �������  � �� �� "	 ��.R�� .+�d� $��ToggleButton��8��  $��2��$|�false��$ Press=� �� $ IsDropDownOpen�$  TwoWay=�! �� *TemplatedParent+�� $��ContentSite��$" False��#��z# #��z$ #��z��$��3,3,23,3q�$��Center=�$
��Left=��� $% PART_EditableTextBox��8�� $
��Left=�$��Center=�$��3,3,23,3q�$
|�True�����	#FF561B34���	#FF561B34$y�Hidden=�#' z& ��Z� � $��Popup��$��Bottom=�#��z( $
) True��$|�False��$��Slide=�.��� $��DropDown��$
 True��#��z* #��z+ .+��� $ DropDownBorder�����	#FFAB3C65$��1q���Z� �� $��4,6,4,6q�$
 True��.���� $
, True��$- 	Contained=� P�  �@��HasItems$ false��. ��� $ DropDownBorder�� � ��$ 95��P�  � {�$ false��. ���  � ��
 �����P�  �@��
IsGrouping$
 true��. ���  � ��$ false��P� $. Popup�� �@�AllowsTransparency$
 true��. ��� $ DropDownBorder�� �@��CornerRadius$ 8���� $ DropDownBorder�� � ��$ 0,2,0,0q�P�  �@��
IsEditable$
 true��. ���  � ��$ false���� $ PART_EditableTextBox�� � y�$ Visible=��� $ ContentSite�� � y�$ Hidden=�
 �� " ��.���  �@J�SnapsToDevicePixels$
 true����  � ��
 �������  �@�OverridesDefaultStyle$
 true����  � �� �� "	 ��.R��� $��Border��$ 2q�$
 true��._���  P�  �@��IsHighlighted$
 true��. ��� $ Border�� � �� �	#FF4F4F4FP�  � {�$ false��. ���  � �� �#888888�� " n�.���  � �� �� "	 n�.R�� $
/ Grid��.+��� $��Stretch=�$��Stretch=�$
��Auto��$
��Auto��
������ �� $ 
Rectangle1��$ 10��$��Stretch=�$��Stretch=�$
��Auto��$
��Auto��#��z�� P�  �@�Tag$ 
Horizontal��. ��� $ 
Rectangle1�� � ��$
 Auto���� $ 
Rectangle1�� � ��$ 7���� " ��.���  �@��IsFlicksEnabled$ false����  � �� �	#FFAB3C65��  � �� Z� ��  � ��$ 3����  � �� �� "	 ��.R�� $/ GridRoot��$��10��#��z��0 �� $��0.00001* �.+�]� $1 
PART_Track��$��0��$
��true��$|�false��2 n� $3 Thumb��#��z��#���  4 �� $5 PageUp��$��ScrollBar.PageDownCommand��$6 0Q�$|�false��7 �� $5 PageDown��$��ScrollBar.PageUpCommand��$6 0Q�$|�false�� P� $. Thumb�� �@J�IsMouseOver$
 true��. ��� # �  $ Thumb�� � ��P� $. Thumb�� �@n�
IsDragging$
 true��. ��� # �  $ Thumb�� � ��P�  � {�$ false��. ��� $ Thumb�� � y�$ 	Collapsed=�P�  �@��Orientation$ 
Horizontal=�. ��� $ GridRoot�� �@�LayoutTransform �� $	8 -90Q��� $ 
PART_Track�� �@�LayoutTransform �� $	8 -90Q���  � ��$
 Auto����  � ��$ 3���� $ Thumb�� �@�Tag$ 
Horizontal���� $ PageDown�� � ��$ ScrollBar.PageLeftCommand���� $ PageUp�� � ��$  ScrollBar.PageRightCommand��.���  �� $
��116* ��� $��1405* �.+�� -   $��
0,0,1327,0q�$��2������ 9 �� EndPoint$9 0.5,1&�: �� 
StartPoint$: 0.5,0&�.��� ; � Color$; 	#FF4B1930��< � Offset$< 1Q�� $; 	#FF641E3A��$< 0Q�.+��� $��Soledout_Discord.png��$
��Fill=�$��	56,21,0,0q�$
��Left=�$��88��$��80��$	��Top=��� $��SoledOut��$��42��$	��Top=�$��18(�$��Sitka Small)�$��
0,101,47,0q�$��Right=�$��92��
��������� -   = ��Name$= version��$��V1.0.0.1��$��14(�$��	0,122,0,0q�$��Center=�$��Center=�$��86��$��27��$	��Top=�
��������� -   > ��Name$> dashboard_button��#��[  $��18(�$
��Left=�$��	0,169,0,0q�$��Center=�$	��193��$��50��$	��Top=���Z� ��Z� .���� ? �� Orientation$? 
Horizontal=����� .+��� $��	graph.png��$��17��$��18��$��40,0,0,0q��� $��5,0,0,0q�
�������$��Center=�	Dashboard�� -   $> tasks_button��#��[  $��18(�$
��Left=�$��	0,217,0,0q�$��Center=�$	��193��$��50��$	��Top=���Z� ��Z� .���� $? 
Horizontal=�.+��� $��to-do-list.png��$��17��$��18��$��40,0,0,0q��� $��5,0,0,0q�
�������$��Center=�Tasks�� -   $> profiles_button��#��[  $��18(�$
��Left=�$��	0,265,0,0q�$��50��$	��Top=�$��Center=�$	��193����Z� ��Z� .���� $? 
Horizontal=�.+��� $��/id-card.png��$��17��$��18��$��40,0,0,0q��� $��5,0,0,0q�
�������$��Center=��� $�Profiles���� -   $> peoxies_button��#��[  $��50��$	��194��$��18(�$
��Left=�$��Center=�$	��Top=�$��	0,313,0,0q���Z� ��Z� .���� $? 
Horizontal=�.+��� $��/location.png��$��17��$��18��$��40,0,0,0q��� $��5,0,0,0q�
�������$��Center=��� $�Proxies���� -   $> settings_button��#��[  $��50��$	��194��$��18(�$
��Left=�$��Center=�$	��Top=�$��	0,361,0,0q���Z� ��Z� .���� $? 
Horizontal=�.+��� $��/settings.png��$��17��$��18��$��40,0,0,0q��� $��5,0,0,0q�
�������$��Center=��� $�Settings���� $��Welcome,��$
��Left=�$��
19,700,0,0q�$	��Top=�$��16(�$��32��$��81��
��������� -   @ ��Name$@ discord_name��$��Kevin Zhang#5345��$
��Left=�$��
19,727,0,0q�$	��Top=�$	��112��$��35��
�������$��Normal&�$��Disabled=�A � UseLayoutRounding$A False��$
��Wrap=�B �� Padding$B 5,0,5,5q���Z� � $��131,717,10,18q�$��45��$��45��.+��� $ 30,30,30,30������ -	   discord_image��C j� Stretch$
C Fill=�D �� ImageSource$D pp.gif���� -
   $> close_window��$
��Left=�$	��Top=�$��15��$��15�����	#FFF76B50$��10,6,0,0q���Z� ��Z�  ��%9   '��       �� " ��.���  �@��CornerRadius$ 8���� -   $> minimize_window��$
��Left=�$	��Top=�$��15��$��15��$��27,6,0,0q����	#FFF7BB3D��Z� ��Z�  ��%9   '��       �� " ��.���  �@��CornerRadius$ 8���� $
��Left=�$	��Top=�$��15��$��15��$��44,6,0,0q����	#FF3ACC5A��Z� ��Z�  ��%9   '��       �� " ��.���  �@��CornerRadius$ 8���� -   #��[ $��Center=�$��	0,671,0,0q�$	��Top=�$	��139��$��24�����	#FF862F4F
���������Z� E J� EffectE 3  -System.Windows.Media.Effects.DropShadowEffect  .���� $? 
Horizontal=�.+��� $��5,0,0,0q�
��������� $�Check For Updates���� $��/reload.png��$��17��$��18��$��10,0,0,0q�� -   $/ 	Dash_grid��$��78,0,0,0q�$y�Visible=�$��1������ $9 0.5,1&�$: 0.5,0&�.��� $; 	#FF4B1930��$< 1Q�� $; 	#FF641E3A��$< 0Q�.+�� $��5,308,839,11q�.+��� $ 12,12,12,12��$��6q�$ 4q�$��0,10,0,0q����	#FF862F4FE   �� -   $% total_checkout��$
��Left=�$��Center=�$��Center=�$��	45,74,0,0q�F �� TextWrapping$
F Wrap=�$��0��$	��Top=�$	��166��$��74��$��18(�
����������	#FF23121F$
' True��*G �� #IsInactiveSelectionHighlightEnabled$
G True����Z� H �� SelectionBrushH Z� I �� SelectionTextBrushI Z� .��E   .���� -   $% checkout_today��$
��Left=�$��Center=�$��Center=�$��
261,76,0,0q�$
F Wrap=�$��0��$	��Top=�$	��166��$��74��$��18(�
����������	#FF23121F$
' True��$
G True����Z� H Z� I Z� .��E   .���� $
��Left=�$��	45,34,0,0q�$	��Top=�$��40��$	��166��$��18(�$��Total Checkouts��$
��Bold"�$��Normal$�$��Normal&�$��Center=�$��Center=�
��������� -   $= checkout_today_label��$
��Left=�$��
261,34,0,0q�$	��Top=�$��40��$	��166��$��18(�$��Checkouts Today��$
��Bold"�$��Normal$�$��Normal&�$��Center=�$��Center=�
��������� -   $% total_decline��$
��Left=�$��Center=�$��Center=�$��
45,212,0,0q�$
F Wrap=�$��0��$	��Top=�$	��166��$��74��$��18(�
����������	#FF23121F$
' True��$
G True����Z� H Z� I Z� .��E   .���� -   $% decline_today��$
��Left=�$��Center=�$��Center=�$��261,212,0,0q�$
F Wrap=�$��0��$	��Top=�$	��166��$��74��$��18(�
����������	#FF23121F$
' True��$
G True����Z� H Z� I Z� .��E   .���� $
��Left=�$��
45,170,0,0q�$	��Top=�$��40��$	��166��$��18(�$��Total Decline��$
��Bold"�$��Normal$�$��Normal&�$��Center=�$��Center=�
��������� -   $= decline_today_label��$
��Left=�$��261,172,0,0q�$	��Top=�$��40��$	��166��$��18(�$��Declines Today��$
��Bold"�$��Normal$�$��Normal&�$��Center=�$��Center=�
��������� -   $% total_spent��$
��Left=�$��Center=�$��Center=�$��
45,346,0,0q�$
F Wrap=�$��$0��$	��Top=�$	��166��$��72��$��18(�
����������	#FF23121F$
' True��$
G True����Z� H Z� I Z� .��E   .���� $
��Left=�$��
45,304,0,0q�$	��Top=�$��40��$	��166��$��18(�$��Total Spent��$
��Bold"�$��Normal$�$��Normal&�$��Center=�$��Center=�
��������� -   $% spent_today��$
��Left=�$��Center=�$��Center=�$��261,344,0,0q�$
F Wrap=�$��$0��$	��Top=�$	��166��$��74��$��18(�
����������	#FF23121F$
' True��$
G True����Z� H Z� I Z� .��E   .���� -   $= spent_today_label��$
��Left=�$��261,304,0,0q�$	��Top=�$��40��$	��166��$��18(�$��Spent Today��$
��Bold"�$��Normal$�$��Normal&�$��Center=�$��Center=�
�������� $��493,44,10,10q�.+��� $ 12,12,12,12��$��6q�$ 4q�$��0,31,0,0q����	#FF862F4FE   �� -   J ��Name$J recent_checkouts��$��10,110,10,0q�$	��601��$	��Top=�$��24(����	#FF141515$��0,0,0,0q�$6 1Q�
�������$��Disabled=�$��Visible=���Z� ���� " ��.���  � {�$ False����  � ��$ 0,0,0,3q�.@��� $��11,0,0,3q��� $��Recent Checkouts��$
��Left=�$��
340,57,0,0q�$	��Top=�$��34��$	��162��$��18(�$
��Bold"�
�������� -   $��5,74,839,461q�.+��� $ 12,12,12,12��$��6q�$ 4q�$	��245��$��Center=����	#FF862F4F$��0,0,5,0q�E   #   LiveCharts.Wpf.CartesianChart  &    LiveCharts.Wpf.Charts.Base.ChartK   LegendLocation$	K Top=�$��	12,0,17,0q�$	��211��$��Center=�L   SeriesL �� *SeriesCollection+M   AxisYM    LiveCharts.Wpf.Axis  -   N  Name$N 	axisy_val��O   
Foreground
O �����P   MinValue$P 0Q�Q   LabelFormatterQ �� *
YFormatter+R   	SeparatorR    LiveCharts.Wpf.Separator  S   StrokeThickness$S 1Q�T   StrokeDashArray$T 2R�${�False��U   StrokeU �� V �� Color$V #404F56��W   AxisXW   
O �����$P 0Q�X   LabelsX �� *Labels+R   $S 1Q�$T 2R�${�False��U �� $V #404F56���� $
��Left=�$��	39,21,0,0q�$	��Top=�$��30(�$
��Bold"�$��Normal$�$��Times New Roman)�
�������$��	Dashboard��$	��164��� -   $/ 	Task_grid��$��78,0,0,0q�$y�Hidden=�$��1������ $9 0.5,1&�$: 0.5,0&�.��� $; 	#FF4B1930��$< 1Q�� $; 	#FF641E3A��$< 0Q�.+��� -   $> newtask��#��[ $
��Left=�$��
407,31,0,0q�$	��Top=�$��38��$	��171��$��18(�$��Arial Rounded MT Bold)����	#FFF2EFF0���	#FFAB3C65E   .���� $? 
Horizontal=����� .+��� $��plus.png��$��17��$��18���� $��5,0,0,0q�
���   �$��Segoe UI)�	New Tasks�� -   $> open_cli��#��[ $
��Left=�$��
641,31,0,0q�$	��Top=�$��38��$	��171��$��18(�$��Arial Rounded MT Bold)����	#FFF2EFF0���	#FFAB3C65E   .���� $? 
Horizontal=����� .+��� $��command.png��$��17��$��18���� $��5,0,0,0q�
���   �$��Segoe UI)�
Open CLI�� -   $> 	edittasks��#��[ $
��Left=�$��
873,31,0,0q�$	��Top=�$��38��$	��171��$��18(�$��Arial Rounded MT Bold)����	#FFF2EFF0���	#FFAB3C65E   .���� $? 
Horizontal=����� .+��� $��draw.png��$��17��$��18���� $��5,0,0,0q�
���   �$��Segoe UI)�
Edit Tasks�� -   $> delete_button��#��[ $
��Left=�$��1105,31,0,0q�$	��Top=�$��38��$	��171��$��18(�$��Arial Rounded MT Bold)����	#FFF2EFF0$y�Visible=����	#FFAB3C65E   .���� $? 
Horizontal=����� .+��� $��	close.png��$��17��$��18���� $��5,0,0,0q�$��Segoe UI)�
���   �
Delete All� $��10,100,10,10q�.+��� $ 12,12,12,12��$ 4q����	#FF862F4FE   �� -   $J 	tasks_box��$��10,49,10,10q�$��Hidden=�Y �� SelectionMode$Y Extended=���Z� ��Z� ���� .R��� $ 12,12,12,12��$ 4q�$
��1271��$��38������ $9 0.5,1&�$: 0.5,0&�.��� $; 	#FF4B1930��$< 1Q�� $; 	#FF641E3A��$< 0Q�E   ._��� $? 
Horizontal=�$��-4,-4,-4,-4q�.+��� $	��104��$��5,0,0,0q�
�������$��16(�${�False��$��Center=�$
��Wrap=�Z �� TextAlignment$
Z Left=�$B 5,0,0,0q�$	��104��$	��104������ *taskID+�� $	��200��$��5,0,0,0q�
�������$��16(�${�False��$��Center=�$
��Wrap=�$
Z Left=�$	��200��$	��200������ *TaskGroupName+�� $��3,0,0,0q�
�������$��16(�$��Center=�$	��140��$
Z Left=�$	��140��$	��140������ *Sizes+�� $��5,0,0,0q�
�������$��16(�$��Center=�$	��200��$
Z Left=�$	��200��$	��200������ *SKU+�� $��5,0,0,0q�
�������$��16(�$��Center=�$
Z Left=�$	��200��$	��200��$	��200������ *Site+�� $��5,0,0,0q�
�������$��16(�$��Center=�$
Z Left=�$	��177��$	��177��$	��177������ *
ProxyGroup+�� $��5,0,0,0q�
�������$��16(�$��Center=�$
Z Left=�$	��132��$	��132��$	��132������ *
TaskAmount+�� $��5,0,0,0q�
�������$��16(�$��Center=�$
Z Left=�$��68��$��68��$��68������ *	Scheduled+[ � ContextMenu[ �� .@�m� -    \ m�Name$\ 	edit_menu��$
��Edit��] m� Icon] �� $��draw.png��m� -!   $��Delete��] �� $��
delete.png��m� -"   $\ duplicate_menu��$��	Duplicate��] �� $��copying.png���� -#   $
��Left=�$��	14,10,0,0q�$	��Top=�$��Task ID��$��18(�
��������� $
��Left=�$��
126,10,0,0q�$	��Top=�$��Task Group Name��$��18(�
��������� $
��Left=�$��
330,10,0,0q�$	��Top=�$��Sizes��$��18(�
��������� $
��Left=�$��
474,10,0,0q�$	��Top=�$
��SKUs��$��18(�
��������� $
��Left=�$��
680,10,0,0q�$	��Top=�$
��Site��$��18(�
��������� $
��Left=�$��
884,10,0,0q�$	��Top=�$��Proxy Group��$��18(�
��������� $
��Left=�$��1066,10,0,0q�$	��Top=�$��Task Amount��$��18(�^ J� RenderTransformOrigin$^ 0.454,0.576&�
��������� $
��Left=�$��1202,10,0,0q�$	��Top=�$��Schedule��$��18(�
��������� $
��Left=�$��	10,25,0,0q�$	��Top=�$��30(�$
��Bold"�$��Normal$�$��Times New Roman)�
�������$��Task Manager��� -$   $/ Profile_grid��$��78,0,0,0q�$y�Hidden=�$��1������ $9 0.5,1&�$: 0.5,0&�.��� $; 	#FF4B1930��$< 1Q�� $; 	#FF641E3A��$< 0Q�.+�� $��10,252,913,211q�.+��� $ 12,12,12,12��$ 4q�$��
0,-14,0,14q����	#FF862F4FE   � $��10,252,913,211q�.+��� $ 12,12,12,12��$ 4q�$��0,-173,-412,338q����	#FF862F4FE   � $��10,252,913,211q�.+��� $ 12,12,12,12��$ 4q�$��0,309,-890,-202q����	#FF862F4FE   � -%   $/ billing_grid��$��420,239,502,224q�.+��� $ 12,12,12,12��$ 4q�$��0,0,0,1q����	#FF862F4FE   �� $
��Left=�$��	10,10,0,0q�$	��Top=�$��Billing Address��
�������$��20(��� -&   $% BFname��$
��Left=�$��	39,61,0,0q�$
F Wrap=�$	��Top=�$	��146��$��0,0,0,1q����	#FF4B1930$��	FirstName��_ �� SelectionOpacity$	_ 0.9Q�` �� 	UndoLimit$` 95��$��26��$��Times New Roman)�
�������
���   �$��16(�$��5,0,0,0q�$
��Left=�$��Center=��� -'   $% Blname��$
��Left=�$��
221,60,0,0q�$
F Wrap=�$	��Top=�$	��146��$��0,0,0,1q����	#FF4B1930$��LastName��$	_ 0.9Q�$` 95��$��27��$��Times New Roman)�
�������
���   �$��16(�$��5,0,0,0q�$
��Left=�$��Center=��� -(   $% Baddy1��$��Center=�$��	0,108,0,0q�$
F Wrap=�$	��Top=�$	��328��$��0,0,0,1q����	#FF4B1930$��Address Line 1��$	_ 0.9Q�$` 95��$��26��a �� 	MaxLength$a 30��$��Times New Roman)�
�������
���   �$��16(�$��5,0,0,0q�$
��Left=�$��Center=��� -)   $% Baddy2��$��Center=�$��	0,151,0,0q�$
F Wrap=�$	��Top=�$	��328��$��0,0,0,1q����	#FF4B1930$��Address Line 2��$	_ 0.9Q�$` 95��$��26��$��Times New Roman)�
�������
���   �$��16(�$��5,0,0,0q�$
��Left=�$��Center=��� -*   $% Bcity��$
��Left=�$��
39,206,0,0q�$
F Wrap=�$	��Top=�$	��146��$��0,0,0,1q����	#FF4B1930$
��City��$	_ 0.9Q�$` 95��$��28��$��Times New Roman)�
�������
���   �$��16(�$��5,0,0,0q�$
��Left=�$��Center=��� -+   $
% Bzip��$
��Left=�$��221,206,0,0q�$
F Wrap=�$	��Top=�$	��146��$��0,0,0,1q����	#FF4B1930$	��Zip��$	_ 0.9Q�$` 95��$��27��$��Times New Roman)�
�������
���   �$��16(�$��5,0,0,0q�$
��Left=�$��Center=��� -,   b ��Name$b BCountry��$
��Left=�$��
39,254,0,0q�$	��Top=�$	��146��$��0,0,0,0q�c �� IsTextSearchEnabled$
c True��$��28��$��18(�$��Times New Roman)�
���   ���Z� .@��� $��United States��d �� 
IsSelected$
d True���� $��Canada���� --   $b 	BState_CA��$
��Left=�$	��Top=�$	��146��$��0,0,0,0q�$
c True��$
& True��$��28��$��18(�$��Times New Roman)�
���   ����	#FF23121F$y�Visible=�$��221,254,0,0q�.@��� $��Alberta��$
d True���� $��British Columbia���� $��Manitoba���� $��New Brunswick���� $��Newfoundland and Labrador���� $��Northwest Territories���� $��Nova Scotia���� $��Nunavut���� $��Ontario���� $��Prince Edward Island���� $��Quebec���� $��Saskatchewan���� $��Yukon���� -.   $b 	BState_US��$
��Left=�$��221,254,0,0q�$	��Top=�$	��146��$��0,0,0,0q�$
c True��$
& True��$��28��$��18(�$��Times New Roman)�
���   ����	#FF23121F.@��� $��Alabama��$
d True���� $��Alaska���� $��Arizona���� $��Arkansas���� $��
California���� $��Colorado���� $��Connecticut���� $��Delaware���� $��Florida���� $��Georgia���� $��Hawaii���� $��Idaho���� $��Illinois���� $��Indiana���� $
��Iowa���� $��Kansas���� $��Kentucky���� $��	Louisiana���� $��Maine���� $��Maryland���� $��Massachusetts���� $��Michigan���� $��	Minnesota���� $��Mississippi���� $��Missouri���� $��Montana���� $��Nebraska���� $��Nevada���� $��New Hampshire���� $��
New Jersey���� $��
New Mexico���� $��New York���� $��North Carolina���� $��North Dakota���� $
��Ohio���� $��Oklahoma���� $��Oregon���� $��Pennsylvania���� $��Rhode Island���� $��South Carolina���� $��South Dakota���� $��	Tennessee���� $��Texas���� $
��Utah���� $��Vermont���� $��Virginia���� $��
Washington���� $��West Virginia���� $��	Wisconsin���� $��Wyoming���� -/   $J profiel_box��$��18,561,28,10q�$
��Auto=�$��Hidden=�$A False��$
��True��4  .System.Windows.Automation.AutomationPropertiese   IsOffscreenBehavior$e Default=�$y�Visible=���Z� ��Z� ���� ���� .R�� f � Orientation$f 
Horizontal=����� .R��� $ 12,12,12,12��$ 4q�$	��204��$	��185������ $9 0.5,1&�$: 0.5,0&�.��� $; 	#FFA5305B��$	< 0.4Q�� $; 	#994B1930��$< 1Q�E   ._��� $? Vertical=�$��-4,-4,-4,-4q�.+��� $��42��$? 
Horizontal=�$��Right=�.+��� $> profile_delete��-0   #��[ $��44��$��41����Z� ��Z� .���� $? 
Horizontal=�.+��� $��
delete.png��$��29��$��27���� $��Center=�$��Center=�$��18(�$��77��
����������� *ProfileName+�� $��Center=�$��Center=�.���� $? 
Horizontal=����� .+��� $��credit-card.png��$��17��$��18���� $��5,0,0,0q�
����������� *	ProfileCC+�� $��Center=�$��Center=�.���� $? 
Horizontal=����� .+��� $��	email.png��$��17��$��18���� $��5,0,0,0q�
����������� *ProfileEmail+�� -1   $% profile_name_text��$
��Left=�$��
52,100,0,0q�$
F Wrap=�$��Profile Name��$	��Top=�$	��228��$��16(�$��28�����	#FF4B192D$��1,1,1,1q�$��Times New Roman)�
����������	#FF020202$
��Left=�$��Center=�$��5,0,0,0q��� -2   $% email��$
��Left=�$��
52,146,0,0q�$
F Wrap=�$��Email��$	��Top=�$	��228��$��28�����	#FF4B1930$��0,0,0,1q�$��Times New Roman)�
�������
���   �$��16(�$��5,0,0,0q�$
��Left=�$��Center=��� -3   $% phonenumber��$
��Left=�$��
52,189,0,0q�$
F Wrap=�$��Phone Number��$	��Top=�$	��228��$��28�����	#FF4B1930$��0,0,0,1q�$��Times New Roman)�
�������
���   �$��16(�$��5,0,0,0q�$
��Left=�$��Center=��� -4   $% Fname��$��52,301,1135,452q�$
F Wrap=�$��0,0,0,1q����	#FF4B1930$��	FirstName��$	_ 0.9Q�$` 95��$��Times New Roman)�
�������
���   �$��27��$��16(�$��5,0,0,0q�$
��Left=�$��Center=��� -5   $% lname��$��230,301,951,452q�$
F Wrap=�$��0,0,0,1q����	#FF4B1930$��LastName��$	_ 0.9Q�$` 95��$��Times New Roman)�
�������
���   �$��27��$��16(�$��5,0,0,0q�$
��Left=�$��Center=��� -6   $% addy1��$��52,346,951,406q�$
F Wrap=�$��0,0,0,1q����	#FF4B1930$��Address Line 1��$	_ 0.9Q�$` 95��$a 30��$��Times New Roman)�
�������
���   �$��27��$��16(�$��5,0,0,0q�$
��Left=�$��Center=��� -7   $% addy2��$��52,390,951,363q�$
F Wrap=�$��0,0,0,1q����	#FF4B1930$��Address Line 2��$	_ 0.9Q�$` 95��$��Times New Roman)�
�������
���   �$��27��$��16(�$��5,0,0,0q�$
��Left=�$��Center=��� -8   $
% city��$��50,448,1132,305q�$
F Wrap=�$��0,0,0,1q����	#FF4B1930$
��City��$	_ 0.9Q�$` 95��$��Times New Roman)�
�������
���   �$��27��$��16(�$��5,0,0,0q�$
��Left=�$��Center=��� -9   $	% zip��$��230,448,951,305q�$
F Wrap=�$��0,0,0,1q����	#FF4B1930$	��Zip��$	_ 0.9Q�$` 95��$��Times New Roman)�
�������
���   �$��27��$��16(�$��5,0,0,0q�$
��Left=�$��Center=��� $
��Left=�$��	22,30,0,0q�$	��Top=�$��Create Profile��$��30(�$
��Bold"�$��Normal$�$��Times New Roman)�
��������� -:   $> Profile_Import��#��[ $
��Left=�$��
961,30,0,0q�$	��Top=�$��38��$	��141��$��18(����	#FFAB3C65E   .���� $? 
Horizontal=����� .+��� $��	inbox.png��$��17��$��18���� $��5,0,0,0q�Import�� -;   $> Profile_Export��#��[ $
��Left=�$��1133,30,0,0q�$	��Top=�$��38��$	��141��$��18(����	#FFAB3C65E   .���� $? 
Horizontal=����� .+��� $��
outbox.png��$��17��$��18���� $��5,0,0,0q�Export�� -<   $> Profile_Save��#��[ $
��Left=�$��
787,30,0,0q�$	��Top=�$��38��$	��141��$��18(����	#FFAB3C65E   .���� $? 
Horizontal=����� .+��� $��diskette.png��$��17��$��18���� $��5,0,0,0q�Save Profile�� $
��Left=�$��
18,245,0,0q�$	��Top=�$��Shipping Address��
�������$��20(��� -=   $b State_CA��$
��Left=�$	��Top=�$	��146��$��0,0,0,0q�$
c True��$
& True��$��27��$��18(�$��Times New Roman)�
���   ����	#FF23121F$y�Visible=�$��230,496,0,0q�.@��� $��Alberta��$
d True���� $��British Columbia���� $��Manitoba���� $��New Brunswick���� $��Newfoundland and Labrador���� $��Northwest Territories���� $��Nova Scotia���� $��Nunavut���� $��Ontario���� $��Prince Edward Island���� $��Quebec���� $��Saskatchewan���� $��Yukon���� ->   $b State_US��$��230,496,951,257q�$��0,0,0,0q�$
c True��$
& True��$��18(�$��Times New Roman)�
���   ����	#FF23121F$��27��.@��� $��Alabama��$
d True���� $��Alaska���� $��Arizona���� $��Arkansas���� $��
California���� $��Colorado���� $��Connecticut���� $��Delaware���� $��Florida���� $��Georgia���� $��Hawaii���� $��Idaho���� $��Illinois���� $��Indiana���� $
��Iowa���� $��Kansas���� $��Kentucky���� $��	Louisiana���� $��Maine���� $��Maryland���� $��Massachusetts���� $��Michigan���� $��	Minnesota���� $��Mississippi���� $��Missouri���� $��Montana���� $��Nebraska���� $��Nevada���� $��New Hampshire���� $��
New Jersey���� $��
New Mexico���� $��New York���� $��North Carolina���� $��North Dakota���� $
��Ohio���� $��Oklahoma���� $��Oregon���� $��Pennsylvania���� $��Rhode Island���� $��South Carolina���� $��South Dakota���� $��	Tennessee���� $��Texas���� $
��Utah���� $��Vermont���� $��Virginia���� $��
Washington���� $��West Virginia���� $��	Wisconsin���� $��Wyoming���� -?   $b Country��$��48,496,1132,257q�$��0,0,0,0q�$
c True��$��18(�$��Times New Roman)�
���   ����	#FF23121F$��27��$	��146��g J� OpacityMaskg �	#FF423E3E.@��� $��United States��$
d True��
���   ��� $��Canada��
���   ��� -@   h ��Name$h samebillship��$��Billing Same As Shipping��$
��Left=�$��327,192,0,0q�$	��Top=�$��20��$	��166��$��12(�$��Times New Roman)�
�������$
��Left=�$��Center=�i � LayoutTransformi �� j �� ScaleX$	j 1.5Q�k �� ScaleY$	k 1.5Q�� $��840,94,53,211q�.+��� $ 12,12,12,12��$ 4q�$��0,-14,-31,15q����	#FF862F4FE   �� 
���   �$��1q�$��	77,34,0,0q�$ 10,10,10,10��$
��Left=�$	��330��$	��173��$	��Top=�E   ���� $9 0.5,1&�$: 0.5,0&�.��� $; 	#FFA5305B��$< 0.236Q�� $; 	#994B1930��$< 1Q�._��� $��27,39,224,89q�$����https://media.discordapp.net/attachments/919371633070833714/945138641557159946/credit-card-chip-silver-isolated-260nw-490291144.jpg.png���� $��logo.ico��$
��Fill=�$��
309,45,0,0q�$
��Left=�$��78��$��76��$	��Top=�$^ 0.5,0.5&�z�V� .~��� �� �� $8 -8.873Q�T� �� -A   $% ccnum1��$
��Left=�$��120,0,0,324q�$
F Wrap=�$��0,0,0,1q�$��Bottom=�$	��228�����	#FF4B1930$��28��$��Card Number��$a 16��$��Times New Roman)�
�������
���   �$��16(�$��5,0,0,0q�$
��Left=�$��Center=�H Z� �� 
���   �$��1q�$��
77,242,0,0q�$ 10,10,10,10��$
��Left=�$	��330��$	��173��$	��Top=�E   ���� $9 0.5,1&�$: 0.5,0&�.��� $; 	#FFA5305B��$< 0.236Q�� $; 	#994B1930��$< 1Q��� -B   $b ccmonth��$
��Left=�$��122,0,0,280q�$��Bottom=�$��55��$��0,0,0,0q�$
c True��$��28��$��18(�$��Times New Roman)�
���   ����	#FF23121F.@��� $��01��$
d True���� $��02���� $��03���� $��04���� $��05���� $��06���� $��07���� $��08���� $��09���� $��10���� $��11���� $��12���� -C   $b ccyear��$
��Left=�$��189,167,0,0q�$	��Top=�$��68��$��0,0,0,0q�$
c True��$��28��$��18(�$��Times New Roman)�
���   ����	#FF23121F.@��� $
��2022��$
d True���� $
��2023���� $
��2024���� $
��2025���� $
��2026���� $
��2027���� $
��2028���� $
��2029���� $
��2030���� $
��2030���� $
��2032���� -D   $	% cvv��$
��Left=�$��
263,0,0,99q�$
F Wrap=�$��1,1,1,1q�$��Bottom=�$��48�����	#FF4B1930$��26��$	��CVV��$a 4��$��Times New Roman)�
�������
���   �$��5,0,0,0q�$��16(�$
��Left=�$��Center=��� $
��Left=�$��26��$��
77,272,0,0q�
���   �$	��Top=�$	��330��
���   ��� $
��Left=�$��26��$��	77,0,0,99q�$��Bottom=�$	��186��
�������� -E   $/ Proxies_grid��$��78,0,0,0q�$y�Hidden=�$��1������ $9 0.5,1&�$: 0.5,0&�.��� $; 	#FF4B1930��$< 1Q�� $; 	#FF641E3A��$< 0Q�.+��� $
��Left=�$��	12,23,0,0q�$	��Top=�$��Proxies��$��30(�$
��Bold"�$��Normal$�$��Times New Roman)�
��������� $ 12,12,12,12��$ 4q�$��10,67,10,616q�$^ 0.5,0.5&����	#FF862F4Fz�V� .~��� �� l �� AngleX$l 0.189Q��� T� m T� X$m 0.163Q�E   �� -F   $b 	proxy_box��$
��Left=�$��
222,78,0,0q�$	��Top=�$	��218��$��38��$��18(�$��Times New Roman)��� $
��Left=�$��	27,78,0,0q�$	��Top=�$��46��$	��190��$��Select Proxy Group:��$
��Bold"�$��18(�
��������� -G   $> delete_proxy��#��[ $
��Left=�$��
803,93,0,0q�$	��Top=�$��38��$	��171��$��18(����	#FFAB3C65E   .���� $? 
Horizontal=����� .+��� $��
delete.png��$��17��$��18���� $��5,0,0,0q�Delete Proxies�� -H   $> 
save_proxy��#��[ $
��Left=�$��
558,93,0,0q�$	��Top=�$��38��$	��171��$��18(����	#FFAB3C65E   .���� $? 
Horizontal=����� .+��� $��diskette.png��$��17��$��18���� $��5,0,0,0q�Save Proxies�� $ 12,12,12,12��$ 4q�$��10,171,10,10q����	#FF862F4FE   �� $ 12,12,12,12��$ 4q�$��25,183,22,22q����� $9 0.5,1&�$: 0.5,0&�.��� $; 	#FF4B1930��$< 1Q�� $; 	#FF641E3A��$< 0Q�._��� -I   $% proxies��$
F Wrap=�n �� AcceptsReturn$
n True��$��Center=�$��Center=�$��14(�
�������$��Visible=�$	��555��$
��1259��$
��True��$o �� HorizontalScrollBarVisibility$o Visible=�"p �� VerticalScrollBarVisibility$p Visible=���Z� ��Z� �� $
��Left=�$��
25,119,0,0q�$	��Top=�$��39��$	��133��$��Proxy Group:��$
��Bold"�$��18(�
��������� -J   $% proxy_group_name��$
��Left=�$��224,126,0,0q�$
F Wrap=�$��	New Group��$	��Top=�$	��218��$��18(�$��28��$��0,0,0,1q�$��Times New Roman)�
�������
���   ���Z� � -K   $/ Settings_grid��$��78,0,0,0q�$y�Hidden=�$��1������ $9 0.5,1&�$: 0.5,0&�.��� $; 	#FF4B1930��$< 1Q�� $; 	#FF641E3A��$< 0Q�.+��� $ 12,12,12,12��$ 4q�$��10,74,25,120q����	#FF862F4FE   �� $ 12,12,12,12��$ 4q�$��398,478,726,153q����� $9 0.5,1&�$: 0.5,0&�.��� $; 	#FF4B1930��$< 1Q�� $; 	#FF641E3A��$< 0Q�E   �� -L   $% domains_box��$
��Left=�$
F Wrap=�$
n True��$	��Top=�$	��194��$	��140��$��18(�$��1,1,1,1q�$��Times New Roman)�
�������$��402,484,0,0q�$
��True��$
G True����Z� ��Z� H Z� .���� $
��Left=�$��	34,96,0,0q�$	��Top=�$	��221��$��18(�$��Discord Webhook:��$
��Bold"�
��������� $��Settings��$
��Left=�$��	12,24,0,0q�$	��Top=�$��30(�$
��Bold"�$��Normal$�$��Times New Roman)�
��������� -M   $% decline_webhook��$
��Left=�$��
34,206,0,0q�$
F Wrap=�$	��Top=�$��0,0,0,1q�$
��1232��$��18(�$��Decline Webhook Here��$��26��$��Times New Roman)�
�������
���   ���Z� �� -N   $% success_webhook��$
��Left=�$��
34,152,0,0q�$
F Wrap=�$	��Top=�$��0,0,0,1q�$
��1232��$��18(�$��Success Webhook Here��$��26��$��Times New Roman)�
�������
���   ���Z� �� $
��Left=�$��
34,260,0,0q�$	��Top=�$	��221��$��18(�$��3rd Party Solver Keys:��$
��Bold"�
��������� -O   $% cap_key��$
��Left=�$��244,315,0,0q�$
F Wrap=�$	��Top=�$��0,0,0,1q�$
��1022��$��18(�$��Key Here��$��26��$��Times New Roman)�
�������
���   �${�False����Z� �� -P   $b _3rdparty_solver��$
��Left=�$��
34,315,0,0q�$	��Top=�$	��181��$��26��$��18(�$��Times New Roman)�.@��� $
��2Cap���� $��Anti Captcha���� $��
CapMonster���� $
��AYCD���� $
��Left=�$��398,444,0,0q�$	��Top=�$	��156��$��18(�$
��Bold"�$��Domains:��
��������� $
��Left=�$��
37,358,0,0q�$	��Top=�$	��221��$��18(�$��Text Captcha Solver Keys:��$
��Bold"�
��������� -Q   $% cap_key_text��$
��Left=�$��244,409,0,0q�$
F Wrap=�$	��Top=�$��0,0,0,1q�$
��1022��$��18(�$��Key Here��$��26��$��Times New Roman)�
�������
���   �$
{�True����Z� �� -R   $b text_cap_solver��$
��Left=�$��
34,409,0,0q�$	��Top=�$	��181��$��26��$��18(�$��Times New Roman)�.@��� $
��2Cap���� $��Anti Captcha���� $��
CapMonster���� $
��Left=�$��
36,444,0,0q�$	��Top=�$	��156��$��18(�$
��Bold"�$��Error Delay:��
��������� -S   $% error_delay��$
��Left=�$��
37,494,0,0q�$
F Wrap=�$	��Top=�$��0,0,0,1q�$	��106��$��18(�$��26��$
��3000��$a 5��$��Times New Roman)�
�������
���   ���Z� �� $
��Left=�$��219,444,0,0q�$	��Top=�$	��158��$��18(�$
��Bold"�$��Monitor Delay:��
��������� -T   $% monitor_delay��$
��Left=�$��223,494,0,0q�$
F Wrap=�$	��Top=�$��0,0,0,1q�$	��106��$��18(�$��26��$
��3000��$a 5��$��Times New Roman)�
�������
���   ���Z� �� -U   $> settings_save��#��[ $
��Left=�$��
84,678,0,0q�$	��Top=�$��38��$	��171��$��18(����	#FFAB3C65��Z� E   .���� $? 
Horizontal=����� .+��� $��diskette.png��$��17��$��18���� $��5,0,0,0q�Save Settings�� -V   $> settings_import��#��[ $
��Left=�$��323,678,0,0q�$	��Top=�$��38��$	��171��$��18(����	#FFAB3C65��Z� E   .���� $? 
Horizontal=����� .+��� $��
/inbox.png��$��17��$��18���� $��5,0,0,0q��� $�Import Settings���� -W   $> settings_export_Copy��#��[ $
��Left=�$��566,678,0,0q�$	��Top=�$��38��$	��171��$��18(����	#FFAB3C65��Z� E   .���� $? 
Horizontal=����� .+��� $��/outbox.png��$��17��$��18���� $��5,0,0,0q��� $�Export Settings���� -X   $> settings_webhook_test��#��[ $
��Left=�$��808,678,0,0q�$	��Top=�$��38��$	��171��$��18(����	#FFAB3C65��Z� E   .���� $? 
Horizontal=����� .+��� $��	/test.png��$��17��$��18���� $��5,0,0,0q��� $�Webhook Test���� -Y   $> settings_deactivate_key��#��[ $
��Left=�$��1050,678,0,0q�$	��Top=�$��38��$	��170��$��18(����	#FFAB3C65��Z� E   .���� $? 
Horizontal=����� .+��� $��/logout.png��$��17��$��18���� $��5,0,0,0q��� $�Deactivate Key��