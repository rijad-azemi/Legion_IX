using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.NetworkInformation;

namespace Legion_IX.Helpers
{
    internal class NetworkListener
    {
        public static bool IsConnectedToNet()
        {

            if (NetworkInterface.GetIsNetworkAvailable())
            {

                foreach (var ni in NetworkInterface.GetAllNetworkInterfaces())
                {
                    if (ni.OperationalStatus == OperationalStatus.Up)
                    {

                        if ((ni.NetworkInterfaceType != NetworkInterfaceType.Tunnel) &&
                            (ni.NetworkInterfaceType != NetworkInterfaceType.Loopback))
                        {

                            IPInterfaceProperties properties = ni.GetIPProperties();

                            if (properties.GatewayAddresses.Count > 0)
                            {

                                Ping ping = new Ping();

                                PingReply reply = ping.Send(properties.GatewayAddresses[0].Address);

                                if (reply.Status == IPStatus.Success)
                                    return true;

                            }

                        }

                    }

                }

                return false;
            }

            return false;
        }

        public static event NetworkAvailabilityChangedEventHandler NetworkAvailabilityChanged
        {
            add { NetworkChange.NetworkAvailabilityChanged += value; }
            remove { NetworkChange.NetworkAvailabilityChanged -= value; }
        }

    }
}