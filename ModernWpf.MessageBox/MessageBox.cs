using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using ModernWpf.Controls;
using ModernWpf.Extensions;

namespace ModernWpf {
    public static class MessageBox {
        public static bool EnableLocalization { get; set; } = true;

        #region Sync
        public static MessageBoxResult? Show(string messageBoxText) =>
            Show(null, messageBoxText, null, null, null, null);
        public static MessageBoxResult? Show(string messageBoxText, string? caption) =>
            Show(null, messageBoxText, caption, null, null, null);
        public static MessageBoxResult? Show(string messageBoxText, string? caption, MessageBoxButton button) =>
            Show(null, messageBoxText, caption, button, null, null);
        public static MessageBoxResult? Show(string messageBoxText, string? caption, MessageBoxButton button, Symbol symbol) =>
            Show(null, messageBoxText, caption, button, symbol, null);
        public static MessageBoxResult? Show(string messageBoxText, string? caption, MessageBoxButton button, SymbolGlyph symbol) =>
            Show(null, messageBoxText, caption, button, symbol, null);
        public static MessageBoxResult? Show(string messageBoxText, string? caption, MessageBoxButton button, MessageBoxImage image) =>
            Show(null, messageBoxText, caption, button, image, null);
        public static MessageBoxResult Show(string messageBoxText, string? caption, MessageBoxButton button, Symbol symbol, MessageBoxResult defaultResult) =>
            Show(null, messageBoxText, caption, button, symbol, defaultResult);
        public static MessageBoxResult? Show(string messageBoxText, string? caption, MessageBoxButton button, Symbol symbol, MessageBoxResult? defaultResult) =>
            Show(null, messageBoxText, caption, button, symbol, defaultResult);
        public static MessageBoxResult Show(string messageBoxText, string? caption, MessageBoxButton button, SymbolGlyph symbol, MessageBoxResult defaultResult) =>
            Show(null, messageBoxText, caption, button, symbol, defaultResult);
        public static MessageBoxResult? Show(string messageBoxText, string? caption, MessageBoxButton button, SymbolGlyph symbol, MessageBoxResult? defaultResult) =>
            Show(null, messageBoxText, caption, button, symbol, defaultResult);
        public static MessageBoxResult Show(string messageBoxText, string? caption, MessageBoxButton button, MessageBoxImage image, MessageBoxResult defaultResult) =>
            Show(null, messageBoxText, caption, button, image, defaultResult);
        public static MessageBoxResult? Show(string messageBoxText, string? caption, MessageBoxButton button, MessageBoxImage image, MessageBoxResult? defaultResult) =>
            Show(null, messageBoxText, caption, button, image, defaultResult);
        public static MessageBoxResult? Show(Window? owner, string messageBoxText) =>
            Show(owner, messageBoxText, null, null, null, null);
        public static MessageBoxResult? Show(Window? owner, string messageBoxText, string? caption) =>
            Show(owner, messageBoxText, caption, null, null, null);
        public static MessageBoxResult? Show(Window? owner, string messageBoxText, string? caption, MessageBoxButton? button) =>
            Show(owner, messageBoxText, caption, button, null, null);
        public static MessageBoxResult? Show(Window? owner, string messageBoxText, string? caption, MessageBoxButton? button, Symbol symbol) =>
            Show(owner, messageBoxText, caption, button, symbol, null);
        public static MessageBoxResult? Show(Window? owner, string messageBoxText, string? caption, MessageBoxButton? button, SymbolGlyph symbol) =>
            Show(owner, messageBoxText, caption, button, symbol, null);
        public static MessageBoxResult? Show(Window? owner, string messageBoxText, string? caption, MessageBoxButton? button, MessageBoxImage image) =>
            Show(owner, messageBoxText, caption, button, image, null);
        public static MessageBoxResult? Show(Window? owner, string messageBoxText, string? caption, MessageBoxButton? button, string? glyph) =>
            Show(owner, messageBoxText, caption, button, glyph, null);
        public static MessageBoxResult Show(Window? owner, string messageBoxText, string? caption, MessageBoxButton? button, Symbol symbol, MessageBoxResult defaultResult) =>
            Show(owner, messageBoxText, caption, button, symbol.ToGlyph(), defaultResult);
        public static MessageBoxResult? Show(Window? owner, string messageBoxText, string? caption, MessageBoxButton? button, Symbol symbol, MessageBoxResult? defaultResult) =>
            Show(owner, messageBoxText, caption, button, symbol.ToGlyph(), defaultResult);
        public static MessageBoxResult Show(Window? owner, string messageBoxText, string? caption, MessageBoxButton? button, SymbolGlyph symbol, MessageBoxResult defaultResult) =>
            Show(owner, messageBoxText, caption, button, symbol.ToGlyph(), defaultResult);
        public static MessageBoxResult? Show(Window? owner, string messageBoxText, string? caption, MessageBoxButton? button, SymbolGlyph symbol, MessageBoxResult? defaultResult) =>
            Show(owner, messageBoxText, caption, button, symbol.ToGlyph(), defaultResult);
        public static MessageBoxResult Show(Window? owner, string messageBoxText, string? caption, MessageBoxButton? button, MessageBoxImage image, MessageBoxResult defaultResult) =>
            Show(owner, messageBoxText, caption, button, image.ToSymbol(), defaultResult);
        public static MessageBoxResult? Show(Window? owner, string messageBoxText, string? caption, MessageBoxButton? button, MessageBoxImage image, MessageBoxResult? defaultResult) =>
            Show(owner, messageBoxText, caption, button, image.ToSymbol(), defaultResult);
        public static MessageBoxResult Show(Window? owner, string messageBoxText, string? caption, MessageBoxButton? button, string? glyph, MessageBoxResult defaultResult) =>
            ShowInternal(owner, messageBoxText, caption, button, glyph, defaultResult);
        public static MessageBoxResult? Show(Window? owner, string messageBoxText, string? caption, MessageBoxButton? button, string? glyph, MessageBoxResult? defaultResult) =>
            ShowInternal(owner, messageBoxText, caption, button, glyph, defaultResult);

