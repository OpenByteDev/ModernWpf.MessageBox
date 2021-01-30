using System.Windows;

namespace ModernWpfMessageBox.Test {
    public partial class App : Application {

        protected override void OnStartup(StartupEventArgs e) {
            base.OnStartup(e);

            var title = "Some title";
            var message = "This is a looooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooong test text!";

            // MessageBox.Show(message, title, MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
            // MessageBox.Show("adawdawda", title, MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
            ShutdownMode = ShutdownMode.OnExplicitShutdown;
            ModernWpf.MessageBox.Show("This is a test text!", "Some title", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
            ModernWpf.MessageBox.Show(message, title, MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
            Shutdown();
        }

    }
}
