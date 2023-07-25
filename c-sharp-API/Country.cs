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
       
            public string officialName { get; set; }
            public string capital { get; set; }
            public double area { get; set; }

        public Country(string officialName, string capital, double area) 
        { 
            this.officialName = officialName;
            this.capital = capital;
            this.area = area;

        }
        public override string ToString()
        {
            return $"Name: {officialName}, capital: {capital}, area: {area}";
        }


    }
}
