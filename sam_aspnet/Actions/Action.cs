using sam_aspnet.States;
using sam_aspnet.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using sam_aspnet.Models;

namespace sam_aspnet.Actions
{
    public abstract class Action<T> : ApiController
        where T : Model, new()
    {
        protected State Recive(View View)
        {
            if (View != null)
            {
                var TModel = new T();
                TModel.Present(View);
                return TModel.gState;
            }
            else
                return Model.ErrorState;
        }
    }
}