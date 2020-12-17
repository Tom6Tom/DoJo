using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace case04
{
    class MainWindowViewModel : INotifyPropertyChanged
    {
        private MainWindow _mwnd;
        private string _text = "";
        public event PropertyChangedEventHandler PropertyChanged;
        public string InputText
        {
            set
            {
                _text = value;
                RaisePropertyChanged();
                RaisePropertyChanged(nameof(ReturnText));
            }
            get
            {
                return _text;
            }
        }
        public string ReturnText => _text.ToUpper();
        private void RaisePropertyChanged([CallerMemberName] string propertyName = null)
    => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        public MainWindowViewModel() { }
        public MainWindowViewModel(MainWindow mwnd)
        {
            _mwnd = mwnd;
        }
    }
}
