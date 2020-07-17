using Fluxor;

namespace blazor_electron_sample.CommonUI.Store.FetchDataUseCase
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
