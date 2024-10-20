using SistemaFacturacion.Models.DTOs;
using SistemaFacturacion.Models.Entities;
using SistemaFacturacion.Utils;

namespace SistemaFacturacion.Services.Abstract
{
    public interface IDTEService
    {
        Task<Result<string>> CreateDTEAsync(DTERegister request);


        Task<Result<List<DTE>>> FilterDTEsAsync(string numberDTE = null, DateTime? startDate = null, DateTime? endDate = null);

        Task<Result<List<DTEDto>>> GetDTEsAsync();

        Task<Result<List<DTE_type>>> GetDTETypesAsync();
    }
}
