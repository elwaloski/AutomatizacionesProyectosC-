using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace GeneradorJsonFECO
{
    public partial class Form1 : Form
    {
        Conexion con = new Conexion();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                //Ruta Destino
                tbxRutaDestino.Text = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);

                //Cargar Combox y Textbox de la pestaña de Configuración
                CargarCmbEmpresaEmisora();
                cmbAsigAuto.SelectedIndex = 0;
                cmbEmpresaEmisora.SelectedIndex = 0;
                cmbEmpresaAdquiriente.SelectedIndex = 0;
                cmbIdArea.SelectedIndex = 0;
                cmbMetodoCarga.SelectedIndex = 0;
                cmbSeriePrefijo.SelectedIndex = 0;
                cmbTipoDocumento.SelectedIndex = 0;
                tbxCantidadDocumento.Text = "1";
                tbxCorrelativoDocumento.Text = "1";

                //Cargar Combox, DateTimePicker de la pestaña de Encabezado
                dtpFechaHoraEmision.CustomFormat = "yyyy-MM-dd | HH:mm:ss";
                cmbTipoOperacion.SelectedIndex = 0;
                cmbMonedaDocumento.SelectedIndex = 0;
                cmbTipoIdentificacionEmisor.SelectedIndex = 0;
                cmbRegimenEmisor.SelectedIndex = 0;
                cmbResponsabilidadEmisor.SelectedIndex = 0;
                cmbTipoIdentificacionAdquiriente.SelectedIndex = 0;
                cmbRegimenAdquiriente.SelectedIndex = 0;
                cmbResponsabilidadAdquiriente.SelectedIndex = 0;

                //Pestaña Medio Pago
                cmbFormaPago.SelectedIndex = 0;
                cmbMedioPago.SelectedIndex = 0;

                //Pestaña Items
                tbxCantidadItems.Text = "1";
                cmbUnidadMedida.SelectedIndex = 0;
                cmbImpuestoItem.SelectedIndex = 0;
                cmbCodigoItems.SelectedIndex = 0;
                cmbCodReferenciaItems.SelectedIndex = 0;
                tbxValorCodigo.Text = "1";

                //Pestaña Referencia
                cmbTipoReferencia.SelectedIndex = 0;
                cmbTipoDocReferencia.SelectedIndex = 0;
                dtpFechaDocReferencia.CustomFormat = "yyyy-MM-dd";
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            

        }

        #region Metodo Que Arma el json

        private void ArmarJson()
        {
            try
            {
                int iCantidad = int.Parse(tbxCantidadDocumento.Text);
                int iCantidadItem = int.Parse(tbxCantidadItems.Text);
                string json = "";
                EstructuraJson.InfoProc infoProc = null;
                EstructuraJson.InfoDoc encabezado = null;
                List<EstructuraJson.InfoDoc> direcion = null;
                List<EstructuraJson.InfoDoc> contacto = null;
                List<EstructuraJson.InfoDoc> impuesto = null;
                EstructuraJson.InfoDoc medioPago = null;
                List<EstructuraJson.InfoDoc> item = null;
                List<EstructuraJson.InfoDoc> impuestoItem = null;
                List<EstructuraJson.InfoDoc> cdgItem = null;
                List<EstructuraJson.InfoDoc> refeItem = null;
                EstructuraJson.InfoDoc referencia = null;
                EstructuraJson.InfoDoc correoDespacho = null;

                EstructuraJson.Root root = new EstructuraJson.Root(); //Contiene toda la info de cada documento
                List<EstructuraJson.Root> roots = new List<EstructuraJson.Root>(); //Contiene todos los documentos

                StreamWriter writer;

                for (int j = 0; j < iCantidad; j++)
                {
                    int iCorrelativo = int.Parse(tbxCorrelativoDocumento.Text) + j;

                    infoProc = EscribirInfoProc(iCorrelativo.ToString());
                    encabezado = EscribirEncabezado(iCorrelativo);
                    direcion = EscribirDireccion();
                    contacto = EscribirContacto();
                    impuesto = EscribirImpuesto();
                    medioPago = EscribirMedioPago(iCorrelativo);
                    item = EscribirItem(iCantidadItem);
                    impuestoItem = EscribirImpuestoItem(iCantidadItem);
                    cdgItem = EscribirCdgItem(iCantidadItem);
                    refeItem = EscribirRefeItem();
                    referencia = EscribirReferencia();
                    correoDespacho = EscribirCorreoDespacho();


                    List<EstructuraJson.InfoDoc> infoDocs = new List<EstructuraJson.InfoDoc>();

                    infoDocs.Add(encabezado);

                    for (int i = 0; i < direcion.Count; i++)
                    {
                        infoDocs.Add(direcion[i]);
                    }

                    for (int i = 0; i < contacto.Count; i++)
                    {
                        infoDocs.Add(contacto[i]);
                    }

                    for (int i = 0; i < impuesto.Count; i++)
                    {
                        infoDocs.Add(impuesto[i]);
                    }

                    infoDocs.Add(medioPago);

                    for (int i = 0; i < item.Count; i++)
                    {
                        infoDocs.Add(item[i]);
                        infoDocs.Add(impuestoItem[i]);
                        infoDocs.Add(cdgItem[i]);
                    }

                    if (refeItem != null)
                    {
                        for (int i = 0; i < refeItem.Count; i++)
                        {
                            infoDocs.Add(refeItem[i]);
                        }
                    }

                    if (referencia != null)
                    {
                        infoDocs.Add(referencia);
                    }

                    infoDocs.Add(correoDespacho);


                    root = new EstructuraJson.Root
                    {
                        infoProc = infoProc,
                        infoDoc = infoDocs
                    };


                    roots.Add(root);

                    ValidarRutaDestino(tbxRutaDestino.Text);

                }

                switch (cmbMetodoCarga.SelectedIndex)
                {
                    case 0: //Generar Archivo Json Normal
                        for (int i = 0; i < roots.Count; i++)
                        {
                            json = JsonConvert.SerializeObject(roots[i], new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
                            writer = new StreamWriter(tbxRutaDestino.Text + "\\" + roots[i].infoDoc[0].TipoDocumento + roots[i].infoProc.corrDoc + ".json");

                            writer.Write(json);
                            writer.Close();
                                                        
                        }

                        MessageBox.Show("Generación Data Completada");
                        System.Diagnostics.Process.Start(tbxRutaDestino.Text);

                        break;

                    case 1: //Carga por WSS
                        string respuesta="";
                        string serv = con.LeerArchivoConfig()[0];
                        for (int i = 0; i < roots.Count; i++)
                        {
                            json = JsonConvert.SerializeObject(roots[i], new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
                            respuesta = CallWssCargaDoc21(json,serv);
                        }

                        string[] respuestas = respuesta.Split('\n');
                        double cantidadError = 0;
                        double cantidadOk = 0;


                        for (int i = 0; i < respuestas.Count(); i++)
                        {

                            if (respuestas[i].Contains("NOK"))
                            {
                                cantidadError++;
                            }
                            else if (respuestas[i].Contains("OK"))
                            {
                                cantidadOk++;
                            }

                        }

                        double totalPorcentaje = (cantidadOk * 100) / iCantidad;

                        StreamWriter resp = new StreamWriter(tbxRutaDestino.Text.Trim() + "\\" + "RespWss_" + DateTime.Today.ToString("ddMMyyyy") + "_" + DateTime.Now.ToString("hhmmss") + ".txt", false);
                        resp.Write(respuesta);
                        resp.Close();
                        MessageBox.Show("Reporte: \n-Cargados OK: " + cantidadOk + "\n-No Cargados: " + cantidadError + "\n-Porcentaje de Carga Correcta: " + totalPorcentaje.ToString("N2") + "% \n\nEl detalle de las respuestas del WSS estan en la ruta de destino especificada");

                        System.Diagnostics.Process.Start(tbxRutaDestino.Text.Trim());

                        break;

                    case 2://Generar Array Json Tipo Allianz

                        json = JsonConvert.SerializeObject(roots, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
                        writer = new StreamWriter(tbxRutaDestino.Text + "\\" + encabezado.TipoDocumento + "_Array" + ".json");

                        writer.Write(json);
                        writer.Close();

                        MessageBox.Show("Generación Data Completada");
                        System.Diagnostics.Process.Start(tbxRutaDestino.Text);

                        break;

                    default: //Inyeccion directa a la bd
                        {
                            int val = con.CargaDocBD(iCantidad,int.Parse(tbxCorrelativoDocumento.Text), encabezado.TipoDocumento);
                            switch (val)
                            {
                                case 3: MessageBox.Show("Generación Data Completada");
                                    break;
                                case 2601: MessageBox.Show("Data No insertada, Documento ya existe");
                                    break;
                            }
                            break;
                        }
                }

            }
            catch (Exception e)
            {
                MessageBox.Show("Error: " + e.Message);
            }


        }

        #endregion

        #region Metodos que escribin los distintos nodos del json

        private EstructuraJson.InfoProc EscribirInfoProc(string iCorrDoc)
        {
            try
            {
                string sIdEmpr = cmbEmpresaEmisora.SelectedItem.ToString().Split('-')[0].Trim();
                string sIdArea = cmbIdArea.SelectedItem.ToString();
                string sTipoDoc = ConvertirTipoDocu();
                string sSerieDoc = cmbSeriePrefijo.SelectedItem.ToString();
                string sAsgCorr = "NO";

                if (cmbAsigAuto.SelectedIndex == 1)
                {
                    sSerieDoc = "";
                    iCorrDoc = "";
                    sAsgCorr = "SI";
                }


                EstructuraJson.InfoProc infoProc = new EstructuraJson.InfoProc
                {
                    idEmpr = sIdEmpr,
                    idArea = sIdArea,
                    tipoDoc = sTipoDoc,
                    SerieDoc = sSerieDoc,
                    corrDoc = iCorrDoc.ToString(),
                    signDoc = "SI",
                    asgCorr = sAsgCorr,
                    genXml = "SI",
                    saveDoc = "SI"
                };

                return infoProc;
            }
            catch (Exception e)
            {
                MessageBox.Show("ERROR EscribirInfoProc: " + e.Message);
                return null;
            }
        }

        private EstructuraJson.InfoDoc EscribirEncabezado(int iCorrelativo)
        {
            try
            {
                string sTipoDocumento = ConvertirTipoDocu();
                string sPrefijo = cmbSeriePrefijo.SelectedItem.ToString();
                string sFechaEmision = dtpFechaHoraEmision.Value.ToString("yyyy-MM-dd");
                string sHoraEmision = dtpFechaHoraEmision.Value.ToString("HH:mm:ss");
                string sTipoOperacion = ConvertirTipoOperacion(sTipoDocumento, iCorrelativo);
                string sTipoFactura = ConvertirTipoFactura();
                string sMonedaDocumento = cmbMonedaDocumento.SelectedItem.ToString();
                string sTipoIdenEmisor = ConvertirTipoIdentificacion(cmbTipoIdentificacionEmisor, iCorrelativo * 2);
                string sEmpresaEmisora = cmbEmpresaEmisora.SelectedItem.ToString().Split('-')[0].Trim();
                string sRegimenEmisor = ConvertirRegimen(cmbRegimenEmisor, iCorrelativo);
                string sCodigoRespEmisor = ConvertirResponsabilidad(cmbResponsabilidadEmisor, iCorrelativo);
                string sTipoIdenAdquiriente = ConvertirTipoIdentificacion(cmbTipoIdentificacionAdquiriente, iCorrelativo * 3);
                string sEmpresaAdquiriente = cmbEmpresaAdquiriente.SelectedItem.ToString().Split('-')[0].Trim();
                string sRegimenAdquiriente = ConvertirRegimen(cmbRegimenAdquiriente, iCorrelativo);
                string sCodigoRespAdquiriente = ConvertirResponsabilidad(cmbResponsabilidadAdquiriente, iCorrelativo);
                string sRazonSocial = cmbEmpresaAdquiriente.SelectedItem.ToString().Substring(10).Trim();

                if (cmbAsigAuto.SelectedIndex == 1)
                {
                    sPrefijo = "";
                }

                EstructuraJson.InfoDoc encabezado = new EstructuraJson.InfoDoc
                {
                    Tipo = "Encabezado",
                    LineaEncabezado = "1",
                    TipoDocumento = sTipoDocumento,
                    Prefijo = sPrefijo,
                    Correlativo = iCorrelativo.ToString(),
                    FechaEmision = sFechaEmision,
                    HoraEmision = sHoraEmision,
                    TipoOperacion = sTipoOperacion,
                    TipoFactura = sTipoFactura,
                    MonedaDocumento = sMonedaDocumento,
                    NotaDocumento = "Prueba de emsion de documentos FECO",
                    TipoEmisor = "1",
                    TipoIdenEmisor = sTipoIdenEmisor,
                    IdentificacionEmisor = sEmpresaEmisora,
                    DigitoVerificadorEmisor = "5",
                    RegimenEmisor = sRegimenEmisor,
                    CodigoRespEmisor = sCodigoRespEmisor,
                    NomComerEmisor = "DBNeT SAS",
                    RSocApeEmisor = "DBNeT SAS",
                    IdentificadorTributoEmisor = "02",
                    NombreTributoEmisor = "IC",
                    TipoAdquirente = "1",
                    TipoIdenAdquirente = sTipoIdenAdquiriente,
                    IdentificacionAdquirente = sEmpresaAdquiriente,
                    DigitoVerificadorAdquiriente = "0",
                    RegimenAdquirente = sRegimenAdquiriente,
                    CodigoRespAdquiriente = sCodigoRespAdquiriente,
                    NomComerAdquirente = sRazonSocial,
                    RSocApeAdquirente = sRazonSocial,
                    TipoReceptorPago = "1",
                    TipoIdenReceptorPago = "31",
                    IdentificacionReceptorPago = sEmpresaEmisora,
                    NombreReceptorPago = "DBNeT SAS",
                    TotalDescuentoDocumento = "0.00",
                    TotalCargoDocumento = "0.00",
                    TotalBrutoDocumento = "1500000.00",
                    BaseImponibleDocumento = "1500000.00",
                    TotalBrutoDocumentoImpu = "1785000.00",
                    TotalDocumento = "1785000.00"
                };

                return encabezado;
            }
            catch (Exception e)
            {
                MessageBox.Show("ERROR EscribirEncabezado: " + e.Message);
                return null;
            }
        }

        private List<EstructuraJson.InfoDoc> EscribirDireccion()
        {

            try
            {
                List<EstructuraJson.InfoDoc> direciones = new List<EstructuraJson.InfoDoc>();
                EstructuraJson.InfoDoc direcionEmisor = new EstructuraJson.InfoDoc
                {
                    Tipo = "Direccion",
                    LineaDireccion = "1",
                    TipoDireccion = "DISU",
                    IdDUNS = "11001",
                    ApartadoPostal = "951951",
                    Direccion = "Colombia",
                    Area = "Bogota, D.C.",
                    Ciudad = "Bogota",
                    Departamento = "Bogota, D.C.",
                    CodigoDepartamento = "11",
                    CodigoPais = "CO"
                };

                EstructuraJson.InfoDoc direcionAdquiriente = new EstructuraJson.InfoDoc
                {
                    Tipo = "Direccion",
                    LineaDireccion = "2",
                    TipoDireccion = "DICU",
                    IdDUNS = "11001",
                    Direccion = "Cra 70C # 54 - 69",
                    Area = "Bogota, D.C.",
                    Ciudad = "Bogota, D.C.",
                    Departamento = "Bogota, D.C.",
                    CodigoDepartamento = "11",
                    CodigoPais = "CO"
                };

                direciones.Add(direcionEmisor);
                direciones.Add(direcionAdquiriente);

                return direciones;
            }

            catch (Exception e)
            {
                MessageBox.Show("ERROR EscribirDireccion: " + e.Message);
                return null;
            }
        }

        private List<EstructuraJson.InfoDoc> EscribirContacto()
        {
            try
            {
                List<EstructuraJson.InfoDoc> contactos = new List<EstructuraJson.InfoDoc>();

                EstructuraJson.InfoDoc contacto1 = new EstructuraJson.InfoDoc
                {
                    Tipo = "Contacto",
                    LineaContacto = "1",
                    TipoContacto = "CEMI",
                    NombreContacto = "Juan Perez",
                    TelefonoContacto = "3258030",
                    MailContacto = "correo@contacto1.com",
                    DescripcionContacto = "Des Contacto 1"
                };

                EstructuraJson.InfoDoc contacto2 = new EstructuraJson.InfoDoc
                {
                    Tipo = "Contacto",
                    LineaContacto = "2",
                    TipoContacto = "CADQ",
                    NombreContacto = "Aquiles Baeza",
                    TelefonoContacto = "3258030",
                    MailContacto = "aquiles@contacto2.com",
                    DescripcionContacto = "Des Contacto 2"
                };

                contactos.Add(contacto1);
                contactos.Add(contacto2);

                return contactos;
            }

            catch (Exception e)
            {
                MessageBox.Show("ERROR EscribirContacto: " + e.Message);
                return null;
            }
        }

        private List<EstructuraJson.InfoDoc> EscribirImpuesto()
        {
            try
            {
                List<EstructuraJson.InfoDoc> impuestos = new List<EstructuraJson.InfoDoc>();
                EstructuraJson.InfoDoc impuesto1 = new EstructuraJson.InfoDoc
                {
                    Tipo = "Impuesto",
                    LineaImpuesto = "1",
                    MonedaImpuesto = "COP",
                    TotalImpuesto = "285000.00",
                    IndicadorImpuesto = "false",
                    BaseImponible = "1500000.00",
                    PorcentajeImpuesto = "19.00",
                    NumeroImpuesto = "01",
                    NombreImpuesto = "IVA"
                };

                EstructuraJson.InfoDoc impuesto2 = new EstructuraJson.InfoDoc
                {
                    Tipo = "Impuesto",
                    LineaImpuesto = "2",
                    MonedaImpuesto = "COP",
                    TotalImpuesto = "42750.00",
                    IndicadorImpuesto = "true",
                    BaseImponible = "285000.00",
                    PorcentajeImpuesto = "15.00",
                    NumeroImpuesto = "05",
                    NombreImpuesto = "ReteIVA"
                };

                impuestos.Add(impuesto1);
                impuestos.Add(impuesto2);

                return impuestos;
            }

            catch (Exception e)
            {
                MessageBox.Show("ERROR EscribirImpuesto: " + e.Message);
                return null;
            }
        }

        private EstructuraJson.InfoDoc EscribirMedioPago(int iCorrelativo)
        {
            try
            {
                string tipoDoc = ConvertirTipoDocu();

                switch (tipoDoc)
                {
                    case "FE":
                        string sIdMedioPago = ConvertirFormaPago(iCorrelativo);
                        string sCodigoMedioPago = null;

                        if (sIdMedioPago == "1")
                        {
                            sCodigoMedioPago = ConvertirMedioPago(iCorrelativo);
                        }

                        EstructuraJson.InfoDoc medioPago = new EstructuraJson.InfoDoc
                        {
                            Tipo = "MedioPago",
                            LineaMedioPago = "1",
                            IdMedioPago = sIdMedioPago,
                            CodigoMedioPago = sCodigoMedioPago,
                            IdentificadorPago = "ID MPAGO"
                        };

                        return medioPago;

                    default:
                        return null;
                }


            }
            catch (Exception e)
            {
                MessageBox.Show("ERROR EscribirMedioPago: " + e.Message);
                return null;
            }
        }

        private List<EstructuraJson.InfoDoc> EscribirItem(int cantidadItems)
        {

            try
            {
                List<EstructuraJson.InfoDoc> items = new List<EstructuraJson.InfoDoc>();
                for (int i = 0; i < cantidadItems; i++)
                {
                    EstructuraJson.InfoDoc item = new EstructuraJson.InfoDoc
                    {
                        Tipo = "Item",
                        LineaItem = (i + 1).ToString(),
                        DescripcionItem = "Descripcion del item: 1",
                        CantidadItem = "1",
                        UnidadMedidaItem = ConvertirUnidadMedida(i),
                        MonedaItem = "COP",
                        ValorUnitarioItem = "1500000.00",
                        CostoTotalItem = "1500000.00",
                        CodigoTipoPrecio = "01",
                        MarcaItem = "",
                        ModeloItem = "",
                        NotaItem = "Notas del Item " + i
                    };

                    items.Add(item);
                }

                return items;
            }

            catch (Exception e)
            {
                MessageBox.Show("ERROR EscribirItem: " + e.Message);
                return null;
            }
        }

        private List<EstructuraJson.InfoDoc> EscribirImpuestoItem(int cantidadItem)
        {
            try
            {
                List<EstructuraJson.InfoDoc> ImpuestosItems = new List<EstructuraJson.InfoDoc>();

                for (int i = 0; i < cantidadItem; i++)
                {
                    EstructuraJson.InfoDoc impuestoItem = new EstructuraJson.InfoDoc
                    {
                        Tipo = "ImpuestoItem",
                        LineaImpuestoItem = "1",
                        MonedaImpuestoItem = "COP",
                        TotalImpuestoItem = "285000.00",
                        BaseImponibleItem = "1500000.00",
                        PorcentajeImpuestoItem = "19.00",
                        NumeroImpuestoItem = ConvertirImpuestoItem(i).Substring(0, 2),
                        NombreImpuestoItem = ConvertirImpuestoItem(i).Substring(3),
                        UnidadMedidaImpItem = "03"
                    };

                    ImpuestosItems.Add(impuestoItem);
                }

                return ImpuestosItems;
            }

            catch (Exception e)
            {
                MessageBox.Show("ERROR EscribirImpuestoItem: " + e.Message);
                return null;
            }
        }

        private List<EstructuraJson.InfoDoc> EscribirCdgItem(int cantidadItem)
        {
            try
            {

                List<EstructuraJson.InfoDoc> codigosItems = new List<EstructuraJson.InfoDoc>();

                for (int i = 0; i < cantidadItem; i++)
                {
                    EstructuraJson.InfoDoc codigoItem = new EstructuraJson.InfoDoc
                    {
                        Tipo = "CdgItem",
                        LineaCodigo = (i + 1).ToString(),
                        TipoCodigo = ConvertirCodigoItem(i),
                        ValorCodigo = tbxValorCodigo.Text
                    };

                    codigosItems.Add(codigoItem);

                }
                return codigosItems;
            }

            catch (Exception e)
            {
                MessageBox.Show("ERROR EscribirCdgItem: " + e.Message);
                return null;
            }
        }

        private List<EstructuraJson.InfoDoc> EscribirRefeItem()
        {
            try
            {
                List<EstructuraJson.InfoDoc> refeItems = new List<EstructuraJson.InfoDoc>();
                if (cmbCodReferenciaItems.SelectedIndex == 0)
                {
                    return null;
                }
                int cantidadRefeItem = int.Parse(tbxCantidadRefItems.Text);
                for (int i = 0; i < cantidadRefeItem; i++)
                {
                    EstructuraJson.InfoDoc refeItem = new EstructuraJson.InfoDoc
                    {
                        Tipo = "RefeItem",
                        LineaRefeItem = (i + 1).ToString(),
                        TipoRefeItem = ConvertirTipoReferenciaItem(i),
                        IdRefeItem = "EP0CLNT500",
                        TipoDocRefeItem = "MIGO"
                    };

                    refeItems.Add(refeItem);
                }

                return refeItems;
            }

            catch (Exception e)
            {
                MessageBox.Show("ERROR EscribirRefeItem: " + e.Message);
                return null;
            }
        }

        private EstructuraJson.InfoDoc EscribirReferencia()
        {
            try
            {
                EstructuraJson.InfoDoc referencia;

                string sTipoReferencia = ConvertirTipoReferencia();
                string sNumeroReferencia = tbxNumeroReferencia.Text;
                string sFechaDocReferencia = dtpFechaDocReferencia.Value.ToString("yyyy-MM-dd");
                string sTipoDocReferencia = "";
                if (sTipoReferencia != null)
                {
                    if (sTipoReferencia.Equals("FA"))
                    {
                        sTipoDocReferencia = cmbTipoDocReferencia.SelectedItem.ToString();
                    }
                    referencia = new EstructuraJson.InfoDoc
                    {
                        Tipo = "Referencia",
                        LineaReferencia = "1",
                        TipoReferencia = sTipoReferencia,
                        NumeroDocReferencia = sNumeroReferencia,
                        FechaDocReferencia = sFechaDocReferencia,
                        TipoDocReferencia = sTipoDocReferencia
                    };
                }
                else
                {
                    referencia = null;
                }

                return referencia;

            }
            catch (Exception e)
            {
                MessageBox.Show("Error EscribirReferencia:" + e.Message);
                return null;
            }
        }

        private EstructuraJson.InfoDoc EscribirCorreoDespacho()
        {
            try
            {
                string sMailPara = tbxMailPara.Text;
                string sMailCopia = tbxMailCopia.Text;
                string sMailOculto = tbxMailOculto.Text;

                EstructuraJson.InfoDoc correoDespacho = new EstructuraJson.InfoDoc
                {
                    Tipo = "CorreoDespacho",
                    LineaCorreoDespacho = "1",
                    MailPara = sMailPara,
                    MailCopia = sMailCopia,
                    MailOculto = sMailOculto,
                    MailTipo = "SEND_FACT_EMIT"
                };

                return correoDespacho;
            }
            catch (Exception e)
            {
                MessageBox.Show("ERROR EscribirCorreoDespacho: " + e.Message);
                return null;
            }
        }

        #endregion

        #region Metodos de Auxiliares para convertir o pre cargar datos

        private string ConvertirTipoDocu()
        {
            string sTipoDocu = cmbTipoDocumento.SelectedItem.ToString();
            switch (sTipoDocu)
            {
                case "NOTA CRÉDITO":

                    sTipoDocu = "NC";

                    break;

                case "NOTA DÉBITO":

                    sTipoDocu = "ND";

                    break;

                default:

                    sTipoDocu = "FE";

                    break;
            }

            return sTipoDocu;
        }

        private string ConvertirTipoFactura()
        {
            string sTipoDocu = cmbTipoDocumento.SelectedItem.ToString();

            switch (sTipoDocu)
            {
                case "FE GENÉRICA":

                    sTipoDocu = "01";

                    break;

                case "FE EXPORTACIÓN":

                    sTipoDocu = "02";

                    break;

                case "FE CONTIGENCIA PROVEEDOR":

                    sTipoDocu = "03";

                    break;

                case "FE CONTIGENCIA DIAN":

                    sTipoDocu = "04";

                    break;
                default:

                    sTipoDocu = null;

                    break;
            }

            return sTipoDocu;
        }

        private string ConvertirTipoOperacion(string sTipoDocumento, int multiplicador)
        {
            int iTipoOperacion = cmbTipoOperacion.SelectedIndex;

            switch (iTipoOperacion)
            {
                case 0:
                    //Se debe generar un tipo de operación aleatorio
                    Random rnd = new Random(System.DateTime.Now.Millisecond * multiplicador);
                    string[] tipoOperaciones = { "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "20", "22", "23", "30", "32", "33" };
                    switch (sTipoDocumento)
                    {
                        case "FE":
                            return tipoOperaciones[rnd.Next(0, 10)];

                        case "NC":
                            return tipoOperaciones[rnd.Next(11, 13)];

                        default:
                            return tipoOperaciones[rnd.Next(14, 16)];
                    }

                default:
                    return cmbTipoOperacion.SelectedItem.ToString().Substring(0, 2);
            }
        }

        private string ConvertirTipoIdentificacion(ComboBox cmb, int multiplicador)
        {
            int iTipoIdentificacion = cmb.SelectedIndex;

            switch (iTipoIdentificacion)
            {
                case 0:
                    Random rnd = new Random(System.DateTime.Now.Millisecond * multiplicador);
                    string[] tipoAdqu = new string[] { "11", "12", "13", "21", "22", "31", "41", "42", "50" };
                    return tipoAdqu[rnd.Next(0, 8)];

                default:
                    return cmbTipoIdentificacionEmisor.SelectedItem.ToString();
            }

        }

        private string ConvertirRegimen(ComboBox cmb, int multiplicador)
        {
            int iRegimen = cmb.SelectedIndex;

            switch (iRegimen)
            {
                case 0:
                    Random rnd = new Random(System.DateTime.Now.Millisecond * multiplicador);
                    string[] regimenes = new string[] { "48", "49" };
                    return regimenes[rnd.Next(0, 1)];

                default:
                    return cmb.SelectedItem.ToString();
            }
        }

        private string ConvertirResponsabilidad(ComboBox cmb, int multiplicador)
        {
            int iResponsabilidad = cmb.SelectedIndex;

            switch (iResponsabilidad)
            {
                case 0:
                    Random rnd = new Random(System.DateTime.Now.Millisecond * multiplicador);
                    string[] responsabilidades = new string[] { "Aleatorio", "O-13", "O-15", "O-23", "O-47", "R-99-PN" };
                    return responsabilidades[rnd.Next(0, 5)];

                default:
                    return cmb.SelectedItem.ToString();
            }
        }

        private string ConvertirFormaPago(int multiplicador)
        {
            int iFormaPago = cmbFormaPago.SelectedIndex;

            switch (iFormaPago)
            {
                case 0:
                    Random rnd = new Random(System.DateTime.Now.Millisecond * multiplicador);
                    string[] formasPagos = new string[] { "1", "2" };

                    return formasPagos[rnd.Next(0, 1)];

                default:
                    string sFormaPago = cmbFormaPago.SelectedItem.ToString();

                    if (sFormaPago.Equals("Contado"))
                    {
                        return "1";
                    }
                    else
                    {
                        return "2";
                    }
            }
        }

        private string ConvertirMedioPago(int multiplicador)
        {
            int iMedioPago = cmbMedioPago.SelectedIndex;

            switch (iMedioPago)
            {
                case 0:
                    Random rnd = new Random(System.DateTime.Now.Millisecond * multiplicador);
                    string[] mediosPagos = new string[] { "10", "20", "42", "48", "49", "71", "72" };

                    return mediosPagos[rnd.Next(0, 6)];

                default:
                    return cmbMedioPago.SelectedItem.ToString().Substring(0, 2);
            }
        }

        private string ConvertirUnidadMedida(int multiplicador)
        {
            int iUnidadMedida = cmbUnidadMedida.SelectedIndex;

            switch (iUnidadMedida)
            {
                case 0:
                    Random rnd = new Random(System.DateTime.Now.Millisecond * multiplicador);
                    string[] unidadesMedidas = new string[] { "94", "JR", "KGM", "BO", "KT", "04" };

                    return unidadesMedidas[rnd.Next(0, 5)];

                default:
                    return cmbUnidadMedida.SelectedItem.ToString().Substring(0, 2).Trim();

            }

        }

        private string ConvertirImpuestoItem(int multiplicador)
        {
            int iImpuestoItem = cmbImpuestoItem.SelectedIndex;

            switch (iImpuestoItem)
            {
                case 0:
                    Random rnd = new Random(System.DateTime.Now.Millisecond * multiplicador);
                    string[] impuestosItems = new string[] { "01-IVA", "02-IC", "03-ICA", "04-INC", "20-FtoHrticultura", "21-Timbre", "22-Bolsas", "23-INCarbono", "24-INCombustibles", "25-Sobretasa", "26-Sordicom", "ZY-Nocausa", "ZZ-Nombredelafiguratributaria" };

                    return impuestosItems[rnd.Next(0, 12)];

                case 1:
                    return null;

                default:
                    return cmbImpuestoItem.SelectedItem.ToString();
            }
        }

        private string ConvertirCodigoItem(int multliplicador)
        {
            int iCodigoItem = cmbCodigoItems.SelectedIndex;

            switch (iCodigoItem)
            {
                case 0:
                    Random rnd = new Random(System.DateTime.Now.Millisecond * multliplicador);
                    string[] codigosItems = new string[] { "001", "010", "020", "999" };

                    return codigosItems[rnd.Next(0, 3)];

                default:
                    return cmbCodigoItems.SelectedItem.ToString().Substring(0, 3);
            }
        }

        private string ConvertirTipoReferenciaItem(int multiplicador)
        {
            int iReferenciaItem = cmbCodReferenciaItems.SelectedIndex;

            switch (iReferenciaItem)
            {
                case 0:
                    return null;

                case 1:
                    Random rnd = new Random(System.DateTime.Now.Millisecond * multiplicador);
                    string[] referenciasItems = new string[] { "BIL", "DES", "DOC", "LIN", "REC" };

                    return referenciasItems[rnd.Next(0, 4)];

                default:
                    return cmbCodReferenciaItems.SelectedItem.ToString().Substring(0, 3);
            }
        }

        private string ConvertirTipoReferencia()
        {
            int sTipoReferencia = cmbTipoReferencia.SelectedIndex;

            switch (sTipoReferencia)
            {
                case 0: return null;

                case 1: return "FA";

                default: return "OT";
            }
        }

        private void cmbTipoDocumento_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbSeriePrefijo.Items.Clear();

            int iIndexTipoDocu = cmbTipoDocumento.SelectedIndex;
            string rutEmpresa = cmbEmpresaEmisora.Text.Split('-')[0];
            ArrayList prefijos;

            if (iIndexTipoDocu <= 1)
            {
                //Tipo Operacion
                cmbTipoOperacion.Items.Clear();
                cmbTipoOperacion.Items.Add("Aleatorio");
                cmbTipoOperacion.Items.Add("01 - Combustibles");
                cmbTipoOperacion.Items.Add("02 - Emisor es Autoretenedor");
                cmbTipoOperacion.Items.Add("03 - Excluidos y Exentos");
                cmbTipoOperacion.Items.Add("04 - Exportación");
                cmbTipoOperacion.Items.Add("05 - Genérica");
                cmbTipoOperacion.Items.Add("06 - Genérica con Pago Anticipado");
                cmbTipoOperacion.Items.Add("07 - Genérica con Periodo de Facturación");
                cmbTipoOperacion.Items.Add("08 - Consorcio");
                cmbTipoOperacion.Items.Add("09 - Servicio AIU");
                cmbTipoOperacion.Items.Add("10 - Estándar");
                cmbTipoOperacion.Items.Add("11 - Mandatos Bienes");
                cmbTipoOperacion.Items.Add("12 - Mandatos Servicios");
                cmbTipoOperacion.SelectedIndex = 0;

                prefijos = con.RescatarPrefijo(rutEmpresa, "FE");

                if(prefijos != null && prefijos.Count > 0)
                {
                    for (int i = 0; i < prefijos.Count; i++)
                    {
                        cmbSeriePrefijo.Items.Add(prefijos[i]);
                    }
                }
            }
            else if(iIndexTipoDocu == 2)
            {
                prefijos = con.RescatarPrefijo(rutEmpresa, "NC");

                if (prefijos != null && prefijos.Count > 0)
                {
                    for (int i = 0; i < prefijos.Count; i++)
                    {
                        cmbSeriePrefijo.Items.Add(prefijos[i]);
                    }
                }
            }
            else
            {
                prefijos = con.RescatarPrefijo(rutEmpresa, "ND");

                if (prefijos != null && prefijos.Count > 0)
                {
                    for (int i = 0; i < prefijos.Count; i++)
                    {
                        cmbSeriePrefijo.Items.Add(prefijos[i]);
                    }
                }
            }

            cmbSeriePrefijo.SelectedIndex = 0;

        }

        private void cmbFormaPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbFormaPago.SelectedIndex)
            {
                case 0:
                    cmbMedioPago.Enabled = false;
                    break;

                case 1:
                    cmbMedioPago.Enabled = true;
                    break;

                default:
                    cmbMedioPago.Enabled = false;
                    break;
            }
        }

        #endregion

        #region Medotodos de validaciones o configuraciones
        private void ValidarRutaDestino(string path) //Verifica si existe la ruta proporcionada si no la crea
        {
            if (!System.IO.Directory.Exists(path))
            {
                System.IO.Directory.CreateDirectory(path);
            }
        }

        private void button1_Click(object sender, EventArgs e) //Funcionalidad del boton de Examinar
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                tbxRutaDestino.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        #endregion

        private string CallWssCargaDoc21(string json, string ip) //Metodo que consume el wss de carga FECO
        {
            String URL = ip;
            HttpWebRequest req;
            WebResponse response;
            bool isOK;
            string token = CallWssGetToken(ip);
            try
            {

                req = (HttpWebRequest)WebRequest.Create("http://" + ip + ":4017/EmisionDocumentoUBL21");
                req.ContentType = "application/json";
                req.Accept = "gzip,deflate";
                req.Method = "POST";

                while (5 > 0)
                {
                    using (Stream stm = req.GetRequestStream())
                    {
                        using (StreamWriter stmw = new StreamWriter(stm))
                        {
                            stmw.Write("{\n" +
                                         "\"EmisionDocumento\": {\n" +
                                         "\"IdentificadorEmpresa\":\"900918004\",\n" +
                                         "\"UsuarioEmpresa\":\"waldo\",\n" +
                                         "\"Token\":\"" + token + "\",\n" +
                                         json.Substring(1) + "\n" +
                                         "}");
                            //stmw.Write(soap);
                        }
                    }
                    response = req.GetResponse();
                    if (((HttpWebResponse)response).StatusCode != HttpStatusCode.OK)
                    {
                        Thread.Sleep(1000);
                    }
                    else
                    {
                        isOK = true;
                        break;
                    }

                }
                if (!isOK)
                {
                    throw new Exception("Error WSS Carga " + URL);
                }
                string content;
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    content = reader.ReadToEnd();
                }
                Console.WriteLine(content);
                Console.ReadLine();

                return content;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error WSS Carga: " + e.Message);
                MessageBox.Show("Error WSS Carga: " + e.Message);

                return null;
            }


        }


        private string CallWssGetToken(string ip = "10.1.3.220") //Metodo que consume el wss de seguridad que nos otorgara un token para consumir el wss de carga
        {

            try
            {
                string URL = "http://" + ip + ":4018/GetToken/";
                int reintentos = 5;
                HttpWebRequest req = null;
                WebResponse response = null;
                bool isOK = false;

                req = (HttpWebRequest)WebRequest.Create(URL);
                req.ContentType = "application/json";
                req.Accept = "text/xml";
                req.Method = "POST";

                string soap = "{\"GetToken\": {" +
                "\"IdentificadorEmpresa\":\"900918004\"," +
                "\"UsuarioEmpresa\":\"waldo\"," +
                "\"AutorizacionEmpresa\":\"OTAwOTE4MDA0JDEyMzQ1\"" +
                "}" +
                "}";

                while (reintentos > 0)
                {
                    reintentos--;
                    try
                    {
                        using (Stream stm = req.GetRequestStream())
                        {
                            using (StreamWriter stmw = new StreamWriter(stm))
                            {
                                stmw.Write(soap);
                            }
                        }
                        response = req.GetResponse();
                        if (((HttpWebResponse)response).StatusCode != HttpStatusCode.OK)
                        {
                            Thread.Sleep(1000);
                        }
                        else
                        {
                            isOK = true;
                            break;
                        }
                    }
                    catch (System.Net.WebException ex)
                    {
                        throw new Exception("Error al ejecutar " + URL + "   " + ex);
                    }
                    catch (Exception)
                    {
                        throw new Exception("Error al ejecutar " + URL);
                    }

                }
                if (!isOK)
                {
                    throw new Exception("Error al ejecutar " + URL);
                }
                //StreamReader reader = new StreamReader(response.GetResponseStream());
                string content;
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    content = reader.ReadToEnd();
                }
                //Console.WriteLine(content.Replace());
                Console.WriteLine(content);
                Console.ReadLine();
                return content.Substring(10).Replace('"', ' ').Replace('}', ' ').Trim();
            }
            catch (Exception e)
            {
                //throw e;
                Console.WriteLine("ERROR \"CallWssGetToken\": " + e.Message);
                return null;
            }



        }


        private void btnGenerarDocumento_Click(object sender, EventArgs e)
        {
            ArmarJson();

        }

        private void tbxCantidadDocumento_Leave(object sender, EventArgs e)
        {
            if (tbxCantidadDocumento.TextLength == 0 || tbxCantidadDocumento.Text == "0")
            {
                tbxCantidadDocumento.Text = "1";
            }
        }

        private void tbxCorrelativoDocumento_Leave(object sender, EventArgs e)
        {
            if (tbxCorrelativoDocumento.TextLength == 0 || tbxCorrelativoDocumento.Text == "0")
            {
                tbxCorrelativoDocumento.Text = "1";
            }
        }

        private void tbxCantidadItems_Leave(object sender, EventArgs e)
        {
            if (tbxCantidadItems.TextLength == 0 || tbxCantidadItems.Text == "0")
            {
                tbxCantidadItems.Text = "1";
            }
        }

        private void tbxValorCodigo_Leave(object sender, EventArgs e)
        {
            if (tbxValorCodigo.TextLength == 0 || tbxValorCodigo.Text == "0")
            {
                tbxValorCodigo.Text = "1";
            }
        }

        private void tbxCantidadRefItems_Leave(object sender, EventArgs e)
        {
            if (tbxCantidadRefItems.TextLength == 0 || tbxCantidadRefItems.Text == "0")
            {
                tbxCantidadRefItems.Text = "1";
            }
        }

        private void tbxNumeroReferencia_Leave(object sender, EventArgs e)
        {
            if (tbxNumeroReferencia.TextLength == 0 || tbxNumeroReferencia.Text == "0")
            {
                tbxNumeroReferencia.Text = "1";
            }
        }

        private void cmbCodReferenciaItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCodReferenciaItems.SelectedIndex == 0)
            {
                tbxCantidadRefItems.Enabled = false;
            }
            else
            {
                tbxCantidadRefItems.Enabled = true;
            }
        }

        private void cmbTipoReferencia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTipoReferencia.SelectedIndex == 0)
            {
                tbxNumeroReferencia.Enabled = false;
                cmbTipoDocReferencia.Enabled = false;
                dtpFechaDocReferencia.Enabled = false;
            }
            else if (cmbTipoReferencia.SelectedIndex == 1)
            {
                tbxNumeroReferencia.Enabled = true;
                cmbTipoDocReferencia.Enabled = true;
                dtpFechaDocReferencia.Enabled = true;
            }
            else
            {
                tbxNumeroReferencia.Enabled = true;
                cmbTipoDocReferencia.Enabled = false;
                dtpFechaDocReferencia.Enabled = false;
            }
        }

        private void CargarCmbEmpresaEmisora()
        {
            ArrayList empresas = con.RescatarEmpresasEmisoras();

            if (empresas != null)
            {
                cmbEmpresaEmisora.Items.Clear();

                for (int i = 0; i < empresas.Count; i++)
                {
                    cmbEmpresaEmisora.Items.Add(empresas[i]);
                }


            }
            else
            {
                MessageBox.Show("Error al Rescatar Empresas");
            }



        }

        private void cmbEmpresaEmisora_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbIdArea.Items.Clear();
            string rutEmpresa = cmbEmpresaEmisora.Text.Split('-')[0];

            ArrayList areas = con.RescatarAreaFactura(rutEmpresa);

            if(areas != null && areas.Count > 0)
            {
                for (int i = 0; i < areas.Count; i++)
                {
                    cmbIdArea.Items.Add(areas[i]);
                }
                cmbIdArea.SelectedIndex = 0;
            }
        }

    }
}
