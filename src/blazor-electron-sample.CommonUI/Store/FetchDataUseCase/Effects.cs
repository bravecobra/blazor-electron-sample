using System;
using System.Net.Http;
using System.Threading.Tasks;
using blazor_eelectron_sample.Application;
using Fluxor;

// ReSharper disable UnusedMember.Global

namespace blazor_electron_sample.CommonUI.Store.FetchDataUseCase
{
    public class Effects
    {
        private readonly HttpClient _http;
        private readonly WeatherForecastService _service;

        public Effects(HttpClient http, WeatherForecastService service)
        {
            _http = http;
            _service = service;
        }

        [EffectMethod]
        public async Task HandleFetchDataAction(FetchDataAction action, IDispatcher dispatcher)
        {
            if (action == null) throw new ArgumentNullException(nameof(action));
            if (dispatcher == null) throw new ArgumentNullException(nameof(dispatcher));
            var forecasts = await _service.GetForecastAsync(DateTime.Now);
            //var forecasts = await _http.GetFromJsonAsync<WeatherForecast[]>("WeatherForecast");
            dispatcher.Dispatch(new FetchDataResultAction(forecasts));
        }
    }
}