using System;
using System.Collections.Generic;
using System.Linq;
using Fluxor;

namespace blazor_electron_sample.Store.FetchDataUseCase
{
    public class Feature: Feature<WeatherState>
    {
        public override string GetName() => "WeatherForecasts";

        protected override WeatherState GetInitialState()
        {
            return new WeatherState(
                isLoading: false,
                forecasts: null);
        }
    }
}
