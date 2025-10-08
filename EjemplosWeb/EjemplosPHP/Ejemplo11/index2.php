<HTML>
	<HEAD>
		<TITLE>Problema de funcion en php</TITLE>
	</HEAD>
	<BODY>
		<?PHP
			function retornarpromedio($valor1,$valor2)
			{
				$pro=($valor1+$valor2)/2;
				return $pro;
			}
			
			$v1=100;
			$v2=50;
			$p=retornarpromedio($v1,$v2);//Es funcion porque regresa algo
			echo "El resultado es: ".$p;
			echo"<BR>";
			$p=retornarpromedio(8,15);//Es funcion porque regresa algo
			echo "El resultado es: ".$p;
		?>
		<BR>	
		<A href="index3.php">Problema de operaciones </A>
	</BODY>
</HTML>