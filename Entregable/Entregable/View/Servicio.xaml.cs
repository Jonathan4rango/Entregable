using Entregable.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Entregable.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Servicio : ContentPage
	{
		public Servicio ()
		{
			InitializeComponent ();
			BindingContext = new ServicioViewModel();
		}

        private void ListV_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

        }
    }
}