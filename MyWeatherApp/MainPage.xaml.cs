//using Xamarin.Essentials;
//using Xamarin.Forms;

namespace MyWeatherApp
{
    public partial class MainPage : ContentPage
    {
        RestService _restService;

        public MainPage()
        {
            InitializeComponent();
            _restService = new RestService();
            GetCachedLocation();
        }

        private async void GetCachedLocation()
        {
            try
            {
                Location location = await Geolocation.GetLastKnownLocationAsync();

                if (location != null)
                {
                    string endPoint = Constants.OpenWeatherMapEndpoint;
                    WeatherData weatherData = await _restService.GetWeatherData(GenerateRequestURL(endPoint, location.Latitude, location.Longitude));
                    BindingContext = weatherData;
                }
                else
                {
                   
                }
            }
            catch (Exception ex)
            {
                
            }
        }

        private async void OnGetMyWeatherButtonClicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(_cityEntry.Text))
            {
                string endPoint = Constants.OpenWeatherMapEndpoint;
                WeatherData weatherData = await _restService.GetWeatherData(GenerateRequestURL(endPoint));
                BindingContext = weatherData;
            }
        }

        private string GenerateRequestURL(string endPoint, double latitude = 0, double longitude = 0)
        {
            string requestUri = endPoint;

            if (latitude != 0 && longitude != 0)
            {
                requestUri += $"?lat={latitude}&lon={longitude}";
            }
            else
            {
                requestUri += $"?q={_cityEntry.Text}";
            }

            requestUri += "&units=imperial";
            requestUri += $"&APPID={Constants.OpenWeatherMapAPIKey}";
            return requestUri;
        }
    }
}
