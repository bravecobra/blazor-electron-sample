using blazor_electron_sample.CommonUI.Store.FetchDataUseCase;
using Fluxor;
using Microsoft.AspNetCore.Components;

namespace blazor_electron_sample.CommonUI.Pages
{
    partial class FetchData
    {
        [Inject]
        private IState<WeatherState> WeatherState { get; set; } = null!;

        [Inject] private IDispatcher Dispatcher { get; set; } = null!;

        protected override void OnInitialized()
        {
            base.OnInitialized();
            Dispatcher.Dispatch(new FetchDataAction());
        }
    }
}
