<?php
    $mysqli=new mysqli("localhost","root","chunjingyoumei","iCare");   
    if(mysqli_connect_errno()){
        printf("Connect failed:%s\n",mysqli_connect_error());
        exit();
    }
  
    $eventsid = $_GET["eventsid"];
    $username = $_GET["username"];
    $content = $_GET["content"]; 
    $time = $_GET["time"];  
    $reply = $_GET["reply"];
   
    $mysqli->set_charset("utf8");
   if($stmt = $mysqli->prepare("INSERT INTO comments VALUES(null,?,?,?,?,?)"))
   {
        $stmt->bind_Param("issss",$eventsid,$username,$content,$time,$reply);
        $stmt->execute();
        $stmt->close();    
   }   
    $mysqli->close();     
?>