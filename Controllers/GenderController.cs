using MatrimonyAPI.Interface;
using MatrimonyAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace MatrimonyAPI.Controllers
{
    public class GenderController : ApiController
    {
        private readonly GenderInterface _GenderInterface;

        [HttpGet]
        [Route("api/Gender/Get")]
        public async Task<IEnumerable<Gender>> Get()
        {
            return await _GenderInterface.GetGenders();
        }

        [HttpPost]
        [Route("api/Gender/Create")]
        public async Task CreateAsync([FromBody] Gender gender)
        {
            if (ModelState.IsValid)
            {
                await _GenderInterface.Add(gender);
            }
        }

        [HttpGet]
        [Route("api/Gender/Details/{id}")]
        public async Task<Gender> Details(string id)
        {
            var result = await _GenderInterface.GetGender(id);
            return result;
        }

        [HttpPut]
        [Route("api/Gender/Edit")]
        public async Task EditAsync([FromBody] Gender gender)
        {
            if (ModelState.IsValid)
            {
                await _GenderInterface.Update(gender);
            }
        }

        [HttpDelete]
        [Route("api/Employees/Delete/{id}")]
        public async Task DeleteConfirmedAsync(string id)
        {
            await _GenderInterface.Delete(id);
        }
    }
}
