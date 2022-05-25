using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace InvalidBoundsDueToCachedArrange
{
    public class MainWindow : Window
    {
        public MainWindow()
        {
            AvaloniaXamlLoader.Load(this);
#if DEBUG
            this.AttachDevTools();
#endif
            var btn = this.FindControl<Button>("_btn");
            
            btn.Click += (s, a) =>
            {
                var vm = btn.DataContext as VM;
                vm.Toggle();
            };

        }
    }
}
