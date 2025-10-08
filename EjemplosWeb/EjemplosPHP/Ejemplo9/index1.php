<HTML>
	<HEAD>
	<TITLE>Ejemplo 9 Problema de if</TITLE>
	</HEAD>
	<BODY>
		<?PHP
			$valor=rand(1,10);
			echo "El valor sorteado es $valor<BR>";
			if ($valor<=5)
			{
				echo "Es menor o igual a 5";
			}
			else
			{
				echo "Es mayor a 5";
			}
		?>
		<A href="index2.php">If anidado </A>
	</BODY>
</HTML>