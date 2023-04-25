using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Entregable
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Bienvenida : ContentPage
    {

        public Bienvenida()
        {
            InitializeComponent();

        }

        async void Btn_login_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Login());
        }
    }
}