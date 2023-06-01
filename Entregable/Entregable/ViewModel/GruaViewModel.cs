using Entregable.Model;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Entregable.ViewModel
{
    internal class GruaViewModel : BaseViewModel
    {

        #region Atributos

        private string dire;
        private string tip;
        #endregion

        public string NombrePTxt
        {
            get
            {
                return this.dire;
            }
            set { SetValue(ref this.dire, value); }
        }
        public string TipoVehiculo
        {
            get
            {
                return this.tip;
            }
            set { SetValue(ref this.tip, value); }
        }

        #region Command
        public ICommand SolicitarSerCommand
        {

            get
            {
                return new RelayCommand(SolicitarGrua);
            }

            set { 
            }
        }


        #endregion

        #region Metodos

        public  async void SolicitarGrua()
        {

            if (string.IsNullOrEmpty(this.dire))
            {
                await Application.Current.MainPage.DisplayAlert("Register", "Por favor Ingresar el Usuario", "Aceptar");

                return;
            }


            GruaModel Gru = new GruaModel();
            Gru.Direccion = dire;
            Gru.TipoVehiculo = tip;
            



            await App.DB.SaveModelAsync<GruaModel>(Gru, true);
            await Application.Current.MainPage.DisplayAlert("Register", " Registro Exitoso", "Aceptar");

        }
        #endregion

    }

}
