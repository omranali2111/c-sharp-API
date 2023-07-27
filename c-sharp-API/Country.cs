using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace c_sharp_API
{
    internal class Country
    {
      //  public string officialName { get; set; }
        public List<string> capital { get; set; }
        public double area { get; set; }

        public Name name { get; set; }

        public class Name
        {
            public string common { get; set; }
            public string official { get; set; }
        }

        public Country( List<string> capital, double area, Name name)
        {
            
            this.capital = capital;
            this.area = area;
            this.name = name;
        }

        public override string ToString()
        {
            string capitals = string.Join(", ", capital);
            return $"official Name: {name.official}, Capitals: {capitals}, Area: {area}";
        }
    }

}
