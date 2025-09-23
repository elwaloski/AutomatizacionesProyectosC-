using System.ComponentModel.DataAnnotations;

namespace ApiWalde.Models
{
    public class ConsultaDTE
    {
        [Key]
        public string? Codi_emex { get; set; }
        public int Codi_empr { get; set; }
        public int Tipo_docu { get; set; }
        public int Foli_docu { get; set; }
        public string? Esta_docu { get; set; }
    }
}
