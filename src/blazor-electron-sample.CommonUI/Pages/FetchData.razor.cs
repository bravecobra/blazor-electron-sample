using blazor_electron_sample.CommonUI.Store.FetchDataUseCase;
using Fluxor;
using Microsoft.AspNetCore.Components;

namespace blazor_electron_sample.CommonUI.Pages
{
    partial class FetchData
    {
        [Inject]
        private IState<WeatherState> WeatherState { get; set; }

        [Inject]
        private IDispatcher Dispatcher { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            Dispatcher.Dispatch(new FetchDataAction());
        }
    }
}
