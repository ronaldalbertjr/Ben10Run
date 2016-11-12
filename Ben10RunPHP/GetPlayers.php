<?php 
	require 'Queries.php';
	$user = $_POST['nickname'];

	$result = ExecuteQuery("SELECT Senha FROM player WHERE '$user' = Nickname");

	if(mysqli_num_rows($result) > 0)
	{
		while ($row = mysqli_fetch_assoc($result)) 
		{
			echo $row['Senha'];
		}
	}	
?>