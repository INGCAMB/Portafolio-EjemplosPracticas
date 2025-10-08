<HTML>
	<HEAD>
		<TITLE>Alta de alumno consultando otra tabla</TITLE>
	</HEAD>
	<BODY>
		<H1>Alta de alumno consultando tabla cursos</H1>
		<FORM action="index2.php" method="post">
			Ingrese nombre:
			<INPUT type="text" name="nombre"><BR>
			Ingrese correo:
			<INPUT type="text" name="mail"><BR>
			Seleccione el curso:
			<SELECT name="codigocurso">
			<?PHP
				//incluir la conexion desde una carpeta antes
				include "conexion.php";
				//ES UNA CONSULTA COMO EN EL EJEMPLO 13 PERO PONIENDO LA INFO EN COMBOBOX
				$registros=mysqli_query($conexion,"select id_curso,nombrecurso from cursos")
					or die("Problemas en el select:".mysqli_error($conexion));
				while ($reg=mysqli_fetch_array($registros))
				{
					echo "<OPTION value=\"$reg[id_curso]\">$reg[nombrecurso]</OPTION>";
				}
				mysqli_close($conexion);
			?>
			</SELECT>
			<BR>
			<INPUT type="submit" value="Registrar">
		</FORM>
	</BODY>
</HTML>