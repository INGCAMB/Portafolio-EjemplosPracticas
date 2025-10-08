<HTML>
	<HEAD>
		<TITLE>Recepcion de correo para baja de Alumno</TITLE>
	</HEAD>
	<BODY>
		<H1>Baja de alumno</H1>
		<?PHP
			include "conexion.php"; //El archivo conexion debe estar en la misma carpeta si no tienes cambiar aqui la ruta
					//consulta para ver si hay registro con ese correo,solo se ocupa id																		
			$registros=mysqli_query($conexion, "select id from alumnos where email='$_REQUEST[mail]'")
			or die("Problemas en el select:".mysqli_error($conexion));
			//si lo encuentra entra al if, primero verifica si existe el registro
			if ($reg=mysqli_fetch_array($registros))
			{
				//lo busca y lo borra
				mysqli_query($conexion, "delete from alumnos where email='$_REQUEST[mail]'")
			or die("Problemas en el select:".mysqli_error($conexion));
			echo "se efectuo el borrado del alumno con dicho correo.";
			}
			else
			{
				echo "No existe un alumno con ese correo.";
			}
			mysqli_close($conexion);
		?>
		<BR><BR>
		<H3><A href="index.php">Borrar otro</A></H3>
	</BODY>
</HTML>