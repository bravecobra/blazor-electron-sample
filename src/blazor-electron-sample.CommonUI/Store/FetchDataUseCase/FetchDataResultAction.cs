using System.Collections.Generic;
using blazor_electron_sample.Domain;

namespace blazor_electron_sample.CommonUI.Store.FetchDataUseCase
{
    public class FetchDataResultAction
    {
        public IEnumerable<WeatherForecast> Forecasts { get; }

        public FetchDataResultAction(IEnumerable<WeatherForecast> forecasts)
        {
            Forecasts = forecasts;
        }
    }
}