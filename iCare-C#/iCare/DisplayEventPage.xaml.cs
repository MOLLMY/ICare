using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Data.Xml.Dom;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Graphics.Imaging;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace iCare
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public partial class DisplayEventPage : Page
    {
        public static string id;
        //public static ObservableCollection<Comment> EventComment = new ObservableCollection<Comment>();
        public DisplayEventPage()
        {
            this.InitializeComponent();

            //加载评论
            //commentListView.ItemsSource = EventComment;
        }

        //加载进来时显示事件详情
        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            //获取上一个清单列表传递过来的参数，该参数是一个StorageFile对象
            StorageFile file = e.Parameter as StorageFile;
            if (file == null) return;
            //获取文件的名字 
            String itemName = file.DisplayName;
            //把应用文件作为一个XML文档加载进来
            XmlDocument doc = await XmlDocument.LoadFromFileAsync(file);

            id = doc.DocumentElement.Attributes.GetNamedItem("id").NodeValue.ToString();
            titleBlock.Text = doc.DocumentElement.Attributes.GetNamedItem("title").NodeValue.ToString();
            timeBlock.Text = doc.DocumentElement.Attributes.GetNamedItem("currentTime").NodeValue.ToString();
            locationBlock.Text = "地点：" + doc.DocumentElement.Attributes.GetNamedItem("location").NodeValue.ToString();
            descriptionBlock.Text = "问题描述： " + doc.DocumentElement.Attributes.GetNamedItem("description").NodeValue.ToString();
            helpBlock.Text = "期望得到：" + doc.DocumentElement.Attributes.GetNamedItem("expectation").NodeValue.ToString();
            validityBlock.Text = "有效期至：" + doc.DocumentElement.Attributes.GetNamedItem("validity").NodeValue.ToString();
            // stateBlock.Text = doc.DocumentElement.Attributes.GetNamedItem("solved").NodeValue.ToString();
            string solved = doc.DocumentElement.Attributes.GetNamedItem("solved").NodeValue.ToString();
            string state = "";
            if (solved == "0") state = "待处理";
            else if (solved == "1") state = "已处理";
            else state = "处理中";
            stateBlock.Text = state;

            string imageName = doc.DocumentElement.Attributes.GetNamedItem("image").NodeValue.ToString();//图片名
            if (imageName != null)
            {
                //string url = "http://118.190.89.123/iCare/upload/" + imageName;

                photoImage.Visibility = Visibility.Visible;
                //从url获取图片
                //photoImage.Source = new BitmapImage(new Uri(imageName));

                StorageFile showFile = await StorageFile.GetFileFromPathAsync(imageName);
                using (IRandomAccessStream fileStream = await showFile.OpenAsync(Windows.Storage.FileAccessMode.Read))
                {
                    // Set the image source to the selected bitmap 
                    BitmapImage bitmapImage = new BitmapImage();
                    bitmapImage.DecodePixelWidth = 600; //match the target Image.Width, not shown
                    await bitmapImage.SetSourceAsync(fileStream);
                    photoImage.Source = bitmapImage;
                }

            }

        }

        //点击返回按钮
        private void AppBarButton_Click(object sender, RoutedEventArgs e)
            {
            this.Frame.GoBack();
            }
        //点击我要帮助他
        private void helpBtn_Click(object sender, RoutedEventArgs e)
            {
            HTTPMethod.changeState(id);//将该事件的solved改为2
            NotifyPopup OKNotifyPopup = new NotifyPopup("事件状态已改为处理中，请在规定时间内赶到TA身边");
            OKNotifyPopup.Show();
            }

        //点击发表评论
        private void sendBtn_Click(object sender, RoutedEventArgs e)
        {

            if (string.IsNullOrEmpty(commentBox.Text))
            {
                NotifyPopup lackMesPopup = new NotifyPopup("请添加评论！");
                lackMesPopup.Show();
                return;
            }
            string CurrentTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            HTTPMethod.SaveComment(id, "孙明鑫", commentBox.Text, CurrentTime, null);
            NotifyPopup OKMesPopup = new NotifyPopup("评论成功！");
            OKMesPopup.Show();
            commentBox.Text = "";//清空发表评论框


        }

    }
    }
