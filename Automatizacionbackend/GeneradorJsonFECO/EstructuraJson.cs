using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneradorJsonFECO
{
    class EstructuraJson
    {
        public class InfoProc
        {
            public string idEmpr { get; set; }
            public string idArea { get; set; }
            public string tipoDoc { get; set; }
            public string SerieDoc { get; set; }
            public string corrDoc { get; set; }
            public string signDoc { get; set; }
            public string asgCorr { get; set; }
            public string genXml { get; set; }
            public string saveDoc { get; set; }
        }

        public class InfoDoc
        {
            public string Tipo { get; set; }
            public string LineaEncabezado { get; set; }
            public string TipoDocumento { get; set; }
            public string Prefijo { get; set; }
            public string Correlativo { get; set; }
            public string FechaEmision { get; set; }
            public string HoraEmision { get; set; }
            public string TipoOperacion { get; set; }
            public string TipoFactura { get; set; }
            public string MonedaDocumento { get; set; }
            public string NotaDocumento { get; set; }
            public string TipoEmisor { get; set; }
            public string TipoIdenEmisor { get; set; }
            public string IdentificacionEmisor { get; set; }
            public string DigitoVerificadorEmisor { get; set; }
            public string RegimenEmisor { get; set; }
            public string CodigoRespEmisor { get; set; }
            public string NomComerEmisor { get; set; }
            public string RSocApeEmisor { get; set; }
            public string IdentificadorTributoEmisor { get; set; }
            public string NombreTributoEmisor { get; set; }
            public string TipoAdquirente { get; set; }
            public string TipoIdenAdquirente { get; set; }
            public string IdentificacionAdquirente { get; set; }
            public string DigitoVerificadorAdquiriente { get; set; }
            public string RegimenAdquirente { get; set; }
            public string CodigoRespAdquiriente { get; set; }
            public string NomComerAdquirente { get; set; }
            public string RSocApeAdquirente { get; set; }
            public string TipoReceptorPago { get; set; }
            public string TipoIdenReceptorPago { get; set; }
            public string IdentificacionReceptorPago { get; set; }
            public string NombreReceptorPago { get; set; }
            public string TotalDescuentoDocumento { get; set; }
            public string TotalCargoDocumento { get; set; }
            public string TotalBrutoDocumento { get; set; }
            public string BaseImponibleDocumento { get; set; }
            public string TotalBrutoDocumentoImpu { get; set; }
            public string TotalDocumento { get; set; }
            public string LineaDireccion { get; set; }
            public string TipoDireccion { get; set; }
            public string IdDUNS { get; set; }
            public string ApartadoPostal { get; set; }
            public string Direccion { get; set; }
            public string Area { get; set; }
            public string Ciudad { get; set; }
            public string Departamento { get; set; }
            public string CodigoDepartamento { get; set; }
            public string CodigoPais { get; set; }
            public string LineaContacto { get; set; }
            public string TipoContacto { get; set; }
            public string NombreContacto { get; set; }
            public string TelefonoContacto { get; set; }
            public string MailContacto { get; set; }
            public string DescripcionContacto { get; set; }
            public string LineaImpuesto { get; set; }
            public string MonedaImpuesto { get; set; }
            public string TotalImpuesto { get; set; }
            public string IndicadorImpuesto { get; set; }
            public string BaseImponible { get; set; }
            public string PorcentajeImpuesto { get; set; }
            public string NumeroImpuesto { get; set; }
            public string NombreImpuesto { get; set; }
            public string LineaMedioPago { get; set; }
            public string IdMedioPago { get; set; }
            public string CodigoMedioPago { get; set; }
            public string IdentificadorPago { get; set; }
            public string LineaItem { get; set; }
            public string DescripcionItem { get; set; }
            public string CantidadItem { get; set; }
            public string UnidadMedidaItem { get; set; }
            public string MonedaItem { get; set; }
            public string ValorUnitarioItem { get; set; }
            public string CostoTotalItem { get; set; }
            public string CodigoTipoPrecio { get; set; }
            public string MarcaItem { get; set; }
            public string ModeloItem { get; set; }
            public string NotaItem { get; set; }
            public string LineaImpuestoItem { get; set; }
            public string MonedaImpuestoItem { get; set; }
            public string TotalImpuestoItem { get; set; }
            public string BaseImponibleItem { get; set; }
            public string PorcentajeImpuestoItem { get; set; }
            public string NumeroImpuestoItem { get; set; }
            public string NombreImpuestoItem { get; set; }
            public string UnidadMedidaImpItem { get; set; }
            public string LineaCodigo { get; set; }
            public string TipoCodigo { get; set; }
            public string ValorCodigo { get; set; }
            public string LineaRefeItem { get; set; }
            public string TipoRefeItem { get; set; }
            public string IdRefeItem { get; set; }
            public string TipoDocRefeItem { get; set; }
            public string LineaReferencia { get; set; }
            public string TipoReferencia { get; set; }
            public string NumeroDocReferencia { get; set; }
            public string FechaDocReferencia { get; set; }
            public string TipoDocReferencia { get; set; }
            public string LineaCorreoDespacho { get; set; }
            public string MailPara { get; set; }
            public string MailCopia { get; set; }
            public string MailOculto { get; set; }
            public string MailTipo { get; set; }
        }

        public class Root
        {
            public InfoProc infoProc { get; set; }
            public List<InfoDoc> infoDoc { get; set; }
        }

    }
}
