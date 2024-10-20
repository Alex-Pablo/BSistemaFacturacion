using SistemaFacturacion.Models.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SistemaFacturacion.Models.DTOs
{
    public class DTEDto
    {
        public Guid DTE_Id { get; set; }

        public required string DTE_number { get; set; }
        public required string Issuer_name { get; set; }

        public required string Receiver_name { get; set; }

        public required string Receiver_nit { get; set; }

        public DateTime DTE_date { get; set; }

        public decimal Total_amount { get; set; }
    }

    public class DTERegister
    {

        /// <summary>
        /// El tipo de documento
        /// </summary>
        public int DTE_type_id { get; set; }


        //--------Datos el emisor -------------------

        //public required string Issuer_name { get; set; }


        //public required string Issuer_nit { get; set; }


        //public required string Service_name { get; set; }


        //public required string Addres_service { get; set; }

        //----------------------------------------


        //---------Nombre del receptor -----------
        /// <summary>
        /// Nombre del receptor,
        /// </summary>
        public required string Receiver_name { get; set; }

        /// <summary>
        /// Nit del receptor
        /// </summary>
        public required string Receiver_nit { get; set; }

        //----------------------------------------


        //------------Datos de autorizacion---------------


        /// <summary>
        /// Serie del Documento tributario eletronico
        /// </summary>
        //public required string DTE_serie { get; set; }


        /// <summary>
        /// El tipo de moneda
        /// </summary>
        public required string Currency { get; set; }

        //---------------------------

        public  List<DTE_detail_register> DteDetails { get; set; } = new();
    }


    public class DTE_detail_register
    {

 


        /// <summary>
        /// Bien = B o servicio = S
        /// </summary>
        public required string Item_type { get; set; }

        /// <summary>
        /// Cantidad del servicio o producto
        /// </summary>
        public required decimal Item_quantity { get; set; }

        /// <summary>
        /// Decripcion del servicio
        /// </summary>
        public required string Item_descripcion { get; set; }


        /// <summary>
        /// Precio unitario del servicio
        /// </summary>
        [Column(TypeName = "decimal(10,2)")]
        public required decimal Unit_price { get; set; }

        /// <summary>
        /// Descuento  de cada item
        /// </summary>

        [Column(TypeName = "decimal(10,2)")]
        public required decimal Discount { get; set; }
    }
}
