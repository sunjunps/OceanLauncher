using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
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
        }
    }

    public class ServerListVM : ObservableObject
    {
        public ICommand GoHome { get; set; }

        public ServerListVM()
        {
            GoHome = new RelayCommand(() =>
            {
                GlobalProps.NavigateTo(new Home());
            });
        }
    }
}
