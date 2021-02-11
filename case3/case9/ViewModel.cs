using System.Collections.ObjectModel;
using System.ComponentModel;

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
                        () => { this.GridData.Add(new GridDataViewModel() { ID = -1, Name = "初期値 三郎", Sex = SexType.Other }); },
                        () => { return true; }
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
                        () => { this.GridData.RemoveAt(this.ItemIndex); },
                        () => { return this.ItemIndex >= 0 && this.ItemIndex != this.GridData.Count; }
                        );
            }
        }

        public ObservableCollection<GridDataViewModel> GridData
        {
            get; set;
        } = new ObservableCollection<GridDataViewModel>()
        {
            new GridDataViewModel() { ID = 1, Name = "Tarou Suzuki", Sex = SexType.Male },
            new GridDataViewModel() { ID = 2, Name = "田中 次郎", Sex = SexType.Other },
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
