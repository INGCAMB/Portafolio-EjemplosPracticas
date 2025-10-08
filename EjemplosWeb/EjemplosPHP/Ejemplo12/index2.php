<HTML>
	<HEAD>
		<TITLE>Recepcion de datos en php para alta en tabla alumnos</TITLE>
	</HEAD>
	<BODY>
		<?PHP
			//codigo para conectar a la bd
			$mysql_host = ""; //Nombre del servidor si es local pon localhost
			$mysql_database=""; //Nombre de la BD
			$mysql_user=""; //Nombre de usuario el predeterminado es root
			$mysql_password=""; //En linea si hay password si no hay deja en blanco
			$conexion=mysqli_connect($mysql_host,$mysql_user,$mysql_password,$mysql_database)
				or die("Problemas en la conexion a la base de datos");//en caso de que no pueda conectarse
			//codigo para el ejercicio de insercion
			mysqli_query($conexion,
				"insert into alumnos(nombre,email,codigocurso) values
				('$_REQUEST[nombre]','$_REQUEST[email]',$_REQUEST[codigocurso])")
				or die("Problemas en el insert:".mysqli_error($conexion));
			//cerrar la conexion
			mysqli_close($conexion);
			echo "El alumno fue dado de alta.";
		?>
		<BR><BR>
		<H3><A href="index.php">otro alumno</A></H3>
	</BODY>
</HTML>
