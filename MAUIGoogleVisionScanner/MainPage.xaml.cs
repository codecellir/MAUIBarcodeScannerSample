using BarcodeScanner.Mobile;

namespace MAUIGoogleVisionScanner
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            // BarcodeScanner.Mobile.Methods.SetSupportBarcodeFormat(BarcodeScanner.Mobile.BarcodeFormats.QRCode | BarcodeScanner.Mobile.BarcodeFormats.Code39);

            Methods.AskForRequiredPermission();
        }

        private void gvCamera_OnDetected(object sender, BarcodeScanner.Mobile.OnDetectedEventArg e)
        {
            List<BarcodeResult> obj = e.BarcodeResults;
            string result = $"Type:{obj[0].BarcodeType}, Value: {obj[0].DisplayValue}";

            Dispatcher.Dispatch(() =>
            {
                bracodeLabel.Text = result;
            });
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            if (!gvCamera.IsScanning)
                gvCamera.IsScanning = true;
            bracodeLabel.Text = "Result:";
        }
    }
}