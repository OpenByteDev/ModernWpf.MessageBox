using System.Windows;

namespace ModernWpfMessageBox.Test {
    public partial class App : Application {

        protected override void OnStartup(StartupEventArgs e) {
            base.OnStartup(e);

            ModernWpf.MessageBox.Show("Test");
        }

    }
}
