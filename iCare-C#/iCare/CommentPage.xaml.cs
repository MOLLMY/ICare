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
    public sealed partial class CommentPage : Page
        {
        public static ObservableCollection<Comment> EventComment = new ObservableCollection<Comment>();
        public string id = MainPage.eventID;
        public CommentPage()
            {
            this.InitializeComponent();
            commentListView.ItemsSource = EventComment;
            //foreach(Comment i in EventComment)
            //{
            //    if (i.reply != "")
            //        isReply.Visibility = Visibility.Visible;
            //}
            }
        //返回
        private void AppBarButton_Click(object sender, RoutedEventArgs e)
            {
            Frame.GoBack();
            }
        public static Comment reply;
        public string r;
        //点击发表评论
        private void sendBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(commentBox.Text))
                {
                    NotifyPopup lackMesPopup = new NotifyPopup("不能发表空评论！");
                    lackMesPopup.Show();
                    return;
                }

                string CurrentTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                string comment = commentBox.Text;
                if (r != "")
                {
                    comment = commentBox.Text.Replace(r, "");
                }


                HTTPMethod.SaveComment(id, "孙明鑫", comment, CurrentTime, reply.Name);
                NotifyPopup OKMesPopup = new NotifyPopup("评论成功！");
                OKMesPopup.Show();
                commentBox.Text = "";//清空发表评论框
                reply = null;
            }
            catch (Exception ex)
            {
                NotifyPopup errorMesPopup = new NotifyPopup(ex.Message.ToString());
                errorMesPopup.Show();
            }
        }
       
        //回复
        private void reply_Click(object sender, RoutedEventArgs e)
        {
            if (commentListView.SelectedItem != null)
            {
                commentBox.Text = "";
                reply = commentListView.SelectedItem as Comment;
                r = "回复 " + reply.Name + "：";
                commentBox.Text = r;
            }
           
        }

    }
    }
