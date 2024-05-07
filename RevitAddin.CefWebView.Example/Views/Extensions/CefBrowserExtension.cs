using CefSharp;
using System;
using System.Threading.Tasks;

namespace RevitAddin.CefWebView.Example.Views.Extensions
{
    public static class CefBrowserExtension
    {
        public static async Task InvokeScriptAsync(this IWebBrowser browser, string script, Action onSuccess = null, params object[] args)
        {
            await browser.InvokeScriptAsync<object>(script, (o) => { onSuccess?.Invoke(); }, args);
        }

        public static async Task<T> InvokeScriptAsync<T>(this IWebBrowser browser, string script, Action<T> onSuccess = null, params object[] args)
        {
            var javascriptResponse = await browser.EvaluateScriptAsync(script, args);
            if (javascriptResponse.Success)
            {
                var result = (T)javascriptResponse.Result;
                onSuccess?.Invoke(result);
                return result;
            }
            else
            {
                throw new Exception(javascriptResponse.Message);
            }
        }
    }
}