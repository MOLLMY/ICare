using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace iCare
    {
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class FindPage : Page
        {
        public static ObservableCollection<Event> HotEvents = new ObservableCollection<Event>();
        public static ObservableCollection<Event> CoolEvents = new ObservableCollection<Event>();

        public FindPage()
            {
            this.InitializeComponent();
            hotEventListView.ItemsSource = HotEvents;
            HotEvents.Add(new Event { PortraitURI = "Portrait\\1-7.png", Name = "朱伟", Time = "15:00", Description = "有人篮球约战吗？今天去测绘球场了，一个能打的都没有，求SOLE", State = "待处理" });
            HotEvents.Add(new Event { PortraitURI = "Portrait\\1-11.png", Name = "蒋超", Time = "13:00", Description = "刚刚看到，街道口附近有儿童乞讨，请问应该怎么帮助他们？", State = "待处理" });
            HotEvents.Add(new Event { PortraitURI = "Portrait\\1-13.png", Name = "周杰伦", Time = "11:00", Description = "武大正门大堵车了，请交警速来疏通，另外准备开车经过这里的朋友就绕道吧。", State = "待处理" });
            HotEvents.Add(new Event { PortraitURI = "Portrait\\1-14.png", Name = "许嵩", Time = "12:00", Description = "请问那些小伙伴会摄影啊，学姐想约拍毕业照，费用私聊。", State = "待处理" });
            HotEvents.Add(new Event { PortraitURI = "Portrait\\1-15.png", Name = "发如雪", Time = "1:00", Description = "在图书馆没带伞啊啊啊啊，有没有信息学部的小伙伴可以一起回去的？", State = "待处理" });
            HotEvents.Add(new Event { PortraitURI = "Portrait\\1-16.png", Name = "托福", Time = "5:00", Description = "急急急！桂操又吃书包了，昨晚9点跑完步后书包就不见了，样子是碎花格子，有同学看到的话请联系15207114340，万分感谢！", State = "待处理" });

            coolEventListView.ItemsSource = CoolEvents;
            CoolEvents.Add(new Event { PortraitURI = "Portrait\\1-8.png", Name = "朱伟", Time = "15:00", Description = "在图书馆没带伞啊啊啊啊，有没有信息学部的小伙伴可以一起回去的？", State = "已处理" });
            CoolEvents.Add(new Event { PortraitURI = "Portrait\\1-999.png", Name = "蒋超", Time = "5:00", Description = "急急急！桂操又吃书包了，昨晚9点跑完步后书包就不见了，样子是碎花格子，有同学看到的话请联系15207114340，万分感谢！", State = "已处理" });
            CoolEvents.Add(new Event { PortraitURI = "Portrait\\2-1.png", Name = "刘志伟", Time = "12:00", Description = "请问那些小伙伴会摄影啊，学姐想约拍毕业照，费用私聊。", State = "已处理" });
            CoolEvents.Add(new Event { PortraitURI = "Portrait\\2-2.png", Name = "夜的第七章", Time = "13:00", Description = "有人篮球约战吗？今天去测绘球场了，一个能打的都没有，求SOLE", State = "已处理" });
            CoolEvents.Add(new Event { PortraitURI = "Portrait\\2-3.png", Name = "安详", Time = "17:00", Description = "武大正门大堵车了，请交警速来疏通，另外准备开车经过这里的朋友就绕道吧。", State = "已处理" });
            }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
            {
            this.Frame.Navigate(typeof(ReleasePage));
            }

        private void HomeBtn_Click(object sender, RoutedEventArgs e)
            {
            this.Frame.Navigate(typeof(MainPage));
            }

        private void UserBtn_Click(object sender, RoutedEventArgs e)
            {
            this.Frame.Navigate(typeof(UserPage));
            }

        private void HandleBtn_Click(object sender, RoutedEventArgs e)
            {
            this.Frame.Navigate(typeof(HandlePage));
            }
        }
    }
