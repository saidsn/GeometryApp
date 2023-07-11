using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Service.DTOs.Build;
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

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await _buildService.GetAllAsync());
            }
            catch (Exception)
            {
                return NotFound("No records found!");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] BuildCreateDto buildCreateDto)
        {
            try
            {
                await _buildService.CreateAsync(buildCreateDto);

                return Ok(await _buildService.GetLastAsync());
            }
            catch (Exception)
            {
                return BadRequest(new { ErrorMessage = "Not Created" });
            }
        }




        [HttpDelete]
        public async Task<IActionResult> Delete([Required] int id)
        {
            try
            {
                await _buildService.DeleteAsync(id);

                return Ok();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }


        [HttpPut, Route("{id}")]
        public async Task<IActionResult> Update([Required] int id, [FromForm] BuildUpdateDto buildUpdateDto)
        {
            try
            {
                await _buildService.UpdateAsync(id, buildUpdateDto);

                return Ok(buildUpdateDto);
            }
            catch (Exception)
            {
                return BadRequest(new { ErrorMessage = "Not Updated" });
            }
        }
    }
}
