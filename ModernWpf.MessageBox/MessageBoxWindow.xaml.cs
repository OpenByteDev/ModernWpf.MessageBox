using System;
using System.Windows;
using DialogBoxCommand = ModernWpf.LocalizedDialogCommands.DialogBoxCommand;

namespace ModernWpf {
    public partial class MessageBoxWindow : Window {
        public MessageBoxResult? Result = null;

        public MessageBoxWindow(string messageBoxText, string caption, MessageBoxButton button, string? symbolGlyph) {
            InitializeComponent();

            messageText.Text = messageBoxText;
            Title = caption;

            switch (button) {
                case MessageBoxButton.OK:
                    okButton.Visibility = Visibility.Visible;

                    if (MessageBox.EnableLocalization) {
                        okButton.Content = LocalizedDialogCommands.GetString(DialogBoxCommand.IDOK);
                    }
                    break;
                case MessageBoxButton.OKCancel:
                    okButton.Visibility = Visibility.Visible;
                    cancelButton.Visibility = Visibility.Visible;

                    if (MessageBox.EnableLocalization) {
                        okButton.Content = LocalizedDialogCommands.GetString(DialogBoxCommand.IDOK);
                        cancelButton.Content = LocalizedDialogCommands.GetString(DialogBoxCommand.IDCANCEL);
                    }
                    break;
                case MessageBoxButton.YesNo:
                    yesButton.Visibility = Visibility.Visible;
                    noButton.Visibility = Visibility.Visible;

                    if (MessageBox.EnableLocalization) {
                        yesButton.Content = LocalizedDialogCommands.GetString(DialogBoxCommand.IDYES);
                        noButton.Content = LocalizedDialogCommands.GetString(DialogBoxCommand.IDNO);
                    }
                    break;
                case MessageBoxButton.YesNoCancel:
                    yesButton.Visibility = Visibility.Visible;
                    noButton.Visibility = Visibility.Visible;
                    cancelButton.Visibility = Visibility.Visible;

                    if (MessageBox.EnableLocalization) {
                        yesButton.Content = LocalizedDialogCommands.GetString(DialogBoxCommand.IDYES);
                        noButton.Content = LocalizedDialogCommands.GetString(DialogBoxCommand.IDNO);
                        cancelButton.Content = LocalizedDialogCommands.GetString(DialogBoxCommand.IDCANCEL);
                    }
                    break;
            }

            okButton.Click += OkButton_Click;
            cancelButton.Click += CancelButton_Click;
            yesButton.Click += YesButton_Click;
            noButton.Click += NoButton_Click;

            if (symbolGlyph is string glyph) {
                symbolIcon.Visibility = Visibility.Visible;
                symbolIcon.Glyph = glyph;
            }
        }

        private void OkButton_Click(object sender, RoutedEventArgs e) => Close(MessageBoxResult.OK);
        private void CancelButton_Click(object sender, RoutedEventArgs e) => Close(MessageBoxResult.Cancel);
        private void YesButton_Click(object sender, RoutedEventArgs e) => Close(MessageBoxResult.Yes);
        private void NoButton_Click(object sender, RoutedEventArgs e) => Close(MessageBoxResult.No);

        public void Close(MessageBoxResult result) {
            Result = result;
            Close();
        }

        protected override void OnSourceInitialized(EventArgs e) {
            base.OnSourceInitialized(e);

            InvalidateMeasure();
        }
    }
}
