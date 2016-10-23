<?php
	require 'config.php';
	
	function ExecuteQuery($query)
	{
		$connection = mysqli_connect(DB_HOSTNAME, DB_USERNAME, DB_PASSWORD, DB_DATABASE) or die(mysqli_connect_error());
		mysqli_set_charset($connection, 'utf8') or die(mysqli_error($connection)); 

		$result = mysqli_query($connection, $query); 

		mysqli_close($connection) or die(mysqli_error($connection));

		return $result;
	}
?>