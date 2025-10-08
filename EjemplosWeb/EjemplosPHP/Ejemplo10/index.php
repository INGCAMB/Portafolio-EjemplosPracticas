<HTML>
	<HEAD>
		<TITLE>Problema de ciclo for</TITLE>
		<META charset="utf-8">
	</HEAD>
	<BODY>
		<H1> Dias de la semana </H1>
		<BR>
		<?PHP
			$dia[0]="Lunes";
			$dia[1]="Martes";
			$dia[2]="Miercoles";
			$dia[3]="Jueves";
			$dia[4]="Viernes";
			$dia[5]="Sabado";
			$dia[6]="Domingo";//inicia de 0
			
			for($cont1=0;$cont1<=6;$cont1++)
			{
				echo ($cont1+1)."-".$dia[$cont1];//se inicia con mas 1 para que ponga el numero de la lista en 1
				echo "<br>";
			}
		?>
		<A href="index2.php">If regular </A>
	</BODY>
</HTML>