using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using Windows.Data.Xml.Dom;
using Windows.Storage;

namespace iCare
    {
    //HTTP服务类封装网络请求的方法
    public static class HTTPMethod
        {
        //首页显示信息
        public static string currentTime;
        public static string description;
        public static string state;
        public static string eventTitle;
        //其余信息
        public static string id;
        public static string latitude;
        public static string longitude;
        public static string location;
        public static string validity;
        public static string expectation;
        public static string image;//图片名
        //评论信息
        public static string commentID;
        public static string eventID;
        public static string userName;
        public static string comContext;
        public static string commentTime;
        public static string replyto;

        /// <summary>
        /// 上传事件信息
        /// </summary>
        /// <param name="title">标题</param>
        /// <param name="description">描述</param>
        /// <param name="location">位置</param>
        /// <param name="expectation">期望</param>
        /// <param name="validity">有效期</param>
        /// <param name="latitude">经纬度</param>
        /// <param name="longitude"></param>
        /// <param name="time">时间</param>
        /// <param name="image">图片名</param>
        public static void Save(string title, string description, string location, string expectation, string validity, string latitude, string longitude, string time, string image)
            {
            //设置URI
            string url = "http://118.190.89.123/iCare/save.php?title=" + title + "&time=" + time + "&latitude=" + latitude + "&longitude=" + longitude + "&description="
                + description + "&validity=" + validity + "&expectation=" + expectation + "&solved=0&location=" + location + "&image=" + image;
            //初始化新的HttpWebRequest对象
            WebRequest request = HttpWebRequest.Create(url);
            //设置为Get请求
            request.Method = "GET";
            //发起getresponse请求，必要，否则无效
            request.BeginGetResponse(SaveResponseCallback, request);
            }

        //请求回调方法
        private static void SaveResponseCallback(IAsyncResult result)
            {
            try
                {
                HttpWebRequest httpWebRequest = (HttpWebRequest)result.AsyncState;
                WebResponse webResponse = httpWebRequest.EndGetResponse(result);
                }
            catch (Exception ex)
                {
                NotifyPopup ErrorNotifyPopup = new NotifyPopup(ex.Message.ToString());
                ErrorNotifyPopup.Show();
                }
            }

        //修改事件的状态，也使用了GET,     没用
            public static void changeState(string id)
            {
            //设置URI
            string url = "http://118.190.89.123/iCare/solved.php?id=" + id+"&solved=2";
            //初始化新的HttpWebRequest对象
            WebRequest request = HttpWebRequest.Create(url);
            //设置为Get请求
            request.Method = "GET";
            //发起getresponse请求，必要，否则无效
            request.BeginGetResponse(GetResponseCallback, request);
            }

        /// <summary>
        ///  提交用户信息
        /// </summary>
        /// <param name="name">用户名</param>
        /// <param name="telephone">电话</param>
        /// <param name="email">邮件</param>
        /// <param name="address">地址</param>
        /// <param name="info">简介</param>
        /// <param name="specialize">特长</param>
        /// <param name="blacklist">黑名单</param>
        public static void SaveUserInfo(string name, string telephone, string email, string address, string info, string specialize)
            {
            //设置URI
            string url = "http://118.190.89.123/iCare/saveuser.php?name=" + name + "&tel=" + telephone + "&mail="
                + email +"&address=" + address +"&info="+info+"&specialize="+specialize+"&blacklist=0";
            //初始化新的HttpWebRequest对象
            WebRequest request = HttpWebRequest.Create(url);
            //设置为Get请求
            request.Method = "GET";
            //发起getresponse请求，必要，否则无效
            request.BeginGetResponse(GetResponseCallback, request);
            }


        /// <summary>
        /// 提交评论
        /// </summary>
        /// <param name="eventID">事件id</param>
        /// <param name="userName">用户名</param>
        /// <param name="content">评论内容</param>
        /// <param name="time">评论时间</param>
        /// <param name="reply">回复某用户，如果是回复的话</param>
        public static void SaveComment(string eventID, string userName, string content, string time, string reply)
            {
            //设置URI
            string url = "http://118.190.89.123/iCare/savecomment.php?eventsid=" + eventID + "&username=" + userName + "&content="
                + content + "&time=" + time + "&reply=" + reply;
            //初始化新的HttpWebRequest对象
            WebRequest request = HttpWebRequest.Create(url);
            //设置为Get请求
            request.Method = "GET";
            //发起getresponse请求，必要，否则无效
            request.BeginGetResponse(GetResponseCallback, request);
            }
        //请求回调方法，   没用
        private static void GetResponseCallback(IAsyncResult result)
            {
            HttpWebRequest httpWebRequest = (HttpWebRequest)result.AsyncState;
            WebResponse webResponse = httpWebRequest.EndGetResponse(result);
            }


        /// <summary>
        /// 将网络获取的事件信息转化成XML对象并显示，保存至本地文件
        /// </summary>
        public async static void LoadEventXML()
            {
            Uri uri = new Uri("http://118.190.89.123/iCare/get.php");
            //将网络获取的信息转化成XMLDoc对象！！！好用！
            XmlDocument doc = await XmlDocument.LoadFromUriAsync(uri);
            //获取根节点Events
            XmlElement events = doc.DocumentElement;
            //获取根节点的所有子节点列表
            XmlNodeList oneEventList = events.ChildNodes;
            //提示当前存在的事件数量
          //  NotifyPopup lackMesPopup = new NotifyPopup(oneEventList.Count.ToString());
          //  lackMesPopup.Show();
            //遍历二级节点
            try
                {             
                foreach(IXmlNode oneEvent in oneEventList)
                    {
                    XmlNodeList info = oneEvent.ChildNodes;
                    //获取XML文档的信息，先获取显示的
                    currentTime = info.Item(2).InnerText;
                    eventTitle = info.Item(1).InnerText;
                    description = info.Item(5).InnerText;
                    string solved = info.Item(8).InnerText;
                    if (solved == "0") state = "待处理";
                    else if (solved == "1") state = "已处理";
                    else state = "处理中";
                    //添加至首页
                    MainPage.AllEvents.Add(new Event { PortraitURI = "Portrait\\1-5.png", Name = "孙明鑫", Time = currentTime, Description = description, State = state, EventTitle = eventTitle });

                    //再获取其余的          
                    id = info.Item(0).InnerText;
                    latitude = info.Item(4).InnerText;
                    longitude = info.Item(5).InnerText;
                    location = info.Item(9).InnerText;
                    validity = info.Item(6).InnerText;
                    expectation = info.Item(7).InnerText;
                    image = info.Item(10).InnerText;
                    //为每个事件创建一个本地XML文件，在事件详情page中需要7个属性，一共有10个
                    //获取事件清单的文件夹对象
                    StorageFolder storage = await ApplicationData.Current.LocalFolder.GetFolderAsync("EventsList");
                    //创建一个XML对象
                    XmlDocument _doc = new XmlDocument();
                    //使用event来创建一个XML元素作为根节点
                    XmlElement _item = _doc.CreateElement("event");
                    _item.SetAttribute("id", id);
                    _item.SetAttribute("title", eventTitle);
                    _item.SetAttribute("currentTime", currentTime);
                    _item.SetAttribute("latitude", latitude);
                    _item.SetAttribute("longitude", longitude);
                    _item.SetAttribute("description", description);
                    _item.SetAttribute("validity", validity);
                    _item.SetAttribute("expectation", expectation);
                    _item.SetAttribute("solved", state);
                    _item.SetAttribute("location", location);
                    _item.SetAttribute("image", image);//图片名
                    _doc.AppendChild(_item);
                    //创建一个应用文件，如果已经存在那么就替换，使用 id+ 标题 作为文件名，也就是标识符
                    StorageFile file = await storage.CreateFileAsync(eventTitle + ".xml", CreationCollisionOption.ReplaceExisting);
                    //把XML中的信息保存到文件中去
                    await _doc.SaveToFileAsync(file);
                    }
                }
            catch(Exception ex)
                {
                NotifyPopup errorMesPopup = new NotifyPopup(ex.Message.ToString());
                errorMesPopup.Show();
                }
      
                
            }

        /// <summary>
        /// 从网络获取评论的信息
        /// </summary>
        /// <param name="eventID"></param>
        public async static void LoadCommentXML(string eventID)
            {
            try
            {
                string suri = "http://118.190.89.123/iCare/getcomment.php?eventsid=" + eventID;
                Uri uri = new Uri(suri);
                //将网络获取的信息转化成XMLDoc对象！！！好用！
                XmlDocument doc = await XmlDocument.LoadFromUriAsync(uri);
                //获取根节点Events
                XmlElement events = doc.DocumentElement;
                //获取根节点的所有子节点列表
                XmlNodeList oneEventList = events.ChildNodes;
                //NotifyPopup lackMesPopup = new NotifyPopup(oneEventList.Count.ToString());
                //lackMesPopup.Show();
                foreach (IXmlNode oneEvent in oneEventList)
                {
                    XmlNodeList info = oneEvent.ChildNodes;
                    commentID = info.Item(0).InnerText;
                    eventID = info.Item(1).InnerText;
                    userName = info.Item(2).InnerText;
                    comContext = info.Item(3).InnerText;
                    commentTime = info.Item(4).InnerText;
                    replyto = info.Item(5).InnerText;
                    //显示
                    if (replyto == "")
                    {
                        CommentPage.EventComment.Add(new Comment { PortraitURI = "Portrait\\1-5.png", Name = userName, context = comContext, time = commentTime });
                    }
                    else
                    {
                        CommentPage.EventComment.Add(new Comment { PortraitURI = "Portrait\\1-5.png", Name = userName, context = comContext, time = commentTime, reply = "回复 " + replyto });
                    }


                }
            }
            catch (Exception ex)
            {
                NotifyPopup errorMesPopup = new NotifyPopup(ex.Message.ToString());
                errorMesPopup.Show();
            }

        }

        ////获取用户信息
        //public async static void LoadUserXML(string eventID)
        //{
        //    string suri = "http://mollmy.com/iCare/getuser.php?username=孙明鑫";
        //    Uri uri = new Uri(suri);
        //    //将网络获取的信息转化成XMLDoc对象！！！好用！
        //    XmlDocument doc = await XmlDocument.LoadFromUriAsync(uri);
        //    //获取根节点Events
        //    XmlElement events = doc.DocumentElement;
        //    //获取根节点的所有子节点列表
        //    XmlNodeList oneEventList = events.ChildNodes;
        //    //NotifyPopup lackMesPopup = new NotifyPopup(oneEventList.Count.ToString());
        //    //lackMesPopup.Show();
        //    foreach (IXmlNode oneEvent in oneEventList)
        //    {
        //        XmlNodeList info = oneEvent.ChildNodes;
        //        commentID = info.Item(0).InnerText;
        //        eventID = info.Item(1).InnerText;
        //        userName = info.Item(2).InnerText;
        //        comContext = info.Item(3).InnerText;
        //        commentTime = info.Item(4).InnerText;
        //        replyto = info.Item(5).InnerText;
        //        //显示
        //        if (replyto == "")
        //        {
        //            CommentPage.EventComment.Add(new Comment { PortraitURI = "Portrait\\1-5.png", Name = userName, context = comContext, time = commentTime });
        //        }
        //        else
        //        {
        //            CommentPage.EventComment.Add(new Comment { PortraitURI = "Portrait\\1-5.png", Name = userName, context = comContext, time = commentTime, reply = "回复 " + replyto });
        //        }


        //    }

        //}
    }
    }
