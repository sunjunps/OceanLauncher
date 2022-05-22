using Newtonsoft.Json;
using OceanLauncher.Pages;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfWidgetDesktop.Utils;

namespace OceanLauncher.Utils
{
    public class GameHelper
    {
        SettingPage.CFG cfg;
        public GameHelper()
        {
            try
            {
                cfg = JsonConvert.DeserializeObject<SettingPage.CFG>(SettingProvider.Get(SettingPage.id));

            }
            catch
            {
                MessageBox.Show("无效的启动配置，请检查设置！");
            }
            finally
            {
                if (cfg == null)
                {
                    cfg = new SettingPage.CFG();

                }
            }
        }


        public void Start()
        {
            Process progress = new Process();
            progress.StartInfo = new ProcessStartInfo
            {
                FileName=cfg.Path,
                Arguments= GetArguments(),

            };
            try
            {
                progress.Start();

            }catch(Exception e)
            {
                MessageBox.Show(e.Message,"启动失败");

            }


        }


        private string GetArguments()
        {
            try
            {

                return $"-screen-height {cfg.Height}" +
                                    $" -screen-width {cfg.Width} {cfg.Args}";
            }
            catch
            {
                return "";
            }


        }
    }
}
