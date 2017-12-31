using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace ui
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void menu_Click(object sender, RoutedEventArgs e)
        {
            menu1.IsOpen = true;
        }

        private void x_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ___Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }


        private void TabControl_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //MessageBox.Show("1");
            //Console.WriteLine("1");
            DoubleAnimation action = new DoubleAnimation();

        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TabControl tab = sender as TabControl;
            TabItem item = tab.SelectedItem as TabItem;
            string header = item.Header.ToString();
            switch (header)
            {
                case "":
                    break;
                default:
                    break;
            }

            // MessageBox.Show("1");
        }

    }

    public class Human
    {
        private string _Name;
        public string Name
        {
            get
            {
                return _Name;
            }
            set
            {
                _Name = value;
            }
        }
        public int Age { get; set; }
    }

    public class Season
    {
        public string Name { get; set; }
        public string Descript { get; set; }
        public string Remark { get; set; }
    }
}
