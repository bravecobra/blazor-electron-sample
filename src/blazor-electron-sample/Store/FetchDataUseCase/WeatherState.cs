using System;
using System.Collections;
using System.Collections.Generic;
using blazor_electron_sample.Data;

namespace blazor_electron_sample.Store.FetchDataUseCase
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