using Entregable.ViewModel;
using Entregable.View;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Contracts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;



namespace Entregable.ViewModel
{
    internal class UserViewModel : BaseViewModel
    {

        #region Atributos

        private string usr;
        private string pass;
        private string nombre;
        private string apellido;
        private int    cedula;
        private string correo;
        private string contrasena;
        private string tel;
        private string usuariologin;
        #endregion

        #region Prop

        public string nombreTxt
        {
            get
            {
                return this.nombre;
            }
            set { SetValue(ref this.nombre, value); }
        }


        public string ApeTxt
        {
            get
            {
                return this.apellido;
            }
            set { SetValue(ref this.apellido, value); }
        }

        public int CedulaTxt
        {
            get
            {
                return this.cedula;
            }
            set { SetValue(ref this.cedula, value); }
        }

        public string CorreoTxt
        {
            get
            {
                return this.correo;
            }
            set { SetValue(ref this.correo, value); }
        }

        public string ContraseTxt
        {
            get
            {
                return this.contrasena;
            }
            set { SetValue(ref this.contrasena, value); }
        }
            

        public string TelTxt
        {
            get { return tel; }
            set { SetValue(ref this.tel, value); }
        }

        public string LoginUserTxt
        {
            get { return usuariologin; }
            set { SetValue(ref this.usuariologin, value); }
        }


        public string UsurioTxt
        {
            get
            {
                return this.usr;
            }
            set { SetValue(ref this.usr, value); }
        }


        public string ContraTxt
        {
            get { return pass; }
            set { SetValue(ref this.pass, value); }
        }

        #endregion


        #region Commands

        public ICommand RegistrarseCommand
        {
            get
            {
                return new RelayCommand(RegistrarUsuario);
            }

            set { }

        }


        public ICommand LoginCommand
        {

            get
            {
                return new RelayCommand(Openlogin);
            }

            set { }
        }

        public ICommand RegistrarCommand
        {

            get
            {
                return new RelayCommand(OpenRegister);
            }

            set { }
        }

        public ICommand IngresarCommand
        {

            get
            {
                return new RelayCommand(GoIngreso);
            }

            set { }
        }


        #endregion


        #region Metodos


        public async void  RegistrarUsuario()
        {


            if (string.IsNullOrEmpty(this.usuariologin))
            {
                await Application.Current.MainPage.DisplayAlert("Register", "Por favor Ingresar el Usuario", "Aceptar");
                contrasena = "";
                return;
            }


            UserModel Usr = new UserModel();
            Usr.UserName = nombre;
            Usr.LastName = apellido;
            Usr.UserId = cedula;
            Usr.Correo = correo;
            Usr.Contra = contrasena;
            Usr.Tel = tel;
            Usr.Usuario = usuariologin;


            await App.DB.SaveModelAsync<UserModel>(Usr, true);
            await Application.Current.MainPage.DisplayAlert("Register", " Registro Exitoso", "Aceptar");


        }
        public async void Openlogin()
        {

            await  Application.Current.MainPage.Navigation.PushAsync(new Login());

        }

        public async void OpenRegister()
        {

           // await Application.Current.MainPage.Navigation.PushAsync(new Registro());
            await Application.Current.MainPage.Navigation.PushAsync(new Registro());

        }

        public async void GoIngreso()
        {
            UserModel Usr = App.DB.GetUsermodel(usr, pass).Result;

            if (Usr == null)
            {
                await Application.Current.MainPage.DisplayAlert("Login", "Credenciales incorrectas", "Aceptar");
            }
            else
            {
             //  await Application.Current.MainPage = new Princmain();
               await Application.Current.MainPage.Navigation.PushAsync(new Princmain());
            }

        }


        #endregion

    }
}
