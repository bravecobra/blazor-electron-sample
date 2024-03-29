﻿using blazor_electron_sample.CommonUI.Store.Layout;
using Fluxor;
using Fluxor.Blazor.Web.Components;
using Microsoft.AspNetCore.Components;

namespace blazor_electron_sample.CommonUI.Shared.Layouts
{
    partial class MainLayout: FluxorLayout
    {
        [Inject] private IState<LayoutState> LayoutState { get; set; } = null!;

        [Inject] private IDispatcher Dispatcher { get; set; } = null!;

        [Inject] private NavigationManager NavigationManager { get; set; } = null!;

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
                _bbDrawerClass = LayoutState.Value.ShowSideNav ? "full" : "closed";
                NavMenuOpened = LayoutState.Value.ShowSideNav;
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