        private static MessageBoxResult ShowInternal(Window? owner, string messageBoxText, string? caption, MessageBoxButton? button, string? glyph, MessageBoxResult defaultResult) =>
            ShowInternal(owner, messageBoxText, caption, button, glyph, defaultResult);
        private static MessageBoxResult? ShowInternal(Window? owner, string messageBoxText, string? caption, MessageBoxButton? button, string? glyph, MessageBoxResult? defaultResult) {
            owner ??= GetActiveWindow();
            var window = new MessageBoxWindow(messageBoxText, caption ?? string.Empty, button ?? MessageBoxButton.OK, glyph) {
                Owner = owner
            };
            window.ShowDialog();

            return window.Result ?? defaultResult;
        }
        #endregion Sync

        #region Async
        public static Task<MessageBoxResult?> ShowAsync(string messageBoxText) =>
            ShowAsync(null, messageBoxText, null, null, null, null);
        public static Task<MessageBoxResult?> ShowAsync(string messageBoxText, string? caption) =>
            ShowAsync(null, messageBoxText, caption, null, null, null);
        public static Task<MessageBoxResult?> ShowAsync(string messageBoxText, string? caption, MessageBoxButton button) =>
            ShowAsync(null, messageBoxText, caption, button, null, null);
        public static Task<MessageBoxResult?> ShowAsync(string messageBoxText, string? caption, MessageBoxButton button, Symbol symbol) =>
            ShowAsync(null, messageBoxText, caption, button, symbol, null);
        public static Task<MessageBoxResult?> ShowAsync(string messageBoxText, string? caption, MessageBoxButton button, SymbolGlyph symbol) =>
            ShowAsync(null, messageBoxText, caption, button, symbol, null);
        public static Task<MessageBoxResult?> ShowAsync(string messageBoxText, string? caption, MessageBoxButton button, MessageBoxImage image) =>
            ShowAsync(null, messageBoxText, caption, button, image, null);
        public static Task<MessageBoxResult> ShowAsync(string messageBoxText, string? caption, MessageBoxButton button, Symbol symbol, MessageBoxResult defaultResult) =>
            ShowAsync(null, messageBoxText, caption, button, symbol, defaultResult);
        public static Task<MessageBoxResult?> ShowAsync(string messageBoxText, string? caption, MessageBoxButton button, Symbol symbol, MessageBoxResult? defaultResult) =>
            ShowAsync(null, messageBoxText, caption, button, symbol, defaultResult);
        public static Task<MessageBoxResult> ShowAsync(string messageBoxText, string? caption, MessageBoxButton button, SymbolGlyph symbol, MessageBoxResult defaultResult) =>
            ShowAsync(null, messageBoxText, caption, button, symbol, defaultResult);
        public static Task<MessageBoxResult?> ShowAsync(string messageBoxText, string? caption, MessageBoxButton button, SymbolGlyph symbol, MessageBoxResult? defaultResult) =>
            ShowAsync(null, messageBoxText, caption, button, symbol, defaultResult);
        public static Task<MessageBoxResult> ShowAsync(string messageBoxText, string? caption, MessageBoxButton button, MessageBoxImage image, MessageBoxResult defaultResult) =>
            ShowAsync(null, messageBoxText, caption, button, image, defaultResult);
        public static Task<MessageBoxResult?> ShowAsync(string messageBoxText, string? caption, MessageBoxButton button, MessageBoxImage image, MessageBoxResult? defaultResult) =>
            ShowAsync(null, messageBoxText, caption, button, image, defaultResult);
        public static Task<MessageBoxResult?> ShowAsync(Window? owner, string messageBoxText) =>
            ShowAsync(owner, messageBoxText, null, null, null, null);
        public static Task<MessageBoxResult?> ShowAsync(Window? owner, string messageBoxText, string? caption) =>
            ShowAsync(owner, messageBoxText, caption, null, null, null);
        public static Task<MessageBoxResult?> ShowAsync(Window? owner, string messageBoxText, string? caption, MessageBoxButton? button) =>
            ShowAsync(owner, messageBoxText, caption, button, null, null);
        public static Task<MessageBoxResult?> ShowAsync(Window? owner, string messageBoxText, string? caption, MessageBoxButton? button, Symbol symbol) =>
            ShowAsync(owner, messageBoxText, caption, button, symbol, null);
        public static Task<MessageBoxResult?> ShowAsync(Window? owner, string messageBoxText, string? caption, MessageBoxButton? button, SymbolGlyph symbol) =>
            ShowAsync(owner, messageBoxText, caption, button, symbol, null);
        public static Task<MessageBoxResult?> ShowAsync(Window? owner, string messageBoxText, string? caption, MessageBoxButton? button, MessageBoxImage image) =>
            ShowAsync(owner, messageBoxText, caption, button, image, null);
        public static Task<MessageBoxResult?> ShowAsync(Window? owner, string messageBoxText, string? caption, MessageBoxButton? button, string? glyph) =>
            ShowAsync(owner, messageBoxText, caption, button, glyph, null);
        public static Task<MessageBoxResult> ShowAsync(Window? owner, string messageBoxText, string? caption, MessageBoxButton? button, Symbol symbol, MessageBoxResult defaultResult) =>
            ShowAsync(owner, messageBoxText, caption, button, symbol.ToGlyph(), defaultResult);
        public static Task<MessageBoxResult?> ShowAsync(Window? owner, string messageBoxText, string? caption, MessageBoxButton? button, Symbol symbol, MessageBoxResult? defaultResult) =>
            ShowAsync(owner, messageBoxText, caption, button, symbol.ToGlyph(), defaultResult);
        public static Task<MessageBoxResult> ShowAsync(Window? owner, string messageBoxText, string? caption, MessageBoxButton? button, SymbolGlyph symbol, MessageBoxResult defaultResult) =>
            ShowAsync(owner, messageBoxText, caption, button, symbol.ToGlyph(), defaultResult);
        public static Task<MessageBoxResult?> ShowAsync(Window? owner, string messageBoxText, string? caption, MessageBoxButton? button, SymbolGlyph symbol, MessageBoxResult? defaultResult) =>
            ShowAsync(owner, messageBoxText, caption, button, symbol.ToGlyph(), defaultResult);
        public static Task<MessageBoxResult> ShowAsync(Window? owner, string messageBoxText, string? caption, MessageBoxButton? button, MessageBoxImage image, MessageBoxResult defaultResult) =>
            ShowAsync(owner, messageBoxText, caption, button, image.ToSymbol(), defaultResult);
        public static Task<MessageBoxResult?> ShowAsync(Window? owner, string messageBoxText, string? caption, MessageBoxButton? button, MessageBoxImage image, MessageBoxResult? defaultResult) =>
            ShowAsync(owner, messageBoxText, caption, button, image.ToSymbol(), defaultResult);
        public static Task<MessageBoxResult> ShowAsync(Window? owner, string messageBoxText, string? caption, MessageBoxButton? button, string? glyph, MessageBoxResult defaultResult) =>
            ShowAsyncInternal(owner, messageBoxText, caption, button, glyph, defaultResult);
        public static Task<MessageBoxResult?> ShowAsync(Window? owner, string messageBoxText, string? caption, MessageBoxButton? button, string? glyph, MessageBoxResult? defaultResult) =>
            ShowAsyncInternal(owner, messageBoxText, caption, button, glyph, defaultResult);

        private static Task<MessageBoxResult> ShowAsyncInternal(Window? owner, string messageBoxText, string? caption, MessageBoxButton? button, string? glyph, MessageBoxResult defaultResult) =>
            ShowAsyncInternal(owner, messageBoxText, caption, button, glyph, defaultResult);
        private static Task<MessageBoxResult?> ShowAsyncInternal(Window? owner, string messageBoxText, string? caption, MessageBoxButton? button, string? glyph, MessageBoxResult? defaultResult) {
            var taskSource = new TaskCompletionSource<MessageBoxResult?>(
#if !NET45
                TaskCreationOptions.RunContinuationsAsynchronously
#endif
            );

            Application.Current.Dispatcher.Invoke(() => {
                var result = ShowInternal(owner, messageBoxText, caption, button, glyph, defaultResult);
                taskSource.TrySetResult(result);
            });

            return taskSource.Task;
        }
        #endregion Async

        private static Window? GetActiveWindow() =>
            Application.Current.Windows.Cast<Window>()
                .FirstOrDefault(window => window.IsActive && window.ShowActivated);
    }
}
