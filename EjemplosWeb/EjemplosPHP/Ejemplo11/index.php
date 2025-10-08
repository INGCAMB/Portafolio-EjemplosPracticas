<HTML>
	<HEAD>
		<TITLE>Problema de metodo en php</TITLE>
		<META charset="utf-8">
		<?PHP
			function mensajecentrado($men)
			{
				echo "<table width=\"100%\" border=\"1\">";//se pone la diagonal para que no truene el codigo
				echo "<tr><td align=\"center\">";//Se puede usar codigo html en el echo
				echo $men;//mas de un parametro se separa con codigo
				echo "</tr></td>";
				echo "</table>";
			}
		?>
	</HEAD>
	<BODY>
		<?PHP
			mensajecentrado("Primer recuadro");
			echo "<BR>";
			mensajecentrado("Segundo recuadro");
		?>
		<BR>	
		<A href="index2.php">Funcion que retorna valor </A>
	</BODY>
</HTML>