<HTML>
	<HEAD>
		<TITLE>Recepcion de datos en php para alta en tabla alumnos</TITLE>
	</HEAD>
	<BODY>
		<?PHP
			include "conexion.php"; //El archivo conexion debe estar en la misma carpeta si no tienes cambiar aqui la ruta
		
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