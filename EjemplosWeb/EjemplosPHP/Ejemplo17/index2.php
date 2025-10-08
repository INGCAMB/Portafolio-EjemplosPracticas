<HTML>
	<HEAD>
		<TITLE>Alta de alumno consultando otra tabla</TITLE>
	</HEAD>
	<BODY>
		<?PHP
			include "conexion.php"; //El archivo conexion debe estar en la misma carpeta si no tienes cambiar aqui la ruta
			
			mysqli_query($conexion, "insert into alumnos(nombre,email,codigocurso) values ('$_REQUEST[nombre]','$_REQUEST[mail]',$_REQUEST[codigocurso])")
				or die("Problemas en el select".mysqli_error($conexion));
				
			mysqli_close($conexion);
			echo "El alumno fue dado de alta.";
		?>
		<BR><BR>
		<H3><A href="index.php">Otro Alumno</A></H3>
	</BODY>
</HTML>