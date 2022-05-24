using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Newtonsoft.Json;
using System.Net.Http;

namespace RuasJauJson
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        async void btnPesquisar_Clicked(object sender, EventArgs e)
        {
            var client = new HttpClient();
            string rua = edtRua.Text;
            var json = await client.GetStringAsync($"https://viacep.com.br/ws/sp/jau/rua%20{rua}/json");

            List<rua> ruas = JsonConvert.DeserializeObject<List<rua>>(json);

            lstRuas.ItemsSource = ruas;
        }
    }
}
