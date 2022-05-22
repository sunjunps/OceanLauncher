using Microsoft.Toolkit.Mvvm.ComponentModel;
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
    /// ServerAddDialog.xaml 的交互逻辑
    /// </summary>
    public partial class ServerAddDialog : Page
    {
        VM vm = new VM();
        public ServerAddDialog()
        {
            InitializeComponent();
            DataContext = vm;
        }

        public class VM : ObservableObject
        {
            private ServerInfo _info=new ServerInfo();

            public ServerInfo Info
            {
                get { return _info; }
                set { SetProperty(ref _info, value); }
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            GlobalProps.frame.NavigationService.GoBack();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {


            GlobalProps.AddServer(vm.Info);



            GlobalProps.frame.NavigationService.GoBack();

        }
    }
}
