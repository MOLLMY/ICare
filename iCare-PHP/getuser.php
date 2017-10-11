<?php
    header("Content-Type: text/xml");
    $mysqli=new mysqli("localhost","root","chunjingyoumei","iCare");
    
    if(mysqli_connect_errno()){
        printf("Connect failed:%s\n",mysqli_connect_error());
        exit();
    }
    
    $userid = $_GET["userid"];//用户id    
    $mysqli->set_charset("utf8");    
    if($result = $mysqli->query("SELECT * FROM users WHERE id =".$userid))
    {
   
    //建立xml，声明版本和编码
    $dom = new DOMDocument("1.0","utf-8");    
    //格式化输出
    $dom->formatOutPut = true;    
    //建立根节点root
    $root = $dom->createElement("users");
    $dom->appendChild($root);    
    $dbtField = array("id","name","tel","mail","address","info","specialize","blacklist");//数据表字段数组
    
    while($row = $result->fetch_row()){
        //建立root节点下的子节点record
        $record = $dom->createElement("user");        
        for($i =0; $i < 8; $i++) {
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