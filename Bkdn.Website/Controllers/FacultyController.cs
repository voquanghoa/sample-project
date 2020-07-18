using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Bkdn.Website.Handlers;
using BusinessLogic.Contract;
using DataModels.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Bkdn.Website.Controllers
{
    [Route("api/faculties")]
    public class FacultyController: ControllerBase
    {
        private readonly IGenericBusiness<Faculty> business;

        public FacultyController(IGenericBusiness<Faculty> business)
        {
            this.business = business;
        }

        [HttpGet]
        public async Task<List<Faculty>> GetAll() => await business.GetAll<Faculty>();
        
        [HttpGet]
        [Route("{id}")]
        public async Task<Faculty> Get(int id) => await business.GetById<Faculty>(id);
        
        [HttpPost][ValidateModel]
        public async Task<Faculty> Create([FromBody] Faculty faculty) => await business.Create<Faculty>(faculty);
        
        [HttpPut][ValidateModel]
        public async Task Update([FromBody] Faculty faculty) => await business.Update(faculty);
    }

}