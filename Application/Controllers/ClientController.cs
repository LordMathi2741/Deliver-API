using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using Domain.Interfaces;
using Infraestructure.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers
{
   
    [Route("api/v1/[controller]")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [AllowAnonymous] //api de libre acceso
    public class ClientController(IRepositoryGeneric<Client> repositoryGeneric) : ControllerBase
    {
        private readonly IRepositoryGeneric<Client> _repositoryGeneric = repositoryGeneric;

        [HttpGet]
        [Route("get-all")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _repositoryGeneric.GetAllAsync());
        }

        [HttpGet]
        [Route("get-by-id")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _repositoryGeneric.GetByIdAsync(id));
        }

        [HttpPost]
        [Route("save-client")]
        public async Task<IActionResult> SaveClient(Client data)
        {
            await _repositoryGeneric.Add(data);
            return Ok(true);
        }

        [HttpGet]
        [Route("delete-client")]
        public async Task<IActionResult> DeleteClient(int id)
        {
            await _repositoryGeneric.Delete(id);
            return Ok(true);
        }

        [HttpPost]
        [Route("update-client")]
        public async Task<IActionResult> UpdateClient(Client data)
        {
            await _repositoryGeneric.Update(data);
            return Ok(true);
        }
        
    }
}
