<HTML>
	<HEAD>
		<TITLE>Captura de datos para alta en tabla alumnos</TITLE>
	</HEAD>
	<BODY>
		<FORM action="index2.php" method="post">
			Ingrese nombre:
			<INPUT type="text" name="nombre"><BR>
			Ingrese e-mail:
			<INPUT type="text" name="email"><BR>
			Seleccione curso:
			<SELECT name="codigocurso">
				<option value="1">PHP</OPTION>
				<option value="2">ASP</OPTION>
				<option value="3">JSP</OPTION>
			</SELECT>
			<BR>
			<INPUT type="submit" value="registrar">
		</FORM>
	</BODY>
</HTML>