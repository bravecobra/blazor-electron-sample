﻿using Fluxor;

namespace blazor_electron_sample.CommonUI.Store.CounterUseCase
{
    public class Feature : Feature<CounterState>
    {
        public override string GetName() => "Counter";
        protected override CounterState GetInitialState() => new CounterState(clickCount: 0);
    }
}
