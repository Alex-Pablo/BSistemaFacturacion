using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaFacturacion.Models.DTOs;
using SistemaFacturacion.Models.Entities;
using SistemaFacturacion.Services.Abstract;
using SistemaFacturacion.Services.Implementation;
using SistemaFacturacion.Utils;

namespace SistemaFacturacion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DTEController : ControllerBase
    {
        private readonly IDTEService _DTEService;
        public DTEController( IDTEService dTEService) {
            _DTEService = dTEService;
        }

        [HttpPost("create")]
        public async Task<Result<string>> Create([FromBody] DTERegister request)
        {
            if (!ModelState.IsValid)
            {
                return Result<string>.Failure("Campos requeridos");
            }

            Result<string> rUserCreated = await _DTEService.CreateDTEAsync(request);
            return rUserCreated;
        }

        [HttpGet("types/all")]
        public async Task<Result<List<DTE_type>>> GetDTETyps()
        {
            var result = await _DTEService.GetDTETypesAsync();
            return result;
        }

        [HttpGet("all")]
        public async Task<Result<List<DTEDto>>> GetDTs()
        {
            var result = await _DTEService.GetDTEsAsync();
            return result;
        }



        [HttpGet("filter")]
        public async Task<Result<List<DTE>>> FilterInvoices(string numberDTE = null, DateTime? startDate = null, DateTime? endDate = null)
        {
            var result = await _DTEService.FilterDTEsAsync(numberDTE, startDate, endDate);
            return result;
        }

    }
}
