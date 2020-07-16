using System;
using Fluxor;

// ReSharper disable UnusedMember.Global

namespace blazor_electron_sample.CommonUI.Store.CounterUseCase
{
    public static class Reducers
    {
        [ReducerMethod]
        public static CounterState ReduceIncrementCounterAction(CounterState state, IncrementCounterAction action)
        {
            if (state == null) throw new ArgumentNullException(nameof(state));
            if (action == null) throw new ArgumentNullException(nameof(action));
            return new CounterState(clickCount: state.ClickCount + 1);
        }
    }
}
