using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;   //for ObservableCollection
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Data.Xml.Dom;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace iCare
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {   
        public static string eventID;
        //数据加载的标识
        public bool IsLoading = false;
        //线程锁的对象
        private object o = new object();
        //使用静态成员变量记录文件名
        public static string fileName = null;
        //创建数据源，绑定ObservableCollection<T>集合，说明是动态的
        public  static ObservableCollection<Event> AllEvents = new ObservableCollection<Event>();
        public MainPage()
        {
            this.InitializeComponent();
            //列表绑定ObservableCollection<T>集合
            eventListView.ItemsSource = AllEvents;
            }
        private void HomeBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }
        private void AddBtn_Click(object sender, RoutedEventArgs e)
            {
            this.Frame.Navigate(typeof(ReleasePage));
            }

        private void FindBtn_Click(object sender, RoutedEventArgs e)
            {
            this.Frame.Navigate(typeof(FindPage));
            }

        private void UserBtn_Click(object sender, RoutedEventArgs e)
            {
            this.Frame.Navigate(typeof(UserPage));
            }

        private void HandleBtn_Click(object sender, RoutedEventArgs e)
            {
            this.Frame.Navigate(typeof(HandlePage));
            }

        private void NavigateBtn_Click(object sender, RoutedEventArgs e)
            {
            this.Frame.Navigate(typeof(NavigatePage));
            //AllEvents.Add(new Event { PortraitURI = "Portrait\\1-7.png", Name = "朱伟", Time = "15:00", Description = "妹子们，最后说一次，只修电脑，不过夜！", State = "待处理" });
            }

        //页面加载事件的处理程序，获取文件的信息
        private  void Page_Loaded(object sender, RoutedEventArgs e)
            {
                //清空事件列表
                AllEvents.Clear();
                // 清空评论列表
                CommentPage.EventComment.Clear();

            //网络
            HTTPMethod.LoadEventXML();
            }
        //查看事件详细信息
        private async void hyperBtn_Click(object sender, RoutedEventArgs e)
            {
            StorageFile currentFile = null;
            //判断是否选中了列表项目
            if (eventListView.SelectedItem != null)
            {
                //把列表选项转换为集合实体类的对象
                Event selectedItem = eventListView.SelectedItem as Event;
               // eventID = selectedItem.id;
                //获取应用程序的本地存储文件
                StorageFolder storage = await ApplicationData.Current.LocalFolder.CreateFolderAsync("EventsList", CreationCollisionOption.OpenIfExists);
                var files = await storage.GetFilesAsync();
                    {
                    //获取事件清单文件夹里面存储的文件
                    foreach (StorageFile file in files)
                        {
                        //这里返回了多个file，我们的目标是只返回一个。      
                        //添加一个HyperLink到详细信息界面
                        if (file.DisplayName == selectedItem.EventTitle)
                        {
                            currentFile = file;
                            this.Frame.Navigate(typeof(DisplayEventPage), file);
                        }                            
                        }
                     }
                XmlDocument doc = await XmlDocument.LoadFromFileAsync(currentFile);
                eventID = doc.DocumentElement.Attributes.GetNamedItem("id").NodeValue.ToString();
                HTTPMethod.LoadCommentXML(eventID);
            }
        }

        //查看评论信息
        public async void Comment_Click(object sender, RoutedEventArgs e)
            {
            try
                {
                StorageFile currentFile = null;
                //判断是否选中了列表项目
                if (eventListView.SelectedItem != null)
                    {
                    //把列表选项转换为集合实体类的对象
                    Event selectedItem = eventListView.SelectedItem as Event;
                    //获取应用程序的本地存储文件
                    StorageFolder storage = await ApplicationData.Current.LocalFolder.CreateFolderAsync("EventsList", CreationCollisionOption.OpenIfExists);
                    var files = await storage.GetFilesAsync();
                        {
                        //获取事件清单文件夹里面存储的文件
                        foreach (StorageFile file in files)
                            {
                            //这里返回了多个file，我们的目标是只返回一个。      
                            //添加一个HyperLink到详细信息界面
                            if (file.DisplayName == selectedItem.EventTitle)
                                currentFile = file;
                            }
                        }
                    XmlDocument doc = await XmlDocument.LoadFromFileAsync(currentFile);
                    eventID = doc.DocumentElement.Attributes.GetNamedItem("id").NodeValue.ToString();
                    HTTPMethod.LoadCommentXML(eventID);
                    this.Frame.Navigate(typeof(CommentPage));

                    }
                }
            catch (Exception ex)
                {            
                NotifyPopup MesPopup = new NotifyPopup(ex.Message.ToString());
                MesPopup.Show();
                }
                
            }

        //选中了某个项目的话
        private void eventListView_Tapped(object sender, TappedRoutedEventArgs e)
        {

        }

       
    }
}
