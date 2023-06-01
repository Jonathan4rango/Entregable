using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using GalaSoft.MvvmLight.Command;
using Entregable.View;
using Entregable.Model;
using System.Threading.Tasks;

namespace Entregable.ViewModel
{
    internal class ServicioViewModel : BaseViewModel
    {

        #region Atributos

        private int idServicio;
        private string fecha;
        private string direccion;
        private string hora;
        private object listViewSoure;

        #endregion



        #region Prop

        public int IdServicio
        {
            get
            {
                return this.idServicio;
            }
            set { SetValue(ref this.idServicio, value); }
        }


        public string Fechatxt
        {
            get
            {
                return this.fecha;
            }
            set { SetValue(ref this.fecha, value); }
        }

        public string DirTxt
        {
            get
            {
                return this.direccion;
            }
            set { SetValue(ref this.direccion, value); }
        }



     
    public string HoraTxt
        {
            get
            {
                return this.hora;
            }
            set { SetValue(ref this.hora, value); }
        }

    public object ListViewSoure
    {
        get
        {
            return this.listViewSoure;
        }
        set { SetValue(ref this.listViewSoure, value); }
    }



    #endregion
    public ICommand SolicitarSerCommand
        {
            get
            {
                return new RelayCommand(GoServicio);
            }

            set { }

        }

        public async void IrServicio()
        {

           // await Application.Current.MainPage.Navigation.PushAsync(new Registro());

            await Application.Current.MainPage.Navigation.PushAsync(new Servicio());

        }

        public async Task LoadList()
        {
            ListViewSoure = await App.DB.GetModel<ServicioModel>();
        }

        public ICommand GuardarServicioCommand
        {
            get
            {
                return new RelayCommand(GuardarServicio);
            }

            set { }

        }
        public ICommand RepuestosCommand
        {
            get
            {
                return new RelayCommand(GoRepuestos);
            }

            set { }

        }

        public async void GoServicio()
        {

            // await Application.Current.MainPage.Navigation.PushAsync(new Registro());

            await Application.Current.MainPage.Navigation.PushAsync(new Servicio());

        }

        public async void GoRepuestos()
        {

            // await Application.Current.MainPage.Navigation.PushAsync(new Registro());

            await Application.Current.MainPage.Navigation.PushAsync(new Repuestos());

        }

        public async void GuardarServicio()
        {


            if (string.IsNullOrEmpty(this.direccion))
            {
                await Application.Current.MainPage.DisplayAlert("Register", "Por favor Ingresar el servicio", "Aceptar");
                
                return;
            }


            ServicioModel Ser = new ServicioModel();
           // Ser.IdServicio = idServicio;
            Ser.FechaServicio = fecha;
            Ser.Dire = direccion;
            Ser.HoraServicio = hora;




           /* await App.DB.SaveModelAsync<ServicioModel>(Ser, true);*/
            await App.DB.SaveModelAsync(Ser, true);
            await Application.Current.MainPage.DisplayAlert("Register", " Registro Exitoso", "Aceptar");


        }

        public ServicioViewModel()
        {
            LoadList();
        }

    }
}
