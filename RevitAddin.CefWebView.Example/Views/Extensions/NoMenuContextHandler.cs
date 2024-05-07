using CefSharp;

namespace RevitAddin.CefWebView.Example.Views.Extensions
{
    public class NoMenuContextHandler : IContextMenuHandler
    {
        public void OnBeforeContextMenu(
            IWebBrowser browserControl, IBrowser browser,
            IFrame frame, IContextMenuParams parameters,
            IMenuModel model)
        {
            model.Clear();
        }

        public bool OnContextMenuCommand(
            IWebBrowser browserControl, IBrowser browser,
            IFrame frame, IContextMenuParams parameters,
            CefMenuCommand commandId, CefEventFlags eventFlags)
        {
            return false;
        }

        public void OnContextMenuDismissed(IWebBrowser browserControl, IBrowser browser, IFrame frame)
        {
        }

        public bool RunContextMenu(
            IWebBrowser browserControl, IBrowser browser,
            IFrame frame, IContextMenuParams parameters,
            IMenuModel model, IRunContextMenuCallback callback)
        {
            return false;
        }
    }

}