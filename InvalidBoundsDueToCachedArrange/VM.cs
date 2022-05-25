using ReactiveUI;
using System;
using System.Reactive.Disposables;

namespace AvaloniaApplication54_BusyIndicatorDialogScrambled
{
    public class VM : ReactiveObject
    {
        public bool IsBusy
        {
            get => _isBusy;
            set => this.RaiseAndSetIfChanged(ref _isBusy, value);
        }

        public string BusyContent
        {
            get => _busyContent;
            set => this.RaiseAndSetIfChanged(ref _busyContent, value);
        }

        internal void Toggle()
        {
            if (_dialog != null)
            {
                _dialog.Dispose();
                _dialog = null;
            }
            else
            {
                _dialog = MakeBusy("Please Wait");
            }
        }

        private IDisposable MakeBusy(string content)
        {
            IsBusy = true;
            BusyContent = content;

            return Disposable.Create(() =>
            {
                IsBusy = false;
                BusyContent = "";
            });
        }

        private bool _isBusy;
        private IDisposable _dialog;
        private string _busyContent;
    }
}
