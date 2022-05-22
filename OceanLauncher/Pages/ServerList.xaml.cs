using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using Newtonsoft.Json;
using OceanLauncher.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using WpfWidgetDesktop.Utils;

namespace OceanLauncher.Pages
{
    /// <summary>
    /// ServerList.xaml 的交互逻辑
    /// </summary>
    public partial class ServerList : Page
    {
        ServerListVM vm = new ServerListVM();
        public ServerList()
        {
            InitializeComponent();
            DataContext = vm;



            GlobalProps.AddServer = AddServer;

        }

        public async Task CheckNetAsync()
        {
            for (int i = 0; i < vm.ServerList.Count; i++)
            {
                try
                {
                    vm.ServerList[i] = await ServerInfoGetter.GetAsync(vm.ServerList[i]);

                }
                catch
                {
                }




            }
            DataContext = null;
            DataContext = vm;
        }




        public void AddServer(ServerInfo si)
        {
            vm.ServerList.Add(si);
            SettingProvider.SetNoSave(GlobalProps.ServerListCfgID, vm.ServerList);

        }

        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            GlobalProps.NavigateTo(new ServerAddDialog());
        }

        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            var selected = lv.SelectedItem as ServerInfo;
            vm.ServerList.Remove(selected);

            SettingProvider.Set(GlobalProps.ServerListCfgID, vm.ServerList);
        }

        private void root_Loaded(object sender, RoutedEventArgs e)
        {
            CheckNetAsync();

        }
    }

    public class ServerListVM : ObservableObject
    {
        public ICommand GoHome { get; set; }
        public ICommand Delete { get; set; }
        public ServerListVM()
        {

            try
            {
                ServerList=JsonConvert.DeserializeObject<ObservableCollection<ServerInfo>>(SettingProvider.Get(GlobalProps.ServerListCfgID));
            }
            finally
            {
                if (ServerList == null)
                {
                    ServerList = new ObservableCollection<ServerInfo>();
                }
            }

            GoHome = new RelayCommand(() =>
            {
                GlobalProps.NavigateTo(new Home());
            });

            Delete = new RelayCommand<object>((o) =>
            {
                GlobalProps.SetServer(o as ServerInfo);
                GlobalProps.NavigateTo(new Home());
            });

        }



        private ObservableCollection<ServerInfo> _serverList;

        public ObservableCollection<ServerInfo> ServerList
        {
            get { return _serverList; }
            set 
            { 
                SetProperty(ref _serverList, value);
            }
        }

    }
}
