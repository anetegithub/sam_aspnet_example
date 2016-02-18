using sam_aspnet.States;
using sam_aspnet.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sam_aspnet.Models
{
    public class AggregateModel : BaseModal<AggregateView>
    {
        protected override State StateRender(AggregateView View)
        {
            View.Age += 1;
            View.Name += " Simple";
            var State = new BaseState<AggregateView>(View);
            return State.Render(StateType.Html);
        }
    }
}