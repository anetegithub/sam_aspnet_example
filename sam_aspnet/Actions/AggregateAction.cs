using sam_aspnet.Models;
using sam_aspnet.States;
using sam_aspnet.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace sam_aspnet.Actions
{
    public class AggregateActionController : Action<AggregateModel>
    {
        public State Index(AggregateView View)
        {
            return Recive(View);
        }
    }
}