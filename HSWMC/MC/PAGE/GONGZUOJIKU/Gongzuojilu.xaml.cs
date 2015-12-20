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

namespace MC.PAGE.GONGZUOJIKU
{
    /// <summary>
    /// Gongzuojilu.xaml 的交互逻辑
    /// </summary>
    public partial class Gongzuojilu : Page
    {
        public Gongzuojilu()
        {
            InitializeComponent();
            
        }

        public Shujuku shujuku { set; get; }
        public PAGE.SYST.Tianjiacaozuo.YuangongSet yuangong { set; get; }
        private List<ShixiangSet> shixiang_shujuyuan
        {
            set { shixiangUI.ItemsSource = value; }
            get { return (List<ShixiangSet>)shixiangUI.ItemsSource; }
        }
        private List<ShixiangjinduSet> jindu_shujuyuan
        {
            set { shixiangjinduUI.ItemsSource = value; }
            get { return (List<ShixiangjinduSet>)shixiangjinduUI.ItemsSource; }
        }

        private ShixiangSet xuanzedeshixiang
        {
            get
            {
                if (shixiangUI.SelectedItem != null)
                {
                    return (ShixiangSet)shixiangUI.SelectedItem;
                }
                else
                {
                    return null;
                }
            }
        }
        private ShixiangjinduSet xuanzedejindu
        {
            get
            {
                if (shixiangjinduUI.SelectedItem != null)
                {
                    return (ShixiangjinduSet)shixiangjinduUI.SelectedItem;
                }
                else
                {
                    return null;
                }
            }
        }
        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void shixiangkongzhiUI_Tianjia_Click(object sender, RoutedEventArgs e)
        {
            var tianjiashixiang = new Tianjiashixiang();
            tianjiashixiang.shixiang = new ShixiangSet();
            tianjiashixiang.ShowDialog();
            yuangong.shixiangs.Add(tianjiashixiang.shixiang);
            shujuku.SaveChanges();
            shixiang_shujuyuan = yuangong.shixiangs.ToList();
        }

        private async  void shixiangkongzhiUI_Xiugai_Click(object sender, RoutedEventArgs e)
        {
            if (xuanzedeshixiang==null)
            {
                await MahApps.Metro.Controls.Dialogs.DialogManager.ShowMessageAsync(((MainWindow)Application.Current.MainWindow), "提示", "请先选择事项！");
                return;
            }
            var tianjiashixiang = new Tianjiashixiang();
            tianjiashixiang.shixiang = xuanzedeshixiang;
            tianjiashixiang.ShowDialog();
            shujuku.SaveChanges();
            shixiang_shujuyuan = yuangong.shixiangs.ToList();
        }

        private async  void shixiangkongzhiUI_Shanchu_Click(object sender, RoutedEventArgs e)
        {
            if (xuanzedeshixiang == null)
            {
                await MahApps.Metro.Controls.Dialogs.DialogManager.ShowMessageAsync(((MainWindow)Application.Current.MainWindow), "提示", "请先选择事项！");
                return;
            }
            shujuku.ShixiangSet.Remove(xuanzedeshixiang);
            shujuku.SaveChanges();
            shixiang_shujuyuan = yuangong.shixiangs.ToList();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            if (yuangong.shixiangs != null)
            {
                shixiang_shujuyuan = yuangong.shixiangs.Where(x=>x.yiwanjie!=true).ToList();
            }
        }

        private async void jindukongzhiUI_Tianjia_Click(object sender, RoutedEventArgs e)
        {
            if (xuanzedeshixiang == null)
            {
                await MahApps.Metro.Controls.Dialogs.DialogManager.ShowMessageAsync(((MainWindow)Application.Current.MainWindow), "提示", "请先选择事项！");
                return;
            }
            var tianjiajindu = new Tianjiajindu();
            var xinjindu = new ShixiangjinduSet();
            xinjindu.shijian = DateTime.Now;
            tianjiajindu.jindu = xinjindu;
            tianjiajindu.ShowDialog();
            xuanzedeshixiang.jindus.Add(xinjindu);
            shujuku.SaveChanges();
            jindu_shujuyuan = xuanzedeshixiang.jindus.ToList();

        }

        private async  void jindukongzhiUI_Xiugai_Click(object sender, RoutedEventArgs e)
        {
            if (xuanzedejindu == null)
            {
                await MahApps.Metro.Controls.Dialogs.DialogManager.ShowMessageAsync(((MainWindow)Application.Current.MainWindow), "提示", "请先选择进度！");
                return;
            }
            var tianjiajindu = new Tianjiajindu();
            tianjiajindu.jindu = xuanzedejindu;
            tianjiajindu.ShowDialog();
            shujuku.SaveChanges();
            jindu_shujuyuan = xuanzedeshixiang.jindus.ToList();
        }

        private async  void jindukongzhiUI_Shanchu_Click(object sender, RoutedEventArgs e)
        {
            if (xuanzedejindu == null)
            {
                await MahApps.Metro.Controls.Dialogs.DialogManager.ShowMessageAsync(((MainWindow)Application.Current.MainWindow), "提示", "请先选择进度！");
                return;
            }
            shujuku.ShixiangjinduSet.Remove(xuanzedejindu);
            jindu_shujuyuan = xuanzedeshixiang.jindus.ToList();
        }

        private void shixiangUI_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (xuanzedeshixiang!=null &&xuanzedeshixiang.jindus!=null)
            {
                jindu_shujuyuan = xuanzedeshixiang.jindus.ToList();
            }
        }

        private void guolvwanjieUI_Click(object sender, RoutedEventArgs e)
        {
            var guolv = (bool)((CheckBox)sender).IsChecked;
            if (guolv)
            {
                shixiang_shujuyuan = yuangong.shixiangs.Where(x => x.yiwanjie != true).ToList();
            }
            else
            {
                shixiang_shujuyuan = yuangong.shixiangs.ToList();

            }
        }
    }
}
