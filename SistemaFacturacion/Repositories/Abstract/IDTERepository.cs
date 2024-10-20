using SistemaFacturacion.Models.DTOs;
using SistemaFacturacion.Models.Entities;
using SistemaFacturacion.Utils;

namespace SistemaFacturacion.Repositories.Abstract
{
    public interface IDTERepository
    {
        Task<DTE> CreateDTEAsync(DTE dte);

        Task<List<DTEDto>> GetDTEsAsync();

        Task<DTE_detail> CreateDTERegiterAsync(DTE_detail dteDetailt);

        Task<List<DTE_type>> GetDTETypesAsync();

        Task<Result<List<DTE>>> GetDTEByNumberAsync(string numberDTE);

        Task<Result<List<DTE>>> GetDTEsAfterStartDateAsync(DateTime startDate);

        Task<Result<List<DTE>>> GetDTEsBeforeEndDateAsync(DateTime endDate);

        Task<Result<List<DTE>>> GetDTEsInDateRangeAsync(DateTime startDate, DateTime endDate);

        Task<int> SaveChangesAsync();
    }
}
