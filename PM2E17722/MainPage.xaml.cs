using Plugin.Media;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PM2E17722
{
    public partial class MainPage : ContentPage
    {


        Plugin.Media.Abstractions.MediaFile photo;


        bool resul = false;




        public MainPage()
        {
            InitializeComponent();
          
        }

        private async void btnfoto_Clicked(object sender, EventArgs e)
        {

            photo = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
            {
                Directory = "imagen",
                Name = "Foto.jpg",
                SaveToAlbum = true
            });

            if (photo != null)
            {
                foto.Source = ImageSource.FromStream(() => { return photo.GetStream(); });
            }




        }

        private async void btnmapa_Clicked(object sender, EventArgs e)
        {


            resul = await DisplayAlert("TERMINOS DE USO", "¿TIENE ENCENDIDO SU GPS?", "SI", "NO");





            if (resul == true)
            {

                await Navigation.PushAsync(new PageMapa());


            }
            else
            {

                await DisplayAlert("ERROR", "SE NECESITA ENCENDER EL GPS PARA GEOLOCALIZACION","CERRAR");



            }
           

         

       

        }
    }
}
