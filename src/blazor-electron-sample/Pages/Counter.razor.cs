using blazor_electron_sample.Store.CounterUseCase;
using Fluxor;
using Microsoft.AspNetCore.Components;

namespace blazor_electron_sample.Pages
{
    public partial class Counter
    {
        [Inject]
        private IState<CounterState> CounterState { get; set; }

        [Inject]
        public IDispatcher Dispatcher { get; set; }

        private void IncrementCount()
        {
            var action = new IncrementCounterAction();
            Dispatcher.Dispatch(action);
        }
    }
}
