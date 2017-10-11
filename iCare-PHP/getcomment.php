<?php
    header("Content-Type: text/xml");

    $mysqli=new mysqli("localhost","root","******","iCare");
    
    if(mysqli_connect_errno()){
        printf("Connect failed:%s\n",mysqli_connect_error());
        exit();
    }
    
    $eventsid = $_GET["eventsid"];
    
    $mysqli->set_charset("utf8");
    $query="SELECT * FROM comments WHERE eventsid = " . $eventsid . " ORDER BY id DESC";
    //$result = $mysqli->query($query) or die("Invalid query:".mysql_error());    
    
    if($result = $mysqli->query($query))
    {

    //建立xml，声明版本和编码
    $dom = new DOMDocument("1.0","utf-8");
    
    //格式化输出
    $dom->formatOutPut = true;
    
    //建立根节点root
    $root = $dom->createElement("comments");
    $dom->appendChild($root);
    
     $dbtField = array("id","eventsid","username","content","time","reply");//数据表字段数组
    
    while($row = $result->fetch_row()){
        //建立root节点下的子节点record
        $record = $dom->createElement("comment");
        
        for($i =0; $i < 6; $i++) {
            //表字段
            $node = $dom->createElement($dbtField[$i]);
            //表字段的值
            $nodeText = $dom->createTextNode($row[$i]);
            $node->appendChild($nodeText);
            $record->appendChild($node);
        }
        $root->appendChild($record);
    }
    echo $dom->saveXML();
    }
    $mysqli->close();
   
    
    
?>
