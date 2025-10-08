<HTML>
	<HEAD>
		<TITLE>Ejemplo 2 PHP</TITLE>
	</HEAD>
	<BODY>
		<?php
			$dia=date("d");
			if($dia<=25)
			{
				echo "sitio activo";
			}
			else
			{
				echo"sitio fuera de servicio";
			}
		?>
	</BODY>
</HTML>