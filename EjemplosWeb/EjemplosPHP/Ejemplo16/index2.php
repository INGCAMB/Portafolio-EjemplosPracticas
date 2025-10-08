<HTML>
	<HEAD>
		<TITLE>Modificacion de Alumno por correo pagina 2</TITLE>
	</HEAD>
	<BODY>
		<H1>Modificacion de alumno</H1>
		<?PHP
			include "conexion.php"; //El archivo conexion debe estar en la misma carpeta si no tienes cambiar aqui la ruta
																							
			$registros=mysqli_query($conexion, "select * from alumnos where email='$_REQUEST[mail]'")
			or die("Problemas en el select:".mysqli_error($conexion));
			
			if ($reg=mysqli_fetch_array($registros))
			{
		?>
		<FORM action="index3.php" method="post">
			Nombre: <?PHP echo $reg['nombre']; ?> <BR>
			Ingrese nuevo correo:
			<INPUT type="text" name="mailnuevo" value="<?PHP echo $reg['email'] ?>"> 
			<BR>
			<INPUT type="hidden" name="mailviejo" value="<?PHP echo $reg['email'] ?>"> 
			<INPUT type="submit" name="Modificar">
		</FORM>
		<?PHP
			}
			else
			{
				echo "No existe un alumno con ese correo.";
			}
			mysqli_close($conexion);
		?>
		<BR><BR>
		<H3><A href="index.php">Regresar</A></H3>
	</BODY>
</HTML>