using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MatrimonyAPI.Models
{
    public class RegisterDetailsModel
    {
        public List<ProfileForModel> profilefor { get; set; }
        public List<GenderModel> gender { get; set; }
        public List<LanguageModel> language { get; set; }
        public List<ReligionModel> religion { get; set; }
        public List<CountriesModel> country { get; set; }
      
        public List<BodyTypeModel> bodytype { get; set; }
        public List<ComplexionModel> complexion { get; set; }
        public List<PhysicalStatusModel> physics_status { get; set; }
        public List<HeightModel> height { get; set; }
        public List<EducationModel> highest_education { get; set; }
        public List<EmploymentTypeModel> employee_type { get; set; }
        public List<OccupationModel> occupation { get; set; }
        public List<AnnualincomeModel> annualincome { get; set; }
        public List<FamilyTypeModel> familytype { get; set; }
        public List<FamilyStatusModel> familystatus { get; set; }
        public List<StarModel> star { get; set; }
    }
}