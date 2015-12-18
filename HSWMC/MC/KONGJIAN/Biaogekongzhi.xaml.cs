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

namespace MC.KONGJIAN
{
    /// <summary>
    /// Biaogekongzhi.xaml 的交互逻辑
    /// </summary>
    public partial class Biaogekongzhi : UserControl
    {
        public Biaogekongzhi()
        {
            InitializeComponent();
        }

        public event RoutedEventHandler Tianjia_Click;
        public event RoutedEventHandler Xiugai_Click;
        public event RoutedEventHandler Shanchu_Click;

        private void tianjiaUI_Click(object sender, RoutedEventArgs e)
        {
            if (Tianjia_Click!=null)
            {
                Tianjia_Click(sender,e);
            }
        }

        private void xiugaiUI_Click(object sender, RoutedEventArgs e)
        {
            if (Xiugai_Click != null)
            {
                Xiugai_Click(sender, e);
            }
        }

        private void shanchuUI_Click(object sender, RoutedEventArgs e)
        {
            if (Shanchu_Click != null)
            {
                Shanchu_Click(sender, e);
            }
        }
    }
}
