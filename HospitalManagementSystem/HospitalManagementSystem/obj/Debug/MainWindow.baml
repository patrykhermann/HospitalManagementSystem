   M S B A M L   `   `   `  ����S  OHospitalManagementSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:HospitalManagementSystemHospitalManagementSystem  5   	   )    #HospitalManagementSystem.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   8local&clr-namespace:HospitalManagementSystem     5   	   V RMaterialDesignThemes.Wpf, Version=2.5.0.1205, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   -   5          � Title$  
MainWindow��5	   	   $	��600��6   $
��1000��6)    � 
ResizeMode$ NoResize=�66    � WindowStartupLocation$ CenterScreen=�6L   .��5
      � .+�5   
   � $��70��6   $	��Top=�6   ���	#FF346CB0.+�5      '  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.5.0.1205, Culture=neutral, PublicKeyToken=null]]   Kind$ Hospital=�6&   
�������$��60��6I   $��60��6T   $��Center=�6`   $
��Left=�6{   $��15,0,0,0q�6�   �� 5      -   5         ��Name$ 
lblSeconds��5      
�������$
��Left=�6;   $��Center=�6V   $��80,0,0,0q�6q   $��18(�6�   �� 5      $��WSB Hospital��6   
�������$��Center=�6?   $��Center=�6\   $��22(�6w   �� 5       �� Orientation$ 
Horizontal=�6   $��Right=�62   .+�5        $ FaceProfile=�6*   $��25��6=   $��25��6H   
�������$��	10,23,5,0q�6g   �� 5      -   5         ��Name$ txtUser��5      $�� ��6-   $��Center=�65   $��16(�6P   
�������6^   '  !MaterialDesignThemes.Wpf.PopupBox  5      $��10q�6*      PlacementMode$ BottomAndAlignRightEdges=�66      	StaysOpen .  
�������	   PopupContent.	 5      �� $	��150��6!   .+�5      �� -   5        
 ��Name$
 ButtonPopUpChangePassword��5   !   $��Change password��6D   6^   �� 5      �� 5      -   5        $
 ButtonPopUpLogout��5   !   $��Logout��6<   6M   �� 5      �� 5      -   5        $
 ButtonPopUpExit��5   !   $
��Exit��6:   6I   5      5      5      5      � 5   
   -   5         �Name$ GridMenu��5      $	��150��6!   $
��Left=�6-   ���	#FF19267C$��0,70,0,0q�6_   .+�5      �� .+�5       �� $��Disabled=�6   ���	#FF346CB0$��0,50,0,0q�6h   .@�5!      �� -   5         ��Name$ lviSchedule��5!   #   $��60��68    � Cursor$
 Hand��6�   .��5"      �� $ 
Horizontal=�6%   .+�5#        $��10q�66   $ Calendar=�6B   $��25��6R   $��25��6^   $��Center=�6i   �� 5$      $��Schedule��6(   $��Center=�68   $��20,10q�6S   5%      5&      �� 5'      -	   5        $ lviEmpoyees��5'   #   $��60��68   $
 Hand��6�   .��5(      �� $ 
Horizontal=�6%   .+�5)        $��10q�66   $ Person=�6B   $��25��6Q   $��25��6]   $��Center=�6h   �� 5*      $��	Employees��6(   $��Center=�69   $��20,10q�6T   5+      5,      �� 5-      -
   5        $ lviAdd��5-   #   $��60��63   $y�Hidden=�6~   $
 Hand��6�   .��5.      �� $ 
Horizontal=�6%   .+�5/        $��10q�66   $ 	PersonAdd=�6B   $��25��6S   $��25��6_   $��Center=�6j   �� 50      $	��Add��6(   $��Center=�63   $��20,10q�6N   51      52      53      54      �� 55      $��© Patryk Hermann, 2019��6   ���	#FF346CB0$��8(�6L   $��Center=�6Y   $��Bottom=�6v   56      � 58   
   -   5        $ gridSchedule��58   "   
�������$	��830��68   $	��491��6D   $��Right=�6Q   $��Bottom=�6m   .+�59      &   System.Windows.Controls.Calendar  -   5          Name$ 
calCurrent��59         FirstDayOfWeek$ Monday=�6+      IsTodayHighlighted .  $��Center=�6^   $��Center=�6y   $��437,54,105,71q�6�   �� 5:      $��Your current schedule��6   $
��Left=�64   $��	10,28,0,0q�6O   $	��Top=�6b   $��20(�6z   $��Segoe UI Semibold)�6�   �� 5;      -   5        $
 btnResetSchedule��5;      $��Reset��6/   $��Bottom=�6?   $��66��6Z   $��Center=�6e   $��654,0,110,20q�6�   $��0q�6�   6�   �� 5<      -   5        $ txtDates��5<      $
��Left=�6*   $��	10,94,0,0q�6E   $
��Wrap=�6X   $	��Top=�6l   $	��356��6�   $	��225��6�   $��16(�6�   �� 5=      -   5        $
 	btnAddDay��5=      $��Add day to your schedule��6(   $
��Left=�6K   $��442,439,0,0q�6f   $	��Top=�6{   $	��181��6�   $��0q�6�   6�   5>      � 5@   
   -   5        $ gridEmployees��5@      $	��839��6&   $	��500��62   $��Right=�6?   $��Bottom=�6[   $y�Hidden=�6v   .+�5A      &   System.Windows.Controls.DataGrid  -   5          Name$ dataEmployees��5A   3      AutoGenerateColumns .  $
��Left=�6J   $	��444��6e   $��	10,10,0,0q�6r   $	��Top=�6�   $	��819��6�      
IsReadOnly .  J� IsManipulationEnabled . 
�������   Columns 5B      0  *System.Windows.Controls.DataGridTextColumn  5C      ,  &System.Windows.Controls.DataGridColumn   Header$ 
First Name��6)   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6=   �� *	FirstName+  5D      $ 	Last Name��6)    6<   �� *
LastName+  5E      $ Specialization��6)    6A   �� *Specialization+  5F      $ Pesel��6)      
Visibility$ Hidden=�6X    68   �� *PeselNumber+6X     5G      $ Login��6)   $ Hidden=�6R    68   �� *Login+6R   5I      �� 5J      -   5        $
 btnEdit��5J      $
��Edit��6&   $
��Left=�65   $��306,459,0,0q�6P   $	��Top=�6e   $��75��6}   $��31��6�   $y�Hidden=�6�   6�   �� 5K      -   5        $
 	btnDelete��5K      $��Delete��6(   $
��Left=�69   $��467,459,0,0q�6T   $	��Top=�6i   $��75��6�   $��31��6�   ���	#FFFF3737���	#FFEC6060$y�Hidden=�6�   6�   5L      � 5N   
   -   5        $ gridAdd��5N      $	��839��6    $	��500��6,   $��Right=�69   $��Bottom=�6U   $y�Hidden=�6p   .+�5O      �� $��Add a new employee��6   $��22(�61   ���	#FF346CB0$��15,15q�6V   $	��Top=�6e   $
��Left=�6}   �� 5P      $��Choose a specialization��6   $��16(�66   $	��Top=�6D   $
��Left=�6\   $��15, 70q�6w   �� 5Q      -   5         ��Name$ comboSpecialization��5Q      $	��100��64   $	��Top=�6@   $
��Left=�6X   $��
195,73,0,0q�6s   .@�5R      �� -   5         ��Name$ 
citemAdmin��5R      $��Administrator��63   �� 5S      -   5        $ 
citemNurse��5S      $��Nurse��63   �� 5T      -   5        $ citemCardiologist��5T      $��Cardiologist��6:   �� 5U      -   5        $ citemLaryngologist��5U      $��Laryngologist��6;   �� 5V      -   5        $ citemNeurologist��5V      $��Neurologist��69   �� 5W      -   5        $ citemUrologist��5W      $��	Urologist��67   5X      �� 5Y      $��
First Name��6   $��16(�6)   $	��Top=�67   $
��Left=�6O   $	��100��6j   $��15, 120q�6v   �� 5Z      -   5         ��Name$ txtFirstName��5Z      $	��200��6,   $
��Left=�68   $	��Top=�6T   $��115,120,0,0q�6l   �� 5[      $��	Last Name��6   $��16(�6(   $	��Top=�66   $
��Left=�6N   $	��100��6i   $��400,120,0,0q�6u   �� 5\      -   5        $ txtlastName��5\      $	��200��6+   $
��Left=�67   $	��Top=�6S   $��500,120,0,0q�6k   �� 5]      $��Pesel��6   $��16(�6$   $	��Top=�62   $
��Left=�6J   $	��100��6e   $��15, 180q�6q   �� 5^      -   5        $ txtPesel��5^      $	��200��6(   $
��Left=�64   $	��Top=�6P   $��115,180,0,0q�6h   �� 5_      $��Login��6   $��16(�6$   $	��Top=�62   $
��Left=�6J   $	��100��6e   $��
15,240,0,0q�6q   $��31��6�   �� 5`      -   5        $ txtLogin��5`      $	��200��6(   $
��Left=�64   $	��Top=�6P   $��115,240,0,0q�6h   �� 5a      $��Password��6   $��16(�6'   $	��Top=�65   $
��Left=�6M   $	��100��6h   $��
15,300,0,0q�6t   $��31��6�   G� 5b      -    5         G�Name$ txtPassword��5b      $	��200��6/   $
��Left=�6;   $	��Top=�6W   $��115,300,0,0q�6o   �� 5c      -!   5        $
 btnAdd��5c      $	��Add��6%   $��Center=�63   $��Bottom=�6P   $��
0,0,200,40q�6k   $	��100��6    �� 	IsDefault . 6�   �� 5d      -"   5        $
 btnClear��5d      $��Clear��6'   $��Center=�67   $��Bottom=�6T   $��
200,0,0,40q�6o   $	��100��6�   6�   �� 5e      -#   5        $ lblWrongPesel��5e      $G��ARemember it can contain only numbers and should be 11 digits long��6+   
���  ��$
��Left=�6�   $��332,179,0,0q�6�   $	��Top=�6�   $y�Hidden=�6�   5f      5g      5h      