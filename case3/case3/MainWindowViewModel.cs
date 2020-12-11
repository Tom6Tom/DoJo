using System.Windows.Input;

namespace case3
{
    class MainWindowViewModel : ViewModelBase
    {
        private string _text = "init";
        private MainWindow _mwnd;

        public ICommand QuitCommand { get; private set; }
        public ICommand ChangeTextType1Command { get; private set; }

        public string TextSample
        {
            set
            {
                _text = value;
                OnPropertyChanged();
            }
            get
            {
                return _text;
            }
        }

        public MainWindowViewModel() : this(null)
        { }

        public MainWindowViewModel(MainWindow mwnd)
        {
            _mwnd = mwnd;
            this.ChangeTextType1Command = new DelegateCommand(() => { TextSample = "Hello, " + _mwnd._tbx1.Text; });
        }
    }
}
