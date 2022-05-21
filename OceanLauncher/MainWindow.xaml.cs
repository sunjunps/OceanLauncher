using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using OceanLauncher.Pages;
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

namespace OceanLauncher
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        MainVM vm = new MainVM();
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = vm;
            GlobalProps.NavigateTo = this.NavigateTo;
        }


        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        public void NavigateTo(Page pg)
        {
            frame.Navigate(pg);
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
    }



}
