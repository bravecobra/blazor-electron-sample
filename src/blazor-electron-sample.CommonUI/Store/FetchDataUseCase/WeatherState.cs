using System;
using System.Collections.Generic;
using blazor_electron_sample.Domain;

namespace blazor_electron_sample.CommonUI.Store.FetchDataUseCase
{
    public class WeatherState
    {
        public bool IsLoading { get; }
        public IEnumerable<WeatherForecast> Forecasts { get; }

        public WeatherState(bool isLoading, IEnumerable<WeatherForecast> forecasts)
        {
            IsLoading = isLoading;
            Forecasts = forecasts ?? Array.Empty<WeatherForecast>();
        }
    }
}