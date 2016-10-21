using GalaSoft.MvvmLight;
using Microsoft.AspNet.SignalR.Client;
using SRH.NBS.Commen;
using Newtonsoft.Json;

namespace SRH.NBS.DesktopApplication.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {


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