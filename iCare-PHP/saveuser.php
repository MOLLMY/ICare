<?php
    $mysqli=new mysqli("localhost","root","chunjingyoumei","iCare");   
    if(mysqli_connect_errno()){
        printf("Connect failed:%s\n",mysqli_connect_error());
        exit();
    }
    //$id = $_GET["id"];
    $name = $_GET["name"];
    $tel = $_GET["tel"];
    $mail = $_GET["mail"];
    $address = $_GET["address"];//地址
    $info = $_GET["info"];
    $specialize = $_GET["specialize"];//擅长
    $blacklist = $_GET["blacklist"];//黑名单

    $mysqli->set_charset("utf8");
   if($stmt = $mysqli->prepare("INSERT INTO users VALUES(null,?,?,?,?,?,?,?)"))
   {
        $stmt->bind_Param("sssssss",$name,$tel,$mail,$address,$info,$specialize,$blacklist);
        $stmt->execute();
        $stmt->close();    
   }   
    $mysqli->close();     
?>