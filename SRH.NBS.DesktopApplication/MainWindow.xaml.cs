using Microsoft.AspNet.SignalR.Client;
using Newtonsoft.Json;
using SRH.NBS.Commen;
using SRH.NBS.DesktopApplication.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SRH.NBS.DesktopApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MainViewModel mvm;
        public MainWindow()
        {
            
            InitializeComponent();
            mvm = new MainViewModel();
            DataContext = mvm;
            var connectingUrl = @"http://" + "192.168.3.80" + ":9000/";
            var hubConnection = new HubConnection(connectingUrl);
            IHubProxy stockTickerHubProxy = hubConnection.CreateHubProxy("RealtimeBrewingData");
            stockTickerHubProxy.On<string>("ReciveRealtimeBrewingData", msg => mvm.Volume=ParceString(msg).AddedVolume.ToString());
            hubConnection.Start();
        }

        private HotLiquidTank ParceString (string jsonObject)
        {
            var ret = JsonConvert.DeserializeObject<HotLiquidTank>(jsonObject);
            return ret;
        }
    }
}
