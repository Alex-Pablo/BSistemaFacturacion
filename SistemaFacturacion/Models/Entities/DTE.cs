using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SistemaFacturacion.Models.Entities
{
    [Index(nameof(DTE_number), IsUnique = true)]
    public class DTE
    {
        [Key]
        public Guid DTE_Id {  get; set; }


        /// <summary>
        /// El tipo de documento
        /// </summary>
        public int DTE_type_id { get; set; }
        [ForeignKey("DTE_type_id")]
        public DTE_type? DTE_type { get; set; }



        //--------Datos el emisor -------------------
        /// <summary>
        /// Nombre del contribuyente
        /// </summary>
        public required string Issuer_name { get; set; }

        /// <summary>
        /// Nit del contribuyente
        /// </summary>
        public required string Issuer_nit {  get; set; }

        /// <summary>
        /// Nombre del establecimiento, negocio o servicio
        /// </summary>
        public required string Service_name { get; set; }

        /// <summary>
        /// Direccion del establecimiento o negocio
        /// </summary>
        public required string Addres_service { get; set; }

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
        /// Es asignado por la sat(se creara uno quemado)
        /// </summary>
        public required string Authorization_number { get; set; }


        /// <summary>
        /// Serie del Documenbto tributario eletronico
        /// </summary>
        public required string DTE_serie {  get; set; }


        /// <summary>
        /// Numero de documento unico
        /// </summary>
        public required string DTE_number { get; set; }


        /// <summary>
        /// Fecha de emision de la factura
        /// </summary>
        public DateTime DTE_date { get; set; }

        /// <summary>
        /// El tipo de moneda
        /// </summary>
        public required string Currency {  get; set; }

        //---------------------------


        /// <summary>
        /// Total de la factura
        /// </summary>
        [Column(TypeName = "decimal(10,2)")]
        public decimal Total_amount { get; set; }


        public virtual List<DTE_detail> DteDetails { get; set; } = new();

    }
}
