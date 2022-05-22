using GenshinImpact_Lanucher.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace OceanLauncher
{
    public static class GlobalProps
    {
        public delegate void navigateTo(Page pg);
        public static navigateTo NavigateTo;


        public delegate void addServer(ServerInfo si);
        public static addServer AddServer;

        public delegate void setServer(ServerInfo si);
        public static setServer SetServer;


        public static Frame frame;

        public readonly static string ServerListCfgID = "core.serverlist";

        public static ProxyController controller;


    }
    public class ServerInfo 
    {

        public string IP { get; set; }="127.0.0.1:25565";

        public string Name { get; set; } = "本地的服务器";

        public string AddTime { get; set; }

        public string timeout { get; set; } = "null";

        public string players { get; set; } = "null";

        public string ver { get; set; } = "null";
    }
}
