<HTML>
	<HEAD>
		<TITLE>Consulta de registros de tabla alumnos</TITLE>
	</HEAD>
	<BODY>
		<?PHP
			include "conexion.php";
			$registros=mysqli_query($conexion,"select id,nombre,email,codigocurso from alumnos")
				or die("problemas en el select:".mysqli_error($conexion));
				
			while ($reg=mysqli_fetch_array($registros))//fetch array saca registros de uno por uno
			{
				echo "Identificador:".$reg['id']."<BR>";
				echo "Nombre:".$reg['nombre']."<BR>";
				echo "Correo:".$reg['email']."<BR>";
				echo "curso:";
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
				echo "<BR>";
				echo "<BR>";
			}
			mysqli_close($conexion);
		?>
		<BR><BR>
		<H3><A href="index2.php">otro alumno</A></H3>
	</BODY>
</HTML>