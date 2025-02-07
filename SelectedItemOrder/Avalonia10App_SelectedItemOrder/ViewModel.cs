using Avalonia;
using Avalonia.Threading;
using ReactiveUI;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Reactive;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Avalonia10App_SelectedItemOrder
{
    public class ViewModel : ReactiveObject
    {
        private string _selectedItem;

        public ViewModel()
        {
            SetSelectedItemCommand = ReactiveCommand.Create(OnSetSelectedItem);
            SetItemsCommand = ReactiveCommand.Create(OnSetItems);
        }

        public ReactiveCommandBase<Unit, Unit> SetSelectedItemCommand { get; }

        public ReactiveCommandBase<Unit, Unit> SetItemsCommand { get; }

        public ObservableCollection<string> Items { get; } = new();


        public string SelectedItem
        {
            get
            {
                return _selectedItem;
            }
            set
            {
                this.RaiseAndSetIfChanged(ref _selectedItem, value);
            }
        }


        private void OnSetSelectedItem()
        {
            SelectedItem = "Jerry";

            //We can force it in Avalonia 10
            this.RaisePropertyChanged(nameof(SelectedItem));
        }

        private void OnSetItems()
        {
            Items.Add("Tom");
            Items.Add("Jerry");
        }
    }
}
