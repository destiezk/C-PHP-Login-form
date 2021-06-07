<?php
require_once "config.php";

ini_set('display_errors', 1);
ini_set('display_startup_errors', 1);
error_reporting(E_ALL);

$username = $_GET['username'];
$password = $_GET['password'];

if (empty($_GET['username'] || !$_GET['password'])) die ('Not given parameter.');

check($username, $password);

function check($username, $password)
{
	global $con;

	if (!($stmt = mysqli_prepare($con, "SELECT * FROM `database_name` WHERE username = ?"))) 
	    {
	        echo "<center>Prepare_update failed: (" . $con->errno . ") " . $con->error;
	    }
		    $stmt->bind_param("s", $username);
		    $stmt->execute(); 
		    $result = $stmt->get_result();
		    $row = $result->fetch_assoc();

	if ($result->num_rows < 1)
    {
        die('0'); // Not existing user.
    }
    else
    { 
        if (strcmp($row['password'], $password) == 0)
        {
            die('1'); // Successful login.
		}
		else
		{
			die('2'); // Wrong password.
		}
	}
}

?>
