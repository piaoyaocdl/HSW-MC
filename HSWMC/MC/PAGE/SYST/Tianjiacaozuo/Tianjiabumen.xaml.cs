﻿using System;
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
    public partial class Tianjiabumen : MetroWindow
    {
        public Tianjiabumen()
        {
            InitializeComponent();
        }

        public BumenSet bumen
        {
            set { bumenUI.DataContext = value; }
            get { return (BumenSet)bumenUI.DataContext; }
        }
    }
}
