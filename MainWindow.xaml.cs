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
using System.Windows.Threading;

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DispatcherTimer m_timer_ = new DispatcherTimer();
        private Calculate m_calculator_ = new Calculate();

        // 每帧刷新的内容
        private void Timer_Tick(object sender, EventArgs e)
        {
            m_calculator_.DrawNumbers();
        }

        AnimationButton m_animation_;

        public MainWindow()
        {
            InitializeComponent();
            m_calculator_.RegisterLabel(label_result, label_symbol);

            m_animation_ = new AnimationButton(this);


            m_timer_.Interval = TimeSpan.FromMilliseconds(1000 / 144);
            m_timer_.Tick += Timer_Tick;
            m_timer_.Start();

        }

        private void Click_1(object sender, RoutedEventArgs e)
        {
            m_calculator_.PressNums("1");
        }

        private void Click_2(object sender, RoutedEventArgs e)
        {
            m_calculator_.PressNums("2");
        }

        private void Click_3(object sender, RoutedEventArgs e)
        {
            m_calculator_.PressNums("3");
        }

        private void Click_4(object sender, RoutedEventArgs e)
        {
            m_calculator_.PressNums("4");
        }

        private void Click_5(object sender, RoutedEventArgs e)
        {
            m_calculator_.PressNums("5");
        }

        private void Click_6(object sender, RoutedEventArgs e)
        {
            m_calculator_.PressNums("6");
        }

        private void Click_7(object sender, RoutedEventArgs e)
        {
            m_calculator_.PressNums("7");
        }

        private void Click_8(object sender, RoutedEventArgs e)
        {
            m_calculator_.PressNums("8");
        }

        private void Click_9(object sender, RoutedEventArgs e)
        {
            m_calculator_.PressNums("9");
        }

        private void Click_0(object sender, RoutedEventArgs e)
        {
            m_calculator_.PressNums("0");
        }

        private void Click_AC(object sender, RoutedEventArgs e)
        {
            m_calculator_.ClearAll();
        }

        private void Click_del(object sender, RoutedEventArgs e)
        {
            m_calculator_.PressedFunctionKeys("del");
        }

        private void Click_ChangeSymbol(object sender, RoutedEventArgs e)
        {
            m_calculator_.PressedFunctionKeys("+/-");
        }

        private void Click_Percent(object sender, RoutedEventArgs e)
        {
            m_calculator_.PressedFunctionKeys("%");
        }

        private void Click_Dot(object sender, RoutedEventArgs e)
        {
            if (label_result.Content == "")
                m_calculator_.PressNums("0.");
            else
                m_calculator_.PressNums(".");
        }

        private void Click_Add(object sender, RoutedEventArgs e)
        {
            m_calculator_.PressSymbol("+");
        }

        private void Click_Minus(object sender, RoutedEventArgs e)
        {
            m_calculator_.PressSymbol("-");
        }

        private void Click_Times(object sender, RoutedEventArgs e)
        {
            m_calculator_.PressSymbol("×");
        }

        private void Click_Divide(object sender, RoutedEventArgs e)
        {
            m_calculator_.PressSymbol("÷");
        }

        private void Click_Equal(object sender, RoutedEventArgs e)
        {
            m_calculator_.PressEqual();
        }
    }
}