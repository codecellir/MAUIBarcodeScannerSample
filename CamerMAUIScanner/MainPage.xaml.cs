using Camera.MAUI;
using Camera.MAUI.ZXingHelper;

namespace CamerMAUIScanner
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
            cameraView.BarCodeOptions = new BarcodeDecodeOptions
            {
                AutoRotate = true,
                PossibleFormats = { ZXing.BarcodeFormat.EAN_13, ZXing.BarcodeFormat.EAN_8, ZXing.BarcodeFormat.QR_CODE },
                ReadMultipleCodes = false,
                TryHarder = true,
                TryInverted = true
            };
            cameraView.BarCodeDetectionFrameRate = 10;
            cameraView.BarCodeDetectionMaxThreads = 5;
            cameraView.ControlBarcodeResultDuplicate = true;
            cameraView.BarCodeDetectionEnabled = true;
        }

        private void camerView_BarcodeDetected(object sender, Camera.MAUI.ZXingHelper.BarcodeEventArgs args)
        {
            Dispatcher.Dispatch(() =>
            {
                myLabel.Text = $"Format:{args.Result[0].BarcodeFormat} Value:{args.Result[0].Text}";
            });
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            myLabel.Text = "waiting...";
        }

        private void cameraView_Loaded(object sender, EventArgs e)
        {
            if (cameraView.NumCamerasDetected > 0)
            {
                if (cameraView.NumMicrophonesDetected > 0)
                    cameraView.Microphone = cameraView.Microphones.First();
                cameraView.Camera = cameraView.Cameras.First();
                Dispatcher.Dispatch(() =>
                {
                    cameraView.StartCameraAsync();
                });
            }
        }
        }
    }
