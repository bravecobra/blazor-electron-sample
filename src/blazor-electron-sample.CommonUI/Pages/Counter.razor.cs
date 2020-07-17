using System;
using System.Collections.Generic;
using System.Text;
using blazor_electron_sample.CommonUI.Store.CounterUseCase;
using Fluxor;
using Microsoft.AspNetCore.Components;

namespace blazor_electron_sample.CommonUI.Pages
{
    partial class Counter
    {
        [Inject] private IState<CounterState> CounterState { get; set; }

        [Inject] private IDispatcher Dispatcher { get; set; }

        private void IncrementCount()
        {
            var action = new IncrementCounterAction();
            Dispatcher.Dispatch(action);
        }
    }
}
