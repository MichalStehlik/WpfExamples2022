using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Wpf09WebApiClient.Models;
using Newtonsoft.Json;

namespace Wpf09WebApiClient.ViewModels
{
    internal class MainViewModel : INotifyPropertyChanged
    {
        private Uri ApiUri = new Uri("https://prace2.pslib.cloud/");
        private HttpClient _client;

        private string _response;
        private Rootobject _resObj;
        private ObservableCollection<Datum> _ideas = new ObservableCollection<Datum>();

        public MainViewModel()
        {
            _client = new HttpClient();
            Response = "";
            _client.BaseAddress = ApiUri;
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            _client.Timeout = TimeSpan.FromSeconds(30);
            ReloadCommand = new RelayCommand(
                async () =>
                {
                    HttpResponseMessage response = new HttpResponseMessage();
                    response = await _client.GetAsync("api/ideas");
                    if (response.IsSuccessStatusCode)
                    {
                        Response = await response.Content.ReadAsStringAsync();
                        //_resObj = System.Text.Json.JsonSerializer.Deserialize<ResponseIdeas>(Response);
                        _resObj = JsonConvert.DeserializeObject<Rootobject>(Response);
                        //_resObj = System.Text.Json.JsonSerializer.Deserialize<ResponseIdeas>(Response, new System.Text.Json.JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
                        Ideas = new ObservableCollection<Datum>(_resObj.data);
                    }
                    else
                    {
                        Response = "OOPS";
                        Ideas.Clear();
                    }
                }
                );
        }

        public string Response { get { return _response; } set { _response = value; NotifyPropertyChanged(); } }
        public ObservableCollection<Datum> Ideas { get { return _ideas; } set { _ideas = value; NotifyPropertyChanged(); } }

        public RelayCommand ReloadCommand { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
