using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SistemaFacturacion.Models.Entities
{
    public class DTE_type
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DTE_type_id {  get; set; }

        public required string DTE_type_name { get; set; }

        public required int code { get; set; }

    }
}
