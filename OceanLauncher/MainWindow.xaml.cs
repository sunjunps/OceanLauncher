using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using Newtonsoft.Json;
using OceanLauncher.Pages;
using OceanLauncher.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfWidgetDesktop.Utils;

namespace OceanLauncher
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        MainVM vm = new MainVM();
        SettingPage.CFG cfg;
        readonly string id = "core.home";
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = vm;
            GlobalProps.NavigateTo = this.NavigateTo;
            GlobalProps.frame = frame;

            GlobalProps.SetServer = SetServer;

            LoadDataAsync();

            try
            {
                cfg = JsonConvert.DeserializeObject<SettingPage.CFG>(SettingProvider.Get(SettingPage.id));
            }
            catch
            {
            }
            finally
            {
                if (cfg == null)
                {
                    NavigateTo(new SettingPage());

                }
                cfg = new SettingPage.CFG();
            }


        }


        public void SetServer(ServerInfo si)
        {
            vm.ServerInfo = si;
            SettingProvider.SetNoSave(id, si);

            LoadDataAsync();
        }


        public async Task LoadDataAsync()
        {
            try
            {
                vm.ServerInfo = JsonConvert.DeserializeObject<ServerInfo>(SettingProvider.Get(id));
            }
            finally
            {
                if (vm.ServerInfo == null)
                {
                    vm.ServerInfo = new ServerInfo { IP="localhost:25565" };

                }
            }
            vm.ServerInfo =await ServerInfoGetter.GetAsync(vm.ServerInfo);
            DataContext = null;
            this.DataContext = vm;


        }




        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        public void NavigateTo(Page pg)
        {
            frame.Navigate(pg);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new SettingPage());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            //SettingProvider.Save();
            //if (GlobalProps.controller!=null)
            //{
            //    GlobalProps.controller.Stop();

            //}
            CloseAsync();
            //Close();
        }
        private async Task CloseAsync()
        {
            Storyboard closeStoryboard = (Storyboard)this.FindResource("WindowClose");
            closeStoryboard.Begin();
            await Task.Delay(200);
            Application.Current.Shutdown();
        }



        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            LoadDataAsync();

        }

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            var btn = sender as Button;
            btn.IsEnabled = false;
            if(GlobalProps.controller == null)
            {
                GlobalProps.controller = new GenshinImpact_Lanucher.Utils.ProxyController(cfg.Port, vm.ServerInfo.IP);


                GlobalProps.controller.Start();


                GameHelper helper = new GameHelper();
                helper.Start();

                btnText.Text = "终止代理";
                btnIcon.Text = "\xe71a";

            }
            else
            {
                GlobalProps.controller.Stop();
                GlobalProps.controller = null;

                btnText.Text = "加入游戏";
                btnIcon.Text = "\xe768";

            }
            btn.IsEnabled = true;


        }

        private void Border_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            //if (GlobalProps.controller == null)
            //{
            //GlobalProps.controller = new GenshinImpact_Lanucher.Utils.ProxyController(cfg.Port, vm.ServerInfo.IP);


            //GlobalProps.controller.Start();


            GameHelper helper = new GameHelper();
            helper.Start();

            //btnText.Text = "游戏已启动";
            //btnIcon.Text = "\xe71a";
            //}
            //else
            //{
            //    GlobalProps.controller.Stop();
            //    GlobalProps.controller = null;

            //    btnText.Text = "加入游戏";
            //    btnIcon.Text = "\xe768";

            //}
        }


        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            Process.Start("https://github.com/SwetyCore/OceanLauncher");

        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            Process.Start("https://github.com/SwetyCore/OceanLauncher");

        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            Process.Start("https://github.com/SwetyCore/OceanLauncher");

        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            Process.Start("https://github.com/SwetyCore/OceanLauncher");

        }
    }

    public class MainVM : ObservableObject
    {
        public ICommand OpenServerList { get; set; }

        public MainVM()
        {
            OpenServerList = new RelayCommand(() =>
              {
                  GlobalProps.NavigateTo(new ServerList());
              });
        }


        private ServerInfo _info;

        public ServerInfo ServerInfo
        {
            get { return _info; }
            set { SetProperty(ref _info, value); }
        }

    }

    public class LauncherCFG
    {
        
    }

}
