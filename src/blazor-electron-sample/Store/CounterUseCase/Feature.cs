using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fluxor;

namespace blazor_electron_sample.Store.CounterUseCase
{
    public class Feature : Feature<CounterState>
    {
        public override string GetName() => "Counter";
        protected override CounterState GetInitialState() => new CounterState(clickCount: 0);
    }
}
