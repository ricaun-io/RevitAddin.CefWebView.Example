using RevitAddin.CefWebView.Example.Views.Extensions;
using System;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;

namespace RevitAddin.CefWebView.Example.Views
{
    public partial class WebView : Window
    {
        public WebView()
        {
            InitializeComponent();
            InitializeWindow();
            Browser.Address = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Web", "index.html");
            Browser.TitleChanged += (s, e) =>
            {
                this.Title = Browser.Title;
            };
            Browser.MenuHandler = new NoMenuContextHandler();
            Browser.LoadingStateChanged += (s, e) =>
            {
                if (!e.IsLoading)
                {
                    Task.Run(async () =>
                    {
                        await Task.Delay(1000);
                        var data = await Browser.InvokeScriptAsync<string>("GetData");
                        Console.WriteLine(data);

                        await Browser.InvokeScriptAsync("SetData", null, "Hello youtube!");
                    });
                }
            };
        }

        #region InitializeWindow
        private void InitializeWindow()
        {
            this.MinWidth = 800;
            this.MinHeight = 600;
            this.SizeToContent = SizeToContent.WidthAndHeight;
            this.ShowInTaskbar = false;
            this.ResizeMode = ResizeMode.CanResize;
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            new System.Windows.Interop.WindowInteropHelper(this) { Owner = Autodesk.Windows.ComponentManager.ApplicationWindow };
        }
        #endregion
    }
}