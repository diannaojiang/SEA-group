using Android.App;
using Android.Webkit;
using Android.OS;
using Android.Views;

namespace TestWebview
{
    [Activity(Label = "SEA group", MainLauncher = true, Icon = "@drawable/icon" )]
    public class Activity1 : Activity
    {
        WebView webviewMain;

        protected override void OnCreate(Bundle bundle)
        {

            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(SEA_group.Resource.Layout.Main);

            webviewMain = FindViewById<WebView>(SEA_group.Resource.Id.webviewMain);
            //啟用Javascript Enable
            webviewMain.Settings.JavaScriptEnabled = true;
            //載入網址
            webviewMain.LoadUrl("http://wows.ga");
            // 請注意這行，如果不加入巢狀Class 會必成呼叫系統讓系統來裁決開啟http 的方式
            webviewMain.SetWebViewClient(new CustWebViewClient());

        }

        /// <summary>
        /// 覆寫使其back可以直接回上一頁並非預設的離開APP
        /// </summary>
        /// <param name="keyCode"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        public override bool OnKeyDown(Android.Views.Keycode keyCode, Android.Views.KeyEvent e)
        {
            if (keyCode == Keycode.Back && webviewMain.CanGoBack())
            {
                webviewMain.GoBack();
                return true;
            }
            return base.OnKeyDown(keyCode, e);
        }

        /// <summary>
        /// 巢狀Class 繼承WebViewClient
        /// </summary>
        private class CustWebViewClient : WebViewClient
        {
            public override bool ShouldOverrideUrlLoading(WebView view, string url)
            {
                view.LoadUrl(url);
                return true;
            }

        }
    }
}
    