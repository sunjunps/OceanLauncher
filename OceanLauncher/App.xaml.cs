using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Windows;
using WpfWidgetDesktop.Utils;

namespace OceanLauncher
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            SettingProvider.Init();

            ServicePointManager.ServerCertificateValidationCallback += (s, cert, chain, sslPolicyErrors) => true;

            base.OnStartup(e);
        }
        protected override void OnExit(ExitEventArgs e)
        {
            SettingProvider.Save();

            if (GlobalProps.controller != null)
            {
                GlobalProps.controller.Stop();

            }

            base.OnExit(e); 
        }
    }
}
