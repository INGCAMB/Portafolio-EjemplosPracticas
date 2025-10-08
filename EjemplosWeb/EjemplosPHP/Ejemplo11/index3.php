<HTML>
	<HEAD>
		<TITLE>Funcion calcular</TITLE>
	</HEAD>
	<?PHP
			function calcular($a,$b,$op)
			{
				switch ($op)	{
				case "suma":
					$c=$a+$b;
					$d="$a + $b = $c";
					return $d;
					break;
				case "resta":
					$c=$a-$b;
					$d="$a - $b = $c";
					return $d;
					break;
				case "multi":
					$c=$a*$b;
					$d="$a x $b = $c";
					return $d;
					break;
				case "divi":
					$c=$a/$b;
					$d="$a / $b = $c";
					return $d;
					break;
				default:
					$d="no has elegido ninguna operación.";
					return $d;
				}
			}
		?>
	<BODY>
		<H1>Calculo con 4 numeros tomados de 2 en 2</H1>
		<H4>Calcularemos todos los posibles resultados la operacion que elijas, tomando los numeros de dos en dos</H4>
		<H4>Los numeros que escribas deben ser distintos de 0</H4>
			
		<FORM method="post" action="#">
			<P>Escribe 4 numeros:
				Primer numero:<INPUT type="text" size="3" maxlength="3" name="n1"/>...
				Segundo numero:<INPUT type="text" size="3" maxlength="3" name="n2"/>...
				Tercer numero:<INPUT type="text" size="3" maxlength="3" name="n3"/>...
				Cuarto numero:<INPUT type="text" size="3" maxlength="3" name="n4"/>...
			</P>
			<P>Calcular para estos numeros...
				<INPUT type="radio" name="op" value="suma"/>Suma...
				<INPUT type="radio" name="op" value="resta"/>Resta...
				<INPUT type="radio" name="op" value="multi"/>Multiplicacion...
				<INPUT type="radio" name="op" value="divi"/>Division...
			</P>
			<P><INPUT type="submit" value="mostrar resultados" /></P>
		</FORM>
		
		<P>
			<?PHP
				$n1=$_REQUEST['n1'];
				$n2=$_REQUEST['n2'];
				$n3=$_REQUEST['n3'];
				$n4=$_REQUEST['n4'];
				$op=$_REQUEST['op'];
				
				if($n1!=0 and $n2!=0 and $n3!=0 and $n4!=0)
				{
					echo "numeros: primero: $n1, segundo: $n2, tercero: $n3, cuarto: $n4 <br/>";
					$r1=calcular($n1,$n2,$op);
					echo "primero y segundo: $r1 <br/>";
					$r2=calcular($n1,$n3,$op);
					echo "primero y tercero: $r2 <br/>";
					$r3=calcular($n1,$n4,$op);
					echo "primero y cuarto: $r3 <br/>";
					$r4=calcular($n2,$n3,$op);
					echo "segundo y tercero: $r4 <br/>";
					$r5=calcular($n2,$n4,$op);
					echo "segundo y cuarto: $r5 <br/>";
					$r6=calcular($n3,$n4,$op);
					echo "Tercero y cuarto: $r6 <br/>";
				}
				else
				{
					echo "No me has dado dos numeros, o el valor de alguno de ellos es 0.";
				}
			?>
		</P>
		<BR>	
		<A href="index.php">Regresar a metodos </A>
	</BODY>
</HTML>