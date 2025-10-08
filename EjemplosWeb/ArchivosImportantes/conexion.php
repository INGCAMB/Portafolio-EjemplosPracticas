<?php
	//codigo para conectar a la bd
			$mysql_host = "";//servidor si es local se pone localhost
			$mysql_database="";
			$mysql_user=""; //root es local
			$mysql_password="";//en linea si hay password si no va vacio
			$conexion=mysqli_connect($mysql_host,$mysql_user,$mysql_password,$mysql_database)
				or die("Problemas en la conexion a la base de datos");//en caso de que no pueda conectarse
?>
