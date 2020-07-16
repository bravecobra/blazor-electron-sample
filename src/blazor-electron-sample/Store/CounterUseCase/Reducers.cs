using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fluxor;
// ReSharper disable UnusedMember.Global

namespace blazor_electron_sample.Store.CounterUseCase
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
