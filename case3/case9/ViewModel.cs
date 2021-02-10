using System.Collections.ObjectModel;
using System.ComponentModel;

namespace case9
{
    internal class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string _text;
        public string Text
        {
            set
            {
                if (_text != value)
                {
                    _text = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Text)));
                    Expression = _text.ToUpper();
                    DeleteRowCommand.RaiseCanExecuteChanged();
                }
            }
            get
            {
                return _text;
            }
        }

        private string _expression;
        public string Expression
        {
            set
            {
                if (_expression != value)
                {
                    _expression = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Expression)));
                }
            }
            get
            {
                return _expression;
            }
        }
        private DelegateCommand _addRowCommand;
        public DelegateCommand AddRowCommand
        {
            get
            {
                return _addRowCommand ??= new DelegateCommand(
                    _ => Text = string.Empty,
                    _ => !string.IsNullOrEmpty(Text)
                );
            }
        }
        private DelegateCommand _deleteRowCommand;
        public DelegateCommand DeleteRowCommand
        {
            get
            {
                return _deleteRowCommand??= new DelegateCommand(
                    _ => Text = string.Empty,
                    _ => !string.IsNullOrEmpty(Text)
                );
            }
        }

        public ObservableCollection<GridDataViewModel> GridData
        {
            get; set;
        } = new ObservableCollection<GridDataViewModel>()
        {
            new GridDataViewModel() { ID = 1, Name = "Tarou Suzuki", Sex = SexType.Male },
            new GridDataViewModel() { ID = 2, Name = "鈴木 次郎", Sex = SexType.Other },
        };
        public enum SexType
            {
                Male,
                Female,
                Other,
                DeclineToAnswer,
            }
        public class GridDataViewModel 
        {
            private int _id;
            public int ID
            {
                get { return _id; }
                set { _id = value; }
            }

            private string _name;
            public string Name
            {
                get { return _name; }
                set { _name = value; }
            }
            
            private SexType _sexType;
            public SexType Sex
            {
                get { return _sexType; }
                set { _sexType = value; }
            }
        }
    }
}
