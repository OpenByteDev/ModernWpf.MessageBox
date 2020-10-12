using ModernWpf.Extensions;
using ModernWpf.Controls;
using System.Linq;
using System.Windows;

namespace ModernWpf {
    public static class MessageBox {

        public static MessageBoxResult? Show(string messageBoxText) =>
            ShowInternal(null, messageBoxText, null, null, null, null);
        public static MessageBoxResult? Show(string messageBoxText, string caption) =>
            ShowInternal(null, messageBoxText, caption, null, null, null);
        public static MessageBoxResult? Show(string messageBoxText, string caption, MessageBoxButton button) =>
            ShowInternal(null, messageBoxText, caption, button, null, null);
        public static MessageBoxResult? Show(string messageBoxText, string caption, MessageBoxButton button, Symbol symbol) =>
            ShowInternal(null, messageBoxText, caption, button, symbol, null);
        public static MessageBoxResult? Show(string messageBoxText, string caption, MessageBoxButton button, MessageBoxImage image) =>
            ShowInternal(null, messageBoxText, caption, button, image, null);
        public static MessageBoxResult Show(string messageBoxText, string caption, MessageBoxButton button, Symbol symbol, MessageBoxResult defaultResult) =>
            ShowInternal(null, messageBoxText, caption, button, symbol, defaultResult);
        public static MessageBoxResult Show(string messageBoxText, string caption, MessageBoxButton button, SymbolGlyph symbol, MessageBoxResult defaultResult) =>
            ShowInternal(null, messageBoxText, caption, button, symbol, defaultResult);
        public static MessageBoxResult Show(string messageBoxText, string caption, MessageBoxButton button, MessageBoxImage image, MessageBoxResult defaultResult) =>
            ShowInternal(null, messageBoxText, caption, button, image, defaultResult);
        public static MessageBoxResult? Show(string messageBoxText, string caption, MessageBoxButton button, Symbol symbol, MessageBoxResult? defaultResult) =>
            ShowInternal(null, messageBoxText, caption, button, symbol, defaultResult);
        public static MessageBoxResult? Show(string messageBoxText, string caption, MessageBoxButton button, SymbolGlyph symbol, MessageBoxResult? defaultResult) =>
            ShowInternal(null, messageBoxText, caption, button, symbol, defaultResult);
        public static MessageBoxResult? Show(string messageBoxText, string caption, MessageBoxButton button, MessageBoxImage image, MessageBoxResult? defaultResult) =>
            ShowInternal(null, messageBoxText, caption, button, image, defaultResult);
        public static MessageBoxResult? Show(Window owner, string messageBoxText) =>
            ShowInternal(owner, messageBoxText, null, null, null, null);
        public static MessageBoxResult? Show(Window owner, string messageBoxText, string caption) =>
            ShowInternal(owner, messageBoxText, caption, null, null, null);
        public static MessageBoxResult? Show(Window owner, string messageBoxText, string caption, MessageBoxButton button) =>
            ShowInternal(owner, messageBoxText, caption, button, null, null);
        public static MessageBoxResult? Show(Window owner, string messageBoxText, string caption, MessageBoxButton button, Symbol symbol) =>
            ShowInternal(owner, messageBoxText, caption, button, symbol, null);
        public static MessageBoxResult? Show(Window owner, string messageBoxText, string caption, MessageBoxButton button, MessageBoxImage image) =>
            ShowInternal(owner, messageBoxText, caption, button, image, null);
        public static MessageBoxResult Show(Window owner, string messageBoxText, string caption, MessageBoxButton button, Symbol symbol, MessageBoxResult defaultResult) =>
            ShowInternal(owner, messageBoxText, caption, button, symbol, defaultResult);
        public static MessageBoxResult Show(Window owner, string messageBoxText, string caption, MessageBoxButton button, SymbolGlyph symbol, MessageBoxResult defaultResult) =>
            ShowInternal(owner, messageBoxText, caption, button, symbol, defaultResult);
        public static MessageBoxResult Show(Window owner, string messageBoxText, string caption, MessageBoxButton button, MessageBoxImage image, MessageBoxResult defaultResult) =>
            ShowInternal(owner, messageBoxText, caption, button, image, defaultResult);
        public static MessageBoxResult? Show(Window owner, string messageBoxText, string caption, MessageBoxButton button, Symbol symbol, MessageBoxResult? defaultResult) =>
            ShowInternal(owner, messageBoxText, caption, button, symbol, defaultResult);
        public static MessageBoxResult? Show(Window owner, string messageBoxText, string caption, MessageBoxButton button, SymbolGlyph symbol, MessageBoxResult? defaultResult) =>
            ShowInternal(owner, messageBoxText, caption, button, symbol, defaultResult);
        public static MessageBoxResult? Show(Window owner, string messageBoxText, string caption, MessageBoxButton button, MessageBoxImage image, MessageBoxResult? defaultResult) =>
            ShowInternal(owner, messageBoxText, caption, button, image, defaultResult);

        private static MessageBoxResult ShowInternal(Window? owner, string messageBoxText, string? caption, MessageBoxButton? button, Symbol symbol, MessageBoxResult defaultResult) =>
            ShowInternal(owner, messageBoxText, caption, button, symbol.ToGlyph(), defaultResult);
        private static MessageBoxResult ShowInternal(Window? owner, string messageBoxText, string? caption, MessageBoxButton? button, SymbolGlyph symbol, MessageBoxResult defaultResult) =>
            ShowInternal(owner, messageBoxText, caption, button, symbol.ToGlyph(), defaultResult);
        private static MessageBoxResult ShowInternal(Window? owner, string messageBoxText, string? caption, MessageBoxButton? button, MessageBoxImage image, MessageBoxResult defaultResult) =>
            ShowInternal(owner, messageBoxText, caption, button, image.ToSymbol(), defaultResult);
        private static MessageBoxResult? ShowInternal(Window? owner, string messageBoxText, string? caption, MessageBoxButton? button, Symbol symbol, MessageBoxResult? defaultResult) =>
            ShowInternal(owner, messageBoxText, caption, button, symbol.ToGlyph(), defaultResult);
        private static MessageBoxResult? ShowInternal(Window? owner, string messageBoxText, string? caption, MessageBoxButton? button, SymbolGlyph symbol, MessageBoxResult? defaultResult) =>
            ShowInternal(owner, messageBoxText, caption, button, symbol.ToGlyph(), defaultResult);
        private static MessageBoxResult? ShowInternal(Window? owner, string messageBoxText, string? caption, MessageBoxButton? button, MessageBoxImage image, MessageBoxResult? defaultResult) =>
            ShowInternal(owner, messageBoxText, caption, button, image.ToSymbol(), defaultResult);
        private static MessageBoxResult ShowInternal(Window? owner, string messageBoxText, string? caption, MessageBoxButton? button, string? glyph, MessageBoxResult defaultResult) =>
            ShowInternal(owner, messageBoxText, caption, button, glyph, defaultResult);
        private static MessageBoxResult? ShowInternal(Window? owner, string messageBoxText, string? caption, MessageBoxButton? button, string? glyph, MessageBoxResult? defaultResult) {
            var window = new MessageBoxWindow(messageBoxText, caption ?? string.Empty, button ?? MessageBoxButton.OK, glyph);
            window.Owner = owner ?? GetActiveWindow();
            window.ShowDialog();
            return window.Result ?? defaultResult;
        }

        private static Window GetActiveWindow() {
            return Application.Current.Windows.Cast<Window>().FirstOrDefault(window => window.IsActive);
        }

    }
}
