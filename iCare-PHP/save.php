<?php
    $mysqli=new mysqli("localhost","root","chunjingyoumei","iCare");   
    if(mysqli_connect_errno()){
        printf("Connect failed:%s\n",mysqli_connect_error());
        exit();
    }
  
    $title = $_GET["title"];
    $time = $_GET["time"];
    $latitude = $_GET["latitude"];//经度
    $longitude = $_GET["longitude"];//纬度
    $description = $_GET["description"];//描述
    $validity = $_GET["validity"];//有效期
    $expectation = $_GET["expectation"];//希望得到的帮助
    $solved = $_GET["solved"];
    $location = $_GET["location"];//位置描述
    $image = $_GET["image"];

    $mysqli->set_charset("utf8");
   if($stmt = $mysqli->prepare("INSERT INTO events VALUES(null,?,?,?,?,?,?,?,?,?,?)"))
   {
        $stmt->bind_Param("sssssssiss",$title,$time,$latitude,$longitude,$description,$validity,$expectation,$solved,$location,$image);
        $stmt->execute();
        $stmt->close();    
   }   
    $mysqli->close();     
?>