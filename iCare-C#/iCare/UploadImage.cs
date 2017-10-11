using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using Windows.Networking.BackgroundTransfer;
using Windows.Storage.Streams;
using Windows.Storage;
using System.Net.Http;
using Windows.Web.Http;
using JyCloudTool;


namespace iCare
{
 
    class UploadImage
    {
        public static void HttpUploadImage(string Path)
        {
            String URL = "http://118.190.89.123/iCare/upload/";

            HttpUploadFile(URL, Path);
        }
        public  static string imageUri;//用于接收九幽传回的图片地址
        //文件名
        public static string FileName = null;
        ///时间戳
        public static string GetTimeStamp()
        {
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(ts.TotalSeconds).ToString();
        }



        private static async void HttpUploadFile(string URL, string Path)
        {

            HttpWebRequest _HttpWebRequest = WebRequest.Create(URL) as HttpWebRequest;
            //_HttpWebRequest.AllowAutoRedirect = true;

            _HttpWebRequest.Method = "POST";

            string Boundary = DateTime.Now.Ticks.ToString("X");//随机分隔线

            _HttpWebRequest.ContentType = "multipart/form-data;charset=utf-8;boundary=" + Boundary;

            byte[] ItemBoundaryBytes = Encoding.UTF8.GetBytes("\r\n--" + Boundary + "\r\n");
            byte[] EndBoundaryBytes = Encoding.UTF8.GetBytes("\r\n--" + Boundary + "--\r\n");

           // int Pos = Path.LastIndexOf("\\");//返回最后的反斜线 从0开始的的索引位置
                                             //string FileName = Path.Substring(Pos + 1);//文件名

            //修改文件名为时间戳
            FileName = GetTimeStamp() + ".jpg";

            //请求头部信息
            StringBuilder HeaderStringBuilder = new StringBuilder(string.Format("Content-Disposition:form-data;name=\"file\";filename=\"{0}\"\r\nContent-Type:application/octet-stream\r\n\r\n", FileName));
            byte[] PostHeaderBytes = Encoding.UTF8.GetBytes(HeaderStringBuilder.ToString());


            await Task.Run(async () =>
            {
                await Task.Yield();

                    //使用指定的路径、创建模式和读/写权限初始化 FileStream 类的新实例。
                    FileStream ReadFileStream = new FileStream(Path, FileMode.Open, FileAccess.Read);

                byte[] ContentBytes = new byte[ReadFileStream.Length];//要post的数据
                    ReadFileStream.Read(ContentBytes, 0, ContentBytes.Length);
                ReadFileStream.Dispose();

                Stream PostStream = await _HttpWebRequest.GetRequestStreamAsync();
                PostStream.Write(ItemBoundaryBytes, 0, ItemBoundaryBytes.Length);
                PostStream.Write(PostHeaderBytes, 0, PostHeaderBytes.Length);
                PostStream.Write(ContentBytes, 0, ContentBytes.Length);//内容
                    PostStream.Write(EndBoundaryBytes, 0, EndBoundaryBytes.Length);
                PostStream.Dispose();
            });

            
                //发送请求并获取响应回应数据
                HttpWebResponse _HttpWebResponse = await _HttpWebRequest.GetResponseAsync() as HttpWebResponse;
                //直到request.GetResponse()程序才开始向目标网页发送Post请求
                _HttpWebResponse.GetResponseStream();
                _HttpWebResponse.Dispose();
            
        }
    }
}
