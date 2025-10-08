<HTML>
	<HEAD>
		<TITLE>Ejemplo 5 Calculo operaciones</TITLE>
	</HEAD>
	<BODY>
		<?PHP
			if ($_REQUEST['radio1']=="suma")
			{
				$suma=$_REQUEST['valor1']+$_REQUEST['valor2'];
				echo "La suma es:".$suma;
			}
			else if ($_REQUEST['radio1']=="resta")
			{
				$resta=$_REQUEST['valor1']-$_REQUEST['valor2'];
				echo "La resta es:".$resta;
			}
		?>
		<HR>
		<A href="pagina1.php">Operar de nuevo</A>
	</BODY>
</HTML>