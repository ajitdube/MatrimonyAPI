using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MatrimonyAPI.Models
{
    public class StateModel
    {
        public int Id { get; set; }

        public int CountryId { get; set; }

        public string StateorCounty { get; set; }
    }
}