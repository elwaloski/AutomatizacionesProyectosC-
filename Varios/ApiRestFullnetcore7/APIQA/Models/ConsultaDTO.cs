using System.ComponentModel.DataAnnotations;

namespace APIQA.Models
{
    public class ConsultaDTO
    {
        [Key]
        public string IdenRece { get; set; }
        public int TipoDocu { get; set; }
        public decimal FoliDocu { get; set; }
    }
}
