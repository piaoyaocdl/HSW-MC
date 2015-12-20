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
using System.Windows.Shapes;
using MahApps.Metro.Controls;

namespace MC.PAGE.SYST.Tianjiacaozuo
{
    /// <summary>
    /// Tianjiabumen.xaml 的交互逻辑
    /// </summary>
    public partial class Tianjiayuangong : MetroWindow
    {
        public Tianjiayuangong()
        {
            InitializeComponent();
        }

        public YuangongSet yuangong
        {
            set { yuangongUI.DataContext = value; }
            get { return (YuangongSet)yuangongUI.DataContext; }
        }
       
    }
}
