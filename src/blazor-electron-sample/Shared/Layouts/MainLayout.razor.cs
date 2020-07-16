using blazor_electron_sample.Store.Layout;
using Fluxor;
using Microsoft.AspNetCore.Components;

namespace blazor_electron_sample.Shared.Layouts
{
    public partial class MainLayout
    {
        [Inject]
        private IState<LayoutState> LayoutState { get; set; }

        [Inject]
        public IDispatcher Dispatcher { get; set; }

        private bool _navMenuOpened;
        public bool NavMenuOpened
        {
            get => _navMenuOpened;
            set
            {
                _navMenuOpened = value;
                OpenedChangedHandler(value);
            }
        }

        public string BbDrawerClass = "";

        protected override void OnInitialized()
        {
            base.OnInitialized();
            LayoutState.StateChanged += (sender, state) =>
            {
                BbDrawerClass = state.ShowSideNav ? "full" : "closed";
                NavMenuOpened = state.ShowSideNav;
                this.StateHasChanged();
            };
        }

        private void NavToggle()
        {
            if (!NavMenuOpened)
                Dispatcher.Dispatch(new OpenSideBarAction());
            else
                Dispatcher.Dispatch(new CloseSideBarAction());
        }

        private void OpenedChangedHandler(bool value)
        {
            if (value && !LayoutState.Value.ShowSideNav)
                Dispatcher.Dispatch(new OpenSideBarAction());
            if (!value && LayoutState.Value.ShowSideNav)
                Dispatcher.Dispatch(new CloseSideBarAction());
        }
    }
}
