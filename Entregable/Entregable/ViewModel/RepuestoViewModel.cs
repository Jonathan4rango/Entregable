using Entregable.Model;
using Entregable.View;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Entregable.ViewModel
{
    internal class RepuestoViewModel : BaseViewModel
    {

        #region Atributos

        private string nombreProduco;
        private int valor;
        private int cantidad;
       
        #endregion

        #region Prop

        public string NombrePTxt
        {
            get
            {
                return this.nombreProduco;
            }
            set { SetValue(ref this.nombreProduco, value); }
        }


        public int ValorPTxt
        {
            get
            {
                return this.valor;
            }
            set { SetValue(ref this.valor, value); }
        }

        public int CatidadTxt
        {
            get
            {
                return this.cantidad;
            }
            set { SetValue(ref this.cantidad, value); }
        }



        #endregion


        #region Commands

         public ICommand IngresarRCommand
         {
             get
             {
                 return new RelayCommand(RegistrarRepuesto);
             }

             set { }

         }



         #endregion


         #region Metodos


         public async void RegistrarRepuesto()
         {


             if (string.IsNullOrEmpty(this.nombreProduco))
             {
                 await Application.Current.MainPage.DisplayAlert("Register", "Por favor Ingresar el Usuario", "Aceptar");
                 
                 return;
             }


             RepuestoModel Rep = new RepuestoModel();
            Rep.NombreProduco = nombreProduco;
            Rep.Cantidad = cantidad;
            Rep.Valor = valor;
             


             await App.DB.SaveModelAsync<RepuestoModel>(Rep, true);
             await Application.Current.MainPage.DisplayAlert("Register", " Registro Exitoso", "Aceptar");


         }
        

         #endregion*/


    }
}
