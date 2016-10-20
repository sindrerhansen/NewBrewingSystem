using System;
using GalaSoft.MvvmLight;
using Microsoft.AspNet.SignalR.Client;
using SRH.NBS.Commen;
using System.Diagnostics;
using Newtonsoft.Json;

namespace SRH.NBS.DesktopApplication.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        SignalrClient realtimeHub;
        public MainViewModel()
        {
            realtimeHub = new SignalrClient("192.168.3.125");
            realtimeHub.Hub.On("OnRealtimeBrewingData", data => {
                var reciveObject = JsonConvert.DeserializeObject<HotLiquidTank>(data);
                Volume = reciveObject.Volume.ToString();
            });

        }
        private void ParceData(string data)
        {
            var reciveObject = JsonConvert.DeserializeObject<HotLiquidTank>(data);
            Volume = reciveObject.Volume.ToString();
        }
        private string volume;
        public string Volume {
            get { return volume; }
            set {
                volume = value;
                RaisePropertyChanged(()=>Volume);
                }
        }
    }
}