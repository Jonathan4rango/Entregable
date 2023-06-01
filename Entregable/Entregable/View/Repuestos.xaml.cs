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
	public partial class Repuestos : ContentPage
	{
		public Repuestos ()
		{
			InitializeComponent ();
			BindingContext = new RepuestoViewModel();
		}
	}
}