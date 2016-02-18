using sam_aspnet.States;
using sam_aspnet.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sam_aspnet.Models
{
    public abstract class BaseModal<T> : Model
        where T : View
    {
        protected override bool Validate(object oView)
        {
            if (typeof(T) != typeof(AggregateView))
            {
                foreach (var Property in typeof(AggregateView).GetProperties())
                    if (oView.GetType().GetProperty(Property.Name) == null)
                        return false;
            }
            try
            {
                return ViewValidate((T)oView);
            }
            catch (NotImplementedException)
            {
                return true;
            }
        }

        protected virtual Boolean ViewValidate(T View)
        {
            throw new NotImplementedException();
        }

        protected override States.State Fault()
        {
            try
            {
                return ValidateFault();
            }
            catch (NotImplementedException)
            {
                //if your Api return html
                return State.FromHtml("<h1>Wrong model</h1>");
                //if your Api return json
                //return State.FromJson("{Error: 'Wrong model'}");
            }
        }

        protected virtual State ValidateFault()
        {
            throw new NotImplementedException();
        }

        protected override States.State Render(object View)
        {
            try
            {
                return StateRender((T)View);
            }
            catch
            {
                return State.FromJson("500");
            }
        }

        protected abstract State StateRender(T View);
    }
}