<?php
    $mysqli=new mysqli("localhost","root","*******","iCare");    
    if(mysqli_connect_errno()){
        printf("Connect failed:%s\n",mysqli_connect_error());
        exit();
    }    
    $solved = $_GET["solved"];//是否解决
    $id = $_GET["id"];    
    
    $mysqli->set_charset("utf8");
    if($stmt = $mysqli->prepare("UPDATE events SET solved=? WHERE id=?"))
    {
        $stmt->bind_param("is",$solved,$id);
        //0表示未解决，1表示已解决，2表示解决中
        $stmt->execute();        
        $stmt->close();   
    }     
    $mysqli->close();    
?>
