using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Devices.Geolocation;
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
    public sealed partial class NavigatePage : Page
        {
        // Geolocator geolocator = null;
        public NavigatePage()
            {
            this.InitializeComponent();
           //创建一个Geolocator对象
           // geolocator = new Geolocator();
            }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
            {
            this.Frame.GoBack();
            }

        private async void LocateBtn_Click(object sender, RoutedEventArgs e)
            {
            try
                {
                //获取当前地理位置信息
               // Geoposition pos = await geolocator.GetGeopositionAsync();
                //Location loca = new Location(pos.Coordinate.Point.Position.Longitude.ToString(), pos.Coordinate.Point.Position.Latitude.ToString());
                //IEnumerable<string> location = new IEnumerable<string>()
                await NavigateWebView.InvokeScriptAsync("theLocation", null);
                }
            catch (System.UnauthorizedAccessException)
                {

                }
            catch (System.Exception ee)
                {

                }
            }
        //使用异步方式实现，C#与JS交互
        private async void SearchLineBtn_Click(object sender, RoutedEventArgs e)
            {
            await NavigateWebView.InvokeScriptAsync("Navigation", null);
            }
        }
    public class Location:IEnumerable<string>
        {
            public string longtitude { get; set; }
            public string latitude { get; set; }
            public Location(string longT,string laT)
            {
            this.longtitude = longT;
            this.latitude = laT;
            }

        IEnumerator<string> IEnumerable<string>.GetEnumerator()
            {
            throw new NotImplementedException();
            }

        IEnumerator IEnumerable.GetEnumerator()
            {
            throw new NotImplementedException();
            }
        }
    }
