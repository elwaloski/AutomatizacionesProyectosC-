using System.ComponentModel.DataAnnotations;

namespace ApiWalde.Models
{
    public class Codigo
    {
        public string? Codigos { get; set; }
        public string? codi_paem { get; set; }


    }
    public class ParaEmprEli
    {
        public string? codi_emex { get; set; }        
        public string? codi_paem { get; set; }
        public int codi_empr { get; set; }

    }

    public class ParaEmprEXP
    {
        public string? codi_emex { get; set; }
        public int codi_empr { get; set; }
        public string? codi_paem { get; set; }
        public string? valo_paem { get; set; }

    }
    public class ParaEmpr
    {
        [Key]
        public string? codi_emex { get; set; }
        public int codi_empr { get; set; }
        public string? codi_paem { get; set; }
        public string? tipo_como { get; set; }
        public string? desc_paem { get; set; }
        public string? valo_paem { get; set; }
        public string? obli_paem { get; set; }
    }
}
