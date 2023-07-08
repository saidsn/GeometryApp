using Microsoft.AspNetCore.Mvc;
using Service.Services.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace MinaApp.Controllers
{
    public class BuildController : AppController
    {
        private readonly IBuildService _buildService;

        public BuildController(IBuildService buildService)
        {
            _buildService = buildService;
        }

        [HttpGet]
        public async Task<IActionResult> GetById([Required] int id)
        {
            try
            {
                return Ok(await _buildService.GetAsync(id));
            }
            catch (Exception)
            {
                return NotFound($"No records found. Id: {id}");
            }
        }
    }
}
