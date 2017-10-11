using JyCloudTool.JsonModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Data.Xml.Dom;
using Windows.Devices.Geolocation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Graphics.Imaging;
using Windows.Media.FaceAnalysis;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.Storage.Streams;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Shapes;


// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace iCare
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ReleasePage : Page
    {
        Geolocator geolocator = null;
        public ReleasePage()
        {
            this.InitializeComponent();
            //创建一个Geolocator对象
            geolocator = new Geolocator();
            //设置地图的ServiceToken，如果要上传电子市场需要通过开发者账号获取
            //myMap.MapServiceToken = "AuthenticationToken a3yFGsoZNlyBDSCkKtPS~KhCceQCVgZjRDj6QwP-R5g~AvLIGVlMTMg-Yq4u2fghkSa6DLZwZjrW98HpwDGbBBN-rJ4EH9orbhEtbok-Dj4D";

            time.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            if (this.Frame.CanGoBack)
            {
                this.Frame.GoBack();
            }
        }

        ///点击发送
        private async void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            //验证各信息完整
            NotifyPopup lackMesPopup = new NotifyPopup("请完善信息！");
            if (string.IsNullOrEmpty(TitleBox.Text))
            {
                lackMesPopup.Show();
                return;
            }
            else if (string.IsNullOrEmpty(PlaceBox.Text))
            {
                lackMesPopup.Show();
                return;
            }
            else if (string.IsNullOrEmpty(DescriptionBox.Text))
            {
                lackMesPopup.Show();
                return;
            }
            else if (string.IsNullOrEmpty(HelpBox.Text))
            {
                lackMesPopup.Show();
                return;
            }

            try
            {

                //获取截止时间
                string Validity = ymd.Date.Date.Add(tt.Time).ToString("yyyy-MM-dd HH:mm:ss");
                //获取当前系统的时间，完整的时间和日期
                string CurrentTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                //获取当前地理位置信息
                Geoposition pos = await geolocator.GetGeopositionAsync();
                //纬度信息
                string latitude = pos.Coordinate.Point.Position.Latitude.ToString();
                //经度信息
                string longitude = pos.Coordinate.Point.Position.Longitude.ToString();

                //上传图片
                //UploadImage.HttpUploadImage(this.photoFile.Path);
                //string imageName = UploadImage.FileName;

                string imageName = this.photoFile.Path;
                //----------------------------↓九幽------------------------------//
                // UploadPicture();//九幽上传图片
               // string imageName = UploadImage.imageUri;
                //-----------------------------↑九幽-----------------------------//
                //将信息发送至服务器,成功！
                if (imageName != null)
                {
                    HTTPMethod.Save(TitleBox.Text, DescriptionBox.Text, PlaceBox.Text, HelpBox.Text, Validity, latitude, longitude, CurrentTime, imageName);
                    //显示发布成功信息框
                    NotifyPopup OKNotifyPopup = new NotifyPopup("发布成功");
                    OKNotifyPopup.Show();
                    //调回清单主页
                    this.Frame.Navigate(typeof(MainPage));
                }
                else
                {
                    //显示发布成功信息框
                    NotifyPopup OKNotifyPopup = new NotifyPopup("发布失败");
                    OKNotifyPopup.Show();
                }
            }
            catch (Exception ex)
            {
                //报异常
                NotifyPopup ErrorNotifyPopup = new NotifyPopup(ex.ToString());
                ErrorNotifyPopup.Show();
            }
        }
        public StorageFile photoFile = null;//记录图片位置

        /// <summary>
        /// 点击添加图片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void AddPhoto_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                FileOpenPicker photoPicker = new FileOpenPicker();
                photoPicker.ViewMode = PickerViewMode.Thumbnail;
                photoPicker.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
                photoPicker.FileTypeFilter.Add(".jpg");

                photoFile = await photoPicker.PickSingleFileAsync();//图片位置

                if (photoFile != null)
                {
                    PhotoCanvas.Visibility = Visibility.Visible;
                    //显示                    
                    using (IRandomAccessStream fileStream = await photoFile.OpenAsync(Windows.Storage.FileAccessMode.Read))
                    {
                        // Set the image source to the selected bitmap 
                        BitmapImage bitmapImage = new BitmapImage();
                        bitmapImage.DecodePixelWidth = 600; //match the target Image.Width, not shown
                        await bitmapImage.SetSourceAsync(fileStream);
                        PhotoCanvas.Source = bitmapImage;
                    }
                }
            }
            catch (Exception ex)
            {
                //this.ClearVisualization();
                NotifyPopup Error = new NotifyPopup(ex.ToString());
                Error.Show();
            }
        }
    }
}
