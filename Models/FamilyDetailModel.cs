using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MatrimonyAPI.Models
{
    public class FamilyDetailModel
    {
        public int Id { get; set; }

        public Nullable<int> FamilytypeId { get; set; }

        public Nullable<int> FamilystatusId { get; set; }

        public string FathersSurname { get; set; }

        public string FathersName { get; set; }

        public string FathersOccupation { get; set; }

        public string MothersSurname { get; set; }

        public string MothersName { get; set; }

        public string MothersOccupation { get; set; }

        public Nullable<int> NoOfSisters { get; set; }

        public Nullable<int> NoOfBrothers { get; set; }
    }
}