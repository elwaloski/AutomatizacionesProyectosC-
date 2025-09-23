using System;

namespace Metodos
{
    public class Definiciones
    {
        public static string qmta_rece_info()
        {
            String qmta_rece_infoX = "INSERT[qmta_rece_info]( [mail_msid],[mail_from], [mail_into], [mail_incc], [mail_subj], [mail_cdat], [mail_esta], [mail_msge], [mail_fing], [fech_proc], [nmro_rtry]) values";
            return qmta_rece_infoX;
        }
        public static string qmta_rece_part()
        {
            String qmta_rece_partx = "INSERT [dbo].[qmta_rece_part] ([mail_msid], [part_txml], [part_filn], [part_type],[part_cset], [part_cb64], [part_esta], [part_msge], [part_fing]) values  ";
            return qmta_rece_partx;
        }
    }
}
