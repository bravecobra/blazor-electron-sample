using Fluxor;

namespace blazor_electron_sample.CommonUI.Store.Layout
{
    public class Feature : Feature<LayoutState>
    {
        public override string GetName() => "Layout";
        protected override LayoutState GetInitialState() => new LayoutState(false);
    }
}
