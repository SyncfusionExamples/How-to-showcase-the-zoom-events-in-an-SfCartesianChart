using System.ComponentModel;

namespace ZoomEventsSample
{
    public class ViewModel : INotifyPropertyChanged
    {
        public List<Model> Data { get; set; }

        private DateTime visibleMinimum;
        public DateTime VisibleMinimum
        {
            get => visibleMinimum;
            set
            {
                if (visibleMinimum != value)
                {
                    visibleMinimum = value;
                    OnPropertyChanged();
                }
            }
        }

        private DateTime visibleMaximum;

        public DateTime VisibleMaximum
        {
            get => visibleMaximum;
            set
            {
                if (visibleMaximum != value)
                {
                    visibleMaximum = value;
                    OnPropertyChanged();
                }
            }
        }

        public ViewModel()
        {
            Data = new List<Model>()
            {
            new Model { Year = new DateTime(2023, 1, 1), StrokePrice = 50 },
            new Model { Year = new DateTime(2023, 2, 1), StrokePrice = 75 },
            new Model { Year = new DateTime(2023, 3, 1), StrokePrice = 80 },
            new Model { Year = new DateTime(2023, 4, 1), StrokePrice = 65 },
            new Model { Year = new DateTime(2023, 5, 1), StrokePrice = 70 },
            new Model { Year = new DateTime(2023, 6, 1), StrokePrice = 85 },
            new Model { Year = new DateTime(2023, 7, 1), StrokePrice = 50 },
            new Model { Year = new DateTime(2023, 8, 1), StrokePrice = 65 },
            new Model { Year = new DateTime(2023, 9, 1), StrokePrice = 90 },
            new Model { Year = new DateTime(2023, 10, 1), StrokePrice = 95 },
            new Model { Year = new DateTime(2023, 11, 1), StrokePrice = 100 },
            new Model { Year = new DateTime(2023, 12, 1), StrokePrice = 105 }
           };

            visibleMinimum = Data[0].Year;
            visibleMaximum = Data[Data.Count - 1].Year;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
