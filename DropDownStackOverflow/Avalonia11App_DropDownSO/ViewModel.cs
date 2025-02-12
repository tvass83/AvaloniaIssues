using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Reactive;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using Avalonia;
using Avalonia.ReactiveUI;
using Avalonia.Threading;
using ReactiveUI;

namespace Avalonia11App1_DropDownSO
{
    public class ViewModel : ReactiveObject
    {
        private bool _isOpen;
        private bool _isParentVisible = true;

        public ViewModel()
        {
            OpenDropDownCommand = ReactiveCommand.Create(OnOpenDropDown);
            HideParentCommand = ReactiveCommand.Create(OnHideParent);

            Values.Add("test1");
            Values.Add("test2");
        }

        public ICommand OpenDropDownCommand { get; }

        public ICommand HideParentCommand { get; }

        public ObservableCollection<string> Values { get; } = new();

        public bool IsOpen
        {
            get
            {
                return _isOpen;
            }
            set
            {
                this.RaiseAndSetIfChanged(ref _isOpen, value);
            }
        }

        public bool IsParentVisible
        {
            get
            {
                return _isParentVisible;
            }
            set
            {
                this.RaiseAndSetIfChanged(ref _isParentVisible, value);
            }
        }

        private void OnOpenDropDown()
        {
            IsOpen = true;
        }

        private void OnHideParent()
        {
            IsParentVisible = false;
        }
    }
}
