using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fluxor;
using Force.DeepCloner;
// ReSharper disable UnusedMember.Global

namespace blazor_electron_sample.Store.Layout
{
    public class Reducers
    {
        [ReducerMethod]
        public static LayoutState ReduceOpenSideBarAction(LayoutState state, OpenSideBarAction action)
        {
            if (state == null) throw new ArgumentNullException(nameof(state));
            if (action == null) throw new ArgumentNullException(nameof(action));
            return new LayoutState(true );
        }


        [ReducerMethod]
        public static LayoutState ReduceCloseSideBarAction(LayoutState state, CloseSideBarAction action)
        {
            if (state == null) throw new ArgumentNullException(nameof(state));
            if (action == null) throw new ArgumentNullException(nameof(action));
            return new LayoutState(false);
        }
    }
}
