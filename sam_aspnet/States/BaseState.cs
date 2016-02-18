using sam_aspnet.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sam_aspnet.States
{
    public class BaseState<T>
        where T : View
    {
        public BaseState(T View)
        {
            PassedView = View;
        }
        protected readonly View PassedView;

        public State Render(StateType Type)
        {
            if (Type == StateType.Html)
                return State.FromHtml(HtmlFromView());
            else if (Type == StateType.Json)
                return State.FromJson(JsonFromView());
            else
                return State.FromHtml("500");
        }

        protected string HtmlFromView()
        {
            string Tags = "<dl>" + Environment.NewLine;
            foreach (var Property in typeof(T).GetProperties())
            {
                Tags += "<dt>" + Property.Name + "</dt>" + Environment.NewLine;
                Tags += "<dd>" + Property.GetValue(PassedView).ToString() + "</dd>" + Environment.NewLine;
            }
            Tags += "</dl>";
            return Tags;
        }

        protected string JsonFromView()
        {
            string Json = "{" + Environment.NewLine;
            foreach (var Property in typeof(T).GetProperties())
                Json += "{ " + Property.Name + ":" + Property.GetValue(PassedView).ToString() + "}" + Environment.NewLine;
            Json += "}";
            return Json;
        }
    }
}