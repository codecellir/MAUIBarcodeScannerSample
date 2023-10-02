using ZXing.Net.Maui;

namespace ZXingScanner
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
            var option = new BarcodeReaderOptions
            {
                //Formats = BarcodeFormat.Ean8 | BarcodeFormat.Ean13 | BarcodeFormat.UpcA | BarcodeFormat.UpcE | BarcodeFormat.UpcEanExtension,
                Formats = BarcodeFormats.All,
                AutoRotate = true,
                Multiple = true,
               TryHarder = true,
               TryInverted = true
            };
            barcodeScanner.Options = option;
        }

        private void CameraBarcodeReaderView_BarcodesDetected(object sender, ZXing.Net.Maui.BarcodeDetectionEventArgs e)
        {
            Dispatcher.Dispatch(() =>
            {
                myLabel.Text = $"Format : {e.Results[0].Format} Value:{e.Results[0].Value}";
            });
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            myLabel.Text = "Waiting...";
            barcodeScanner.IsDetecting = true;
        }
    }
}