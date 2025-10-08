<HTML>
	<HEAD>
		<TITLE>Consulta de registros de tabla alumnos EN TABLA</TITLE>
	</HEAD>
	<BODY>
		<?PHP
			include "conexion.php"; //El archivo conexion debe estar en la misma carpeta si no tienes cambiar aqui la ruta
			$registros=mysqli_query($conexion,"select id,nombre,email,codigocurso from alumnos")
				or die("problemas en el select:".mysqli_error($conexion));
			?>	
			
			<TABLE border="1">
			<TR>
				<TH>Identificador</TH>
				<TH>Nombre</TH>
				<TH>Correo</TH>
				<TH>Curso</TH>
			</TR>
			<?PHP
				while ($reg=mysqli_fetch_array($registros))
			{
			?>
			<TR>
				<TD><?PHP echo $reg['id'];?></TD>
				<TD><?PHP echo $reg['nombre'];?></TD>
				<TD><?PHP echo $reg['email'];?></TD>
				<TD><?PHP
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
					?></TD>
			</TR>
			<?PHP
				}
				mysqli_close($conexion);
			?>
			</TABLE>
		<BR><BR>
		<H3><A href="index.php">Sin tabla</A></H3>
	</BODY>
</HTML>