using AfricaTransfer.Mob.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AfricaTransfer.Mob.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditItemPage : ContentPage
    {
        public Item Item { get; set; }
        public string FormattedId { get { return $"ID: { Item?.Id ?? string.Empty }"; } }
        public EditItemPage(Item item)
        {
            Item = item;
            InitializeComponent();
        }
    }
}
