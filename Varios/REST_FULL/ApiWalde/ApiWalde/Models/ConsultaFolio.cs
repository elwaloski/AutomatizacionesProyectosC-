using System.ComponentModel.DataAnnotations;

namespace ApiWalde.Models
{
    public class DteRangFoli1
    {
        public int Folio_Disponible { get; set; }

    }

    public class DteRangFoli
    {
        [Key]        
        public string? CODI_EMEX { get; set; }
        public int CODI_EMPR { get; set; }
        public int TIPO_DORA { get; set; }
        public int FOLI_DESD { get; set; }
        public int FOLI_HAST { get; set; }
    }
}
