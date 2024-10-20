using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaFacturacion.Models.Entities
{

    public class DTE_detail
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DTE_datail_id { get; set; }

        public Guid DTE_id { get; set; }
        [ForeignKey("DTE_id")]
        public DTE? DTE { get; set; }

        /// <summary>
        /// Lineas
        /// </summary>
        public int Item_number { get; set; }


        /// <summary>
        /// Bien o servicio
        /// </summary>
        public required string Item_type { get; set; }

        /// <summary>
        /// Cantidad del servicio o producto
        /// </summary>
        [Column(TypeName = "decimal(10,2)")]
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


        /// <summary>
        /// Total del item despues de (precio * cantidad - descuento)
        /// </summary>
        [Column(TypeName = "decimal(10,2)")]
        public required decimal Total_item_price { get; set; }

    }
}
