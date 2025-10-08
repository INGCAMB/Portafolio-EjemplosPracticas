<HTML>
	<HEAD>
	<TITLE>Ejemplo 7 formulario operaciones Combo Box</TITLE>
	</HEAD>
	<BODY>
		<FORM method="post" action="pagina2.php">
			Ingrese primer valor:
			<INPUT type="text" name="valor1">
			<BR>
			Ingrese segundo valor:
			<INPUT type="text" name="valor2">
			<BR>
			<SELECT name="operaciones">
				<OPTION value="suma">Sumar valores</OPTION>
				<OPTION value="resta">Restar valores</OPTION>
			</SELECT>
			<BR>
			<INPUT type="submit" value="operar">
		</FORM>
	</BODY>
</HTML>