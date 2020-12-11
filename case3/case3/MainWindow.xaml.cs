using System.Windows;

namespace case3
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel(this);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //_lb1.Content = $"Hello {_tb1.Text}";
        }
    }
}
