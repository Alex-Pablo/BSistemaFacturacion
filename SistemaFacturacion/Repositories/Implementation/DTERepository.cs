using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using SistemaFacturacion.DAL;
using SistemaFacturacion.Models.DTOs;
using SistemaFacturacion.Models.Entities;
using SistemaFacturacion.Repositories.Abstract;
using SistemaFacturacion.Utils;

namespace SistemaFacturacion.Repositories.Implementation
{
    public class DTERepository: IDTERepository
    {

        private readonly MyDbContext _myDbContext;

        public DTERepository(MyDbContext myDbContext)
        {
            _myDbContext = myDbContext;
        }

        public async Task<DTE> CreateDTEAsync(DTE dte)
        {
            await _myDbContext.DTE.AddAsync(dte);
            return dte;
        }

        public async Task<List<DTEDto>> GetDTEsAsync()
        {
            var cDTEs = await _myDbContext.DTE
                .Select(d => new DTEDto
                {
                    DTE_Id = d.DTE_Id,
                    DTE_number = d.DTE_number,
                    Issuer_name = d.Issuer_name,
                    Receiver_name = d.Receiver_name,
                    Receiver_nit = d.Receiver_nit,
                    DTE_date = d.DTE_date,
                    Total_amount= d.Total_amount,
                })
                .ToListAsync();
            return cDTEs;
        }



        public async Task<DTE_detail> CreateDTERegiterAsync(DTE_detail dteDetailt)
        {
            await _myDbContext.DTE_detail.AddAsync(dteDetailt);
            return dteDetailt;
        }

        public async Task<List<DTE_type>> GetDTETypesAsync()
        {
            var DTETypes = await _myDbContext.DTE_type.ToListAsync();
            return DTETypes;
        }

        public async Task<Result<List<DTE>>> GetDTEByNumberAsync(string numberDTE)
        {
            var dte = await _myDbContext.DTE.FirstOrDefaultAsync(d => d.DTE_number == numberDTE);
            if (dte == null)
            {
                return Result<List<DTE>>.Failure("Factura no encontrada");
            }
            return Result<List<DTE>>.Success(new List<DTE> { dte });
        }

        public async Task<Result<List<DTE>>> GetDTEsAfterStartDateAsync(DateTime startDate)
        {
            var dteList = await _myDbContext.DTE
                .Where(d => d.DTE_date >= startDate)
                .ToListAsync();

            if (!dteList.Any())
            {
                return Result<List<DTE>>.Failure("No se encontraron facturas desde la fecha especificada.");
            }

            return Result<List<DTE>>.Success(dteList);
        }

        public async Task<Result<List<DTE>>> GetDTEsBeforeEndDateAsync(DateTime endDate)
        {
            var dteList = await _myDbContext.DTE
                .Where(d => d.DTE_date <= endDate)
                .ToListAsync();

            if (!dteList.Any())
            {
                return Result<List<DTE>>.Failure("No se encontraron facturas hasta la fecha especificada.");
            }

            return Result<List<DTE>>.Success(dteList);
        }



        public async Task<Result<List<DTE>>> GetDTEsInDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            var dteList = await _myDbContext.DTE
                .Where(d => d.DTE_date >= startDate && d.DTE_date <= endDate)
                .ToListAsync();

            if (!dteList.Any())
            {
                return Result<List<DTE>>.Failure("No se encontraron facturas en el rango de fechas especificado.");
            }

            return Result<List<DTE>>.Success(dteList);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _myDbContext.SaveChangesAsync();
        }

    }
}
