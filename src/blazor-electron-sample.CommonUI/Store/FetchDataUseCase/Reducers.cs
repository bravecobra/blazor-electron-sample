using System;
using Fluxor;

// ReSharper disable UnusedMember.Global

namespace blazor_electron_sample.CommonUI.Store.FetchDataUseCase
{
    public class Reducers
    {
        [ReducerMethod]
        public static WeatherState ReduceFetchDataAction(WeatherState state, FetchDataAction action)
        {
            if (state == null) throw new ArgumentNullException(nameof(state));
            if (action == null) throw new ArgumentNullException(nameof(action));
            return new WeatherState(
                isLoading: true,
                forecasts: null);
        }

        [ReducerMethod]
        public static WeatherState ReduceFetchDataResultAction(WeatherState state, FetchDataResultAction action)
        {
            if (state == null) throw new ArgumentNullException(nameof(state));
            if (action == null) throw new ArgumentNullException(nameof(action));
            return new WeatherState(
                isLoading: false,
                forecasts: action.Forecasts);
        }
    }
}
