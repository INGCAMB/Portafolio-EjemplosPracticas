<HTML>
	<HEAD>
		<TITLE>Problema de ciclo while</TITLE>
		<META charset="utf-8">
	</HEAD>
	<BODY>
		<H1> Dias de la semana </H1>
		<BR>
		<?PHP
			$dia[]="Lunes";//si no pones indice te pone en automatico los numeros del arreglo iniciando de 0
			$dia[]="Martes";
			$dia[]="Miercoles";
			$dia[]="Jueves";
			$dia[]="Viernes";
			$dia[]="Sabado";
			$dia[]="Domingo";
			
			$num=count($dia);//el count cuenta la longitud del arreglo
			echo "La semana tiene $num dias y son: <BR>";
			
			$cont1=0;//inicia el contador con 0 por el ciclo while
			while($cont1<$num)//el while debe iniciarse de 0 siempre o si no truena
			{
				echo ($cont1+1)."-".$dia[$cont1];
				echo "<BR>";
				$cont1++;//incremento
			}
		?>
		<A href="index3.php">Ciclo y Rand </A>
	</BODY>
</HTML>