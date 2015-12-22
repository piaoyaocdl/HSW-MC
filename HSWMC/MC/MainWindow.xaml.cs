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
using MahApps.Metro.Controls;

namespace MC
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            Application.Current.MainWindow = this;
            shujuku.ShixiangjinduSet.RemoveRange(shujuku.ShixiangjinduSet.Where(x => x.shixiang == null));
            shujuku.ShixiangSet.RemoveRange(shujuku.ShixiangSet.Where(x => x.yuangong == null));
            shujuku.YuangongSet.RemoveRange(shujuku.YuangongSet.Where(x => x.bumen == null));

            Shuaxinshu();
        }

        private Shujuku shujuku = new Shujuku();
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

        public void Shuaxinshu()
        {
            shujuku.Dispose();
            shujuku = new Shujuku();
            shuUI.ItemsSource = null;

            var bumens = shujuku.BumenSet.ToList();
            List<TreeViewItem> shu = new List<TreeViewItem>();

            foreach (var bumen in bumens)
            {
                var bumenitem = new TreeViewItem();
                bumenitem.Header = bumen.bumenmingcheng;
                bumenitem.Tag = bumen;
                bumenitem.IsExpanded = true;
                
                var yuangongshu = new List<TreeViewItem>();
                foreach (var yuangong in bumen.yuangongs)
                {
                    var yuangongitem = new TreeViewItem();
                    yuangongitem.Header = yuangong.yuangongmingzi;
                    yuangongitem.Tag = yuangong;
                    yuangongshu.Add(yuangongitem);
                }
                bumenitem.ItemsSource = yuangongshu;

                shu.Add(bumenitem);
            }

            var xitongsheding = new TreeViewItem()
            {
                Header = "系统设定",
                IsExpanded = true,
                Tag = "系统设定",
                ItemsSource = new List<TreeViewItem>
                {
                     new TreeViewItem() { Header = "部门操作" ,Tag="系统设定_部门操作"}
                }
            };

            shu.Add(xitongsheding);

            shuUI.ItemsSource = shu;
        }

        private void MetroWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            shujuku.Dispose();
        }

        private void shuUI_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (!(e.NewValue is TreeViewItem))
            {
                return;
            }

            var tag = ((TreeViewItem)e.NewValue).Tag;

            if (tag is string)
            {
                var ls = (string)tag;
                switch (ls)
                {
                    case "系统设定_部门操作":
                        jiazaiqiUI.Content = new PAGE.SYST.Tianjiacaozuo.Bumencaozuo();
                        break;
                    default:
                        break;
                }
            }
            if (tag is PAGE.SYST.Tianjiacaozuo.YuangongSet)
            {
                var ls = (PAGE.SYST.Tianjiacaozuo.YuangongSet)tag;
                var gongzuopage = new PAGE.GONGZUOJIKU.Gongzuojilu();
                gongzuopage.yuangong = ls;
                gongzuopage.shujuku = shujuku;
                gongzuopage.yuangongmingziUI.Content = ls.yuangongmingzi;
                jiazaiqiUI.Content = gongzuopage;
            }
        }
    }
}
