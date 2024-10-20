using SistemaFacturacion.Models.DTOs;
using SistemaFacturacion.Models.Entities;
using SistemaFacturacion.Repositories.Abstract;
using SistemaFacturacion.Repositories.Implementation;
using SistemaFacturacion.Services.Abstract;
using SistemaFacturacion.Utils;
using SistemaFacturacion.Utils.UnitOfWork;
using System;

namespace SistemaFacturacion.Services.Implementation
{
    public class DTEService: IDTEService
    {
        private readonly IDTERepository _DTERepository;
        private readonly IUnitOfWork _unitOfWork;
        public DTEService( IDTERepository dTERepository, IUnitOfWork unitOfWork) {
            _DTERepository = dTERepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<List<DTEDto>>> GetDTEsAsync()
        {
            try
            {
                var cDTEs = await _DTERepository.GetDTEsAsync();
                return Result<List<DTEDto>>.Success(cDTEs);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return Result<List<DTEDto>>.Failure("Error en la consulta");
            }

        }
        public async Task<Result<List<DTE_type>>> GetDTETypesAsync()
        {
            try
            {
                var cDTETypes = await _DTERepository.GetDTETypesAsync();
                return Result<List<DTE_type>>.Success(cDTETypes);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return Result<List<DTE_type>>.Failure("Error en la consulta");
            }
        }

        public async Task<Result<List<DTE>>> FilterDTEsAsync(string numberDTE = null, DateTime? startDate = null, DateTime? endDate = null)
        {
            try
            {
           
                if (!string.IsNullOrEmpty(numberDTE))
                {
                    return await _DTERepository.GetDTEByNumberAsync(numberDTE);
                }

              
                if (startDate.HasValue && !endDate.HasValue)
                {
                    return await _DTERepository.GetDTEsAfterStartDateAsync(startDate.Value);
                }

           
                if (!startDate.HasValue && endDate.HasValue)
                {
                    return await _DTERepository.GetDTEsBeforeEndDateAsync(endDate.Value);
                }

                if (startDate.HasValue && endDate.HasValue)
                {
                    return await _DTERepository.GetDTEsInDateRangeAsync(startDate.Value, endDate.Value);
                }


                return Result<List<DTE>>.Failure("Debe proporcionar un número de DTE, una fecha de inicio o una fecha de fin.");
            }
            catch (Exception ex) {
                Console.WriteLine(ex.ToString());
                return Result<List<DTE>>.Failure("Error al realizar la consulta");
            }
        }


        public async Task<Result<string>> CreateDTEAsync(DTERegister request)
        {
            Guid guid = Guid.NewGuid();
            string authNumber = "AFJ398-JKF8932-9HAD83-FK93";
            string serie = "GJGK930";

            try
            {
                await _unitOfWork.BeginTransactionAsync();

                decimal totalAmount = 0;
                var itemNumber = 1;
                foreach (var item in request.DteDetails)
                {
                    decimal totalItemPrice = item.Unit_price * item.Item_quantity - item.Discount;
                    DTE_detail dte_detail = new DTE_detail
                    {
                        DTE_id = guid,
                        Item_number = itemNumber,
                        Item_type = item.Item_type,
                        Item_quantity = item.Item_quantity,
                        Item_descripcion = item.Item_descripcion,
                        Unit_price = item.Unit_price,
                        Discount = item.Discount,
                        Total_item_price = totalItemPrice
                    };

                    await _DTERepository.CreateDTERegiterAsync(dte_detail);
                    totalAmount += totalItemPrice;
                    itemNumber++;
                }


                DTE dteEntity = new DTE
                {
                    DTE_Id = guid,
                    DTE_type_id = request.DTE_type_id,
                    Issuer_name = "Juan pablo",
                    Issuer_nit = " 23457689",
                    Service_name = "xxxxxxx",
                    Addres_service = "Solola Guatemala",
                    Receiver_name = request.Receiver_name,
                    Receiver_nit = request.Receiver_nit,
                    Authorization_number = authNumber,
                    DTE_serie = serie,
                    DTE_number = GenerarDteNumber(),
                    DTE_date = DateTime.Now,
                    Currency = request.Currency,
                    Total_amount = totalAmount
                };

                await _DTERepository.CreateDTEAsync(dteEntity);
                await _unitOfWork.SaveChangesAsync();
                await _unitOfWork.CommitTransactionAsync();
                return Result<string>.Success("Factura creada");
            }
            catch (Exception ex)
            {
                await _unitOfWork.RollbackTransactionAsync();
                Console.WriteLine(ex.ToString());
                return Result<string>.Failure("Error al crear la facturacion");
            }
        }






        public string GenerarDteNumber()
        {
            Random random = new Random();
            var fechaActual = DateTime.Now.ToString("yyMMdd");

            long numeroAleatorio = random.Next(10000, 100000); 

            return $"{fechaActual}{numeroAleatorio}";
        }


    }

}
