   M S B A M L   `   `   `  ����  KiranduloApp    KiranduloApp.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$(  "Kirándulóhelyek Nyilvántartása��5   	   $	��450��60   $	��800��6=   .��5      � $��10q�6   .+�5   
   �� -   5         ��Name$ lbxKirandulohelyek��5      $
��Left=�6.   $	��250��6I   $��10q�6U   5	      �� 5   
   $��Right=�6   $	��500��61   $��270,10,10,10q�6=   .+�5      �� $��Kirándulóhely neve:��6   $
��Bold"�63   �� 5      -   5         ��Name$ tbNev��5       �� 
IsReadOnly . $��0,0,0,10q�67   �� 5      $��
Helyszín:��6   $
��Bold"�6)   �� 5      -   5        $ 
tbHelyszin��5       . $��0,0,0,10q�6<   �� 5      $��Nehézségi szint:��6   $
��Bold"�60   �� 5      -   5        $ tbNehezsegiSzint��5       . $��0,0,0,10q�6B   �� 5      $��Látogatók száma:��6   $
��Bold"�60   �� 5      -   5        $ tbLatogatokSzama��5       . $��0,0,0,10q�6B   �� 5      $��Távolság (km):��6   $
��Bold"�6.   �� 5      -   5        $ tbTav��5       . $��0,0,0,10q�67   �� 5      $&�� Látogatottság (százalékban):��6   $
��Bold"�6<   � 5      -   5         �Name$ pbLatogatok��5      $��20��6/   $��0,0,0,10q�6;    � Maximum$	 100Q�6M   �� 5!      $)��#Szűrés nehézségi szint szerint:��6   $
��Bold"�6?   �� 5"      -   5        $ tbSzures��5"      $��0,0,0,10q�6(   �� 5#      -	   5        $��Szűrés��5#      $��0,0,0,10q�6>   �� 5&      -
   5        $��Szűrt adatok mentése��5&      64   5'      5(      5)      