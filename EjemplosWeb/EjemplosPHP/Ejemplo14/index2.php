<HTML>
	<HEAD>
		<TITLE>Recepcion de consulta de Alumnos por correo</TITLE>
	</HEAD>
	<BODY>
		<H1>Consulta de alumno</H1>
		<?PHP
			include "conexion.php"; //El archivo conexion debe estar en la misma carpeta si no tienes cambiar aqui la ruta
																							//condicion where			//si se usa comilla doble se cierra
			$registros=mysqli_query($conexion, "select id,nombre, codigocurso from alumnos where email='$_REQUEST[mail]'")//si se quieren mas filtros se usa coma
			or die("Problemas en el select:".mysqli_error($conexion));
			
			if ($reg=mysqli_fetch_array($registros))//saca un registro, el reg se convierte en arreglos que contiene los campos definidos en el query
			{//consulta especifica
				echo "Identificador:".$reg['id']."<BR>";
				echo "Nombre:".$reg['nombre']."<BR>";
				echo "Curso:";
				switch ($reg['codigocurso'])
				{
					case 1:
						echo "PHP";
						break;
					case 2:
						echo "ASP";
						break;
					case 3:
						echo "JSP";
						break;
				}
			}
			else
			{
				echo "No existe un alumno con ese correo.";
			}
			mysqli_close($conexion);
		?>
		<BR><BR>
		<H3><A href="index.php">Consultar Otro</A></H3>
	</BODY>
</HTML>