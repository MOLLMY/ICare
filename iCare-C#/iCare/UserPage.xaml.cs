using System;
using System.Collections.Generic;
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
    /// 
    public sealed partial class UserPage : Page
        {
        public UserPage()
            {
            this.InitializeComponent();




            }

        public static string username;
        

        private void HomeBtn_Click(object sender, RoutedEventArgs e)
            {
            this.Frame.Navigate(typeof(MainPage));
            }

        private void FindBtn_Click(object sender, RoutedEventArgs e)
            {
            this.Frame.Navigate(typeof(FindPage));
            }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
            {
            this.Frame.Navigate(typeof(ReleasePage));
            }

        private void HandleBtn_Click(object sender, RoutedEventArgs e)
            {
            this.Frame.Navigate(typeof(HandlePage));
            }
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveBtn_Click(object sender, RoutedEventArgs e)
            {
            username = UserName.Text;
            
            HTTPMethod.SaveUserInfo(username, Phone.Text, Mail.Text,Address.Text, Infomation.Text, Major.Text);
            NotifyPopup OKNotifyPopup = new NotifyPopup("保存成功");
            OKNotifyPopup.Show();
            }
        }
    }
