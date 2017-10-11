using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;    //使用INotifyPropertyChanged接口需要的命名空间

namespace iCare
    {
    public class Event    // : INotifyPropertyChanged
        {
        //id
        public string id { get; set; }
        //用户头像地址
        public string PortraitURI { get; set; }
        //用户名
        public string Name { get; set; }
        //发布时间
        public string Time { get; set; }
        //事件图片地址
        public string EventURI { get; set; }
        //事件描述
        public string Description { get; set; }
        //事件状态
        public string State { get; set; }
        //评论数
        public int CommentNum { get; set; } 
        //关注人数
        public int FocusNum { get; set; }
        //事件标题
        public string EventTitle { get; set; }
        //声明事件
        public event PropertyChangedEventHandler PropertyChanged;
        //创建OnProPertyChanged方法
        protected void OnPropertyChanged(string option)
            {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                {
                handler(this, new PropertyChangedEventArgs(option));
                }
            }

        }
    }
