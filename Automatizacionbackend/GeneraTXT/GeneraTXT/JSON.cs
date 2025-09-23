using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneraTXT
{
    public class JSON
    {
    public string JSON33Gateway(Int64 CantidadTotal, string fecha,string fechaVenc,string NuevaRutaCarpeta,string RutEmpresa,int Tipo_docu, Int64 FolioDesde) {
            string jsonModificado = "";
            string GATEWAY33 = @"{
  ""AsignacionFolio"": ""SI"",
  ""VersionDocumento"": ""F22"",
  ""TipoContenido"": ""json"",
  ""Carga"": ""SI"",
  ""SalidaPDF"": ""SI"",
  ""SalidaPDFMerito"": ""SI"",
  ""Impresion"": {
    ""Ruta"": ""Wondershare PDFelement"",
    ""CopiasMerito"": 0,
    ""CopiasNorma"": 1
  },
  ""Documento"": {
    ""Encabezado"": {
      ""TipoDocumento"": ""33"",
      ""Folio"": null,
      ""FolioCliente"": """",
      ""FechaEmision"": """",
      ""FormaPago"": 2.0,
      ""FechaVencimiento"": """",
      ""Emisor"": {
        ""RUT"": ""78079790-8"",
        ""RazonSocial"": ""KUEHNE + NAGEL LTDA."",
        ""Giro"": ""SERVICIOS DETRANSPORTES Y SERV."",
        ""Direccion"": ""AV. APOQUINDO 4501 PISO 14 SANTIAGO CHILE"",
        ""Comuna"": ""LAS CONDES"",
        ""Ciudad"": ""SANTIAGO"",
        ""RUTMandante"": ""80043600-1"",
        ""Acteco"": [
          ""620200""
        ]
      },
      ""Receptor"": {
        ""RUT"": ""80043600-1"",
        ""CodigoInterno"": "" 1038589601"",
        ""RazonSocial"": "" BASF Chile S.A."",
        ""Giro"": "" FABRICACION PRODUCTOS QUIMICOS INDU"",
        ""Direccion"": "" Avenida Carrascal3851"",
        ""Comuna"": ""Santiago"",
        ""Ciudad"": ""Santiago""
      },
      ""Transporte"": {
        ""PatenteVehiculo"": """",
        ""DireccionDestino"": """",
        ""ComunaDestino"": """",
        ""CiudadDestino"": """"
      },
      ""MontoNeto"": 23834.0,
      ""MontoExento"": 0.0,
      ""TasaIVA"": 19.0,
      ""IVA"": 4528.0,
      ""MontoPeriodo"": 28362.0,
      ""MontoTotal"": 28362.0
    },
    ""Detalles"": [
      {
        ""NroLinea"": 1.0,
        ""Nombre"": ""Collect Fee"",
        ""Cantidad"": 1.0,
        ""PrecioUnitario"": 6053.0,
        ""Monto"": 6053.0,
        ""PrecioUnitarioFinal"": 0.0
      },
      {
        ""NroLinea"": 2.0,
        ""Nombre"": ""Desconsolidacion"",
        ""Cantidad"": 1.0,
        ""PrecioUnitario"": 17781.0,
        ""Monto"": 17781.0,
        ""PrecioUnitarioFinal"": 0.0
      }
    ],
    ""ReferenciasGlobales"": [
      {
        ""NroLinea"": 1.0,
        ""TipoDocumento"": ""TN"",
        ""Folio"": ""1038589601"",
        ""Fecha"": ""2021-04-12""
      },
      {
        ""NroLinea"": 2.0,
        ""TipoDocumento"": ""809"",
        ""Folio"": ""1038589601"",
        ""Fecha"": ""2021-04-12"",
        ""Razon"": ""AWB""
      },
      {
        ""NroLinea"": 3.0,
        ""TipoDocumento"": ""BKN"",
        ""Folio"": ""2010626656"",
        ""Fecha"": ""2021-04-12""
      },
      {
        ""NroLinea"": 4.0,
        ""TipoDocumento"": ""DQ"",
        ""Folio"": ""145301184"",
        ""Fecha"": ""2021-04-12""
      },
      {
        ""NroLinea"": 5.0,
        ""TipoDocumento"": ""ON"",
        ""Folio"": ""4963815226"",
        ""Fecha"": ""2021-04-12""
      }
    ]
  }
}";
            for (int i = 1; i <= CantidadTotal; i++)
            {
                // Crea una copia del JSON original y reemplaza el valor del campo "FolioCliente"
                jsonModificado = GATEWAY33.Replace(@"""FolioCliente"": """"", $@"""FolioCliente"": ""{FolioDesde}""").
                    Replace(@"""FechaEmision"": """"", $@"""FechaEmision"": ""{fecha}""").
                    Replace(@"""FechaVencimiento"": """"", $@"""FechaVencimiento"": ""{fechaVenc}""") ;
                StreamWriter writer22 = new StreamWriter(NuevaRutaCarpeta + "\\33\\" + "JsonGatewayE0" + RutEmpresa + "T" + Tipo_docu + "0000" + FolioDesde + ".txt", false, Encoding.Default);

                writer22.WriteLine(jsonModificado.TrimEnd());
                writer22.Close();
                FolioDesde++;
            }

            return jsonModificado;

        }

        public string JSON34Gateway(Int64 CantidadTotal, string fecha, string fechaVenc, string NuevaRutaCarpeta, string RutEmpresa, int Tipo_docu, Int64 FolioDesde)
        {
            string jsonModificado = "";
            string GATEWAY34 = @"{
  ""AsignacionFolio"": ""SI"",
  ""VersionDocumento"": ""F22"",
  ""TipoContenido"": ""json"",
  ""Carga"": ""SI"",
  ""SalidaPDF"": ""SI"",
  ""SalidaPDFMerito"": ""SI"",
  ""Documento"": {
    ""ValoresLibres"": [
      """",
      ""30 Days"",
      ""HAWB^^1038669534^^MAWB^^157-12584736^^Origin^^Brussels^^Destination^^Santiago^^Flight(s)^^QR/8147^^ETD^^11.04.2021^^Insurance^^Not arranged by KN^^INCOTERM^^EXW VILVOORDE"",
      ""1038669534 / 157-12584736^^       40^^Pieces^^SPARE PARTS FOR KOMATSUEQUIPMENT^^      777.10^^      3.271^^^^         ^^^^^^            ^^           ^^^^         ^^^^^^            ^^           "",
      ""^^         ^^^^^^            ^^           ^^^^         ^^^^^^            ^^           ^^^^         ^^^^^^            ^^           "",
      ""^^         ^^^^^^            ^^           ^^^^         ^^^^^^            ^^           ^^^^         ^^^^^^            ^^           "",
      ""6560.13"",
      ""0.00"",
      ""^^^^USER:gustavo.picado"",
      """"
    ],
    ""Encabezado"": {
      ""TipoDocumento"": ""34"",
      ""Folio"": null,
      ""FolioCliente"": """",
      ""FechaEmision"": """",
      ""FormaPago"": 2.0,
      ""FechaVencimiento"": """",
      ""Emisor"": {
        ""RUT"": ""78079790-8"",
        ""RazonSocial"": ""KUEHNE + NAGEL LTDA."",
        ""Giro"": ""SERVICIOS DE TRANSPORTES Y SERV."",
        ""Direccion"": ""AV. APOQUINDO 4501 PISO 14 SANTIAGO CHILE"",
        ""Comuna"": ""LAS CONDES"",
        ""Ciudad"": ""SANTIAGO"",
        ""RUTMandante"": ""96843130-7"",
        ""Acteco"": [""620200""]
      },
      ""Receptor"": {
        ""RUT"": ""96843130-7"",
        ""CodigoInterno"": ""1038669534"",
        ""RazonSocial"": ""Komatsu Chile S.A."",
        ""Giro"": ""IMP.VTA MAQ.DE MOTORES Y REPUESTO"",
        ""Direccion"": ""Avenida Americo Vespucio 0631"",
        ""Comuna"": ""Quilicura"",
        ""Ciudad"": ""Quilicura""
      },
      ""Transporte"": {
        ""PatenteVehiculo"": """",
        ""DireccionDestino"": """",
        ""ComunaDestino"": """",
        ""CiudadDestino"": """"
      },
      ""MontoNeto"": 0.0,
      ""MontoExento"": 5553806.0,
      ""MontoPeriodo"": 0.0,
      ""MontoTotal"": 5553806.0
    },
    ""Detalles"": [
      {
        ""NroLinea"": 1.0,
        ""IndicadorExencion"": 1.0,
        ""Nombre"": ""Flete Aéreo"",
        ""Cantidad"": 1.0,
        ""PrecioUnitario"": 5364591.0,
        ""PrecioUnitarioOtraMoneda"": 6336.63,
        ""CodigoOtraMoneda"": ""EUR"",
        ""FactorConversionPesos"": 846.6,
        ""Monto"": 5364591.0,
        ""PrecioUnitarioFinal"": 0.0
      },
      {
        ""NroLinea"": 2.0,
        ""IndicadorExencion"": 1.0,
        ""Nombre"": ""Manejo Terminal en origen"",
        ""Cantidad"": 1.0,
        ""PrecioUnitario"": 10159.0,
        ""PrecioUnitarioOtraMoneda"": 12.0,
        ""CodigoOtraMoneda"": ""EUR"",
        ""FactorConversionPesos"": 846.6,
        ""Monto"": 10159.0,
        ""PrecioUnitarioFinal"": 0.0
      },
      {
        ""NroLinea"": 3.0,
        ""IndicadorExencion"": 1.0,
        ""Nombre"": ""1500 PICK UP"",
        ""Cantidad"": 1.0,
        ""PrecioUnitario"": 78988.0,
        ""PrecioUnitarioOtraMoneda"": 93.3,
        ""CodigoOtraMoneda"": ""EUR"",
        ""FactorConversionPesos"": 846.6,
        ""Monto"": 78988.0,
        ""PrecioUnitarioFinal"": 0.0
      },
      {
        ""NroLinea"": 4.0,
        ""IndicadorExencion"": 1.0,
        ""Nombre"": ""Manejo en origen"",
        ""Cantidad"": 1.0,
        ""PrecioUnitario"": 21165.0,
        ""PrecioUnitarioOtraMoneda"": 25.0,
        ""CodigoOtraMoneda"": ""EUR"",
        ""FactorConversionPesos"": 846.6,
        ""Monto"": 21165.0,
        ""PrecioUnitarioFinal"": 0.0
      },
      {
        ""NroLinea"": 5.0,
        ""IndicadorExencion"": 1.0,
        ""Nombre"": ""Tasa Escaneo"",
        ""Cantidad"": 1.0,
        ""PrecioUnitario"": 78903.0,
        ""PrecioUnitarioOtraMoneda"": 93.2,
        ""CodigoOtraMoneda"": ""EUR"",
        ""FactorConversionPesos"": 846.6,
        ""Monto"": 78903.0,
        ""PrecioUnitarioFinal"": 0.0
      }
    ],
    ""ReferenciasGlobales"": [
      {
        ""NroLinea"": 1.0,
        ""TipoDocumento"": ""TN"",
        ""Folio"": ""1038669534"",
        ""Fecha"": ""2021-04-12""
      },
      {
        ""NroLinea"": 2.0,
        ""TipoDocumento"": ""809"",
        ""Folio"": ""1038669534"",
        ""Fecha"": ""2021-04-12"",
        ""Razon"": ""AWB""
      }
    ]
  }
}";
            for (int i = 1; i <= CantidadTotal; i++)
            {
                // Crea una copia del JSON original y reemplaza el valor del campo "FolioCliente"
                jsonModificado = GATEWAY34.Replace(@"""FolioCliente"": """"", $@"""FolioCliente"": ""{FolioDesde}""").
                    Replace(@"""FechaEmision"": """"", $@"""FechaEmision"": ""{fecha}""").
                    Replace(@"""FechaVencimiento"": """"", $@"""FechaVencimiento"": ""{fechaVenc}""");
                StreamWriter writer22 = new StreamWriter(NuevaRutaCarpeta + "\\34\\" + "JsonGatewayE0" + RutEmpresa + "T" + Tipo_docu + "0000" + FolioDesde + ".txt", false, Encoding.Default);

                writer22.WriteLine(jsonModificado.TrimEnd());
                writer22.Close();
                FolioDesde++;
            }

            return jsonModificado;
        }

        public string JSON39Gateway(Int64 CantidadTotal, string fecha, string fechaVenc, string NuevaRutaCarpeta, string RutEmpresa, int Tipo_docu, Int64 FolioDesde)
        {
            string jsonModificado = "";
            string GATEWAY39 = @"{
  ""AsignacionFolio"": ""SI"",
  ""VersionDocumento"": ""F2"",
  ""TipoContenido"": ""json"",
  ""Carga"": ""SI"",
  ""SalidaPDF"": ""SI"",
  ""SalidaPDFMerito"": ""SI"",
  ""Impresion"": {
    ""Ruta"": ""Wondershare PDFelement"",
    ""CopiasMerito"": 0,
    ""CopiasNorma"": 1
  },
  ""Documento"": {
    ""ValoresLibres"": [
      """",
      ""INGRESO 7 PERSONAS POR 30 DIAS"",
      """",
      ""|||||"",
      """",
      ""CON CHEQUE"",
      ""|772.83|28700.20|TERMINAL MOLO|1||22-09-2020|ALEJANDRA VASQUEZ ACEVEDO|OTROS|||"",
      """",
      ""0"",
      ""1.00""
    ],
    ""Encabezado"": {
      ""TipoDocumento"": ""39"",
      ""FolioCliente"": """",
      ""FechaEmision"": """",
      ""IndicadorServicioPeriodico"": 3.0,
      ""PeriodoDesde"": ""2026-05-12"",
      ""PeriodoHasta"": ""2026-10-01"",
      ""FechaVencimiento"": """",
      ""IndicadorMontoNeto"": true,
      ""Emisor"": {
        ""RUT"": ""78079790-8"",
        ""RazonSocial"": ""Dbnet"",
        ""Giro"": ""DEPOSITO Y ALMACENAM. Y OTROS SERV."",
        ""Direccion"": ""AV. JORGE BARRERA N 62"",
        ""Comuna"": ""IQUIQUE"",
        ""Ciudad"": ""IQUIQUE""
      },
      ""Receptor"": {
        ""RUT"": ""66666666-6"",
        ""CodigoInterno"": ""66666666"",
        ""RazonSocial"": ""CBT ING.Y CONSTR. LTDA"",
        ""Direccion"": ""RECINTO PORTUARIO S N"",
        ""Comuna"": ""IQUIQUE"",
        ""Ciudad"": ""IQUIQUE""
      },
      ""MontoNeto"": 81150.0,
      ""IVA"": 15418,
      ""MontoTotal"": 96565.0,
      ""TotalPeriodo"": 96565.0,
      ""SaldoAnterior"": 1000.0,
      ""ValorAPagar"": 97565.0
    },
    ""Detalles"": [
      {
        ""NroLinea"": 1.0,
        ""Nombre"": ""21 UND PERMISO ACCESO PERSONAS 1 A 10 DIAS"",
        ""Cantidad"": 1.000000,
        ""UnidadMedida"": ""UND"",
        ""PrecioUnitario"": 81147.0,
        ""ValorItem"": 81147.0,
        ""CodigosItem"": [
          {
            ""Tipo"": ""INT"",
            ""Codigo"": ""LSP 46560""
          }
        ]
      }
    ]
  }
}"; 
            for (int i = 1; i <= CantidadTotal; i++)
            {
                // Crea una copia del JSON original y reemplaza el valor del campo "FolioCliente"
                jsonModificado = GATEWAY39.Replace(@"""FolioCliente"": """"", $@"""FolioCliente"": ""{FolioDesde}""").
                    Replace(@"""FechaEmision"": """"", $@"""FechaEmision"": ""{fecha}""").
                    Replace(@"""FechaVencimiento"": """"", $@"""FechaVencimiento"": ""{fechaVenc}""");
                StreamWriter writer22 = new StreamWriter(NuevaRutaCarpeta + "\\39\\" + "JsonGatewayE0" + RutEmpresa + "T" + Tipo_docu + "0000" + FolioDesde + ".txt", false, Encoding.Default);

                writer22.WriteLine(jsonModificado.TrimEnd());
                writer22.Close();
                FolioDesde++;
            }

            return jsonModificado;
        }
        public string JSON41Gateway(Int64 CantidadTotal, string fecha, string fechaVenc, string NuevaRutaCarpeta, string RutEmpresa, int Tipo_docu, Int64 FolioDesde)
        {
            string jsonModificado = "";
            string GATEWAY41 = @"{
  ""AsignacionFolio"": ""SI"",
  ""VersionDocumento"": ""F2"",
  ""TipoContenido"": ""json"",
  ""Carga"": ""SI"",
  ""SalidaPDF"": ""SI"",
  ""SalidaPDFMerito"": ""SI"",
  ""Documento"": {
    ""ValoresLibres"": [
      ""FE_NORACID_SCL01"",
      ""0094311104-CVARELA-Bol-0040005476"",
      ""SERVICIOS ULTRACORP"",
      """",
      """",
      """",
      """",
      ""219"",
      """",
      ""Hecho no gravado DL 825 de 1974""
    ],
    ""Encabezado"": {
      ""TipoDocumento"": ""41"",
      ""Folio"": null,
      ""FolioCliente"": """",
      ""FechaEmision"": """",
      ""IndicadorServicioPeriodico"": 3.0,
      ""FechaVencimiento"": """",
      ""IndicadorMontoNeto"": true,
      ""Emisor"": {
        ""RUT"": ""78079790-8"",
        ""RazonSocial"": ""Dbnet"",
        ""Giro"": ""Arriendo de Oficinas con Muebles"",
        ""Direccion"": ""Avda. El Bosque Norte 500"",
        ""Comuna"": ""LAS CONDES"",
        ""Ciudad"": ""Santiago""
      },
      ""Receptor"": {
        ""RUT"": ""66666666-6"",
        ""CodigoInterno"": ""0000115971"",
        ""RazonSocial"": ""MAIK BUROSE "",
        ""Direccion"": ""FRAY LEON  12334 LAS CONDES  LAS CONDES"",
        ""Comuna"": ""LAS CONDES"",
        ""Ciudad"": ""LAS CONDES""
      },
      ""MontoNeto"": null,
      ""MontoExento"": 32104.0,
      ""MontoTotal"": 32101.0,
      ""TotalPeriodo"": 32104.0,
      ""SaldoAnterior"": 1000.0,
      ""ValorAPagar"": 33104.0
    },
    ""Detalles"": [
      {
        ""NroLinea"": 1.0,
        ""UnidadMedida"": ""KL"",
        ""IndicadorExencion"": 1.0,
        ""Nombre"": ""Servicio: Arriendo de estacionamiento compartido"",
        ""Cantidad"": 1.0,
        ""PrecioUnitario"": 32104.0,
        ""ValorItem"": 32104.0
      }
    ]
  }
}";
            for (int i = 1; i <= CantidadTotal; i++)
            {
                // Crea una copia del JSON original y reemplaza el valor del campo "FolioCliente"
                jsonModificado = GATEWAY41.Replace(@"""FolioCliente"": """"", $@"""FolioCliente"": ""{FolioDesde}""").
                    Replace(@"""FechaEmision"": """"", $@"""FechaEmision"": ""{fecha}""").
                    Replace(@"""FechaVencimiento"": """"", $@"""FechaVencimiento"": ""{fechaVenc}""");
                StreamWriter writer22 = new StreamWriter(NuevaRutaCarpeta + "\\41\\" + "JsonGatewayE0" + RutEmpresa + "T" + Tipo_docu + "0000" + FolioDesde + ".txt", false, Encoding.Default);

                writer22.WriteLine(jsonModificado.TrimEnd());
                writer22.Close();
                FolioDesde++;
            }

            return jsonModificado;
        }
        public string JSON43Gateway(Int64 CantidadTotal, string fecha, string fechaVenc, string NuevaRutaCarpeta, string RutEmpresa, int Tipo_docu, Int64 FolioDesde)
        {
            string jsonModificado = "";
            string GATEWAY43 = @"{
  ""AsignacionFolio"": ""SI"",
  ""VersionDocumento"": ""F22"",
  ""TipoContenido"": ""json"",
  ""Carga"": ""SI"",
  ""SalidaPDF"": ""SI"",
  ""SalidaPDFMerito"": ""SI"",
  ""Documento"": {
    ""ValoresLibres"": [
      """",
      """",
      """",
      """",
      """",
      """",
      """",
      """",
      """",
      """"
    ],
    ""Encabezado"": {
      ""TipoDocumento"": ""43"",
      ""Folio"": null,
      ""FolioCliente"": """",
      ""FechaEmision"": """",
      ""FormaPago"": 2.0,
      ""DiasTerminoPago"": 0.0,
      ""FechaVencimiento"": """",
      ""Emisor"": {
        ""RUT"": ""78079790-8"",
        ""RazonSocial"": ""DBNET Ingenieria de Software"",
        ""Giro"": ""venta de confites"",
        ""Direccion"": ""18 sep 1234"",
        ""Comuna"": "" HUECHURABA"",
        ""Ciudad"": ""SANTIAGO"",
        ""Acteco"": [""620200""]
      },
      ""Receptor"": {
        ""RUT"": ""78079790-8"",
        ""CodigoInterno"": ""111"",
        ""RazonSocial"": ""dbnet"",
        ""Giro"": ""Papas"",
        ""Contacto"": ""511551"",
        ""Direccion"": ""dbnet"",
        ""Comuna"": "" CERRILLOS"",
        ""Ciudad"": ""SANTIAGO""
      },
      ""Transporte"": {
        ""PatenteVehiculo"": """",
        ""DireccionDestino"": """",
        ""ComunaDestino"": """",
        ""CiudadDestino"": """"
      },
      ""MontoNeto"": 33.0,
      ""MontoExento"": 0.0,
      ""MontoBase"": 0.0,
      ""TasaIVA"": 19.00,
      ""IVA"": 6.0,
      ""IVANoRetenido"": 0.0,
      ""CreditoEmpresaConstruccion"": 0.0,
      ""GarantiaDeposito"": 0.0,
      ""MontoNoFacturable"": 0.0,
      ""MontoTotal"": 39.0,
      ""SaldoAnterior"": 0.0,
      ""ValorAPagar"": 0.0
    },
    ""Detalles"": [
      {
        ""NroLinea"": 1.0,
        ""Nombre"": ""a"",
        ""Descripcion"": ""a"",
        ""Cantidad"": 1.0,
        ""PrecioUnitario"": 3.0,
        ""PorcentajeDescuento"": 0.0,
        ""MontoDescuento"": 0.0,
        ""PorcentajeRecargo"": 0.0,
        ""MontoRecargo"": 0.0,
        ""Monto"": 3.0,
        ""PrecioUnitarioFinal"": 0.0,
        ""CodigosItem"": [
          {
            ""Tipo"": ""INT1"",
            ""Codigo"": ""123""
          },
          {
            ""Tipo"": ""DUN14"",
            ""Codigo"": ""2""
          }
        ],
        ""TipoDocumentoLiquidacion"": ""33""
      }
    ]
  }
}";
            for (int i = 1; i <= CantidadTotal; i++)
            {
                // Crea una copia del JSON original y reemplaza el valor del campo "FolioCliente"
                jsonModificado = GATEWAY43.Replace(@"""FolioCliente"": """"", $@"""FolioCliente"": ""{FolioDesde}""").
                    Replace(@"""FechaEmision"": """"", $@"""FechaEmision"": ""{fecha}""").
                    Replace(@"""FechaVencimiento"": """"", $@"""FechaVencimiento"": ""{fechaVenc}""");
                StreamWriter writer22 = new StreamWriter(NuevaRutaCarpeta + "\\43\\" + "JsonGatewayE0" + RutEmpresa + "T" + Tipo_docu + "0000" + FolioDesde + ".txt", false, Encoding.Default);

                writer22.WriteLine(jsonModificado.TrimEnd());
                writer22.Close();
                FolioDesde++;
            }

            return jsonModificado;
        }
        public string JSON46Gateway(Int64 CantidadTotal, string fecha, string fechaVenc, string NuevaRutaCarpeta, string RutEmpresa, int Tipo_docu, Int64 FolioDesde)
        {
            string jsonModificado = "";
            string GATEWAY46 = @"{
  ""AsignacionFolio"": ""SI"",
  ""VersionDocumento"": ""F22"",
  ""TipoContenido"": ""json"",
  ""Carga"": ""SI"",
  ""SalidaPDF"": ""SI"",
  ""SalidaPDFMerito"": ""SI"",
  ""Documento"": {
    ""ValoresLibres"": [
      """",
      """",
      """",
      """",
      """",
      """",
      """",
      """",
      """",
      """"
    ],
    ""Encabezado"": {
      ""TipoDocumento"": ""46"",
      ""Folio"": null,
      ""FolioCliente"": """",
      ""FechaEmision"": """",
      ""Emisor"": {
        ""RUT"": ""78079790-8"",
        ""RazonSocial"": ""UNIVERSIDAD DE LOS LAGOS"",
        ""Giro"": ""EDUCACION"",
        ""Direccion"": ""AVENIDA FUCHSLOCHER 1305"",
        ""Comuna"": ""OSORNO"",
        ""Acteco"": [""620200""]
      },
      ""Receptor"": {
        ""RUT"": ""10777715-6"",
        ""RazonSocial"": ""JOSE LEONEL VILLARROEL CASANOVA"",
        ""Giro"": ""OTRAS ACTIV.DE SERV.PERSONALES N.C.P."",
        ""Contacto"": ""."",
        ""Direccion"": ""CARRETERA AUSTRAL KILOMETRO 30 ."",
        ""Comuna"": ""PUERTO MONTT"",
        ""Ciudad"": ""PUERTO MONTT""
      },
      ""Transporte"": {
        ""PatenteVehiculo"": """",
        ""DireccionDestino"": """",
        ""ComunaDestino"": """",
        ""CiudadDestino"": """"
      },
      ""MontoNeto"": 126000.0,
      ""MontoExento"": 0.0,
      ""TasaIVA"": 19.00,
      ""IVA"": 23940.0,
      ""MontoTotal"": 126000.0,
      ""GlosaTerminoPago"": ""CREDITO""
    },
    ""ImpuestosYRetenciones"": [
      {
        ""Tipo"": ""15"",
        ""Tasa"": 19.00,
        ""Valor"": 23940.0
      }
    ],
    ""Detalles"": [
      {
        ""NroLinea"": 1.0,
        ""Nombre"": ""COMPRA DE 63 KILOGRAMOS DE PESCADO FRESCO PARA ALIMENTO DE CONGRIOS VALOR UNITAR"",
        ""Descripcion"": ""IO $2.000.- EL KILOGRAMO."",
        ""Cantidad"": 63.0,
        ""PrecioUnitario"": 2000.0,
        ""CodigoImpuestoAdicional"": ""15"",
        ""Monto"": 126000.0,
        ""PrecioUnitarioFinal"": 0.0
      }
    ]
  }
}";
            for (int i = 1; i <= CantidadTotal; i++)
            {
                // Crea una copia del JSON original y reemplaza el valor del campo "FolioCliente"
                jsonModificado = GATEWAY46.Replace(@"""FolioCliente"": """"", $@"""FolioCliente"": ""{FolioDesde}""").
                    Replace(@"""FechaEmision"": """"", $@"""FechaEmision"": ""{fecha}""");
                StreamWriter writer22 = new StreamWriter(NuevaRutaCarpeta + "\\46\\" + "JsonGatewayE0" + RutEmpresa + "T" + Tipo_docu + "0000" + FolioDesde + ".txt", false, Encoding.Default);

                writer22.WriteLine(jsonModificado.TrimEnd());
                writer22.Close();
                FolioDesde++;
            }

            return jsonModificado;
        }
        public string JSON52Gateway(Int64 CantidadTotal, string fecha, string fechaVenc, string NuevaRutaCarpeta, string RutEmpresa, int Tipo_docu, Int64 FolioDesde)
        {
            string jsonModificado = "";
            string GATEWAY52 = @"{
  ""AsignacionFolio"": ""SI"",
  ""VersionDocumento"": ""F22"",
  ""TipoContenido"": ""json"",
  ""Carga"": ""SI"",
  ""SalidaPDF"": ""SI"",
  ""SalidaPDFMerito"": ""SI"",
  ""Documento"": {
    ""ValoresLibres"": [
      ""\\FACTURAE_IILP60_1"",
      "".                                                           "",
      """",
      ""3"",
      """",
      """",
      """",
      ""86 CONTROL CALIDAD BERC.|"",
      ""."",
      ""2""
    ],
    ""Encabezado"": {
      ""TipoDocumento"": ""52"",
      ""Folio"": null,
      ""FolioCliente"": """",
      ""FechaEmision"": """",
      ""TipoDespacho"": 2.0,
      ""IndicadorTraslado"": 6.0,
      ""Emisor"": {
        ""RUT"": ""78079790-8"",
        ""RazonSocial"": ""BERCOVICH LTDA."",
        ""Giro"": ""FABRICACION, IMPORTACION, VENTA Y EXP"",
        ""Direccion"": ""A.PDTE.RIESCO 8736 LTA-COND.IND.VENTISQUERO"",
        ""Comuna"": ""RENCA"",
        ""Acteco"": [""620200""]
      },
      ""Receptor"": {
        ""RUT"": ""16124089-3"",
        ""RazonSocial"": ""GARATE MARIO ANDRES ESPINOZA"",
        ""Giro"": ""GIRO NO IDENTIFICADO                    "",
        ""Direccion"": ""EL HIDALGO 3705"",
        ""Comuna"": ""Puente Alto"",
        ""Ciudad"": ""SANTIAGO""
      },
      ""Transporte"": {
        ""PatenteVehiculo"": ""."",
        ""DireccionDestino"": """",
        ""ComunaDestino"": """",
        ""CiudadDestino"": """",
        ""Aduana"": {
          ""TotalItems"": 0.0
        }
      },
      ""MontoNeto"": 0.0,
      ""MontoExento"": 0.0,
      ""TasaIVA"": 19.0,
      ""IVA"": 0.0,
      ""MontoTotal"": 0.0
    },
    ""Detalles"": [
      {
        ""NroLinea"": 1.0,
        ""Nombre"": ""SE ENVIAN 5 BLUSAS PARA REPONER PIEZAS"",
        ""PrecioReferencia"": 0.0,
        ""Cantidad"": 1.0,
        ""UnidadMedida"": ""UNI"",
        ""PrecioUnitario"": 0.0,
        ""Monto"": 0.0,
        ""PrecioUnitarioFinal"": 0.0,
        ""CodigosItem"": [
          {
            ""Tipo"": ""INT1"",
            ""Codigo"": ""9999""
          }
        ]
      },
      {
        ""NroLinea"": 2.0,
        ""Nombre"": ""MOD. B-61353-600 EMP # 500 SCOTIABANK"",
        ""PrecioReferencia"": 0.0,
        ""Cantidad"": 1.0,
        ""UnidadMedida"": ""UNI"",
        ""PrecioUnitario"": 0.0,
        ""Monto"": 0.0,
        ""PrecioUnitarioFinal"": 0.0,
        ""CodigosItem"": [
          {
            ""Tipo"": ""INT1"",
            ""Codigo"": ""9999""
          }
        ]
      }
    ]
  }
}";
            for (int i = 1; i <= CantidadTotal; i++)
            {
                // Crea una copia del JSON original y reemplaza el valor del campo "FolioCliente"
                jsonModificado = GATEWAY52.Replace(@"""FolioCliente"": """"", $@"""FolioCliente"": ""{FolioDesde}""").
                    Replace(@"""FechaEmision"": """"", $@"""FechaEmision"": ""{fecha}""");
                StreamWriter writer22 = new StreamWriter(NuevaRutaCarpeta + "\\52\\" + "JsonGatewayE0" + RutEmpresa + "T" + Tipo_docu + "0000" + FolioDesde + ".txt", false, Encoding.Default);

                writer22.WriteLine(jsonModificado.TrimEnd());
                writer22.Close();
                FolioDesde++;
            }

            return jsonModificado;
        }
        public string JSON56Gateway(Int64 CantidadTotal, string fecha, string fechaVenc, string NuevaRutaCarpeta, string RutEmpresa, int Tipo_docu, Int64 FolioDesde)
        {
            string jsonModificado = "";
            string GATEWAY56 = @"{
  ""AsignacionFolio"": ""SI"",
  ""VersionDocumento"": ""F22"",
  ""TipoContenido"": ""json"",
  ""Carga"": ""SI"",
  ""SalidaPDF"": ""SI"",
  ""SalidaPDFMerito"": ""SI"",
  ""Documento"": {
    ""Encabezado"": {
      ""TipoDocumento"": ""56"",
      ""Folio"": null,
      ""FolioCliente"": """",
      ""FechaEmision"": """",
      ""FechaVencimiento"": """",
      ""Emisor"": {
        ""RUT"": ""78079790-8"",
        ""RazonSocial"": ""DBNET"",
        ""Giro"": ""TIC"",
        ""Direccion"": ""8"",
        ""Comuna"": ""SANTIAGO"",
        ""Acteco"": [""620200""]
      },
      ""Receptor"": {
        ""RUT"": ""78079790-8"",
        ""CodigoInterno"": ""1234567894"",
        ""RazonSocial"": ""DBNET"",
        ""Giro"": ""TIC"",
        ""Contacto"": ""065-2265500"",
        ""Direccion"": ""AV SIEMPRE VIVA"",
        ""Comuna"": ""PUERTO MONTT"",
        ""Ciudad"": ""LLANQUIHUE""
      },
      ""Transporte"": {
        ""PatenteVehiculo"": """",
        ""DireccionDestino"": """",
        ""ComunaDestino"": """",
        ""CiudadDestino"": """"
      },
      ""MontoNeto"": 199200.0,
      ""MontoExento"": 0.0,
      ""TasaIVA"": 19.00,
      ""IVA"": 37848.0,
      ""MontoTotal"": 237048.0
    },
    ""ImpuestosYRetenciones"": [
      {
        ""Tipo"": ""50"",
        ""Tasa"": 9.0,
        ""Valor"": 20.0
      }
    ],
    ""Detalles"": [
      {
        ""NroLinea"": 1.0,
        ""Nombre"": ""Coliflor"",
        ""Cantidad"": 1.0,
        ""PrecioUnitario"": 864145.0,
        ""Monto"": 864145.0,
        ""IndicadorAgente"": ""R"",
        ""MontoBaseFaena"": 100.0
      },
      {
        ""NroLinea"": 2.0,
        ""Nombre"": ""Dátil"",
        ""Cantidad"": 1.0,
        ""PrecioUnitario"": 977481.0,
        ""Monto"": 977481.0,
        ""IndicadorAgente"": ""R"",
        ""MargenComercializacion"": 200.0
      },
      {
        ""NroLinea"": 3.0,
        ""Nombre"": ""Betabel"",
        ""Cantidad"": 1.0,
        ""PrecioUnitario"": 842942.0,
        ""Monto"": 842942.0,
        ""IndicadorAgente"": ""R"",
        ""PrecioUnitarioFinal"": 300.0
      },
      {
        ""NroLinea"": 4.0,
        ""Nombre"": ""Ajo"",
        ""Cantidad"": 1.0,
        ""PrecioUnitario"": 349403.0,
        ""Monto"": 349403.0,
        ""IndicadorAgente"": ""R"",
        ""MontoBaseFaena"": 100.0,
        ""MargenComercializacion"": 200.0,
        ""PrecioUnitarioFinal"": 300.0
      }
    ],
    ""ReferenciasGlobales"": [
      {
        ""NroLinea"": 1.0,
        ""TipoDocumento"": ""801"",
        ""Folio"": ""12"",
        ""Codigo"": 1,
        ""Fecha"": ""2015-04-22""
      }
    ]
  }
}";
            for (int i = 1; i <= CantidadTotal; i++)
            {
                // Crea una copia del JSON original y reemplaza el valor del campo "FolioCliente"
                jsonModificado = GATEWAY56.Replace(@"""FolioCliente"": """"", $@"""FolioCliente"": ""{FolioDesde}""").
                    Replace(@"""FechaEmision"": """"", $@"""FechaEmision"": ""{fecha}""").
                    Replace(@"""FechaVencimiento"": """"", $@"""FechaVencimiento"": ""{fechaVenc}""");
                StreamWriter writer22 = new StreamWriter(NuevaRutaCarpeta + "\\56\\" + "JsonGatewayE0" + RutEmpresa + "T" + Tipo_docu + "0000" + FolioDesde + ".txt", false, Encoding.Default);

                writer22.WriteLine(jsonModificado.TrimEnd());
                writer22.Close();
                FolioDesde++;
            }

            return jsonModificado;
        }
        public string JSON61Gateway(Int64 CantidadTotal, string fecha, string fechaVenc, string NuevaRutaCarpeta, string RutEmpresa, int Tipo_docu, Int64 FolioDesde)
        {
            string jsonModificado = "";
            string GATEWAY61 = @"{
  ""AsignacionFolio"": ""SI"",
  ""VersionDocumento"": ""F22"",
  ""TipoContenido"": ""json"",
  ""Carga"": ""SI"",
  ""SalidaPDF"": ""SI"",
  ""SalidaPDFMerito"": ""SI"",
  ""Documento"": {
    ""ValoresLibres"": [
      ""\\FACTURAE_IILP60_1"",
      ""0 Days"",
      ""VESSEL :^^POLYNESIA^^VOY :^^0GI2WR1MA^^P.O.L. :^^Bilbao^^ETS :^^28.02.2021^^P.O.D. :^^Arica^^ETA :^^22.04.2021^^^^^^^^"",
      ""^^        1^^40' HC^^^^    24620.00^^     60.000^^CMAU4028654^^        1^^40' HC^^CONTAINER SAID TO CONTAIN:^^    24620.00^^     60.000^^Seal No. G9669802^^         ^^^^18 Piezas^^            ^^           "",
      ""^^         ^^^^PIENSOS PARA ALIMENTACIóNN^^            ^^           ^^^^         ^^^^ANIMAL^^            ^^           ^^^^         ^^^^FEEDS FOR ANIMAL NUTRITIOO^^            ^^           "",
      ""^^         ^^^^HS CODE:2309909695 80^^            ^^           ^^^^         ^^^^18 PALLETS^^            ^^           ^^^^         ^^^^MERCANCIA EN TRANSITO A^^            ^^           "",
      ""455252.00"",
      ""72687.00"",
      ""Anula factura por error en facturación^^^^USER:gilda.jara"",
      """"
    ],
    ""Encabezado"": {
      ""TipoDocumento"": ""61"",
      ""Folio"": null,
      ""FolioCliente"": """",
      ""FechaEmision"": """",
      ""FormaPago"": 1.0,
      ""FechaVencimiento"": """",
      ""Emisor"": {
        ""RUT"": ""78079790-8"",
        ""RazonSocial"": ""KUEHNE + NAGEL LTDA."",
        ""Giro"": ""SERVICIOS DE TRANSPORTES Y SERV."",
        ""Direccion"": ""AV. APOQUINDO 4501 PISO 14 SANTIAGO CHILE"",
        ""Comuna"": ""LAS CONDES"",
        ""Ciudad"": ""SANTIAGO"",
        ""RUTMandante"": ""76065775-1"",
        ""Acteco"": [""620200""]
      },
      ""Receptor"": {
        ""RUT"": ""76065775-1"",
        ""CodigoInterno"": ""1037626799"",
        ""RazonSocial"": ""Faes Farma Chile, Salud Y Nutricion Limitada"",
        ""Giro"": ""VTA AL POR MAYOR DE ALIMENTOS"",
        ""Direccion"": ""Avenida Apoquindo Alimento Para Animales 6314 Oficina 604"",
        ""Comuna"": ""Santiago"",
        ""Ciudad"": ""Santiago""
      },
      ""Transporte"": {
        ""PatenteVehiculo"": """",
        ""DireccionDestino"": """",
        ""ComunaDestino"": """",
        ""CiudadDestino"": """"
      },
      ""MontoNeto"": 382565.0,
      ""MontoExento"": 0.0,
      ""TasaIVA"": 19.0,
      ""IVA"": 72687.0,
      ""MontoPeriodo"": 455252.0,
      ""MontoTotal"": 455252.0,
      ""FolioCliente"": ""2""
    },
    ""Detalles"": [
      {
        ""NroLinea"": 1.0,
        ""Nombre"": ""Container Guarantee"",
        ""Cantidad"": 1.0,
        ""PrecioUnitario"": 126319.0,
        ""Monto"": 126319.0,
        ""PrecioUnitarioFinal"": 0.0
      },
      {
        ""NroLinea"": 2.0,
        ""Nombre"": ""THC - Import FFF"",
        ""Cantidad"": 1.0,
        ""PrecioUnitario"": 108273.0,
        ""Monto"": 108273.0,
        ""PrecioUnitarioFinal"": 0.0
      },
      {
        ""NroLinea"": 3.0,
        ""Nombre"": ""Handling Fee"",
        ""Cantidad"": 1.0,
        ""PrecioUnitario"": 36091.0,
        ""Monto"": 36091.0,
        ""PrecioUnitarioFinal"": 0.0
      },
      {
        ""NroLinea"": 4.0,
        ""Nombre"": ""B/L Fee Import"",
        ""Cantidad"": 1.0,
        ""PrecioUnitario"": 46918.0,
        ""Monto"": 46918.0,
        ""PrecioUnitarioFinal"": 0.0
      },
      {
        ""NroLinea"": 5.0,
        ""Nombre"": ""GASTOS DE MANIFIESTO"",
        ""Cantidad"": 1.0,
        ""PrecioUnitario"": 64964.0,
        ""Monto"": 64964.0,
        ""PrecioUnitarioFinal"": 0.0
      }
    ],
    ""ReferenciasGlobales"": [
      {
        ""NroLinea"": 1.0,
        ""TipoDocumento"": ""33"",
        ""Folio"": ""506084"",
        ""Fecha"": ""2021-04-04"",
        ""Codigo"": 3.0
      },
      {
        ""NroLinea"": 2.0,
        ""TipoDocumento"": ""TN"",
        ""Folio"": ""1037626799"",
        ""Fecha"": ""2021-04-12"",
        ""Codigo"": 2.0
      },
      {
        ""NroLinea"": 3.0,
        ""TipoDocumento"": ""808"",
        ""Folio"": ""2230-0452-102.018"",
        ""Fecha"": ""2021-04-12"",
        ""Codigo"": 2.0,
        ""Razon"": ""BAL""
      }
    ]
  }
}";
            for (int i = 1; i <= CantidadTotal; i++)
            {
                // Crea una copia del JSON original y reemplaza el valor del campo "FolioCliente"
                jsonModificado = GATEWAY61.Replace(@"""FolioCliente"": """"", $@"""FolioCliente"": ""{FolioDesde}""").
                    Replace(@"""FechaEmision"": """"", $@"""FechaEmision"": ""{fecha}""").
                    Replace(@"""FechaVencimiento"": """"", $@"""FechaVencimiento"": ""{fechaVenc}""");
                StreamWriter writer22 = new StreamWriter(NuevaRutaCarpeta + "\\61\\" + "JsonGatewayE0" + RutEmpresa + "T" + Tipo_docu + "0000" + FolioDesde + ".txt", false, Encoding.Default);

                writer22.WriteLine(jsonModificado.TrimEnd());
                writer22.Close();
                FolioDesde++;
            }

            return jsonModificado;
        }
        public string JSON110Gateway(Int64 CantidadTotal, string fecha, string fechaVenc, string NuevaRutaCarpeta, string RutEmpresa, int Tipo_docu, Int64 FolioDesde)
        {
            string jsonModificado = "";
            string GATEWAY110 = @"{
  ""AsignacionFolio"": ""SI"",
  ""VersionDocumento"": ""F22"",
  ""TipoContenido"": ""json"",
  ""Carga"": ""SI"",
  ""SalidaPDF"": ""SI"",
  ""SalidaPDFMerito"": ""SI"",
  ""Documento"": {
    ""ValoresLibres"": [
      """",
      ""0095000025"",
      """",
      """",
      """",
      """",
      """",
      """",
      """",
      """"
    ],
    ""Encabezado"": {
      ""TipoDocumento"": ""110"",
      ""FolioCliente"": """",
      ""FechaEmision"": """",
      ""FormaPago"": 2.0,
      ""FechaVencimiento"": """",
      ""Emisor"": {
        ""RUT"": ""78079790-8"",
        ""RazonSocial"": ""SALMONES MULTIEXPORT S.A."",
        ""Giro"": ""GIRO MULTIEXPORT"",
        ""Sucursal"": ""S100"",
        ""Direccion"": ""Avda Cardonal 2501"",
        ""Comuna"": ""Puerto Montt"",
        ""Ciudad"": ""Puerto Montt"",
        ""Acteco"": [""620200""]
      },
      ""Receptor"": {
        ""RUT"": ""55555555-5"",
        ""CodigoInterno"": ""0012000678"",
        ""RazonSocial"": ""OOO AKRA"",
        ""Giro"": ""."",
        ""Direccion"": ""NAB. REKI SMOLENKI, D.14, LITER A,"",
        ""Comuna"": ""ST PETERSBURG"",
        ""Ciudad"": ""ST PETERSBURG""
      },
      ""Transporte"": {
        ""PatenteVehiculo"": """",
        ""DireccionDestino"": """",
        ""ComunaDestino"": """",
        ""CiudadDestino"": """",
        ""Aduana"": {
          ""CodigoClausulaVenta"": 1.0
        }
      },
      ""MontoNeto"": 0.0,
      ""MontoExento"": 1000.00,
      ""MontoTotal"": 1000.00,
      ""GlosaTerminoPago"": ""Cobr Directa (Crédito) 30 días"",
      ""TipoMoneda"": ""DOLAR USA""
    },
    ""TiposBulto"": [
      {
        ""Codigo"": 22.0,
        ""Cantidad"": 10.0
      }
    ],
    ""Detalles"": [
      {
        ""NroLinea"": 1.0,
        ""Nombre"": ""FROZEN ATLANTIC SALMON HON IND. B 0,5-1 KG IQF"",
        ""Cantidad"": 100.0,
        ""UnidadMedida"": ""KG"",
        ""PrecioUnitario"": 10.00,
        ""Monto"": 1000.00,
        ""PrecioUnitarioFinal"": 0.0,
        ""CodigosItem"": [
          {
            ""Tipo"": ""INT1"",
            ""Codigo"": ""3000002""
          }
        ]
      }
    ]
  }
}";
            for (int i = 1; i <= CantidadTotal; i++)
            {
                // Crea una copia del JSON original y reemplaza el valor del campo "FolioCliente"
                jsonModificado = GATEWAY110.Replace(@"""FolioCliente"": """"", $@"""FolioCliente"": ""{FolioDesde}""").
                    Replace(@"""FechaEmision"": """"", $@"""FechaEmision"": ""{fecha}""").
                    Replace(@"""FechaVencimiento"": """"", $@"""FechaVencimiento"": ""{fechaVenc}""");
                StreamWriter writer22 = new StreamWriter(NuevaRutaCarpeta + "\\110\\" + "JsonGatewayE0" + RutEmpresa + "T" + Tipo_docu + "0000" + FolioDesde + ".txt", false, Encoding.Default);

                writer22.WriteLine(jsonModificado.TrimEnd());
                writer22.Close();
                FolioDesde++;
            }

            return jsonModificado;
        }
        public string JSON111Gateway(Int64 CantidadTotal, string fecha, string fechaVenc, string NuevaRutaCarpeta, string RutEmpresa, int Tipo_docu, Int64 FolioDesde)
        {
            string jsonModificado = "";
            string GATEWAY111 = @"{
  ""AsignacionFolio"": ""SI"",
  ""VersionDocumento"": ""F22"",
  ""TipoContenido"": ""json"",
  ""Carga"": ""SI"",
  ""Documento"": {
    ""ValoresLibres"": [
      ""SRP-VENLACETESTHPM602"",
      """",
      """",
      """",
      """",
      ""0"",
      ""0"",
      """",
      ""25.00"",
      ""0""
    ],
    ""Encabezado"": {
      ""TipoDocumento"": ""111"",
      ""FolioCliente"": """",
      ""FechaEmision"": """",
      ""FormaPago"": 1.0,
      ""FechaVencimiento"": """",
      ""Emisor"": {
        ""RUT"": ""78079790-8"",
        ""RazonSocial"": ""MARIENBERG"",
        ""Giro"": ""PRODUCCION Y COMERCIALIZACION DE ELEMENTOS PARA LA INDUSTRIA"",
        ""Direccion"": ""SANTA MARTA"",
        ""Comuna"": ""MAIPÚ"",
        ""Ciudad"": ""SANTIAGO"",
        ""CodigoVendedor"": ""GERENCIA"",
        ""Acteco"": [""620200""]
      },
      ""Receptor"": {
        ""RUT"": ""55555555-5"",
        ""CodigoInterno"": ""20-23644496-2"",
        ""RazonSocial"": ""CERMINARO JUAN MANUEL"",
        ""Giro"": ""IMPORTADORES DE PISOS Y ALFOMBRAS"",
        ""Contacto"": ""(+5411)6860 1925"",
        ""Direccion"": ""AV JUAN MANUEL DE ROSAS 138 – CASTELAR –MORON (1712)"",
        ""Comuna"": ""CASTELAR  MORON"",
        ""Ciudad"": ""BUENOS AIRES"",
        ""DireccionPostal"": ""U_CASILLA_CORR""
      },
      ""Transporte"": {
        ""PatenteVehiculo"": """",
        ""DireccionDestino"": """",
        ""ComunaDestino"": """",
        ""CiudadDestino"": """",
        ""Aduana"": {
          ""TotalBultos"": 0.0
        }
      },
      ""MontoNeto"": 0.0,
      ""MontoExento"": 25.00,
      ""MontoTotal"": 25.00,
      ""GlosaTerminoPago"": ""Depósito y/o Transferencia"",
      ""TipoMoneda"": ""DOLAR USA"",
      ""TipoMonedaOtraMoneda"": ""PESO CL"",
      ""TipoCambio"": 667.550000,
      ""MontoExentoOtraMoneda"": 16689.0,
      ""MontoTotalOtraMoneda"": 16689.00
    },
    ""Detalles"": [
      {
        ""NroLinea"": 1.0,
        ""Nombre"": ""Diferencia por tipo de Cambio al pagar Neto de FV 88989"",
        ""Descripcion"": ""Diferencia por tipo de Cambio al pagar Neto de FV 88989"",
        ""Cantidad"": 1.0,
        ""PrecioUnitario"": 25.00,
        ""PorcentajeDescuento"": 0.0,
        ""MontoDescuento"": 0.0,
        ""Monto"": 25.00,
        ""PrecioUnitarioFinal"": 0.0
      }
    ],
    ""ReferenciasGlobales"": [
      {
        ""NroLinea"": 1.0,
        ""TipoDocumento"": ""110"",
        ""Folio"": ""13"",
        ""Fecha"": ""2019-02-27"",
        ""Codigo"": 3.0
      }
    ],
    ""MailEnvio"": [
      {
        ""NroLinea"": 1.0,
        ""Direccion"": ""ventas@gpindustrial.com.ar"",
        ""Mensaje"": ""PDF""
      }
    ]
  }
}";
            for (int i = 1; i <= CantidadTotal; i++)
            {
                // Crea una copia del JSON original y reemplaza el valor del campo "FolioCliente"
                jsonModificado = GATEWAY111.Replace(@"""FolioCliente"": """"", $@"""FolioCliente"": ""{FolioDesde}""").
                    Replace(@"""FechaEmision"": """"", $@"""FechaEmision"": ""{fecha}""").
                    Replace(@"""FechaVencimiento"": """"", $@"""FechaVencimiento"": ""{fechaVenc}""");
                StreamWriter writer22 = new StreamWriter(NuevaRutaCarpeta + "\\111\\" + "JsonGatewayE0" + RutEmpresa + "T" + Tipo_docu + "0000" + FolioDesde + ".txt", false, Encoding.Default);

                writer22.WriteLine(jsonModificado.TrimEnd());
                writer22.Close();
                FolioDesde++;
            }

            return jsonModificado;
        }
        public string JSON112Gateway(Int64 CantidadTotal, string fecha, string fechaVenc, string NuevaRutaCarpeta, string RutEmpresa, int Tipo_docu, Int64 FolioDesde)
        {
            string jsonModificado = "";
            string GATEWAY112 = @"{
  ""AsignacionFolio"": ""SI"",
  ""VersionDocumento"": ""F22"",
  ""TipoContenido"": ""json"",
  ""Carga"": ""SI"",
  ""Documento"": {
    ""Encabezado"": {
      ""TipoDocumento"": ""112"",
      ""FolioCliente"": """",
      ""FechaEmision"": """",
      ""FechaVencimiento"": """",
      ""Emisor"": {
        ""RUT"": ""78079790-8"",
        ""RazonSocial"": ""GE HEALTHCARE INTERNATIONAL LLC AGENCIA EN CHILE"",
        ""Giro"": ""REP DE OTROS EQ ELECT Y OPTICOS N.C.P."",
        ""Direccion"": ""Isidora Goyenechea 2800,Piso 21"",
        ""Comuna"": ""Santiago"",
        ""Ciudad"": ""Las Condes"",
        ""Acteco"": [""620200""]
      },
      ""Receptor"": {
        ""RUT"": ""78079790-8"",
        ""RazonSocial"": ""GE HEALTHCARE COLOMBIA S.A.S."",
        ""Giro"": ""VENTA AL POR MAYOR NO ESPECIALIZADA"",
        ""Direccion"": ""CALLE 103 NO. 14 A-43"",
        ""Comuna"": ""Bogota"",
        ""Ciudad"": ""BOGOTA, D.C."",
        ""DireccionPostal"": ""110111""
      },
      ""Transporte"": {
        ""PatenteVehiculo"": """",
        ""DireccionDestino"": ""CALLE 103 NO. 14 A-43"",
        ""ComunaDestino"": ""Bogota"",
        ""CiudadDestino"": ""BOGOTA, D.C."",
        ""Aduana"": {
          ""CodigoModalidadVenta"": 1.0,
          ""CodigoClausulaVenta"": 8.0,
          ""CodigoPaisDestino"": 202.0
        }
      },
      ""MontoNeto"": 0.0,
      ""MontoExento"": 87840.76,
      ""MontoTotal"": 87840.76,
      ""FormaPagoExportacion"": 1.0,
      ""CodigoTraslado"": 1.0,
      ""TipoMoneda"": ""DOLAR USA"",
      ""TipoMonedaOtraMoneda"": ""PESO CL"",
      ""TipoCambio"": 693.0,
      ""MontoNetoOtraMoneda"": 60873646.68,
      ""MontoTotalOtraMoneda"": 60873646.68
    },
    ""Detalles"": [
      {
        ""NroLinea"": 1.0,
        ""IndicadorExencion"": 1.0,
        ""Nombre"": ""Por la provision de un equipo modelo marca GE Segun propuesta definitiva FDON"",
        ""Descripcion"": "" Por la provision de un equipo modelo marca GE Segun propuesta definitiva FDON"",
        ""UnidadMedidaReferencia"": ""10"",
        ""Cantidad"": 2583.55176,
        ""UnidadMedida"": ""10"",
        ""PrecioUnitario"": 34.0,
        ""Monto"": 87840.76,
        ""PrecioUnitarioFinal"": 0.0
      }
    ],
    ""ReferenciasGlobales"": [
      {
        ""NroLinea"": 1.0,
        ""TipoDocumento"": ""110"",
        ""Folio"": ""18"",
        ""Fecha"": ""2019-05-13"",
        ""Codigo"": 3.0,
        ""Razon"": ""Corrige montos""
      },
      {
        ""NroLinea"": 2.0,
        ""TipoDocumento"": ""801"",
        ""Codigo"": 3.0,
        ""Folio"": ""56756"",
        ""Fecha"": ""2019-05-13""
      }
    ]
  }
}";
            for (int i = 1; i <= CantidadTotal; i++)
            {
                // Crea una copia del JSON original y reemplaza el valor del campo "FolioCliente"
                jsonModificado = GATEWAY112.Replace(@"""FolioCliente"": """"", $@"""FolioCliente"": ""{FolioDesde}""").
                    Replace(@"""FechaEmision"": """"", $@"""FechaEmision"": ""{fecha}""").
                    Replace(@"""FechaVencimiento"": """"", $@"""FechaVencimiento"": ""{fechaVenc}""");
                StreamWriter writer22 = new StreamWriter(NuevaRutaCarpeta + "\\112\\" + "JsonGatewayE0" + RutEmpresa + "T" + Tipo_docu + "0000" + FolioDesde + ".txt", false, Encoding.Default);

                writer22.WriteLine(jsonModificado.TrimEnd());
                writer22.Close();
                FolioDesde++;
            }

            return jsonModificado;
        }

    }
}
