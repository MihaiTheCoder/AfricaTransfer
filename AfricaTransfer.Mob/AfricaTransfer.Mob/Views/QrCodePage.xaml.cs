using System.Diagnostics;
using System.IO;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZXing;
using ZXing.Rendering;

namespace AfricaTransfer.Mob.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class QrCodePage : ContentPage
    {
        BarcodeWriter<PixelData> bw;
        public ImageSource QrCode { get; set; }
        public QrCodePage(string code)
        {
            BarcodeWriter<PixelData> bw = new BarcodeWriter<PixelData> { Format = BarcodeFormat.QR_CODE, Renderer = new ZXing.Rendering.PixelDataRenderer()};

            QrCode = ImageSource.FromStream(() => new MemoryStream(bw.Write(code).Pixels));
            
            InitializeComponent();

            Qrimg.Source = QrCode;

            BindingContext = this;
        }
    }
}
