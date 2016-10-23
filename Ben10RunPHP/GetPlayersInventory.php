<?php
	require 'queries.php';

	$result = ExecuteQuery("SELECT AlienID FROM caixadecapsulas INNER JOIN player ON (caixadecapsulas.Nickname = player.Nickname) WHERE player.Nickname = 'jupotengy'");
	echo "Aliens da potengy: ";
	if(mysqli_num_rows($result) > 0)
	{
		while ($row = mysqli_fetch_assoc($result)) 
		{
			$alienID =  $row['AlienID'];
			$resulty = ExecuteQuery("SELECT Nome FROM aliens INNER JOIN caixadecapsulas ON (aliens.ID = caixadecapsulas.AlienID) WHERE aliens.ID = '$alienID'");
			
			if(mysqli_num_rows($resulty) > 0)
			{
				while($row = mysqli_fetch_assoc($resulty))
				{
					echo '|'.$row['Nome'];
				}	
			}
		}
	}

	echo '<br>';


	$result = ExecuteQuery("SELECT ItemID FROM mochila INNER JOIN player ON (mochila.Nickname = player.Nickname) WHERE player.Nickname = 'jupotengy'");
	echo "Itens da potengy: ";
	if(mysqli_num_rows($result) > 0)
	{
		while ($row = mysqli_fetch_assoc($result)) 
		{
			$itemID =  $row['ItemID'];
			$resulty = ExecuteQuery("SELECT Nome FROM itens INNER JOIN mochila ON (itens.ID = mochila.ItemID) WHERE itens.ID = '$itemID'");
			
			if(mysqli_num_rows($resulty) > 0)
			{
				while($row = mysqli_fetch_assoc($resulty))
				{
					echo '|'.$row['Nome'];
				}	
			}
		}
	}					

?>