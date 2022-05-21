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
    }
}
