using System;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Interop;
using MicaWPF.Controls;
using DialogBoxCommand = ModernWpf.LocalizedDialogCommands.DialogBoxCommand;

namespace ModernWpf
{
    public partial class MessageBoxWindow : MicaWindow
    {
        private const int GWL_STYLE = -16;
        private const int WS_SYSMENU = 0x80000;
        [DllImport("user32.dll", SetLastError = true)]
        private static extern int GetWindowLong(IntPtr hWnd, int nIndex);
        [DllImport("user32.dll")]
        private static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        public MessageBoxResult? Result = null;

        public MessageBoxWindow(string messageBoxText, string caption, MessageBoxButton button, string? symbolGlyph) {
            InitializeComponent();

            messageText.Text = messageBoxText;
            TitleText.Content = caption;
            TitleText.Visibility = !string.IsNullOrEmpty(caption) ? Visibility.Visible : Visibility.Collapsed;

            switch (button) {
                case MessageBoxButton.OK:
                    okButton.Visibility = Visibility.Visible;

                    if (MessageBox.EnableLocalization) {
                        okButton.Content = LocalizedDialogCommands.GetString(DialogBoxCommand.IDOK);
                    }

                    okButton.Focus();
                    break;
                case MessageBoxButton.OKCancel:
                    okButton.Visibility = Visibility.Visible;
                    cancelButton.Visibility = Visibility.Visible;
                    cancelButton.IsCancel = true;

                    if (MessageBox.EnableLocalization) {
                        okButton.Content = LocalizedDialogCommands.GetString(DialogBoxCommand.IDOK);
                        cancelButton.Content = LocalizedDialogCommands.GetString(DialogBoxCommand.IDCANCEL);
                    }
                    
                    okButton.Focus();
                    break;
                case MessageBoxButton.YesNo:
                    yesButton.Visibility = Visibility.Visible;
                    noButton.Visibility = Visibility.Visible;

                    if (MessageBox.EnableLocalization) {
                        yesButton.Content = LocalizedDialogCommands.GetString(DialogBoxCommand.IDYES);
                        noButton.Content = LocalizedDialogCommands.GetString(DialogBoxCommand.IDNO);
                    }

                    yesButton.Focus();
                    break;
                case MessageBoxButton.YesNoCancel:
                    yesButton.Visibility = Visibility.Visible;
                    noButton.Visibility = Visibility.Visible;
                    cancelButton.Visibility = Visibility.Visible;
                    cancelButton.IsCancel = true;

                    if (MessageBox.EnableLocalization) {
                        yesButton.Content = LocalizedDialogCommands.GetString(DialogBoxCommand.IDYES);
                        noButton.Content = LocalizedDialogCommands.GetString(DialogBoxCommand.IDNO);
                        cancelButton.Content = LocalizedDialogCommands.GetString(DialogBoxCommand.IDCANCEL);
                    }

                    yesButton.Focus();
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

        private void MicaWindow_Loaded(object sender, RoutedEventArgs e)
        {
            IntPtr hwnd = new WindowInteropHelper(this).Handle;
            SetWindowLong(hwnd, GWL_STYLE, GetWindowLong(hwnd, GWL_STYLE) & ~WS_SYSMENU);
        }
    }
}
