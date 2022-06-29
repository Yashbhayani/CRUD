using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Form.Models
{
    public class Styu
    {
        public string Employname { get; set; }

        public string Surname { get; set; }

    }

    public class Fom
    {
        public List<Styu> FomList { get; set; }

        public Styu Formmodel { get; set; }

    }
}