<HTML>
	<HEAD>
		<TITLE>Problema de ciclos todos</TITLE>
		<META charset="utf-8">
	</HEAD>
	<BODY>
		<H1> Funcion Rand y Ciclos </H1>
		<BR>
		<H2> Con for </H2>
		<?PHP
			$num1=rand(0,10);
			
			for($cont1=0;$cont1<=$num1;$cont1++)
			{
				echo "$cont1, ";
			}
		?>
		<BR>
		<BR>
		<BR>
		<H2> Con while </H2>
		<?PHP
			$num2=rand(10,100);
			$cont2=10;
			while($cont2<$num2)
			{
				echo "$cont2, ";
				$cont2++;
			}
		?>
		<BR>
		<BR>
		<H2> Con Do while </H2>
		<?PHP
			$num3=rand(202,300);
			$cont3=200;
			do
			{
				echo "$cont3, ";
				$cont3++;
			}
			while($cont3<$num3);//do while lleva punto y coma
		?>
		<A href="index.php">Arreglo con for </A>
	</BODY>
</HTML>