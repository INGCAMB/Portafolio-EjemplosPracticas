<HTML>
	<HEAD>
	<TITLE>Ejemplo 7 Calculo operaciones</TITLE>
	</HEAD>
	<BODY>
		<?PHP
			if ($_REQUEST['operaciones']=="suma")
			{
				$suma=$_REQUEST['valor1']+$_REQUEST['valor2'];
				echo "La suma es:".$suma;
			}
			else
			{
				if ($_REQUEST['operaciones']=="resta")
				{
					$resta=$_REQUEST['valor1']-$_REQUEST['valor2'];
					echo "La resta es:".$resta;
				}
			}
		?>
	</BODY>
</HTML>