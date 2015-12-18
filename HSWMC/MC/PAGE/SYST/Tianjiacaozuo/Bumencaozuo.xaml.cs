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



namespace MC.PAGE.SYST.Tianjiacaozuo
{
    /// <summary>
    /// Bumencaozuo.xaml 的交互逻辑
    /// </summary>
    public partial class Bumencaozuo : Page
    {
        public Bumencaozuo()
        {
            InitializeComponent();
            bumen_shujuyuan = shujuku.BumenSet.ToList();
        }

        private Shujuku shujuku = new Shujuku();

        private List<BumenSet> bumen_shujuyuan
        {
            set { bumenUI.ItemsSource = value; }
            get { return (List<BumenSet>)bumenUI.ItemsSource; }
        }

        private BumenSet xuanzedebumen
        {
            get
            {
                if (bumenUI.SelectedItem != null)
                {
                    return (BumenSet)bumenUI.SelectedItem;
                }
                return null;

            }
        }
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void bumenkongzhiUI_Tianjia_Click(object sender, RoutedEventArgs e)
        {
            var tianjiabumen = new Tianjiabumen();
            tianjiabumen.bumen = new BumenSet();
            tianjiabumen.ShowDialog();
            shujuku.BumenSet.Add(tianjiabumen.bumen);
            shujuku.SaveChanges();
            shujuku.Dispose();
            shujuku = new Shujuku();
            bumen_shujuyuan = shujuku.BumenSet.ToList();
            ((MainWindow)Application.Current.MainWindow).Shuaxinshu();
        }

        private async void bumenkongzhiUI_Xiugai_Click(object sender, RoutedEventArgs e)
        {
            if (xuanzedebumen==null)
            {
                await MahApps.Metro.Controls.Dialogs.DialogManager.ShowMessageAsync(((MainWindow)Application.Current.MainWindow), "提示", "请先选择部门！");
                return;
            }
            var tianjiabumen = new Tianjiabumen();
            tianjiabumen.bumen = xuanzedebumen;
            tianjiabumen.ShowDialog();
            shujuku.SaveChanges();
            bumen_shujuyuan = bumen_shujuyuan.ToList();
            ((MainWindow)Application.Current.MainWindow).Shuaxinshu();
        }

        private  async  void bumenkongzhiUI_Shanchu_Click(object sender, RoutedEventArgs e)
        {
            if (xuanzedebumen == null)
            {
                await MahApps.Metro.Controls.Dialogs.DialogManager.ShowMessageAsync(((MainWindow)Application.Current.MainWindow), "提示", "请先选择部门！");
                return;
            }
            shujuku.BumenSet.Remove(xuanzedebumen);
            shujuku.SaveChanges();
            shujuku.Dispose();
            shujuku = new Shujuku();
            bumen_shujuyuan = shujuku.BumenSet.ToList();
            ((MainWindow)Application.Current.MainWindow).Shuaxinshu();
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if ((bool)e.NewValue == false)
            {
                shujuku.Dispose();
            }
        }
    }
}
