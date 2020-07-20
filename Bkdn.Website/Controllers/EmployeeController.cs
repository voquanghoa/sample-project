using System.Collections.Generic;
using System.Threading.Tasks;
using Bkdn.Website.Handlers;
using BusinessLogic.Contract;
using BusinessLogic.Models.Employee;
using BusinessLogic.Models.Faculty;
using DataModels.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bkdn.Website.Controllers
{
    [Route("api/employees")]
    public class EmployeeController: ControllerBase
    {
        private readonly IGenericBusiness<Employee> business;

        public EmployeeController(IGenericBusiness<Employee> business)
        {
            this.business = business;
        }

        [HttpGet]
        public async Task<List<EmployeeResponse>> GetAll() => await business.GetAll<EmployeeResponse>();
        
        [HttpGet]
        [Route("{id}")]
        public async Task<EmployeeResponse> Get(int id) => await business.GetById<EmployeeResponse>(id);
        
        [HttpPost][ValidateModel][Authorize]
        public async Task<EmployeeResponse> Create([FromBody] EmployeeCreate faculty) => await business.Create<EmployeeResponse>(faculty);
        
        [HttpPut][ValidateModel][Authorize]
        public async Task Update([FromBody] EmployeeUpdate faculty) => await business.Update(faculty);
    }
}