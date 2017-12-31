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
        Human human = new Human { Name = "张三", Age = 12 };
        public MainWindow()
        {
            InitializeComponent();
            InitialData();
        }

        // 初始化数据
        private void InitialData()
        {
            List<Season> seasons = new List<Season>() { 
            new Season(){ Remark="春的魅力在于百花齐放", Name="春", Descript="春暖花开"},
            new Season(){ Remark="夏的魅力在于凉风习习", Name="夏", Descript="炎炎盛夏"},
            new Season(){ Remark="秋的魅力在于朗月当空", Name="秋", Descript="一叶知秋"},
            new Season(){ Remark="冬的魅力在于白雪皑皑", Name="冬", Descript="寒冬腊月"}
            };
            this.lbInfos.ItemsSource = seasons;

            // 后台代码设置绑定属性
            txtName.SetBinding(TextBlock.TextProperty, new Binding("Name") { Source = human });
            pnlStack.DataContext = human;
        }

        #region Binding

        private void ChangeButton_Click(object sender, RoutedEventArgs e)
        {
            human.Name = "兽人永不为奴！";
        }

        #endregion

        #region Dispatcher

        // Thread
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new Thread(() =>
            {
                txtContent.Text = "Thread";
            }).Start();
        }

        // Dispatcher 同步
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Dispatcher.Invoke(DispatcherPriority.ApplicationIdle, (ThreadStart)delegate()
            {
                Thread.Sleep(4000);
                txtContent.Text = "Dispatcher同步";
            });
        }

        // Dispatcher 异步
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            new Thread(() =>
            {
                Thread.Sleep(4000);
                this.Dispatcher.BeginInvoke(DispatcherPriority.ApplicationIdle, new Action(() =>
                {
                    txtContent.Text = "Dispatcher异步！！！";
                }));
            }).Start();
        }

        #endregion

        #region 事件

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

        #endregion
    }

    public class Human : INotifyPropertyChanged
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
                //触发事件
                if (PropertyChanged != null)
                {
                    PropertyChanged.Invoke(this, new PropertyChangedEventArgs("Name"));
                }
            }
        }
        public int Age { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }

    public class Season
    {
        public string Name { get; set; }
        public string Descript { get; set; }
        public string Remark { get; set; }
    }
}
