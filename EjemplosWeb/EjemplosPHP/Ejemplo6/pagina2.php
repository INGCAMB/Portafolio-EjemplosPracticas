<HTML>
	<HEAD>
	<TITLE>Ejemplo 6 Calculo operaciones</TITLE>
	</HEAD>
	<BODY>
		<?PHP
			if (isset($_REQUEST['check1']))
			{
				$suma=$_REQUEST['valor1']+$_REQUEST['valor2'];
				echo "La suma es:".$suma."<BR>";
			}
			if (isset($_REQUEST['check2']))
			{
				$resta=$_REQUEST['valor1']-$_REQUEST['valor2'];
				echo "La resta es:".$resta;
			}
		?>
		<HR>
		<A href="pagina1.php">Operar de nuevo</A>
	</BODY>
</HTML>