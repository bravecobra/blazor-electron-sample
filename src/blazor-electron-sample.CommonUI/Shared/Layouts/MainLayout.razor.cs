using blazor_electron_sample.CommonUI.Store.Layout;
using Fluxor;
using Microsoft.AspNetCore.Components;

namespace blazor_electron_sample.CommonUI.Shared.Layouts
{
    partial class MainLayout
    {
        [Inject] private IState<LayoutState> LayoutState { get; set; }

        [Inject] private IDispatcher Dispatcher { get; set; }

        [Inject] private NavigationManager NavigationManager { get; set; }

        private bool _navMenuOpened;

        private bool NavMenuOpened
        {
            get => _navMenuOpened;
            set
            {
                _navMenuOpened = value;
                OpenedChangedHandler(value);
            }
        }

        private string _bbDrawerClass = "";

        protected override void OnInitialized()
        {
            base.OnInitialized();
            LayoutState.StateChanged += (sender, state) =>
            {
                _bbDrawerClass = state.ShowSideNav ? "full" : "closed";
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
