<HTML>
	<HEAD>
		<TITLE>Modificacion Alumno por correo pagina 3</TITLE>
	</HEAD>
	<BODY>
		<H1>Modificacion de alumno</H1>
		<?PHP
			include "conexion.php"; //El archivo conexion debe estar en la misma carpeta si no tienes cambiar aqui la ruta
																							
			$registros=mysqli_query($conexion, "update alumnos set email='$_REQUEST[mailnuevo]' where email='$_REQUEST[mailviejo]'")
			or die("Problemas en el select:".mysqli_error($conexion));
			
			echo "El mail fue modificado con exito.";
			mysqli_close($conexion);
		?>
		<BR><BR>
		<H3><A href="index.php">Modificar otro</A></H3>
	</BODY>
</HTML>