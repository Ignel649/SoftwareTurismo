   M S B A M L   `   `   `  ����E  AWpfTurismo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:WpfTurismo
WpfTurismo  5   	       WpfTurismo.login   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:WpfTurismo     5   	   b ^MaterialDesignThemes.Wpf, Version=3.2.0.1979, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     � Title$  Login��5	   	   $	��500��6   $	��350��6$    � 
ResizeMode$ NoResize=�60    � WindowStartupLocation$ CenterScreen=�6F   .��5
      � 
�������.+�5   
   �� $	��280��6   $��Bottom=�6!   ��5      �� 5       �� EndPoint$ 0.5,1&�6&    �� 
StartPoint$ 0.5,0&�67   .��5      �  � Color$ White��6#   � 5      $ #EC5269��6#    � Offset$	 0.5Q�63   � 5      $ #EC5269��6#   $ 1Q�63   5      5      �� 5   
   $%��Imagenes\Logo_turismo_real1.png��6   $��0,-15,-16,285q�69   �� 5   
   $	��280��6   $	��220��6    $��Bottom=�6-   $
��0,50q�6H   
������� �� RadiusY$ 18.385��6c    �� RadiusX$ 18.385��6t   	 J� Effect	 5      3  -System.Windows.Media.Effects.DropShadowEffect  5      
   	Direction$
 0Q�6#      
BlurRadius$ 15Q�61      RenderingBias$ Quality=�6A      ShadowDepth$ 1Q�6Y   5      � 5   
   $	��280��6   $	��220��6   $��Bottom=�6(   $
��0,50q�6C   .+�5      �� $��Datos de usuario��6   $��Center=�60   $��20(�6M   
�������$��10q�6m   �� 5      $��Center=�6   $��10q�64   .+�5      �� -   5         ��Name$ 	txbCorreo��5      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Correo Electronico��6-    %  !MaterialDesignFloatingHintTextBox#��[  6a   $
��0,10q�6�   $��15(�6�   G� 5      -   5         G�Name$ psbContraseña��5      $ Contraseña��65    ) %MaterialDesignFloatingHintPasswordBox#��[ 6a   $
��0,10q�6�   $��15(�6�   5       5!      �� 5"   
   -   5         ��Name$ btnlogin��5"      $��Bottom=�6#   $
��0,40q�6>   $	��150��6L   $��Iniciar Sesion��6X   ���#429696���#4296966�   5$      5%      