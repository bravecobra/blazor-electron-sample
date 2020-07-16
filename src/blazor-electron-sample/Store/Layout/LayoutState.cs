namespace blazor_electron_sample.Store.Layout
{
    public class LayoutState
    {
        public bool ShowSideNav { get; private set; }

        public LayoutState(bool sidebarOpened)
        {
            ShowSideNav = sidebarOpened;
        }
    }
}