using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ui
{
    /// <summary>
    /// MyButtom.xaml 的交互逻辑
    /// </summary>
    public partial class MyButtom : UserControl
    {
        public MyButtom()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("自定义按钮点击");
        }
    }
}
