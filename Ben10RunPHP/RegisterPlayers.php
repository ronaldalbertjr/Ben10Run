<?php
	require 'Queries.php';
	$user = $_POST['nicknamePost'];
	$senha = $_POST['passwordPost'];
	$email = $_POST['emailPost'];
	$xp = 0;
	$result = ExecuteQuery("INSERT INTO player (Nickname, Email, Senha, XP) VALUES ('$user','$email','$senha','$xp')");
?>