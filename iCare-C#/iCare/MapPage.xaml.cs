using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Devices.Geolocation;                                  //for Geolocator
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
    public sealed partial class MapPage : Page
        {
        //1.
        Geolocator geolocator = null;
        public MapPage()
            {
            this.InitializeComponent();
            this.NavigationCacheMode = NavigationCacheMode.Required;
            //创建一个Geolocator对象
            geolocator = new Geolocator();
            //设置地图的ServiceToken，如果要上传电子市场需要通过开发者账号获取
            myMap.MapServiceToken = "AuthenticationToken a3yFGsoZNlyBDSCkKtPS~KhCceQCVgZjRDj6QwP-R5g~AvLIGVlMTMg-Yq4u2fghkSa6DLZwZjrW98HpwDGbBBN-rJ4EH9orbhEtbok-Dj4D";
            }

        private async void getlocation_Click(object sender, RoutedEventArgs e)
            {
            try
                {
                //获取当前地理位置信息
                Geoposition pos = await geolocator.GetGeopositionAsync();
                //设置地图中心
                myMap.Center = pos.Coordinate.Point;
                //设置地图缩放级别
                myMap.ZoomLevel = 18;
                //纬度信息
                tbLatitude.Text = "纬度：" + pos.Coordinate.Point.Position.Latitude;
                //经度信息
                tbLongitude.Text = "经度：" + pos.Coordinate.Point.Position.Longitude;
                //精确性信息
                tbAccuracy.Text = "精确性：" + pos.Coordinate.Accuracy;
                }
            catch(System.UnauthorizedAccessException)
                {
                //服务被禁用异常
                tbLatitude.Text = "No data";
                tbLongitude.Text = "No data";
                tbLatitude.Text = "No data";
                }
           catch(System.Exception ee)
                {
                tbLongitude.Text = ee.ToString();
                }
            }
        }
    }
