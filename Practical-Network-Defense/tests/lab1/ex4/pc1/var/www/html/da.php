
<?php
$realm = 'Practical Network Defense - Sapienza';

//user => password
$users = array('angelo' => 'angsp');

$heade = array('angsp' => 'angsp was here');


if (empty($_SERVER['PHP_AUTH_DIGEST']) || $_COOKIE["login"]=="False") {
    header('HTTP/1.1 401 Unauthorized');
    header('WWW-Authenticate: Digest realm="'.$realm.
           '",qop="auth",nonce="'.uniqid().'",opaque="'.md5($realm).'"');
    setcookie("login","True",time()+300);
    die('Restricted area: only authenticated users can access.');
}


// analyze the PHP_AUTH_DIGEST variable
if (!($data = http_digest_parse($_SERVER['PHP_AUTH_DIGEST'])) ||
    !isset($users[$data['username']]))
    {
    header('HTTP/1.1 401 Unauthorized');
    header('WWW-Authenticate: Digest realm="'.$realm.
           '",qop="auth",nonce="'.uniqid().'",opaque="'.md5($realm).'"');
	die('Wrong Credentials!');
}	   


// generate the valid response
$A1 = md5($data['username'] . ':' . $realm . ':' . $users[$data['username']]);
$A2 = md5($_SERVER['REQUEST_METHOD'].':'.$data['uri']);
$valid_response = md5($A1.':'.$data['nonce'].':'.$data['nc'].':'.$data['cnonce'].':'.$data['qop'].':'.$A2);

if ($data['response'] != $valid_response)
    die('Wrong Credentials!');

// ok, valid username & password
header('Assignment2-header: '.$heade[$data['username']]);
echo "<html>";
echo "<p>Welcome {$data['username']}.</p>";
echo "<p>You entered the right password.</p>";
echo <<< EOT
<script>
function logout(){
	 document.cookie="login=False";
	 location.href = "da.php";
}
</script>
<p>
<button onclick="logout()">Log out</button>
</p>
</html>
EOT;

// function to parse the http auth header
function http_digest_parse($txt)
{
    // protect against missing data
    $needed_parts = array('nonce'=>1, 'nc'=>1, 'cnonce'=>1, 'qop'=>1, 'username'=>1, 'uri'=>1, 'response'=>1);
    $data = array();
    $keys = implode('|', array_keys($needed_parts));

    preg_match_all('@(' . $keys . ')=(?:([\'"])([^\2]+?)\2|([^\s,]+))@', $txt, $matches, PREG_SET_ORDER);

    foreach ($matches as $m) {
        $data[$m[1]] = $m[3] ? $m[3] : $m[4];
        unset($needed_parts[$m[1]]);
    }

    return $needed_parts ? false : $data;
}
?>

