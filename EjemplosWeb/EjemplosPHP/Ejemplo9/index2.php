<HTML>
	<HEAD>
	<TITLE>Problema de else if</TITLE>
	</HEAD>
	<BODY>
		<?PHP
			$valor=rand(1,100);
			echo "El valor sorteado es $valor<BR>";
			if ($valor<=9)
			{
				echo "Tiene un digito";
			}
			elseif($valor<100)
			{
				echo "Tiene 2 digitos";
			}
			else
			{
				echo "Tiene 3 digitos";
			}
		?>
		<A href="index1.php">If regular </A>
	</BODY>
</HTML>