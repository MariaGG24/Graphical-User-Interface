   M S B A M L   `   `   `  ����J  FIngestaCalorica, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:IngestaCaloricaIngestaCalorica  5   	        IngestaCalorica.TablaDatos   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:IngestaCalorica     5   	   -   5        $��ventana��5	   	     � Title$  Tabla de Datos��5   	   $	��800��6    $	��500��6-    � Icon$ 	icono.png��69   .��5
      �  � ColumnDefinitions 5   
   �� 5      $
��143* �6   �� 5      $
��105* �6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      �� 5      .+�5   
   �� $#��Seleccione el día que desee:��6   $��0��67   $��2��6D   &   System.Windows.Controls.Calendar  5   
   -   5        $��
calendario��5   `   $��0��6   $��Right=�6    $��
0,10,10,10q�6<   $��1��6P   6`   �� 5   
   $��1��6    �� Orientation$ 
Horizontal=�6"   $��2��6;   .+�5      �� $!��Escoja la comida que desee:��6   �� 5      
�������$	��130��6%   �� 5      -   5        $��comBox��5   #   $	��200��6   .@�5      �� $��Desayuno��6   �� 5       $��	Mediodía��6   �� 5!      $��Comida��6   �� 5"      $��Merienda��6   �� 5#      $
��Cena��6   �� 5$      $��Otros��6   5%      5'      �� 5(   
   $��2��6   $ 
Horizontal=�6"   $��2��6;   .+�5)      �� $+��%Introduzca las calorías consumidas: ��6   �� 5*      
�������$��89��6%   �� 5+      -   5        $��cajaCalorias��5+      $	��200��6*   $��2q�66   5,      �� 5.   
   $��3��6   $ 
Horizontal=�6"   $��2��6;   .+�5/      �� -   5        $��et��5/   '   
�������$	��388��61   �� 50      -   5        $	��100��50      $��Añadir Comida��6!   $��Right=�69   51      �� 52      
�������$��Right=�6%   $��10��6A   53      �� 55   
   -   5        $��lvFechas��55      $��20q�6#   $��4��6/   $��2��6<    �� View 56      �� 57      .P�58      �� $��FECHA��6%    �� Width$	 230��64    �� DisplayMemberBinding 6@   �� *	cadenaDia+�� 59      $��TOTAL CALORÍAS��6%   $	 230��6=    6I   �� *totalCalorias+5:      5<      �� 5=   
   -   5        $��	lvComidas��5=      $��20q�6$   $��5��60   $��2��6=    5>      �� 5?      .P�5@      �� $��COMIDA��6%   $	 230��65    6A   �� *comidaSeleccionada+�� 5A      $��	CALORÍAS��6%   $	 230��67    6C   �� *caloriasComidaSeleccionada+5B      5D      5E      5F      