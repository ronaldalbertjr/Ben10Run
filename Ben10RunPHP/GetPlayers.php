<?php 
	require 'queries.php';

	$result = ExecuteQuery("SELECT Nickname FROM player");

	if(mysqli_num_rows($result) > 0)
	{
		while ($row = mysqli_fetch_assoc($result)) 
		{
			echo '|'.$row['Nickname'];
		}
	}	
?>