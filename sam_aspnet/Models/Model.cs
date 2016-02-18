using sam_aspnet.States;
using sam_aspnet.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sam_aspnet.Models
{
    public abstract class Model
    {
        public void Present(Object View)
        {
            StoredView = View;
        }
        private Object StoredView;

        protected abstract Boolean Validate(Object View);
        protected abstract State Render(Object View);
        protected abstract State Fault();

        public State gState
        {
            get
            {
                if (Validate(StoredView))
                    return Render(StoredView);
                else
                    return Fault();
            }
        }

        public static State ErrorState
        {
            get
            {
                return State.FromJson("500");
            }
        }
    }
}