using Newtonsoft.Json;
using SRH.NBS.Commen;
using System;
using System.Diagnostics;
using System.Globalization;
using System.IO.Ports;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;

namespace SRH.NBS.DataCollectorService
{
    public class UdpCollector : ICollector
    {
        private const int listenPort = 6000;
        private bool done = false;
        private UdpClient listener;
        private IPEndPoint groupEP;
        private SignalrClient realtimeHub;
        private SerialPort mySerialPort;

        public UdpCollector(SignalrClient realtimeHub)
        {
            this.realtimeHub = realtimeHub;
            listener = new UdpClient(listenPort);
            groupEP = new IPEndPoint(IPAddress.Any, listenPort);
            mySerialPort = new SerialPort();
        }
        public void Start()
        {
            try
            {
                mySerialPort.PortName = "COM4";
                mySerialPort.BaudRate = 9600;
                mySerialPort.Parity = Parity.None;
                mySerialPort.StopBits = StopBits.One;
                mySerialPort.DataBits = 8;
                mySerialPort.Handshake = Handshake.None;
                //               mySerialPort.WriteTimeout = 500;
                mySerialPort.Open();
                mySerialPort.DataReceived -= new SerialDataReceivedEventHandler(DataReceivedHandler);
                mySerialPort.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);


            }
            catch
            {
                mySerialPort.Close();

            }

            try
            {
                while (!done)
                {
                    Console.WriteLine("Waiting for broadcast");
                    byte[] bytes = listener.Receive(ref groupEP);
                    var jsonObj = Encoding.ASCII.GetString(bytes, 0, bytes.Length);
                    if (jsonObj != null)
                    {
                        var reciveObject = JsonConvert.DeserializeObject<HotLiquidTank>(jsonObj);
                        Console.WriteLine(reciveObject.Temperature);
                        Console.WriteLine(reciveObject.Volume);
                        if (realtimeHub.Connection.State == Microsoft.AspNet.SignalR.Client.ConnectionState.Connected)
                        {
                            realtimeHub.Hub.Invoke("PublishRealtimeBrewingData", jsonObj);
                            Console.WriteLine("Connection is upp!!");
                        }
                        else if (realtimeHub.Connection.State == Microsoft.AspNet.SignalR.Client.ConnectionState.Disconnected)
                        {
                            realtimeHub.Connection.Stop();
                            System.Threading.Thread.Sleep(500);
                            realtimeHub.Connection.Start();
                        }


                    }

                }

            }
            catch (Exception e)
            {
                Debug.WriteLine(e.ToString());
            }
            finally
            {
                listener.Close();
            }
        }

        private void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            var sp = (SerialPort)sender;
            Console.WriteLine("Data recived from serial");
            if (mySerialPort.IsOpen)
            {
                var reciveObject = sp.ReadLine();
                Console.WriteLine(reciveObject);
                reciveObject.Trim();
                string replacement = Regex.Replace(reciveObject, "\r", "");
                var textList = Regex.Split(replacement, "_");
                try
                {
                    foreach (var item in textList)
                    {
                        if (item.StartsWith("AmbTe"))
                        {

                            var value = double.Parse(item.Remove(0, 5), CultureInfo.InvariantCulture);

                            var tank = new HotLiquidTank() {Temperature = value, Volume=0 } ;
                            if (realtimeHub.Connection.State == Microsoft.AspNet.SignalR.Client.ConnectionState.Connected)
                            {
                                realtimeHub.Hub.Invoke("PublishRealtimeBrewingData", tank);
                                Console.WriteLine("Connection is upp!!");
                            }
                            else if (realtimeHub.Connection.State == Microsoft.AspNet.SignalR.Client.ConnectionState.Disconnected)
                            {
                                realtimeHub.Connection.Stop();
                                System.Threading.Thread.Sleep(500);
                                realtimeHub.Connection.Start();
                            }

                        }
                    }
                }
                catch
                {

                }



            }
        }

        public void Stopp()
        { }
    }
}
