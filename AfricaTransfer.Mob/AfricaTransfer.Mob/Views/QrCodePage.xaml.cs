using System.Diagnostics;
using System.IO;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZXing;

namespace AfricaTransfer.Mob.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class QrCodePage : ContentPage
    {
        BarcodeWriter<MemoryStream> bw;
        public ImageSource QrCode { get; set; }
        public QrCodePage(string code)
        {
            BarcodeWriter<MemoryStream> bw = new BarcodeWriter<MemoryStream> { Format = BarcodeFormat.QR_CODE };
            
            ImageSource.FromStream(() => bw.Write(code));
            Debug.WriteLine(code);
            Debug.WriteLine(code);
            Debug.WriteLine(code);
            InitializeComponent();

            BindingContext = this;
        }
    }
}
