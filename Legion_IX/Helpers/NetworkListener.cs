using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.NetworkInformation;
using MongoDB.Driver;

namespace Legion_IX.Helpers
{
    internal class NetworkListener
    {
        internal static string AtlasClusterConn_String = "mongodb+srv://AppUser777:itsMarioo@cluster0.m9qqpen.mongodb.net/?retryWrites=true&w=majority";

        public static bool IsConnectedToNet()
        {

            if (NetworkInterface.GetIsNetworkAvailable())
            {

                foreach (NetworkInterface ni in NetworkInterface.GetAllNetworkInterfaces())
                {
                    if (ni.OperationalStatus == OperationalStatus.Up)
                    {

                        if ((ni.NetworkInterfaceType != NetworkInterfaceType.Tunnel) &&
                            (ni.NetworkInterfaceType != NetworkInterfaceType.Loopback))
                        {

                            /*                            Ping checkIfClusterUp = new Ping();

                                                        try
                                                        {
                                                            PingReply clusterPingReply = checkIfClusterUp.Send(new Uri(AtlasClusterConn_String).Host);
                                                            return (clusterPingReply.Status == IPStatus.Success);
                                                        }

                                                        catch (Exception ex_statusFailed)
                                                        {
                                                            MessageBox.Show("Failed to ping Atlas Cluster! Check `URI`!", ex_statusFailed.Message, MessageBoxButtons.OK);
                                                        }*/

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