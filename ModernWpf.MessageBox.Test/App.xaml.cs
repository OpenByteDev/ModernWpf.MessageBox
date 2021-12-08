using System.Windows;
using ModernWpf;
using ModernWpf.Controls;

namespace ModernWpfMessageBox.Test {
    public partial class App : Application {
        protected override void OnStartup(StartupEventArgs e) {
            base.OnStartup(e);

            var title = "Some title";
            var message = "This is a looooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooong test text!";

            // MessageBox.Show(message, title, MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
            // MessageBox.Show("adawdawda", title, MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
            ShutdownMode = ShutdownMode.OnExplicitShutdown;
            // ModernWpf.MessageBox.Show("This is a test text!", "Some title", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
            // ModernWpf.MessageBox.Show(message, title, MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
            ModernWpf.MessageBox.Show("redadwada", null, MessageBoxButton.OK, Symbol.Admin);
            ModernWpf.MessageBox.Show("redadwada", null, MessageBoxButton.OK, SymbolGlyph.Airplane);
            ModernWpf.MessageBox.Show("redadwada", null, MessageBoxButton.OK, SymbolGlyph.Airplane, MessageBoxResult.OK);
            ModernWpf.MessageBox.ShowAsync(message, title, MessageBoxButton.YesNoCancel, MessageBoxImage.Question).GetAwaiter().GetResult();
            ModernWpf.MessageBox.ShowAsync(message, title, MessageBoxButton.YesNoCancel, MessageBoxImage.Hand, MessageBoxResult.Cancel).GetAwaiter().GetResult();
            ModernWpf.MessageBox.EnableLocalization = false;
            ModernWpf.MessageBox.ShowAsync("Press Alt and you should see underscores!", null, MessageBoxButton.YesNoCancel, MessageBoxImage.Hand).GetAwaiter().GetResult();
            Shutdown();
        }
    }
}
