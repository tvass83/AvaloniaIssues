using ReactiveUI;
using System.Collections.ObjectModel;

namespace Avalonia11App_InvalidBoundsForSelectedItem
{
    public class ViewModel : ReactiveObject
    {
        public ViewModel()
        {
            for (int i = 1; i < 16; i++)
            {
                Values.Add(new Data(i));
            }

            Values.Add(new DataEx(-1));

            for (int i = 16; i < 31; i++)
            {
                Values.Add(new Data(i));
            }
        }

        public ObservableCollection<Data> Values { get; } = new();
    }

    public class Data
    {
        public Data(int val)
        {
            Value = val;
        }

        public int Value { get; set; }

        public override string ToString()
        {
            return $"Value: {Value}";
        }
    }

    public class DataEx : Data
    {
        public DataEx(int val) : base(val)
        {
        }
    }
}
