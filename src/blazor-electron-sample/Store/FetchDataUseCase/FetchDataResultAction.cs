using System.Collections.Generic;
using blazor_electron_sample.Data;

namespace blazor_electron_sample.Store.FetchDataUseCase
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