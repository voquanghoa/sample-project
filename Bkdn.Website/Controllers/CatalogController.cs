using System.Collections.Generic;
using System.Threading.Tasks;
using Bkdn.Website.Handlers;
using BusinessLogic.Contract;
using BusinessLogic.Models.Catalog;
using DataModels.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bkdn.Website.Controllers
{
    [Route("api/catalogs")]
    public class CatalogController: ControllerBase
    {
        private readonly IGenericBusiness<Catalog> business;

        public CatalogController(IGenericBusiness<Catalog> business)
        {
            this.business = business;
        }
        
        [HttpGet]
        public async Task<List<Catalog>> GetAll() => await business.GetAll<Catalog>();
        
        [HttpGet]
        [Route("{id}")]
        public async Task<CatalogResponse> Get(int id) => await business.GetById<CatalogResponse>(id);
        
        [HttpPost][ValidateModel][Authorize]
        public async Task<CatalogResponse> Create([FromBody] CatalogCreate catalog) => await business.Create<CatalogResponse>(catalog);
        
        [HttpPut][ValidateModel][Authorize]
        public async Task Update([FromBody] CatalogUpdate catalog) => await business.Update(catalog);
    }
}