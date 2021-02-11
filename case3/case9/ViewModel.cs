using System.Collections.ObjectModel;

namespace case9
{
    internal class ViewModel
    {
        private DelegateCommand _addRowCommand;
        public DelegateCommand AddRowCommand
        {
            get
            {
                return _addRowCommand ??=
                    new DelegateCommand(
                        // TBD 入力ダイアログ
                        () => { GridData.Add(new GridDataViewModel() { ID = -1, Name = "初期値 三郎", Gender = GenderType.Other }); },
                        () => true
                        );
            }
        }
        private DelegateCommand _deleteRowCommand;
        public DelegateCommand DeleteRowCommand
        {
            get
            {
                return _deleteRowCommand ??=
                    new DelegateCommand(
                        () => { GridData.RemoveAt(ItemIndex); },
                         () => ItemIndex >= 0 && ItemIndex != GridData.Count
                        );
            }
        }

        public ObservableCollection<GridDataViewModel> GridData
        {
            get; set;
        } = new ObservableCollection<GridDataViewModel>()
        {
            new GridDataViewModel() { ID = 1, Name = "Tarou Suzuki", Gender = GenderType.Male },
            new GridDataViewModel() { ID = 2, Name = "田中 次郎", Gender = GenderType.Other },
        };
        public enum GenderType
        {
            Male,
            Female,
            Other,
            DeclineToAnswer,
        }
        public class GridDataViewModel
        {
            // INotifyPropertyChanged
            private int _id;
            public int ID
            {
                get { return _id; }
                // イベント....
                set { _id = value; }
            }

            private string _name;
            public string Name
            {
                get { return _name; }
                set { _name = value; }
            }

            private GenderType _genderType;
            public GenderType Gender
            {
                get { return _genderType; }
                set { _genderType = value; }
            }
        }
        private int _currentIndex { get; set; }

        public int ItemIndex
        {
            set
            {
                _currentIndex = value;
            }
            get
            {
                return _currentIndex;
            }
        }
    }
}
