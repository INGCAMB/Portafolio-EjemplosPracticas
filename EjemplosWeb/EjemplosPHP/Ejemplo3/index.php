<HTML>
	<HEAD>
		<TITLE>Ejemplo 3 PHP</TITLE>
	</HEAD>
	<BODY>
		<?php
			$dia=24;//se declara una variable de tipo integer
			$sueldo= 758.43; //se declara una variable de tipo double al momento de poner punto
			$nombre="juan";//se declara una variable de tipo string
			$existe = true; //se declara una variable boolean
			echo "variable entera:";
			echo $dia;
			echo "<br>";
			echo "variable double:";
			echo $sueldo;
			echo "<br>";
			echo "variable string:";
			echo $nombre;
			echo "<br>";
			echo "variable boolean:";
			echo $existe;//dependiendo como la declares arriba es el numero que saldrá en la página (true=1)
			echo "<H1>Fin de PHP</H1>";
			$n1=12;
			$n2=33;
			$R=$n1*$n2;
			echo "La multiplicacion es: ".$R." Fin de res";//la respuesta no lleva "+" cuando se concatenean cosas se separa con puntos(sumar cadenas)
			
			echo "<BR>";
			$cadena1="hola";
			$cadena2="Mundo";
			echo $cadena1." ".$cadena2;//el simbolo "$" significa que le das un espacio en la memoria
			
			echo "<BR><BR><BR>";
			$dia=10;
			$fecha="Hoy es $dia";
			echo $fecha;
		?>
	</BODY>
</HTML>