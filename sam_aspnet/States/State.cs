using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sam_aspnet.Views;

namespace sam_aspnet.States
{
    public sealed class State
    {
        private State(String State)
        {
            Value = State;
            Rendered = Value;
        }
        private readonly String Value;

        public static State FromHtml(String Html)
        {
            return new State(Html);
        }
        public static State FromJson(String Json)
        {
            return new State(Json);
        }

        public override string ToString()
        {
            return Value;
        }

        public string Rendered { get; set; }
    }
}