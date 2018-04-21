using AfricaTransfer.CoreLib.Models;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AfricaTransfer.Mob.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditItemPage : ContentPage
    {
        public Product Item { get; set; }
        public string FormattedId { get { return $"ID: { Item?.ID.ToString() ?? string.Empty }"; } }
        public EditItemPage(Product item)
        {
            Item = item;
            InitializeComponent();
            BindingContext = this;
        }
    }
}
