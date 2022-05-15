using MatrimonyAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrimonyAPI.Interface
{
    public interface GenderInterface
    {
        Task Add(Gender genders);
        Task Update(Gender gender);
        Task Delete(string Id);
        Task<Gender> GetGender(string id);
        Task<IEnumerable<Gender>> GetGenders();
    }
}
