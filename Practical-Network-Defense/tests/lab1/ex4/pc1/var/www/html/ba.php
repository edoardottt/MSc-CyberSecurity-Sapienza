<?php

$realm = 'Practical Network Defense - Sapienza';

if (!isset($_SERVER['PHP_AUTH_USER']) || $_COOKIE["login"]=="False"	) {
    header('WWW-Authenticate: Basic realm="'.$realm.'"');
    header('HTTP/1.0 401 Unauthorized');
    setcookie("login","True",time()+300);
    die('Restricted area: only authenticated users can access.');	
}

if ($_SERVER['PHP_AUTH_USER']!='angelo' || $_SERVER['PHP_AUTH_PW'] !='angsp') {
    header('WWW-Authenticate: Basic realm="'.$realm.'"');
    header('HTTP/1.0 401 Unauthorized');
    die('Restricted area: only authenticated users can access.');	
}
echo "<html>";
echo "<p>Welcome {$_SERVER['PHP_AUTH_USER']}.</p>";
echo "<p>You entered the right password.</p>";
echo <<< EOT
<script>
function logout(){
	 document.cookie="login=False";
	 location.href = "ba.php";
}
</script>
<p>
<button onclick="logout()">Log out</button>
</p>
</html>
EOT;
?>

