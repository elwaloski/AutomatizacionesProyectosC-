using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.LinkLabel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace Carga_Directa_BD_SE
{
    public partial class Form1 : Form
    {
        public static string RutaPRCSE = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"PRC Ejecutar en BD\SE\"));
        public static string RutaPRCCF = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"PRC Ejecutar en BD\CF\"));
        public Form1()
        {
            InitializeComponent();
        }
        String Ambiente = "";
        String AmbienteCF = "";
        String tablaCF = "";
        String Accion = "";
        String AccionBOL = "";
        String Documento = "";
        String DefinicionDTE_TEMP = "";
        String DefinicionDTE_Control = "";
        String definicionARCH_DTE_INFO_SII = "";
        String definicionDTE_ENCA_DOCU_HOLD = "";
        String definiciondte_deta_acec_hold = "";
        String definiciondte_deta_prse_hold = "";
        String deficion_dte_docu_refe_hold = "";
        String definiciondte_foli_clie_hold = "";
        String definicion_BEL_ENCA_DOCU_HOLD = "";
        String definicion_DTE_ENCA_DOCU_HOLD = "";
        String definicion_BEL_DETA_PRSE_HOLD = "";
        String definicion_BEL_DETA_CODI_HOLD = "";
        String definicion_dte_enca_docu = "";
        String definicion_dte_docu_refe = "";
        String definicion_DTE_ENCA_DOCU_HOLD43 = "";
        String definicion_BEL_ENCA_DOCU = "";
        String definicion_BEL_DETA_PRSE = "";
        String definicion_BEL_DETA_CODI = "";
        String definicion_qmta_rece_info = "";
        String definicion_qmta_rece_part = "";
        String definicion_dte_cesion_sii_tmp = "";
        String Hold = "";
        String Holdbel = "";
        String RutEmpresa;
        String DigiEmpresa;
        String RutEmis;
        String DigiEmis; 
        String RutReces;
        String DigiReces;
        String RutEmpresaCF;
        String DigiEmpresaCF;
        int TipoDocu = 0;
        int TipoDocuBEL = 0;
        String tipodescarga = "";
        String fecha = "";
        String fechaBel = "";
        String fechaVenc = "";
        String FechaTED = "";
        String Periodo = "";
        String PeriodoCF = "";
        String PeriodoEMISCF = "";
        Int64 Foliodesde = 1;
        Int64 Foliohasta = 1;
        Int64 Foliodesdedto = 1;
        Int64 Foliohastadto = 1;
        Int64 Foliodesdebel = 1;
        Int64 Foliohastabel = 1;
        Int64 FoliodesdeCF = 1;
        Int64 FoliohastaCF = 1;
        String Insert = "";
        String FechaDTOS;
        String definicion_Dbq_arch="";
        String definicion_Dbq_arch_clob ="";
        int TipoAmbiente =0 ;
        Random random = new Random();
        private string[] GuardaQueryOracle;
        String RutaCarpeta = "C:\\aqui";
        List<string> RutaDocumetos;
        int FolioInicialtxtCambio = 0;
        public bool Multiselect { get; set; }

        protected int GetRandomInt(int min, int max)
        {
            return random.Next(min, max);
        }
        private void CBXAmbiente_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (CBXAmbiente.SelectedIndex)
            {
                case 0:
                    Ambiente = "CLOUD";
                    txbHolding.Visible = true;
                    LblHolding.Visible = true;

                    CBXAmbiente.Visible = true;
                    label2.Visible = true;
                    label26.Visible = true;
                    textBox6.Visible = true;
                    label31.Visible = true;
                    Checkdeshast.Visible = true;
                    lbFoliDesde.Visible = false;
                    tbxFoliDesde.Visible = false;
                    lbFoliHasta.Visible = false;
                    tbxFoliHasta.Visible = false;
                    BtnDirectorio.Visible = false;
                    break;
                case 1:
                    Ambiente = "SQL";
                    txbHolding.Visible = false;
                    LblHolding.Visible = false;
                    label26.Visible = false;
                    textBox6.Visible = false;
                    label31.Visible = false;
                    Checkdeshast.Visible = false;
                    lbFoliDesde.Visible = true;
                    tbxFoliDesde.Visible = true;
                    lbFoliHasta.Visible = true;
                    tbxFoliHasta.Visible = true;
                    BtnDirectorio.Visible = false;
                    break;
                case 2:
                    Ambiente = "ORACLE";
                    txbHolding.Visible = false;
                    LblHolding.Visible = false;
                    label26.Visible = false;
                    textBox6.Visible = false;
                    label31.Visible = false;
                    Checkdeshast.Visible = false;
                    lbFoliDesde.Visible = true;
                    tbxFoliDesde.Visible = true;
                    lbFoliHasta.Visible = true;
                    tbxFoliHasta.Visible = true;
                    BtnDirectorio.Visible = false;
                    break;
                default:
                    Console.WriteLine("Default case");
                    break;
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dtFechEmis.Value = DateTime.Now;
            FechaVencimiento.Value = DateTime.Now.AddDays(90);
            CBXAmbiente.SelectedIndex = 0;
            CBXTipoDocu.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            comboBox5.SelectedIndex = 0;
            comboBox6.SelectedIndex = 0;
            comboBox7.SelectedIndex = 0;
            comboBox1.SelectedIndex = 0;
            comboBox3.SelectedIndex = 0;
            ComboSE.SelectedIndex = 0;
            cmbTipoDocumento.SelectedIndex = 0;
            txbHolding.Text = "PROD_0277";
            textBox4.Text = "78079790";
            txbRut.Text = "78079790";
            txbDigi.Text = "8";
            textBox3.Text = "8";
            TxtRUTCF.Text = "78079790";
            TxtDIGICF.Text = "8";
            fecha = dtFechEmis.Value.ToString("yyyy-MM-dd");
            fechaBel = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            fechaVenc = FechaVencimiento.Value.ToString("yyyy-MM-dd");
            FechaTED = dtFechEmis.Value.ToString("yyyy-MM-ddTHH:mm:ss");
            tbxFoliDesde.Text = "1";
            tbxFoliHasta.Text = "2";
            textBox6.Text = "1";
            textBox7.Text = "1";
            tbxFoliDesdedto.Text = "1";
            tbxFoliHastadto.Text = "2";
            RutEmi.Text= "78079790";
            DigiEmi.Text = "8";            
            RutRece.Text= "78079790";
            DigiRece.Text = "8";
            comboBox9.SelectedIndex = 0;

            tbxFoliDesdeCF.Text = "1";
            tbxFoliHastaCF.Text = "2";

            textBox2.Text = "1";
            textBox1.Text = "2";
            Foliodesdebel = Int64.Parse(textBox2.Text);
            Foliohastabel = Int64.Parse(textBox1.Text);

            Periodo = dtFechEmis.Value.ToString("yyyyMM");
            PeriodoCF = dtPeriodoCF.Value.ToString("yyyyMM");
            PeriodoEMISCF = dtPeriodoCF.Value.ToString("yyyy-MM");
            textBox5.Text = "PROD_0277";
            FechaDTOS= FechaDTO.Value.ToString("yyyy-MM-dd");
            LBLMadera.Visible = false;
            CKBMADERA.Visible= false;
            CKBLeyMaderaTXT.Visible = false;
            label37.Visible = false;
            LblTotaldocumentos.Visible = false;
            label38.Visible = false;
            TxbCantidad.Visible = false;
            BtnCambiarFolios.Visible = false;
            TXBRutEmis.Visible = false;
            label39.Visible = false;
            checkBox1.Visible = false;
            TXBRutEmis.Visible = false;
            label40.Visible = false;
            checkBox2.Visible = false;
            TXBRutRece.Visible = false;

        }

        private void CBXTipoDocu_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (CBXTipoDocu.SelectedIndex)
            {
                case 0:
                    TipoDocu = 33;
                    CKBLeyMaderaTXT.Visible = false;
                    break;
                case 1:
                    TipoDocu = 34;
                    CKBLeyMaderaTXT.Visible = false;
                    break;
                case 2:
                    TipoDocu = 43;
                    CKBLeyMaderaTXT.Visible = false;
                    break;
                case 3:
                    TipoDocu = 46;
                    CKBLeyMaderaTXT.Visible = false;
                    break;
                case 4:
                    TipoDocu = 52;
                    CKBLeyMaderaTXT.Visible = true;
                    break;
                case 5:
                    TipoDocu = 56;
                    CKBLeyMaderaTXT.Visible = false;
                    break;
                case 6:
                    TipoDocu = 61;
                    CKBLeyMaderaTXT.Visible = false;
                    break;
                case 7:
                    TipoDocu = 110;
                    CKBLeyMaderaTXT.Visible = false;
                    break;
                case 8:
                    TipoDocu = 111;
                    CKBLeyMaderaTXT.Visible = false;
                    break;
                default:
                    TipoDocu = 112;
                    CKBLeyMaderaTXT.Visible = false;
                    break;
            }
        }

        private void dtFechEmis_ValueChanged(object sender, EventArgs e)
        {
            
            fecha = dtFechEmis.Value.ToString("yyyy-MM-dd");
            Periodo = dtFechEmis.Value.ToString("yyyyMM");
            FechaTED = dtFechEmis.Value.ToString("yyyy-MM-ddTHH:mm:ss");
        }
        private void validarCamposbel()

        {
            if (textBox2.Text == "") //desde
            {
                MessageBox.Show("Los campos Folio Desde no pueden quedar vacios, Se asignaran valores por defecto = 1");
                textBox2.Text = "1";
            }
            if (textBox1.Text == "") //hasta
            {
                MessageBox.Show("Los campos Folio Hasta no pueden quedar vacios, Se asignaran valores por defecto= 1");
                textBox1.Text = "1";
            }

            if (Foliodesdebel > Foliohastabel)
            {
                MessageBox.Show("El Valor ingresado en Folio desde no puede ser menor que Folio Hasta por deFecto quedara con Valor Folio  Hasta");
                textBox2.Text = Foliohastabel.ToString();
            }

            Foliohastabel = Int64.Parse(textBox1.Text);
            Foliodesdebel = Int64.Parse(textBox2.Text);

            if (Foliohastabel < Foliodesdebel)
            {
                MessageBox.Show("El Valor ingresado en Folio hasta no puede ser menor que Folio desde por defecto quedara con valor folio Desde");
                textBox1.Text = Foliodesdebel.ToString();

            }

            Foliodesdebel = Int64.Parse(textBox2.Text);
            Foliohastabel = Int64.Parse(textBox1.Text);

            if (Ambiente == "CLOUD") {
                if (RutEmpresaCF == "" | DigiEmpresaCF == "" | Holdbel == "")
                {
                    textBox4.Text = "78079790";
                    textBox3.Text = "9";
                    RutEmpresaCF = "78079790";
                    DigiEmpresaCF = "9";
                    textBox5.Text = "DEMO";
                    Holdbel = "DEMO";

                    MessageBox.Show("Dejo vacio un dato ya sea Rut, Digitador o Holding .... Se asignaran Valores por defecto");
                }
            } else if (RutEmpresa == "" | DigiEmpresa == "")
            {
                textBox4.Text = "78079790";
                textBox3.Text = "9";
                RutEmpresa = "78079790";
                DigiEmpresa = "9";

                MessageBox.Show("Dejo vacio un dato ya sea Rut o Digitador .... Se asignaran Valores por defecto");
            }

        }
        private void validarCampos()
        {
            if (tbxFoliDesde.Text == "")
            {
                MessageBox.Show("Los campos Folio Desde no pueden quedar vacios, Se asignaran valores por defecto = 1");
                tbxFoliDesde.Text = "1";
            }
            if (tbxFoliHasta.Text == "")
            {
                MessageBox.Show("Los campos Folio Hasta no pueden quedar vacios, Se asignaran valores por defecto= 1");
                tbxFoliHasta.Text = "1";
            }
            if (tbxFoliDesdedto.Text == "")
            {
                MessageBox.Show("Los campos Folio Desde no pueden quedar vacios, Se asignaran valores por defecto = 1");
                tbxFoliDesdedto.Text = "1";
            }
            if (tbxFoliHastadto.Text == "")
            {
                MessageBox.Show("Los campos Folio Hasta no pueden quedar vacios, Se asignaran valores por defecto= 1");
                tbxFoliHastadto.Text = "1";
            }
            if (textBox6.Text == "")
            {
                MessageBox.Show("Campo Cantidad no puede quedar vacio, Se asignaran valor por defecto = 1");
                textBox6.Text = "1";
            }
            

            if (Foliodesde > Foliohasta)
            {
                MessageBox.Show("El Valor ingresado en Folio desde no puede ser menor que Folio Hasta por deFecto quedara con Valor Folio  Hasta");
                tbxFoliDesde.Text = Foliohasta.ToString();
            }

            Foliohasta = Int64.Parse(tbxFoliHasta.Text);
            Foliodesde = Int64.Parse(tbxFoliDesde.Text);

            if (Foliohasta < Foliodesde)
            {
                MessageBox.Show("El Valor ingresado en Folio hasta no puede ser menor que Folio desde por defecto quedara con valor folio Desde");
                tbxFoliHasta.Text = Foliodesde.ToString();

            }

            Foliodesde = Int64.Parse(tbxFoliDesde.Text);
            Foliohasta = Int64.Parse(tbxFoliHasta.Text);


        
           if (Foliodesdedto > Foliohastadto)
            {
                MessageBox.Show("El Valor ingresado en Folio desde no puede ser menor que Folio Hasta por deFecto quedara con Valor Folio  Hasta");
                tbxFoliDesdedto.Text = Foliohastadto.ToString();
            }

            Foliohastadto = Int64.Parse(tbxFoliHastadto.Text);
            Foliodesdedto = Int64.Parse(tbxFoliDesdedto.Text);

            if (Foliohastadto < Foliodesdedto)
            {
                MessageBox.Show("El Valor ingresado en Folio hasta no puede ser menor que Folio desde por defecto quedara con valor folio Desde");
                tbxFoliHastadto.Text = Foliodesdedto.ToString();

            }

            Foliodesdedto = Int64.Parse(tbxFoliDesdedto.Text);
            Foliohastadto = Int64.Parse(tbxFoliHastadto.Text);
            //CF

            if (tbxFoliDesdeCF.Text == "")
            {
                MessageBox.Show("Los campos Folio Desde no pueden quedar vacios, Se asignaran valores por defecto = 1");
                tbxFoliDesdeCF.Text = "1";
            }
            if (tbxFoliHastaCF.Text == "")
            {
                MessageBox.Show("Los campos Folio Hasta no pueden quedar vacios, Se asignaran valores por defecto= 1");
                tbxFoliHastaCF.Text = "1";
            }

            if (FoliodesdeCF > FoliohastaCF)
            {
                MessageBox.Show("El Valor ingresado en Folio desde no puede ser menor que Folio Hasta por deFecto quedara con Valor Folio  Hasta");
                tbxFoliDesdeCF.Text = FoliohastaCF.ToString();
            }

            FoliohastaCF = Int64.Parse(tbxFoliHastaCF.Text);
            FoliodesdeCF = Int64.Parse(tbxFoliDesdeCF.Text);

            if (FoliohastaCF < FoliodesdeCF)
            {
                MessageBox.Show("El Valor ingresado en Folio hasta no puede ser menor que Folio desde por defecto quedara con valor folio Desde");
                tbxFoliHastaCF.Text = FoliodesdeCF.ToString();

            }

            FoliodesdeCF = Int64.Parse(tbxFoliDesdeCF.Text);
            FoliohastaCF = Int64.Parse(tbxFoliHastaCF.Text);

            if (this.dtFechEmis.Value.CompareTo(this.FechaVencimiento.Value) == 1)

            {
                MessageBox.Show("La fecha desde no puede ser mayor que hasta");
                fechaVenc = dtFechEmis.Value.ToString("yyyy-MM-dd");
            }

            if (RutEmpresa == "" | DigiEmpresa == "" | Hold == "")
            {
                txbRut.Text = "78079790";
                txbDigi.Text = "9";
                RutEmpresa = "78079790";
                DigiEmpresa = "9";
                txbHolding.Text = "DEMO";
                Hold = "DEMO";
                MessageBox.Show("Dejo vacio un dato ya sea Rut, Digitador o Holding .... Se asignaran Valores por defecto");
            }
        }

        private void ValidarLetras(KeyPressEventArgs e)
        {

            if (Char.IsDigit(e.KeyChar))
            {

                e.Handled = false;


            }
            else if (Char.IsControl(e.KeyChar))
            {

                e.Handled = false;
            }
            else
            {
                e.Handled = true;
                MessageBox.Show("Solo Numeros");
            }
        }

        private void tbxFoliDesde_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarLetras(e);
        }

        private void tbxFoliHasta_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarLetras(e);
        }

        private void button1_Click(object sender, EventArgs e)
        //Boton inserta SE

        {

           if (Accion == "INSERT")
            {


                switch (Ambiente)
                {
                    #region CLOUD
                    case "CLOUD":

                        Definiciones Tabla = new Definiciones();
                        definicion_DTE_ENCA_DOCU_HOLD = Tabla.Dte_enca_docu_hold();
                        definicion_DTE_ENCA_DOCU_HOLD43 = Tabla.Dte_enca_docu_hold43();
                        deficion_dte_docu_refe_hold = Tabla.Dte_docu_refe_hold();
                        String Defi33 = Tabla.Dte_enca_docu_hold33();
                        validarCampos();

                        switch (TipoDocu)
                        {

                            case 33:

                                if (Checkdeshast.Checked == false)
                                {
                                    validarCampos();
                                    int diferencia = Convert.ToInt32(textBox6.Text);
                                    ConexionBD conexionCLOUD33 = new ConexionBD(Ambiente);
                                    conexionCLOUD33.abrirBD();
                                    String PRC33 = Tabla.PRCCARGADTE(TipoDocu, diferencia, Hold, RutEmpresa, DigiEmpresa);
                                    conexionCLOUD33.EjecutarSql(PRC33);
                                    conexionCLOUD33.CerraBD();
                                }
                                else {
                                    validarCampos();
                                    ConexionBD recuperaFolio33 = new ConexionBD(Ambiente);
                                    String Consulta = "Select * from dte_rang_foli_hold where tipo_dora = 33 and esta_rafo = 'VAL' and codi_emex = 'demo'";
                                    recuperaFolio33.abrirBD();
                                    String rescatafolio33CAF = recuperaFolio33.recupera_dato(Consulta);

                                    if (rescatafolio33CAF == "")
                                    {
                                        Definiciones DEF = new Definiciones();
                                        String insertCAF = DEF.Dte_rang_foli_hold(Hold, RutEmpresa, DigiEmpresa);
                                        recuperaFolio33.EjecutarSql(insertCAF);
                                        recuperaFolio33.CerraBD();
                                    }

                                    recuperaFolio33.CerraBD();

                                    for (int i = Convert.ToInt32(Foliodesde); i <= Foliohasta; i++)
                                    {
                                        ConexionBD conexionCLOUD = new ConexionBD(Ambiente);
                                        conexionCLOUD.abrirBD();
                                        String a = "dbnet_set_emex '" + Hold + Defi33 +
                                                   "('" + Hold + "',1 ,'" + TipoDocu + "', '1.0', ''  ,'' , '', '" + i + "' , '" + fecha + "' , 0 , 0 , 6, 0, 0, 3, '2020-11-20', '2020-11-20', '2020-11-20', 'PE', '5462', 45, '2019-08-19', " + RutEmpresa + ", '" + DigiEmpresa + "', " +
                                                   "'DBNET', 'TIC', '', 0, '8', 'SANTIAGO', '', '', 0, '', 78079790, '8', '', 'DBNET', 'TIC', '065 - 2265500' , 'AV SIEMPRE VIVA', 'PUERTO MONTT', 'LLANQUIHUE', '', ''," +
                                                   " '', 0, '', '', 0, '', '', '', '', 647000.0, 0.0, 0.0, 19.0, 122930.0, 0.0 , 0.0, 0.0, 769930.0, 0.0, 0.0, 0.0, 0.0, 'ING', '', '', 0.0, 0.0, 0, 0, 0.0, '', '', 0," +
                                                   " 0, '', '', '', '', '', '', '', 0, '', '', 0, 0, 0.0, 0, '', 0, '', '' , '', '', '', 0 , '', 0, '', 0, 0, 0.0, 0, 0.0, 0, 0.0, 0.0, 0.0, 0.0, '', '', '', 0.0, 0.0," +
                                                   " 0.0, '', 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 'Perú y Colombia. En', '17:27', '2220', 'Kapaza','878','val5','val6','val7','val8','val9',0,0,'', 0, 0, 0, 0) " +


                                                   "INSERT dte_deta_acec_hold(codi_emex,codi_empr,tipo_docu,foli_docu,corr_acec,codi_acec,mnsg_erro,peri_part) VALUES " +
                                                   "('" + Hold + "', 1, '" + TipoDocu + "', '" + i + "', 0, '620200', '','" + Periodo + "')" +

                                                   "INSERT dte_deta_prse_hold(codi_emex,codi_empr,tipo_docu,foli_docu,nume_line,codi_impu,tipo_codi,codi_item,indi_exen,nomb_item,desc_item,cant_item,cant_refe," +
                                                   "unid_refe,prec_refe,unid_medi,prec_item,prec_mono,codi_mone,fact_conv,dcto_item,reca_item,neto_item,desc_porc,reca_porc,fech_elab,fech_vepr,mnsg_erro,desc_mone," +
                                                   "reca_mone,valo_mone,indi_agen,base_faen,marg_comer,prne_cofi,peri_part) VALUES " +
                                                   "('" + Hold + "', 1, '" + TipoDocu + "',  '" + i + "', 1, '', NULL, NULL, 0, 'Calabaza', '', 1.000000, 0, '', 0.000000, '', 209409.000000, 0.000000, '', 0.0000, 0, 0, 209409.0000, 0.00, 0.00, '', '', '', 0.0000, 0.0000, 0.0000, '', 0, 0, 0, '" + Periodo + "')" +

                                                   "INSERT INTO dte_foli_clie_hold(codi_emex,codi_empr,tipo_docu,foli_docu,foli_clie,esta_tras,peri_part) VALUES ('" + Hold + "',1,'" + TipoDocu + "', '" + i + "','',0,'" + Periodo + "')";

                                        string[] Items = { a};

                                        int ItemsSS = GetRandomInt(0, Items.Length);

                                        Insert = Items[ItemsSS];

                                        String Query = Insert;
                                        conexionCLOUD.EjecutarSql(Query, i);
                                        conexionCLOUD.CerraBD();

                                    }
                                }
                                break;
                            case 34:
                                if (Checkdeshast.Checked == false)
                                {
                                    validarCampos();
                                    int diferencia = Convert.ToInt32(textBox6.Text);
                                    ConexionBD conexionCLOUD34 = new ConexionBD(Ambiente);
                                    conexionCLOUD34.abrirBD();
                                    String PRC34 = Tabla.PRCCARGADTE(TipoDocu, diferencia, Hold, RutEmpresa, DigiEmpresa);
                                    conexionCLOUD34.EjecutarSql(PRC34);
                                    conexionCLOUD34.CerraBD();
                                }
                                else
                                {
                                    validarCampos();
                                    for (int i = Convert.ToInt32(Foliodesde); i <= Foliohasta; i++)
                                    {
                                        ConexionBD conexionCLOUD = new ConexionBD(Ambiente);
                                        conexionCLOUD.abrirBD();
                                        String a = "dbnet_set_emex '" + Hold + definicion_DTE_ENCA_DOCU_HOLD +
                                                  "('" + Hold + "',1, '" + TipoDocu + "' ,'" + i + "', 'ING', NULL, NULL, NULL, '" + fecha + "', 0 , 0 , 2 , NULL, NULL, NULL, NULL, '', '" + fechaVenc + "'," + RutEmpresa + " , NULL, NULL, '" + DigiEmpresa + "', 'DBNET Ingenieria de Software', 'Botellas', NULL, NULL," +
                                                  "'Providencia', 'Algarrobo', 'ALTO PALENA', NULL, NULL, NULL, 78079790, '8', 'dbnet', '789', 'Manzanas', '511551', 'dbnet', 'Canela', 'SANTIAGO', NULL, NULL, NULL, NULL, NULL, '', 0, '', '', '', ''," +
                                                  "0 , 25000000, 0 , NULL, NULL, NULL, 25000000, 0, 0 , NULL, NULL, NULL, 0 , '1.0' , N'" + fecha + "T09:27:56', NULL, CAST(N'" + fecha + " 09:27:55.947' AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, " +
                                                  "NULL, '', NULL, NULL, 'D:\\facture_homes\\demo\\out', '', '', '', '', '', '', '', '', '', '', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL,0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, '', NULL, " +
                                                  "NULL, NULL, 0 , '', '',0, 0, 0, 0 , '', NULL, NULL, NULL, NULL, '', '', 0 , '', 0, '', NULL, NULL, 0, 0 , 0, 0, NULL, 0 , 0, NULL, '', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL," +
                                                  "NULL, NULL, NULL, NULL, NULL, NULL, '', 'S', '0', NULL, NULL, 'demo', NULL, NULL, NULL, NULL, NULL, NULL, '" + Periodo + "', N'2020-12', NULL, NULL, NULL,0 , 0, 0 ,0)" +


                                                   "INSERT dte_deta_acec_hold(codi_emex,codi_empr,tipo_docu,foli_docu,corr_acec,codi_acec,mnsg_erro,peri_part) VALUES " +
                                                   "('" + Hold + "', 1, '" + TipoDocu + "', '" + i + "', 0, '620200', '','" + Periodo + "')" +

                                                   "INSERT dte_deta_prse_hold(codi_emex,codi_empr,tipo_docu,foli_docu,nume_line,codi_impu,tipo_codi,codi_item,indi_exen,nomb_item,desc_item,cant_item,cant_refe," +
                                                   "unid_refe,prec_refe,unid_medi,prec_item,prec_mono,codi_mone,fact_conv,dcto_item,reca_item,neto_item,desc_porc,reca_porc,fech_elab,fech_vepr,mnsg_erro,desc_mone," +
                                                   "reca_mone,valo_mone,indi_agen,base_faen,marg_comer,prne_cofi,peri_part) VALUES " +
                                                   " ('" + Hold + "', 1, '" + TipoDocu + "',  '" + i + "', 1, '', NULL, NULL, 0, 'Gorra', 'Nike', 500,0 , NULL, NULL, '', 50000, NULL, NULL, NULL, 0 , NULL, 25000000, 0, NULL, NULL, NULL, '', NULL, NULL, NULL, NULL, NULL, NULL, NULL,'" + Periodo + "')" +

                                                   "INSERT INTO dte_foli_clie_hold(codi_emex,codi_empr,tipo_docu,foli_docu,foli_clie,esta_tras,peri_part) VALUES ('" + Hold + "',1,'" + TipoDocu + "', '" + i + "','',0,'" + Periodo + "')";

                                        string[] Items = { a };

                                        int ItemsSS = GetRandomInt(0, Items.Length);

                                        Insert = Items[ItemsSS];

                                        String Query = Insert;
                                        // int Folioquery = Convert.ToInt32(Foliodesde);
                                        conexionCLOUD.EjecutarSql(Query, i);
                                        conexionCLOUD.CerraBD();
                                    }
                                }
                                break;
                            case 43:
                                if (Checkdeshast.Checked == false)
                                {
                                    validarCampos();
                                    int diferencia = Convert.ToInt32(textBox6.Text);
                                    ConexionBD conexionCLOUD43 = new ConexionBD(Ambiente);
                                    conexionCLOUD43.abrirBD();
                                    String PRC34 = Tabla.PRCCARGADTE(TipoDocu, diferencia, Hold, RutEmpresa, DigiEmpresa);
                                    conexionCLOUD43.EjecutarSql(PRC34);
                                    conexionCLOUD43.CerraBD();
                                }
                                else
                                {
                                    validarCampos();
                                    for (int i = Convert.ToInt32(Foliodesde); i <= Foliohasta; i++)
                                    {
                                        ConexionBD conexionCLOUD = new ConexionBD(Ambiente);
                                        conexionCLOUD.abrirBD();
                                        String a = "dbnet_set_emex '" + Hold + definicion_DTE_ENCA_DOCU_HOLD43 +

                                         "('" + Hold + "',1 , '" + TipoDocu + "', '1.0', '','' , '' ,'" + i + "', '" + fecha + "', 0 , 0 , 0 , " +
                                         "0 , 0 , 2 , '' , '' , '' , '' , '' , 0 , '" + fechaVenc + "' ,  " + RutEmpresa + " , '" + DigiEmpresa + "' , 'DBNET Ingenieria de Software', 'venta de confites' , '' , 0 , '18 sep 1234' , ' HUECHURABA', 'SANTIAGO' , '', 0 ," +
                                         " '' ,  " + RutEmpresa + " , '" + DigiEmpresa + "' , '111', 'dbnet', 'Papas' , '511551', 'dbnet' , ' CERRILLOS' , 'SANTIAGO', '' , '' , '' ," +
                                         " 0 , '' , '', 0 , '', '' , '', '' , 33.0 , 0.0 , 0.0 , 19.0 , 6.0, 0.0 , 0.0, 0.0  , 39.0 , 0.0 , 0.0 , 0.0 , 0.0 , 'ING', '', '', 0.0, 0.0 , 0 , 0, 0.0, '' , '', 0 , 0 , '', '', '' , '' , '', '' , '' , 0" +
                                         " , '', '', 0 , 0 , 0.0 , 0 , '', 0, '', '', '' , '', '', 0 , '', 0 , '', 0 , 0 , 0.0 , 0 , 0.0 , 0, 0.0, 0.0, 0.0 , 0.0, '' , '', '' , 0.0, 0.0 , 0.0, '' , 0.0 , 0.0 , 0.0 , 0.0  , 0.0 , 0.0 , 0.0 , 0.0 , '' ," +
                                         " ''  , ''  , '' , '' , '' , '' , '', '', '', 0 , 0 , '', 0 , 0 , 0, 0 ) " +



                                         "INSERT INTO dte_deta_acec (codi_emex,codi_empr, tipo_docu, foli_docu, corr_acec, codi_acec) VALUES ('" + Hold + "',1 , '" + TipoDocu + "' , '" + i + "', 0 , convert(varchar(6), 620200 )) " +


                                         "INSERT INTO dte_deta_prse (codi_emex,codi_empr, tipo_docu, foli_docu, nume_line, indi_exen,nomb_item, desc_item, cant_refe,unid_refe, prec_refe, cant_item,fech_elab, fech_vepr, unid_medi,prec_item, " +
                                         "prec_mono, codi_mone,fact_conv, desc_porc, dcto_item,reca_porc, reca_item, codi_impu,neto_item, desc_mone, reca_mone,valo_mone, indi_agen, base_faen, marg_comer, prne_cofi,tipo_codi) " +
                                         "VALUES ('" + Hold + "',1 ,'" + TipoDocu + "' , '" + i + "' , 1 , 0 ,'a', 'a', 0.0 ,'', 0.0 , 1.0 ,'', '', '', 3.0, 0.0 , '',0.0, 0.0, 0.0,0.0 , 0.0, '',3.0  , 0.0 , 0.0 ,0.0 , '', 0.0 ,0.0 , 0.0,33 ) " +


                                         "INSERT INTO dte_deta_codi (codi_emex,codi_empr, tipo_docu, foli_docu, nume_line, tipo_codi, codi_item, corr_codi) VALUES ('" + Hold + "',1 , '" + TipoDocu + "' , '" + i + "', 1 , 'INT1' , '123', 0 ) " +
                                         "INSERT INTO dte_deta_codi (codi_emex,codi_empr, tipo_docu, foli_docu, nume_line, tipo_codi, codi_item, corr_codi) VALUES ('" + Hold + "',1 , '" + TipoDocu + "' , '" + i + "', 1 , 'DUN14' , '2' , 1 ) " +

                                         "INSERT INTO dte_foli_clie (codi_emex,codi_empr, tipo_docu, foli_docu, foli_clie, esta_tras) VALUES ('" + Hold + "',1 , '" + TipoDocu + "' , '" + i + "' , '' , 0 ) ";

                                        string[] Items = { a };

                                        int ItemsSS = GetRandomInt(0, Items.Length);

                                        Insert = Items[ItemsSS];

                                        String Query = Insert;
                                        // int Folioquery = Convert.ToInt32(Foliodesde);
                                        conexionCLOUD.EjecutarSql(Query, i);
                                        conexionCLOUD.CerraBD();
                                    }
                                }

                                break;
                            case 46:
                                if (Checkdeshast.Checked == false)
                                {
                                    validarCampos();
                                    int diferencia = Convert.ToInt32(textBox6.Text);
                                    ConexionBD conexionCLOUD46 = new ConexionBD(Ambiente);
                                    conexionCLOUD46.abrirBD();
                                    String PRC46 = Tabla.PRCCARGADTE(TipoDocu, diferencia, Hold, RutEmpresa, DigiEmpresa);
                                    conexionCLOUD46.EjecutarSql(PRC46);
                                    conexionCLOUD46.CerraBD();
                                }
                                else
                                {
                                    validarCampos();
                                    for (int i = Convert.ToInt32(Foliodesde); i <= Foliohasta; i++)
                                    {
                                        ConexionBD conexionCLOUD = new ConexionBD(Ambiente);
                                        conexionCLOUD.abrirBD();
                                        String a = "dbnet_set_emex '" + Hold + definicion_DTE_ENCA_DOCU_HOLD +
                                                   "('" + Hold + "',1, '" + TipoDocu + "' ,'" + i + "', 'ING', NULL, NULL, NULL, '" + fecha + "', 0 , 0 , 2, NULL, NULL, NULL, NULL, '', '" + fechaVenc + "'," + RutEmpresa + ", NULL, NULL, '" + DigiEmpresa + "', 'DBNET Ingenieria de Software', 'Botellas', NULL, NULL, 'Providencia'," +
                                                   "'Algarrobo', 'ALTO PALENA', NULL, NULL, NULL,78079790, '8', 'dbnet', '789', 'Manzanas', '511551', 'dbnet', 'Canela', 'SANTIAGO', NULL, NULL, NULL, NULL, NULL, '', 0 , '', '', '', '', 15000000, 0, 2850000 , " +
                                                   "NULL, NULL, NULL, 17850000, 0 , 0 , NULL, NULL, NULL, 0 , '1.0', N'" + fecha + "T10:14:56', NULL, CAST(N'" + fecha + " 10:14:56.487' AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, NULL, '', NULL, NULL, " +
                                                   "'D:\\facture_homes\\demo\\out', '', '', '', '', '', '', '', '', '', '', 15, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, '', NULL, NULL, NULL, 0, '', '', " +
                                                   "0, 0 ,0, 0 , '', NULL, NULL, NULL, NULL, '', '', 0, '', 0, '', NULL, NULL,0,0 ,0, 0, NULL, 0, 0, NULL, '', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL," +
                                                   "'', 'S', '0', NULL, NULL, 'demo', NULL, NULL, NULL, NULL, NULL, NULL, '" + Periodo + "', '2020-12', NULL, NULL, NULL, 0 , 0,0, 0 )" +


                                                   "INSERT dte_deta_acec_hold(codi_emex,codi_empr,tipo_docu,foli_docu,corr_acec,codi_acec,mnsg_erro,peri_part) VALUES " +
                                                   "('" + Hold + "', 1, '" + TipoDocu + "', '" + i + "', 0, '620200', '','" + Periodo + "')" +

                                                   "INSERT dte_deta_prse_hold(codi_emex,codi_empr,tipo_docu,foli_docu,nume_line,codi_impu,tipo_codi,codi_item,indi_exen,nomb_item,desc_item,cant_item,cant_refe," +
                                                   "unid_refe,prec_refe,unid_medi,prec_item,prec_mono,codi_mone,fact_conv,dcto_item,reca_item,neto_item,desc_porc,reca_porc,fech_elab,fech_vepr,mnsg_erro,desc_mone," +
                                                   "reca_mone,valo_mone,indi_agen,base_faen,marg_comer,prne_cofi,peri_part) VALUES " +
                                                   " ('" + Hold + "',1 ,'" + TipoDocu + "',  '" + i + "', 1, '', NULL, NULL, 0 , 'Choco', 'lates', 6000, 0 , NULL, NULL, '', 2500, NULL, NULL, NULL, 0 , NULL,15000000, 0, NULL, NULL, NULL, '', NULL, NULL, NULL, NULL, NULL, NULL, NULL, '" + Periodo + "')" +

                                                   "INSERT INTO dte_foli_clie_hold(codi_emex,codi_empr,tipo_docu,foli_docu,foli_clie,esta_tras,peri_part) VALUES ('" + Hold + "',1,'" + TipoDocu + "', '" + i + "','',0,'" + Periodo + "')";

                                        string[] Items = { a };

                                        int ItemsSS = GetRandomInt(0, Items.Length);

                                        Insert = Items[ItemsSS];

                                        String Query = Insert;
                                        // int Folioquery = Convert.ToInt32(Foliodesde);
                                        conexionCLOUD.EjecutarSql(Query, i);
                                        conexionCLOUD.CerraBD();
                                    }
                                }
                                break;
                            case 52:
                                if (Checkdeshast.Checked == false)
                                {
                                    validarCampos();
                                    int diferencia = Convert.ToInt32(textBox6.Text);
                                    ConexionBD conexionCLOUD52 = new ConexionBD(Ambiente);
                                    conexionCLOUD52.abrirBD();
                                    String PRC52 = Tabla.PRCCARGADTE(TipoDocu, diferencia, Hold, RutEmpresa, DigiEmpresa);
                                    conexionCLOUD52.EjecutarSql(PRC52);
                                    conexionCLOUD52.CerraBD();
                                }
                                else
                                {
                                    validarCampos();
                                    if (CKBLeyMaderaTXT.Checked == true)
                                    {
                                        for (int i = Convert.ToInt32(Foliodesde); i <= Foliohasta; i++)
                                        {
                                            ConexionBD conexionCLOUD = new ConexionBD(Ambiente);
                                            conexionCLOUD.abrirBD();
                                            String a = "dbnet_set_emex '" + Hold + definicion_DTE_ENCA_DOCU_HOLD +
                                                       "('" + Hold + "', 1 , '" + TipoDocu + "','" + i + "', 'ING', NULL, NULL, NULL, '" + fecha + "',0 , 0 , 2 , NULL, NULL, NULL, NULL, '', '" + fechaVenc + "'," + RutEmpresa + ", NULL, NULL, '" + DigiEmpresa + "', 'DBNET Ingenieria de Software', 'Botellas', NULL, NULL,'Providencia'," +
                                                       "'Algarrobo', 'ALTO PALENA', NULL, NULL, NULL, 78079790, '8', 'dbnet', '789', 'Manzanas', '511551', 'dbnet', 'Canela', 'SANTIAGO', NULL, NULL, NULL, NULL, NULL, 'XXVV25', 18050200, '9', '', '', '', 12500000," +
                                                       "0, 2375000, NULL, NULL, NULL, 14875000, 0,0, NULL, NULL, NULL, 2 , '1.0', N'" + fecha + "T10:23:23', NULL, CAST(N'" + fecha + " 10:23:23.437' AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, NULL," +
                                                       "'', NULL, NULL, 'D:\\facture_homes\\demo\\out', '', '', '', '', '', '', '', '', '', '', 15, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0 , NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, '', NULL," +
                                                       "NULL, NULL, 18050200, '9', 'Wdadimir ',0,0, 0,0, '', NULL, NULL, NULL, NULL, '', '', 0, '',0 , N'', NULL, NULL, 0, 0, 0, 0, NULL, 0 ,0,0, '', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL," +
                                                       "NULL, NULL, NULL, NULL, NULL, NULL, NULL, '', 'S', '0', NULL, NULL, 'demo', NULL, NULL, NULL, NULL, NULL, NULL, '" + Periodo + "', '2021-01', NULL, NULL, NULL, 0,0,0,0)" +


                                                       "INSERT dte_deta_acec_hold(codi_emex,codi_empr,tipo_docu,foli_docu,corr_acec,codi_acec,mnsg_erro,peri_part) VALUES " +
                                                       "('" + Hold + "', 1, '" + TipoDocu + "', '" + i + "', 0, '620200', '','" + Periodo + "')" +


                                                       "INSERT dte_deta_prse_hold(codi_emex,codi_empr,tipo_docu,foli_docu,nume_line,codi_impu,tipo_codi,codi_item,indi_exen,nomb_item,desc_item,cant_item,cant_refe," +
                                                       "unid_refe,prec_refe,unid_medi,prec_item,prec_mono,codi_mone,fact_conv,dcto_item,reca_item,neto_item,desc_porc,reca_porc,fech_elab,fech_vepr,mnsg_erro,desc_mone," +
                                                       "reca_mone,valo_mone,indi_agen,base_faen,marg_comer,prne_cofi,peri_part) VALUES " +
                                                       " ('" + Hold + "',1 ,'" + TipoDocu + "',  '" + i + "', 1, '', NULL, NULL, 0 , 'Pastel', 'Papas'  ,5000,0 , NULL, NULL, '',2500, NULL, NULL, NULL, 0 ,NULL,12500000,0, NULL, NULL, NULL, '', NULL, NULL, NULL, NULL, NULL, NULL, NULL, '" + Periodo + "')" +

                                                       "INSERT INTO dte_foli_clie_hold(codi_emex,codi_empr,tipo_docu,foli_docu,foli_clie,esta_tras,peri_part) VALUES ('" + Hold + "',1,'" + TipoDocu + "', '" + i + "','',0,'" + Periodo + "')";

                                            string[] Items = { a };

                                            int ItemsSS = GetRandomInt(0, Items.Length);

                                            Insert = Items[ItemsSS];

                                            String Query = Insert;
                                            // int Folioquery = Convert.ToInt32(Foliodesde);
                                            conexionCLOUD.EjecutarSql(Query, i);
                                            conexionCLOUD.CerraBD();
                                        }
                                    }
                                    else
                                    {
                                        for (int i = Convert.ToInt32(Foliodesde); i <= Foliohasta; i++)
                                        {
                                            ConexionBD conexionCLOUD = new ConexionBD(Ambiente);
                                            conexionCLOUD.abrirBD();
                                            String a = "dbnet_set_emex '" + Hold + definicion_DTE_ENCA_DOCU_HOLD +
                                                       "('" + Hold + "', 1 , '" + TipoDocu + "','" + i + "', 'ING', NULL, NULL, NULL, '" + fecha + "',0 , 0 , 2 , NULL, NULL, NULL, NULL, '', '" + fechaVenc + "'," + RutEmpresa + ", NULL, NULL, '" + DigiEmpresa + "', 'DBNET Ingenieria de Software', 'Botellas', NULL, NULL,'Providencia'," +
                                                       "'Algarrobo', 'ALTO PALENA', NULL, NULL, NULL, 78079790, '8', 'dbnet', '789', 'Manzanas', '511551', 'dbnet', 'Canela', 'SANTIAGO', NULL, NULL, NULL, NULL, NULL, 'XXVV25', 18050200, '9', '', '', '', 12500000," +
                                                       "0, 2375000, NULL, NULL, NULL, 14875000, 0,0, NULL, NULL, NULL, 2 , '1.0', N'" + fecha + "T10:23:23', NULL, CAST(N'" + fecha + " 10:23:23.437' AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, NULL," +
                                                       "'', NULL, NULL, 'D:\\facture_homes\\demo\\out', '', '', '', '', '', '', '', '', '', '', 15, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0 , NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, '', NULL," +
                                                       "NULL, NULL, 18050200, '9', 'Wdadimir ',0,0, 0,0, '', NULL, NULL, NULL, NULL, '', '', 0, '',0 , N'', NULL, NULL, 0, 0, 0, 0, NULL, 0 ,0,0, '', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL," +
                                                       "NULL, NULL, NULL, NULL, NULL, NULL, NULL, '', 'S', '0', NULL, NULL, 'demo', NULL, NULL, NULL, NULL, NULL, NULL, '" + Periodo + "', '2021-01', NULL, NULL, NULL, 0,0,0,0)" +


                                                       "INSERT dte_deta_acec_hold(codi_emex,codi_empr,tipo_docu,foli_docu,corr_acec,codi_acec,mnsg_erro,peri_part) VALUES " +
                                                       "('" + Hold + "', 1, '" + TipoDocu + "', '" + i + "', 0, '620200', '','" + Periodo + "')" +


                                                       "INSERT dte_deta_prse_hold(codi_emex,codi_empr,tipo_docu,foli_docu,nume_line,codi_impu,tipo_codi,codi_item,indi_exen,nomb_item,desc_item,cant_item,cant_refe," +
                                                       "unid_refe,prec_refe,unid_medi,prec_item,prec_mono,codi_mone,fact_conv,dcto_item,reca_item,neto_item,desc_porc,reca_porc,fech_elab,fech_vepr,mnsg_erro,desc_mone," +
                                                       "reca_mone,valo_mone,indi_agen,base_faen,marg_comer,prne_cofi,peri_part) VALUES " +
                                                       " ('" + Hold + "',1 ,'" + TipoDocu + "',  '" + i + "', 1, '', NULL, NULL, 0 , 'Pastel', 'Papas'  ,5000,0 , NULL, NULL, '',2500, NULL, NULL, NULL, 0 ,NULL,12500000,0, NULL, NULL, NULL, '', NULL, NULL, NULL, NULL, NULL, NULL, NULL, '" + Periodo + "')" +

                                                       "INSERT INTO dte_foli_clie_hold(codi_emex,codi_empr,tipo_docu,foli_docu,foli_clie,esta_tras,peri_part) VALUES ('" + Hold + "',1,'" + TipoDocu + "', '" + i + "','',0,'" + Periodo + "')";

                                            string[] Items = { a };

                                            int ItemsSS = GetRandomInt(0, Items.Length);

                                            Insert = Items[ItemsSS];

                                            String Query = Insert;
                                            // int Folioquery = Convert.ToInt32(Foliodesde);
                                            conexionCLOUD.EjecutarSql(Query, i);
                                            conexionCLOUD.CerraBD();
                                        }
                                    }
                                }
                                break;
                            case 56:
                                if (Checkdeshast.Checked == false)
                                {
                                    validarCampos();
                                    int diferencia = Convert.ToInt32(textBox6.Text);
                                    ConexionBD conexionCLOUD56 = new ConexionBD(Ambiente);
                                    conexionCLOUD56.abrirBD();
                                    String PRC56 = Tabla.PRCCARGADTE(TipoDocu, diferencia, Hold, RutEmpresa, DigiEmpresa);
                                    conexionCLOUD56.EjecutarSql(PRC56);
                                    conexionCLOUD56.CerraBD();
                                }
                                else
                                {
                                    validarCampos();
                                    for (int i = Convert.ToInt32(Foliodesde); i <= Foliohasta; i++)
                                    {
                                        ConexionBD conexionCLOUD = new ConexionBD(Ambiente);
                                        conexionCLOUD.abrirBD();
                                        String a = "dbnet_set_emex '" + Hold + definicion_DTE_ENCA_DOCU_HOLD +
                                                   "('" + Hold + "', 1,'" + TipoDocu + "','" + i + "', 'ING', NULL, NULL, NULL,'" + fecha + "',0,0 , 2, NULL, NULL, NULL, NULL, '', '" + fechaVenc + "'," + RutEmpresa + ", NULL, NULL, '" + DigiEmpresa + "', 'DBNET Ingenieria de Software', 'Botellas', NULL, NULL, 'Providencia'," +
                                                   "'Algarrobo','ALTO PALENA', NULL, NULL, NULL,78079790,'8','dbnet','789','Manzanas','511551','dbnet','Canela','SANTIAGO', NULL, NULL, NULL, NULL, NULL, '',0,'','','','', 24600000,0,4674000, NULL," +
                                                   "0, NULL,29274000,0,0, NULL, NULL, NULL,0, '1.0', N'" + fecha + "T11:19:19', NULL, CAST(N'" + fecha + " 11:19:19.047' AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, NULL,'', NULL, NULL," +
                                                   "'D:\\facture_homes\\demo\\out','','','','','','','','','', '', 15, NULL, NULL, NULL, NULL, NULL, NULL, NULL,0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, '', NULL, NULL, NULL,0,'','',0," +
                                                   "0,0,0,'', NULL, NULL, NULL, NULL,'','',0,'',0,'', NULL, NULL,0,0,0,0, NULL,0, 0, NULL,'', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, '','S','0'," +
                                                   "NULL, NULL,'demo', NULL, NULL, NULL, NULL, NULL, NULL, '" + Periodo + "', '2021-01', NULL, NULL, NULL,0,0,0,0)" +

                                                   "INSERT dte_deta_acec_hold(codi_emex,codi_empr,tipo_docu,foli_docu,corr_acec,codi_acec,mnsg_erro,peri_part) VALUES " +
                                                   "('" + Hold + "', 1, '" + TipoDocu + "', '" + i + "', 0, '620200', '','" + Periodo + "')" +

                                                   "INSERT dte_deta_prse_hold(codi_emex,codi_empr,tipo_docu,foli_docu,nume_line,codi_impu,tipo_codi,codi_item,indi_exen,nomb_item,desc_item,cant_item,cant_refe," +
                                                   "unid_refe,prec_refe,unid_medi,prec_item,prec_mono,codi_mone,fact_conv,dcto_item,reca_item,neto_item,desc_porc,reca_porc,fech_elab,fech_vepr,mnsg_erro,desc_mone," +
                                                   "reca_mone,valo_mone,indi_agen,base_faen,marg_comer,prne_cofi,peri_part) VALUES " +
                                                   " ('" + Hold + "',1 ,'" + TipoDocu + "',  '" + i + "', 1, '', NULL, NULL, 0 , 'notebook','Asus',200,0, NULL, NULL, '',123000, NULL, NULL, NULL,0, NULL,24600000,0, NULL, NULL, NULL, '', NULL, NULL, NULL, NULL, NULL, NULL, NULL, '" + Periodo + "')" +

                                                   "INSERT INTO dte_foli_clie_hold(codi_emex,codi_empr,tipo_docu,foli_docu,foli_clie,esta_tras,peri_part) VALUES ('" + Hold + "',1,'" + TipoDocu + "', '" + i + "','',0,'" + Periodo + "')" +

                                                    deficion_dte_docu_refe_hold + "('" + Hold + "',1,'" + TipoDocu + "',  '" + i + "',1,'30','1', NULL, NULL,'2020-01-15','Factura','1',0, NULL, NULL, '" + Periodo + "')";



                                        string[] Items = { a };

                                        int ItemsSS = GetRandomInt(0, Items.Length);

                                        Insert = Items[ItemsSS];

                                        String Query = Insert;
                                        // int Folioquery = Convert.ToInt32(Foliodesde);
                                        conexionCLOUD.EjecutarSql(Query, i);
                                        conexionCLOUD.CerraBD();
                                    }
                                }
                                break;
                            case 61:
                                if (Checkdeshast.Checked == false)
                                {
                                    validarCampos();
                                    int diferencia = Convert.ToInt32(textBox6.Text);
                                    ConexionBD conexionCLOUD61 = new ConexionBD(Ambiente);
                                    conexionCLOUD61.abrirBD();
                                    String PRC61 = Tabla.PRCCARGADTE(TipoDocu, diferencia, Hold, RutEmpresa, DigiEmpresa);
                                    conexionCLOUD61.EjecutarSql(PRC61);
                                    conexionCLOUD61.CerraBD();
                                }
                                else
                                {
                                    validarCampos();
                                    for (int i = Convert.ToInt32(Foliodesde); i <= Foliohasta; i++)
                                    {
                                        ConexionBD conexionCLOUD = new ConexionBD(Ambiente);
                                        conexionCLOUD.abrirBD();
                                        String a = "dbnet_set_emex '" + Hold + definicion_DTE_ENCA_DOCU_HOLD +
                                                   "('" + Hold + "',1,'" + TipoDocu + "','" + i + "','ING', NULL, NULL, NULL,'" + fecha + "',0,0,2, NULL, NULL, NULL, NULL,'', '" + fechaVenc + "'," + RutEmpresa + ", NULL, NULL,'" + DigiEmpresa + "','DBNET Ingenieria de Software','Botellas', NULL, NULL,'Providencia'," +
                                                   "'Algarrobo','ALTO PALENA', NULL, NULL, NULL,78079790,'8','dbnet','789','Manzanas','511551','dbnet','Canela','SANTIAGO', NULL, NULL, NULL, NULL, NULL,'',0, '','','','',7500000, 0,1425000, NULL," +
                                                   "0, NULL,8925000,0,0, NULL, NULL, NULL,0,'1.0', N'" + fecha + "T12:09:20', NULL, CAST(N'" + fecha + " 12:09:20.667' AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, NULL,'', NULL, NULL," +
                                                   "'D:\\facture_homes\\demo\\out','','','','','','','','','', '',15, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL,'', NULL, NULL, NULL, 0, '',''," +
                                                   "0,0,0,0, '', NULL, NULL, NULL, NULL, '', '',0,'',0, '', NULL, NULL, 0, 0, 0,0, NULL,0,0, NULL,'', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL," +
                                                   "NULL,'','S','0', NULL, NULL, 'demo', NULL, NULL, NULL, NULL, NULL, NULL, '" + Periodo + "','2021-01', NULL, NULL, NULL,0,0,0,0)" +



                                                   "INSERT dte_deta_acec_hold(codi_emex,codi_empr,tipo_docu,foli_docu,corr_acec,codi_acec,mnsg_erro,peri_part) VALUES " +
                                                   "('" + Hold + "', 1, '" + TipoDocu + "', '" + i + "', 0, '620200', '','" + Periodo + "')" +

                                                   "INSERT dte_deta_prse_hold(codi_emex,codi_empr,tipo_docu,foli_docu,nume_line,codi_impu,tipo_codi,codi_item,indi_exen,nomb_item,desc_item,cant_item,cant_refe," +
                                                   "unid_refe,prec_refe,unid_medi,prec_item,prec_mono,codi_mone,fact_conv,dcto_item,reca_item,neto_item,desc_porc,reca_porc,fech_elab,fech_vepr,mnsg_erro,desc_mone," +
                                                   "reca_mone,valo_mone,indi_agen,base_faen,marg_comer,prne_cofi,peri_part) VALUES " +
                                                   " ('" + Hold + "',1 ,'" + TipoDocu + "',  '" + i + "', 1, '', NULL, NULL, 0 ,'Poleras','Hilos',2500,0, NULL, NULL, '',3000, NULL, NULL, NULL,0, NULL,7500000, NULL, NULL, NULL,'', NULL, NULL, NULL,NULL, NULL, NULL, NULL, NULL, '" + Periodo + "')" +

                                                   "INSERT INTO dte_foli_clie_hold(codi_emex,codi_empr,tipo_docu,foli_docu,foli_clie,esta_tras,peri_part) VALUES ('" + Hold + "',1,'" + TipoDocu + "', '" + i + "','',0,'" + Periodo + "')" +

                                                    deficion_dte_docu_refe_hold + "('" + Hold + "',1,'" + TipoDocu + "',  '" + i + "',1,'30','33', NULL, NULL,'2020-01-15','Factura','1',0, NULL, NULL, '" + Periodo + "')" +
                                                    "INSERT [dbo].[dte_deta_codi_hold] ([codi_emex], [codi_empr], [tipo_docu], [foli_docu], [nume_line], [corr_codi], [tipo_codi], [codi_item], [mnsg_erro], [peri_part]) VALUES " +
                                                    "('" + Hold + "', 1, '" + TipoDocu + "',  '" + i + "', 1, 1, 'INT1', '001', '', '" + Periodo + "')";


                                        string[] Items = { a };

                                        int ItemsSS = GetRandomInt(0, Items.Length);

                                        Insert = Items[ItemsSS];

                                        String Query = Insert;
                                        // int Folioquery = Convert.ToInt32(Foliodesde);
                                        conexionCLOUD.EjecutarSql(Query, i);
                                        conexionCLOUD.CerraBD();
                                    }
                                }
                                break;
                            case 110:
                                if (Checkdeshast.Checked == false)
                                {
                                    validarCampos();
                                    int diferencia = Convert.ToInt32(textBox6.Text);
                                    ConexionBD conexionCLOUD110 = new ConexionBD(Ambiente);
                                    conexionCLOUD110.abrirBD();
                                    String PRC110 = Tabla.PRCCARGADTE(TipoDocu, diferencia, Hold, RutEmpresa, DigiEmpresa);
                                    conexionCLOUD110.EjecutarSql(PRC110);
                                    conexionCLOUD110.CerraBD();
                                }
                                else
                                {
                                    validarCampos();
                                    for (int i = Convert.ToInt32(Foliodesde); i <= Foliohasta; i++)
                                    {
                                        ConexionBD conexionCLOUD = new ConexionBD(Ambiente);
                                        conexionCLOUD.abrirBD();
                                        String a = "dbnet_set_emex '" + Hold + definicion_DTE_ENCA_DOCU_HOLD +
                                                   "('" + Hold + "',1,'" + TipoDocu + "','" + i + "','ING', NULL,NULL,NULL,'" + fecha + "',0,0,2, NULL, NULL, NULL, NULL,'','" + fechaVenc + "'," + RutEmpresa + ", NULL, NULL, '" + DigiEmpresa + "', 'DBNET Ingenieria de Software','Botellas', NULL, NULL,'Providencia','Algarrobo'," +
                                                   "'ALTO PALENA', NULL, NULL, NULL,55555555,'5','dbnet','789','Manzanas','511551','dbnet','Canela','SANTIAGO', NULL, NULL, NULL, NULL, NULL,'',0,'','', '', '', 0,690200000, 0, NULL, NULL, NULL,690200000," +
                                                   "0, 0, NULL, NULL, NULL,0, N'1.0', N'" + fecha + "T14:52:41', NULL, CAST(N'" + fecha + " 14:52:41.680' AS DateTime), NULL, NULL, NULL, NULL," +
                                                   "NULL, NULL, NULL, '', NULL, NULL,'D:\\facture_homes\\demo\\out', '','','','','','','','','','', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, '', NULL, NULL, NULL, 0,'','', 0,0, 0, 0, ''," +
                                                   "NULL, NULL, NULL, NULL, '','', 0,'', 0,'', NULL, NULL,0,0,0,0, NULL,0 ,0,0, '247', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'PESO CL',1, NULL,690200000, NULL, NULL, NULL, NULL,690200000, 'PESO CL','S','0', NULL, NULL, 'demo', NULL, " +
                                                   "NULL, NULL, NULL, NULL, NULL, '" + Periodo + "', '2021-01', NULL, NULL, NULL,0,0,0,0)" +


                                                   "INSERT dte_deta_acec_hold(codi_emex,codi_empr,tipo_docu,foli_docu,corr_acec,codi_acec,mnsg_erro,peri_part) VALUES " +
                                                   "('" + Hold + "', 1, '" + TipoDocu + "', '" + i + "', 0, '620200', '','" + Periodo + "')" +

                                                   "INSERT dte_deta_prse_hold(codi_emex,codi_empr,tipo_docu,foli_docu,nume_line,codi_impu,tipo_codi,codi_item,indi_exen,nomb_item,desc_item,cant_item,cant_refe," +
                                                   "unid_refe,prec_refe,unid_medi,prec_item,prec_mono,codi_mone,fact_conv,dcto_item,reca_item,neto_item,desc_porc,reca_porc,fech_elab,fech_vepr,mnsg_erro,desc_mone," +
                                                   "reca_mone,valo_mone,indi_agen,base_faen,marg_comer,prne_cofi,peri_part) VALUES " +

                                                   "('" + Hold + "',1 ,'" + TipoDocu + "',  '" + i + "', 1, '', NULL, NULL, 0, 'notebook','Teclas',7000,0, NULL, NULL, '',98600, NULL, NULL, NULL,0, NULL,690200000,0, NULL, NULL, NULL, '', NULL, NULL, NULL, NULL, NULL, NULL, NULL, '" + Periodo + "')" +

                                                   "INSERT INTO dte_foli_clie_hold(codi_emex,codi_empr,tipo_docu,foli_docu,foli_clie,esta_tras,peri_part) VALUES ('" + Hold + "',1,'" + TipoDocu + "', '" + i + "','',0,'" + Periodo + "')" +

                                                    deficion_dte_docu_refe_hold + "('" + Hold + "',1,'" + TipoDocu + "',  '" + i + "',1,'50','1', NULL, NULL,'2021-01-27','Doc', NULL,0, NULL, NULL, '" + Periodo + "')" +
                                                                                                 "INSERT [dbo].[dte_deta_codi_hold] ([codi_emex], [codi_empr], [tipo_docu], [foli_docu], [nume_line], [corr_codi], [tipo_codi], [codi_item], [mnsg_erro], [peri_part]) VALUES " +
                                                     "('" + Hold + "', 1, '" + TipoDocu + "',  '" + i + "', 1, 1, 'INT1', '001', '', '" + Periodo + "')";


                                        string[] Items = { a };

                                        int ItemsSS = GetRandomInt(0, Items.Length);

                                        Insert = Items[ItemsSS];

                                        String Query = Insert;
                                        // int Folioquery = Convert.ToInt32(Foliodesde);
                                        conexionCLOUD.EjecutarSql(Query, i);
                                        conexionCLOUD.CerraBD();
                                    }
                                }
                                break;
                            case 111:
                                if (Checkdeshast.Checked == false)
                                {
                                    validarCampos();
                                    int diferencia = Convert.ToInt32(textBox6.Text);
                                    ConexionBD conexionCLOUD111 = new ConexionBD(Ambiente);
                                    conexionCLOUD111.abrirBD();
                                    String PRC111 = Tabla.PRCCARGADTE(TipoDocu, diferencia, Hold, RutEmpresa, DigiEmpresa);
                                    conexionCLOUD111.EjecutarSql(PRC111);
                                    conexionCLOUD111.CerraBD();
                                }
                                else
                                {
                                    validarCampos();
                                    for (int i = Convert.ToInt32(Foliodesde); i <= Foliohasta; i++)
                                    {
                                        ConexionBD conexionCLOUD = new ConexionBD(Ambiente);
                                        conexionCLOUD.abrirBD();
                                        String a = "dbnet_set_emex '" + Hold + definicion_DTE_ENCA_DOCU_HOLD +
                                                   "('" + Hold + "',1,'" + TipoDocu + "','" + i + "','ING', NULL, NULL, NULL,'" + fecha + "',0, 0, 2, NULL, NULL, NULL, NULL, '','" + fechaVenc + "'," + RutEmpresa + ", NULL, NULL, '" + DigiEmpresa + "','DBNET Ingenieria de Software','Botellas', NULL, NULL,'Providencia','Algarrobo'," +
                                                   "'ALTO PALENA', NULL, NULL, NULL,55555555,'5', 'dbnet','789','Manzanas','511551','dbnet','Canela','SANTIAGO', NULL, NULL, NULL, NULL, NULL,'', 0,'','','','', 0,15000000,0, NULL, NULL, NULL,15000000, " +
                                                   "0,0, NULL, NULL, NULL, 0, '1.0', N'" + fecha + "T16:36:03', NULL, CAST(N'" + fecha + " 16:36:03.780' AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, NULL,'', NULL, NULL, N'D:\\facture_homes\\demo\\out','','',''," +
                                                   "'','','','','','','', 15, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, '', NULL, NULL, NULL,0,'','', 0,0, 0, 0,'', NULL, NULL, NULL, NULL,'','', " +
                                                   "0, '',0,'', NULL, NULL,0,0,0, 0, NULL,0,0,0,'', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'PESO CL',1, NULL,15000000, NULL, NULL, NULL, NULL,15000000, 'PESO CL','S','0', NULL, NULL,'demo', NULL, NULL," +
                                                   "NULL, NULL, NULL, NULL, '" + Periodo + "', '2021-01', NULL, NULL, NULL,0,0,0,0 )" +

                                                   "INSERT dte_deta_acec_hold(codi_emex,codi_empr,tipo_docu,foli_docu,corr_acec,codi_acec,mnsg_erro,peri_part) VALUES " +
                                                   "('" + Hold + "', 1, '" + TipoDocu + "', '" + i + "', 0, '620200', '','" + Periodo + "')" +

                                                   "INSERT dte_deta_prse_hold(codi_emex,codi_empr,tipo_docu,foli_docu,nume_line,codi_impu,tipo_codi,codi_item,indi_exen,nomb_item,desc_item,cant_item,cant_refe," +
                                                   "unid_refe,prec_refe,unid_medi,prec_item,prec_mono,codi_mone,fact_conv,dcto_item,reca_item,neto_item,desc_porc,reca_porc,fech_elab,fech_vepr,mnsg_erro,desc_mone," +
                                                   "reca_mone,valo_mone,indi_agen,base_faen,marg_comer,prne_cofi,peri_part) VALUES " +

                                                   "('" + Hold + "',1,'" + TipoDocu + "',  '" + i + "', 1, '', NULL, NULL, 0,'Pan','Amasado',500,0, NULL, NULL,'', 30000, NULL, NULL, NULL, 0, NULL,15000000,0, NULL, NULL, NULL,'', NULL, NULL, NULL, NULL, NULL, NULL, NULL, '" + Periodo + "')" +

                                                   "INSERT INTO dte_foli_clie_hold(codi_emex,codi_empr,tipo_docu,foli_docu,foli_clie,esta_tras,peri_part) VALUES ('" + Hold + "',1,'" + TipoDocu + "', '" + i + "','',0,'" + Periodo + "')" +

                                                    deficion_dte_docu_refe_hold + "('" + Hold + "',1,'" + TipoDocu + "',  '" + i + "',1,'50','1', NULL, NULL,'2021-01-30','Factura','1',0, NULL, NULL,'" + Periodo + "')" +


                                                     "INSERT [dbo].[dte_deta_codi_hold] ([codi_emex], [codi_empr], [tipo_docu], [foli_docu], [nume_line], [corr_codi], [tipo_codi], [codi_item], [mnsg_erro], [peri_part]) VALUES " +
                                                     "('" + Hold + "', 1, '" + TipoDocu + "',  '" + i + "', 1, 1, 'INT1', '001', '', '" + Periodo + "')";


                                        string[] Items = { a };

                                        int ItemsSS = GetRandomInt(0, Items.Length);

                                        Insert = Items[ItemsSS];

                                        String Query = Insert;
                                        // int Folioquery = Convert.ToInt32(Foliodesde);
                                        conexionCLOUD.EjecutarSql(Query, i);
                                        conexionCLOUD.CerraBD();
                                    }
                                }
                                break;
                            case 112:
                                if (Checkdeshast.Checked == false)
                                {
                                    validarCampos();
                                    int diferencia = Convert.ToInt32(textBox6.Text);
                                    ConexionBD conexionCLOUD112 = new ConexionBD(Ambiente);
                                    conexionCLOUD112.abrirBD();
                                    String PRC112 = Tabla.PRCCARGADTE(TipoDocu, diferencia, Hold, RutEmpresa, DigiEmpresa);
                                    conexionCLOUD112.EjecutarSql(PRC112);
                                    conexionCLOUD112.CerraBD();
                                }
                                else
                                {
                                    validarCampos();
                                    for (int i = Convert.ToInt32(Foliodesde); i <= Foliohasta; i++)
                                    {
                                        ConexionBD conexionCLOUD = new ConexionBD(Ambiente);
                                        conexionCLOUD.abrirBD();
                                        String a = "dbnet_set_emex '" + Hold + definicion_DTE_ENCA_DOCU_HOLD +
                                                   "('" + Hold + "',1,'" + TipoDocu + "','" + i + "','ING', NULL, NULL, NULL,'" + fecha + "',0,0,2, NULL, NULL, NULL, NULL,'','" + fechaVenc + "'," + RutEmpresa + ", NULL, NULL, '" + DigiEmpresa + "', 'DBNET Ingenieria de Software','Botellas', NULL, NULL,'Providencia','Algarrobo'," +
                                                    "'ALTO PALENA', NULL, NULL, NULL, 55555555,'5','dbnet','789','Manzanas','511551','dbnet','Canela','SANTIAGO', NULL, NULL, NULL, NULL, NULL,'',0 ,'','','','',0,14689800,0, NULL, NULL, NULL, 14689800, 0, 0, NULL, " +
                                                    "NULL, NULL,0,'1.0', N'" + fecha + "T17:13:54', NULL, CAST(N'" + fecha + " 17:13:53.873' AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, NULL,'', NULL, NULL, N'D:\\facture_homes\\demo\\out','','','','','',''," +
                                                    "'','','','', 15, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL,'', NULL, NULL, NULL, 0,'','', 0,0,0, 0,'', NULL, NULL, NULL, NULL,'','', 0,'', 0, '', NULL," +
                                                    "NULL,0,0, 0,0, NULL, 0,0,0, '', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL,'PESO CL', 1, NULL,14689800, NULL, NULL, NULL, NULL,14689800,'PESO CL','S','0', NULL, NULL,'demo', NULL, NULL, NULL, NULL, NULL, " +
                                                    "NULL, '" + Periodo + "','2021-01', NULL, NULL, NULL, 0,0,0,0)" +



                                                   "INSERT dte_deta_acec_hold(codi_emex,codi_empr,tipo_docu,foli_docu,corr_acec,codi_acec,mnsg_erro,peri_part) VALUES " +
                                                   "('" + Hold + "', 1, '" + TipoDocu + "', '" + i + "', 0, '620200', '','" + Periodo + "')" +

                                                   "INSERT dte_deta_prse_hold(codi_emex,codi_empr,tipo_docu,foli_docu,nume_line,codi_impu,tipo_codi,codi_item,indi_exen,nomb_item,desc_item,cant_item,cant_refe," +
                                                   "unid_refe,prec_refe,unid_medi,prec_item,prec_mono,codi_mone,fact_conv,dcto_item,reca_item,neto_item,desc_porc,reca_porc,fech_elab,fech_vepr,mnsg_erro,desc_mone," +
                                                   "reca_mone,valo_mone,indi_agen,base_faen,marg_comer,prne_cofi,peri_part) VALUES " +

                                                   "('" + Hold + "',1,'" + TipoDocu + "',  '" + i + "', 1,'' , NULL, NULL, 0,'Flan','Manjar',300,0, NULL, NULL,'',48966, NULL, NULL, NULL,0, NULL,14689800,0, NULL, NULL, NULL,'', NULL, NULL, NULL, NULL, NULL, NULL, NULL,'" + Periodo + "')" +


                                                   "INSERT INTO dte_foli_clie_hold(codi_emex,codi_empr,tipo_docu,foli_docu,foli_clie,esta_tras,peri_part) VALUES ('" + Hold + "',1,'" + TipoDocu + "', '" + i + "','',0,'" + Periodo + "')" +

                                                   deficion_dte_docu_refe_hold + "('" + Hold + "',1,'" + TipoDocu + "',  '" + i + "',1,'50','22', NULL, NULL,'2021-01-28','1','1',0, NULL, NULL, '" + Periodo + "')" +


                                                    "INSERT [dbo].[dte_deta_codi_hold] ([codi_emex], [codi_empr], [tipo_docu], [foli_docu], [nume_line], [corr_codi], [tipo_codi], [codi_item], [mnsg_erro], [peri_part]) VALUES " +
                                                    "('" + Hold + "', 1, '" + TipoDocu + "',  '" + i + "', 1, 1, 'INT1', '001', '', '" + Periodo + "')";


                                        string[] Items = { a };

                                        int ItemsSS = GetRandomInt(0, Items.Length);

                                        Insert = Items[ItemsSS];

                                        String Query = Insert;
                                        // int Folioquery = Convert.ToInt32(Foliodesde);
                                        conexionCLOUD.EjecutarSql(Query, i);
                                        conexionCLOUD.CerraBD();
                                    }
                                }
                                break;
                        }
                        MessageBox.Show("Termine ");

                        break;
                    #endregion


                    #region CaseSQL
                    case "SQL":

                        definicion_dte_enca_docu = " INSERT dte_enca_docu (codi_empr,tipo_docu, foli_docu, esta_docu, mens_esta, corr_envi, mens_envi, fech_emis, entr_bien, vent_serv, form_pago, fech_canc, dias_tepa, codi_tepa, mont_brut, " +
                                                    "moda_pago, fech_venc, rutt_emis, peri_desd, peri_hast, digi_emis, nomb_emis, giro_emis, nomb_sucu , codi_sucu , dire_orig, comu_orig, ciud_orig, codi_vend, rutt_mand, digi_mand, rutt_rece, " +
                                                    "digi_rece, nomb_rece, codi_rece, giro_rece, cont_rece, dire_rece, comu_rece, ciud_rece, dire_post , comu_post , ciud_post, rutt_sofa, digi_sofa, info_tran, rutt_tran, digi_tran, dire_dest, " +
                                                    "comu_dest, ciud_dest, mont_neto, mont_exen, impu_vaag, impu_vanr, cred_es65, gara_enva, mont_tota , mont_nofa , valo_paga, sald_ante, codi_ceco, feho_firm, indi_vegd, vers_enca, " +
                                                    "feho_ted ,  firm_ted, fech_carg, usua_impr, nume_impr, fech_impr, vige_docu, codi_peri, corr_envi1, esta_docu1, mnsg_erro, indi_nore, subt_vese, dire_arch, impr_dest, val1, val2, val3, " +
                                                    "val4 ,  val5 ,  val6, val7, val8, val9, tasa_vaag, mont_base, cola_proc, nume_imme, arch_resp , hace_envi , tipo_impr, mont_canc, sald_inso, from_paex, tipo_cupa, cuen_pago, banc_pago, " +
                                                    "glos_pago, codi_emtr, foli_auto, fech_auto, codi_suad, iden_adem, iden_reex, naci_ext  , iden_adre , mail_rece, rutt_chof, digi_chof, nomb_chof, moda_vent, clau_expo, tota_clex, viaa_tran, " +
                                                    "nomb_tran, rutt_citr, digi_citr, nomb_citr, iden_citr, nume_book, codi_oper, codi_puem , iden_puem , codi_pude, iden_pude, cant_tara, umed_tara, tota_brut, unid_brut, tota_neto, unid_neto," +
                                                    "tota_item, tota_bult, mont_flet, mont_segu, pais_rece, pais_dest, tipo_mone, mont_baco , ivag_prop , ivag_terc, valo_cone, valo_coex, ivaag_core,tipo_moom, tipo_camb, neto_otmo, noaf_otmo," +
                                                    "faca_otmo, maco_otmo, ivag_otmo, ivno_otmo, mont_otmo, foli_clie, corr_extr, codi_usua , comi_neto , comi_exen, comi_ivaa, codi_emex, lote_docu, codi_serv, corr_cert_Firm, codi_form, peri_part," +
                                                    "esta_reme, even_recl, docu_escd, tran_vent, tran_comp, TIPO_FAES, TIPO_TURI) VALUES  ";
                        definicion_dte_docu_refe = " INSERT dte_docu_refe (codi_empr, tipo_docu, foli_docu, nume_refe, tipo_refe, foli_refe, rutt_otro, digi_otro, fech_refe, razo_refe, codi_refe, indi_regl, mnsg_erro, foli_clie, codi_emex, peri_part) VALUES";
                        validarCampos();
                        switch (TipoDocu)
                        {

                            case 33:

                                for (int i = Convert.ToInt32(Foliodesde); i <= Foliohasta; i++)
                                {
                                    ConexionBD conexionCLOUD = new ConexionBD(Ambiente);
                                    conexionCLOUD.abrirBD();
                                    String a = definicion_dte_enca_docu +
                                              "(1 , '" + TipoDocu + "', '" + i + "', 'ING', NULL, NULL, NULL, '" + fecha + "', NULL,   0 , 2   , NULL, NULL, NULL, NULL,   '', '" + fechaVenc + "' , " + RutEmpresa + ", NULL, NULL, '" + DigiEmpresa + "', " +
                                                "'DBNET Ingenieria de Software', 'Las mejores frutas', NULL, NULL, 'Av siempre viva 335', ' HUECHURABA', 'SANTIAGO', NULL, NULL, NULL, 78079790 , '8', 'dbnet', '123', 'Botellas', '511551', 'dbnet', ' CERRILLOS', " +
                                                "'SANTIAGO',              NULL, NULL, NULL, NULL, NULL, '', 0 , '', '', '', '', 500000000   , 0         , 95000000  , NULL, 0   , NULL, 595000000  , 0 , 0 , NULL, NULL, NULL, 0 , '1.0', '" + fecha + "T09:05:29'," +
                                                " NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, '', NULL, NULL, 'C:\\esuite\\out', '', '', '', '', '', '', '', '', '', '', 19, NULL, NULL, NULL, NULL, 'S', NULL, NULL, NULL, 0 , NULL, NULL, NULL, NULL, NULL, " +
                                                " NULL, NULL, NULL, NULL, '', NULL, NULL, NULL, NULL, NULL, NULL, 0 , 0 , 0, 0 , '', NULL, NULL, NULL, NULL, '', '', 0   , NULL, 0   , NULL, NULL, NULL, 0, 0, 0, 0 , NULL, 0 , 0, NULL, ''   , NULL, ''    , NULL, NULL," +
                                                " NULL, NULL, NULL, NULL, NULL     , NULL, NULL, NULL        , NULL, NULL, NULL, NULL, NULL        , '0', NULL, 'esuite', NULL, NULL    , NULL, 'PROD_0000', '2021-01', NULL, NULL, NULL, 202101, NULL, NULL, NULL, 0 ," +
                                                " 0, 0 , 0 )" +


                                               "INSERT dte_deta_acec(codi_empr,tipo_docu,foli_docu,corr_acec,codi_acec,mnsg_erro,peri_part) VALUES " +
                                               "( 1, '" + TipoDocu + "', '" + i + "', 0, '620200', '','" + Periodo + "')" +

                                               "INSERT dte_deta_prse(codi_emex,codi_empr,tipo_docu,foli_docu,nume_line,codi_impu,tipo_codi,codi_item,indi_exen,nomb_item,desc_item,cant_item,cant_refe," +
                                               "unid_refe,prec_refe,unid_medi,prec_item,prec_mono,codi_mone,fact_conv,dcto_item,reca_item,neto_item,desc_porc,reca_porc,fech_elab,fech_vepr,mnsg_erro,desc_mone," +
                                               "reca_mone,valo_mone,indi_agen,base_faen,marg_comer,prne_cofi,peri_part) VALUES " +
                                               "('PROD_0000', 1, '" + TipoDocu + "',  '" + i + "', 1, '', NULL, NULL, 0, 'Calabaza', '', 1.000000, 0, '', 0.000000, '', 209409.000000, 0.000000, '', 0.0000, 0, 0, 209409.0000, 0.00, 0.00, '', '', '', 0.0000, 0.0000, 0.0000, '', 0, 0, 0, '" + Periodo + "')" +

                                               "INSERT INTO dte_foli_clie(codi_emex,codi_empr,tipo_docu,foli_docu,foli_clie,esta_tras,peri_part) VALUES ('PROD_0000',1,'" + TipoDocu + "', '" + i + "','',0,'" + Periodo + "')";



                                    string[] Items = { a };

                                    int ItemsSS = GetRandomInt(0, Items.Length);

                                    Insert = Items[ItemsSS];

                                    String Query = Insert;
                                    // int Folioquery = Convert.ToInt32(Foliodesde);
                                    conexionCLOUD.EjecutarSql(Query, i);
                                    conexionCLOUD.CerraBD();
                                }
                                break;

                            case 34:
                                for (int i = Convert.ToInt32(Foliodesde); i <= Foliohasta; i++)
                                {
                                    ConexionBD conexionCLOUD = new ConexionBD(Ambiente);
                                    conexionCLOUD.abrirBD();
                                    String a = definicion_dte_enca_docu +
                                              "(1 , '" + TipoDocu + "', '" + i + "', 'ING', NULL, NULL, NULL, '" + fecha + "', NULL,   0 , 2   , NULL, NULL, NULL, NULL,   '', '" + fechaVenc + "' , " + RutEmpresa + ", NULL, NULL, '" + DigiEmpresa + "', " +
                                                "'DBNET Ingenieria de Software', 'Las mejores frutas', NULL, NULL, 'Av siempre viva 335', ' HUECHURABA', 'SANTIAGO', NULL, NULL, NULL, 78079790 , '8', 'dbnet', '123', 'Botellas', '511551', 'dbnet', ' CERRILLOS'," +
                                                " 'SANTIAGO',              NULL, NULL, NULL, NULL, NULL, '', 0 , '', '', '', '', 0           , 6250000   , 0         , NULL, NULL, NULL, 6250000    , 0 , 0 , NULL, NULL, NULL, 0 , '1.0' , '" + fecha + "T09:06:12'," +
                                                " NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, '', NULL, NULL, 'C:\\esuite\\out', '', '', '', '', '', '', '', '', '', '', 0 , NULL, NULL, NULL, NULL, 'S', NULL, NULL, NULL, 0 , NULL, NULL, NULL, NULL, NULL, " +
                                                " NULL, NULL, NULL, NULL, '', NULL, NULL, NULL, NULL, NULL, NULL, 0 , 0 , 0, 0 , '', NULL, NULL, NULL, NULL, '', '', 0   , NULL, 0   , NULL, NULL, NULL, 0, 0, 0, 0 , NULL, 0 , 0, NULL, ''   , NULL, ''    , NULL, NULL," +
                                                " NULL, NULL, NULL, NULL, NULL     , NULL, NULL, NULL        , NULL, NULL, NULL, NULL, NULL        , '0', NULL, 'esuite', NULL, NULL    , NULL, 'PROD_0000', '2021-01', NULL, NULL, NULL, 202101, NULL, NULL, NULL, 0 ," +
                                                " 0, 0 , 0 )" +


                                               "INSERT dte_deta_acec(codi_empr,tipo_docu,foli_docu,corr_acec,codi_acec,mnsg_erro,peri_part) VALUES " +
                                               "( 1, '" + TipoDocu + "', '" + i + "', 0, '620200', '','" + Periodo + "')" +

                                               "INSERT dte_deta_prse(codi_emex,codi_empr,tipo_docu,foli_docu,nume_line,codi_impu,tipo_codi,codi_item,indi_exen,nomb_item,desc_item,cant_item,cant_refe," +
                                               "unid_refe,prec_refe,unid_medi,prec_item,prec_mono,codi_mone,fact_conv,dcto_item,reca_item,neto_item,desc_porc,reca_porc,fech_elab,fech_vepr,mnsg_erro,desc_mone," +
                                               "reca_mone,valo_mone,indi_agen,base_faen,marg_comer,prne_cofi,peri_part) VALUES " +
                                               " ('PROD_0000', 1, '" + TipoDocu + "',  '" + i + "', 1, '', NULL, NULL, 0, 'Gorra', 'Nike', 500,0 , NULL, NULL, '', 50000, NULL, NULL, NULL, 0 , NULL, 25000000, 0, NULL, NULL, NULL, '', NULL, NULL, NULL, NULL, NULL, NULL, NULL,'" + Periodo + "')" +

                                               "INSERT INTO dte_foli_clie(codi_empr,tipo_docu,foli_docu,foli_clie,esta_tras,peri_part) VALUES (1,'" + TipoDocu + "', '" + i + "','',0,'" + Periodo + "')";

                                    string[] Items = { a };

                                    int ItemsSS = GetRandomInt(0, Items.Length);

                                    Insert = Items[ItemsSS];

                                    String Query = Insert;
                                    // int Folioquery = Convert.ToInt32(Foliodesde);
                                    conexionCLOUD.EjecutarSql(Query, i);
                                    conexionCLOUD.CerraBD();
                                }
                                break;
                            case 43:
                                for (int i = Convert.ToInt32(Foliodesde); i <= Foliohasta; i++)
                                {
                                    ConexionBD conexionCLOUD = new ConexionBD(Ambiente);
                                    conexionCLOUD.abrirBD();
                                    String a = definicion_dte_enca_docu +
                                              "(1 , '" + TipoDocu + "', '" + i + "', 'ING', NULL, NULL, NULL, '" + fecha + "', NULL,   0 , 2   , NULL, NULL, NULL, NULL,   '', '" + fechaVenc + "' , " + RutEmpresa + ", NULL, NULL, '" + DigiEmpresa + "'," +
                                                " 'DBNET Ingenieria de Software', 'Las mejores frutas', NULL, NULL, 'Av siempre viva 335', ' HUECHURABA', 'SANTIAGO', NULL, NULL, NULL, 78079790 , '8', 'dbnet', '123', 'Botellas', '511551', 'dbnet', ' CERRILLOS'," +
                                                " 'SANTIAGO',              NULL, NULL, NULL, NULL, NULL, '', 0 , '', '', '', '', 2025000     , 0         , 384750    , NULL, NULL, NULL, 2409750    , 0 , 0 , NULL, NULL, NULL, 0 , '1.0' , '" + fecha + "T09:07:20'," +
                                                " NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, '', NULL, NULL, 'C:\\esuite\\out', '', '', '', '', '', '', '', '', '', '', 19, NULL, NULL, NULL, NULL, 'S', NULL, NULL, NULL, 0 , NULL, NULL, NULL, NULL, NULL," +
                                                " NULL, NULL, NULL, NULL, '', NULL, NULL, NULL, NULL, NULL, NULL, 0 , 0 , 0, 0 , '', NULL, NULL, NULL, NULL, '', '', 0   , NULL, 0   , NULL, NULL, NULL, 0, 0, 0, 0 , NULL, 0 , 0, NULL, ''   , NULL, ''    , NULL, NULL," +
                                                " NULL, NULL, NULL, NULL, NULL     , NULL, NULL, NULL        , NULL, NULL, NULL, NULL, NULL        , '0', NULL, 'esuite', 0   , 0       , 0   , 'PROD_0000', '2021-01', NULL, NULL, NULL, 202101, NULL, NULL, NULL," +
                                                " 0 , 0, 0 , 0 )" +


                                               "INSERT dte_deta_acec(codi_empr,tipo_docu,foli_docu,corr_acec,codi_acec,mnsg_erro,peri_part) VALUES " +
                                               "( 1, '" + TipoDocu + "', '" + i + "', 0, '620200', '','" + Periodo + "')" +

                                               "INSERT dte_deta_prse(codi_emex,codi_empr,tipo_docu,foli_docu,nume_line,codi_impu,tipo_codi,codi_item,indi_exen,nomb_item,desc_item,cant_item,cant_refe," +
                                               "unid_refe,prec_refe,unid_medi,prec_item,prec_mono,codi_mone,fact_conv,dcto_item,reca_item,neto_item,desc_porc,reca_porc,fech_elab,fech_vepr,mnsg_erro,desc_mone," +
                                               "reca_mone,valo_mone,indi_agen,base_faen,marg_comer,prne_cofi,peri_part) VALUES " +
                                               " ('PROD_0000', 1, '" + TipoDocu + "',  '" + i + "', 1, '', NULL, NULL, 0, 'Gorra', 'Nike', 500,0 , NULL, NULL, '', 50000, NULL, NULL, NULL, 0 , NULL, 25000000, 0, NULL, NULL, NULL, '', NULL, NULL, NULL, NULL, NULL, NULL, NULL,'" + Periodo + "')" +

                                               "INSERT INTO dte_foli_clie(codi_empr,tipo_docu,foli_docu,foli_clie,esta_tras,peri_part) VALUES (1,'" + TipoDocu + "', '" + i + "','',0,'" + Periodo + "')";

                                    string[] Items = { a };

                                    int ItemsSS = GetRandomInt(0, Items.Length);

                                    Insert = Items[ItemsSS];

                                    String Query = Insert;
                                    // int Folioquery = Convert.ToInt32(Foliodesde);
                                    conexionCLOUD.EjecutarSql(Query, i);
                                    conexionCLOUD.CerraBD();
                                }
                                break;
                            case 46:
                                for (int i = Convert.ToInt32(Foliodesde); i <= Foliohasta; i++)
                                {
                                    ConexionBD conexionCLOUD = new ConexionBD(Ambiente);
                                    conexionCLOUD.abrirBD();
                                    String a = definicion_dte_enca_docu +
                                               "(1 , '" + TipoDocu + "', '" + i + "', 'ING', NULL, NULL, NULL, '" + fecha + "', NULL,   0 , 2   , NULL, NULL, NULL, NULL,   '', '" + fechaVenc + "' , " + RutEmpresa + ", NULL, NULL, '" + DigiEmpresa + "'," +
                                               "'DBNET Ingenieria de Software', 'Las mejores frutas', NULL, NULL, 'Av siempre viva 335', ' HUECHURABA', 'SANTIAGO', NULL, NULL, NULL, 78079790 , '8', 'dbnet', '123', 'Botellas', '511551', 'dbnet', ' CERRILLOS'," +
                                               "'SANTIAGO',              NULL, NULL, NULL, NULL, NULL, '', 0 , '', '', '', '', 247500000   , 0         , 47025000  , NULL, NULL, NULL, 294525000  , 0 , 0 , NULL, NULL, NULL, 0 , '1.0' , '" + fecha + "T09:08:02', " +
                                               "NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, '', NULL, NULL, 'C:\\esuite\\out', '', '', '', '', '', '', '', '', '', '', 19, NULL, NULL, NULL, NULL, 'S', NULL, NULL, NULL, 0 , NULL, NULL, NULL, NULL, NULL, " +
                                               "NULL, NULL, NULL, NULL, '', NULL, NULL, NULL, NULL, NULL, NULL, 0 , 0 , 0, 0 , '', NULL, NULL, NULL, NULL, '', '', 0   , NULL, 0   , NULL, NULL, NULL, 0, 0, 0, 0 , NULL, 0 , 0, NULL, ''   , NULL, ''    , NULL, NULL," +
                                               "NULL, NULL, NULL, NULL, NULL     , NULL, NULL, NULL        , NULL, NULL, NULL, NULL, NULL        , '0', NULL, 'esuite', NULL, NULL    , NULL, 'PROD_0000', '2021-01', NULL, NULL, NULL, 202101, NULL, NULL, NULL," +
                                               "0 , 0, 0 , 0 )" +


                                               "INSERT dte_deta_acec(codi_empr,tipo_docu,foli_docu,corr_acec,codi_acec,mnsg_erro,peri_part) VALUES " +
                                               "( 1, '" + TipoDocu + "', '" + i + "', 0, '620200', '','" + Periodo + "')" +

                                               "INSERT dte_deta_prse(codi_emex,codi_empr,tipo_docu,foli_docu,nume_line,codi_impu,tipo_codi,codi_item,indi_exen,nomb_item,desc_item,cant_item,cant_refe," +
                                               "unid_refe,prec_refe,unid_medi,prec_item,prec_mono,codi_mone,fact_conv,dcto_item,reca_item,neto_item,desc_porc,reca_porc,fech_elab,fech_vepr,mnsg_erro,desc_mone," +
                                               "reca_mone,valo_mone,indi_agen,base_faen,marg_comer,prne_cofi,peri_part) VALUES " +
                                               " ('PROD_0000',1 ,'" + TipoDocu + "',  '" + i + "', 1, '', NULL, NULL, 0 , 'Choco', 'lates', 6000, 0 , NULL, NULL, '', 2500, NULL, NULL, NULL, 0 , NULL,15000000, 0, NULL, NULL, NULL, '', NULL, NULL, NULL, NULL, NULL, NULL, NULL, '" + Periodo + "')" +

                                               "INSERT INTO dte_foli_clie(codi_empr,tipo_docu,foli_docu,foli_clie,esta_tras,peri_part) VALUES (1,'" + TipoDocu + "', '" + i + "','',0,'" + Periodo + "')";

                                    string[] Items = { a };

                                    int ItemsSS = GetRandomInt(0, Items.Length);

                                    Insert = Items[ItemsSS];

                                    String Query = Insert;
                                    // int Folioquery = Convert.ToInt32(Foliodesde);
                                    conexionCLOUD.EjecutarSql(Query, i);
                                    conexionCLOUD.CerraBD();
                                }
                                break;
                            case 52:
                                for (int i = Convert.ToInt32(Foliodesde); i <= Foliohasta; i++)
                                {
                                    ConexionBD conexionCLOUD = new ConexionBD(Ambiente);
                                    conexionCLOUD.abrirBD();
                                    String a = definicion_dte_enca_docu +
                                               "(1 , '" + TipoDocu + "', '" + i + "', 'ING', NULL, NULL, NULL, '" + fecha + "', NULL,   0 , 2   , NULL, NULL, NULL, NULL,   '', '" + fechaVenc + "' , " + RutEmpresa + ", NULL, NULL, '" + DigiEmpresa + "', " +
                                                "'DBNET Ingenieria de Software', 'Las mejores frutas', NULL, NULL, 'Av siempre viva 335', ' HUECHURABA', 'SANTIAGO', NULL, NULL, NULL, 55555555 , '5', 'Empresa Internacional', '852', 'Frutillas', '', 'Tokyo', " +
                                                "' CERRO NAVIA', 'SANTIAGO', NULL, NULL, NULL, NULL, NULL, '', 0 , '', '', '', '', 7700000     , 0         , 1463000   , NULL, NULL, NULL, 9163000    , 0 , 0 , NULL, NULL, NULL, 0 , '1.0', '" + fecha + "T09:11:20'," +
                                                " NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, '', NULL, NULL, 'C:\\esuite\\out', '', '', '', '', '', '', '', '', '', '', 19, NULL, NULL, NULL, NULL, 'S', NULL, NULL, NULL, 0 , NULL, NULL, NULL, NULL, NULL, " +
                                                " NULL, NULL, NULL, NULL, '', NULL, NULL, NULL, NULL, NULL, NULL, 0 , 0 , 0, 0 , '', NULL, NULL, NULL, NULL, '', '', 0   , NULL, 0   , NULL, NULL, NULL, 0, 0, 0, 0 , NULL, 0 , 0, NULL, ''   , NULL, ''    , NULL, NULL," +
                                                " NULL, NULL, NULL, NULL, NULL     , NULL, NULL, NULL        , NULL, NULL, NULL, NULL, NULL        , '0', NULL, 'esuite', NULL, NULL    , NULL, 'PROD_0000', '2021-01', NULL, NULL, NULL, 202101, NULL, NULL, NULL," +
                                                " 0 , 0, 0 , 0 )" +


                                               "INSERT dte_deta_acec(codi_empr,tipo_docu,foli_docu,corr_acec,codi_acec,mnsg_erro,peri_part) VALUES " +
                                               "( 1, '" + TipoDocu + "', '" + i + "', 0, '620200', '','" + Periodo + "')" +


                                               "INSERT dte_deta_prse(codi_emex,codi_empr,tipo_docu,foli_docu,nume_line,codi_impu,tipo_codi,codi_item,indi_exen,nomb_item,desc_item,cant_item,cant_refe," +
                                               "unid_refe,prec_refe,unid_medi,prec_item,prec_mono,codi_mone,fact_conv,dcto_item,reca_item,neto_item,desc_porc,reca_porc,fech_elab,fech_vepr,mnsg_erro,desc_mone," +
                                               "reca_mone,valo_mone,indi_agen,base_faen,marg_comer,prne_cofi,peri_part) VALUES " +
                                               " ('PROD_0000',1 ,'" + TipoDocu + "',  '" + i + "', 1, '', NULL, NULL, 0 , 'Pastel', 'Papas'  ,5000,0 , NULL, NULL, '',2500, NULL, NULL, NULL, 0 ,NULL,12500000,0, NULL, NULL, NULL, '', NULL, NULL, NULL, NULL, NULL, NULL, NULL, '" + Periodo + "')" +

                                               "INSERT INTO dte_foli_clie(codi_empr,tipo_docu,foli_docu,foli_clie,esta_tras,peri_part) VALUES (1,'" + TipoDocu + "', '" + i + "','',0,'" + Periodo + "')";

                                    string[] Items = { a };

                                    int ItemsSS = GetRandomInt(0, Items.Length);

                                    Insert = Items[ItemsSS];

                                    String Query = Insert;
                                    // int Folioquery = Convert.ToInt32(Foliodesde);
                                    conexionCLOUD.EjecutarSql(Query, i);
                                    conexionCLOUD.CerraBD();
                                }

                                break;
                            case 56:
                                for (int i = Convert.ToInt32(Foliodesde); i <= Foliohasta; i++)
                                {
                                    ConexionBD conexionCLOUD = new ConexionBD(Ambiente);
                                    conexionCLOUD.abrirBD();
                                    String a = definicion_dte_enca_docu +
                                               "(1 , '" + TipoDocu + "', '" + i + "', 'ING', NULL, NULL, NULL, '" + fecha + "', NULL,   0 , 2   , NULL, NULL, NULL, NULL,   '', '" + fechaVenc + "' , " + RutEmpresa + ", NULL, NULL, '" + DigiEmpresa + "'," +
                                               "'DBNET Ingenieria de Software', 'Las mejores frutas', NULL, NULL, 'Av siempre viva 335', ' HUECHURABA', 'SANTIAGO', NULL, NULL, NULL, 78079790 , '8', 'dbnet', '123', 'Botellas', '511551', 'dbnet', ' CERRILLOS'," +
                                               "'SANTIAGO',              NULL, NULL, NULL, NULL, NULL, '', 0 , '', '', '', '', 354892000   , 0         , 67429480  , NULL, 0   , NULL, 422321480  , 0 , 0 , NULL, NULL, NULL, 0 , '1.0','" + fecha + "T09:12:20'," +
                                               "NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, '', NULL, NULL, 'C:\\esuite\\out', '', '', '', '', '', '', '', '', '', '', 19, NULL, NULL, NULL, NULL, 'S', NULL, NULL, NULL, 0 , NULL, NULL, NULL, NULL, NULL," +
                                               "NULL, NULL, NULL, NULL, '', NULL, NULL, NULL, NULL, NULL, NULL, 0 , 0 , 0, 0 , '', NULL, NULL, NULL, NULL, '', '', 0   , NULL, 0   , NULL, NULL, NULL, 0, 0, 0, 0 , NULL, 0 , 0, NULL, ''   , NULL, ''    , NULL, NULL," +
                                               "NULL, NULL, NULL, NULL, NULL     , NULL, NULL, NULL        , NULL, NULL, NULL, NULL, NULL        , '0', NULL, 'esuite', NULL, NULL    , NULL, 'PROD_0000', '2021-01', NULL, NULL, NULL, 202101, NULL, NULL, NULL," +
                                               "0 , 0, 0 , 0 )" +


                                               "INSERT dte_deta_acec(codi_empr,tipo_docu,foli_docu,corr_acec,codi_acec,mnsg_erro,peri_part) VALUES " +
                                               "( 1, '" + TipoDocu + "', '" + i + "', 0, '620200', '','" + Periodo + "')" +

                                               "INSERT dte_deta_prse(codi_emex,codi_empr,tipo_docu,foli_docu,nume_line,codi_impu,tipo_codi,codi_item,indi_exen,nomb_item,desc_item,cant_item,cant_refe," +
                                               "unid_refe,prec_refe,unid_medi,prec_item,prec_mono,codi_mone,fact_conv,dcto_item,reca_item,neto_item,desc_porc,reca_porc,fech_elab,fech_vepr,mnsg_erro,desc_mone," +
                                               "reca_mone,valo_mone,indi_agen,base_faen,marg_comer,prne_cofi,peri_part) VALUES " +
                                               " ('PROD_0000',1 ,'" + TipoDocu + "',  '" + i + "', 1, '', NULL, NULL, 0 , 'notebook','Asus',200,0, NULL, NULL, '',123000, NULL, NULL, NULL,0, NULL,24600000,0, NULL, NULL, NULL, '', NULL, NULL, NULL, NULL, NULL, NULL, NULL, '" + Periodo + "')" +

                                               "INSERT INTO dte_foli_clie(codi_empr,tipo_docu,foli_docu,foli_clie,esta_tras,peri_part) VALUES (1,'" + TipoDocu + "', '" + i + "','',0,'" + Periodo + "')" +



                                    definicion_dte_docu_refe + "(1 , '" + TipoDocu + "',  '" + i + "', 1 , '34', '1', NULL, NULL, '2021-01-29', '1', '1', 0 , NULL, NULL, 'PROD_0000', '" + Periodo + "')" +

                                    "INSERT [dbo].[dte_deta_codi] ([codi_emex], [codi_empr], [tipo_docu], [foli_docu], [nume_line], [corr_codi], [tipo_codi], [codi_item], [mnsg_erro], [peri_part]) VALUES " +
                                                 "('PROD_0000', 1, '" + TipoDocu + "',  '" + i + "', 1, 1, 'INT1', '001', '', '" + Periodo + "')";



                                    string[] Items = { a };

                                    int ItemsSS = GetRandomInt(0, Items.Length);

                                    Insert = Items[ItemsSS];

                                    String Query = Insert;
                                    // int Folioquery = Convert.ToInt32(Foliodesde);
                                    conexionCLOUD.EjecutarSql(Query, i);
                                    conexionCLOUD.CerraBD();
                                }

                                break;
                            case 61:
                                for (int i = Convert.ToInt32(Foliodesde); i <= Foliohasta; i++)
                                {
                                    ConexionBD conexionCLOUD = new ConexionBD(Ambiente);
                                    conexionCLOUD.abrirBD();
                                    String a = definicion_dte_enca_docu +
                                               "(1 , '" + TipoDocu + "', '" + i + "', 'ING', NULL, NULL, NULL, '" + fecha + "', NULL,   0 , 2   , NULL, NULL, NULL, NULL,   '', '" + fechaVenc + "' , " + RutEmpresa + ", NULL, NULL, '" + DigiEmpresa + "'," +
                                               " 'DBNET Ingenieria de Software', 'Las mejores frutas', NULL, NULL, 'Av siempre viva 335', ' HUECHURABA', 'SANTIAGO', NULL, NULL, NULL, 78079790 , '8', 'dbnet', '123', 'Botellas', '511551', 'dbnet', ' CERRILLOS'," +
                                               " 'SANTIAGO',              NULL, NULL, NULL, NULL, NULL, '', 0 , '', '', '', '', 16944781000 , 0         , 3219508390, NULL, 0   , NULL, 20164289390, 0 , 0 , NULL, NULL, NULL, 0 , '1.0',  '" + fecha + "T09:13:16'," +
                                               " NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, '', NULL, NULL, 'C:\\esuite\\out', '', '', '', '', '', '', '', '', '', '', 19, NULL, NULL, NULL, NULL, 'S', NULL, NULL, NULL, 0 , NULL, NULL, NULL, NULL, NULL," +
                                               " NULL, NULL, NULL, NULL, '', NULL, NULL, NULL, NULL, NULL, NULL, 0 , 0 , 0, 0 , '', NULL, NULL, NULL, NULL, '', '', 0   , NULL, 0   , NULL, NULL, NULL, 0, 0, 0, 0 , NULL, 0 , 0, NULL, ''   , NULL, ''    , NULL, NULL," +
                                               " NULL, NULL, NULL, NULL, NULL     , NULL, NULL, NULL        , NULL, NULL, NULL, NULL, NULL        , '0', NULL, 'esuite', NULL, NULL    , NULL, 'PROD_0000', '2021-01', NULL, NULL, NULL, 202101, NULL, NULL, NULL, " +
                                               " 0 , 0, 0 , 0 )" +



                                               "INSERT dte_deta_acec(codi_emex,codi_empr,tipo_docu,foli_docu,corr_acec,codi_acec,mnsg_erro,peri_part) VALUES " +
                                               "('PROD_0000', 1, '" + TipoDocu + "', '" + i + "', 0, '620200', '','" + Periodo + "')" +

                                               "INSERT dte_deta_prse(codi_emex,codi_empr,tipo_docu,foli_docu,nume_line,codi_impu,tipo_codi,codi_item,indi_exen,nomb_item,desc_item,cant_item,cant_refe," +
                                               "unid_refe,prec_refe,unid_medi,prec_item,prec_mono,codi_mone,fact_conv,dcto_item,reca_item,neto_item,desc_porc,reca_porc,fech_elab,fech_vepr,mnsg_erro,desc_mone," +
                                               "reca_mone,valo_mone,indi_agen,base_faen,marg_comer,prne_cofi,peri_part) VALUES " +
                                               " ('PROD_0000',1 ,'" + TipoDocu + "',  '" + i + "', 1, '', NULL, NULL, 0 ,'Poleras','Hilos',2500,0, NULL, NULL, '',3000, NULL, NULL, NULL,0, NULL,7500000, NULL, NULL, NULL,'', NULL, NULL, NULL,NULL, NULL, NULL, NULL, NULL, '" + Periodo + "')" +

                                               "INSERT INTO dte_foli_clie(codi_emex,codi_empr,tipo_docu,foli_docu,foli_clie,esta_tras,peri_part) VALUES ('" + Hold + "',1,'" + TipoDocu + "', '" + i + "','',0,'" + Periodo + "')" +
                                               definicion_dte_docu_refe + "(1 , '" + TipoDocu + "',  '" + i + "', 1 , '34', '1', NULL, NULL, '2021-01-29', '1', '1', 0 , NULL, NULL, 'PROD_0000', '" + Periodo + "')" +

                                    "INSERT [dbo].[dte_deta_codi] ([codi_emex], [codi_empr], [tipo_docu], [foli_docu], [nume_line], [corr_codi], [tipo_codi], [codi_item], [mnsg_erro], [peri_part]) VALUES " +
                                                 "('PROD_0000', 1, '" + TipoDocu + "',  '" + i + "', 1, 1, 'INT1', '001', '', '" + Periodo + "')";


                                    string[] Items = { a };

                                    int ItemsSS = GetRandomInt(0, Items.Length);

                                    Insert = Items[ItemsSS];

                                    String Query = Insert;
                                    // int Folioquery = Convert.ToInt32(Foliodesde);
                                    conexionCLOUD.EjecutarSql(Query, i);
                                    conexionCLOUD.CerraBD();
                                }
                                break;
                            case 110:
                                for (int i = Convert.ToInt32(Foliodesde); i <= Foliohasta; i++)
                                {
                                    ConexionBD conexionCLOUD = new ConexionBD(Ambiente);
                                    conexionCLOUD.abrirBD();
                                    String a = definicion_dte_enca_docu +
                                               "(1 , '" + TipoDocu + "', '" + i + "', 'ING', NULL, NULL, NULL, '" + fecha + "', NULL,   0 , 2   , NULL, NULL, NULL, NULL,   '', '" + fechaVenc + "' , " + RutEmpresa + ", NULL, NULL, '" + DigiEmpresa + "', " +
                                                "'DBNET Ingenieria de Software', 'Las mejores frutas', NULL, NULL, 'Av siempre viva 335', ' HUECHURABA', 'SANTIAGO', NULL, NULL, NULL, 55555555 , '5', 'dbnet', '123', 'Botellas', '511551', 'dbnet', ' CERRILLOS'," +
                                                " 'SANTIAGO',              NULL, NULL, NULL, NULL, NULL, '', 0 , '', '', '', '', 0           , 1197341500, 0         , NULL, NULL, NULL, 1197341500 , 0 , 0 , NULL, NULL, NULL, 0 , '1.0',  '" + fecha + "T09:15:37', " +
                                                " NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, '', NULL, NULL, 'C:\\esuite\\out', '', '', '', '', '', '', '', '', '', '', 0 , NULL, NULL, NULL, NULL, 'S', NULL, NULL, NULL, 0 , NULL, NULL, NULL, NULL, NULL, " +
                                                " NULL, NULL, NULL, NULL, '', NULL, NULL, NULL, NULL, NULL, NULL, 0 , 0 , 0, 0 , '', NULL, NULL, NULL, NULL, '', '', 992 , NULL, 931 , NULL, NULL, NULL, 0, 0, 0, 0 , NULL, 0 , 0, NULL, '243', NULL, 'PESO', NULL, NULL," +
                                                " NULL, NULL, NULL, NULL, 'PESO CL', 800 , NULL, 957873200000, NULL, NULL, NULL, NULL, 957873200000, '0', NULL, 'esuite', NULL, NULL    , NULL, 'PROD_0000', '2021-01', NULL, NULL, NULL, 202101, NULL, NULL, NULL," +
                                                " 0 , 0, 0 , 0 )" +


                                               "INSERT dte_deta_acec(codi_emex,codi_empr,tipo_docu,foli_docu,corr_acec,codi_acec,mnsg_erro,peri_part) VALUES " +
                                               "('PROD_0000', 1, '" + TipoDocu + "', '" + i + "', 0, '620200', '','" + Periodo + "')" +

                                               "INSERT dte_deta_prse(codi_emex,codi_empr,tipo_docu,foli_docu,nume_line,codi_impu,tipo_codi,codi_item,indi_exen,nomb_item,desc_item,cant_item,cant_refe," +
                                               "unid_refe,prec_refe,unid_medi,prec_item,prec_mono,codi_mone,fact_conv,dcto_item,reca_item,neto_item,desc_porc,reca_porc,fech_elab,fech_vepr,mnsg_erro,desc_mone," +
                                               "reca_mone,valo_mone,indi_agen,base_faen,marg_comer,prne_cofi,peri_part) VALUES " +

                                               "('PROD_0000',1 ,'" + TipoDocu + "',  '" + i + "', 1, '', NULL, NULL, 0, 'notebook','Teclas',7000,0, NULL, NULL, '',98600, NULL, NULL, NULL,0, NULL,690200000,0, NULL, NULL, NULL, '', NULL, NULL, NULL, NULL, NULL, NULL, NULL, '" + Periodo + "')" +

                                               "INSERT INTO dte_foli_clie(codi_emex,codi_empr,tipo_docu,foli_docu,foli_clie,esta_tras,peri_part) VALUES ('PROD_0000',1,'" + TipoDocu + "', '" + i + "','',0,'" + Periodo + "')" +


                                               definicion_dte_docu_refe + "(1 , '" + TipoDocu + "',  '" + i + "', 1 , '30', '1', NULL, NULL, '2021-01-29', '1', '1', 0 , NULL, NULL, 'PROD_0000', '" + Periodo + "')" +
                                    "INSERT [dbo].[dte_deta_codi] ([codi_emex], [codi_empr], [tipo_docu], [foli_docu], [nume_line], [corr_codi], [tipo_codi], [codi_item], [mnsg_erro], [peri_part]) VALUES " +
                                                 "('PROD_0000', 1, '" + TipoDocu + "',  '" + i + "', 1, 1, 'INT1', '001', '', '" + Periodo + "')";


                                    string[] Items = { a };

                                    int ItemsSS = GetRandomInt(0, Items.Length);

                                    Insert = Items[ItemsSS];

                                    String Query = Insert;
                                    // int Folioquery = Convert.ToInt32(Foliodesde);
                                    conexionCLOUD.EjecutarSql(Query, i);
                                    conexionCLOUD.CerraBD();
                                }

                                break;
                            case 111:
                                for (int i = Convert.ToInt32(Foliodesde); i <= Foliohasta; i++)
                                {
                                    ConexionBD conexionCLOUD = new ConexionBD(Ambiente);
                                    conexionCLOUD.abrirBD();
                                    String a = definicion_dte_enca_docu +
                                               "(1 , '" + TipoDocu + "', '" + i + "', 'ING', NULL, NULL, NULL, '" + fecha + "', NULL,   0 , 2   , NULL, NULL, NULL, NULL,   '', '" + fechaVenc + "' , " + RutEmpresa + ", NULL, NULL, '" + DigiEmpresa + "', " +
                                               "'DBNET Ingenieria de Software', 'Las mejores frutas', NULL, NULL, 'Av siempre viva 335', ' HUECHURABA', 'SANTIAGO', NULL, NULL, NULL, 55555555 , '5', 'dbnet', '123', 'Botellas', '511551', 'dbnet', ' CERRILLOS'," +
                                               " 'SANTIAGO',              NULL, NULL, NULL, NULL, NULL, '', 0 , '', '', '', '', 0           , 4566600   , 0         , NULL, NULL, NULL, 4566600    , 0 , 0 , NULL, NULL, NULL, 0 , '1.0', '" + fecha + "T09:16:51'," +
                                               " NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, '', NULL, NULL, 'C:\\esuite\\out', '', '', '', '', '', '', '', '', '', '', 19, NULL, NULL, NULL, NULL, 'S', NULL, NULL, NULL, 0 , NULL, NULL, NULL, NULL, NULL," +
                                               " NULL, NULL, NULL, NULL, '', NULL, NULL, NULL, NULL, NULL, NULL, 0 , 0 , 0, 0 , '', NULL, NULL, NULL, NULL, '', '', 992 , NULL, 903 , NULL, NULL, NULL, 0, 0, 0, 0 , NULL, 0 , 0, NULL, '406', NULL, 'PESO', NULL, NULL," +
                                               " NULL, NULL, NULL, NULL, 'PESO CL', 700 , NULL, 3196620000  , NULL, NULL, NULL, NULL, 3196620000  , '0', NULL, 'esuite', NULL, NULL    , NULL, 'PROD_0000', '2021-01', NULL, NULL, NULL, 202101, NULL, NULL, NULL," +
                                               " 0 , 0, 0 , 0 )" +

                                               "INSERT dte_deta_acec(codi_emex,codi_empr,tipo_docu,foli_docu,corr_acec,codi_acec,mnsg_erro,peri_part) VALUES " +
                                               "('PROD_0000', 1, '" + TipoDocu + "', '" + i + "', 0, '620200', '','" + Periodo + "')" +

                                               "INSERT dte_deta_prse(codi_emex,codi_empr,tipo_docu,foli_docu,nume_line,codi_impu,tipo_codi,codi_item,indi_exen,nomb_item,desc_item,cant_item,cant_refe," +
                                               "unid_refe,prec_refe,unid_medi,prec_item,prec_mono,codi_mone,fact_conv,dcto_item,reca_item,neto_item,desc_porc,reca_porc,fech_elab,fech_vepr,mnsg_erro,desc_mone," +
                                               "reca_mone,valo_mone,indi_agen,base_faen,marg_comer,prne_cofi,peri_part) VALUES " +

                                               "('PROD_0000',1,'" + TipoDocu + "',  '" + i + "', 1, '', NULL, NULL, 0,'Pan','Amasado',500,0, NULL, NULL,'', 30000, NULL, NULL, NULL, 0, NULL,15000000,0, NULL, NULL, NULL,'', NULL, NULL, NULL, NULL, NULL, NULL, NULL, '" + Periodo + "')" +

                                               "INSERT INTO dte_foli_clie(codi_emex,codi_empr,tipo_docu,foli_docu,foli_clie,esta_tras,peri_part) VALUES ('PROD_0000',1,'" + TipoDocu + "', '" + i + "','',0,'" + Periodo + "')" +

                                               definicion_dte_docu_refe + "(1 , '" + TipoDocu + "',  '" + i + "', 1 , '30', '1', NULL, NULL, '2021-01-29', '1', '1', 0 , NULL, NULL, 'PROD_0000', '" + Periodo + "')" +


                                                "INSERT [dbo].[dte_deta_codi] ([codi_emex], [codi_empr], [tipo_docu], [foli_docu], [nume_line], [corr_codi], [tipo_codi], [codi_item], [mnsg_erro], [peri_part]) VALUES " +
                                                 "('PROD_0000', 1, '" + TipoDocu + "',  '" + i + "', 1, 1, 'INT1', '001', '', '" + Periodo + "')";


                                    string[] Items = { a };

                                    int ItemsSS = GetRandomInt(0, Items.Length);

                                    Insert = Items[ItemsSS];

                                    String Query = Insert;
                                    // int Folioquery = Convert.ToInt32(Foliodesde);
                                    conexionCLOUD.EjecutarSql(Query, i);
                                    conexionCLOUD.CerraBD();
                                }
                                break;
                            case 112:
                                for (int i = Convert.ToInt32(Foliodesde); i <= Foliohasta; i++)
                                {
                                    ConexionBD conexionCLOUD = new ConexionBD(Ambiente);
                                    conexionCLOUD.abrirBD();
                                    String a = definicion_dte_enca_docu +
                                               "(1 , '" + TipoDocu + "', '" + i + "', 'ING', NULL, NULL, NULL, '" + fecha + "', NULL,   0 , 2   , NULL, NULL, NULL, NULL,   '', '" + fechaVenc + "' , " + RutEmpresa + ", NULL, NULL, '" + DigiEmpresa + "', " +
                                               "'DBNET Ingenieria de Software', 'Las mejores frutas', NULL, NULL, 'Av siempre viva 335', ' HUECHURABA', 'SANTIAGO', NULL, NULL, NULL, 55555555 , '5', 'dbnet', '123', 'Botellas', '511551', 'dbnet', " +
                                               "' CERRILLOS', 'SANTIAGO',              NULL, NULL, NULL, NULL, NULL, '', 0 , '', '', '', '', 0           , 51200     , 0         , NULL, NULL, NULL, 51200      , 0 , 0 , NULL, NULL, NULL, 0 , '1.0', " +
                                               " '" + fecha + "T09:18:06', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, '', NULL, NULL, 'C:\\esuite\\out', '', '', '', '', '', '', '', '', '', '', 19, NULL, NULL, NULL, NULL, 'S', NULL, NULL, NULL," +
                                               " 0 , NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, '', NULL, NULL, NULL, NULL, NULL, NULL, 0 , 0 , 0, 0 , '', NULL, NULL, NULL, NULL, '', '', 992 , NULL, 601 , NULL, NULL, NULL, 0, 0, 0, 0 , NULL, 0 " +
                                               " , 0, NULL, '540', NULL, 'PESO', NULL, NULL, NULL, NULL, NULL, NULL, 'PESO CL', 800 , NULL, 40960000    , NULL, NULL, NULL, NULL, 40960000    , '0', NULL, 'esuite', NULL, NULL    , NULL, 'PROD_0000', '2021-01'," +
                                               " NULL, NULL, NULL, 202101, NULL, NULL, NULL, 0 , 0, 0 , 0 )" +




                                               "INSERT dte_deta_acec(codi_emex,codi_empr,tipo_docu,foli_docu,corr_acec,codi_acec,mnsg_erro,peri_part) VALUES " +
                                               "('PROD_0000', 1, '" + TipoDocu + "', '" + i + "', 0, '620200', '','" + Periodo + "')" +

                                               "INSERT dte_deta_prse(codi_emex,codi_empr,tipo_docu,foli_docu,nume_line,codi_impu,tipo_codi,codi_item,indi_exen,nomb_item,desc_item,cant_item,cant_refe," +
                                               "unid_refe,prec_refe,unid_medi,prec_item,prec_mono,codi_mone,fact_conv,dcto_item,reca_item,neto_item,desc_porc,reca_porc,fech_elab,fech_vepr,mnsg_erro,desc_mone," +
                                               "reca_mone,valo_mone,indi_agen,base_faen,marg_comer,prne_cofi,peri_part) VALUES " +

                                               "('PROD_0000',1,'" + TipoDocu + "',  '" + i + "', 1,'' , NULL, NULL, 0,'Flan','Manjar',300,0, NULL, NULL,'',48966, NULL, NULL, NULL,0, NULL,14689800,0, NULL, NULL, NULL,'', NULL, NULL, NULL, NULL, NULL, NULL, NULL,'" + Periodo + "')" +


                                               "INSERT INTO dte_foli_clie(codi_emex,codi_empr,tipo_docu,foli_docu,foli_clie,esta_tras,peri_part) VALUES ('PROD_0000',1,'" + TipoDocu + "', '" + i + "','',0,'" + Periodo + "')" +

                                              definicion_dte_docu_refe + "(1 , '" + TipoDocu + "',  '" + i + "', 1 , '30', '1', NULL, NULL, '2021-01-29', '1', '1', 0 , NULL, NULL, 'PROD_0000', '" + Periodo + "')" +


                                                "INSERT [dbo].[dte_deta_codi] ([codi_emex], [codi_empr], [tipo_docu], [foli_docu], [nume_line], [corr_codi], [tipo_codi], [codi_item], [mnsg_erro], [peri_part]) VALUES " +
                                                 "('PROD_0000', 1, '" + TipoDocu + "',  '" + i + "', 1, 1, 'INT1', '001', '', '" + Periodo + "')";


                                    string[] Items = { a };

                                    int ItemsSS = GetRandomInt(0, Items.Length);

                                    Insert = Items[ItemsSS];

                                    String Query = Insert;
                                    // int Folioquery = Convert.ToInt32(Foliodesde);
                                    conexionCLOUD.EjecutarSql(Query, i);
                                    conexionCLOUD.CerraBD();
                                }
                                break;
                        }
                        break;
                    #endregion


                    #region Oracle
                    case "ORACLE":
                        Definiciones defora = new Definiciones();

                        definicion_dte_enca_docu = defora.Dte_enca_docu_oracle();
                        definicion_dte_docu_refe = defora.dte_docu_refe_oracle();
                        validarCampos();

                        switch (TipoDocu)
                        {

                            case 33:

                                for (int i = Convert.ToInt32(Foliodesde); i <= Foliohasta; i++)
                                {

                                    ConexionBD conexionOR = new ConexionBD(Ambiente);
                                    conexionOR.ConexionOracle();

                                    String a = definicion_dte_enca_docu + "(1 , '" + TipoDocu + "', '" + i + "', 'ING', NULL, NULL, NULL, '" + fecha + "', NULL,   0 , 2   , NULL, NULL, NULL, NULL,   '', '" + fechaVenc + "' , " + RutEmpresa + ", NULL, NULL, '" + DigiEmpresa + "', " +
                                       "'DBNET Ingenieria de Software', 'Las mejores frutas', NULL, NULL, 'Av siempre viva 335', ' HUECHURABA', 'SANTIAGO', NULL, NULL, NULL, 55555555 , '5', 'dbnet', '123', 'Botellas', '511551', 'dbnet', " +
                                       "' CERRILLOS', 'SANTIAGO',              NULL, NULL, NULL, NULL, NULL, '', 0 , '', '', '', '', 0           , 51200     , 0         , NULL, NULL, NULL, 51200      , 0 , 0 , NULL, NULL, NULL, 0 , '1.0', " +
                                       " '" + fecha + "T09:18:06', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, '', NULL, NULL, 'C:\\esuite\\out', '', '', '', '', '', '', '', '', '', '', 19, NULL, NULL, NULL, NULL, 'S', NULL, NULL, NULL," +
                                       " 0 , NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, '', NULL, NULL, NULL, NULL, NULL, NULL, 0 , 0 , 0, 0 , '', NULL, NULL, NULL, NULL, '', '', 992 , NULL, 601 , NULL, NULL, NULL, 0, 0, 0, 0 , NULL, 0 " +
                                       " , 0, NULL, '540', NULL, 'PESO', NULL, NULL, NULL, NULL, NULL, NULL, 'PESO CL', 800 , NULL, 40960000    , NULL, NULL, NULL, NULL, 40960000    , '0', NULL, 'esuite', NULL, NULL    , NULL, 'PROD_0000', '2021-01'," +
                                       " NULL, NULL, NULL, 202101, NULL, NULL, NULL, 0 , 0, 0 , 0 )¿" +

                                       "INSERT into dte_deta_acec(codi_emex,codi_empr,tipo_docu,foli_docu,corr_acec,codi_acec,mnsg_erro,peri_part) VALUES " +
                                       "('PROD_0000', 1, '" + TipoDocu + "', '" + i + "', 0, '620200', '','" + Periodo + "')¿" +

                                        "INSERT into dte_deta_prse(codi_emex,codi_empr,tipo_docu,foli_docu,nume_line,codi_impu,tipo_codi,codi_item,indi_exen,nomb_item,desc_item,cant_item,cant_refe," +
                                       "unid_refe,prec_refe,unid_medi,prec_item,prec_mono,codi_mone,fact_conv,dcto_item,reca_item,neto_item,desc_porc,reca_porc,fech_elab,fech_vepr,mnsg_erro,desc_mone," +
                                       "reca_mone,valo_mone,indi_agen,base_faen,marg_comer,prne_cofi,peri_part) VALUES " +
                                       "('PROD_0000',1,'" + TipoDocu + "',  '" + i + "', 1,'' , NULL, NULL, 0,'Flan','Manjar',300,0, NULL, NULL,'',48966, NULL, NULL, NULL,0, NULL,14689800,0, NULL, NULL, NULL,'', NULL, NULL, NULL, NULL, NULL, NULL, NULL,'" + Periodo + "')¿" +


                                       "INSERT INTO dte_foli_clie(codi_emex,codi_empr,tipo_docu,foli_docu,foli_clie,esta_tras,peri_part) VALUES ('PROD_0000',1,'" + TipoDocu + "', '" + i + "','A',0,'" + Periodo + "')¿" +

                                      definicion_dte_docu_refe + "(1 , '" + TipoDocu + "',  '" + i + "', 1 , '30', '1', NULL, NULL, '2021-01-29', '1', '1', 0 , NULL, NULL, 'PROD_0000', '" + Periodo + "')¿" +


                                        "INSERT into dte_deta_codi (codi_emex, codi_empr, tipo_docu, foli_docu, nume_line, corr_codi, tipo_codi, codi_item, mnsg_erro, peri_part) VALUES " +
                                         "('PROD_0000', 1, '" + TipoDocu + "',  '" + i + "', 1, 1, 'INT1', '001', '', '" + Periodo + "')¿";



                                    string[] Items = { a };

                                    int ItemsSS = GetRandomInt(0, Items.Length);

                                    Insert = Items[ItemsSS];

                                    char[] Separador = { '¿' };
                                    string[] words = Insert.Split(Separador);

                                    String Primero = "";
                                    String Segundo = "";
                                    String Tercero = "";
                                    String cuarto = "";
                                    String quinto = "";
                                    String sexto = "";
                                    GuardaQueryOracle = new string[10];
                                    int x = 0;
                                    foreach (var word in words)
                                    {

                                        GuardaQueryOracle[x] = word;
                                        x++;
                                    }

                                    Primero = GuardaQueryOracle[0];
                                    Segundo = GuardaQueryOracle[1];
                                    Tercero = GuardaQueryOracle[2];
                                    cuarto = GuardaQueryOracle[3];
                                    quinto = GuardaQueryOracle[4];
                                    sexto = GuardaQueryOracle[5];
                                    //MessageBox.Show(Primero + Segundo + Tercero);

                                    String Query1 = Primero;
                                    conexionOR.EjecutaQueryOracle(Query1);
                                    String Query2 = Segundo;
                                    conexionOR.EjecutaQueryOracle(Query2);
                                    String Query3 = Tercero;
                                    conexionOR.EjecutaQueryOracle(Query3);
                                    String Query4 = cuarto;
                                    conexionOR.EjecutaQueryOracle(Query4);
                                    String Query5 = quinto;
                                    conexionOR.EjecutaQueryOracle(Query5);
                                    String Query6 = sexto;
                                    conexionOR.EjecutaQueryOracle(Query6);



                                }

                                break;
                            case 34:
                                for (int i = Convert.ToInt32(Foliodesde); i <= Foliohasta; i++)
                                {

                                    ConexionBD conexionOR = new ConexionBD(Ambiente);
                                    conexionOR.ConexionOracle();

                                    String a = definicion_dte_enca_docu + "(1 , '" + TipoDocu + "', '" + i + "', 'ING', NULL, NULL, NULL, '" + fecha + "', NULL,   0 , 2   , NULL, NULL, NULL, NULL,   '', '" + fechaVenc + "' , " + RutEmpresa + ", NULL, NULL, '" + DigiEmpresa + "', " +
                                                "'DBNET Ingenieria de Software', 'Las mejores frutas', NULL, NULL, 'Av siempre viva 335', ' HUECHURABA', 'SANTIAGO', NULL, NULL, NULL, 78079790 , '8', 'dbnet', '123', 'Botellas', '511551', 'dbnet', ' CERRILLOS'," +
                                                " 'SANTIAGO',              NULL, NULL, NULL, NULL, NULL, '', 0 , '', '', '', '', 0           , 6250000   , 0         , NULL, NULL, NULL, 6250000    , 0 , 0 , NULL, NULL, NULL, 0 , '1.0',  '" + fecha + "T09:06:12'," +
                                                " NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, '', NULL, NULL, 'C:\\esuite\\out', '', '', '', '', '', '', '', '', '', '', 0 , NULL, NULL, NULL, NULL, 'S', NULL, NULL, NULL, 0 , NULL, NULL, NULL, NULL, NULL, " +
                                                " NULL, NULL, NULL, NULL, '', NULL, NULL, NULL, NULL, NULL, NULL, 0 , 0 , 0, 0 , '', NULL, NULL, NULL, NULL, '', '', 0   , NULL, 0   , NULL, NULL, NULL, 0, 0, 0, 0 , NULL, 0 , 0, NULL, ''   , NULL, ''    , NULL, NULL," +
                                                " NULL, NULL, NULL, NULL, NULL     , NULL, NULL, NULL        , NULL, NULL, NULL, NULL, NULL        , '0', NULL, 'esuite', NULL, NULL    , NULL, 'PROD_0000', '2021-01', NULL, NULL, NULL, 202101, NULL, NULL, NULL, 0 ," +
                                                " 0, 0 , 0 )¿" +


                                       "INSERT into  dte_deta_acec(codi_empr,tipo_docu,foli_docu,corr_acec,codi_acec,mnsg_erro,peri_part) VALUES " +
                                               "( 1, '" + TipoDocu + "', '" + i + "', 0, '620200', '','" + Periodo + "')¿" +

                                       "INSERT into dte_deta_prse(codi_emex,codi_empr,tipo_docu,foli_docu,nume_line,codi_impu,tipo_codi,codi_item,indi_exen,nomb_item,desc_item,cant_item,cant_refe," +
                                        "unid_refe,prec_refe,unid_medi,prec_item,prec_mono,codi_mone,fact_conv,dcto_item,reca_item,neto_item,desc_porc,reca_porc,fech_elab,fech_vepr,mnsg_erro,desc_mone," +
                                        "reca_mone,valo_mone,indi_agen,base_faen,marg_comer,prne_cofi,peri_part) VALUES " +
                                        " ('PROD_0000', 1, '" + TipoDocu + "',  '" + i + "', 1, '', NULL, NULL, 0, 'Gorra', 'Nike', 500,0 , NULL, NULL, '', 50000, NULL, NULL, NULL, 0 , NULL, 25000000, 0, NULL, NULL, NULL, '', NULL, NULL, NULL, NULL, NULL, NULL, NULL,'" + Periodo + "')¿" +


                                       "INSERT INTO dte_foli_clie(codi_empr,tipo_docu,foli_docu,foli_clie,esta_tras,peri_part) VALUES (1,'" + TipoDocu + "', '" + i + "','M',0,'" + Periodo + "')¿" +

                                       definicion_dte_docu_refe + "(1 , '" + TipoDocu + "',  '" + i + "', 1 , '30', '1', NULL, NULL, '2021-01-29', '1', '1', 0 , NULL, NULL, 'PROD_0000', '" + Periodo + "')¿" +


                                        "INSERT into dte_deta_codi (codi_emex, codi_empr, tipo_docu, foli_docu, nume_line, corr_codi, tipo_codi, codi_item, mnsg_erro, peri_part) VALUES " +
                                         "('PROD_0000', 1, '" + TipoDocu + "',  '" + i + "', 1, 1, 'INT1', '001', '', '" + Periodo + "')¿";









                                    string[] Items = { a };

                                    int ItemsSS = GetRandomInt(0, Items.Length);

                                    Insert = Items[ItemsSS];

                                    char[] Separador = { '¿' };
                                    string[] words = Insert.Split(Separador);

                                    String Primero = "";
                                    String Segundo = "";
                                    String Tercero = "";
                                    String cuarto = "";
                                    String quinto = "";
                                    String sexto = "";
                                    GuardaQueryOracle = new string[10];
                                    int x = 0;
                                    foreach (var word in words)
                                    {

                                        GuardaQueryOracle[x] = word;
                                        x++;
                                    }

                                    Primero = GuardaQueryOracle[0];
                                    Segundo = GuardaQueryOracle[1];
                                    Tercero = GuardaQueryOracle[2];
                                    cuarto = GuardaQueryOracle[3];
                                    quinto = GuardaQueryOracle[4];
                                    sexto = GuardaQueryOracle[5];
                                    //MessageBox.Show(Primero + Segundo + Tercero);

                                    String Query1 = Primero;
                                    conexionOR.EjecutaQueryOracle(Query1);
                                    String Query2 = Segundo;
                                    conexionOR.EjecutaQueryOracle(Query2);
                                    String Query3 = Tercero;
                                    conexionOR.EjecutaQueryOracle(Query3);
                                    String Query4 = cuarto;
                                    conexionOR.EjecutaQueryOracle(Query4);
                                    String Query5 = quinto;
                                    conexionOR.EjecutaQueryOracle(Query5);
                                    String Query6 = sexto;
                                    conexionOR.EjecutaQueryOracle(Query6);



                                }
                                break;
                            case 43:
                                for (int i = Convert.ToInt32(Foliodesde); i <= Foliohasta; i++)
                                {

                                    ConexionBD conexionOR = new ConexionBD(Ambiente);
                                    conexionOR.ConexionOracle();

                                    String a = definicion_dte_enca_docu + "(1 , '" + TipoDocu + "', '" + i + "', 'ING', NULL, NULL, NULL, '" + fecha + "', NULL,   0 , 2   , NULL, NULL, NULL, NULL,   '', '" + fechaVenc + "' , " + RutEmpresa + ", NULL, NULL, '" + DigiEmpresa + "'," +
                                                " 'DBNET Ingenieria de Software', 'Las mejores frutas', NULL, NULL, 'Av siempre viva 335', ' HUECHURABA', 'SANTIAGO', NULL, NULL, NULL, 78079790 , '8', 'dbnet', '123', 'Botellas', '511551', 'dbnet', ' CERRILLOS'," +
                                                " 'SANTIAGO',              NULL, NULL, NULL, NULL, NULL, '', 0 , '', '', '', '', 2025000     , 0         , 384750    , NULL, NULL, NULL, 2409750    , 0 , 0 , NULL, NULL, NULL, 0 , '1.0',  '" + fecha + "T09:07:20'," +
                                                " NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, '', NULL, NULL, 'C:\\esuite\\out', '', '', '', '', '', '', '', '', '', '', 19, NULL, NULL, NULL, NULL, 'S', NULL, NULL, NULL, 0 , NULL, NULL, NULL, NULL, NULL," +
                                                " NULL, NULL, NULL, NULL, '', NULL, NULL, NULL, NULL, NULL, NULL, 0 , 0 , 0, 0 , '', NULL, NULL, NULL, NULL, '', '', 0   , NULL, 0   , NULL, NULL, NULL, 0, 0, 0, 0 , NULL, 0 , 0, NULL, ''   , NULL, ''    , NULL, NULL," +
                                                " NULL, NULL, NULL, NULL, NULL     , NULL, NULL, NULL        , NULL, NULL, NULL, NULL, NULL        , '0', NULL, 'esuite', 0   , 0       , 0   , 'PROD_0000', '2021-01', NULL, NULL, NULL, 202101, NULL, NULL, NULL," +
                                                " 0 , 0, 0 , 0 )¿" +


                                               "INSERT into dte_deta_acec(codi_empr,tipo_docu,foli_docu,corr_acec,codi_acec,mnsg_erro,peri_part) VALUES " +
                                               "( 1, '" + TipoDocu + "', '" + i + "', 0, '620200', '','" + Periodo + "')¿" +

                                               "INSERT into dte_deta_prse(codi_emex,codi_empr,tipo_docu,foli_docu,nume_line,codi_impu,tipo_codi,codi_item,indi_exen,nomb_item,desc_item,cant_item,cant_refe," +
                                               "unid_refe,prec_refe,unid_medi,prec_item,prec_mono,codi_mone,fact_conv,dcto_item,reca_item,neto_item,desc_porc,reca_porc,fech_elab,fech_vepr,mnsg_erro,desc_mone," +
                                               "reca_mone,valo_mone,indi_agen,base_faen,marg_comer,prne_cofi,peri_part) VALUES " +
                                               " ('PROD_0000', 1, '" + TipoDocu + "',  '" + i + "', 1, '', NULL, NULL, 0, 'Gorra', 'Nike', 500,0 , NULL, NULL, '', 50000, NULL, NULL, NULL, 0 , NULL, 25000000, 0, NULL, NULL, NULL, '', NULL, NULL, NULL, NULL, NULL, NULL, NULL,'" + Periodo + "')¿" +

                                               "INSERT INTO dte_foli_clie(codi_empr,tipo_docu,foli_docu,foli_clie,esta_tras,peri_part) VALUES (1,'" + TipoDocu + "', '" + i + "','A',0,'" + Periodo + "')¿" +

                                            definicion_dte_docu_refe + "(1 , '" + TipoDocu + "',  '" + i + "', 1 , '30', '1', NULL, NULL, '2021-01-29', '1', '1', 0 , NULL, NULL, 'PROD_0000', '" + Periodo + "')¿" +


                                            "INSERT into dte_deta_codi (codi_emex, codi_empr, tipo_docu, foli_docu, nume_line, corr_codi, tipo_codi, codi_item, mnsg_erro, peri_part) VALUES " +
                                            "('PROD_0000', 1, '" + TipoDocu + "',  '" + i + "', 1, 1, 'INT1', '001', '', '" + Periodo + "')¿";



                                    string[] Items = { a };

                                    int ItemsSS = GetRandomInt(0, Items.Length);

                                    Insert = Items[ItemsSS];

                                    char[] Separador = { '¿' };
                                    string[] words = Insert.Split(Separador);

                                    String Primero = "";
                                    String Segundo = "";
                                    String Tercero = "";
                                    String cuarto = "";
                                    String quinto = "";
                                    String sexto = "";
                                    GuardaQueryOracle = new string[10];
                                    int x = 0;
                                    foreach (var word in words)
                                    {

                                        GuardaQueryOracle[x] = word;
                                        x++;
                                    }

                                    Primero = GuardaQueryOracle[0];
                                    Segundo = GuardaQueryOracle[1];
                                    Tercero = GuardaQueryOracle[2];
                                    cuarto = GuardaQueryOracle[3];
                                    quinto = GuardaQueryOracle[4];
                                    sexto = GuardaQueryOracle[5];
                                    //MessageBox.Show(Primero + Segundo + Tercero);

                                    String Query1 = Primero;
                                    conexionOR.EjecutaQueryOracle(Query1);
                                    String Query2 = Segundo;
                                    conexionOR.EjecutaQueryOracle(Query2);
                                    String Query3 = Tercero;
                                    conexionOR.EjecutaQueryOracle(Query3);
                                    String Query4 = cuarto;
                                    conexionOR.EjecutaQueryOracle(Query4);
                                    String Query5 = quinto;
                                    conexionOR.EjecutaQueryOracle(Query5);
                                    String Query6 = sexto;
                                    conexionOR.EjecutaQueryOracle(Query6);



                                }
                                break;
                            case 46:
                                for (int i = Convert.ToInt32(Foliodesde); i <= Foliohasta; i++)
                                {

                                    ConexionBD conexionOR = new ConexionBD(Ambiente);
                                    conexionOR.ConexionOracle();

                                    String a = definicion_dte_enca_docu + "(1 , '" + TipoDocu + "', '" + i + "', 'ING', NULL, NULL, NULL, '" + fecha + "', NULL,   0 , 2   , NULL, NULL, NULL, NULL,   '', '" + fechaVenc + "' , " + RutEmpresa + ", NULL, NULL, '" + DigiEmpresa + "'," +
                                               "'DBNET Ingenieria de Software', 'Las mejores frutas', NULL, NULL, 'Av siempre viva 335', ' HUECHURABA', 'SANTIAGO', NULL, NULL, NULL, 78079790 , '8', 'dbnet', '123', 'Botellas', '511551', 'dbnet', ' CERRILLOS'," +
                                               "'SANTIAGO',              NULL, NULL, NULL, NULL, NULL, '', 0 , '', '', '', '', 247500000   , 0         , 47025000  , NULL, NULL, NULL, 294525000  , 0 , 0 , NULL, NULL, NULL, 0 , '1.0',  '" + fecha + "T09:08:02', " +
                                               "NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, '', NULL, NULL, 'C:\\esuite\\out', '', '', '', '', '', '', '', '', '', '', 19, NULL, NULL, NULL, NULL, 'S', NULL, NULL, NULL, 0 , NULL, NULL, NULL, NULL, NULL, " +
                                               "NULL, NULL, NULL, NULL, '', NULL, NULL, NULL, NULL, NULL, NULL, 0 , 0 , 0, 0 , '', NULL, NULL, NULL, NULL, '', '', 0   , NULL, 0   , NULL, NULL, NULL, 0, 0, 0, 0 , NULL, 0 , 0, NULL, ''   , NULL, ''    , NULL, NULL," +
                                               "NULL, NULL, NULL, NULL, NULL     , NULL, NULL, NULL        , NULL, NULL, NULL, NULL, NULL        , '0', NULL, 'esuite', NULL, NULL    , NULL, 'PROD_0000', '2021-01', NULL, NULL, NULL, 202101, NULL, NULL, NULL," +
                                               "0 , 0, 0 , 0 )¿" +


                                               "INSERT into dte_deta_acec(codi_empr,tipo_docu,foli_docu,corr_acec,codi_acec,mnsg_erro,peri_part) VALUES " +
                                               "( 1, '" + TipoDocu + "', '" + i + "', 0, '620200', '','" + Periodo + "')¿" +

                                               "INSERT into dte_deta_prse(codi_emex,codi_empr,tipo_docu,foli_docu,nume_line,codi_impu,tipo_codi,codi_item,indi_exen,nomb_item,desc_item,cant_item,cant_refe," +
                                               "unid_refe,prec_refe,unid_medi,prec_item,prec_mono,codi_mone,fact_conv,dcto_item,reca_item,neto_item,desc_porc,reca_porc,fech_elab,fech_vepr,mnsg_erro,desc_mone," +
                                               "reca_mone,valo_mone,indi_agen,base_faen,marg_comer,prne_cofi,peri_part) VALUES " +
                                               " ('PROD_0000',1 ,'" + TipoDocu + "',  '" + i + "', 1, '', NULL, NULL, 0 , 'Choco', 'lates', 6000, 0 , NULL, NULL, '', 2500, NULL, NULL, NULL, 0 , NULL,15000000, 0, NULL, NULL, NULL, '', NULL, NULL, NULL, NULL, NULL, NULL, NULL, '" + Periodo + "')¿" +

                                               "INSERT INTO dte_foli_clie(codi_empr,tipo_docu,foli_docu,foli_clie,esta_tras,peri_part) VALUES (1,'" + TipoDocu + "', '" + i + "','R',0,'" + Periodo + "')¿" +

                                    definicion_dte_docu_refe + "(1 , '" + TipoDocu + "',  '" + i + "', 1 , '30', '1', NULL, NULL, '2021-01-29', '1', '1', 0 , NULL, NULL, 'PROD_0000', '" + Periodo + "')¿" +


                                        "INSERT into dte_deta_codi (codi_emex, codi_empr, tipo_docu, foli_docu, nume_line, corr_codi, tipo_codi, codi_item, mnsg_erro, peri_part) VALUES " +
                                         "('PROD_0000', 1, '" + TipoDocu + "',  '" + i + "', 1, 1, 'INT1', '001', '', '" + Periodo + "')¿";



                                    string[] Items = { a };

                                    int ItemsSS = GetRandomInt(0, Items.Length);

                                    Insert = Items[ItemsSS];

                                    char[] Separador = { '¿' };
                                    string[] words = Insert.Split(Separador);

                                    String Primero = "";
                                    String Segundo = "";
                                    String Tercero = "";
                                    String cuarto = "";
                                    String quinto = "";
                                    String sexto = "";
                                    GuardaQueryOracle = new string[10];
                                    int x = 0;
                                    foreach (var word in words)
                                    {

                                        GuardaQueryOracle[x] = word;
                                        x++;
                                    }

                                    Primero = GuardaQueryOracle[0];
                                    Segundo = GuardaQueryOracle[1];
                                    Tercero = GuardaQueryOracle[2];
                                    cuarto = GuardaQueryOracle[3];
                                    quinto = GuardaQueryOracle[4];
                                    sexto = GuardaQueryOracle[5];
                                    //MessageBox.Show(Primero + Segundo + Tercero);

                                    String Query1 = Primero;
                                    conexionOR.EjecutaQueryOracle(Query1);
                                    String Query2 = Segundo;
                                    conexionOR.EjecutaQueryOracle(Query2);
                                    String Query3 = Tercero;
                                    conexionOR.EjecutaQueryOracle(Query3);
                                    String Query4 = cuarto;
                                    conexionOR.EjecutaQueryOracle(Query4);
                                    String Query5 = quinto;
                                    conexionOR.EjecutaQueryOracle(Query5);
                                    String Query6 = sexto;
                                    conexionOR.EjecutaQueryOracle(Query6);



                                }
                                break;
                            case 52:
                                for (int i = Convert.ToInt32(Foliodesde); i <= Foliohasta; i++)
                                {

                                    ConexionBD conexionOR = new ConexionBD(Ambiente);
                                    conexionOR.ConexionOracle();

                                    String a = definicion_dte_enca_docu + "(1 , '" + TipoDocu + "', '" + i + "', 'ING', NULL, NULL, NULL, '" + fecha + "', NULL,   0 , 2   , NULL, NULL, NULL, NULL,   '', '" + fechaVenc + "' , " + RutEmpresa + ", NULL, NULL, '" + DigiEmpresa + "', " +
                                                "'DBNET Ingenieria de Software', 'Las mejores frutas', NULL, NULL, 'Av siempre viva 335', ' HUECHURABA', 'SANTIAGO', NULL, NULL, NULL, 55555555 , '5', 'Empresa Internacional', '852', 'Frutillas', '', 'Tokyo', " +
                                                "' CERRO NAVIA', 'SANTIAGO', NULL, NULL, NULL, NULL, NULL, '', 0 , '', '', '', '', 7700000     , 0         , 1463000   , NULL, NULL, NULL, 9163000    , 0 , 0 , NULL, NULL, NULL, 0 , '1.0', '" + fecha + "T09:11:20'," +
                                                " NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, '', NULL, NULL, 'C:\\esuite\\out', '', '', '', '', '', '', '', '', '', '', 19, NULL, NULL, NULL, NULL, 'S', NULL, NULL, NULL, 0 , NULL, NULL, NULL, NULL, NULL, " +
                                                " NULL, NULL, NULL, NULL, '', NULL, NULL, NULL, NULL, NULL, NULL, 0 , 0 , 0, 0 , '', NULL, NULL, NULL, NULL, '', '', 0   , NULL, 0   , NULL, NULL, NULL, 0, 0, 0, 0 , NULL, 0 , 0, NULL, ''   , NULL, ''    , NULL, NULL," +
                                                " NULL, NULL, NULL, NULL, NULL     , NULL, NULL, NULL        , NULL, NULL, NULL, NULL, NULL        , '0', NULL, 'esuite', NULL, NULL    , NULL, 'PROD_0000', '2021-01', NULL, NULL, NULL, 202101, NULL, NULL, NULL," +
                                                " 0 , 0, 0 , 0 )¿" +


                                               "INSERT into  dte_deta_acec(codi_empr,tipo_docu,foli_docu,corr_acec,codi_acec,mnsg_erro,peri_part) VALUES " +
                                               "( 1, '" + TipoDocu + "', '" + i + "', 0, '620200', '','" + Periodo + "')¿" +


                                               "INSERT into dte_deta_prse(codi_emex,codi_empr,tipo_docu,foli_docu,nume_line,codi_impu,tipo_codi,codi_item,indi_exen,nomb_item,desc_item,cant_item,cant_refe," +
                                               "unid_refe,prec_refe,unid_medi,prec_item,prec_mono,codi_mone,fact_conv,dcto_item,reca_item,neto_item,desc_porc,reca_porc,fech_elab,fech_vepr,mnsg_erro,desc_mone," +
                                               "reca_mone,valo_mone,indi_agen,base_faen,marg_comer,prne_cofi,peri_part) VALUES " +
                                               " ('PROD_0000',1 ,'" + TipoDocu + "',  '" + i + "', 1, '', NULL, NULL, 0 , 'Pastel', 'Papas'  ,5000,0 , NULL, NULL, '',2500, NULL, NULL, NULL, 0 ,NULL,12500000,0, NULL, NULL, NULL, '', NULL, NULL, NULL, NULL, NULL, NULL, NULL, '" + Periodo + "')¿" +

                                               "INSERT INTO dte_foli_clie(codi_empr,tipo_docu,foli_docu,foli_clie,esta_tras,peri_part) VALUES (1,'" + TipoDocu + "', '" + i + "','m',0,'" + Periodo + "')¿" +

                                    definicion_dte_docu_refe + "(1 , '" + TipoDocu + "',  '" + i + "', 1 , '30', '1', NULL, NULL, '2021-01-29', '1', '1', 0 , NULL, NULL, 'PROD_0000', '" + Periodo + "')¿" +


                                        "INSERT into dte_deta_codi (codi_emex, codi_empr, tipo_docu, foli_docu, nume_line, corr_codi, tipo_codi, codi_item, mnsg_erro, peri_part) VALUES " +
                                         "('PROD_0000', 1, '" + TipoDocu + "',  '" + i + "', 1, 1, 'INT1', '001', '', '" + Periodo + "')¿";



                                    string[] Items = { a };

                                    int ItemsSS = GetRandomInt(0, Items.Length);

                                    Insert = Items[ItemsSS];

                                    char[] Separador = { '¿' };
                                    string[] words = Insert.Split(Separador);

                                    String Primero = "";
                                    String Segundo = "";
                                    String Tercero = "";
                                    String cuarto = "";
                                    String quinto = "";
                                    String sexto = "";
                                    GuardaQueryOracle = new string[10];
                                    int x = 0;
                                    foreach (var word in words)
                                    {

                                        GuardaQueryOracle[x] = word;
                                        x++;
                                    }

                                    Primero = GuardaQueryOracle[0];
                                    Segundo = GuardaQueryOracle[1];
                                    Tercero = GuardaQueryOracle[2];
                                    cuarto = GuardaQueryOracle[3];
                                    quinto = GuardaQueryOracle[4];
                                    sexto = GuardaQueryOracle[5];
                                    //MessageBox.Show(Primero + Segundo + Tercero);

                                    String Query1 = Primero;
                                    conexionOR.EjecutaQueryOracle(Query1);
                                    String Query2 = Segundo;
                                    conexionOR.EjecutaQueryOracle(Query2);
                                    String Query3 = Tercero;
                                    conexionOR.EjecutaQueryOracle(Query3);
                                    String Query4 = cuarto;
                                    conexionOR.EjecutaQueryOracle(Query4);
                                    String Query5 = quinto;
                                    conexionOR.EjecutaQueryOracle(Query5);
                                    String Query6 = sexto;
                                    conexionOR.EjecutaQueryOracle(Query6);



                                }
                                break;
                            case 56:
                                for (int i = Convert.ToInt32(Foliodesde); i <= Foliohasta; i++)
                                {

                                    ConexionBD conexionOR = new ConexionBD(Ambiente);
                                    conexionOR.ConexionOracle();

                                    String a = definicion_dte_enca_docu + "(1 , '" + TipoDocu + "', '" + i + "', 'ING', NULL, NULL, NULL, '" + fecha + "', NULL,   0 , 2   , NULL, NULL, NULL, NULL,   '', '" + fechaVenc + "' , " + RutEmpresa + ", NULL, NULL, '" + DigiEmpresa + "'," +
                                               "'DBNET Ingenieria de Software', 'Las mejores frutas', NULL, NULL, 'Av siempre viva 335', ' HUECHURABA', 'SANTIAGO', NULL, NULL, NULL, 78079790 , '8', 'dbnet', '123', 'Botellas', '511551', 'dbnet', ' CERRILLOS'," +
                                               "'SANTIAGO',              NULL, NULL, NULL, NULL, NULL, '', 0 , '', '', '', '', 354892000   , 0         , 67429480  , NULL, 0   , NULL, 422321480  , 0 , 0 , NULL, NULL, NULL, 0 , '1.0',  '" + fecha + "T09:12:20'," +
                                               "NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, '', NULL, NULL, 'C:\\esuite\\out', '', '', '', '', '', '', '', '', '', '', 19, NULL, NULL, NULL, NULL, 'S', NULL, NULL, NULL, 0 , NULL, NULL, NULL, NULL, NULL," +
                                               "NULL, NULL, NULL, NULL, '', NULL, NULL, NULL, NULL, NULL, NULL, 0 , 0 , 0, 0 , '', NULL, NULL, NULL, NULL, '', '', 0   , NULL, 0   , NULL, NULL, NULL, 0, 0, 0, 0 , NULL, 0 , 0, NULL, ''   , NULL, ''    , NULL, NULL," +
                                               "NULL, NULL, NULL, NULL, NULL     , NULL, NULL, NULL        , NULL, NULL, NULL, NULL, NULL        , '0', NULL, 'esuite', NULL, NULL    , NULL, 'PROD_0000', '2021-01', NULL, NULL, NULL, 202101, NULL, NULL, NULL," +
                                               "0 , 0, 0 , 0 )¿" +


                                               "INSERT into dte_deta_acec(codi_empr,tipo_docu,foli_docu,corr_acec,codi_acec,mnsg_erro,peri_part) VALUES " +
                                               "( 1, '" + TipoDocu + "', '" + i + "', 0, '620200', '','" + Periodo + "')¿" +

                                               "INSERT into dte_deta_prse(codi_emex,codi_empr,tipo_docu,foli_docu,nume_line,codi_impu,tipo_codi,codi_item,indi_exen,nomb_item,desc_item,cant_item,cant_refe," +
                                               "unid_refe,prec_refe,unid_medi,prec_item,prec_mono,codi_mone,fact_conv,dcto_item,reca_item,neto_item,desc_porc,reca_porc,fech_elab,fech_vepr,mnsg_erro,desc_mone," +
                                               "reca_mone,valo_mone,indi_agen,base_faen,marg_comer,prne_cofi,peri_part) VALUES " +
                                               " ('PROD_0000',1 ,'" + TipoDocu + "',  '" + i + "', 1, '', NULL, NULL, 0 , 'notebook','Asus',200,0, NULL, NULL, '',123000, NULL, NULL, NULL,0, NULL,24600000,0, NULL, NULL, NULL, '', NULL, NULL, NULL, NULL, NULL, NULL, NULL, '" + Periodo + "')¿" +

                                               "INSERT INTO dte_foli_clie(codi_empr,tipo_docu,foli_docu,foli_clie,esta_tras,peri_part) VALUES (1,'" + TipoDocu + "', '" + i + "','A',0,'" + Periodo + "')¿" +



                                    definicion_dte_docu_refe + "(1 , '" + TipoDocu + "',  '" + i + "', 1 , '30', '1', NULL, NULL, '2021-01-29', '1', '1', 0 , NULL, NULL, 'PROD_0000', '" + Periodo + "')¿" +

                                    "INSERT into dte_deta_codi (codi_emex, codi_empr, tipo_docu, foli_docu, nume_line, corr_codi, tipo_codi, codi_item, mnsg_erro, peri_part) VALUES " +
                                                 "('PROD_0000', 1, '" + TipoDocu + "',  '" + i + "', 1, 1, 'INT1', '001', '', '" + Periodo + "')¿";



                                    string[] Items = { a };

                                    int ItemsSS = GetRandomInt(0, Items.Length);

                                    Insert = Items[ItemsSS];

                                    char[] Separador = { '¿' };
                                    string[] words = Insert.Split(Separador);

                                    String Primero = "";
                                    String Segundo = "";
                                    String Tercero = "";
                                    String cuarto = "";
                                    String quinto = "";
                                    String sexto = "";
                                    GuardaQueryOracle = new string[10];
                                    int x = 0;
                                    foreach (var word in words)
                                    {

                                        GuardaQueryOracle[x] = word;
                                        x++;
                                    }

                                    Primero = GuardaQueryOracle[0];
                                    Segundo = GuardaQueryOracle[1];
                                    Tercero = GuardaQueryOracle[2];
                                    cuarto = GuardaQueryOracle[3];
                                    quinto = GuardaQueryOracle[4];
                                    sexto = GuardaQueryOracle[5];
                                    //MessageBox.Show(Primero + Segundo + Tercero);

                                    String Query1 = Primero;
                                    conexionOR.EjecutaQueryOracle(Query1);
                                    String Query2 = Segundo;
                                    conexionOR.EjecutaQueryOracle(Query2);
                                    String Query3 = Tercero;
                                    conexionOR.EjecutaQueryOracle(Query3);
                                    String Query4 = cuarto;
                                    conexionOR.EjecutaQueryOracle(Query4);
                                    String Query5 = quinto;
                                    conexionOR.EjecutaQueryOracle(Query5);
                                    String Query6 = sexto;
                                    conexionOR.EjecutaQueryOracle(Query6);



                                }
                                break;
                            case 61:
                                for (int i = Convert.ToInt32(Foliodesde); i <= Foliohasta; i++)
                                {

                                    ConexionBD conexionOR = new ConexionBD(Ambiente);
                                    conexionOR.ConexionOracle();

                                    String a = definicion_dte_enca_docu + "(1 , '" + TipoDocu + "', '" + i + "', 'ING', NULL, NULL, NULL, '" + fecha + "', NULL,   0 , 2   , NULL, NULL, NULL, NULL,   '', '" + fechaVenc + "' , " + RutEmpresa + ", NULL, NULL, '" + DigiEmpresa + "'," +
                                               " 'DBNET Ingenieria de Software', 'Las mejores frutas', NULL, NULL, 'Av siempre viva 335', ' HUECHURABA', 'SANTIAGO', NULL, NULL, NULL, 78079790 , '8', 'dbnet', '123', 'Botellas', '511551', 'dbnet', ' CERRILLOS'," +
                                               " 'SANTIAGO',              NULL, NULL, NULL, NULL, NULL, '', 0 , '', '', '', '', 16944781000 , 0         , 3219508390, NULL, 0   , NULL, 20164289390, 0 , 0 , NULL, NULL, NULL, 0 , '1.0',  '" + fecha + "T09:13:16'," +
                                               " NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, '', NULL, NULL, 'C:\\esuite\\out', '', '', '', '', '', '', '', '', '', '', 19, NULL, NULL, NULL, NULL, 'S', NULL, NULL, NULL, 0 , NULL, NULL, NULL, NULL, NULL," +
                                               " NULL, NULL, NULL, NULL, '', NULL, NULL, NULL, NULL, NULL, NULL, 0 , 0 , 0, 0 , '', NULL, NULL, NULL, NULL, '', '', 0   , NULL, 0   , NULL, NULL, NULL, 0, 0, 0, 0 , NULL, 0 , 0, NULL, ''   , NULL, ''    , NULL, NULL," +
                                               " NULL, NULL, NULL, NULL, NULL     , NULL, NULL, NULL        , NULL, NULL, NULL, NULL, NULL        , '0', NULL, 'esuite', NULL, NULL    , NULL, 'PROD_0000', '2021-01', NULL, NULL, NULL, 202101, NULL, NULL, NULL, " +
                                               " 0 , 0, 0 , 0 )¿" +

                                               "INSERT into dte_deta_acec(codi_emex,codi_empr,tipo_docu,foli_docu,corr_acec,codi_acec,mnsg_erro,peri_part) VALUES " +
                                               "('PROD_0000', 1, '" + TipoDocu + "', '" + i + "', 0, '620200', '','" + Periodo + "')¿" +

                                               "INSERT into dte_deta_prse(codi_emex,codi_empr,tipo_docu,foli_docu,nume_line,codi_impu,tipo_codi,codi_item,indi_exen,nomb_item,desc_item,cant_item,cant_refe," +
                                               "unid_refe,prec_refe,unid_medi,prec_item,prec_mono,codi_mone,fact_conv,dcto_item,reca_item,neto_item,desc_porc,reca_porc,fech_elab,fech_vepr,mnsg_erro,desc_mone," +
                                               "reca_mone,valo_mone,indi_agen,base_faen,marg_comer,prne_cofi,peri_part) VALUES " +
                                               " ('PROD_0000',1 ,'" + TipoDocu + "',  '" + i + "', 1, '', NULL, NULL, 0 ,'Poleras','Hilos',2500,0, NULL, NULL, '',3000, NULL, NULL, NULL,0, NULL,7500000, NULL, NULL, NULL,'', NULL, NULL, NULL,NULL, NULL, NULL, NULL, NULL, '" + Periodo + "')¿" +

                                              "INSERT INTO dte_foli_clie(codi_empr,tipo_docu,foli_docu,foli_clie,esta_tras,peri_part) VALUES (1,'" + TipoDocu + "', '" + i + "','A',0,'" + Periodo + "')¿" +

                                               definicion_dte_docu_refe + "(1 , '" + TipoDocu + "',  '" + i + "', 1 , '30', '1', NULL, NULL, '2021-01-29', '1', '1', 0 , NULL, NULL, 'PROD_0000', '" + Periodo + "')¿" +

                                                "INSERT into dte_deta_codi (codi_emex, codi_empr, tipo_docu, foli_docu, nume_line, corr_codi, tipo_codi, codi_item, mnsg_erro, peri_part) VALUES " +
                                                 "('PROD_0000', 1, '" + TipoDocu + "',  '" + i + "', 1, 1, 'INT1', '001', '', '" + Periodo + "')¿";



                                    string[] Items = { a };

                                    int ItemsSS = GetRandomInt(0, Items.Length);

                                    Insert = Items[ItemsSS];

                                    char[] Separador = { '¿' };
                                    string[] words = Insert.Split(Separador);

                                    String Primero = "";
                                    String Segundo = "";
                                    String Tercero = "";
                                    String cuarto = "";
                                    String quinto = "";
                                    String sexto = "";
                                    GuardaQueryOracle = new string[10];
                                    int x = 0;
                                    foreach (var word in words)
                                    {

                                        GuardaQueryOracle[x] = word;
                                        x++;
                                    }

                                    Primero = GuardaQueryOracle[0];
                                    Segundo = GuardaQueryOracle[1];
                                    Tercero = GuardaQueryOracle[2];
                                    cuarto = GuardaQueryOracle[3];
                                    quinto = GuardaQueryOracle[4];
                                    sexto = GuardaQueryOracle[5];
                                    //MessageBox.Show(Primero + Segundo + Tercero);

                                    String Query1 = Primero;
                                    conexionOR.EjecutaQueryOracle(Query1);
                                    String Query2 = Segundo;
                                    conexionOR.EjecutaQueryOracle(Query2);
                                    String Query3 = Tercero;
                                    conexionOR.EjecutaQueryOracle(Query3);
                                    String Query4 = cuarto;
                                    conexionOR.EjecutaQueryOracle(Query4);
                                    String Query5 = quinto;
                                    conexionOR.EjecutaQueryOracle(Query5);
                                    String Query6 = sexto;
                                    conexionOR.EjecutaQueryOracle(Query6);



                                }
                                break;
                            case 110:
                                for (int i = Convert.ToInt32(Foliodesde); i <= Foliohasta; i++)
                                {

                                    ConexionBD conexionOR = new ConexionBD(Ambiente);
                                    conexionOR.ConexionOracle();

                                    String a = definicion_dte_enca_docu + "(1 , '" + TipoDocu + "', '" + i + "', 'ING', NULL, NULL, NULL, '" + fecha + "', NULL,   0 , 2   , NULL, NULL, NULL, NULL,   '', '" + fechaVenc + "' , " + RutEmpresa + ", NULL, NULL, '" + DigiEmpresa + "', " +
                                                "'DBNET Ingenieria de Software', 'Las mejores frutas', NULL, NULL, 'Av siempre viva 335', ' HUECHURABA', 'SANTIAGO', NULL, NULL, NULL, 55555555 , '5', 'dbnet', '123', 'Botellas', '511551', 'dbnet', ' CERRILLOS'," +
                                                " 'SANTIAGO',              NULL, NULL, NULL, NULL, NULL, '', 0 , '', '', '', '', 0           , 1197341500, 0         , NULL, NULL, NULL, 1197341500 , 0 , 0 , NULL, NULL, NULL, 0 , '1.0',  '" + fecha + "T09:15:37', " +
                                                " NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, '', NULL, NULL, 'C:\\esuite\\out', '', '', '', '', '', '', '', '', '', '', 0 , NULL, NULL, NULL, NULL, 'S', NULL, NULL, NULL, 0 , NULL, NULL, NULL, NULL, NULL, " +
                                                " NULL, NULL, NULL, NULL, '', NULL, NULL, NULL, NULL, NULL, NULL, 0 , 0 , 0, 0 , '', NULL, NULL, NULL, NULL, '', '', 992 , NULL, 931 , NULL, NULL, NULL, 0, 0, 0, 0 , NULL, 0 , 0, NULL, '243', NULL, 'PESO', NULL, NULL," +
                                                " NULL, NULL, NULL, NULL, 'PESO CL', 800 , NULL, 957873200000, NULL, NULL, NULL, NULL, 957873200000, '0', NULL, 'esuite', NULL, NULL    , NULL, 'PROD_0000', '2021-01', NULL, NULL, NULL, 202101, NULL, NULL, NULL," +
                                                " 0 , 0, 0 , 0 )¿" +


                                               "INSERT into dte_deta_acec(codi_emex,codi_empr,tipo_docu,foli_docu,corr_acec,codi_acec,mnsg_erro,peri_part) VALUES " +
                                               "('PROD_0000', 1, '" + TipoDocu + "', '" + i + "', 0, '620200', '','" + Periodo + "')¿" +

                                               "INSERT into dte_deta_prse(codi_emex,codi_empr,tipo_docu,foli_docu,nume_line,codi_impu,tipo_codi,codi_item,indi_exen,nomb_item,desc_item,cant_item,cant_refe," +
                                               "unid_refe,prec_refe,unid_medi,prec_item,prec_mono,codi_mone,fact_conv,dcto_item,reca_item,neto_item,desc_porc,reca_porc,fech_elab,fech_vepr,mnsg_erro,desc_mone," +
                                               "reca_mone,valo_mone,indi_agen,base_faen,marg_comer,prne_cofi,peri_part) VALUES " +

                                               "('PROD_0000',1 ,'" + TipoDocu + "',  '" + i + "', 1, '', NULL, NULL, 0, 'notebook','Teclas',7000,0, NULL, NULL, '',98600, NULL, NULL, NULL,0, NULL,690200000,0, NULL, NULL, NULL, '', NULL, NULL, NULL, NULL, NULL, NULL, NULL, '" + Periodo + "')¿" +


                                               "INSERT INTO dte_foli_clie(codi_empr,tipo_docu,foli_docu,foli_clie,esta_tras,peri_part) VALUES (1,'" + TipoDocu + "', '" + i + "','A',0,'" + Periodo + "')¿" +


                                               definicion_dte_docu_refe + "(1 , '" + TipoDocu + "',  '" + i + "', 1 , '30', '1', NULL, NULL, '2021-01-29', '1', '1', 0 , NULL, NULL, 'PROD_0000', '" + Periodo + "')¿" +
                                               "INSERT into dte_deta_codi (codi_emex, codi_empr, tipo_docu, foli_docu, nume_line, corr_codi, tipo_codi, codi_item, mnsg_erro, peri_part) VALUES " +
                                                 "('PROD_0000', 1, '" + TipoDocu + "',  '" + i + "', 1, 1, 'INT1', '001', '', '" + Periodo + "')¿";



                                    string[] Items = { a };

                                    int ItemsSS = GetRandomInt(0, Items.Length);

                                    Insert = Items[ItemsSS];

                                    char[] Separador = { '¿' };
                                    string[] words = Insert.Split(Separador);

                                    String Primero = "";
                                    String Segundo = "";
                                    String Tercero = "";
                                    String cuarto = "";
                                    String quinto = "";
                                    String sexto = "";
                                    GuardaQueryOracle = new string[10];
                                    int x = 0;
                                    foreach (var word in words)
                                    {

                                        GuardaQueryOracle[x] = word;
                                        x++;
                                    }

                                    Primero = GuardaQueryOracle[0];
                                    Segundo = GuardaQueryOracle[1];
                                    Tercero = GuardaQueryOracle[2];
                                    cuarto = GuardaQueryOracle[3];
                                    quinto = GuardaQueryOracle[4];
                                    sexto = GuardaQueryOracle[5];
                                    //MessageBox.Show(Primero + Segundo + Tercero);

                                    String Query1 = Primero;
                                    conexionOR.EjecutaQueryOracle(Query1);
                                    String Query2 = Segundo;
                                    conexionOR.EjecutaQueryOracle(Query2);
                                    String Query3 = Tercero;
                                    conexionOR.EjecutaQueryOracle(Query3);
                                    String Query4 = cuarto;
                                    conexionOR.EjecutaQueryOracle(Query4);
                                    String Query5 = quinto;
                                    conexionOR.EjecutaQueryOracle(Query5);
                                    String Query6 = sexto;
                                    conexionOR.EjecutaQueryOracle(Query6);



                                }
                                break;
                            case 111:
                                for (int i = Convert.ToInt32(Foliodesde); i <= Foliohasta; i++)
                                {

                                    ConexionBD conexionOR = new ConexionBD(Ambiente);
                                    conexionOR.ConexionOracle();

                                    String a = definicion_dte_enca_docu + "(1 , '" + TipoDocu + "', '" + i + "', 'ING', NULL, NULL, NULL, '" + fecha + "', NULL,   0 , 2   , NULL, NULL, NULL, NULL,   '', '" + fechaVenc + "' , " + RutEmpresa + ", NULL, NULL, '" + DigiEmpresa + "', " +
                                               "'DBNET Ingenieria de Software', 'Las mejores frutas', NULL, NULL, 'Av siempre viva 335', ' HUECHURABA', 'SANTIAGO', NULL, NULL, NULL, 55555555 , '5', 'dbnet', '123', 'Botellas', '511551', 'dbnet', ' CERRILLOS'," +
                                               " 'SANTIAGO',              NULL, NULL, NULL, NULL, NULL, '', 0 , '', '', '', '', 0           , 4566600   , 0         , NULL, NULL, NULL, 4566600    , 0 , 0 , NULL, NULL, NULL, 0 , '1.0', '" + fecha + "T09:16:51'," +
                                               " NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, '', NULL, NULL, 'C:\\esuite\\out', '', '', '', '', '', '', '', '', '', '', 19, NULL, NULL, NULL, NULL, 'S', NULL, NULL, NULL, 0 , NULL, NULL, NULL, NULL, NULL," +
                                               " NULL, NULL, NULL, NULL, '', NULL, NULL, NULL, NULL, NULL, NULL, 0 , 0 , 0, 0 , '', NULL, NULL, NULL, NULL, '', '', 992 , NULL, 903 , NULL, NULL, NULL, 0, 0, 0, 0 , NULL, 0 , 0, NULL, '406', NULL, 'PESO', NULL, NULL," +
                                               " NULL, NULL, NULL, NULL, 'PESO CL', 700 , NULL, 3196620000  , NULL, NULL, NULL, NULL, 3196620000  , '0', NULL, 'esuite', NULL, NULL    , NULL, 'PROD_0000', '2021-01', NULL, NULL, NULL, 202101, NULL, NULL, NULL," +
                                               " 0 , 0, 0 , 0 )¿" +

                                               "INSERT into dte_deta_acec(codi_emex,codi_empr,tipo_docu,foli_docu,corr_acec,codi_acec,mnsg_erro,peri_part) VALUES " +
                                               "('PROD_0000', 1, '" + TipoDocu + "', '" + i + "', 0, '620200', '','" + Periodo + "')¿" +

                                               "INSERT into dte_deta_prse(codi_emex,codi_empr,tipo_docu,foli_docu,nume_line,codi_impu,tipo_codi,codi_item,indi_exen,nomb_item,desc_item,cant_item,cant_refe," +
                                               "unid_refe,prec_refe,unid_medi,prec_item,prec_mono,codi_mone,fact_conv,dcto_item,reca_item,neto_item,desc_porc,reca_porc,fech_elab,fech_vepr,mnsg_erro,desc_mone," +
                                               "reca_mone,valo_mone,indi_agen,base_faen,marg_comer,prne_cofi,peri_part) VALUES " +
                                               "('PROD_0000',1,'" + TipoDocu + "',  '" + i + "', 1, '', NULL, NULL, 0,'Pan','Amasado',500,0, NULL, NULL,'', 30000, NULL, NULL, NULL, 0, NULL,15000000,0, NULL, NULL, NULL,'', NULL, NULL, NULL, NULL, NULL, NULL, NULL, '" + Periodo + "')¿" +

                                               "INSERT INTO dte_foli_clie(codi_empr,tipo_docu,foli_docu,foli_clie,esta_tras,peri_part) VALUES (1,'" + TipoDocu + "', '" + i + "','A',0,'" + Periodo + "')¿" +

                                               definicion_dte_docu_refe + "(1 , '" + TipoDocu + "',  '" + i + "', 1 , '30', '1', NULL, NULL, '2021-01-29', '1', '1', 0 , NULL, NULL, 'PROD_0000', '" + Periodo + "')¿" +


                                                "INSERT into dte_deta_codi (codi_emex, codi_empr, tipo_docu, foli_docu, nume_line, corr_codi, tipo_codi, codi_item, mnsg_erro, peri_part) VALUES " +
                                                 "('PROD_0000', 1, '" + TipoDocu + "',  '" + i + "', 1, 1, 'INT1', '001', '', '" + Periodo + "')¿";



                                    string[] Items = { a };

                                    int ItemsSS = GetRandomInt(0, Items.Length);

                                    Insert = Items[ItemsSS];

                                    char[] Separador = { '¿' };
                                    string[] words = Insert.Split(Separador);

                                    String Primero = "";
                                    String Segundo = "";
                                    String Tercero = "";
                                    String cuarto = "";
                                    String quinto = "";
                                    String sexto = "";
                                    GuardaQueryOracle = new string[10];
                                    int x = 0;
                                    foreach (var word in words)
                                    {

                                        GuardaQueryOracle[x] = word;
                                        x++;
                                    }

                                    Primero = GuardaQueryOracle[0];
                                    Segundo = GuardaQueryOracle[1];
                                    Tercero = GuardaQueryOracle[2];
                                    cuarto = GuardaQueryOracle[3];
                                    quinto = GuardaQueryOracle[4];
                                    sexto = GuardaQueryOracle[5];
                                    //MessageBox.Show(Primero + Segundo + Tercero);

                                    String Query1 = Primero;
                                    conexionOR.EjecutaQueryOracle(Query1);
                                    String Query2 = Segundo;
                                    conexionOR.EjecutaQueryOracle(Query2);
                                    String Query3 = Tercero;
                                    conexionOR.EjecutaQueryOracle(Query3);
                                    String Query4 = cuarto;
                                    conexionOR.EjecutaQueryOracle(Query4);
                                    String Query5 = quinto;
                                    conexionOR.EjecutaQueryOracle(Query5);
                                    String Query6 = sexto;
                                    conexionOR.EjecutaQueryOracle(Query6);



                                }
                                break;
                            case 112:
                                for (int i = Convert.ToInt32(Foliodesde); i <= Foliohasta; i++)
                                {

                                    ConexionBD conexionOR = new ConexionBD(Ambiente);
                                    conexionOR.ConexionOracle();

                                    String a = definicion_dte_enca_docu + "(1 , '" + TipoDocu + "', '" + i + "', 'ING', NULL, NULL, NULL, '" + fecha + "', NULL,   0 , 2   , NULL, NULL, NULL, NULL,   '', '" + fechaVenc + "' , " + RutEmpresa + ", NULL, NULL, '" + DigiEmpresa + "', " +
                                               "'DBNET Ingenieria de Software', 'Las mejores frutas', NULL, NULL, 'Av siempre viva 335', ' HUECHURABA', 'SANTIAGO', NULL, NULL, NULL, 55555555 , '5', 'dbnet', '123', 'Botellas', '511551', 'dbnet', " +
                                               "' CERRILLOS', 'SANTIAGO',              NULL, NULL, NULL, NULL, NULL, '', 0 , '', '', '', '', 0           , 51200     , 0         , NULL, NULL, NULL, 51200      , 0 , 0 , NULL, NULL, NULL, 0 , '1.0'," +
                                               " '" + fecha + "T09:18:06', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, '', NULL, NULL, 'C:\\esuite\\out', '', '', '', '', '', '', '', '', '', '', 19, NULL, NULL, NULL, NULL, 'S', NULL, NULL, NULL," +
                                               " 0 , NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, '', NULL, NULL, NULL, NULL, NULL, NULL, 0 , 0 , 0, 0 , '', NULL, NULL, NULL, NULL, '', '', 992 , NULL, 601 , NULL, NULL, NULL, 0, 0, 0, 0 , NULL, 0 " +
                                               " , 0, NULL, '540', NULL, 'PESO', NULL, NULL, NULL, NULL, NULL, NULL, 'PESO CL', 800 , NULL, 40960000    , NULL, NULL, NULL, NULL, 40960000    , '0', NULL, 'esuite', NULL, NULL    , NULL, 'PROD_0000', '2021-01'," +
                                               " NULL, NULL, NULL, 202101, NULL, NULL, NULL, 0 , 0, 0 , 0 )¿" +

                                               "INSERT into dte_deta_acec(codi_emex,codi_empr,tipo_docu,foli_docu,corr_acec,codi_acec,mnsg_erro,peri_part) VALUES " +
                                               "('PROD_0000', 1, '" + TipoDocu + "', '" + i + "', 0, '620200', '','" + Periodo + "')¿" +

                                               "INSERT into dte_deta_prse(codi_emex,codi_empr,tipo_docu,foli_docu,nume_line,codi_impu,tipo_codi,codi_item,indi_exen,nomb_item,desc_item,cant_item,cant_refe," +
                                               "unid_refe,prec_refe,unid_medi,prec_item,prec_mono,codi_mone,fact_conv,dcto_item,reca_item,neto_item,desc_porc,reca_porc,fech_elab,fech_vepr,mnsg_erro,desc_mone," +
                                               "reca_mone,valo_mone,indi_agen,base_faen,marg_comer,prne_cofi,peri_part) VALUES " +
                                               "('PROD_0000',1,'" + TipoDocu + "',  '" + i + "', 1,'' , NULL, NULL, 0,'Flan','Manjar',300,0, NULL, NULL,'',48966, NULL, NULL, NULL,0, NULL,14689800,0, NULL, NULL, NULL,'', NULL, NULL, NULL, NULL, NULL, NULL, NULL,'" + Periodo + "')¿" +


                                               "INSERT INTO dte_foli_clie(codi_empr,tipo_docu,foli_docu,foli_clie,esta_tras,peri_part) VALUES (1,'" + TipoDocu + "', '" + i + "','A',0,'" + Periodo + "')¿" +

                                              definicion_dte_docu_refe + "(1 , '" + TipoDocu + "',  '" + i + "', 1 , '30', '1', NULL, NULL, '2021-01-29', '1', '1', 0 , NULL, NULL, 'PROD_0000', '" + Periodo + "')¿" +


                                                "INSERT into dte_deta_codi (codi_emex, codi_empr, tipo_docu, foli_docu, nume_line, corr_codi, tipo_codi, codi_item, mnsg_erro, peri_part) VALUES " +
                                                 "('PROD_0000', 1, '" + TipoDocu + "',  '" + i + "', 1, 1, 'INT1', '001', '', '" + Periodo + "')¿";



                                    string[] Items = { a };

                                    int ItemsSS = GetRandomInt(0, Items.Length);

                                    Insert = Items[ItemsSS];

                                    char[] Separador = { '¿' };
                                    string[] words = Insert.Split(Separador);

                                    String Primero = "";
                                    String Segundo = "";
                                    String Tercero = "";
                                    String cuarto = "";
                                    String quinto = "";
                                    String sexto = "";
                                    GuardaQueryOracle = new string[10];
                                    int x = 0;
                                    foreach (var word in words)
                                    {

                                        GuardaQueryOracle[x] = word;
                                        x++;
                                    }

                                    Primero = GuardaQueryOracle[0];
                                    Segundo = GuardaQueryOracle[1];
                                    Tercero = GuardaQueryOracle[2];
                                    cuarto = GuardaQueryOracle[3];
                                    quinto = GuardaQueryOracle[4];
                                    sexto = GuardaQueryOracle[5];
                                    //MessageBox.Show(Primero + Segundo + Tercero);

                                    String Query1 = Primero;
                                    conexionOR.EjecutaQueryOracle(Query1);
                                    String Query2 = Segundo;
                                    conexionOR.EjecutaQueryOracle(Query2);
                                    String Query3 = Tercero;
                                    conexionOR.EjecutaQueryOracle(Query3);
                                    String Query4 = cuarto;
                                    conexionOR.EjecutaQueryOracle(Query4);
                                    String Query5 = quinto;
                                    conexionOR.EjecutaQueryOracle(Query5);
                                    String Query6 = sexto;
                                    conexionOR.EjecutaQueryOracle(Query6);



                                }
                                break;
                        }
                        break;
                    #endregion

                    default:
                        Console.WriteLine("Default case");

                        break;
                }
             
            } else

           if (Accion == "TXT")
            {
                Definiciones Ruta = new Definiciones();
                Ruta.creaDirectorio(RutaCarpeta);

                switch (TipoDocu)
                {

                    case 33:
                        validarCampos();
                        Ruta.creaDirectorio(RutaCarpeta + "\\DocumentosTXT\\33\\");

                        for (int i = Convert.ToInt32(Foliodesde); i <= Foliohasta; i++)
                        {
                            Documento = "A0;Perú y Colombia. En;17:27;2220;Kapaza;878;val5;val6;val7;val8;val9;\n" +
                                        "A;33;1.0;" + i + ";"+fecha+ ";;;6;;;3;2020-11-20;2020-11-20;2020-11-20;PE;5462;45;" + fechaVenc + ";" + RutEmpresa + "-" + DigiEmpresa + ";DBNET;TIC;;;8;SANTIAGO;;;;78079790-8;;DBNET;TIC;065-2265500;AV SIEMPRE VIVA;PUERTO MONTT;LLANQUIHUE;;;;;;;;;;647000;0;;19.00;122930;;;;;;769930;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;\n" +
                                        "A1;620200;\n" +
                                        "B;1;;Jarabe p/preparar bebidas;;;;;1;;;;218858;;;;;;;;;218858;;;;;;;;\n" +
                                        "B;2;;Margarina;;;;;1;;;;380118;;;;;;;;;380118;;;;;;;;\n"+
                                        "M; 1;Waldo.gonzalez@dbnetcorp.com;Waldo.gonzalez@dbnetcorp.com;Waldo.gonzalez@dbnetcorp.com;PDF de pruebas;";

                            StreamWriter writer2 = new StreamWriter(RutaCarpeta + "\\DocumentosTXT\\33\\" + "E0" + RutEmpresa + "T" + TipoDocu + "0000" + i + ".txt", false, Encoding.Default);
                            writer2.WriteLine(Documento.TrimEnd('\n'));
                            writer2.Close();                            
                        }
                        System.Diagnostics.Process.Start(RutaCarpeta + "\\DocumentosTXT\\33\\");

                        break;
                    case 34:
                        validarCampos();
                        Ruta.creaDirectorio(RutaCarpeta + "\\DocumentosTXT\\34\\");
                        for (int i = Convert.ToInt32(Foliodesde); i <= Foliohasta; i++)
                        {
                            Documento = "A0;\\; - V1; DE  - V2;GRUPO  - V3; POR- ; SAP - V5;V6;V7;V8;V9;\n" +
                                        "A;34;1.0;" + i + ";" + fecha + ";;;;;;2;;;;;;; "+ fechaVenc + " ;" + RutEmpresa + "-" + DigiEmpresa + ";DBNET;SERVICIOS DE CAPACITACION;AGROCAPACITA;;RAMON FREIRE N 986;OSORNO;OSORNO;SOLIS YENNY SOLEDAD;;78079790-8;0010070299;DBNET;SERVICIO VETERINARIO;+56987654321;HERTA FUCHSLOCHER 1001;OSORNO;OSORNO;;;;;PATENTE;;FDO. MIRAMONTES;LOS MUERMOS;LOS MUERMOS;0;40000;;;;;;;;;40000;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;\n" +
                                        "A1;620200;\n" +
                                        "B;1;;SIPEC WEB TRAZABILIDAD ANIMAL;;;;;1;;;UN;40000.000000;;;;;;;;;40000;;;;;;;;\n" +
                                        "B2;INT1;94700003;\n" +
                                        "M; 1;Waldo.gonzalez@dbnetcorp.com;Waldo.gonzalez@dbnetcorp.com;Waldo.gonzalez@dbnetcorp.com;PDF de pruebas;";

                            StreamWriter writer2 = new StreamWriter(RutaCarpeta + "\\DocumentosTXT\\34\\" + "E0" + RutEmpresa + "T" + TipoDocu + "0000" + i + ".txt", false, Encoding.Default);

                            writer2.WriteLine(Documento.TrimEnd('\n'));
                            writer2.Close();                            
                        }
                        System.Diagnostics.Process.Start(RutaCarpeta + "\\DocumentosTXT\\34\\");
                        break;
                    case 43:
                        validarCampos();
                        Ruta.creaDirectorio(RutaCarpeta + "\\DocumentosTXT\\43\\");
                        for (int i = Convert.ToInt32(Foliodesde); i <= Foliohasta; i++)
                        {
                            Documento = "A0;;;;;;;;;;;\n" +
                                        "A;43;1.0;" + i + ";" + fecha + ";;;;;;2;;;;;;0;" + fechaVenc + ";" + RutEmpresa + "-" + DigiEmpresa + ";DBNET Ingenieria de Software;venta de confites;;;18 sep 1234; HUECHURABA;SANTIAGO;;;78079790-8;111;dbnet;Papas;511551;dbnet; CERRILLOS;SANTIAGO;;;;;;;;;;33;0;0;19.00;6;0;0;;0;0;39;0;0;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;\n" +
                                        "A1;620200;\n" +
                                        "B;1;;a;a;;;;1;;;;3;;;;0;0;0;0;;3;;;;;;;;\n" +
                                        "B2;INT1;123;\n" +
                                        "B2;DUN14;2;\n" +
                                        "B5;22;\n" +
                                        "M; 1;Waldo.gonzalez@dbnetcorp.com;Waldo.gonzalez@dbnetcorp.com;Waldo.gonzalez@dbnetcorp.com;PDF de pruebas;";

                            StreamWriter writer2 = new StreamWriter(RutaCarpeta + "\\DocumentosTXT\\43\\" + "E0" + RutEmpresa + "T" + TipoDocu + "0000" + i + ".txt", false, Encoding.Default);

                            writer2.WriteLine(Documento.TrimEnd('\n'));
                            writer2.Close();                            
                        }
                        System.Diagnostics.Process.Start(RutaCarpeta + "\\DocumentosTXT\\43\\");
                        break;
                    case 46:
                        validarCampos();
                        Ruta.creaDirectorio(RutaCarpeta + "\\DocumentosTXT\\46\\");
                        for (int i = Convert.ToInt32(Foliodesde); i <= Foliohasta; i++)
                        {
                            Documento = "A0;;;;;;;;;;;\n" +
                                        "A;46;1.0;" + i + ";" + fecha + ";;;;;;;;;;;;;;" + RutEmpresa + "-" + DigiEmpresa + ";UNIVERSIDAD DE LOS LAGOS;EDUCACION;;;AVENIDA FUCHSLOCHER 1305;OSORNO;;;;10777715-6;;JOSE LEONEL VILLARROEL CASANOVA;OTRAS ACTIV.DE SERV.PERSONALES N.C.P.;.;CARRETERA AUSTRAL KILOMETRO 30 .;PUERTO MONTT;PUERTO MONTT;;;;;;;;;;126000;0;;019.00;23940;;;;;;126000;;;;;;;;;;CREDITO;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;\n" +
                                        "A1;620200;\n" +
                                        "A2;15;19.00;23940;\n" +
                                        "B;1;;COMPRA DE 63 KILOGRAMOS DE PESCADO FRESCO PARA ALIMENTO DE CONGRIOS VALOR UNITAR;IO $2.000.- EL KILOGRAMO.;;;;63;;;;2000;;;;;;;;15;126000;;;;;;;;\n" +
                                        "M; 1;Waldo.gonzalez@dbnetcorp.com;Waldo.gonzalez@dbnetcorp.com;Waldo.gonzalez@dbnetcorp.com;PDF de pruebas;";

                            StreamWriter writer2 = new StreamWriter(RutaCarpeta + "\\DocumentosTXT\\46\\" + "E0" + RutEmpresa + "T" + TipoDocu + "0000" + i + ".txt", false, Encoding.Default);

                            writer2.WriteLine(Documento.TrimEnd('\n'));
                            writer2.Close();
                        }
                        System.Diagnostics.Process.Start(RutaCarpeta + "\\DocumentosTXT\\46\\");
                        break;
                    case 52:
                        validarCampos();
                        Ruta.creaDirectorio(RutaCarpeta + "\\DocumentosTXT\\52\\");
                        if (CKBLeyMaderaTXT.Checked == true)
                        {
                            for (int i = Convert.ToInt32(Foliodesde); i <= Foliohasta; i++)
                            {
                                Documento = "A;52;1.0;" + i + ";" + fecha + ";;;;;;;;;;;;;" + fechaVenc + ";" + RutEmpresa + "-" + DigiEmpresa + ";DBNET;TIC;;;8;SANTIAGO;;;;78079790-8;;DBNET;TIC2;065-2265500;AV ALGO;PUERTO MONTT;LLANQUIHUE;;;;;;;;;;259439;0;;19.00;49293;;;;;;237048;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;\n" +
                                            "A1;620200;\n" +
                                            "B;1;;Elote;;;;;1;;;;259439;;;;;;;;;259439;;;;;;;;\n" +
                                            "M; 1;Waldo.gonzalez@dbnetcorp.com;Waldo.gonzalez@dbnetcorp.com;Waldo.gonzalez@dbnetcorp.com;PDF de pruebas;\n" +
                                            "R;String 1;Sring 2;1;\n" +
                                            "S;1;2;3;4;String 5;String 6;1;";

                                StreamWriter writer2 = new StreamWriter(RutaCarpeta + "\\DocumentosTXT\\52\\" + "E0" + RutEmpresa + "T" + TipoDocu + "0000" + i + ".txt", false, Encoding.Default);

                                writer2.WriteLine(Documento.TrimEnd('\n'));
                                writer2.Close();
                            }
                        }
                        else
                        {
                            for (int i = Convert.ToInt32(Foliodesde); i <= Foliohasta; i++)
                            {
                                Documento = "A;52;1.0;" + i + ";" + fecha + ";;;;;;;;;;;;;" + fechaVenc + ";" + RutEmpresa + "-" + DigiEmpresa + ";DBNET;TIC;;;8;SANTIAGO;;;;78079790-8;;DBNET;TIC2;065-2265500;AV ALGO;PUERTO MONTT;LLANQUIHUE;;;;;;;;;;259439;0;;19.00;49293;;;;;;237048;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;\n" +
                                            "A1;620200;\n" +
                                            "B;1;;Elote;;;;;1;;;;259439;;;;;;;;;259439;;;;;;;;\n" +
                                            "M; 1;Waldo.gonzalez@dbnetcorp.com;Waldo.gonzalez@dbnetcorp.com;Waldo.gonzalez@dbnetcorp.com;PDF de pruebas;";

                                StreamWriter writer2 = new StreamWriter(RutaCarpeta + "\\DocumentosTXT\\52\\" + "E0" + RutEmpresa + "T" + TipoDocu + "0000" + i + ".txt", false, Encoding.Default);

                                writer2.WriteLine(Documento.TrimEnd('\n'));
                                writer2.Close();
                            }
                        }
                        System.Diagnostics.Process.Start(RutaCarpeta + "\\DocumentosTXT\\52\\");
                        break;
                    case 56:
                        validarCampos();
                        Ruta.creaDirectorio(RutaCarpeta + "\\DocumentosTXT\\56\\");
                        for (int i = Convert.ToInt32(Foliodesde); i <= Foliohasta; i++)
                        {
                            Documento = "A;56;1.0;" + i + ";" + fecha + ";;;;;;;;;;;;;" + fechaVenc + ";" + RutEmpresa + "-" + DigiEmpresa + ";DBNET;TIC;;;8;SANTIAGO;;;;78079790-8;1234567894;DBNET;TIC;065-2265500;AV SIEMPRE VIVA;PUERTO MONTT;LLANQUIHUE;;;;;;;;;;199200;0;;19.00;37848;;;;;;237048;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;\n" +
                                        "A1;620200;\n" +
                                        "A2;50;9;20;\n" +
                                        "B;1;;Coliflor;;;;;1;;;;864145;;;;;;;;;864145;;;;R;100;;;\n" +
                                        "B;2;;Dátil;;;;;1;;;;977481;;;;;;;;;977481;;;;R;;200;;\n" +
                                        "B;3;;Betabel;;;;;1;;;;842942;;;;;;;;;842942;;;;R;;;300;\n" +
                                        "B;4;;Ajo;;;;;1;;;;349403;;;;;;;;;349403;;;;R;100;200;300;\n" +
                                        "D;1;801;;53333;;2015-04-22;;;\n" +
                                        "M; 1;Waldo.gonzalez@dbnetcorp.com;Waldo.gonzalez@dbnetcorp.com;Waldo.gonzalez@dbnetcorp.com;PDF de pruebas;";

                            StreamWriter writer2 = new StreamWriter(RutaCarpeta + "\\DocumentosTXT\\56\\" + "E0" + RutEmpresa + "T" + TipoDocu + "0000" + i + ".txt", false, Encoding.Default);

                            writer2.WriteLine(Documento.TrimEnd('\n'));
                            writer2.Close();                            
                        }
                        System.Diagnostics.Process.Start(RutaCarpeta + "\\DocumentosTXT\\56\\");
                        break;
                    case 61:
                        validarCampos();
                        Ruta.creaDirectorio(RutaCarpeta + "\\DocumentosTXT\\61\\");
                        for (int i = Convert.ToInt32(Foliodesde); i <= Foliohasta; i++)
                        {
                            Documento = "A;61;1.0;" + i + ";" + fecha + ";;;;;;3;;;;;;;" + fechaVenc + ";" + RutEmpresa + "-" + DigiEmpresa + ";DBNET;TIC;;;8;SANTIAGO;;;;78079790-8;1234567893;DBNET;TIC;065-2265500;AV SIEMPRE VIVA;PUERTO MONTT;LLANQUIHUE;;;;;;;;;;199200;0;;19.00;37848;;;;;;237048;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;\n" +
                                        "A1;620200;\n" +
                                        "A2;17;9;20;\n" +
                                        "B;1;;Coliflor;;;;;1;;;;864145;;;;;;;;;864145;;;;R;100;;;\n" +
                                        "B;2;;Dátil;;;;;1;;;;977481;;;;;;;;;977481;;;;R;;200;;\n" +
                                        "B;3;;Betabel;;;;;1;;;;842942;;;;;;;;;842942;;;;R;;;300;\n" +
                                        "B;4;;Ajo;;;;;1;;;;349403;;;;;;;;;349403;;;;R;100;200;300;\n" +
                                        "D;1;801;;285613;;2015-04-22;;;\n" +
                                        "M; 1;Waldo.gonzalez@dbnetcorp.com;Waldo.gonzalez@dbnetcorp.com;Waldo.gonzalez@dbnetcorp.com;PDF de pruebas;";

                            StreamWriter writer2 = new StreamWriter(RutaCarpeta + "\\DocumentosTXT\\61\\" + "E0" + RutEmpresa + "T" + TipoDocu + "0000" + i + ".txt", false, Encoding.Default);

                            writer2.WriteLine(Documento.TrimEnd('\n'));
                            writer2.Close();                            
                        }
                        System.Diagnostics.Process.Start(RutaCarpeta + "\\DocumentosTXT\\61\\");
                        break;
                    case 110:
                        validarCampos();
                        Ruta.creaDirectorio(RutaCarpeta + "\\DocumentosTXT\\110\\");
                        for (int i = Convert.ToInt32(Foliodesde); i <= Foliohasta; i++)
                        {

                            Documento = "A0;;0095000025;;;;;;;;;\n" +
                                        "A;110;1.0;" + i + ";" + fecha + ";;;;;;2;;;;;;;" + fechaVenc + ";" + RutEmpresa + "-" + DigiEmpresa + ";SALMONES MULTIEXPORT S.A.;GIRO MULTIEXPORT;S100;;Avda Cardonal 2501;Puerto Montt;Puerto Montt;;;55555555-5;0012000678;OOO AKRA;.;;NAB. REKI SMOLENKI, D.14, LITER A,;ST PETERSBURG;ST PETERSBURG;;;;;;;;;;0;1000.00;;;;;;;;;1000.00;;;;;;;;;;Cobr Directa (Crédito) 30 días;;;;;;;;;;;;;1;;;;;;;;;;;;;;;;;;;;;;;;;DOLAR USA;;;;;;;;;;;;;\n" +
                                        "A1;620200;\n" +
                                        "A3;22;10;;;;;\n" +
                                        "B;1;;FROZEN ATLANTIC SALMON HON IND. B 0,5-1 KG IQF;;;;;100;;;KG;10.00;;;;;;;;;1000.00;;;;;;;;\n" +
                                        "B2;INT1;3000002;\n" +
                                        "M; 1;Waldo.gonzalez@dbnetcorp.com;Waldo.gonzalez@dbnetcorp.com;Waldo.gonzalez@dbnetcorp.com;PDF de pruebas;";

                            StreamWriter writer2 = new StreamWriter(RutaCarpeta + "\\DocumentosTXT\\110\\" + "E0" + RutEmpresa + "T" + TipoDocu + "0000" + i + ".txt", false, Encoding.Default);

                            writer2.WriteLine(Documento.TrimEnd('\n'));
                            writer2.Close();                            
                        }
                        System.Diagnostics.Process.Start(RutaCarpeta + "\\DocumentosTXT\\110\\");
                        break;
                    case 111:
                        validarCampos();
                        Ruta.creaDirectorio(RutaCarpeta + "\\DocumentosTXT\\111\\");
                        for (int i = Convert.ToInt32(Foliodesde); i <= Foliohasta; i++)
                        {
                            Documento = "A0;\\SRP-VENLACETEST\\HPM602;;;;;0;0;;25.00;0;\n" +
                                        "A;111;1.0;" + i + ";" + fecha + ";;;;;;1;;;;;;;" + fechaVenc + ";" + RutEmpresa + "-" + DigiEmpresa + ";MARIENBERG;PRODUCCION Y COMERCIALIZACION DE ELEMENTOS PARA LA INDUSTRIA;;;SANTA MARTA;MAIPÚ;SANTIAGO;GERENCIA;;55555555-5;20-23644496-2;CERMINARO JUAN MANUEL;IMPORTADORES DE PISOS Y ALFOMBRAS;(+5411)6860 1925;AV JUAN MANUEL DE ROSAS 138 – CASTELAR –MORON (1712);CASTELAR  MORON;BUENOS AIRES;U_CASILLA_CORR;;;;;;;;;0;25.00;;;;;;;;;25.00;;;;;;;;;;Depósito y/o Transferencia;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;0;;;;;DOLAR USA;;;;PESO CL;667.550000;;16689;;;;;16689.00;\n" +
                                        "A1;620200;\n" +
                                        "B;1;;Diferencia por tipo de Cambio al pagar Neto de FV 88989;Diferencia por tipo de Cambio al pagar Neto de FV 88989;;;;1;;;;25.00;;;;0.0;0;;;;25.00;;;;;;;;\n" +
                                        "D;1;110;;13;;2019-02-27;3;;\n" +
                                        "M; 1;Waldo.gonzalez@dbnetcorp.com;Waldo.gonzalez@dbnetcorp.com;Waldo.gonzalez@dbnetcorp.com;PDF de pruebas;";

                            StreamWriter writer2 = new StreamWriter(RutaCarpeta + "\\DocumentosTXT\\111\\" + "E0" + RutEmpresa + "T" + TipoDocu + "0000" + i + ".txt", false, Encoding.Default);

                            writer2.WriteLine(Documento.TrimEnd('\n'));
                            writer2.Close(); 
                        }
                        System.Diagnostics.Process.Start(RutaCarpeta + "\\DocumentosTXT\\111\\");
                        break;
                    case 112:
                        validarCampos();
                        Ruta.creaDirectorio(RutaCarpeta + "\\DocumentosTXT\\112\\");
                        for (int i = Convert.ToInt32(Foliodesde); i <= Foliohasta; i++)
                        {
                            Documento = "A;112;1.0;" + i + ";" + fecha + ";;;;;;;;;;;;;" + fechaVenc + ";" + RutEmpresa + "-" + DigiEmpresa + ";GE HEALTHCARE INTERNATIONAL LLC AGENCIA EN CHILE;REP DE OTROS EQ ELECT Y OPTICOS N.C.P.;;;Isidora Goyenechea 2800,Piso 21;Santiago;Las Condes;;;78079790-8;;GE HEALTHCARE COLOMBIA S.A.S.;VENTA AL POR MAYOR NO ESPECIALIZADA;;CALLE 103 NO. 14 A-43;Bogota;BOGOTA, D.C.;110111;;;;;;CALLE 103 NO. 14 A-43;Bogota;BOGOTA, D.C.;0;87840.76;;;;;;;;;87840.76;;;;;;1;;;;;1;;;;;;;;;;;1;8;;;;;;;;;;;;;;;;;;;;;;;;202;DOLAR USA;;;;PESO CL;693;60873646.68;;;;;;60873646.68;\n" +
                            "A1;620200;\n" +
                            "B;1;1;Por la provision de un equipo modelo marca GE Segun propuesta definitiva FDON; Por la provision de un equipo modelo marca GE Segun propuesta definitiva FDON;;10;;2583.55176;;;10;34;;;;;;;;;87840.76;;;;;;;;\n" +
                            "D;1;110;;18;;2019-05-13;3;Corrige montos;\n" +
                            "D;2;801;;56756;;2019-05-13;;;\n" +
                             "M; 1;Waldo.gonzalez@dbnetcorp.com;Waldo.gonzalez@dbnetcorp.com;Waldo.gonzalez@dbnetcorp.com;PDF de pruebas;";

                            StreamWriter writer2 = new StreamWriter(RutaCarpeta + "\\DocumentosTXT\\112\\" + "E0" + RutEmpresa + "T" + TipoDocu + "0000" + i + ".txt", false, Encoding.Default);

                            writer2.WriteLine(Documento.TrimEnd('\n'));
                            writer2.Close();
                           
                        }
                        System.Diagnostics.Process.Start(RutaCarpeta + "\\DocumentosTXT\\112\\");

                        break;
                }


            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Seguro Desea Salir?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void FechaVencimiento_ValueChanged(object sender, EventArgs e)
        {
            fechaVenc = FechaVencimiento.Value.ToString("yyyy-MM-dd");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            switch (Ambiente)
            {
                #region CLOUD
                case "CLOUD":
                    definicionDTE_ENCA_DOCU_HOLD = "dbnet_set_emex '" + Hold + "'INSERT dte_enca_docu_hold(codi_emex,codi_empr,tipo_docu,foli_docu,esta_docu,mens_esta,corr_envi,mens_envi,fech_emis,entr_bien,vent_serv,form_pago,fech_canc," +
                                                   "dias_tepa,codi_tepa,mont_brut,moda_pago,fech_venc,rutt_emis,peri_desd,peri_hast,digi_emis,nomb_emis,giro_emis,nomb_sucu,codi_sucu,dire_orig,comu_orig,ciud_orig," +
                                                   "codi_vend,rutt_mand,digi_mand,rutt_rece,digi_rece,nomb_rece,codi_rece,giro_rece,cont_rece,dire_rece,comu_rece,ciud_rece,dire_post,comu_post,ciud_post,rutt_sofa," +
                                                   "digi_sofa,info_tran,rutt_tran,digi_tran,dire_dest,comu_dest,ciud_dest,mont_neto,mont_exen,impu_vaag,impu_vanr,cred_es65,gara_enva,mont_tota,mont_nofa,valo_paga," +
                                                   "sald_ante,codi_ceco,feho_firm,indi_vegd,vers_enca,feho_ted,firm_ted,fech_carg,usua_impr,nume_impr,fech_impr,vige_docu,codi_peri,corr_envi1,esta_docu1," +
                                                   "mnsg_erro,indi_nore,subt_vese,dire_arch,impr_dest,val1,val2,val3,val4,val5,val6,val7,val8,val9,tasa_vaag,mont_base,cola_proc,nume_imme,arch_resp,tipo_impr,mont_canc," +
                                                   "sald_inso,from_paex,tipo_cupa,cuen_pago,banc_pago,glos_pago,codi_emtr,foli_auto,fech_auto,codi_suad,iden_adem,iden_reex,naci_ext,iden_adre,mail_rece,rutt_chof," +
                                                   "digi_chof,nomb_chof,moda_vent,clau_expo,tota_clex,viaa_tran,nomb_tran,rutt_citr,digi_citr,nomb_citr,iden_citr,nume_book,codi_oper,codi_puem,iden_puem,codi_pude," +
                                                   "iden_pude,cant_tara,umed_tara,tota_brut,unid_brut,tota_neto,unid_neto,tota_item,tota_bult,mont_flet,mont_segu,pais_rece,pais_dest,tipo_moto,mont_baco,ivag_prop," +
                                                   "ivag_terc,valo_cone,valo_coex,ivaag_core,tipo_moom,tipo_camb,neto_otmo,noaf_otmo,faca_otmo,maco_otmo,ivag_otmo,ivno_otmo,mont_otmo,tipo_mone,hace_envi,foli_clie," +
                                                   "corr_extr,codi_mone,codi_usua,comi_neto,comi_exen,comi_ivaa,codi_serv,corr_cert_Firm,codi_form,peri_part,lote_docu,esta_reme,even_recl,docu_escd,tran_vent,tran_comp," +
                                                   "TIPO_FAES,TIPO_TURI) VALUES ";
                    definiciondte_deta_acec_hold = "INSERT dte_deta_acec_hold(codi_emex,codi_empr,tipo_docu,foli_docu,corr_acec,codi_acec,mnsg_erro,peri_part) VALUES ";
                    definiciondte_deta_prse_hold = "INSERT dte_deta_prse_hold(codi_emex,codi_empr,tipo_docu,foli_docu,nume_line,codi_impu,tipo_codi,codi_item,indi_exen,nomb_item,desc_item,cant_item,cant_refe," +
                                                    "unid_refe,prec_refe,unid_medi,prec_item,prec_mono,codi_mone,fact_conv,dcto_item,reca_item,neto_item,desc_porc,reca_porc,fech_elab,fech_vepr,mnsg_erro,desc_mone," +
                                                    "reca_mone,valo_mone,indi_agen,base_faen,marg_comer,prne_cofi,peri_part) VALUES ";
                    definiciondte_foli_clie_hold = "INSERT INTO dte_foli_clie_hold(codi_emex,codi_empr,tipo_docu,foli_docu,foli_clie,esta_tras,peri_part) VALUES ";

                    validarCampos();
                    // MessageBox.Show(Ambiente + "  " + TipoDocu + "  " + fecha + "  " + Foliodesde + "  " + Foliohasta);   '" +fechaVenc+ "'    '" +fecha+ "'
                    switch (TipoDocu)
                    {
                        case 33:
                            for (int i = Convert.ToInt32(Foliodesde); i <= Foliohasta; i++)
                            {
                                ConexionBD conexionCLOUD = new ConexionBD(Ambiente);
                                conexionCLOUD.abrirBD();
                                String a = definicionDTE_ENCA_DOCU_HOLD +
                                           "('" + Hold + "', 1,'" + TipoDocu + "', '" + i + "', 'ING', NULL, NULL, NULL, '" + fecha + "', 0, 0, 1, '" + fecha + "'," +
                                           "30, 'Koup', '0', 'OT', '" + fechaVenc + "' , " + RutEmpresa + ", '" + fecha + "',  '" + fechaVenc + "', '" + DigiEmpresa + "', 'DBNET', 'TIC', '', 0, '8', 'SANTIAGO', '', '', 0, '', 78079790, '8', 'DBNET', '', 'TIC', " +
                                           "'065-2265500', 'AV SIEMPRE VIVA', 'PUERTO MONTT', 'LLANQUIHUE', '', '', '', 0, '', '', 0, N'', N'', N'', N'',74500,0.0000,14155,0,0,0,88655.0000," +
                                           "0,0,0,NULL,'',0, N'1.0', NULL, '" + FechaTED + "', NULL,CAST(N'2020-04-02 10:50:47.913' AS DateTime),NULL,0, NULL, NULL, NULL, NULL, NULL,''," +
                                           "0,0,'D:\\facture_homes\\demo\\out','','','','','','','','','','',19.00,0, N'',0,NULL,'',0,0,0,0,0,'','',0,0,'','','','','','','',0,'','',0,0,0.00,0,'',0,'','','','','',0," +
                                           "'',0,'',0,0,0.00,0,0.00,0,0,0,0.0000,0.0000,'','',NULL,0,0,0,NULL,NULL,NULL,'',0.0000,0.0000,0.0000,0.0000,0.0000,0.0000,0.0000,0.0000,'','S',''," +
                                           "NULL,NULL,NULL,0,0,0,NULL,NULL,NULL,'" + Periodo + "','2020-04',NULL,NULL,NULL,0,0,0,0)" +

                                           definiciondte_deta_acec_hold + "('" + Hold + "', 1, '" + TipoDocu + "', '" + i + "', 0, '620200', '','" + Periodo + "')" +

                                           definiciondte_deta_prse_hold + "('" + Hold + "', 1, '" + TipoDocu + "',  '" + i + "', 1, '', NULL, NULL, 0, 'Calabaza', '', 1.000000, 0, '', 0.000000, '', 209409.000000, 0.000000, '', 0.0000, 0, 0, 209409.0000, 0.00, 0.00, '', '', '', 0.0000, 0.0000, 0.0000, '', 0, 0, 0, '" + Periodo + "')" +

                                           definiciondte_foli_clie_hold + "('" + Hold + "',1,'" + TipoDocu + "', '" + i + "','',0,'" + Periodo + "')";

                                String b = definicionDTE_ENCA_DOCU_HOLD +
                                           "('DEMO', 1, '" + TipoDocu + "',  '" + i + "', 'ING', NULL, NULL, NULL, '" + fecha + "', 0, 0, 1, '" + fecha + "'," +
                                           "30, 'Koup', '0', 'OT', '" + fechaVenc + "', " + RutEmpresa + ", '" + fecha + "',  '" + fechaVenc + "', '" + DigiEmpresa + "', 'DBNET', 'TIC', '', 0, '8', 'SANTIAGO', '', '', 0, '', 78079790, '8', 'DBNET', '', 'TIC', " +
                                           "'065-2265500', 'AV SIEMPRE VIVA', 'PUERTO MONTT', 'LLANQUIHUE', '', '', '', 0, '', '', 0, N'', N'', N'', N'',74500,0.0000,14155,0,0,0,88655.0000," +
                                           "0,0,0,NULL,'',0, N'1.0', NULL, '" + FechaTED + "', NULL,CAST(N'2020-04-02 10:50:47.913' AS DateTime),NULL,0, NULL, NULL, NULL, NULL, NULL,''," +
                                           "0,0,'D:\\facture_homes\\demo\\out','','','','','','','','','','',19.00,0, N'',0,NULL,'',0,0,0,0,0,'','',0,0,'','','','','','','',0,'','',0,0,0.00,0,'',0,'','','','','',0," +
                                           "'',0,'',0,0,0.00,0,0.00,0,0,0,0.0000,0.0000,'','',NULL,0,0,0,NULL,NULL,NULL,'',0.0000,0.0000,0.0000,0.0000,0.0000,0.0000,0.0000,0.0000,'','S',''," +
                                           "NULL,NULL,NULL,0,0,0,NULL,NULL,NULL,'" + Periodo + "','2020-04',NULL,NULL,NULL,0,0,0,0)" +


                                           definiciondte_deta_acec_hold + "('" + Hold + "', 1, 33,  '" + i + "', 0, '620200', '', '" + Periodo + "')" +

                                           definiciondte_deta_prse_hold + "('" + Hold + "', 1, '" + TipoDocu + "',  '" + i + "', 1, '', NULL, NULL, 0, 'Calabaza', '', 1.000000, 0, '', 0.000000, '', 209409.000000, 0.000000, '', 0.0000, 0, 0, 209409.0000, 0.00, 0.00, '', '', '', 0.0000, 0.0000, 0.0000, '', 0, 0, 0, '" + Periodo + "')" +

                                           definiciondte_foli_clie_hold + "('" + Hold + "',1,'" + TipoDocu + "', '" + i + "','',0,'" + Periodo + "')";

                                string[] Items = { a, b };

                                int ItemsSS = GetRandomInt(0, Items.Length);

                                Insert = Items[ItemsSS];

                                String Query = Insert;
                                // int Folioquery = Convert.ToInt32(Foliodesde);
                                conexionCLOUD.EjecutarSql(Query, i);
                                conexionCLOUD.CerraBD();
                            }
                            break;
                        case 34:
                            break;
                        case 43:
                            break;
                        case 46:
                            break;
                        case 52:
                            break;
                        case 56:
                            break;
                        case 61:
                            break;
                        case 110:
                            break;
                        case 111:
                            break;
                        case 112:
                            break;
                    }


                    break;
                #endregion


                #region CaseSQL
                case "SQL":
                    ConexionBD conexionsql = new ConexionBD(Ambiente);
                    conexionsql.abrirBD();

                    MessageBox.Show(Ambiente + "  " + TipoDocu + "  " + fecha + "  " + Foliodesde + "  " + Foliohasta);
                    conexionsql.CerraBD();
                    break;
                #endregion


                #region Oracle
                case "ORACLE":
                    ConexionBD conexionORA = new ConexionBD(Ambiente);
                    conexionORA.ConexionOracle();

                    validarCampos();
                    MessageBox.Show(Ambiente + "  " + TipoDocu + "  " + fecha + "  " + Foliodesde + "  " + Foliohasta);
                    break;
                #endregion

                default:
                    Console.WriteLine("Default case");

                    break;
            }
            MessageBox.Show("Termine ");
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        //Boton inserta CF
        {
            switch (Ambiente)
            {
                #region CLOUD
                        
                case "CLOUD":
                    Definiciones DEFCF = new Definiciones();

                    DefinicionDTE_TEMP = DEFCF.dte_temp_CF();
                    DefinicionDTE_Control = DEFCF.dte_control_CF();
                    definicionARCH_DTE_INFO_SII = DEFCF.ARCH_DTE_INFO_SII_CF();
                    definicion_dte_cesion_sii_tmp = DEFCF.dte_cesion_sii_tmp_CF();

                    validarCampos();

                    switch (tipodescarga)
                    {
                        #region RCV_CompraNoIncluir
                        case "RCV_CompraNoIncluir":
                            ConexionBD conexionCLOUDCFCorr = new ConexionBD(AmbienteCF);
                            conexionCLOUDCFCorr.abrirBD();

                            String Query1 = definicionARCH_DTE_INFO_SII + "(645, 'InsertDirecto','DTER', CAST(N'" + PeriodoEMISCF + "-02 12:51:39.130' AS DateTime),'ING', 'Carga exitosa'," +
                                            "" + RutEmpresaCF + ",'" + DigiEmpresaCF + "', 'SODIMAC', 10, 1,0 ,0)";

                            conexionCLOUDCFCorr.EjecutarSql(Query1);
                            String CORR_ARCH = conexionCLOUDCFCorr.DevolverCorr_arch();
                            conexionCLOUDCFCorr.CerraBD();

                            if (tablaCF == "DTE_TEMP")  //hay que sacar el corr_arch de la tabla ARCH_DTE_INFO_SII
                            {
                                for (int i = Convert.ToInt32(FoliodesdeCF); i <= FoliohastaCF; i++)
                                {
                                    ConexionBD conexionCLOUDCF = new ConexionBD(AmbienteCF);
                                    conexionCLOUDCF.abrirBD();
                                    String a = DefinicionDTE_TEMP + " ('RCP','SII','" + PeriodoCF + "',96792430,'K','SODIMAC S.A.', NULL, " + RutEmpresaCF + ",'" + DigiEmpresaCF + "','', 33 , " + i + " ,'" + PeriodoEMISCF + "-15', NULL,'" + PeriodoEMISCF + "-07 04:12:23', NULL, NULL, NULL, NULL, NULL, 'Sin Recibo', NULL, " +
                                                " 127059.00, NULL, NULL, 151200.00,'Sin OC', NULL,'No Corresp. Incluir', NULL,24141.00 , 9 , NULL, NULL, NULL, NULL, 0.00 , NULL, NULL, NULL,0 , NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL," +
                                                " NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, " + CORR_ARCH + " , NULL, NULL, NULL,'No Incluir', NULL, 'COM')";


                                    String b = DefinicionDTE_TEMP + " ('RCP','SII','" + PeriodoCF + "',96792430,'K','SODIMAC S.A.', NULL, " + RutEmpresaCF + ",'" + DigiEmpresaCF + "','', 33 , " + i + " ,'" + PeriodoEMISCF + "-30', NULL,'" + PeriodoEMISCF + "-02 11:20:20', NULL, NULL, NULL, NULL, NULL, 'Sin Recibo', NULL, " +
                                               " 127059.00, NULL, NULL, 151200.00,'Sin OC', NULL,'No Corresp. Incluir', NULL,24141.00 , 9 , NULL, NULL, NULL, NULL, 0.00 , NULL, NULL, NULL,0 , NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL," +
                                               " NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, " + CORR_ARCH + " , NULL, NULL, NULL,'No Incluir', NULL, 'COM')";


                                    string[] Items = { a, b };

                                    int ItemsSS = GetRandomInt(0, Items.Length);

                                    Insert = Items[ItemsSS];

                                    String Query = Insert;
                                    // int Folioquery = Convert.ToInt32(Foliodesde);
                                    conexionCLOUDCF.EjecutarSql(Query);
                                    conexionCLOUDCF.CerraBD();
                                }
                            }
                            else if (tablaCF == "DTE_CONTROL")
                            {
                                for (int i = Convert.ToInt32(FoliodesdeCF); i <= FoliohastaCF; i++)
                                {
                                    ConexionBD conexionCLOUDCF = new ConexionBD(AmbienteCF);
                                    conexionCLOUDCF.abrirBD();
                                    String a = DefinicionDTE_Control + "('RCP', 76388223 , '3', 'CEM S.A', NULL," + RutEmpresaCF + ",'" + DigiEmpresaCF + "', '',33 ," + i + " ,'" + PeriodoEMISCF + "-10' , NULL, 'Recibido', CAST(N'" + PeriodoEMISCF + "-10 16:20:35.000' AS DateTime), " +
                                               "CAST(N'" + PeriodoEMISCF + "-02 12:51:39.130' AS DateTime), NULL, 877987 , 'NO Cargado', NULL, 'Sin Evento', NULL, 'NO Cedido', NULL, NULL, NULL, NULL, NULL, NULL, 'Sin Respuesta', NULL, NULL, NULL, 'Sin Recibo', " +
                                               "NULL, NULL, NULL, NULL, NULL, 73440.00 , 'Sin OC', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 61714.00 , NULL, NULL, NULL, NULL, NULL, 'No Corresp. Incluir', NULL, 11726.00 , 4 , NULL, NULL, NULL," +
                                               " NULL, 0.00 , NULL, NULL, NULL, 0, '" + PeriodoCF + "', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL," +
                                               " 'No Incluir',0 , 'COM')";


                                    String b = DefinicionDTE_Control + "('RCP', 76388223 , '3', 'CEM S.A', NULL, " + RutEmpresaCF + ",'" + DigiEmpresaCF + "', '',33 ," + i + " , '2020-07-10' , NULL, 'Recibido', CAST(N'2020-07-10 16:20:35.000' AS DateTime), " +
                                               "CAST(N'2020-10-02 12:51:39.130' AS DateTime), NULL, 877987 , 'NO Cargado', NULL, 'Sin Evento', NULL, 'NO Cedido', NULL, NULL, NULL, NULL, NULL, NULL, 'Sin Respuesta', NULL, NULL, NULL, 'Sin Recibo', " +
                                               "NULL, NULL, NULL, NULL, NULL, 73440.00 , 'Sin OC', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 61714.00 , NULL, NULL, NULL, NULL, NULL, 'No Corresp. Incluir', NULL, 11726.00 , 4 , NULL, NULL, NULL," +
                                               " NULL, 0.00 , NULL, NULL, NULL, 0, '202007', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL," +
                                               " 'No Incluir',0 , 'COM')";


                                    string[] Items = { a, b };

                                    int ItemsSS = GetRandomInt(0, Items.Length);

                                    Insert = Items[ItemsSS];

                                    String Query = Insert;
                                    // int Folioquery = Convert.ToInt32(Foliodesde);
                                    conexionCLOUDCF.EjecutarSql(Query);
                                    conexionCLOUDCF.CerraBD();
                                }
                            }

                            break;
                        #endregion

                        case "RCV_CompraPendiente":

                            break;
                        #region RCV_CompraReclamado
                        case "RCV_CompraReclamado":
                            ConexionBD conexionCLOUDCFCorrV = new ConexionBD(AmbienteCF);
                            conexionCLOUDCFCorrV.abrirBD();

                            String Queryp = definicionARCH_DTE_INFO_SII + "(645, 'InsertDirecto','DTER', CAST(N'" + PeriodoEMISCF + "-02 12:51:39.130' AS DateTime),'ING', 'Carga exitosa'," +
                                            "" + RutEmpresaCF + ",'" + DigiEmpresaCF + "', 'SODIMAC', 10, 1,0 ,0)";

                            conexionCLOUDCFCorrV.EjecutarSql(Queryp);
                            String CORR_ARCHV = conexionCLOUDCFCorrV.DevolverCorr_arch();
                            conexionCLOUDCFCorrV.CerraBD();

                            if (tablaCF == "DTE_TEMP")  //hay que sacar el corr_arch de la tabla ARCH_DTE_INFO_SII
                            {
                                for (int i = Convert.ToInt32(FoliodesdeCF); i <= FoliohastaCF; i++)
                                {
                                    ConexionBD conexionCLOUDCF = new ConexionBD(AmbienteCF);
                                    conexionCLOUDCF.abrirBD();
                                    String a = DefinicionDTE_TEMP + " ('RCP', 'SII', '" + PeriodoCF + "', 83162400, '0', 'Emaresa Ingenieros y Representaciones S.A.', NULL, " + RutEmpresaCF + ",'" + DigiEmpresaCF + "', '', 61 , " + i + ", '" + PeriodoEMISCF + "-22', NULL, '" + PeriodoEMISCF + "-22 10:04:14', NULL, NULL, NULL, NULL, NULL, 'Sin Recibo', NULL, 89078   , 0, NULL, 106003  , 'Sin OC', NULL, 'Del Giro', 16925  , NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, NULL, NULL, 0 , NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, " + CORR_ARCHV + ", NULL, NULL, NULL, 'Reclamado', NULL, 'COM')";
                                    String b = DefinicionDTE_TEMP + " ('RCP', 'SII', '" + PeriodoCF + "', 83162400, '0', 'Emaresa Ingenieros y Representaciones S.A.', NULL, " + RutEmpresaCF + ",'" + DigiEmpresaCF + "', '', 61 , " + i + ", '" + PeriodoEMISCF + "-22', NULL, '" + PeriodoEMISCF + "-22 10:04:17', NULL, NULL, NULL, NULL, NULL, 'Sin Recibo', NULL, 1197503 , 0, NULL, 1425029 , 'Sin OC', NULL, 'Del Giro', 227526 , NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, NULL, NULL, 0 , NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, " + CORR_ARCHV + ", NULL, NULL, NULL, 'Reclamado', NULL, 'COM')";
                                    String c = DefinicionDTE_TEMP + " ('RCP', 'SII', '" + PeriodoCF + "', 83162400, '0', 'Emaresa Ingenieros y Representaciones S.A.', NULL, " + RutEmpresaCF + ",'" + DigiEmpresaCF + "', '', 61 , " + i + ", '" + PeriodoEMISCF + "-22', NULL, '" + PeriodoEMISCF + "-22 10:04:23', NULL, NULL, NULL, NULL, NULL, 'Sin Recibo', NULL, 1467345 , 0, NULL, 1746141 , 'Sin OC', NULL, 'Del Giro', 278796 , NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, NULL, NULL, 0 , NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, " + CORR_ARCHV + ", NULL, NULL, NULL, 'Reclamado', NULL, 'COM')";
                                    String d = DefinicionDTE_TEMP + " ('RCP', 'SII', '" + PeriodoCF + "', 83162400, '0', 'Emaresa Ingenieros y Representaciones S.A.', NULL, " + RutEmpresaCF + ",'" + DigiEmpresaCF + "', '', 61 , " + i + ", '" + PeriodoEMISCF + "-22', NULL, '" + PeriodoEMISCF + "-22 10:04:26', NULL, NULL, NULL, NULL, NULL, 'Sin Recibo', NULL, 28819312, 0, NULL, 34294981, 'Sin OC', NULL, 'Del Giro', 5475669, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, NULL, NULL, 0 , NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, " + CORR_ARCHV + ", NULL, NULL, NULL, 'Reclamado', NULL, 'COM')";
                                    String f = DefinicionDTE_TEMP + " ('RCP', 'SII', '" + PeriodoCF + "', 96510970, '6', 'Maderas Arauco S.A.'                       , NULL, " + RutEmpresaCF + ",'" + DigiEmpresaCF + "', '', 61 , " + i + ", '" + PeriodoEMISCF + "-22', NULL, '" + PeriodoEMISCF + "-22 10:04:33', NULL, NULL, NULL, NULL, NULL, 'Sin Recibo', NULL, 257640  , 0, NULL, 306592  , 'Sin OC', NULL, 'Del Giro', 48952  , NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, NULL, NULL, 0 , NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, " + CORR_ARCHV + ", NULL, NULL, NULL, 'Reclamado', NULL, 'COM')";
                                    String g = DefinicionDTE_TEMP + " ('RCP', 'SII', '" + PeriodoCF + "', 96510970, '6', 'Maderas Arauco S.A.'                       , NULL, " + RutEmpresaCF + ",'" + DigiEmpresaCF + "', '', 61 , " + i + ", '" + PeriodoEMISCF + "-22', NULL, '" + PeriodoEMISCF + "-22 10:04:31', NULL, NULL, NULL, NULL, NULL, 'Sin Recibo', NULL, 4461677 , 0, NULL, 5309396 , 'Sin OC', NULL, 'Del Giro', 847719 , NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, NULL, NULL, 0 , NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, " + CORR_ARCHV + ", NULL, NULL, NULL, 'Reclamado', NULL, 'COM')";
                                    String h = DefinicionDTE_TEMP + " ('RCP', 'SII', '" + PeriodoCF + "', 96510970, '6', 'Maderas Arauco S.A.'                       , NULL, " + RutEmpresaCF + ",'" + DigiEmpresaCF + "', '', 61 , " + i + ", '" + PeriodoEMISCF + "-22', NULL, '" + PeriodoEMISCF + "-22 10:04:35', NULL, NULL, NULL, NULL, NULL, 'Sin Recibo', NULL, 458205  , 0, NULL, 545264  , 'Sin OC', NULL, 'Del Giro', 87059  , NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, NULL, NULL, 0 , NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, " + CORR_ARCHV + ", NULL, NULL, NULL, 'Reclamado', NULL, 'COM')";
                                    String ii = DefinicionDTE_TEMP + " ('RCP', 'SII', '" + PeriodoCF + "', 96510970, '6', 'Maderas Arauco S.A.'                      , NULL, " + RutEmpresaCF + ",'" + DigiEmpresaCF + "', '', 61 , " + i + ", '" + PeriodoEMISCF + "-22', NULL, '" + PeriodoEMISCF + "-22 10:07:36', NULL, NULL, NULL, NULL, NULL, 'Sin Recibo', NULL, 3226716 , 0, NULL, 3839792 , 'Sin OC', NULL, 'Del Giro', 613076 , NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, NULL, NULL, 0 , NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, " + CORR_ARCHV + ", NULL, NULL, NULL, 'Reclamado', NULL, 'COM')";
                                    String j = DefinicionDTE_TEMP + " ('RCP', 'SII', '" + PeriodoCF + "', 96510970, '6', 'Maderas Arauco S.A.'                       , NULL, " + RutEmpresaCF + ",'" + DigiEmpresaCF + "', '', 61 , " + i + ", '" + PeriodoEMISCF + "-22', NULL, '" + PeriodoEMISCF + "-22 10:07:36', NULL, NULL, NULL, NULL, NULL, 'Sin Recibo', NULL, 4095336 , 0, NULL, 4873450 , 'Sin OC', NULL, 'Del Giro', 778114 , NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, NULL, NULL, 0 , NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, " + CORR_ARCHV + ", NULL, NULL, NULL, 'Reclamado', NULL, 'COM')";
                                    String k = DefinicionDTE_TEMP + " ('RCP', 'SII', '" + PeriodoCF + "', 96510970, '6', 'Maderas Arauco S.A.'                       , NULL, " + RutEmpresaCF + ",'" + DigiEmpresaCF + "', '', 61 , " + i + ", '" + PeriodoEMISCF + "-22', NULL, '" + PeriodoEMISCF + "-22 10:07:38', NULL, NULL, NULL, NULL, NULL, 'Sin Recibo', NULL, 1192040 , 0, NULL, 1418528 , 'Sin OC', NULL, 'Del Giro', 226488 , NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, NULL, NULL, 0 , NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, " + CORR_ARCHV + ", NULL, NULL, NULL, 'Reclamado', NULL, 'COM')";
                                    String m = DefinicionDTE_TEMP + " ('RCP', 'SII', '" + PeriodoCF + "', 96510970, '6', 'Maderas Arauco S.A.'                       , NULL, " + RutEmpresaCF + ",'" + DigiEmpresaCF + "', '', 61 , " + i + ", '" + PeriodoEMISCF + "-22', NULL, '" + PeriodoEMISCF + "-22 10:07:34', NULL, NULL, NULL, NULL, NULL, 'Sin Recibo', NULL, 792103  , 0, NULL, 942603  , 'Sin OC', NULL, 'Del Giro', 150500 , NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, NULL, NULL, 0 , NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, " + CORR_ARCHV + ", NULL, NULL, NULL, 'Reclamado', NULL, 'COM')";
                                    String n = DefinicionDTE_TEMP + " ('RCP', 'SII', '" + PeriodoCF + "', 76337651, '6', 'INDUSTRIA MANUFACTURA ELECTRICA SPA'       , NULL, " + RutEmpresaCF + ",'" + DigiEmpresaCF + "', '', 61 , " + i + ", '" + PeriodoEMISCF + "-22', NULL, '" + PeriodoEMISCF + "-22 10:16:45', NULL, NULL, NULL, NULL, NULL, 'Sin Recibo', NULL, 5212    , 0, NULL, 6202    , 'Sin OC', NULL, 'Del Giro', 990    , NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, NULL, NULL, 0 , NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, " + CORR_ARCHV + ", NULL, NULL, NULL, 'Reclamado', NULL, 'COM')";
                                    String o = DefinicionDTE_TEMP + " ('RCP', 'SII', '" + PeriodoCF + "', 78803490, '3', 'Henkel Chile Limitada'                     , NULL, " + RutEmpresaCF + ",'" + DigiEmpresaCF + "', '', 61 , " + i + ", '" + PeriodoEMISCF + "-22', NULL, '" + PeriodoEMISCF + "-22 10:21:42', NULL, NULL, NULL, NULL, NULL, 'Sin Recibo', NULL, 157145  , 0, NULL, 187003  , 'Sin OC', NULL, 'Del Giro', 29858  , NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, NULL, NULL, 0 , NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, " + CORR_ARCHV + ", NULL, NULL, NULL, 'Reclamado', NULL, 'COM')";
                                    String p = DefinicionDTE_TEMP + " ('RCP', 'SII', '" + PeriodoCF + "', 77248430, '5', 'MAKITA CHILE COMERCIAL LTDA.'              , NULL, " + RutEmpresaCF + ",'" + DigiEmpresaCF + "', '', 61 , " + i + ", '" + PeriodoEMISCF + "-22', NULL, '" + PeriodoEMISCF + "-22 10:47:15', NULL, NULL, NULL, NULL, NULL, 'Sin Recibo', NULL, 79170   , 0, NULL, 94212   , 'Sin OC', NULL, 'Del Giro', 15042  , NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, NULL, NULL, 0 , NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, " + CORR_ARCHV + ", NULL, NULL, NULL, 'Reclamado', NULL, 'COM')";
                                    String kk = DefinicionDTE_TEMP + " ('RCP', 'SII', '" + PeriodoCF + "', 77248430, '5', 'MAKITA CHILE COMERCIAL LTDA.'             , NULL, " + RutEmpresaCF + ",'" + DigiEmpresaCF + "', '', 61 , " + i + ", '" + PeriodoEMISCF + "-22', NULL, '" + PeriodoEMISCF + "-22 10:49:43', NULL, NULL, NULL, NULL, NULL, 'Sin Recibo', NULL, 268900  , 0, NULL, 319991  , 'Sin OC', NULL, 'Del Giro', 51091  , NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, NULL, NULL, 0 , NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, " + CORR_ARCHV + ", NULL, NULL, NULL, 'Reclamado', NULL, 'COM')";
                                    String aa = DefinicionDTE_TEMP + " ('RCP', 'SII', '" + PeriodoCF + "', 76969758, '6', 'SOS ASISTENCIA CHILE SPA'                 , NULL, " + RutEmpresaCF + ",'" + DigiEmpresaCF + "', '', 61 , " + i + ", '" + PeriodoEMISCF + "-22', NULL, '" + PeriodoEMISCF + "-22 10:55:03', NULL, NULL, NULL, NULL, NULL, 'Sin Recibo', NULL, 190696  , 0, NULL, 226928  , 'Sin OC', NULL, 'Del Giro', 36232  , NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, NULL, NULL, 0 , NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, " + CORR_ARCHV + ", NULL, NULL, NULL, 'Reclamado', NULL, 'COM')";


                                    string[] Items = { a, b, c, d, f, g, h, ii, j, k, m, n, o, p, kk, aa };

                                    int ItemsSS = GetRandomInt(0, Items.Length);

                                    Insert = Items[ItemsSS];

                                    String Query = Insert;
                                    // int Folioquery = Convert.ToInt32(Foliodesde);
                                    conexionCLOUDCF.EjecutarSql(Query);
                                    conexionCLOUDCF.CerraBD();
                                }
                            }
                            else if (tablaCF == "DTE_CONTROL")
                            {
                                for (int i = Convert.ToInt32(FoliodesdeCF); i <= FoliohastaCF; i++)
                                {
                                    ConexionBD conexionCLOUDCF = new ConexionBD(AmbienteCF);
                                    conexionCLOUDCF.abrirBD();

                                    String a = DefinicionDTE_Control + "('RCP', 76337651, '6', 'INDUSTRIA MANUFACTURA ELECTRICA SPA'       , NULL, " + RutEmpresaCF + ",'" + DigiEmpresaCF + "', '', 33 , " + i + ", '" + PeriodoEMISCF + "-22' , NULL, 'Recibido', CAST(N'" + PeriodoEMISCF + "-22 10:16:45.000' AS DateTime), CAST(N'" + PeriodoEMISCF + "-10 09:01:15.480' AS DateTime), NULL, 888033, 'NO Cargado', NULL, 'Reclamado', NULL, 'NO Cedido', NULL, NULL, NULL, NULL, NULL, NULL, 'Sin Respuesta', NULL, NULL, NULL, 'Sin Recibo', NULL, NULL, NULL, NULL, NULL, 6202   ,  'Sin OC', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 5212    , 0, NULL, NULL, NULL, NULL, 'Del Giro', 990  ,   NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, NULL, NULL, 0, '202006', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'Reclamado',0 , 'COM')";
                                    String b = DefinicionDTE_Control + "('RCP', 76969758, '6', 'SOS ASISTENCIA CHILE SPA'                  , NULL, " + RutEmpresaCF + ",'" + DigiEmpresaCF + "', '', 33 , " + i + ", '" + PeriodoEMISCF + "-22' , NULL, 'Recibido', CAST(N'" + PeriodoEMISCF + "-22 10:55:03.000' AS DateTime), CAST(N'" + PeriodoEMISCF + "-10 09:01:15.480' AS DateTime), NULL, 888033, 'NO Cargado', NULL, 'Reclamado', NULL, 'NO Cedido', NULL, NULL, NULL, NULL, NULL, NULL, 'Sin Respuesta', NULL, NULL, NULL, 'Sin Recibo', NULL, NULL, NULL, NULL, NULL, 226928 ,  'Sin OC', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 190696  , 0, NULL, NULL, NULL, NULL, 'Del Giro', 36232,   NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, NULL, NULL, 0, '202006', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'Reclamado',0 , 'COM')";
                                    String c = DefinicionDTE_Control + "('RCP', 77248430, '5', 'MAKITA CHILE COMERCIAL LTDA.'              , NULL, " + RutEmpresaCF + ",'" + DigiEmpresaCF + "', '', 34 , " + i + ", '" + PeriodoEMISCF + "-22' , NULL, 'Recibido', CAST(N'" + PeriodoEMISCF + "-22 10:47:15.000' AS DateTime), CAST(N'" + PeriodoEMISCF + "-10 09:01:15.480' AS DateTime), NULL, 888033, 'NO Cargado', NULL, 'Reclamado', NULL, 'NO Cedido', NULL, NULL, NULL, NULL, NULL, NULL, 'Sin Respuesta', NULL, NULL, NULL, 'Sin Recibo', NULL, NULL, NULL, NULL, NULL, 94212  ,  'Sin OC', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 79170   , 0, NULL, NULL, NULL, NULL, 'Del Giro', 15042,   NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, NULL, NULL, 0, '202006', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'Reclamado',0 , 'COM')";
                                    String d = DefinicionDTE_Control + "('RCP', 77248430, '5', 'MAKITA CHILE COMERCIAL LTDA.'              , NULL, " + RutEmpresaCF + ",'" + DigiEmpresaCF + "', '', 34 , " + i + ", '" + PeriodoEMISCF + "-22' , NULL, 'Recibido', CAST(N'" + PeriodoEMISCF + "-22 10:49:43.000' AS DateTime), CAST(N'" + PeriodoEMISCF + "-10 09:01:15.480' AS DateTime), NULL, 888033, 'NO Cargado', NULL, 'Reclamado', NULL, 'NO Cedido', NULL, NULL, NULL, NULL, NULL, NULL, 'Sin Respuesta', NULL, NULL, NULL, 'Sin Recibo', NULL, NULL, NULL, NULL, NULL, 319991 ,  'Sin OC', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 268900  , 0, NULL, NULL, NULL, NULL, 'Del Giro', 51091,   NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, NULL, NULL, 0, '202006', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'Reclamado',0 , 'COM')";
                                    String f = DefinicionDTE_Control + "('RCP', 78803490, '3', 'Henkel Chile Limitada'                     , NULL, " + RutEmpresaCF + ",'" + DigiEmpresaCF + "', '', 43 , " + i + ", '" + PeriodoEMISCF + "-22' , NULL, 'Recibido', CAST(N'" + PeriodoEMISCF + "-22 10:21:42.000' AS DateTime), CAST(N'" + PeriodoEMISCF + "-10 09:01:15.480' AS DateTime), NULL, 888033, 'NO Cargado', NULL, 'Reclamado', NULL, 'NO Cedido', NULL, NULL, NULL, NULL, NULL, NULL, 'Sin Respuesta', NULL, NULL, NULL, 'Sin Recibo', NULL, NULL, NULL, NULL, NULL, 187003 ,  'Sin OC', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 157145  , 0, NULL, NULL, NULL, NULL, 'Del Giro', 29858,   NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, NULL, NULL, 0, '202006', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'Reclamado',0 , 'COM')";
                                    String g = DefinicionDTE_Control + "('RCP', 83162400, '0', 'Emaresa Ingenieros y Representaciones S.A.', NULL, " + RutEmpresaCF + ",'" + DigiEmpresaCF + "', '', 43 , " + i + ", '" + PeriodoEMISCF + "-22' , NULL, 'Recibido', CAST(N'" + PeriodoEMISCF + "-22 10:04:14.000' AS DateTime), CAST(N'" + PeriodoEMISCF + "-10 09:01:15.480' AS DateTime), NULL, 888033, 'NO Cargado', NULL, 'Reclamado', NULL, 'NO Cedido', NULL, NULL, NULL, NULL, NULL, NULL, 'Sin Respuesta', NULL, NULL, NULL, 'Sin Recibo', NULL, NULL, NULL, NULL, NULL, 106003 ,  'Sin OC', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 89078   , 0, NULL, NULL, NULL, NULL, 'Del Giro', 16925,   NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, NULL, NULL, 0, '202006', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'Reclamado',0 , 'COM')";
                                    String h = DefinicionDTE_Control + "('RCP', 83162400, '0', 'Emaresa Ingenieros y Representaciones S.A.', NULL, " + RutEmpresaCF + ",'" + DigiEmpresaCF + "', '', 46 , " + i + ", '" + PeriodoEMISCF + "-22' , NULL, 'Recibido', CAST(N'" + PeriodoEMISCF + "-22 10:04:17.000' AS DateTime), CAST(N'" + PeriodoEMISCF + "-10 09:01:15.480' AS DateTime), NULL, 888033, 'NO Cargado', NULL, 'Reclamado', NULL, 'NO Cedido', NULL, NULL, NULL, NULL, NULL, NULL, 'Sin Respuesta', NULL, NULL, NULL, 'Sin Recibo', NULL, NULL, NULL, NULL, NULL, 1425029,  'Sin OC', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1197503 , 0, NULL, NULL, NULL, NULL, 'Del Giro', 227526,  NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, NULL, NULL, 0, '202006', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'Reclamado',0 , 'COM')";
                                    String ii = DefinicionDTE_Control + "('RCP', 83162400, '0', 'Emaresa Ingenieros y Representaciones S.A.', NULL, " + RutEmpresaCF + ",'" + DigiEmpresaCF + "', '', 46 , " + i + ", '" + PeriodoEMISCF + "-22' , NULL, 'Recibido', CAST(N'" + PeriodoEMISCF + "-22 10:04:23.000' AS DateTime), CAST(N'" + PeriodoEMISCF + "-10 09:01:15.480' AS DateTime), NULL, 888033, 'NO Cargado', NULL, 'Reclamado', NULL, 'NO Cedido', NULL, NULL, NULL, NULL, NULL, NULL, 'Sin Respuesta', NULL, NULL, NULL, 'Sin Recibo', NULL, NULL, NULL, NULL, NULL, 1746141 , 'Sin OC', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1467345 , 0, NULL, NULL, NULL, NULL, 'Del Giro', 278796,  NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, NULL, NULL, 0, '202006', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'Reclamado',0 , 'COM')";
                                    String j = DefinicionDTE_Control + "('RCP', 83162400, '0', 'Emaresa Ingenieros y Representaciones S.A.', NULL, " + RutEmpresaCF + ",'" + DigiEmpresaCF + "', '', 52 , " + i + ", '" + PeriodoEMISCF + "-22' , NULL, 'Recibido', CAST(N'" + PeriodoEMISCF + "-22 10:04:26.000' AS DateTime), CAST(N'" + PeriodoEMISCF + "-10 09:01:15.480' AS DateTime), NULL, 888033, 'NO Cargado', NULL, 'Reclamado', NULL, 'NO Cedido', NULL, NULL, NULL, NULL, NULL, NULL, 'Sin Respuesta', NULL, NULL, NULL, 'Sin Recibo', NULL, NULL, NULL, NULL, NULL, 34294981, 'Sin OC', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 28819312, 0, NULL, NULL, NULL, NULL, 'Del Giro', 5475669, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, NULL, NULL, 0, '202006', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'Reclamado',0 , 'COM')";
                                    String k = DefinicionDTE_Control + "('RCP', 96510970, '6', 'Maderas Arauco S.A.'                       , NULL, " + RutEmpresaCF + ",'" + DigiEmpresaCF + "', '', 52 , " + i + ", '" + PeriodoEMISCF + "-22' , NULL, 'Recibido', CAST(N'" + PeriodoEMISCF + "-22 10:04:31.000' AS DateTime), CAST(N'" + PeriodoEMISCF + "-10 09:01:15.480' AS DateTime), NULL, 888033, 'NO Cargado', NULL, 'Reclamado', NULL, 'NO Cedido', NULL, NULL, NULL, NULL, NULL, NULL, 'Sin Respuesta', NULL, NULL, NULL, 'Sin Recibo', NULL, NULL, NULL, NULL, NULL, 5309396 , 'Sin OC', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 4461677 , 0, NULL, NULL, NULL, NULL, 'Del Giro', 847719 , NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, NULL, NULL, 0, '202006', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'Reclamado',0 , 'COM')";
                                    String m = DefinicionDTE_Control + "('RCP', 96510970, '6', 'Maderas Arauco S.A.'                       , NULL, " + RutEmpresaCF + ",'" + DigiEmpresaCF + "', '', 56 , " + i + ", '" + PeriodoEMISCF + "-22' , NULL, 'Recibido', CAST(N'" + PeriodoEMISCF + "-22 10:04:33.000' AS DateTime), CAST(N'" + PeriodoEMISCF + "-10 09:01:15.480' AS DateTime), NULL, 888033, 'NO Cargado', NULL, 'Reclamado', NULL, 'NO Cedido', NULL, NULL, NULL, NULL, NULL, NULL, 'Sin Respuesta', NULL, NULL, NULL, 'Sin Recibo', NULL, NULL, NULL, NULL, NULL, 306592  , 'Sin OC', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 257640  , 0, NULL, NULL, NULL, NULL, 'Del Giro', 48952  , NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, NULL, NULL, 0, '202006', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'Reclamado',0 , 'COM')";
                                    String n = DefinicionDTE_Control + "('RCP', 96510970, '6', 'Maderas Arauco S.A.'                       , NULL, " + RutEmpresaCF + ",'" + DigiEmpresaCF + "', '', 56 , " + i + ", '" + PeriodoEMISCF + "-22' , NULL, 'Recibido', CAST(N'" + PeriodoEMISCF + "-22 10:07:38.000' AS DateTime), CAST(N'" + PeriodoEMISCF + "-10 09:01:15.480' AS DateTime), NULL, 888033, 'NO Cargado', NULL, 'Reclamado', NULL, 'NO Cedido', NULL, NULL, NULL, NULL, NULL, NULL, 'Sin Respuesta', NULL, NULL, NULL, 'Sin Recibo', NULL, NULL, NULL, NULL, NULL, 1418528 , 'Sin OC', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1192040 , 0, NULL, NULL, NULL, NULL, 'Del Giro', 226488 , NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, NULL, NULL, 0, '202006', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'Reclamado',0 , 'COM')";
                                    String o = DefinicionDTE_Control + "('RCP', 96510970, '6', 'Maderas Arauco S.A.'                       , NULL, " + RutEmpresaCF + ",'" + DigiEmpresaCF + "', '', 61 , " + i + ", '" + PeriodoEMISCF + "-22' , NULL, 'Recibido', CAST(N'" + PeriodoEMISCF + "-22 10:04:35.000' AS DateTime), CAST(N'" + PeriodoEMISCF + "-10 09:01:15.480' AS DateTime), NULL, 888033, 'NO Cargado', NULL, 'Reclamado', NULL, 'NO Cedido', NULL, NULL, NULL, NULL, NULL, NULL, 'Sin Respuesta', NULL, NULL, NULL, 'Sin Recibo', NULL, NULL, NULL, NULL, NULL, 545264  , 'Sin OC', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 458205  , 0, NULL, NULL, NULL, NULL, 'Del Giro', 87059  , NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, NULL, NULL, 0, '202006', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'Reclamado',0 , 'COM')";
                                    String p = DefinicionDTE_Control + "('RCP', 96510970, '6', 'Maderas Arauco S.A.'                       , NULL, " + RutEmpresaCF + ",'" + DigiEmpresaCF + "', '', 61 , " + i + ", '" + PeriodoEMISCF + "-22' , NULL, 'Recibido', CAST(N'" + PeriodoEMISCF + "-22 10:07:36.000' AS DateTime), CAST(N'" + PeriodoEMISCF + "-10 09:01:15.480' AS DateTime), NULL, 888033, 'NO Cargado', NULL, 'Reclamado', NULL, 'NO Cedido', NULL, NULL, NULL, NULL, NULL, NULL, 'Sin Respuesta', NULL, NULL, NULL, 'Sin Recibo', NULL, NULL, NULL, NULL, NULL, 4873450 , 'Sin OC', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 4095336 , 0, NULL, NULL, NULL, NULL, 'Del Giro', 778114 , NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, NULL, NULL, 0, '202006', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'Reclamado',0 , 'COM')";
                                    String kk = DefinicionDTE_Control + "('RCP', 96510970, '6', 'Maderas Arauco S.A.'                       , NULL, " + RutEmpresaCF + ",'" + DigiEmpresaCF + "', '', 61 , " + i + ", '" + PeriodoEMISCF + "-22' , NULL, 'Recibido', CAST(N'" + PeriodoEMISCF + "-22 10:07:36.000' AS DateTime), CAST(N'" + PeriodoEMISCF + "-10 09:01:15.480' AS DateTime), NULL, 888033, 'NO Cargado', NULL, 'Reclamado', NULL, 'NO Cedido', NULL, NULL, NULL, NULL, NULL, NULL, 'Sin Respuesta', NULL, NULL, NULL, 'Sin Recibo', NULL, NULL, NULL, NULL, NULL, 3839792 , 'Sin OC', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 3226716 , 0, NULL, NULL, NULL, NULL, 'Del Giro', 613076 , NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, NULL, NULL, 0, '202006', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'Reclamado',0 , 'COM')";
                                    String aa = DefinicionDTE_Control + "('RCP', 96510970, '6', 'Maderas Arauco S.A.'                       , NULL, " + RutEmpresaCF + ",'" + DigiEmpresaCF + "', '', 61 , " + i + ", '" + PeriodoEMISCF + "-22' , NULL, 'Recibido', CAST(N'" + PeriodoEMISCF + "-22 10:07:34.000' AS DateTime), CAST(N'" + PeriodoEMISCF + "-10 09:01:15.480' AS DateTime), NULL, 888033, 'NO Cargado', NULL, 'Reclamado', NULL, 'NO Cedido', NULL, NULL, NULL, NULL, NULL, NULL, 'Sin Respuesta', NULL, NULL, NULL, 'Sin Recibo', NULL, NULL, NULL, NULL, NULL, 942603  , 'Sin OC', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 792103  , 0, NULL, NULL, NULL, NULL, 'Del Giro', 150500 , NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, NULL, NULL, 0, '202006', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'Reclamado',0 , 'COM')";

                                    string[] Items = { a, b, c, d, f, g, h, ii, j, k, m, n, o, p, kk, aa };

                                    int ItemsSS = GetRandomInt(0, Items.Length);

                                    Insert = Items[ItemsSS];

                                    String Query = Insert;
                                    // int Folioquery = Convert.ToInt32(Foliodesde);
                                    conexionCLOUDCF.EjecutarSql(Query);
                                    conexionCLOUDCF.CerraBD();
                                }
                            }
                            break;
                        #endregion

                        case "RCV_CompraRegistro":
                            break;

                        #region RCV_Venta
                        case "RCV_Venta":
                            ConexionBD conexionCLOUDCFCorrVen = new ConexionBD(AmbienteCF);
                            conexionCLOUDCFCorrVen.abrirBD();

                            String Queryven = definicionARCH_DTE_INFO_SII + "(645, 'InsertDirecto','DTER', CAST(N'" + PeriodoEMISCF + "-02 12:51:39.130' AS DateTime),'ING', 'Carga exitosa'," +
                                            "" + RutEmpresaCF + ",'" + DigiEmpresaCF + "', 'SODIMAC', 10, 1,0 ,0)";

                            conexionCLOUDCFCorrVen.EjecutarSql(Queryven);
                            String CORR_ARCHVen = conexionCLOUDCFCorrVen.DevolverCorr_arch();
                            conexionCLOUDCFCorrVen.CerraBD();

                            if (tablaCF == "DTE_TEMP")  //hay que sacar el corr_arch de la tabla ARCH_DTE_INFO_SII
                            {
                                for (int i = Convert.ToInt32(FoliodesdeCF); i <= FoliohastaCF; i++)
                                {
                                    ConexionBD conexionCLOUDCF = new ConexionBD(AmbienteCF);
                                    conexionCLOUDCF.abrirBD();
                                    String a = DefinicionDTE_TEMP + " ('EMI', 'SII', '" + PeriodoCF + "',  " + RutEmpresaCF + ",'" + DigiEmpresaCF + "', '', NULL, 14374971 , '1', 'CLAUDIA FERNANDEZ CONTRER', 33, " + i + " , '" + PeriodoEMISCF + "-15', NULL, '" + PeriodoEMISCF + "-01 08:37:28', NULL, NULL, NULL, NULL, NULL, 'Sin Recibo', NULL, 12158 , 0, 2310 , 14468 , 'Sin OC', NULL, 'Del Giro', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, '', '', 0, 0, 0, 0, 0, '', '', '', '0', NULL, 0, 1 , 0, 0, 0, NULL, NULL, NULL, 65515137, " + CORR_ARCHVen + ", NULL, NULL, NULL, 'Venta', NULL, 'VEN')";
                                    String b = DefinicionDTE_TEMP + " ('EMI', 'SII', '" + PeriodoCF + "',  " + RutEmpresaCF + ",'" + DigiEmpresaCF + "', '', NULL, 77021835 , '7', 'ESQUINA 21 SPA'           , 33, " + i + " , '" + PeriodoEMISCF + "-15', NULL, '" + PeriodoEMISCF + "-01 08:37:28', NULL, NULL, NULL, NULL, NULL, 'Sin Recibo', NULL, 78681 , 0, 14949, 93630 , 'Sin OC', NULL, 'Del Giro', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, '', '', 0, 0, 0, 0, 0, '', '', '', '0', NULL, 0, 1 , 0, 0, 0, NULL, NULL, NULL, 65515137, " + CORR_ARCHVen + ", NULL, NULL, NULL, 'Venta', NULL, 'VEN')";
                                    String c = DefinicionDTE_TEMP + " ('EMI', 'SII', '" + PeriodoCF + "',  " + RutEmpresaCF + ",'" + DigiEmpresaCF + "', '', NULL, 77138194 , '4', 'CHENE-ELEC EIRL'          , 33, " + i + " , '" + PeriodoEMISCF + "-15', NULL, '" + PeriodoEMISCF + "-01 08:50:17', NULL, NULL, NULL, NULL, NULL, 'Sin Recibo', NULL, 114614, 0, 21777, 136391, 'Sin OC', NULL, 'Del Giro', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, '', '', 0, 0, 0, 0, 0, '', '', '', '0', NULL, 0, 1 , 0, 0, 0, NULL, NULL, NULL, 65515137, " + CORR_ARCHVen + ", NULL, NULL, NULL, 'Venta', NULL, 'VEN')";
                                    String d = DefinicionDTE_TEMP + " ('EMI', 'SII', '" + PeriodoCF + "',  " + RutEmpresaCF + ",'" + DigiEmpresaCF + "', '', NULL, 76507696 , 'K', 'INVERSIONES MALADETA LTDA', 33, " + i + " , '" + PeriodoEMISCF + "-15', NULL, '" + PeriodoEMISCF + "-01 08:50:17', NULL, NULL, NULL, NULL, NULL, 'Sin Recibo', NULL, 131873, 0, 25056, 156929, 'Sin OC', NULL, 'Del Giro', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, '', '', 0, 0, 0, 0, 0, '', '', '', '0', NULL, 0, 1 , 0, 0, 0, NULL, NULL, NULL, 65515137, " + CORR_ARCHVen + ", NULL, NULL, NULL, 'Venta', NULL, 'VEN')";
                                    String f = DefinicionDTE_TEMP + " ('EMI', 'SII', '" + PeriodoCF + "',  " + RutEmpresaCF + ",'" + DigiEmpresaCF + "', '', NULL, 76315947 , '7', 'COMERCIALIZADORA SOLARGAS', 33, " + i + " , '" + PeriodoEMISCF + "-15', NULL, '" + PeriodoEMISCF + "-01 08:50:17', NULL, NULL, NULL, NULL, NULL, 'Sin Recibo', NULL, 10630 , 0, 2020 , 12650 , 'Sin OC', NULL, 'Del Giro', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, '', '', 0, 0, 0, 0, 0, '', '', '', '0', NULL, 0, 1 , 0, 0, 0, NULL, NULL, NULL, 65515137, " + CORR_ARCHVen + ", NULL, NULL, NULL, 'Venta', NULL, 'VEN')";
                                    String g = DefinicionDTE_TEMP + " ('EMI', 'SII', '" + PeriodoCF + "',  " + RutEmpresaCF + ",'" + DigiEmpresaCF + "', '', NULL, 76775579 , '1', 'INGENIERIA Y PROYECTOS AD', 33, " + i + " , '" + PeriodoEMISCF + "-15', NULL, '" + PeriodoEMISCF + "-01 08:50:17', NULL, NULL, NULL, NULL, NULL, 'Sin Recibo', NULL, 241203, 0, 45829, 287032, 'Sin OC', NULL, 'Del Giro', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, '', '', 0, 0, 0, 0, 0, '', '', '', '0', NULL, 0, 1 , 0, 0, 0, NULL, NULL, NULL, 65679951, " + CORR_ARCHVen + ", NULL, NULL, NULL, 'Venta', NULL, 'VEN')";
                                    String h = DefinicionDTE_TEMP + " ('EMI', 'SII', '" + PeriodoCF + "',  " + RutEmpresaCF + ",'" + DigiEmpresaCF + "', '', NULL, 76687879 , '2', 'PATRICIO ENRIQUE RAMIREZ' , 33, " + i + " , '" + PeriodoEMISCF + "-15', NULL, '" + PeriodoEMISCF + "-01 08:50:17', NULL, NULL, NULL, NULL, NULL, 'Sin Recibo', NULL, 21000 , 0, 3990 , 24990 , 'Sin OC', NULL, 'Del Giro', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, '', '', 0, 0, 0, 0, 0, '', '', '', '0', NULL, 0, 1 , 0, 0, 0, NULL, NULL, NULL, 65679951, " + CORR_ARCHVen + ", NULL, NULL, NULL, 'Venta', NULL, 'VEN')";
                                    String ii = DefinicionDTE_TEMP + " ('EMI', 'SII','" + PeriodoCF + "', " + RutEmpresaCF + ",'" + DigiEmpresaCF + "', '', NULL, 78048910 , '3', 'SOC DE TRANSPORTES SAE LT', 33,  " + i + " , '" + PeriodoEMISCF + "-15', NULL, '" + PeriodoEMISCF + "-01 09:03:22', NULL, NULL, NULL, NULL, NULL, 'Sin Recibo', NULL, 40976 , 0, 7785 , 48761 , 'Sin OC', NULL, 'Del Giro', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, '', '', 0, 0, 0, 0, 0, '', '', '', '0', NULL, 0, 1 , 0, 0, 0, NULL, NULL, NULL, 65679951, " + CORR_ARCHVen + ", NULL, NULL, NULL, 'Venta', NULL, 'VEN')";
                                    String j = DefinicionDTE_TEMP + " ('EMI', 'SII', '" + PeriodoCF + "',  " + RutEmpresaCF + ",'" + DigiEmpresaCF + "', '', NULL, 77138194 , '4', 'CHENE-ELEC EIRL'          , 33, " + i + " , '" + PeriodoEMISCF + "-15', NULL, '" + PeriodoEMISCF + "-01 09:03:22', NULL, NULL, NULL, NULL, NULL, 'Sin Recibo', NULL, 18530 , 0, 3521 , 22051 , 'Sin OC', NULL, 'Del Giro', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, '', '', 0, 0, 0, 0, 0, '', '', '', '0', NULL, 0, 1 , 0, 0, 0, NULL, NULL, NULL, 65515137, " + CORR_ARCHVen + ", NULL, NULL, NULL, 'Venta', NULL, 'VEN')";
                                    String k = DefinicionDTE_TEMP + " ('EMI', 'SII', '" + PeriodoCF + "',  " + RutEmpresaCF + ",'" + DigiEmpresaCF + "', '', NULL, 11153417 , '9', 'MARCOS ANTONIO REYES SILV', 33, " + i + " , '" + PeriodoEMISCF + "-15', NULL, '" + PeriodoEMISCF + "-01 09:03:22', NULL, NULL, NULL, NULL, NULL, 'Sin Recibo', NULL, 42871 , 0, 8145 , 51016 , 'Sin OC', NULL, 'Del Giro', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, '', '', 0, 0, 0, 0, 0, '', '', '', '0', NULL, 0, 1 , 0, 0, 0, NULL, NULL, NULL, 66397661, " + CORR_ARCHVen + ", NULL, NULL, NULL, 'Venta', NULL, 'VEN')";
                                    String m = DefinicionDTE_TEMP + " ('EMI', 'SII', '" + PeriodoCF + "',  " + RutEmpresaCF + ",'" + DigiEmpresaCF + "', '', NULL, 77136918 , '9', 'TERRAFIRME SPA'           , 33, " + i + " , '" + PeriodoEMISCF + "-15', NULL, '" + PeriodoEMISCF + "-01 09:03:22', NULL, NULL, NULL, NULL, NULL, 'Sin Recibo', NULL, 240584, 0, 45711, 286295, 'Sin OC', NULL, 'Del Giro', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, '', '', 0, 0, 0, 0, 0, '', '', '', '0', NULL, 0, 1 , 0, 0, 0, NULL, NULL, NULL, 66397661, " + CORR_ARCHVen + ", NULL, NULL, NULL, 'Venta', NULL, 'VEN')";
                                    String n = DefinicionDTE_TEMP + " ('EMI', 'SII', '" + PeriodoCF + "',  " + RutEmpresaCF + ",'" + DigiEmpresaCF + "', '', NULL, 76813063 , '9', 'CONSTRUCTORA Y MANTENCION', 33, " + i + " , '" + PeriodoEMISCF + "-15', NULL, '" + PeriodoEMISCF + "-01 09:03:22', NULL, NULL, NULL, NULL, NULL, 'Sin Recibo', NULL, 40142 , 0, 7627 , 47769 , 'Sin OC', NULL, 'Del Giro', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, '', '', 0, 0, 0, 0, 0, '', '', '', '0', NULL, 0, 1 , 0, 0, 0, NULL, NULL, NULL, 81701361, " + CORR_ARCHVen + ", NULL, NULL, NULL, 'Venta', NULL, 'VEN')";
                                    String o = DefinicionDTE_TEMP + " ('EMI', 'SII', '" + PeriodoCF + "',  " + RutEmpresaCF + ",'" + DigiEmpresaCF + "', '', NULL, 13115995 , '1', 'JAVIER DOM LLANQUIN NANCUL', 33," + i + " , '" + PeriodoEMISCF + "-15', NULL, '" + PeriodoEMISCF + "-01 09:03:22', NULL, NULL, NULL, NULL, NULL, 'Sin Recibo', NULL, 129769, 0, 24656, 154425, 'Sin OC', NULL, 'Del Giro', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, '', '', 0, 0, 0, 0, 0, '', '', '', '0', NULL, 0, 1 , 0, 0, 0, NULL, NULL, NULL, 66397661, " + CORR_ARCHVen + ", NULL, NULL, NULL, 'Venta', NULL, 'VEN')";
                                    String p = DefinicionDTE_TEMP + " ('EMI', 'SII', '" + PeriodoCF + "',  " + RutEmpresaCF + ",'" + DigiEmpresaCF + "', '', NULL, 8842323  , '2', 'LUIS AGUILAR PEREZ'        , 33," + i + " , '" + PeriodoEMISCF + "-15', NULL, '" + PeriodoEMISCF + "-01 09:03:22', NULL, NULL, NULL, NULL, NULL, 'Sin Recibo', NULL, 25648 , 0, 4873 , 30521 , 'Sin OC', NULL, 'Del Giro', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, '', '', 0, 0, 0, 0, 0, '', '', '', '0', NULL, 0, 1 , 0, 0, 0, NULL, NULL, NULL, 65515137, " + CORR_ARCHVen + ", NULL, NULL, NULL, 'Venta', NULL, 'VEN')";
                                    String kk = DefinicionDTE_TEMP + " ('EMI', 'SII','" + PeriodoCF + "', " + RutEmpresaCF + ",'" + DigiEmpresaCF + "', '', NULL, 76011302 , '6', 'SOCIEDAD CONSTRUCTORA R'   , 33, " + i + " , '" + PeriodoEMISCF + "-15', NULL, '" + PeriodoEMISCF + "-01 09:03:22', NULL, NULL, NULL, NULL, NULL, 'Sin Recibo', NULL, 83491 , 0, 15863, 99354 , 'Sin OC', NULL, 'Del Giro', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, '', '', 0, 0, 0, 0, 0, '', '', '', '0', NULL, 0, 1 , 0, 0, 0, NULL, NULL, NULL, 65679951, " + CORR_ARCHVen + ", NULL, NULL, NULL, 'Venta', NULL, 'VEN')";
                                    String aa = DefinicionDTE_TEMP + " ('EMI', 'SII','" + PeriodoCF + "', " + RutEmpresaCF + ",'" + DigiEmpresaCF + "', '', NULL, 5378725  , '8', 'MARIA SUSANA CABRERA BELL' , 33, " + i + " , '" + PeriodoEMISCF + "-15', NULL, '" + PeriodoEMISCF + "-01 09:03:22', NULL, NULL, NULL, NULL, NULL, 'Sin Recibo', NULL, 166176, 0, 31573, 197749, 'Sin OC', NULL, 'Del Giro', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, '', '', 0, 0, 0, 0, 0, '', '', '', '0', NULL, 0, 1 , 0, 0, 0, NULL, NULL, NULL, 66397661, " + CORR_ARCHVen + ", NULL, NULL, NULL, 'Venta', NULL, 'VEN')";


                                    string[] Items = { a, b, c, d, f, g, h, ii, j, k, m, n, o, p, kk, aa };

                                    int ItemsSS = GetRandomInt(0, Items.Length);

                                    Insert = Items[ItemsSS];

                                    String Query = Insert;
                                    // int Folioquery = Convert.ToInt32(Foliodesde);
                                    conexionCLOUDCF.EjecutarSql(Query);
                                    conexionCLOUDCF.CerraBD();
                                }
                            }
                            else if (tablaCF == "DTE_CONTROL")
                            {
                                for (int i = Convert.ToInt32(FoliodesdeCF); i <= FoliohastaCF; i++)
                                {
                                    ConexionBD conexionCLOUDCF = new ConexionBD(AmbienteCF);
                                    conexionCLOUDCF.abrirBD();

                                    String a = DefinicionDTE_Control + "('EMI', " + RutEmpresaCF + ",'" + DigiEmpresaCF + "', '', NULL, 5378725  , '8', 'MARIA SUSANA CABRERA BELL' , 34, " + i + ",'" + PeriodoEMISCF + "-01', NULL, 'Recibido', CAST(N'" + PeriodoEMISCF + "-01 09:03:22.000' AS DateTime), CAST(N'" + PeriodoEMISCF + "-09 17:45:52.207' AS DateTime), NULL, 888033 , 'NO Cargado', NULL, 'Sin Evento', NULL, 'NO Cedido', NULL, NULL, NULL, NULL, NULL, NULL, 'Sin Respuesta', NULL, NULL, NULL, 'Sin Recibo', NULL, NULL, NULL, NULL, NULL, 197749, 'Sin OC', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 166176, 0, 31573 , NULL, NULL, NULL, 'Del Giro', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, '202006', 0, 0, 0, 0, 0, NULL, NULL, 0, 0, 0, 0,0, '', '', '', '0', NULL, 0, 1, 0, 0,0, NULL, NULL, NULL, 66397661, 'Venta', 0 , 'VEN')";
                                    String b = DefinicionDTE_Control + "('EMI', " + RutEmpresaCF + ",'" + DigiEmpresaCF + "', '', NULL, 8842323  , '2', 'LUIS AGUILAR PEREZ'        , 34, " + i + ",'" + PeriodoEMISCF + "-01', NULL, 'Recibido', CAST(N'" + PeriodoEMISCF + "-01 09:03:22.000' AS DateTime), CAST(N'" + PeriodoEMISCF + "-09 17:45:52.207' AS DateTime), NULL, 888033 , 'NO Cargado', NULL, 'Sin Evento', NULL, 'NO Cedido', NULL, NULL, NULL, NULL, NULL, NULL, 'Sin Respuesta', NULL, NULL, NULL, 'Sin Recibo', NULL, NULL, NULL, NULL, NULL, 30521 , 'Sin OC', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 25648 , 0, 4873  , NULL, NULL, NULL, 'Del Giro', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, '202006', 0, 0, 0, 0, 0, NULL, NULL, 0, 0, 0, 0,0, '', '', '', '0', NULL, 0, 1, 0, 0,0, NULL, NULL, NULL, 65515137, 'Venta', 0 , 'VEN')";
                                    String c = DefinicionDTE_Control + "('EMI', " + RutEmpresaCF + ",'" + DigiEmpresaCF + "', '', NULL, 11153417 , '9', 'MARCOS ANTONIO REYES SILV' , 34, " + i + ",'" + PeriodoEMISCF + "-01', NULL, 'Recibido', CAST(N'" + PeriodoEMISCF + "-01 09:03:22.000' AS DateTime), CAST(N'" + PeriodoEMISCF + "-09 17:45:52.207' AS DateTime), NULL, 888033 , 'NO Cargado', NULL, 'Sin Evento', NULL, 'NO Cedido', NULL, NULL, NULL, NULL, NULL, NULL, 'Sin Respuesta', NULL, NULL, NULL, 'Sin Recibo', NULL, NULL, NULL, NULL, NULL, 51016 , 'Sin OC', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 42871 , 0, 8145  , NULL, NULL, NULL, 'Del Giro', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, '202006', 0, 0, 0, 0, 0, NULL, NULL, 0, 0, 0, 0,0, '', '', '', '0', NULL, 0, 1, 0, 0,0, NULL, NULL, NULL, 66397661, 'Venta', 0 , 'VEN')";
                                    String d = DefinicionDTE_Control + "('EMI', " + RutEmpresaCF + ",'" + DigiEmpresaCF + "', '', NULL, 13115995 , '1', 'JAVIER DOM LLANQUIN NANCUL', 34, " + i + ",'" + PeriodoEMISCF + "-01', NULL, 'Recibido', CAST(N'" + PeriodoEMISCF + "-01 09:03:22.000' AS DateTime), CAST(N'" + PeriodoEMISCF + "-09 17:45:52.207' AS DateTime), NULL, 888033 , 'NO Cargado', NULL, 'Sin Evento', NULL, 'NO Cedido', NULL, NULL, NULL, NULL, NULL, NULL, 'Sin Respuesta', NULL, NULL, NULL, 'Sin Recibo', NULL, NULL, NULL, NULL, NULL, 154425, 'Sin OC', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 129769, 0, 24656 , NULL, NULL, NULL, 'Del Giro', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, '202006', 0, 0, 0, 0, 0, NULL, NULL, 0, 0, 0, 0,0, '', '', '', '0', NULL, 0, 1, 0, 0,0, NULL, NULL, NULL, 66397661, 'Venta', 0 , 'VEN')";
                                    String f = DefinicionDTE_Control + "('EMI', " + RutEmpresaCF + ",'" + DigiEmpresaCF + "', '', NULL, 14374971 , '1', 'CLAUDIA FERNANDEZ CONTRER' , 34, " + i + ",'" + PeriodoEMISCF + "-01', NULL, 'Recibido', CAST(N'" + PeriodoEMISCF + "-01 08:37:28.000' AS DateTime), CAST(N'" + PeriodoEMISCF + "-09 17:45:52.207' AS DateTime), NULL, 888033 , 'NO Cargado', NULL, 'Sin Evento', NULL, 'NO Cedido', NULL, NULL, NULL, NULL, NULL, NULL, 'Sin Respuesta', NULL, NULL, NULL, 'Sin Recibo', NULL, NULL, NULL, NULL, NULL, 14468 , 'Sin OC', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 12158 , 0, 2310  , NULL, NULL, NULL, 'Del Giro', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, '202006', 0, 0, 0, 0, 0, NULL, NULL, 0, 0, 0, 0,0, '', '', '', '0', NULL, 0, 1, 0, 0,0, NULL, NULL, NULL, 65515137, 'Venta', 0 , 'VEN')";
                                    String g = DefinicionDTE_Control + "('EMI', " + RutEmpresaCF + ",'" + DigiEmpresaCF + "', '', NULL, 76011302 , '6', 'SOCIEDAD CONSTRUCTORA R'   , 34, " + i + ",'" + PeriodoEMISCF + "-01', NULL, 'Recibido', CAST(N'" + PeriodoEMISCF + "-01 09:03:22.000' AS DateTime), CAST(N'" + PeriodoEMISCF + "-09 17:45:52.207' AS DateTime), NULL, 888033 , 'NO Cargado', NULL, 'Sin Evento', NULL, 'NO Cedido', NULL, NULL, NULL, NULL, NULL, NULL, 'Sin Respuesta', NULL, NULL, NULL, 'Sin Recibo', NULL, NULL, NULL, NULL, NULL, 99354 , 'Sin OC', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 83491 , 0, 15863 , NULL, NULL, NULL, 'Del Giro', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, '202006', 0, 0, 0, 0, 0, NULL, NULL, 0, 0, 0, 0,0, '', '', '', '0', NULL, 0, 1, 0, 0,0, NULL, NULL, NULL, 65679951, 'Venta', 0 , 'VEN')";
                                    String h = DefinicionDTE_Control + "('EMI', " + RutEmpresaCF + ",'" + DigiEmpresaCF + "', '', NULL, 76315947 , '7', 'COMERCIALIZADORA SOLARGAS' , 34, " + i + ",'" + PeriodoEMISCF + "-01', NULL, 'Recibido', CAST(N'" + PeriodoEMISCF + "-01 08:50:17.000' AS DateTime), CAST(N'" + PeriodoEMISCF + "-09 17:45:52.207' AS DateTime), NULL, 888033 , 'NO Cargado', NULL, 'Sin Evento', NULL, 'NO Cedido', NULL, NULL, NULL, NULL, NULL, NULL, 'Sin Respuesta', NULL, NULL, NULL, 'Sin Recibo', NULL, NULL, NULL, NULL, NULL, 12650 , 'Sin OC', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 10630 , 0, 2020  , NULL, NULL, NULL, 'Del Giro', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, '202006', 0, 0, 0, 0, 0, NULL, NULL, 0, 0, 0, 0,0, '', '', '', '0', NULL, 0, 1, 0, 0,0, NULL, NULL, NULL, 65515137, 'Venta', 0 , 'VEN')";
                                    String ii = DefinicionDTE_Control + "('EMI', " + RutEmpresaCF + ",'" + DigiEmpresaCF + "', '', NULL, 76507696 , 'K', 'INVERSIONES MALADETA LTDA' ,34, " + i + ",'" + PeriodoEMISCF + "-01', NULL, 'Recibido', CAST(N'" + PeriodoEMISCF + "-01 08:50:17.000' AS DateTime), CAST(N'" + PeriodoEMISCF + "-09 17:45:52.207' AS DateTime), NULL, 888033 , 'NO Cargado', NULL, 'Sin Evento', NULL, 'NO Cedido', NULL, NULL, NULL, NULL, NULL, NULL, 'Sin Respuesta', NULL, NULL, NULL, 'Sin Recibo', NULL, NULL, NULL, NULL, NULL, 156929, 'Sin OC', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 131873, 0, 25056 , NULL, NULL, NULL, 'Del Giro', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, '202006', 0, 0, 0, 0, 0, NULL, NULL, 0, 0, 0, 0,0, '', '', '', '0', NULL, 0, 1, 0, 0,0, NULL, NULL, NULL, 65515137, 'Venta', 0 , 'VEN')";
                                    String j = DefinicionDTE_Control + "('EMI', " + RutEmpresaCF + ",'" + DigiEmpresaCF + "', '', NULL, 76687879 , '2', 'PATRICIO ENRIQUE RAMIREZ'  , 34, " + i + ",'" + PeriodoEMISCF + "-01', NULL, 'Recibido', CAST(N'" + PeriodoEMISCF + "-01 08:50:17.000' AS DateTime), CAST(N'" + PeriodoEMISCF + "-09 17:45:52.207' AS DateTime), NULL, 888033 , 'NO Cargado', NULL, 'Sin Evento', NULL, 'NO Cedido', NULL, NULL, NULL, NULL, NULL, NULL, 'Sin Respuesta', NULL, NULL, NULL, 'Sin Recibo', NULL, NULL, NULL, NULL, NULL, 24990., 'Sin OC', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 21000 , 0, 3990  , NULL, NULL, NULL, 'Del Giro', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, '202006', 0, 0, 0, 0, 0, NULL, NULL, 0, 0, 0, 0,0, '', '', '', '0', NULL, 0, 1, 0, 0,0, NULL, NULL, NULL, 65679951, 'Venta', 0 , 'VEN')";
                                    String k = DefinicionDTE_Control + "('EMI', " + RutEmpresaCF + ",'" + DigiEmpresaCF + "', '', NULL, 76775579 , '1', 'INGENIERIA Y PROYECTOS AD' , 34, " + i + ",'" + PeriodoEMISCF + "-01', NULL, 'Recibido', CAST(N'" + PeriodoEMISCF + "-01 08:50:17.000' AS DateTime), CAST(N'" + PeriodoEMISCF + "-09 17:45:52.207' AS DateTime), NULL, 888033 , 'NO Cargado', NULL, 'Sin Evento', NULL, 'NO Cedido', NULL, NULL, NULL, NULL, NULL, NULL, 'Sin Respuesta', NULL, NULL, NULL, 'Sin Recibo', NULL, NULL, NULL, NULL, NULL, 287032, 'Sin OC', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 241203, 0, 45829 , NULL, NULL, NULL, 'Del Giro', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, '202006', 0, 0, 0, 0, 0, NULL, NULL, 0, 0, 0, 0,0, '', '', '', '0', NULL, 0, 1, 0, 0,0, NULL, NULL, NULL, 65679951, 'Venta', 0 , 'VEN')";
                                    String m = DefinicionDTE_Control + "('EMI', " + RutEmpresaCF + ",'" + DigiEmpresaCF + "', '', NULL, 76813063 , '9', 'CONSTRUCTORA Y MANTENCION' , 34, " + i + ",'" + PeriodoEMISCF + "-01', NULL, 'Recibido', CAST(N'" + PeriodoEMISCF + "-01 09:03:22.000' AS DateTime), CAST(N'" + PeriodoEMISCF + "-09 17:45:52.207' AS DateTime), NULL, 888033 , 'NO Cargado', NULL, 'Sin Evento', NULL, 'NO Cedido', NULL, NULL, NULL, NULL, NULL, NULL, 'Sin Respuesta', NULL, NULL, NULL, 'Sin Recibo', NULL, NULL, NULL, NULL, NULL, 47769 , 'Sin OC', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 40142 , 0, 7627  , NULL, NULL, NULL, 'Del Giro', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, '202006', 0, 0, 0, 0, 0, NULL, NULL, 0, 0, 0, 0,0, '', '', '', '0', NULL, 0, 1, 0, 0,0, NULL, NULL, NULL, 81701361, 'Venta', 0 , 'VEN')";
                                    String n = DefinicionDTE_Control + "('EMI', " + RutEmpresaCF + ",'" + DigiEmpresaCF + "', '', NULL, 77021835 , '7', 'ESQUINA 21 SPA'            , 34, " + i + ",'" + PeriodoEMISCF + "-01', NULL, 'Recibido', CAST(N'" + PeriodoEMISCF + "-01 08:37:28.000' AS DateTime), CAST(N'" + PeriodoEMISCF + "-09 17:45:52.207' AS DateTime), NULL, 888033 , 'NO Cargado', NULL, 'Sin Evento', NULL, 'NO Cedido', NULL, NULL, NULL, NULL, NULL, NULL, 'Sin Respuesta', NULL, NULL, NULL, 'Sin Recibo', NULL, NULL, NULL, NULL, NULL, 93630 , 'Sin OC', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 78681 , 0, 14949 , NULL, NULL, NULL, 'Del Giro', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, '202006', 0, 0, 0, 0, 0, NULL, NULL, 0, 0, 0, 0,0, '', '', '', '0', NULL, 0, 1, 0, 0,0, NULL, NULL, NULL, 65515137, 'Venta', 0 , 'VEN')";
                                    String o = DefinicionDTE_Control + "('EMI', " + RutEmpresaCF + ",'" + DigiEmpresaCF + "', '', NULL, 77136918 , '9', 'TERRAFIRME SPA'            , 34, " + i + ",'" + PeriodoEMISCF + "-01', NULL, 'Recibido', CAST(N'" + PeriodoEMISCF + "-01 09:03:22.000' AS DateTime), CAST(N'" + PeriodoEMISCF + "-09 17:45:52.207' AS DateTime), NULL, 888033 , 'NO Cargado', NULL, 'Sin Evento', NULL, 'NO Cedido', NULL, NULL, NULL, NULL, NULL, NULL, 'Sin Respuesta', NULL, NULL, NULL, 'Sin Recibo', NULL, NULL, NULL, NULL, NULL, 286295, 'Sin OC', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 240584, 0, 45711 , NULL, NULL, NULL, 'Del Giro', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, '202006', 0, 0, 0, 0, 0, NULL, NULL, 0, 0, 0, 0,0, '', '', '', '0', NULL, 0, 1, 0, 0,0, NULL, NULL, NULL, 66397661, 'Venta', 0 , 'VEN')";
                                    String p = DefinicionDTE_Control + "('EMI', " + RutEmpresaCF + ",'" + DigiEmpresaCF + "', '', NULL, 77138194 , '4', 'CHENE-ELEC EIRL'           , 34, " + i + ",'" + PeriodoEMISCF + "-01', NULL, 'Recibido', CAST(N'" + PeriodoEMISCF + "-01 08:50:17.000' AS DateTime), CAST(N'" + PeriodoEMISCF + "-09 17:45:52.207' AS DateTime), NULL, 888033 , 'NO Cargado', NULL, 'Sin Evento', NULL, 'NO Cedido', NULL, NULL, NULL, NULL, NULL, NULL, 'Sin Respuesta', NULL, NULL, NULL, 'Sin Recibo', NULL, NULL, NULL, NULL, NULL, 136391, 'Sin OC', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 114614, 0, 21777 , NULL, NULL, NULL, 'Del Giro', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, '202006', 0, 0, 0, 0, 0, NULL, NULL, 0, 0, 0, 0,0, '', '', '', '0', NULL, 0, 1, 0, 0,0, NULL, NULL, NULL, 65515137, 'Venta', 0 , 'VEN')";
                                    String kk = DefinicionDTE_Control + "('EMI', " + RutEmpresaCF + ",'" + DigiEmpresaCF + "', '', NULL, 77138194 , '4', 'CHENE-ELEC EIRL'           ,34, " + i + ",'" + PeriodoEMISCF + "-01', NULL, 'Recibido', CAST(N'" + PeriodoEMISCF + "-01 09:03:22.000' AS DateTime), CAST(N'" + PeriodoEMISCF + "-09 17:45:52.207' AS DateTime), NULL, 888033 , 'NO Cargado', NULL, 'Sin Evento', NULL, 'NO Cedido', NULL, NULL, NULL, NULL, NULL, NULL, 'Sin Respuesta', NULL, NULL, NULL, 'Sin Recibo', NULL, NULL, NULL, NULL, NULL, 22051 , 'Sin OC', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 18530 , 0, 3521  , NULL, NULL, NULL, 'Del Giro', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, '202006', 0, 0, 0, 0, 0, NULL, NULL, 0, 0, 0, 0,0, '', '', '', '0', NULL, 0, 1, 0, 0,0, NULL, NULL, NULL, 65515137, 'Venta', 0 , 'VEN')";
                                    String aa = DefinicionDTE_Control + "('EMI', " + RutEmpresaCF + ",'" + DigiEmpresaCF + "', '', NULL, 78048910 , '3', 'SOC DE TRANSPORTES SAE LT' ,34, " + i + ",'" + PeriodoEMISCF + "-01', NULL, 'Recibido', CAST(N'" + PeriodoEMISCF + "-01 09:03:22.000' AS DateTime), CAST(N'" + PeriodoEMISCF + "-09 17:45:52.207' AS DateTime), NULL, 888033 , 'NO Cargado', NULL, 'Sin Evento', NULL, 'NO Cedido', NULL, NULL, NULL, NULL, NULL, NULL, 'Sin Respuesta', NULL, NULL, NULL, 'Sin Recibo', NULL, NULL, NULL, NULL, NULL, 48761 , 'Sin OC', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 40976 , 0, 7785  , NULL, NULL, NULL, 'Del Giro', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, '202006', 0, 0, 0, 0, 0, NULL, NULL, 0, 0, 0, 0,0, '', '', '', '0', NULL, 0, 1, 0, 0,0, NULL, NULL, NULL, 65679951, 'Venta', 0 , 'VEN')";

                                    string[] Items = { a, b, c, d, f, g, h, ii, j, k, m, n, o, p, kk, aa };

                                    int ItemsSS = GetRandomInt(0, Items.Length);

                                    Insert = Items[ItemsSS];

                                    String Query = Insert;
                                    // int Folioquery = Convert.ToInt32(Foliodesde);
                                    conexionCLOUDCF.EjecutarSql(Query);
                                    conexionCLOUDCF.CerraBD();
                                }
                            }
                            break;
                        #endregion
                        #region BHR
                        case "BHR":

                            ConexionBD conexionCLOUDCFCorrBHR = new ConexionBD(AmbienteCF);
                            conexionCLOUDCFCorrBHR.abrirBD();

                            if (tablaCF == "DTE_TEMP")  //hay que sacar el corr_arch de la tabla ARCH_DTE_INFO_SII
                            {
                                for (int i = Convert.ToInt32(FoliodesdeCF); i <= FoliohastaCF; i++)
                                {
                                    ConexionBD conexionCLOUDCF = new ConexionBD(AmbienteCF);
                                    conexionCLOUDCF.abrirBD();
                                    String a = DefinicionDTE_TEMP + " ('BHR', 'SII', NULL, 11415502, '0', 'PAOLA ANDREA VON KNORRING CIFU', 'NO', " + RutEmpresaCF + ",'" + DigiEmpresaCF + "', '   DBNET INGENIERIA DE SOFTWARE S A ', -1, " + i + " , 'Nov  1 2020 12:00AM', " +
                                    "NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'VIG', 'Nov  1 2020 12:00AM', 691996, NULL, 83350, 775346,  'N', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL," +
                                    "NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'VIG', 'Nov  1 2020 12:00AM', NULL)";

                                    String b = DefinicionDTE_TEMP + " ('BHR', 'SII', NULL, 9958456 , '4', 'FERNANDO MIGUEL CUBILLOS GOMEZ', 'NO', " + RutEmpresaCF + ",'" + DigiEmpresaCF + "', '   DBNET INGENIERIA DE SOFTWARE S A ', -1, " + i + " , 'Nov  2 2020 12:00AM', " +
                                    "NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'VIG', 'Nov  2 2020 12:00AM', 322926, NULL, 38896, 361822,  'N', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, " +
                                    "NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'VIG', 'Nov  2 2020 12:00AM', NULL)";

                                    String c = DefinicionDTE_TEMP + " ('BHR', 'SII', NULL, 9958456 , '4', 'FERNANDO MIGUEL CUBILLOS GOMEZ', 'NO', " + RutEmpresaCF + ",'" + DigiEmpresaCF + "', '   DBNET INGENIERIA DE SOFTWARE S A ', -1, " + i + " , 'Nov  2 2020 12:00AM'," +
                                    "NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'VIG', 'Nov  2 2020 12:00AM', 356243, NULL, 42909, 399152,  'N', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, " +
                                    "NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'VIG', 'Nov  2 2020 12:00AM', NULL)";

                                    String d = DefinicionDTE_TEMP + " ('BHR', 'SII', NULL, 9958456 , '4', 'FERNANDO MIGUEL CUBILLOS GOMEZ', 'NO', " + RutEmpresaCF + ",'" + DigiEmpresaCF + "', '   DBNET INGENIERIA DE SOFTWARE S A ', -1, " + i + " , 'Nov  2 2020 12:00AM', " +
                                        "NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'VIG', 'Nov  2 2020 12:00AM', 174278, NULL, 20991, 195269,  'N', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, " +
                                        "NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'VIG', 'Nov  2 2020 12:00AM', NULL)";

                                    String f = DefinicionDTE_TEMP + " ('BHR', 'SII', NULL, 9958456 , '4', 'FERNANDO MIGUEL CUBILLOS GOMEZ', 'NO', " + RutEmpresaCF + ",'" + DigiEmpresaCF + "', '   DBNET INGENIERIA DE SOFTWARE S A ', -1, " + i + " , 'Nov  2 2020 12:00AM', " +
                                        "NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'VIG', 'Nov  2 2020 12:00AM', 123020, NULL, 14817, 137837,  'N', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, " +
                                        "NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'VIG', 'Nov  2 2020 12:00AM', NULL)";

                                    String g = DefinicionDTE_TEMP + " ('BHR', 'SII', NULL, 9958456 , '4', 'FERNANDO MIGUEL CUBILLOS GOMEZ', 'NO', " + RutEmpresaCF + ",'" + DigiEmpresaCF + "', '   DBNET INGENIERIA DE SOFTWARE S A ', -1, " + i + " , 'Nov  2 2020 12:00AM'," +
                                        "NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'VIG', 'Nov  2 2020 12:00AM', 161463, NULL, 19448, 180911,  'N', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL," +
                                        "NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'VIG', 'Nov  2 2020 12:00AM', NULL)";

                                    String h = DefinicionDTE_TEMP + " ('BHR', 'SII', NULL, 9958456 , '4', 'FERNANDO MIGUEL CUBILLOS GOMEZ', 'NO', " + RutEmpresaCF + ",'" + DigiEmpresaCF + "', '   DBNET INGENIERIA DE SOFTWARE S A ', -1, " + i + " , 'Nov  2 2020 12:00AM'," +
                                        "NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'VIG', 'Nov  2 2020 12:00AM', 120456, NULL, 14509, 134965,  'N', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, " +
                                        "NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'VIG', 'Nov  2 2020 12:00AM', NULL)";

                                    String ii = DefinicionDTE_TEMP + " ('BHR', 'SII', NULL, 15311845, '0', 'RAUL ALEJANDRO ESPARZA LANDERO', 'NO', " + RutEmpresaCF + ",'" + DigiEmpresaCF + "', '   DBNET INGENIERIA DE SOFTWARE S A ', -1, " + i + " , 'Nov  4 2020 12:00AM'," +
                                        "NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'VIG', 'Nov  4 2020 12:00AM', 172230, NULL, 20745, 192975,  'N', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, " +
                                        "NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'VIG', 'Nov  4 2020 12:00AM', NULL)";

                                    String j = DefinicionDTE_TEMP + " ('BHR', 'SII', NULL, 15311845, '0', 'RAUL ALEJANDRO ESPARZA LANDERO', 'NO', " + RutEmpresaCF + ",'" + DigiEmpresaCF + "', '   DBNET INGENIERIA DE SOFTWARE S A ', -1, " + i + " , 'Nov  4 2020 12:00AM', " +
                                        "NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'VIG', 'Nov  4 2020 12:00AM', 172230, NULL, 20745, 192975,  'N', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, " +
                                        "NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'VIG', 'Nov  4 2020 12:00AM', NULL)";

                                    String k = DefinicionDTE_TEMP + " ('BHR', 'SII', NULL, 15311845, '0', 'RAUL ALEJANDRO ESPARZA LANDERO', 'NO', " + RutEmpresaCF + ",'" + DigiEmpresaCF + "', '   DBNET INGENIERIA DE SOFTWARE S A ', -1, " + i + " , 'Nov  4 2020 12:00AM', " +
                                        "NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'VIG', 'Nov  4 2020 12:00AM', 369065, NULL, 44453, 413518,  'N', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL," +
                                        "NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'VIG', 'Nov  4 2020 12:00AM', NULL)";

                                    String m = DefinicionDTE_TEMP + " ('BHR', 'SII', NULL, 15311845, '0', 'RAUL ALEJANDRO ESPARZA LANDERO', 'NO', " + RutEmpresaCF + ",'" + DigiEmpresaCF + "', '   DBNET INGENIERIA DE SOFTWARE S A ', -1, " + i + " , 'Nov  4 2020 12:00AM', " +
                                        "NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'VIG', 'Nov  4 2020 12:00AM', 98417,  NULL, 11854, 110271,  'N', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL," +
                                        "NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'VIG', 'Nov  4 2020 12:00AM', NULL)";

                                    String n = DefinicionDTE_TEMP + " ('BHR', 'SII', NULL, 16429988, '0', 'VIOLETA ANAHI HURTADO ESCUDERO', 'NO', " + RutEmpresaCF + ",'" + DigiEmpresaCF + "', '   DBNET INGENIERIA DE SOFTWARE S A ', -1, " + i + " , 'Nov  5 2020 12:00AM'," +
                                        "NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'VIG', 'Nov  5 2020 12:00AM', 65000,  NULL, 7829,  72829,   'N', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, " +
                                        "NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'VIG', 'Nov  5 2020 12:00AM', NULL)";

                                    String o = DefinicionDTE_TEMP + " ('BHR', 'SII', NULL, 14351139, '1', 'ALEJANDRO GIOVANNI IBANEZ CALA', 'NO', " + RutEmpresaCF + ",'" + DigiEmpresaCF + "', '   DBNET INGENIERIA DE SOFTWARE S A ', -1, " + i + " , 'Nov 11 2020 12:00AM'," +
                                        "NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'VIG', 'Nov 11 2020 12:00AM', 142800, NULL, 17200, 160000,  'N', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL," +
                                        "NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'VIG', 'Nov 11 2020 12:00AM', NULL)";

                                    String p = DefinicionDTE_TEMP + " ('BHR', 'SII', NULL, 18911866, 'K', 'FRANCIS ALBERTO ELIER HERRERA',  'NO', " + RutEmpresaCF + ",'" + DigiEmpresaCF + "', '   DBNET INGENIERIA DE SOFTWARE S A ', -1, " + i + " , 'Nov 16 2020 12:00AM'," +
                                        "NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'VIG', 'Nov 16 2020 12:00AM', 102494, NULL, 12345, 114839,  'N', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, " +
                                        "NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'VIG', 'Nov 16 2020 12:00AM', NULL)";

                                    String kk = DefinicionDTE_TEMP + " ('BHR', 'SII', NULL, 18911866, 'K', 'FRANCIS ALBERTO ELIER HERRERA',  'NO', " + RutEmpresaCF + ",'" + DigiEmpresaCF + "', '   DBNET INGENIERIA DE SOFTWARE S A ', -1, " + i + " , 'Nov 16 2020 12:00AM'," +
                                        "NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'VIG', 'Nov 16 2020 12:00AM', 102494, NULL, 12345, 114839,  'N', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, " +
                                        "NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'VIG', 'Nov 16 2020 12:00AM', NULL)";

                                    String aa = DefinicionDTE_TEMP + " ('BHR', 'SII', NULL, 9702536 , '3', 'CECILIA PAZ MONGE BABICH',       'NO', " + RutEmpresaCF + ",'" + DigiEmpresaCF + "', '   DBNET INGENIERIA DE SOFTWARE S A ', -1, " + i + " , 'Nov 17 2020 12:00AM', " +
                                        "NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'VIG', 'Nov 17 2020 12:00AM', 562275, NULL, 67725, 630000,  'N', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, " +
                                        "NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'VIG', 'Nov 17 2020 12:00AM', NULL)";

                                    String bb = DefinicionDTE_TEMP + " ('BHR', 'SII', NULL, 9702536 , '3', 'CECILIA PAZ MONGE BABICH',       'NO', " + RutEmpresaCF + ",'" + DigiEmpresaCF + "', '   DBNET INGENIERIA DE SOFTWARE S A ', -1, " + i + " , 'Nov 17 2020 12:00AM', " +
                                        "NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'VIG', 'Nov 17 2020 12:00AM', 562275, NULL, 67725, 630000,  'N', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL," +
                                        "NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'VIG', 'Nov 17 2020 12:00AM', NULL)";

                                    String cc = DefinicionDTE_TEMP + " ('BHR', 'SII', NULL, 15311845, '0', 'RAUL ALEJANDRO ESPARZA LANDERO', 'NO', " + RutEmpresaCF + ",'" + DigiEmpresaCF + "', '   DBNET INGENIERIA DE SOFTWARE S A ', -1, " + i + " , 'Nov 18 2020 12:00AM', " +
                                        "NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'VIG', 'Nov 18 2020 12:00AM', 196776, NULL, 23701, 220477,  'N', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, " +
                                        "NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'VIG', 'Nov 18 2020 12:00AM', NULL)";

                                    String dd = DefinicionDTE_TEMP + " ('BHR', 'SII', NULL, 15311845, '0', 'RAUL ALEJANDRO ESPARZA LANDERO', 'NO', " + RutEmpresaCF + ",'" + DigiEmpresaCF + "', '   DBNET INGENIERIA DE SOFTWARE S A ', -1, " + i + " , 'Nov 18 2020 12:00AM'," +
                                        "NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'VIG', 'Nov 18 2020 12:00AM', 49194 , NULL, 5925,  55119 ,  'N', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, " +
                                        "NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'VIG', 'Nov 18 2020 12:00AM', NULL)";



                                    string[] Items = { a, b, c, d, f, g, h, ii, j, k, m, n, o, p, kk, aa, bb, cc, dd };

                                    int ItemsSS = GetRandomInt(0, Items.Length);

                                    Insert = Items[ItemsSS];

                                    String Query = Insert;
                                    // int Folioquery = Convert.ToInt32(Foliodesde);
                                    conexionCLOUDCF.EjecutarSql(Query);
                                    conexionCLOUDCF.CerraBD();
                                }
                            }
                            else if (tablaCF == "DTE_CONTROL")
                            {
                                for (int i = Convert.ToInt32(FoliodesdeCF); i <= FoliohastaCF; i++)
                                {
                                    ConexionBD conexionCLOUDCF = new ConexionBD(AmbienteCF);
                                    conexionCLOUDCF.abrirBD();

                                    String a = DefinicionDTE_Control + "('BHR', 15311845, '0', 'RAUL ALEJANDRO ESPARZA LANDERO', 'NO', " + RutEmpresaCF + ",'" + DigiEmpresaCF + "', '   DBNET INGENIERIA DE SOFTWARE S A ', -1, " + i + ", CAST(N'2020-11-18' AS Date), 0 , 'Recibida', CAST(N'2020-11-18 00:00:00.000' AS DateTime), CAST(N'2020-11-09 15:22:42.227' AS DateTime), NULL, NULL, 'No Cargada', NULL, 'VIG', CAST(N'2020-11-09 15:22:42.227' AS DateTime), 'No Aplica', NULL, NULL, NULL, NULL, NULL, NULL, 'No Aplica', NULL, NULL, NULL, 'VIG', CAST(N'2020-11-09 15:22:42.227' AS DateTime), 196776 , NULL, 23701, 220477, NULL, 'N', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL)";
                                    String b = DefinicionDTE_Control + "('BHR', 15311845, '0', 'RAUL ALEJANDRO ESPARZA LANDERO', 'NO', " + RutEmpresaCF + ",'" + DigiEmpresaCF + "', '   DBNET INGENIERIA DE SOFTWARE S A ', -1, " + i + ", CAST(N'2020-11-18' AS Date), 0 , 'Recibida', CAST(N'2020-11-18 00:00:00.000' AS DateTime), CAST(N'2020-11-09 15:22:42.227' AS DateTime), NULL, NULL, 'No Cargada', NULL, 'VIG', CAST(N'2020-11-09 15:22:42.227' AS DateTime), 'No Aplica', NULL, NULL, NULL, NULL, NULL, NULL, 'No Aplica', NULL, NULL, NULL, 'VIG', CAST(N'2020-11-09 15:22:42.227' AS DateTime), 49194  , NULL, 5925 , 55119 , NULL, 'N', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL)";
                                    String c = DefinicionDTE_Control + "('BHR', 11415502, '0', 'PAOLA ANDREA VON KNORRING CIFU', 'NO', " + RutEmpresaCF + ",'" + DigiEmpresaCF + "', '   DBNET INGENIERIA DE SOFTWARE S A ', -1, " + i + ", CAST(N'2020-11-01' AS Date), 0 , 'Recibida', CAST(N'2020-11-01 00:00:00.000' AS DateTime), CAST(N'2020-11-09 15:22:42.213' AS DateTime), NULL, NULL, 'No Cargada', NULL, 'VIG', CAST(N'2020-11-09 15:22:42.213' AS DateTime), 'No Aplica', NULL, NULL, NULL, NULL, NULL, NULL, 'No Aplica', NULL, NULL, NULL, 'VIG', CAST(N'2020-11-09 15:22:42.213' AS DateTime), 691996 , NULL, 83350, 775346, NULL, 'N', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL)";
                                    String d = DefinicionDTE_Control + "('BHR', 9958456 , '4', 'FERNANDO MIGUEL CUBILLOS GOMEZ', 'NO', " + RutEmpresaCF + ",'" + DigiEmpresaCF + "', '   DBNET INGENIERIA DE SOFTWARE S A ', -1, " + i + ", CAST(N'2020-11-02' AS Date), 0 , 'Recibida', CAST(N'2020-11-02 00:00:00.000' AS DateTime), CAST(N'2020-11-09 15:22:42.213' AS DateTime), NULL, NULL, 'No Cargada', NULL, 'VIG', CAST(N'2020-11-09 15:22:42.213' AS DateTime), 'No Aplica', NULL, NULL, NULL, NULL, NULL, NULL, 'No Aplica', NULL, NULL, NULL, 'VIG', CAST(N'2020-11-09 15:22:42.213' AS DateTime), 322926 , NULL, 38896, 361822, NULL, 'N', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL)";
                                    String f = DefinicionDTE_Control + "('BHR', 9958456 , '4', 'FERNANDO MIGUEL CUBILLOS GOMEZ', 'NO', " + RutEmpresaCF + ",'" + DigiEmpresaCF + "', '   DBNET INGENIERIA DE SOFTWARE S A ', -1, " + i + ", CAST(N'2020-11-02' AS Date), 0 , 'Recibida', CAST(N'2020-11-02 00:00:00.000' AS DateTime), CAST(N'2020-11-09 15:22:42.217' AS DateTime), NULL, NULL, 'No Cargada', NULL, 'VIG', CAST(N'2020-11-09 15:22:42.217' AS DateTime), 'No Aplica', NULL, NULL, NULL, NULL, NULL, NULL, 'No Aplica', NULL, NULL, NULL, 'VIG', CAST(N'2020-11-09 15:22:42.217' AS DateTime), 356243 , NULL, 42909, 399152, NULL, 'N', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL)";
                                    String g = DefinicionDTE_Control + "('BHR', 9958456 , '4', 'FERNANDO MIGUEL CUBILLOS GOMEZ', 'NO', " + RutEmpresaCF + ",'" + DigiEmpresaCF + "', '   DBNET INGENIERIA DE SOFTWARE S A ', -1, " + i + ", CAST(N'2020-11-02' AS Date), 0 , 'Recibida', CAST(N'2020-11-02 00:00:00.000' AS DateTime), CAST(N'2020-11-09 15:22:42.217' AS DateTime), NULL, NULL, 'No Cargada', NULL, 'VIG', CAST(N'2020-11-09 15:22:42.217' AS DateTime), 'No Aplica', NULL, NULL, NULL, NULL, NULL, NULL, 'No Aplica', NULL, NULL, NULL, 'VIG', CAST(N'2020-11-09 15:22:42.217' AS DateTime), 174278 , NULL, 20991, 195269, NULL, 'N', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL)";
                                    String h = DefinicionDTE_Control + "('BHR', 9958456 , '4', 'FERNANDO MIGUEL CUBILLOS GOMEZ', 'NO', " + RutEmpresaCF + ",'" + DigiEmpresaCF + "', '   DBNET INGENIERIA DE SOFTWARE S A ', -1, " + i + ", CAST(N'2020-11-02' AS Date), 0 , 'Recibida', CAST(N'2020-11-02 00:00:00.000' AS DateTime), CAST(N'2020-11-09 15:22:42.217' AS DateTime), NULL, NULL, 'No Cargada', NULL, 'VIG', CAST(N'2020-11-09 15:22:42.217' AS DateTime), 'No Aplica', NULL, NULL, NULL, NULL, NULL, NULL, 'No Aplica', NULL, NULL, NULL, 'VIG', CAST(N'2020-11-09 15:22:42.217' AS DateTime), 123020 , NULL, 14817, 137837, NULL, 'N', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL)";
                                    String ii = DefinicionDTE_Control + "('BHR', 9958456 , '4', 'FERNANDO MIGUEL CUBILLOS GOMEZ', 'NO'," + RutEmpresaCF + ",'" + DigiEmpresaCF + "', '   DBNET INGENIERIA DE SOFTWARE S A ', -1, " + i + ", CAST(N'2020-11-02' AS Date), 0 , 'Recibida', CAST(N'2020-11-02 00:00:00.000' AS DateTime), CAST(N'2020-11-09 15:22:42.217' AS DateTime), NULL, NULL, 'No Cargada', NULL, 'VIG', CAST(N'2020-11-09 15:22:42.217' AS DateTime), 'No Aplica', NULL, NULL, NULL, NULL, NULL, NULL, 'No Aplica', NULL, NULL, NULL, 'VIG', CAST(N'2020-11-09 15:22:42.217' AS DateTime), 161463 , NULL, 19448, 180911, NULL, 'N', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL)";
                                    String j = DefinicionDTE_Control + "('BHR', 9958456 , '4', 'FERNANDO MIGUEL CUBILLOS GOMEZ', 'NO', " + RutEmpresaCF + ",'" + DigiEmpresaCF + "', '   DBNET INGENIERIA DE SOFTWARE S A ', -1, " + i + ", CAST(N'2020-11-02' AS Date), 0 , 'Recibida', CAST(N'2020-11-02 00:00:00.000' AS DateTime), CAST(N'2020-11-09 15:22:42.217' AS DateTime), NULL, NULL, 'No Cargada', NULL, 'VIG', CAST(N'2020-11-09 15:22:42.217' AS DateTime), 'No Aplica', NULL, NULL, NULL, NULL, NULL, NULL, 'No Aplica', NULL, NULL, NULL, 'VIG', CAST(N'2020-11-09 15:22:42.217' AS DateTime), 120456 , NULL, 14509, 134965, NULL, 'N', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL)";
                                    String k = DefinicionDTE_Control + "('BHR', 15311845, '0', 'RAUL ALEJANDRO ESPARZA LANDERO', 'NO', " + RutEmpresaCF + ",'" + DigiEmpresaCF + "', '   DBNET INGENIERIA DE SOFTWARE S A ', -1, " + i + ", CAST(N'2020-11-04' AS Date), 0 , 'Recibida', CAST(N'2020-11-04 00:00:00.000' AS DateTime), CAST(N'2020-11-09 15:22:42.220' AS DateTime), NULL, NULL, 'No Cargada', NULL, 'VIG', CAST(N'2020-11-09 15:22:42.220' AS DateTime), 'No Aplica', NULL, NULL, NULL, NULL, NULL, NULL, 'No Aplica', NULL, NULL, NULL, 'VIG', CAST(N'2020-11-09 15:22:42.220' AS DateTime), 172230 , NULL, 20745, 192975, NULL, 'N', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL)";
                                    String m = DefinicionDTE_Control + "('BHR', 15311845, '0', 'RAUL ALEJANDRO ESPARZA LANDERO', 'NO', " + RutEmpresaCF + ",'" + DigiEmpresaCF + "', '   DBNET INGENIERIA DE SOFTWARE S A ', -1, " + i + ", CAST(N'2020-11-04' AS Date), 0 , 'Recibida', CAST(N'2020-11-04 00:00:00.000' AS DateTime), CAST(N'2020-11-09 15:22:42.220' AS DateTime), NULL, NULL, 'No Cargada', NULL, 'VIG', CAST(N'2020-11-09 15:22:42.220' AS DateTime), 'No Aplica', NULL, NULL, NULL, NULL, NULL, NULL, 'No Aplica', NULL, NULL, NULL, 'VIG', CAST(N'2020-11-09 15:22:42.220' AS DateTime), 172230 , NULL, 20745, 192975, NULL, 'N', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL)";
                                    String n = DefinicionDTE_Control + "('BHR', 15311845, '0', 'RAUL ALEJANDRO ESPARZA LANDERO', 'NO', " + RutEmpresaCF + ",'" + DigiEmpresaCF + "', '   DBNET INGENIERIA DE SOFTWARE S A ', -1, " + i + ", CAST(N'2020-11-04' AS Date), 0 , 'Recibida', CAST(N'2020-11-04 00:00:00.000' AS DateTime), CAST(N'2020-11-09 15:22:42.220' AS DateTime), NULL, NULL, 'No Cargada', NULL, 'VIG', CAST(N'2020-11-09 15:22:42.220' AS DateTime), 'No Aplica', NULL, NULL, NULL, NULL, NULL, NULL, 'No Aplica', NULL, NULL, NULL, 'VIG', CAST(N'2020-11-09 15:22:42.220' AS DateTime), 369065 , NULL, 44453, 413518, NULL, 'N', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL)";
                                    String o = DefinicionDTE_Control + "('BHR', 15311845, '0', 'RAUL ALEJANDRO ESPARZA LANDERO', 'NO', " + RutEmpresaCF + ",'" + DigiEmpresaCF + "', '   DBNET INGENIERIA DE SOFTWARE S A ', -1, " + i + ", CAST(N'2020-11-04' AS Date), 0 , 'Recibida', CAST(N'2020-11-04 00:00:00.000' AS DateTime), CAST(N'2020-11-09 15:22:42.220' AS DateTime), NULL, NULL, 'No Cargada', NULL, 'VIG', CAST(N'2020-11-09 15:22:42.220' AS DateTime), 'No Aplica', NULL, NULL, NULL, NULL, NULL, NULL, 'No Aplica', NULL, NULL, NULL, 'VIG', CAST(N'2020-11-09 15:22:42.220' AS DateTime), 98417  , NULL, 11854, 110271, NULL, 'N', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL)";
                                    String p = DefinicionDTE_Control + "('BHR', 16429988, '0', 'VIOLETA ANAHI HURTADO ESCUDERO', 'NO', " + RutEmpresaCF + ",'" + DigiEmpresaCF + "', '   DBNET INGENIERIA DE SOFTWARE S A ', -1, " + i + ", CAST(N'2020-11-05' AS Date), 0 , 'Recibida', CAST(N'2020-11-05 00:00:00.000' AS DateTime), CAST(N'2020-11-09 15:22:42.220' AS DateTime), NULL, NULL, 'No Cargada', NULL, 'VIG', CAST(N'2020-11-09 15:22:42.220' AS DateTime), 'No Aplica', NULL, NULL, NULL, NULL, NULL, NULL, 'No Aplica', NULL, NULL, NULL, 'VIG', CAST(N'2020-11-09 15:22:42.220' AS DateTime), 65000  , NULL, 7829 , 72829 , NULL, 'N', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL)";
                                    String kk = DefinicionDTE_Control + "('BHR', 14351139, '1', 'ALEJANDRO GIOVANNI IBANEZ CALA', 'NO'," + RutEmpresaCF + ",'" + DigiEmpresaCF + "', '   DBNET INGENIERIA DE SOFTWARE S A ', -1, " + i + ", CAST(N'2020-11-11' AS Date), 0 , 'Recibida', CAST(N'2020-11-11 00:00:00.000' AS DateTime), CAST(N'2020-11-09 15:22:42.220' AS DateTime), NULL, NULL, 'No Cargada', NULL, 'VIG', CAST(N'2020-11-09 15:22:42.220' AS DateTime), 'No Aplica', NULL, NULL, NULL, NULL, NULL, NULL, 'No Aplica', NULL, NULL, NULL, 'VIG', CAST(N'2020-11-09 15:22:42.220' AS DateTime), 142800 , NULL, 17200, 160000, NULL, 'N', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL)";
                                    String aa = DefinicionDTE_Control + "('BHR', 18911866, 'K', 'FRANCIS ALBERTO ELIER HERRERA',  'NO'," + RutEmpresaCF + ",'" + DigiEmpresaCF + "', '   DBNET INGENIERIA DE SOFTWARE S A ', -1, " + i + ", CAST(N'2020-11-16' AS Date), 0 , 'Recibida', CAST(N'2020-11-16 00:00:00.000' AS DateTime), CAST(N'2020-11-09 15:22:42.223' AS DateTime), NULL, NULL, 'No Cargada', NULL, 'VIG', CAST(N'2020-11-09 15:22:42.223' AS DateTime), 'No Aplica', NULL, NULL, NULL, NULL, NULL, NULL, 'No Aplica', NULL, NULL, NULL, 'VIG', CAST(N'2020-11-09 15:22:42.223' AS DateTime), 102494 , NULL, 12345, 114839, NULL, 'N', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL)";
                                    String bb = DefinicionDTE_Control + "('BHR', 18911866, 'K', 'FRANCIS ALBERTO ELIER HERRERA',  'NO'," + RutEmpresaCF + ",'" + DigiEmpresaCF + "', '   DBNET INGENIERIA DE SOFTWARE S A ', -1, " + i + ", CAST(N'2020-11-16' AS Date), 0 , 'Recibida', CAST(N'2020-11-16 00:00:00.000' AS DateTime), CAST(N'2020-11-09 15:22:42.223' AS DateTime), NULL, NULL, 'No Cargada', NULL, 'VIG', CAST(N'2020-11-09 15:22:42.223' AS DateTime), 'No Aplica', NULL, NULL, NULL, NULL, NULL, NULL, 'No Aplica', NULL, NULL, NULL, 'VIG', CAST(N'2020-11-09 15:22:42.223' AS DateTime), 102494 , NULL, 12345, 114839, NULL, 'N', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL)";
                                    String cc = DefinicionDTE_Control + "('BHR', 9702536 , '3', 'CECILIA PAZ MONGE BABICH',       'NO'," + RutEmpresaCF + ",'" + DigiEmpresaCF + "', '   DBNET INGENIERIA DE SOFTWARE S A ', -1, " + i + ", CAST(N'2020-11-17' AS Date), 0 , 'Recibida', CAST(N'2020-11-17 00:00:00.000' AS DateTime), CAST(N'2020-11-09 15:22:42.223' AS DateTime), NULL, NULL, 'No Cargada', NULL, 'VIG', CAST(N'2020-11-09 15:22:42.223' AS DateTime), 'No Aplica', NULL, NULL, NULL, NULL, NULL, NULL, 'No Aplica', NULL, NULL, NULL, 'VIG', CAST(N'2020-11-09 15:22:42.223' AS DateTime), 562275 , NULL, 67725, 630000, NULL, 'N', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL)";
                                    String dd = DefinicionDTE_Control + "('BHR', 9702536 , '3', 'CECILIA PAZ MONGE BABICH',       'NO'," + RutEmpresaCF + ",'" + DigiEmpresaCF + "', '   DBNET INGENIERIA DE SOFTWARE S A ', -1, " + i + ", CAST(N'2020-11-17' AS Date), 0 , 'Recibida', CAST(N'2020-11-17 00:00:00.000' AS DateTime), CAST(N'2020-11-09 15:22:42.223' AS DateTime), NULL, NULL, 'No Cargada', NULL, 'VIG', CAST(N'2020-11-09 15:22:42.223' AS DateTime), 'No Aplica', NULL, NULL, NULL, NULL, NULL, NULL, 'No Aplica', NULL, NULL, NULL, 'VIG', CAST(N'2020-11-09 15:22:42.223' AS DateTime), 562275 , NULL, 67725, 630000, NULL, 'N', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL)";


                                    string[] Items = { a, b, c, d, f, g, h, ii, j, k, m, n, o, p, kk, aa, bb, cc, dd };

                                    int ItemsSS = GetRandomInt(0, Items.Length);

                                    Insert = Items[ItemsSS];

                                    String Query = Insert;
                                    // int Folioquery = Convert.ToInt32(Foliodesde);
                                    conexionCLOUDCF.EjecutarSql(Query);
                                    conexionCLOUDCF.CerraBD();
                                }
                            }
                            break;
                        #endregion
                        case "Cesiones":

                            ConexionBD conexionCLOUDCFCorrCES = new ConexionBD(AmbienteCF);
                            conexionCLOUDCFCorrCES.abrirBD();

                            String QueryCes = definicionARCH_DTE_INFO_SII + "(645, 'InsertDirecto','DTER', CAST(N'" + PeriodoEMISCF + "-02 12:51:39.130' AS DateTime),'ING', 'Carga exitosa'," +
                                            "" + RutEmpresaCF + ",'" + DigiEmpresaCF + "', 'SODIMAC', 10, 1,0 ,0)";

                            conexionCLOUDCFCorrCES.EjecutarSql(QueryCes);
                            String CORR_ARCHCES = conexionCLOUDCFCorrCES.DevolverCorr_arch();
                            conexionCLOUDCFCorrCES.CerraBD();

                            if (tablaCF == "DTE_TEMP")  //hay que sacar el corr_arch de la tabla ARCH_DTE_INFO_SII
                            {
                                for (int i = Convert.ToInt32(FoliodesdeCF); i <= FoliohastaCF; i++)
                                {
                                    ConexionBD conexionCLOUDCF = new ConexionBD(AmbienteCF);
                                    conexionCLOUDCF.abrirBD();

                                    String a = definicion_dte_cesion_sii_tmp + "( " + CORR_ARCHCES + ", 1 , 76717806 , '9', 'Cesion Vigente', " + RutEmpresaCF + ",'" + DigiEmpresaCF + "', 'null', 33 , 'Factura Electronica' ," + i + " , '" + PeriodoEMISCF + "-07', 835334 , 76717806 , '9', 'CRR COMUNICACION Y MAR8ETING DIGITAL SPA, PUDIENDO UTILIZAR COMO NOMBR', 'crubio@ehubard.com', 96885910 , '2', 'SOC. PROYECCION S.A.'               , 'ventas@todofactoring.cl'  , '" + PeriodoEMISCF + "-04 12:52', 835334,  '2030-10-07')";
                                    String b = definicion_dte_cesion_sii_tmp + "( " + CORR_ARCHCES + ", 1 , 76717806 , '9', 'Cesion Vigente', " + RutEmpresaCF + ",'" + DigiEmpresaCF + "', 'null', 33 , 'Factura Electronica' ," + i + " , '" + PeriodoEMISCF + "-09', 835334 , 76717806 , '9', 'CRR COMUNICACION Y MAR8ETING DIGITAL SPA, PUDIENDO UTILIZAR COMO NOMBR', 'crubio@ehubard.com', 96885910 , '2', 'SOC. PROYECCION S.A.'               , 'ventas@todofactoring.cl'  , '" + PeriodoEMISCF + "-04 12:52', 835334,  '2030-10-09')";
                                    String c = definicion_dte_cesion_sii_tmp + "( " + CORR_ARCHCES + ", 1 , 96751690 , '2', 'Cesion Vigente', " + RutEmpresaCF + ",'" + DigiEmpresaCF + "', 'null', 33 , 'Factura Electronica' ," + i + " , '" + PeriodoEMISCF + "-30', 791350 , 96751690 , '2', 'MASGRAFICA SPA' , 'facturacion@facturachile.cl', 76621380 , '4', 'FINAMERIS SERVICIOS FINANCIEROS S A', 'facturacionmipyme2@sii.cl', '" + PeriodoEMISCF + "-04 18:19', 791350,  '2030-12-17')";
                                    String d = definicion_dte_cesion_sii_tmp + "( " + CORR_ARCHCES + ", 1 , 96751690 , '2', 'Cesion Vigente', " + RutEmpresaCF + ",'" + DigiEmpresaCF + "', 'null', 33 , 'Factura Electronica' ," + i + " , '" + PeriodoEMISCF + "-15', 166600 , 96751690 , '2', 'MASGRAFICA SPA' , 'facturacion@facturachile.cl', 76621380 , '4', 'FINAMERIS SERVICIOS FINANCIEROS S A', 'facturacionmipyme2@sii.cl', '" + PeriodoEMISCF + "-04 18:25', 166600,  '2030-11-30')";
                                    String f = definicion_dte_cesion_sii_tmp + "( " + CORR_ARCHCES + ", 1 , 96751690 , '2', 'Cesion Vigente', " + RutEmpresaCF + ",'" + DigiEmpresaCF + "', 'null', 33 , 'Factura Electronica' ," + i + " , '" + PeriodoEMISCF + "-25', 392700 , 96751690 , '2', 'MASGRAFICA SPA' , 'facturacion@facturachile.cl', 76621380 , '4', 'FINAMERIS SERVICIOS FINANCIEROS S A', 'facturacionmipyme2@sii.cl', '" + PeriodoEMISCF + "-04 18:25', 392700,  '2030-12-10')";
                                    String g = definicion_dte_cesion_sii_tmp + "( " + CORR_ARCHCES + ", 1 , 76717806 , '9', 'Cesion Vigente', " + RutEmpresaCF + ",'" + DigiEmpresaCF + "', 'null', 33 , 'Factura Electronica' ," + i + " , '" + PeriodoEMISCF + "-06', 835332 , 76717806 , '9', 'CRR COMUNICACION Y MAR8ETING DIGITAL SPA, PUDIENDO UTILIZAR COMO NOMBR', 'crubio@ehubard.com', 96885910 , '2', 'SOC. PROYECCION S.A.'               , 'ventas@todofactoring.cl'  , '" + PeriodoEMISCF + "-07 11:40', 835332,  '2030-11-06')";
                                    String h = definicion_dte_cesion_sii_tmp + "( " + CORR_ARCHCES + ", 1 , 96751690 , '2', 'Cesion Vigente', " + RutEmpresaCF + ",'" + DigiEmpresaCF + "', 'null', 33 , 'Factura Electronica' ," + i + " , '" + PeriodoEMISCF + "-11', 7610812, 96751690 , '2', 'MASGRAFICA SPA'   , 'facturacion@facturachile.cl', 76621380 , '4', 'FINAMERIS SERVICIOS FINANCIEROS S A', 'facturacionmipyme2@sii.cl', '" + PeriodoEMISCF + "-11 12:17', 7610812, '2030-12-26')";
                                    String ii = definicion_dte_cesion_sii_tmp + "(" + CORR_ARCHCES + ", 1 , 76430588 , '4', 'Cesion Vigente', " + RutEmpresaCF + ",'" + DigiEmpresaCF + "', 'null', 33 , 'Factura Electronica'," + i + " , '" + PeriodoEMISCF + "-11', 595000 , 76430588 , '4', 'BPP&FRIENDS S.A'  , 'alberto.garrido@wolfbcpp.com'     , 76146246 , '6', 'FACTORCLIC8 S.A'                    , 'azancaner@factorclic8.cl' , '" + PeriodoEMISCF + "-13 13:16', 595000 , '2030-01-13')";
                                    String j = definicion_dte_cesion_sii_tmp + "( " + CORR_ARCHCES + ", 1 , 76430588 , '4', 'Cesion Vigente', " + RutEmpresaCF + ",'" + DigiEmpresaCF + "', 'null', 33 , 'Factura Electronica' ," + i + " , '" + PeriodoEMISCF + "-11', 595000 , 76430588 , '4', 'BPP&FRIENDS S.A'  , 'alberto.garrido@wolfbcpp.com'     , 76146246 , '6', 'FACTORCLIC8 SA'                     , 'azancaner@factorclic8.cl' , '" + PeriodoEMISCF + "-13 13:18', 595000 , '2030-01-13')";
                                    String k = definicion_dte_cesion_sii_tmp + "( " + CORR_ARCHCES + ", 1 , 96751690 , '2', 'Cesion Vigente', " + RutEmpresaCF + ",'" + DigiEmpresaCF + "', 'null', 33 , 'Factura Electronica' ," + i + " , '" + PeriodoEMISCF + "-14', 7056700, 96751690 , '2', 'MASGRAFICA SPA'   , 'facturacion@facturachile.cl'      , 76621380 , '4', 'FINAMERIS SERVICIOS FINANCIEROS S A', 'facturacionmipyme2@sii.cl', '" + PeriodoEMISCF + "-14 11:59', 7056700, '2030-12-16')";
                                    String m = definicion_dte_cesion_sii_tmp + "( " + CORR_ARCHCES + ", 1 , 96751690 , '2', 'Cesion Vigente', " + RutEmpresaCF + ",'" + DigiEmpresaCF + "', 'null', 33 , 'Factura Electronica' ," + i + " , '" + PeriodoEMISCF + "-14', 1319710, 96751690 , '2', 'MASGRAFICA SPA'   , 'facturacion@facturachile.cl'      , 76621380 , '4', 'FINAMERIS SERVICIOS FINANCIEROS S A', 'facturacionmipyme2@sii.cl', '" + PeriodoEMISCF + "-14 11:59', 1319710, '2030-12-16')";
                                    String n = definicion_dte_cesion_sii_tmp + "( " + CORR_ARCHCES + ", 1 , 96751690 , '2', 'Cesion Vigente', " + RutEmpresaCF + ",'" + DigiEmpresaCF + "', 'null', 33 , 'Factura Electronica' ," + i + " , '" + PeriodoEMISCF + "-18', 791350 , 96751690 , '2', 'MASGRAFICA SPA'   , 'facturacion@facturachile.cl'      , 76621380 , '4', 'FINAMERIS SERVICIOS FINANCIEROS S A', 'facturacionmipyme2@sii.cl', '" + PeriodoEMISCF + "-20 13:26', 791350 , '2030-01-02')";
                                    String o = definicion_dte_cesion_sii_tmp + "( " + CORR_ARCHCES + ", 1 , 96964510 , '6', 'Cesion Vigente', " + RutEmpresaCF + ",'" + DigiEmpresaCF + "', 'null', 33 , 'Factura Electronica' ," + i + " , '" + PeriodoEMISCF + "-06', 3825423, 96964510 , '6', 'COMUNICACIONES NETGLOBALIS S A' , 'antonio.hernandez@netglobalis.net', 76562786 , '9', 'BICE FACTORING S.A'                 , 'stefania.sanchez@bice.cl' , '" + PeriodoEMISCF + "-21 12:20', 3825423, '2030-12-06')";
                                    String p = definicion_dte_cesion_sii_tmp + "( " + CORR_ARCHCES + ", 1 , 96964510 , '6', 'Cesion Vigente', " + RutEmpresaCF + ",'" + DigiEmpresaCF + "', 'null', 33 , 'Factura Electronica' ," + i + " , '" + PeriodoEMISCF + "-14', 3822265, 96964510 , '6', 'COMUNICACIONES NETGLOBALIS S A' , 'antonio.hernandez@netglobalis.net', 76562786 , '9', 'BICE FACTORING S.A'                 , 'stefania.sanchez@bice.cl' , '" + PeriodoEMISCF + "-21 12:21', 3822265, '2030-12-14')";
                                    String kk = definicion_dte_cesion_sii_tmp + "(" + CORR_ARCHCES + ", 1 , 77063770 , '8', 'Cesion Vigente', " + RutEmpresaCF + ",'" + DigiEmpresaCF + "', 'null', 34 , 'Factura Exenta Electronica'," + i + " , '" + PeriodoEMISCF + "-14', 3245568, 77063770 , '8', 'PRAGMA INFORMATICA S.A.' , 'MSALINAS@PRAGMA.CL'               , 96667560 , '8', 'TANNER SERVICIOS FINANCIEROS S.A'   , 'venta.spf@tanner.cl'      , '" + PeriodoEMISCF + "-22 13:18', 3245568, '2030-01-10')";
                                    String aa = definicion_dte_cesion_sii_tmp + "(" + CORR_ARCHCES + ", 1 , 76430588 , '4', 'Cesion Vigente', " + RutEmpresaCF + ",'" + DigiEmpresaCF + "', 'null', 33 , 'Factura Electronica'," + i + " , '" + PeriodoEMISCF + "-23', 595000 , 76430588 , '4', 'BPP&FRIENDS S.A' , 'alberto.garrido@wolfbcpp.com'     , 96667560 , '8', 'TANNER SERVICIOS FINANCIEROS S.A'   , 'venta.spf@tanner.cl'      , '" + PeriodoEMISCF + "-26 12:31', 595000 , '2030-01-10')";

                                    string[] Items = { a, b, c, d, f, g, h, ii, j, k, m, n, o, p, kk, aa };

                                    int ItemsSS = GetRandomInt(0, Items.Length);

                                    Insert = Items[ItemsSS];

                                    String Query = Insert;
                                    // int Folioquery = Convert.ToInt32(Foliodesde);
                                    conexionCLOUDCF.EjecutarSqlCF(Query);
                                    conexionCLOUDCF.CerraBD();
                                }
                            }
                            else if (tablaCF == "DTE_CONTROL")
                            {
                                for (int i = Convert.ToInt32(FoliodesdeCF); i <= FoliohastaCF; i++)
                                {
                                    ConexionBD conexionCLOUDCF = new ConexionBD(AmbienteCF);
                                    conexionCLOUDCF.abrirBD();


                                    //string[] Items = { a, b, c, d, f, g, h, ii, j, k, m, n, o, p, kk, aa };

                                    // int ItemsSS = GetRandomInt(0, Items.Length);

                                    // Insert = Items[ItemsSS];

                                    String Query = Insert;
                                    // int Folioquery = Convert.ToInt32(Foliodesde);
                                    conexionCLOUDCF.EjecutarSql(Query);
                                    conexionCLOUDCF.CerraBD();
                                }
                            }
                            break;


                    }
                    break;
                #endregion


                #region CaseSQL
                case "SQL":
                    validarCampos();
                    switch (tipodescarga)
                    {
                        case "RCV_CompraNoIncluir":
                            break;
                        case "RCV_CompraPendiente":
                            break;
                        case "RCV_CompraReclamado":
                            break;
                        case "RCV_CompraRegistro":
                            break;
                        case "RCV_Venta":
                            break;
                        case "BHR":

                            ConexionBD conexionCLOUDCFCorrBHR = new ConexionBD(AmbienteCF);
                            conexionCLOUDCFCorrBHR.abrirBD();

                            if (tablaCF == "DTE_TEMP")  //hay que sacar el corr_arch de la tabla ARCH_DTE_INFO_SII
                            {
                                for (int i = Convert.ToInt32(FoliodesdeCF); i <= FoliohastaCF; i++)
                                {
                                    ConexionBD conexionCLOUDCF = new ConexionBD(AmbienteCF);
                                    conexionCLOUDCF.abrirBD();
                                    String a = DefinicionDTE_TEMP + " ('BHR', 'SII', NULL, 11415502, '0', 'PAOLA ANDREA VON KNORRING CIFU', 'NO', " + RutEmpresaCF + ",'" + DigiEmpresaCF + "', '   DBNET INGENIERIA DE SOFTWARE S A ', -1, " + i + " , 'Nov  1 2020 12:00AM', " +
                                    "NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'VIG', 'Nov  1 2020 12:00AM', 691996, NULL, 83350, 775346,  'N', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL," +
                                    "NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'VIG', 'Nov  1 2020 12:00AM', NULL)";

                                    String b = DefinicionDTE_TEMP + " ('BHR', 'SII', NULL, 9958456 , '4', 'FERNANDO MIGUEL CUBILLOS GOMEZ', 'NO', " + RutEmpresaCF + ",'" + DigiEmpresaCF + "', '   DBNET INGENIERIA DE SOFTWARE S A ', -1, " + i + " , 'Nov  2 2020 12:00AM', " +
                                    "NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'VIG', 'Nov  2 2020 12:00AM', 322926, NULL, 38896, 361822,  'N', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, " +
                                    "NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'VIG', 'Nov  2 2020 12:00AM', NULL)";

                                    String c = DefinicionDTE_TEMP + " ('BHR', 'SII', NULL, 9958456 , '4', 'FERNANDO MIGUEL CUBILLOS GOMEZ', 'NO', " + RutEmpresaCF + ",'" + DigiEmpresaCF + "', '   DBNET INGENIERIA DE SOFTWARE S A ', -1, " + i + " , 'Nov  2 2020 12:00AM'," +
                                     "NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'VIG', 'Nov  2 2020 12:00AM', 356243, NULL, 42909, 399152,  'N', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, " +
                                     "NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'VIG', 'Nov  2 2020 12:00AM', NULL)";

                                    String d = DefinicionDTE_TEMP + " ('BHR', 'SII', NULL, 9958456 , '4', 'FERNANDO MIGUEL CUBILLOS GOMEZ', 'NO', " + RutEmpresaCF + ",'" + DigiEmpresaCF + "', '   DBNET INGENIERIA DE SOFTWARE S A ', -1, " + i + " , 'Nov  2 2020 12:00AM', " +
                                     "NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'VIG', 'Nov  2 2020 12:00AM', 174278, NULL, 20991, 195269,  'N', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, " +
                                     "NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'VIG', 'Nov  2 2020 12:00AM', NULL)";

                                    String f = DefinicionDTE_TEMP + " ('BHR', 'SII', NULL, 9958456 , '4', 'FERNANDO MIGUEL CUBILLOS GOMEZ', 'NO', " + RutEmpresaCF + ",'" + DigiEmpresaCF + "', '   DBNET INGENIERIA DE SOFTWARE S A ', -1, " + i + " , 'Nov  2 2020 12:00AM', " +
                                     "NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'VIG', 'Nov  2 2020 12:00AM', 123020, NULL, 14817, 137837,  'N', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, " +
                                     "NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'VIG', 'Nov  2 2020 12:00AM', NULL)";

                                    String g = DefinicionDTE_TEMP + " ('BHR', 'SII', NULL, 9958456 , '4', 'FERNANDO MIGUEL CUBILLOS GOMEZ', 'NO', " + RutEmpresaCF + ",'" + DigiEmpresaCF + "', '   DBNET INGENIERIA DE SOFTWARE S A ', -1, " + i + " , 'Nov  2 2020 12:00AM'," +
                                      "NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'VIG', 'Nov  2 2020 12:00AM', 161463, NULL, 19448, 180911,  'N', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL," +
                                      "NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'VIG', 'Nov  2 2020 12:00AM', NULL)";

                                    String h = DefinicionDTE_TEMP + " ('BHR', 'SII', NULL, 9958456 , '4', 'FERNANDO MIGUEL CUBILLOS GOMEZ', 'NO', " + RutEmpresaCF + ",'" + DigiEmpresaCF + "', '   DBNET INGENIERIA DE SOFTWARE S A ', -1, " + i + " , 'Nov  2 2020 12:00AM'," +
                                        "NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'VIG', 'Nov  2 2020 12:00AM', 120456, NULL, 14509, 134965,  'N', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, " +
                                        "NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'VIG', 'Nov  2 2020 12:00AM', NULL)";

                                    String ii = DefinicionDTE_TEMP + " ('BHR', 'SII', NULL, 15311845, '0', 'RAUL ALEJANDRO ESPARZA LANDERO', 'NO', " + RutEmpresaCF + ",'" + DigiEmpresaCF + "', '   DBNET INGENIERIA DE SOFTWARE S A ', -1, " + i + " , 'Nov  4 2020 12:00AM'," +
                                        "NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'VIG', 'Nov  4 2020 12:00AM', 172230, NULL, 20745, 192975,  'N', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, " +
                                        "NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'VIG', 'Nov  4 2020 12:00AM', NULL)";

                                    String j = DefinicionDTE_TEMP + " ('BHR', 'SII', NULL, 15311845, '0', 'RAUL ALEJANDRO ESPARZA LANDERO', 'NO', " + RutEmpresaCF + ",'" + DigiEmpresaCF + "', '   DBNET INGENIERIA DE SOFTWARE S A ', -1, " + i + " , 'Nov  4 2020 12:00AM', " +
                                        "NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'VIG', 'Nov  4 2020 12:00AM', 172230, NULL, 20745, 192975,  'N', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, " +
                                        "NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'VIG', 'Nov  4 2020 12:00AM', NULL)";

                                    String k = DefinicionDTE_TEMP + " ('BHR', 'SII', NULL, 15311845, '0', 'RAUL ALEJANDRO ESPARZA LANDERO', 'NO', " + RutEmpresaCF + ",'" + DigiEmpresaCF + "', '   DBNET INGENIERIA DE SOFTWARE S A ', -1, " + i + " , 'Nov  4 2020 12:00AM', " +
                                        "NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'VIG', 'Nov  4 2020 12:00AM', 369065, NULL, 44453, 413518,  'N', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL," +
                                        "NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'VIG', 'Nov  4 2020 12:00AM', NULL)";

                                    String m = DefinicionDTE_TEMP + " ('BHR', 'SII', NULL, 15311845, '0', 'RAUL ALEJANDRO ESPARZA LANDERO', 'NO', " + RutEmpresaCF + ",'" + DigiEmpresaCF + "', '   DBNET INGENIERIA DE SOFTWARE S A ', -1, " + i + " , 'Nov  4 2020 12:00AM', " +
                                        "NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'VIG', 'Nov  4 2020 12:00AM', 98417,  NULL, 11854, 110271,  'N', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL," +
                                        "NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'VIG', 'Nov  4 2020 12:00AM', NULL)";

                                    String n = DefinicionDTE_TEMP + " ('BHR', 'SII', NULL, 16429988, '0', 'VIOLETA ANAHI HURTADO ESCUDERO', 'NO', " + RutEmpresaCF + ",'" + DigiEmpresaCF + "', '   DBNET INGENIERIA DE SOFTWARE S A ', -1, " + i + " , 'Nov  5 2020 12:00AM'," +
                                        "NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'VIG', 'Nov  5 2020 12:00AM', 65000,  NULL, 7829,  72829,   'N', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, " +
                                        "NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'VIG', 'Nov  5 2020 12:00AM', NULL)";

                                    String o = DefinicionDTE_TEMP + " ('BHR', 'SII', NULL, 14351139, '1', 'ALEJANDRO GIOVANNI IBANEZ CALA', 'NO', " + RutEmpresaCF + ",'" + DigiEmpresaCF + "', '   DBNET INGENIERIA DE SOFTWARE S A ', -1, " + i + " , 'Nov 11 2020 12:00AM'," +
                                        "NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'VIG', 'Nov 11 2020 12:00AM', 142800, NULL, 17200, 160000,  'N', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL," +
                                        "NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'VIG', 'Nov 11 2020 12:00AM', NULL)";

                                    String p = DefinicionDTE_TEMP + " ('BHR', 'SII', NULL, 18911866, 'K', 'FRANCIS ALBERTO ELIER HERRERA',  'NO', " + RutEmpresaCF + ",'" + DigiEmpresaCF + "', '   DBNET INGENIERIA DE SOFTWARE S A ', -1, " + i + " , 'Nov 16 2020 12:00AM'," +
                                        "NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'VIG', 'Nov 16 2020 12:00AM', 102494, NULL, 12345, 114839,  'N', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, " +
                                        "NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'VIG', 'Nov 16 2020 12:00AM', NULL)";

                                    String kk = DefinicionDTE_TEMP + " ('BHR', 'SII', NULL, 18911866, 'K', 'FRANCIS ALBERTO ELIER HERRERA',  'NO', " + RutEmpresaCF + ",'" + DigiEmpresaCF + "', '   DBNET INGENIERIA DE SOFTWARE S A ', -1, " + i + " , 'Nov 16 2020 12:00AM'," +
                                        "NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'VIG', 'Nov 16 2020 12:00AM', 102494, NULL, 12345, 114839,  'N', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, " +
                                        "NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'VIG', 'Nov 16 2020 12:00AM', NULL)";

                                    String aa = DefinicionDTE_TEMP + " ('BHR', 'SII', NULL, 9702536 , '3', 'CECILIA PAZ MONGE BABICH',       'NO', " + RutEmpresaCF + ",'" + DigiEmpresaCF + "', '   DBNET INGENIERIA DE SOFTWARE S A ', -1, " + i + " , 'Nov 17 2020 12:00AM', " +
                                        "NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'VIG', 'Nov 17 2020 12:00AM', 562275, NULL, 67725, 630000,  'N', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, " +
                                        "NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'VIG', 'Nov 17 2020 12:00AM', NULL)";

                                    String bb = DefinicionDTE_TEMP + " ('BHR', 'SII', NULL, 9702536 , '3', 'CECILIA PAZ MONGE BABICH',       'NO', " + RutEmpresaCF + ",'" + DigiEmpresaCF + "', '   DBNET INGENIERIA DE SOFTWARE S A ', -1, " + i + " , 'Nov 17 2020 12:00AM', " +
                                        "NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'VIG', 'Nov 17 2020 12:00AM', 562275, NULL, 67725, 630000,  'N', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL," +
                                        "NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'VIG', 'Nov 17 2020 12:00AM', NULL)";

                                    String cc = DefinicionDTE_TEMP + " ('BHR', 'SII', NULL, 15311845, '0', 'RAUL ALEJANDRO ESPARZA LANDERO', 'NO', " + RutEmpresaCF + ",'" + DigiEmpresaCF + "', '   DBNET INGENIERIA DE SOFTWARE S A ', -1, " + i + " , 'Nov 18 2020 12:00AM', " +
                                        "NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'VIG', 'Nov 18 2020 12:00AM', 196776, NULL, 23701, 220477,  'N', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, " +
                                        "NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'VIG', 'Nov 18 2020 12:00AM', NULL)";

                                    String dd = DefinicionDTE_TEMP + " ('BHR', 'SII', NULL, 15311845, '0', 'RAUL ALEJANDRO ESPARZA LANDERO', 'NO', " + RutEmpresaCF + ",'" + DigiEmpresaCF + "', '   DBNET INGENIERIA DE SOFTWARE S A ', -1, " + i + " , 'Nov 18 2020 12:00AM'," +
                                        "NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'VIG', 'Nov 18 2020 12:00AM', 49194 , NULL, 5925,  55119 ,  'N', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, " +
                                        "NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'VIG', 'Nov 18 2020 12:00AM', NULL)";



                                    string[] Items = { a, b, c, d, f, g, h, ii, j, k, m, n, o, p, kk, aa, bb, cc, dd };

                                    int ItemsSS = GetRandomInt(0, Items.Length);

                                    Insert = Items[ItemsSS];

                                    String Query = Insert;
                                    // int Folioquery = Convert.ToInt32(Foliodesde);
                                    conexionCLOUDCF.EjecutarSql(Query);
                                    conexionCLOUDCF.CerraBD();
                                }
                            }
                            else if (tablaCF == "DTE_CONTROL")
                            {
                                for (int i = Convert.ToInt32(FoliodesdeCF); i <= FoliohastaCF; i++)
                                {
                                    ConexionBD conexionCLOUDCF = new ConexionBD(AmbienteCF);
                                    conexionCLOUDCF.abrirBD();

                                    String a = DefinicionDTE_Control + "('BHR', 15311845, '0', 'RAUL ALEJANDRO ESPARZA LANDERO', 'NO', " + RutEmpresaCF + ",'" + DigiEmpresaCF + "', '   DBNET INGENIERIA DE SOFTWARE S A ', -1, " + i + ", CAST(N'2020-11-18' AS Date), 0 , 'Recibida', CAST(N'2020-11-18 00:00:00.000' AS DateTime), CAST(N'2020-11-09 15:22:42.227' AS DateTime), NULL, NULL, 'No Cargada', NULL, 'VIG', CAST(N'2020-11-09 15:22:42.227' AS DateTime), 'No Aplica', NULL, NULL, NULL, NULL, NULL, NULL, 'No Aplica', NULL, NULL, NULL, 'VIG', CAST(N'2020-11-09 15:22:42.227' AS DateTime), 196776 , NULL, 23701, 220477, NULL, 'N', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL)";
                                    String b = DefinicionDTE_Control + "('BHR', 15311845, '0', 'RAUL ALEJANDRO ESPARZA LANDERO', 'NO', " + RutEmpresaCF + ",'" + DigiEmpresaCF + "', '   DBNET INGENIERIA DE SOFTWARE S A ', -1, " + i + ", CAST(N'2020-11-18' AS Date), 0 , 'Recibida', CAST(N'2020-11-18 00:00:00.000' AS DateTime), CAST(N'2020-11-09 15:22:42.227' AS DateTime), NULL, NULL, 'No Cargada', NULL, 'VIG', CAST(N'2020-11-09 15:22:42.227' AS DateTime), 'No Aplica', NULL, NULL, NULL, NULL, NULL, NULL, 'No Aplica', NULL, NULL, NULL, 'VIG', CAST(N'2020-11-09 15:22:42.227' AS DateTime), 49194  , NULL, 5925 , 55119 , NULL, 'N', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL)";
                                    String c = DefinicionDTE_Control + "('BHR', 11415502, '0', 'PAOLA ANDREA VON KNORRING CIFU', 'NO', " + RutEmpresaCF + ",'" + DigiEmpresaCF + "', '   DBNET INGENIERIA DE SOFTWARE S A ', -1, " + i + ", CAST(N'2020-11-01' AS Date), 0 , 'Recibida', CAST(N'2020-11-01 00:00:00.000' AS DateTime), CAST(N'2020-11-09 15:22:42.213' AS DateTime), NULL, NULL, 'No Cargada', NULL, 'VIG', CAST(N'2020-11-09 15:22:42.213' AS DateTime), 'No Aplica', NULL, NULL, NULL, NULL, NULL, NULL, 'No Aplica', NULL, NULL, NULL, 'VIG', CAST(N'2020-11-09 15:22:42.213' AS DateTime), 691996 , NULL, 83350, 775346, NULL, 'N', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL)";
                                    String d = DefinicionDTE_Control + "('BHR', 9958456 , '4', 'FERNANDO MIGUEL CUBILLOS GOMEZ', 'NO', " + RutEmpresaCF + ",'" + DigiEmpresaCF + "', '   DBNET INGENIERIA DE SOFTWARE S A ', -1, " + i + ", CAST(N'2020-11-02' AS Date), 0 , 'Recibida', CAST(N'2020-11-02 00:00:00.000' AS DateTime), CAST(N'2020-11-09 15:22:42.213' AS DateTime), NULL, NULL, 'No Cargada', NULL, 'VIG', CAST(N'2020-11-09 15:22:42.213' AS DateTime), 'No Aplica', NULL, NULL, NULL, NULL, NULL, NULL, 'No Aplica', NULL, NULL, NULL, 'VIG', CAST(N'2020-11-09 15:22:42.213' AS DateTime), 322926 , NULL, 38896, 361822, NULL, 'N', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL)";
                                    String f = DefinicionDTE_Control + "('BHR', 9958456 , '4', 'FERNANDO MIGUEL CUBILLOS GOMEZ', 'NO', " + RutEmpresaCF + ",'" + DigiEmpresaCF + "', '   DBNET INGENIERIA DE SOFTWARE S A ', -1, " + i + ", CAST(N'2020-11-02' AS Date), 0 , 'Recibida', CAST(N'2020-11-02 00:00:00.000' AS DateTime), CAST(N'2020-11-09 15:22:42.217' AS DateTime), NULL, NULL, 'No Cargada', NULL, 'VIG', CAST(N'2020-11-09 15:22:42.217' AS DateTime), 'No Aplica', NULL, NULL, NULL, NULL, NULL, NULL, 'No Aplica', NULL, NULL, NULL, 'VIG', CAST(N'2020-11-09 15:22:42.217' AS DateTime), 356243 , NULL, 42909, 399152, NULL, 'N', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL)";
                                    String g = DefinicionDTE_Control + "('BHR', 9958456 , '4', 'FERNANDO MIGUEL CUBILLOS GOMEZ', 'NO', " + RutEmpresaCF + ",'" + DigiEmpresaCF + "', '   DBNET INGENIERIA DE SOFTWARE S A ', -1, " + i + ", CAST(N'2020-11-02' AS Date), 0 , 'Recibida', CAST(N'2020-11-02 00:00:00.000' AS DateTime), CAST(N'2020-11-09 15:22:42.217' AS DateTime), NULL, NULL, 'No Cargada', NULL, 'VIG', CAST(N'2020-11-09 15:22:42.217' AS DateTime), 'No Aplica', NULL, NULL, NULL, NULL, NULL, NULL, 'No Aplica', NULL, NULL, NULL, 'VIG', CAST(N'2020-11-09 15:22:42.217' AS DateTime), 174278 , NULL, 20991, 195269, NULL, 'N', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL)";
                                    String h = DefinicionDTE_Control + "('BHR', 9958456 , '4', 'FERNANDO MIGUEL CUBILLOS GOMEZ', 'NO', " + RutEmpresaCF + ",'" + DigiEmpresaCF + "', '   DBNET INGENIERIA DE SOFTWARE S A ', -1, " + i + ", CAST(N'2020-11-02' AS Date), 0 , 'Recibida', CAST(N'2020-11-02 00:00:00.000' AS DateTime), CAST(N'2020-11-09 15:22:42.217' AS DateTime), NULL, NULL, 'No Cargada', NULL, 'VIG', CAST(N'2020-11-09 15:22:42.217' AS DateTime), 'No Aplica', NULL, NULL, NULL, NULL, NULL, NULL, 'No Aplica', NULL, NULL, NULL, 'VIG', CAST(N'2020-11-09 15:22:42.217' AS DateTime), 123020 , NULL, 14817, 137837, NULL, 'N', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL)";
                                    String ii = DefinicionDTE_Control + "('BHR', 9958456 , '4', 'FERNANDO MIGUEL CUBILLOS GOMEZ', 'NO'," + RutEmpresaCF + ",'" + DigiEmpresaCF + "', '   DBNET INGENIERIA DE SOFTWARE S A ', -1, " + i + ", CAST(N'2020-11-02' AS Date), 0 , 'Recibida', CAST(N'2020-11-02 00:00:00.000' AS DateTime), CAST(N'2020-11-09 15:22:42.217' AS DateTime), NULL, NULL, 'No Cargada', NULL, 'VIG', CAST(N'2020-11-09 15:22:42.217' AS DateTime), 'No Aplica', NULL, NULL, NULL, NULL, NULL, NULL, 'No Aplica', NULL, NULL, NULL, 'VIG', CAST(N'2020-11-09 15:22:42.217' AS DateTime), 161463 , NULL, 19448, 180911, NULL, 'N', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL)";
                                    String j = DefinicionDTE_Control + "('BHR', 9958456 , '4', 'FERNANDO MIGUEL CUBILLOS GOMEZ', 'NO', " + RutEmpresaCF + ",'" + DigiEmpresaCF + "', '   DBNET INGENIERIA DE SOFTWARE S A ', -1, " + i + ", CAST(N'2020-11-02' AS Date), 0 , 'Recibida', CAST(N'2020-11-02 00:00:00.000' AS DateTime), CAST(N'2020-11-09 15:22:42.217' AS DateTime), NULL, NULL, 'No Cargada', NULL, 'VIG', CAST(N'2020-11-09 15:22:42.217' AS DateTime), 'No Aplica', NULL, NULL, NULL, NULL, NULL, NULL, 'No Aplica', NULL, NULL, NULL, 'VIG', CAST(N'2020-11-09 15:22:42.217' AS DateTime), 120456 , NULL, 14509, 134965, NULL, 'N', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL)";
                                    String k = DefinicionDTE_Control + "('BHR', 15311845, '0', 'RAUL ALEJANDRO ESPARZA LANDERO', 'NO', " + RutEmpresaCF + ",'" + DigiEmpresaCF + "', '   DBNET INGENIERIA DE SOFTWARE S A ', -1, " + i + ", CAST(N'2020-11-04' AS Date), 0 , 'Recibida', CAST(N'2020-11-04 00:00:00.000' AS DateTime), CAST(N'2020-11-09 15:22:42.220' AS DateTime), NULL, NULL, 'No Cargada', NULL, 'VIG', CAST(N'2020-11-09 15:22:42.220' AS DateTime), 'No Aplica', NULL, NULL, NULL, NULL, NULL, NULL, 'No Aplica', NULL, NULL, NULL, 'VIG', CAST(N'2020-11-09 15:22:42.220' AS DateTime), 172230 , NULL, 20745, 192975, NULL, 'N', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL)";
                                    String m = DefinicionDTE_Control + "('BHR', 15311845, '0', 'RAUL ALEJANDRO ESPARZA LANDERO', 'NO', " + RutEmpresaCF + ",'" + DigiEmpresaCF + "', '   DBNET INGENIERIA DE SOFTWARE S A ', -1, " + i + ", CAST(N'2020-11-04' AS Date), 0 , 'Recibida', CAST(N'2020-11-04 00:00:00.000' AS DateTime), CAST(N'2020-11-09 15:22:42.220' AS DateTime), NULL, NULL, 'No Cargada', NULL, 'VIG', CAST(N'2020-11-09 15:22:42.220' AS DateTime), 'No Aplica', NULL, NULL, NULL, NULL, NULL, NULL, 'No Aplica', NULL, NULL, NULL, 'VIG', CAST(N'2020-11-09 15:22:42.220' AS DateTime), 172230 , NULL, 20745, 192975, NULL, 'N', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL)";
                                    String n = DefinicionDTE_Control + "('BHR', 15311845, '0', 'RAUL ALEJANDRO ESPARZA LANDERO', 'NO', " + RutEmpresaCF + ",'" + DigiEmpresaCF + "', '   DBNET INGENIERIA DE SOFTWARE S A ', -1, " + i + ", CAST(N'2020-11-04' AS Date), 0 , 'Recibida', CAST(N'2020-11-04 00:00:00.000' AS DateTime), CAST(N'2020-11-09 15:22:42.220' AS DateTime), NULL, NULL, 'No Cargada', NULL, 'VIG', CAST(N'2020-11-09 15:22:42.220' AS DateTime), 'No Aplica', NULL, NULL, NULL, NULL, NULL, NULL, 'No Aplica', NULL, NULL, NULL, 'VIG', CAST(N'2020-11-09 15:22:42.220' AS DateTime), 369065 , NULL, 44453, 413518, NULL, 'N', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL)";
                                    String o = DefinicionDTE_Control + "('BHR', 15311845, '0', 'RAUL ALEJANDRO ESPARZA LANDERO', 'NO', " + RutEmpresaCF + ",'" + DigiEmpresaCF + "', '   DBNET INGENIERIA DE SOFTWARE S A ', -1, " + i + ", CAST(N'2020-11-04' AS Date), 0 , 'Recibida', CAST(N'2020-11-04 00:00:00.000' AS DateTime), CAST(N'2020-11-09 15:22:42.220' AS DateTime), NULL, NULL, 'No Cargada', NULL, 'VIG', CAST(N'2020-11-09 15:22:42.220' AS DateTime), 'No Aplica', NULL, NULL, NULL, NULL, NULL, NULL, 'No Aplica', NULL, NULL, NULL, 'VIG', CAST(N'2020-11-09 15:22:42.220' AS DateTime), 98417  , NULL, 11854, 110271, NULL, 'N', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL)";
                                    String p = DefinicionDTE_Control + "('BHR', 16429988, '0', 'VIOLETA ANAHI HURTADO ESCUDERO', 'NO', " + RutEmpresaCF + ",'" + DigiEmpresaCF + "', '   DBNET INGENIERIA DE SOFTWARE S A ', -1, " + i + ", CAST(N'2020-11-05' AS Date), 0 , 'Recibida', CAST(N'2020-11-05 00:00:00.000' AS DateTime), CAST(N'2020-11-09 15:22:42.220' AS DateTime), NULL, NULL, 'No Cargada', NULL, 'VIG', CAST(N'2020-11-09 15:22:42.220' AS DateTime), 'No Aplica', NULL, NULL, NULL, NULL, NULL, NULL, 'No Aplica', NULL, NULL, NULL, 'VIG', CAST(N'2020-11-09 15:22:42.220' AS DateTime), 65000  , NULL, 7829 , 72829 , NULL, 'N', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL)";
                                    String kk = DefinicionDTE_Control + "('BHR', 14351139, '1', 'ALEJANDRO GIOVANNI IBANEZ CALA', 'NO'," + RutEmpresaCF + ",'" + DigiEmpresaCF + "', '   DBNET INGENIERIA DE SOFTWARE S A ', -1, " + i + ", CAST(N'2020-11-11' AS Date), 0 , 'Recibida', CAST(N'2020-11-11 00:00:00.000' AS DateTime), CAST(N'2020-11-09 15:22:42.220' AS DateTime), NULL, NULL, 'No Cargada', NULL, 'VIG', CAST(N'2020-11-09 15:22:42.220' AS DateTime), 'No Aplica', NULL, NULL, NULL, NULL, NULL, NULL, 'No Aplica', NULL, NULL, NULL, 'VIG', CAST(N'2020-11-09 15:22:42.220' AS DateTime), 142800 , NULL, 17200, 160000, NULL, 'N', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL)";
                                    String aa = DefinicionDTE_Control + "('BHR', 18911866, 'K', 'FRANCIS ALBERTO ELIER HERRERA',  'NO'," + RutEmpresaCF + ",'" + DigiEmpresaCF + "', '   DBNET INGENIERIA DE SOFTWARE S A ', -1, " + i + ", CAST(N'2020-11-16' AS Date), 0 , 'Recibida', CAST(N'2020-11-16 00:00:00.000' AS DateTime), CAST(N'2020-11-09 15:22:42.223' AS DateTime), NULL, NULL, 'No Cargada', NULL, 'VIG', CAST(N'2020-11-09 15:22:42.223' AS DateTime), 'No Aplica', NULL, NULL, NULL, NULL, NULL, NULL, 'No Aplica', NULL, NULL, NULL, 'VIG', CAST(N'2020-11-09 15:22:42.223' AS DateTime), 102494 , NULL, 12345, 114839, NULL, 'N', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL)";
                                    String bb = DefinicionDTE_Control + "('BHR', 18911866, 'K', 'FRANCIS ALBERTO ELIER HERRERA',  'NO'," + RutEmpresaCF + ",'" + DigiEmpresaCF + "', '   DBNET INGENIERIA DE SOFTWARE S A ', -1, " + i + ", CAST(N'2020-11-16' AS Date), 0 , 'Recibida', CAST(N'2020-11-16 00:00:00.000' AS DateTime), CAST(N'2020-11-09 15:22:42.223' AS DateTime), NULL, NULL, 'No Cargada', NULL, 'VIG', CAST(N'2020-11-09 15:22:42.223' AS DateTime), 'No Aplica', NULL, NULL, NULL, NULL, NULL, NULL, 'No Aplica', NULL, NULL, NULL, 'VIG', CAST(N'2020-11-09 15:22:42.223' AS DateTime), 102494 , NULL, 12345, 114839, NULL, 'N', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL)";
                                    String cc = DefinicionDTE_Control + "('BHR', 9702536 , '3', 'CECILIA PAZ MONGE BABICH',       'NO'," + RutEmpresaCF + ",'" + DigiEmpresaCF + "', '   DBNET INGENIERIA DE SOFTWARE S A ', -1, " + i + ", CAST(N'2020-11-17' AS Date), 0 , 'Recibida', CAST(N'2020-11-17 00:00:00.000' AS DateTime), CAST(N'2020-11-09 15:22:42.223' AS DateTime), NULL, NULL, 'No Cargada', NULL, 'VIG', CAST(N'2020-11-09 15:22:42.223' AS DateTime), 'No Aplica', NULL, NULL, NULL, NULL, NULL, NULL, 'No Aplica', NULL, NULL, NULL, 'VIG', CAST(N'2020-11-09 15:22:42.223' AS DateTime), 562275 , NULL, 67725, 630000, NULL, 'N', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL)";
                                    String dd = DefinicionDTE_Control + "('BHR', 9702536 , '3', 'CECILIA PAZ MONGE BABICH',       'NO'," + RutEmpresaCF + ",'" + DigiEmpresaCF + "', '   DBNET INGENIERIA DE SOFTWARE S A ', -1, " + i + ", CAST(N'2020-11-17' AS Date), 0 , 'Recibida', CAST(N'2020-11-17 00:00:00.000' AS DateTime), CAST(N'2020-11-09 15:22:42.223' AS DateTime), NULL, NULL, 'No Cargada', NULL, 'VIG', CAST(N'2020-11-09 15:22:42.223' AS DateTime), 'No Aplica', NULL, NULL, NULL, NULL, NULL, NULL, 'No Aplica', NULL, NULL, NULL, 'VIG', CAST(N'2020-11-09 15:22:42.223' AS DateTime), 562275 , NULL, 67725, 630000, NULL, 'N', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL)";


                                    string[] Items = { a, b, c, d, f, g, h, ii, j, k, m, n, o, p, kk, aa, bb, cc, dd };

                                    int ItemsSS = GetRandomInt(0, Items.Length);

                                    Insert = Items[ItemsSS];

                                    String Query = Insert;
                                    // int Folioquery = Convert.ToInt32(Foliodesde);
                                    conexionCLOUDCF.EjecutarSql(Query);
                                    conexionCLOUDCF.CerraBD();
                                }
                            }
                            break;
                        case "Cesiones":
                            break;

                    }
                    break;
                #endregion


                #region Oracle
                case "ORACLE":
                    validarCampos();
                    switch (tipodescarga)
                    {
                        case "RCV_CompraNoIncluir":
                            break;
                        case "RCV_CompraPendiente":
                            break;
                        case "RCV_CompraReclamado":
                            break;
                        case "RCV_CompraRegistro":
                            break;
                        case "RCV_Venta":
                            break;
                        case "BHR":
                            break;
                        case "Cesiones":
                            break;

                    }
                    break;
                #endregion

                default:
                    Console.WriteLine("Default case");

                    break;
            }
            MessageBox.Show("Termine ");
        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox5.SelectedIndex)
            {
                case 0:
                    AmbienteCF = "CLOUDCF";
                    break;
                case 1:
                    AmbienteCF = "SQLCF";
                    break;
                case 2:
                    AmbienteCF = "ORACLECF";
                    break;
                default:
                    Console.WriteLine("Default case");
                    break;
            }
        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox7.SelectedIndex)
            {
                case 0:
                    tablaCF = "DTE_TEMP";
                    break;
                case 1:
                    tablaCF = "DTE_CONTROL";
                    break;
                default:
                    Console.WriteLine("Default case");
                    break;
            }
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox6.SelectedIndex)
            {
                case 0:
                    tipodescarga = "RCV_CompraNoIncluir";
                    break;
                case 1:
                    tipodescarga = "RCV_CompraPendiente";
                    break;
                case 2:
                    tipodescarga = "RCV_CompraReclamado";
                    break;
                case 3:
                    tipodescarga = "RCV_CompraRegistro";
                    break;
                case 4:
                    tipodescarga = "RCV_Venta";
                    break;
                case 5:
                    tipodescarga = "BHR";
                    break;
                case 6:
                    tipodescarga = "Cesiones";
                    break;
                default:
                    Console.WriteLine("Default case");
                    break;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Seguro Desea Salir?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Hold = txbHolding.Text;
        }

        private void txbRut_TextChanged(object sender, EventArgs e)
        {
            RutEmpresa = txbRut.Text;
        }

        private void txbDigi_TextChanged(object sender, EventArgs e)
        {
            DigiEmpresa = txbDigi.Text;
        }

        private void tbxFoliDesde_TextChanged(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void lbFechEmis_Click(object sender, EventArgs e)
        {

        }

        private void dtPeriodoCF_ValueChanged(object sender, EventArgs e)
        {
            PeriodoCF = dtPeriodoCF.Value.ToString("yyyyMM");
            PeriodoEMISCF = dtPeriodoCF.Value.ToString("yyyy-MM");
        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void TxtRUTCF_TextChanged(object sender, EventArgs e)
        {
            RutEmpresaCF = TxtRUTCF.Text;

        }

        private void TxtDIGICF_TextChanged(object sender, EventArgs e)
        {
            DigiEmpresaCF = TxtDIGICF.Text;
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Seguro Desea Salir?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            Holdbel = textBox5.Text;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            RutEmpresaCF = textBox4.Text;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            DigiEmpresaCF = textBox3.Text;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (AccionBOL == "INSERT")
            {
                validarCampos();
                switch (Ambiente)
                {

                    #region CLOUD
                    case "CLOUD":

                           validarCamposbel();
                            Definiciones Beldef = new Definiciones();
                            definicion_BEL_ENCA_DOCU_HOLD = Beldef.BEL_ENCA_DOCU_HOLD();
                            definicion_BEL_DETA_PRSE_HOLD = Beldef.BEL_DETA_PRSE_HOLD();
                            definicion_BEL_DETA_CODI_HOLD = Beldef.BEL_DETA_CODI_HOLD();

                            if (TipoDocuBEL == 39)
                            {
                            if (checkBEL.Checked == false)
                            {
                                validarCampos();
                                int diferencia = Convert.ToInt32(textBox7.Text);
                                ConexionBD conexionCLOUD39 = new ConexionBD(Ambiente);
                                conexionCLOUD39.abrirBD();
                                String PRC39 = Beldef.PRCCARGADTE(TipoDocuBEL, diferencia, Holdbel, RutEmpresa, DigiEmpresa);
                                conexionCLOUD39.EjecutarSql(PRC39);
                                conexionCLOUD39.CerraBD();
                            }
                            else
                            {
                                
                                for (int i = Convert.ToInt32(Foliodesdebel); i <= Foliohastabel; i++)
                                {
                                    ConexionBD conexionCLOUD = new ConexionBD(Ambiente);
                                    conexionCLOUD.abrirBD();
                                    String a = definicion_BEL_ENCA_DOCU_HOLD + "('" + Holdbel + "',1, " + TipoDocuBEL + ", " + i + " , '1.0', 'INI', '" + fechaBel + "', 3 , 0 , '', '', '2020-10-30', 78079790, '8', 'EMPRESA PORTUARIA IQUIQUE', 'DEPOSITO Y ALMACENAM. Y OTROS SERV.', 0,  'AV. JORGE BARRERA N 62', 'IQUIQUE', 'IQUIQUE', 66666666, '6', '66666666', 'CBT ING.Y CONSTR. LTDA', '', 'RECINTO PORTUARIO S N', 'IQUIQUE', 'IQUIQUE', '', '', '', 81147.0, 0.0,15.0, 15418.0, 96565.0, 0.0, 0.0, 0.0, 0.0, '2020-10-07T11:41:23', 'INGRESO 7 PERSONAS POR 30 DIAS', '', '|||||', '', 'CON CHEQUE','|772.83|28700.20|TERMINAL MOLO|1||22-09-2020|ALEJANDRA VASQUEZ ACEVEDO|OTROS|||', '', '0', '1.00', '', isnull(0,0), '', '', '', '', 0 , '', '', '', '', '')" +
                                           definicion_BEL_DETA_PRSE_HOLD + "('" + Holdbel + "',1 , " + i + "," + TipoDocuBEL + ", 1, 0, '21 UND PERMISO ACCESO PERSONAS 1 A 10 DIAS', '', 1.0, 'UND', 96565.0, 96565.0, 0.0, 0, 0.0, 0)" +
                                           definicion_BEL_DETA_CODI_HOLD + "('" + Holdbel + "',1," + TipoDocuBEL + "," + i + ", 1, 'INT','LSP 46560')" +
                                           definicion_BEL_DETA_CODI_HOLD + "('" + Holdbel + "',1," + TipoDocuBEL + ", " + i + " , 1, 'TARIFA', 'EPI-503')";
                                    String Query = a;                                    
                                    conexionCLOUD.EjecutarSql(Query, i);
                                    conexionCLOUD.CerraBD();
                                }
                            }
                            }
                            else if (TipoDocuBEL == 41)
                            {
                            
                            if (checkBEL.Checked == false)
                                {
                                    validarCampos();
                                    int diferencia = Convert.ToInt32(textBox7.Text);
                                    ConexionBD conexionCLOUD41 = new ConexionBD(Ambiente);
                                    conexionCLOUD41.abrirBD();
                                    String PRC41 = Beldef.PRCCARGADTE(TipoDocuBEL, diferencia, Holdbel, RutEmpresa, DigiEmpresa);
                                    conexionCLOUD41.EjecutarSql(PRC41);
                                    conexionCLOUD41.CerraBD();
                                }
                                else
                                {
                                for (int i = Convert.ToInt32(Foliodesdebel); i <= Foliohastabel; i++)
                                {
                                    ConexionBD conexionCLOUD = new ConexionBD(Ambiente);
                                    conexionCLOUD.abrirBD();
                                    String a = definicion_BEL_ENCA_DOCU_HOLD + "('" + Holdbel + "',1," + TipoDocuBEL + ", " + i + " , '1.0', 'INI', '" + fechaBel + "', 3 , 0 , '', '', '2020-10-30', 78079790, '8', 'EMPRESA PORTUARIA IQUIQUE', 'DEPOSITO Y ALMACENAM. Y OTROS SERV.', 0,  'AV. JORGE BARRERA N 62', 'IQUIQUE', 'IQUIQUE', 66666666, '6', '66666666', 'CBT ING.Y CONSTR. LTDA', '', 'RECINTO PORTUARIO S N', 'IQUIQUE', 'IQUIQUE', '', '', '', 0, 96565.0,0, 0, 96565.0, 0.0, 0.0, 0.0, 0.0, '2020-10-07T11:41:23', 'INGRESO 7 PERSONAS POR 30 DIAS', '', '|||||', '', 'CON CHEQUE','|772.83|28700.20|TERMINAL MOLO|1||22-09-2020|ALEJANDRA VASQUEZ ACEVEDO|OTROS|||', '', '0', '1.00', '', isnull(0,0), '', '', '', '', 0 , '', '', '', '', '')" +
                                           definicion_BEL_DETA_PRSE_HOLD + "('" + Holdbel + "',1," + i + "," + TipoDocuBEL + ", 1, 0, '21 UND PERMISO ACCESO PERSONAS 1 A 10 DIAS', '', 1.0, 'UND', 96565.0, 96565.0, 0.0, 0, 0.0, 0)" +
                                           definicion_BEL_DETA_CODI_HOLD + "('" + Holdbel + "',1," + TipoDocuBEL + "," + i + ", 1, 'INT','LSP 46560')" +
                                           definicion_BEL_DETA_CODI_HOLD + "('" + Holdbel + "',1," + TipoDocuBEL + ", " + i + " , 1, 'TARIFA', 'EPI-503')";
                                    String Query = a;
                                    int Folioquery = Convert.ToInt32(Foliodesdebel);
                                    conexionCLOUD.EjecutarSql(Query, i);
                                    conexionCLOUD.CerraBD();
                                }
                            }
                        }
                        break;
                    #endregion
                    #region CaseSQL
                    case "SQL":
                        validarCamposbel();
                        for (int i = Convert.ToInt32(Foliodesdebel); i <= Foliohastabel; i++)
                        {
                            Definiciones sqlinhouse = new Definiciones();
                            definicion_BEL_ENCA_DOCU = sqlinhouse.BEL_ENCA_DOCU_SQLINHOUSE();
                            definicion_BEL_DETA_PRSE = sqlinhouse.BEL_DETA_PRSE_SQLINHOUSE();
                            String definicion_bel_deta_codi = sqlinhouse.BEL_DETA_CODI_SQLINHOUSE();
                            ConexionBD conexionsql = new ConexionBD(Ambiente);
                            conexionsql.abrirBD();

                            if (TipoDocuBEL == 39)
                            {
                                String a = definicion_BEL_ENCA_DOCU + "(1, " + TipoDocuBEL + ", " + i + " , '1.0', 'INI', '" + fechaBel + "', 3 , 0 , '', '', '2020-10-30', 78079790, '8', 'EMPRESA PORTUARIA IQUIQUE', 'DEPOSITO Y ALMACENAM. Y OTROS SERV.', 0,  'AV. JORGE BARRERA N 62', 'IQUIQUE', 'IQUIQUE', 66666666, '6', '66666666', 'CBT ING.Y CONSTR. LTDA', '', 'RECINTO PORTUARIO S N', 'IQUIQUE', 'IQUIQUE', '', '', '', 81147.0, 0.0,15.0, 15418.0, 96565.0, 0.0, 0.0, 0.0, 0.0, '2020-10-07T11:41:23', 'INGRESO 7 PERSONAS POR 30 DIAS', '', '|||||', '', 'CON CHEQUE','|772.83|28700.20|TERMINAL MOLO|1||22-09-2020|ALEJANDRA VASQUEZ ACEVEDO|OTROS|||', '', '0', '1.00', '', isnull(0,0), '', '', '', '', 0 , '', '', '', '', '')" +
                                           definicion_BEL_DETA_PRSE+"(1 , " + i + "," + TipoDocuBEL + ", 1, 0, '21 UND PERMISO ACCESO PERSONAS 1 A 10 DIAS', '', 1.0, 'UND', 96565.0, 96565.0, 0.0, 0, 0.0, 0)" +
                                           definicion_bel_deta_codi+"(1," + TipoDocuBEL + "," + i + ", 1, 'INT','LSP 46560')" +
                                           definicion_bel_deta_codi+" (1," + TipoDocuBEL + ", " + i + " , 1, 'TARIFA', 'EPI-503')";
                                String Query = a;
                                conexionsql.EjecutarSql(Query);
                                conexionsql.CerraBD();
                            }
                            else if (TipoDocuBEL == 41)
                            {
                                String a = definicion_BEL_ENCA_DOCU+"(1, " + TipoDocuBEL + ", " + i + " , '1.0', 'INI', '" + fechaBel + "', 3 , 0 , '', '', '2020-10-30', 78079790, '8', 'EMPRESA PORTUARIA IQUIQUE', 'DEPOSITO Y ALMACENAM. Y OTROS SERV.', 0,  'AV. JORGE BARRERA N 62', 'IQUIQUE', 'IQUIQUE', 66666666, '6', '66666666', 'CBT ING.Y CONSTR. LTDA', '', 'RECINTO PORTUARIO S N', 'IQUIQUE', 'IQUIQUE', '', '', '', 0, 96565.0,0, 0, 96565.0, 0.0, 0.0, 0.0, 0.0, '2020-10-07T11:41:23', 'INGRESO 7 PERSONAS POR 30 DIAS', '', '|||||', '', 'CON CHEQUE','|772.83|28700.20|TERMINAL MOLO|1||22-09-2020|ALEJANDRA VASQUEZ ACEVEDO|OTROS|||', '', '0', '1.00', '', isnull(0,0), '', '', '', '', 0 , '', '', '', '', '')" +
                                           definicion_BEL_DETA_PRSE+"(1 ," + i + "," + TipoDocuBEL + ", 1, 0, '21 UND PERMISO ACCESO PERSONAS 1 A 10 DIAS', '', 1.0, 'UND', 96565.0, 96565.0, 0.0, 0, 0.0, 0)" +
                                           definicion_bel_deta_codi+"(1," + TipoDocuBEL + "," + i + ", 1, 'INT','LSP 46560')" +
                                           definicion_bel_deta_codi+"(1," + TipoDocuBEL + ", " + i + " , 1, 'TARIFA', 'EPI-503')";
                                String Query = a;
                                conexionsql.EjecutarSql(Query);
                                conexionsql.CerraBD();
                            }

                        }
                        break;
                    #endregion
                    #region Oracle
                    case "ORACLE":
                        Definiciones Oracledef = new Definiciones();
                        definicion_BEL_ENCA_DOCU = Oracledef.BEL_ENCA_DOCU_oracle();
                        definicion_BEL_DETA_PRSE = Oracledef.BEL_DETA_PRSE_Oracle(); ;
                        definicion_BEL_DETA_CODI = Oracledef.BEL_DETA_CODI_Oracle();
                        validarCamposbel();
                        for (int i = Convert.ToInt32(Foliodesdebel); i <= Foliohastabel; i++)
                        {

                            ConexionBD conexionORA = new ConexionBD(Ambiente);
                            conexionORA.ConexionOracle();
                            if (TipoDocuBEL == 39)
                            {
                                String a = definicion_BEL_ENCA_DOCU + "(1,'" + TipoDocuBEL + "','" + i + "', '1.0', 'INI', '" + fechaBel + "', 3 , 0 , '', '', '2020-10-30', 78079790, '8', 'EMPRESA PORTUARIA IQUIQUE', 'DEPOSITO Y ALMACENAM. Y OTROS SERV.', 0,  'AV. JORGE BARRERA N 62', 'IQUIQUE', 'IQUIQUE', 66666666, '6', '66666666', 'CBT ING.Y CONSTR. LTDA', '', 'RECINTO PORTUARIO S N', 'IQUIQUE', 'IQUIQUE', '', '', '', 81147.0, 0.0,15.0, 15418.0, 96565.0, 0.0, 0.0, 0.0, 0.0, '2020-10-26T11:41:23', 'INGRESO 7 PERSONAS POR 30 DIAS', '', '|||||', '', 'CON CHEQUE','|772.83|28700.20|TERMINAL MOLO|1||22-09-2020|ALEJANDRA VASQUEZ ACEVEDO|OTROS|||', '', '0', '1.00', '', 0, '', '', '', '', 0 , '', '', '', '', '')¿" +
                                            definicion_BEL_DETA_PRSE + "(1, " + i + ", " + TipoDocuBEL + ",1, 0, '21 UND PERMISO ACCESO PERSONAS 1 A 10 DIAS', '', 1.0, 'UND', 96565.0, 96565.0, 0.0, 0, 0.0, 0)¿" +
                                            definicion_BEL_DETA_CODI + "(1,'" + TipoDocuBEL + "','" + i + "', 1, 'INT','LSP 46560')¿" +
                                            definicion_BEL_DETA_CODI + "(1,'" + TipoDocuBEL + "','" + i + "', 1, 'TARIFA', 'EPI-503')¿";


                                string[] Items = { a };

                                int ItemsSS = GetRandomInt(0, Items.Length);

                                Insert = Items[ItemsSS];

                                char[] Separador = { '¿' };
                                string[] words = Insert.Split(Separador);

                                String Primero = "";
                                String Segundo = "";
                                String Tercero = "";
                                String cuarto = "";
                                GuardaQueryOracle = new string[10];
                                int x = 0;
                                foreach (var word in words)
                                {

                                    GuardaQueryOracle[x] = word;
                                    x++;
                                }

                                Primero = GuardaQueryOracle[0];
                                Segundo = GuardaQueryOracle[1];
                                Tercero = GuardaQueryOracle[2];
                                cuarto = GuardaQueryOracle[3];
                                //MessageBox.Show(Primero + Segundo + Tercero);

                                String Query1 = Primero;
                                conexionORA.EjecutaQueryOracle(Query1);
                                String Query2 = Segundo;
                                conexionORA.EjecutaQueryOracle(Query2);
                                String Query3 = Tercero;
                                conexionORA.EjecutaQueryOracle(Query3);
                                String Query4 = cuarto;
                                conexionORA.EjecutaQueryOracle(Query4);
                            }
                            else if (TipoDocuBEL == 41)
                            {

                                String a = definicion_BEL_ENCA_DOCU + "(1, " + TipoDocuBEL + ", " + i + " , '1.0', 'INI', '" + fechaBel + "', 3 , 0 , '', '', '2020-10-30', 78079790, '8', 'EMPRESA PORTUARIA IQUIQUE', 'DEPOSITO Y ALMACENAM. Y OTROS SERV.', 0,  'AV. JORGE BARRERA N 62', 'IQUIQUE', 'IQUIQUE', 66666666, '6', '66666666', 'CBT ING.Y CONSTR. LTDA', '', 'RECINTO PORTUARIO S N', 'IQUIQUE', 'IQUIQUE', '', '', '', 0, 96565.0,0, 0, 96565.0, 0.0, 0.0, 0.0, 0.0, '2020-10-26T11:41:23', 'INGRESO 7 PERSONAS POR 30 DIAS', '', '|||||', '', 'CON CHEQUE','|772.83|28700.20|TERMINAL MOLO|1||22-09-2020|ALEJANDRA VASQUEZ ACEVEDO|OTROS|||', '', '0', '1.00', '', 0, '', '', '', '', 0 , '', '', '', '', '')¿" +
                                           definicion_BEL_DETA_PRSE + "(1 , " + i + "," + TipoDocuBEL + ", 1, 0, '21 UND PERMISO ACCESO PERSONAS 1 A 10 DIAS', '', 1.0, 'UND', 96565.0, 96565.0, 0.0, 0, 0.0, 0)¿" +
                                           definicion_BEL_DETA_CODI + "(1," + TipoDocuBEL + "," + i + ", 1, 'INT','LSP 46560')¿" +
                                           definicion_BEL_DETA_CODI + "(1," + TipoDocuBEL + ", " + i + " , 1, 'TARIFA', 'EPI-503')¿";

                                string[] Items = { a };

                                int ItemsSS = GetRandomInt(0, Items.Length);

                                Insert = Items[ItemsSS];

                                char[] Separador = { '¿' };
                                string[] words = Insert.Split(Separador);

                                String Primero = "";
                                String Segundo = "";
                                String Tercero = "";
                                String cuarto = "";
                                GuardaQueryOracle = new string[10];
                                int x = 0;
                                foreach (var word in words)
                                {

                                    GuardaQueryOracle[x] = word;
                                    x++;
                                }

                                Primero = GuardaQueryOracle[0];
                                Segundo = GuardaQueryOracle[1];
                                Tercero = GuardaQueryOracle[2];
                                cuarto = GuardaQueryOracle[3];
                                //MessageBox.Show(Primero + Segundo + Tercero);

                                String Query1 = Primero;
                                conexionORA.EjecutaQueryOracle(Query1);
                                String Query2 = Segundo;
                                conexionORA.EjecutaQueryOracle(Query2);
                                String Query3 = Tercero;
                                conexionORA.EjecutaQueryOracle(Query3);
                                String Query4 = cuarto;
                                conexionORA.EjecutaQueryOracle(Query4);
                            }

                        }

                        break;
                    #endregion
                    default:
                        Console.WriteLine("Default case");

                        break;
                }

                MessageBox.Show("Termine ");
            }


            else if (AccionBOL == "TXT") 
                {
                    Definiciones Ruta = new Definiciones();
                    Ruta.creaDirectorio(RutaCarpeta);

                switch (TipoDocuBEL)
                    {

                        case 39:

                        validarCamposbel();
                        Ruta.creaDirectorio(RutaCarpeta + "\\DocumentosTXT\\39\\");

                        for (int i = Convert.ToInt32(Foliodesdebel); i <= Foliohastabel; i++)
                            {
                                Documento = "A0;;INGRESO 7 PERSONAS POR 30 DIAS;;|||||;;CON CHEQUE;|772.83|28700.20|TERMINAL MOLO|1||22-09-2020|ALEJANDRA VASQUEZ ACEVEDO|OTROS|||;;0;1.00;\n" +
                                            "A;39;1.0;" + i + ";" +fechaBel +";3;;;;2020-10-30;"+ textBox4.Text + "-" + textBox3.Text + ";Dbnet;DEPOSITO Y ALMACENAM. Y OTROS SERV.;;AV. JORGE BARRERA N 62;IQUIQUE;IQUIQUE;66666666-6;66666666;CBT ING.Y CONSTR. LTDA;;RECINTO PORTUARIO S N;IQUIQUE;IQUIQUE;;;;81147;;15418;96565;;;;;\n" +
                                            "B;1;;21 UND PERMISO ACCESO PERSONAS 1 A 10 DIAS;;1.000000;UND;96565;96565;\n" +
                                            "B2;INT;LSP 46560;";


                            StreamWriter writer2 = new StreamWriter(RutaCarpeta + "\\DocumentosTXT\\39\\" + "\\E0" + txbRut.Text + "T" + TipoDocuBEL + "0000" + i + ".txt", false, Encoding.Default);

                                writer2.WriteLine(Documento.TrimEnd('\n'));
                                writer2.Close();
                            }
                        System.Diagnostics.Process.Start(RutaCarpeta + "\\DocumentosTXT\\39\\");
                        break;
                        case 41:
                        validarCamposbel();
                        validarCamposbel();
                        Ruta.creaDirectorio(RutaCarpeta + "\\DocumentosTXT\\41\\");
                        for (int i = Convert.ToInt32(Foliodesdebel); i <= Foliohastabel; i++)
                            {
                                Documento = "A0;FE_NORACID_SCL01;0094311104-CVARELA-Bol-0040005476;SERVICIOS ULTRACORP;;;;;219;;Hecho no gravado DL 825 de 1974;\n" +
                                            "A;41;1.0;" + i + ";" + fechaBel + ";3 ;;;;2021-01-31;" + textBox4.Text + "-" + textBox3.Text + ";Dbnet;Arriendo de Oficinas con Muebles;;Avda. El Bosque Norte 500;LAS CONDES;;9250199-K;0000115971;MAIK BUROSE ;;FRAY LEON  12334 LAS CONDES  LAS CONDES;LAS CONDES;LAS CONDES;;;;0;32104;;32104;;;;32104;\n" +
                                            "B;1 ;1;Servicio: Arriendo de estacionamiento compartido;;1;;32104;32104;\n" +
                                            "B;2 ;1;Precio vta unitario CLP 32.104 por 1 UN = CLP 32.104,00;;1;;0;0;";

                            StreamWriter writer2 = new StreamWriter(RutaCarpeta + "\\DocumentosTXT\\41\\" + "\\E0" + txbRut.Text + "T" + TipoDocuBEL + "0000" + i + ".txt", false, Encoding.Default);

                                writer2.WriteLine(Documento.TrimEnd('\n'));
                                writer2.Close();
                            }
                        System.Diagnostics.Process.Start(RutaCarpeta + "\\DocumentosTXT\\41\\");
                        break;
                    }

            }
            
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text=="") {

            }
            else
                Foliodesdebel =Int64.Parse(textBox2.Text); 
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    Ambiente = "CLOUD";
                    textBox5.Visible = true;
                    label13.Visible = true;

                    btnDirecBel.Visible = false;
                    label33.Visible = true;
                    textBox7.Visible = true;
                    label11.Visible = false;
                    textBox2.Visible = false;
                    label10.Visible = false;
                    textBox1.Visible = false;
                    label32.Visible = true;
                    checkBEL.Visible = true;
                    if (AccionBOL == "TXT") {
                        btnDirecBel.Visible = true;
                    }
                    break;
                case 1:
                    Ambiente = "SQL";
                    textBox5.Visible = false;
                    label13.Visible = false;
                    btnDirecBel.Visible = true;
                    label33.Visible = false;
                    textBox7.Visible = false;
                    label11.Visible = true;
                    textBox2.Visible = true;
                    label10.Visible = true;
                    textBox1.Visible = true;
                    label32.Visible = false;
                    checkBEL.Visible = false;
                    btnDirecBel.Visible = false;
                    break;
                case 2:
                    Ambiente = "ORACLE";
                    textBox5.Visible = false;
                    label13.Visible = false;
                    btnDirecBel.Visible = true;
                    label33.Visible = false;
                    textBox7.Visible = false;
                    label11.Visible = true;
                    textBox2.Visible = true;
                    label10.Visible = true;
                    textBox1.Visible = true;
                    label32.Visible = false;
                    checkBEL.Visible = false;
                    btnDirecBel.Visible = false;
                    break;
                default:
                    Console.WriteLine("Default case");
                    break;
            }
        }

        private void cmbTipoDocumento_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbTipoDocumento.SelectedIndex)
            {
                case 0:
                    TipoDocuBEL = 39;
                    break;
                case 1:
                    TipoDocuBEL = 41;
                    break;
                default:
                    Console.WriteLine("Default case");
                    break;
            }
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            if (textBox1.Text=="")
            { }
            else
                Foliohastabel = Int64.Parse(textBox1.Text);
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void txbRut_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarLetras(e);
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarLetras(e);
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarLetras(e);
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarLetras(e);
        }

        private void tbxFoliHasta_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            fechaBel = dateTimePicker1.Value.ToString("yyyy-MM-dd");
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox2.SelectedIndex)
            {
                case 0:
                    Accion = "INSERT";
                    txbHolding.Visible = true;
                    LblHolding.Visible = true;
                    CBXAmbiente.Visible = true;
                    label2.Visible = true;
                    label31.Visible = true;
                    Checkdeshast.Visible = true;
                    label26.Visible = true;
                    textBox6.Visible = true;
                    BtnDirectorio.Visible = false;
                    if (Checkdeshast.Checked == false)
                    {
                     lbFoliDesde.Visible = false;
                     tbxFoliDesde.Visible = false;
                     lbFoliHasta.Visible = false;
                     tbxFoliHasta.Visible = false;
                    }
                    if (Checkdeshast.Checked == true)
                    {
                        lbFoliDesde.Visible = true;
                        tbxFoliDesde.Visible = true;
                        lbFoliHasta.Visible = true;
                        tbxFoliHasta.Visible = true;
                        label31.Visible = false;
                        Checkdeshast.Visible = false;
                    }

                    break;
                case 1:
                    Accion = "TXT";
                    txbHolding.Visible = false;
                    LblHolding.Visible = false;
                    CBXAmbiente.Visible = false;
                    label2.Visible = false;
                    label26.Visible = false;
                    textBox6.Visible = false;
                    label31.Visible = false;
                    Checkdeshast.Visible = false;
                    lbFoliDesde.Visible = true;
                    tbxFoliDesde.Visible = true;
                    lbFoliHasta.Visible = true;
                    tbxFoliHasta.Visible = true;
                    BtnDirectorio.Visible = true;
                    break;
                default:
                    Console.WriteLine("Default case");
                    break;
            }
        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            switch (comboBox3.SelectedIndex)
            {
                case 0:
                    AccionBOL = "INSERT";
                    label6.Visible = true;
                    comboBox1.Visible = true;
                    btnDirecBel.Visible = false;
                    label33.Visible = true;
                    textBox7.Visible = true;
                    textBox5.Visible = true;
                    label13.Visible = true;
                    label11.Visible = false;
                    textBox2.Visible = false;
                    label10.Visible = false;
                    textBox1.Visible = false;
                    label32.Visible = true;
                    checkBEL.Visible = true;
                    break;
                case 1:
                    AccionBOL = "TXT";
                    label6.Visible = false;
                    comboBox1.Visible = false;
                    textBox5.Visible = false;
                    label13.Visible = false;
                    btnDirecBel.Visible = true;
                    label33.Visible = false;
                    textBox7.Visible = false;
                    label11.Visible = true;
                    textBox2.Visible = true;
                    label10.Visible = true;
                    textBox1.Visible = true;
                    label32.Visible = false;
                    checkBEL.Visible = false;
                    break;
                default:
                    Console.WriteLine("Default case");
                    break;
            }
        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            DigiReces = DigiRece.Text;
        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {
            RutReces = RutRece.Text;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Seguro Desea Salir?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void comboBox9_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox9.SelectedIndex)
            {
                case 0:
                    TipoDocu = 33;
                    LBLMadera.Visible = false;
                    CKBMADERA.Visible = false;
                    break;
                case 1:
                    TipoDocu = 34;
                    LBLMadera.Visible = false;
                    CKBMADERA.Visible = false;
                    break;
                case 2:
                    TipoDocu = 43;
                    LBLMadera.Visible = false;
                    CKBMADERA.Visible = false;
                    break;
                case 3:
                    TipoDocu = 46;
                    LBLMadera.Visible = false;
                    CKBMADERA.Visible = false;
                    break;
                case 4:
                    TipoDocu = 52;
                    LBLMadera.Visible = true;
                    CKBMADERA.Visible = true;
                    break;
                case 5:
                    TipoDocu = 56;
                    LBLMadera.Visible = false;
                    CKBMADERA.Visible = false;
                    break;
                default:
                    TipoDocu = 61;
                    LBLMadera.Visible = false;
                    CKBMADERA.Visible = false;
                    break;
            }
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            RutEmis = RutEmi.Text;
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            DigiEmis = DigiEmi.Text;
        }

        private void dateTimePicker3_ValueChanged(object sender, EventArgs e)
        {
            fecha = dtFechEmis.Value.ToString("yyyy-MM-dd");
            Periodo = dtFechEmis.Value.ToString("yyyyMM");
            FechaTED = dtFechEmis.Value.ToString("yyyy-MM-ddTHH:mm:ss");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Definiciones Define = new Definiciones();
            switch (TipoAmbiente) {
                case 6200:
                    definicion_qmta_rece_info = Define.qmta_rece_info();
                    definicion_qmta_rece_part = Define.qmta_rece_part();

                    validarCampos();
                    Metodos metodo = new Metodos();
                    //      
                    switch (TipoDocu)
                    {
                        case 33:
                            validarCampos();

                            for (int i = Convert.ToInt32(Foliodesdedto); i <= Foliohastadto; i++)
                            {
                                ConexionBD conexionCLOUDX = new ConexionBD(Ambiente);
                                conexionCLOUDX.abrirBD();


                                String Dato = conexionCLOUDX.recupera_dato("select top 1 [mail_msid]from qmta_rece_info  order by corr_info desc");
                                if (Dato == "")
                                {
                                    Dato = "0";
                                }
                                int mail_msid = int.Parse(Dato);
                                mail_msid = mail_msid + 1;

                                String a = definicion_qmta_rece_info +
                                          "(" + mail_msid + ",'Waldo Gonzalez <waldo.gonzalez@dbnetcorp.com>', N'jorgeflores@mt5.dbnetcorp.com', '', 'Documentos','" + FechaDTOS + " 00:00:00', N'NEW', NULL,'" + FechaDTOS + " 00:00:00.570', NULL, NULL)";
                                conexionCLOUDX.EjecutarSql(a);
                                String imprime = metodo.documento33(RutEmis, DigiEmis, RutReces, DigiReces, FechaDTOS, Convert.ToInt32(i));

                                if (checkPDF.Checked == true)
                                {
                                    String PDF64A = metodo.PDF();
                                    String PDF64B = metodo.PDF();

                                    String B = definicion_qmta_rece_part + "(" + mail_msid + ",'DocumentoProveedor','envCliE" + i + ".xml','text/xml','US-ASCII','" + imprime + "','NEW',NULL,'" + FechaDTOS + " 00:00:00.033')" +
                                    definicion_qmta_rece_part + "(" + mail_msid + ", 'Otro adjunto', 'PDFA" + mail_msid + i + ".pdf', 'application/pdf', '', '" + PDF64A + "', 'NEW', NULL, '" + FechaDTOS + " 00:00:00.033')" +
                                    definicion_qmta_rece_part + "(" + mail_msid + ", 'Otro adjunto', 'PDFB" + mail_msid + i + ".pdf', 'application/pdf', '', '" + PDF64B + "', 'NEW', NULL, '" + FechaDTOS + " 00:00:00.033')";
                                    conexionCLOUDX.EjecutarSql(B);
                                    conexionCLOUDX.CerraBD();
                                }
                                else
                                {
                                    String B = definicion_qmta_rece_part + "(" + mail_msid + ",'DocumentoProveedor','envCliE" + i + ".xml','text/xml','US-ASCII','" + imprime + "','NEW',NULL,'" + FechaDTOS + " 00:00:00.033')";
                                    conexionCLOUDX.EjecutarSql(B);
                                    conexionCLOUDX.CerraBD();
                                }



                            }
                            MessageBox.Show("Termine ");
                            break;

                        case 34:
                            validarCampos();

                            for (int i = Convert.ToInt32(Foliodesdedto); i <= Foliohastadto; i++)
                            {

                                ConexionBD conexionCLOUDX = new ConexionBD(Ambiente);
                                conexionCLOUDX.abrirBD();

                                String Dato = conexionCLOUDX.recupera_dato("select top 1 [mail_msid]from qmta_rece_info  order by corr_info desc");
                                if (Dato == "")
                                {
                                    Dato = "0";
                                }
                                int mail_msid = int.Parse(Dato);
                                mail_msid = mail_msid + 1;

                                String a = definicion_qmta_rece_info +
                                          "(" + mail_msid + ",'Waldo Gonzalez <waldo.gonzalez@dbnetcorp.com>', N'jorgeflores@mt5.dbnetcorp.com', '', 'Documentos','" + FechaDTOS + " 00:00:00', N'NEW', NULL,'" + FechaDTOS + " 00:00:00.570', NULL, NULL)";
                                conexionCLOUDX.EjecutarSql(a);
                                String imprime = metodo.documento34(RutEmis, DigiEmis, RutReces, DigiReces, FechaDTOS, Convert.ToInt32(i));

                                if (checkPDF.Checked == true)
                                {
                                    String PDF64A = metodo.PDF();
                                    String PDF64B = metodo.PDF();
                                    String B = definicion_qmta_rece_part + "(" + mail_msid + ",'DocumentoProveedor','envCliE" + i + ".xml','text/xml','US-ASCII','" + imprime + "','NEW',NULL,'" + FechaDTOS + " 00:00:00.033')" +
                                    definicion_qmta_rece_part + "(" + mail_msid + ", 'Otro adjunto', 'PDFA" + mail_msid + i + ".pdf', 'application/pdf', '', '" + PDF64A + "', 'NEW', NULL, '" + FechaDTOS + " 00:00:00.033')" +
                                    definicion_qmta_rece_part + "(" + mail_msid + ", 'Otro adjunto', 'PDFB" + mail_msid + i + ".pdf', 'application/pdf', '', '" + PDF64B + "', 'NEW', NULL, '" + FechaDTOS + " 00:00:00.033')";
                                    conexionCLOUDX.EjecutarSql(B);
                                    conexionCLOUDX.CerraBD();
                                }
                                else
                                {
                                    String B = definicion_qmta_rece_part + "(" + mail_msid + ",'DocumentoProveedor','envCliE" + i + ".xml','text/xml','US-ASCII','" + imprime + "','NEW',NULL,'" + FechaDTOS + " 00:00:00.033')";
                                    conexionCLOUDX.EjecutarSql(B);
                                    conexionCLOUDX.CerraBD();
                                }
                            }
                            MessageBox.Show("Termine ");
                            break;

                        case 43:
                            validarCampos();

                            for (int i = Convert.ToInt32(Foliodesdedto); i <= Foliohastadto; i++)
                            {

                                ConexionBD conexionCLOUDX = new ConexionBD(Ambiente);
                                conexionCLOUDX.abrirBD();

                                String Dato = conexionCLOUDX.recupera_dato("select top 1 [mail_msid]from qmta_rece_info  order by corr_info desc");
                                if (Dato == "")
                                {
                                    Dato = "0";
                                }
                                int mail_msid = int.Parse(Dato);
                                mail_msid = mail_msid + 1;

                                String a = definicion_qmta_rece_info +
                                          "(" + mail_msid + ",'Waldo Gonzalez <waldo.gonzalez@dbnetcorp.com>', N'jorgeflores@mt5.dbnetcorp.com', '', 'Documentos','" + FechaDTOS + " 14:09:34', N'NEW', NULL,'" + FechaDTOS + " 00:00:00.570', NULL, NULL)";
                                conexionCLOUDX.EjecutarSql(a);
                                String imprime = metodo.documento43(RutEmis, DigiEmis, RutReces, DigiReces, FechaDTOS, Convert.ToInt32(i));

                                if (checkPDF.Checked == true)
                                {
                                    String PDF64A = metodo.PDF();
                                    String PDF64B = metodo.PDF();

                                    String B = definicion_qmta_rece_part + "(" + mail_msid + ",'DocumentoProveedor','envCliE00207768361.xml','text/xml','US-ASCII','" + imprime + "','NEW',NULL,'" + FechaDTOS + " 00:00:00.033')" +
                                    definicion_qmta_rece_part + "(" + mail_msid + ", 'Otro adjunto', 'PDFA" + mail_msid + Foliodesdedto + ".pdf', 'application/pdf', '', '" + PDF64A + "', 'NEW', NULL, '" + FechaDTOS + " 00:00:00.033')" +
                                    definicion_qmta_rece_part + "(" + mail_msid + ", 'Otro adjunto', 'PDFB" + mail_msid + Foliodesdedto + ".pdf', 'application/pdf', '', '" + PDF64B + "', 'NEW', NULL, '" + FechaDTOS + " 00:00:00.033')";
                                    conexionCLOUDX.EjecutarSql(B);
                                    conexionCLOUDX.CerraBD();
                                }
                                else
                                {
                                    String B = definicion_qmta_rece_part + "(" + mail_msid + ",'DocumentoProveedor','envCliE00207768361.xml','text/xml','US-ASCII','" + imprime + "','NEW',NULL,'" + FechaDTOS + " 00:00:00.033')";
                                    conexionCLOUDX.EjecutarSql(B);
                                    conexionCLOUDX.CerraBD();
                                }


                            }
                            MessageBox.Show("Termine ");
                            break;

                        case 46:
                            validarCampos();

                            for (int i = Convert.ToInt32(Foliodesdedto); i <= Foliohastadto; i++)
                            {

                                ConexionBD conexionCLOUDX = new ConexionBD(Ambiente);
                                conexionCLOUDX.abrirBD();

                                String Dato = conexionCLOUDX.recupera_dato("select top 1 [mail_msid]from qmta_rece_info  order by corr_info desc");
                                if (Dato == "")
                                {
                                    Dato = "0";
                                }
                                int mail_msid = int.Parse(Dato);
                                mail_msid = mail_msid + 1;

                                String a = definicion_qmta_rece_info +
                                          "(" + mail_msid + ",'Waldo Gonzalez <waldo.gonzalez@dbnetcorp.com>', N'jorgeflores@mt5.dbnetcorp.com', '', 'Documentos','" + FechaDTOS + " 14:09:34', N'NEW', NULL,'" + FechaDTOS + " 00:00:00.570', NULL, NULL)";
                                conexionCLOUDX.EjecutarSql(a);
                                String imprime = metodo.documento46(RutEmis, DigiEmis, RutReces, DigiReces, FechaDTOS, Convert.ToInt32(i));

                                if (checkPDF.Checked == true)
                                {
                                    String PDF64A = metodo.PDF();
                                    String PDF64B = metodo.PDF();


                                    String B = definicion_qmta_rece_part + "(" + mail_msid + ",'DocumentoProveedor','envCliE00207768361.xml','text/xml','US-ASCII','" + imprime + "','NEW',NULL,'" + FechaDTOS + " 00:00:00.033')" +
                                    definicion_qmta_rece_part + "(" + mail_msid + ", 'Otro adjunto', 'PDFA" + mail_msid + Foliodesdedto + ".pdf', 'application/pdf', '', '" + PDF64A + "', 'NEW', NULL, '" + FechaDTOS + " 00:00:00.033')" +
                                    definicion_qmta_rece_part + "(" + mail_msid + ", 'Otro adjunto', 'PDFB" + mail_msid + Foliodesdedto + ".pdf', 'application/pdf', '', '" + PDF64B + "', 'NEW', NULL, '" + FechaDTOS + " 00:00:00.033')";
                                    conexionCLOUDX.EjecutarSql(B);
                                    conexionCLOUDX.CerraBD();
                                }
                                else
                                {
                                    String B = definicion_qmta_rece_part + "(" + mail_msid + ",'DocumentoProveedor','envCliE00207768361.xml','text/xml','US-ASCII','" + imprime + "','NEW',NULL,'" + FechaDTOS + " 00:00:00.033')";
                                    conexionCLOUDX.EjecutarSql(B);
                                    conexionCLOUDX.CerraBD();
                                }

                            }
                            MessageBox.Show("Termine ");
                            break;

                        case 52:
                            validarCampos();

                            for (int i = Convert.ToInt32(Foliodesdedto); i <= Foliohastadto; i++)
                            {

                                ConexionBD conexionCLOUDX = new ConexionBD(Ambiente);
                                conexionCLOUDX.abrirBD();
                                String imprime;

                                String Dato = conexionCLOUDX.recupera_dato("select top 1 [mail_msid]from qmta_rece_info  order by corr_info desc");
                                if (Dato == "")
                                {
                                    Dato = "0";
                                }
                                int mail_msid = int.Parse(Dato);
                                mail_msid = mail_msid + 1;

                                if (CKBMADERA.Checked == true)
                                {
                                    String a = definicion_qmta_rece_info +
                                          "(" + mail_msid + ",'Waldo Gonzalez <waldo.gonzalez@dbnetcorp.com>', N'jorgeflores@mt5.dbnetcorp.com', '', 'Documentos','" + FechaDTOS + " 14:09:34', N'NEW', NULL,'" + FechaDTOS + " 00:00:00.570', NULL, NULL)";
                                    conexionCLOUDX.EjecutarSql(a);
                                     imprime = metodo.documento52(RutEmis, DigiEmis, RutReces, DigiReces, FechaDTOS, Convert.ToInt32(i),"Si");
                                }
                                else
                                {
                                    String a = definicion_qmta_rece_info +
                                          "(" + mail_msid + ",'Waldo Gonzalez <waldo.gonzalez@dbnetcorp.com>', N'jorgeflores@mt5.dbnetcorp.com', '', 'Documentos','" + FechaDTOS + " 14:09:34', N'NEW', NULL,'" + FechaDTOS + " 00:00:00.570', NULL, NULL)";
                                     conexionCLOUDX.EjecutarSql(a);
                                     imprime = metodo.documento52(RutEmis, DigiEmis, RutReces, DigiReces, FechaDTOS, Convert.ToInt32(i));
                                }
                                    if (checkPDF.Checked == true)
                                {
                                    String PDF64A = metodo.PDF();
                                    String PDF64B = metodo.PDF();

                                    String B = definicion_qmta_rece_part + "(" + mail_msid + ",'DocumentoProveedor','envCliE00207768361.xml','text/xml','US-ASCII','" + imprime + "','NEW',NULL,'" + FechaDTOS + " 00:00:00.033')" +
                                    definicion_qmta_rece_part + "(" + mail_msid + ", 'Otro adjunto', 'PDFA" + mail_msid + Foliodesdedto + ".pdf', 'application/pdf', '', '" + PDF64A + "', 'NEW', NULL, '" + FechaDTOS + " 00:00:00.033')" +
                                    definicion_qmta_rece_part + "(" + mail_msid + ", 'Otro adjunto', 'PDFB" + mail_msid + Foliodesdedto + ".pdf', 'application/pdf', '', '" + PDF64B + "', 'NEW', NULL, '" + FechaDTOS + " 00:00:00.033')";
                                    conexionCLOUDX.EjecutarSql(B);
                                    conexionCLOUDX.CerraBD();
                                }
                                else
                                {
                                    String B = definicion_qmta_rece_part + "(" + mail_msid + ",'DocumentoProveedor','envCliE00207768361.xml','text/xml','US-ASCII','" + imprime + "','NEW',NULL,'" + FechaDTOS + " 00:00:00.033')";
                                    conexionCLOUDX.EjecutarSql(B);
                                    conexionCLOUDX.CerraBD();
                                }
                                

                            }
                            MessageBox.Show("Termine ");
                            break;

                        case 56:
                            validarCampos();

                            for (int i = Convert.ToInt32(Foliodesdedto); i <= Foliohastadto; i++)
                            {

                                ConexionBD conexionCLOUDX = new ConexionBD(Ambiente);
                                conexionCLOUDX.abrirBD();

                                String Dato = conexionCLOUDX.recupera_dato("select top 1 [mail_msid]from qmta_rece_info  order by corr_info desc");
                                if (Dato == "")
                                {
                                    Dato = "0";
                                }
                                int mail_msid = int.Parse(Dato);
                                mail_msid = mail_msid + 1;

                                String a = definicion_qmta_rece_info +
                                          "(" + mail_msid + ",'Waldo Gonzalez <waldo.gonzalez@dbnetcorp.com>', N'jorgeflores@mt5.dbnetcorp.com', '', 'Documentos','" + FechaDTOS + " 14:09:34', N'NEW', NULL,'" + FechaDTOS + " 00:00:00.570', NULL, NULL)";
                                conexionCLOUDX.EjecutarSql(a);
                                String imprime = metodo.documento56(RutEmis, DigiEmis, RutReces, DigiReces, FechaDTOS, Convert.ToInt32(i));

                                if (checkPDF.Checked == true)
                                {
                                    String PDF64A = metodo.PDF();
                                    String PDF64B = metodo.PDF();

                                    String B = definicion_qmta_rece_part + "(" + mail_msid + ",'DocumentoProveedor','envCliE00207768361.xml','text/xml','US-ASCII','" + imprime + "','NEW',NULL,'" + FechaDTOS + " 00:00:00.033')" +
                                    definicion_qmta_rece_part + "(" + mail_msid + ", 'Otro adjunto', 'PDFA" + mail_msid + Foliodesdedto + ".pdf', 'application/pdf', '', '" + PDF64A + "', 'NEW', NULL, '" + FechaDTOS + " 00:00:00.033')" +
                                    definicion_qmta_rece_part + "(" + mail_msid + ", 'Otro adjunto', 'PDFB" + mail_msid + Foliodesdedto + ".pdf', 'application/pdf', '', '" + PDF64B + "', 'NEW', NULL, '" + FechaDTOS + " 00:00:00.033')";
                                    conexionCLOUDX.EjecutarSql(B);
                                    conexionCLOUDX.CerraBD();
                                }
                                else
                                {
                                    String B = definicion_qmta_rece_part + "(" + mail_msid + ",'DocumentoProveedor','envCliE00207768361.xml','text/xml','US-ASCII','" + imprime + "','NEW',NULL,'" + FechaDTOS + " 00:00:00.033')";
                                    conexionCLOUDX.EjecutarSql(B);
                                    conexionCLOUDX.CerraBD();

                                }


                            }
                            MessageBox.Show("Termine ");
                            break;

                        case 61:
                            validarCampos();

                            for (int i = Convert.ToInt32(Foliodesdedto); i <= Foliohastadto; i++)
                            {

                                ConexionBD conexionCLOUDX = new ConexionBD(Ambiente);
                                conexionCLOUDX.abrirBD();

                                String Dato = conexionCLOUDX.recupera_dato("select top 1 [mail_msid]from qmta_rece_info  order by corr_info desc");
                                if (Dato == "")
                                {
                                    Dato = "0";
                                }
                                int mail_msid = int.Parse(Dato);
                                mail_msid = mail_msid + 1;

                                String a = definicion_qmta_rece_info +
                                          "(" + mail_msid + ",'Waldo Gonzalez <waldo.gonzalez@dbnetcorp.com>', N'jorgeflores@mt5.dbnetcorp.com', '', 'Documentos','" + FechaDTOS + " 14:09:34', N'NEW', NULL,'" + FechaDTOS + " 00:00:00.570', NULL, NULL)";
                                conexionCLOUDX.EjecutarSql(a);
                                String imprime = metodo.documento61(RutEmis, DigiEmis, RutReces, DigiReces, FechaDTOS, Convert.ToInt32(i));

                                if (checkPDF.Checked == true)
                                {
                                    String PDF64A = metodo.PDF();
                                    String PDF64B = metodo.PDF();

                                    String B = definicion_qmta_rece_part + "(" + mail_msid + ",'DocumentoProveedor','envCliE00207768361.xml','text/xml','US-ASCII','" + imprime + "','NEW',NULL,'" + FechaDTOS + " 00:00:00.033')" +
                                    definicion_qmta_rece_part + "(" + mail_msid + ", 'Otro adjunto', 'PDFA" + mail_msid + Foliodesdedto + ".pdf', 'application/pdf', '', '" + PDF64A + "', 'NEW', NULL, '" + FechaDTOS + " 00:00:00.033')" +
                                    definicion_qmta_rece_part + "(" + mail_msid + ", 'Otro adjunto', 'PDFB" + mail_msid + Foliodesdedto + ".pdf', 'application/pdf', '', '" + PDF64B + "', 'NEW', NULL, '" + FechaDTOS + " 00:00:00.033')";
                                    conexionCLOUDX.EjecutarSql(B);
                                    conexionCLOUDX.CerraBD();
                                }
                                else
                                {
                                    String B = definicion_qmta_rece_part + "(" + mail_msid + ",'DocumentoProveedor','envCliE00207768361.xml','text/xml','US-ASCII','" + imprime + "','NEW',NULL,'" + FechaDTOS + " 00:00:00.033')";
                                    conexionCLOUDX.EjecutarSql(B);
                                    conexionCLOUDX.CerraBD();

                                }


                            }
                            MessageBox.Show("Termine ");
                            break;
                    }
                    break;

                case 5200:

                    definicion_Dbq_arch = Define.Dbq_arch();
                    definicion_Dbq_arch_clob = Define.Dbq_arch_clob();

                    validarCampos();
                    Metodos metodo52 = new Metodos();
                    //      
                    switch (TipoDocu)
                    {
                        case 33:
                            validarCampos();

                            for (int i = Convert.ToInt32(Foliodesdedto); i <= Foliohastadto; i++)
                            {
                                ConexionBD conexionCLOUDX = new ConexionBD(Ambiente);
                                conexionCLOUDX.abrirBD();

                                decimal Dato = conexionCLOUDX.recupera_dato_recimal(" select top 1 [CODI_GRPO] from [DBQ_ARCH]  order by Codi_arch desc");
                                if (Dato == 0)
                                {
                                    Dato = 0;
                                }
                                int CODI_GRPO = Decimal.ToInt32(Dato); ;
                                CODI_GRPO = CODI_GRPO + 1;

                                String imprime = metodo52.documento33(RutEmis, DigiEmis, RutReces, DigiReces, FechaDTOS, Convert.ToInt32(i));

                                if (checkPDF.Checked == true)
                                {
                                    String PDF64A = metodo52.PDF();

                                    String A = definicion_Dbq_arch + " (" + CODI_GRPO + ",'ING','X','dbq_scan_arch','dbq_read_mail',  CAST(N'" + FechaDTOS + " 00:00:00.677' AS DateTime), CAST(N'" + FechaDTOS + " 00:00:00.677' AS DateTime), 0,'D:\\DBNeTSE\\ReadMail\\WRK\\envCliE" + i + "6.xml',  'text/xml', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL,'T', NULL)";
                                    conexionCLOUDX.EjecutarSql(A);
                                    int CODI_ARCHDEcimal = Decimal.ToInt32( conexionCLOUDX.recupera_dato_recimal(" select top 1 CODI_ARCH from [DBQ_ARCH]  order by Codi_arch desc"));
                                    String CODI_ARCH = Convert.ToString(CODI_ARCHDEcimal);
                                    String B = definicion_Dbq_arch_clob + "(" + CODI_ARCH + ",'" + imprime + "')";
                                    conexionCLOUDX.EjecutarSql(B);

                                    String C = definicion_Dbq_arch + " (" + CODI_GRPO + ",'ING','X','dbq_scan_arch','dbq_read_mail',  CAST(N'" + FechaDTOS + " 00:00:00.677' AS DateTime), CAST(N'" + FechaDTOS + " 00:00:00.677' AS DateTime), 0,'D:\\DBNeTSE\\ReadMail\\WRK\\CERT_PREVACA.xslt_" + i + ".pdf',  'application/pdf', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL,'T', NULL)";
                                    conexionCLOUDX.EjecutarSql(C);
                                    int CODI_ARCHDEcimal2 = Decimal.ToInt32( conexionCLOUDX.recupera_dato_recimal(" select top 1 CODI_ARCH from [DBQ_ARCH]  order by Codi_arch desc"));
                                    String CODI_ARCH2= Convert.ToString(CODI_ARCHDEcimal2);
                                    String D = definicion_Dbq_arch_clob + "(" + CODI_ARCH2 + ",'" + PDF64A + "')";
                                    conexionCLOUDX.EjecutarSql(D);
                                    conexionCLOUDX.CerraBD();
                                }
                                else
                                {

                                    String A = definicion_Dbq_arch + " (" + CODI_GRPO + ",'ING','X','dbq_scan_arch','dbq_read_mail',  CAST(N'" + FechaDTOS + " 00:00:00.677' AS DateTime), CAST(N'" + FechaDTOS + " 00:00:00.677' AS DateTime), 0,'D:\\DBNeTSE\\ReadMail\\WRK\\envCliE" + i + "6.xml',  'text/xml', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL,'T', NULL)";
                                    conexionCLOUDX.EjecutarSql(A);
                                    int CODI_ARCHDEcimal = Decimal.ToInt32(conexionCLOUDX.recupera_dato_recimal(" select top 1 CODI_ARCH from [DBQ_ARCH]  order by Codi_arch desc"));
                                    String CODI_ARCH = Convert.ToString(CODI_ARCHDEcimal);
                                    String B = definicion_Dbq_arch_clob +"("+ CODI_ARCH +",'"+ imprime+"')";
                                    
                                    conexionCLOUDX.EjecutarSql(B);
                                    conexionCLOUDX.CerraBD();
                                }



                            }
                            MessageBox.Show("Termine ");
                            break;
                            
                        case 34:
                            validarCampos();

                            for (int i = Convert.ToInt32(Foliodesdedto); i <= Foliohastadto; i++)
                            {
                                ConexionBD conexionCLOUDX = new ConexionBD(Ambiente);
                                conexionCLOUDX.abrirBD();

                                decimal Dato = conexionCLOUDX.recupera_dato_recimal(" select top 1 [CODI_GRPO] from [DBQ_ARCH]  order by Codi_arch desc");
                                if (Dato == 0)
                                {
                                    Dato = 0;
                                }
                                int CODI_GRPO = Decimal.ToInt32(Dato); ;
                                CODI_GRPO = CODI_GRPO + 1;

                                String imprime = metodo52.documento34(RutEmis, DigiEmis, RutReces, DigiReces, FechaDTOS, Convert.ToInt32(i));

                                if (checkPDF.Checked == true)
                                {
                                    String PDF64A = metodo52.PDF();

                                    String A = definicion_Dbq_arch + " (" + CODI_GRPO + ",'ING','X','dbq_scan_arch','dbq_read_mail',  CAST(N'" + FechaDTOS + " 00:00:00.677' AS DateTime), CAST(N'" + FechaDTOS + " 00:00:00.677' AS DateTime), 0,'D:\\DBNeTSE\\ReadMail\\WRK\\envCliE" + i + "6.xml',  'text/xml', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL,'T', NULL)";
                                    conexionCLOUDX.EjecutarSql(A);
                                    int CODI_ARCHDEcimal = Decimal.ToInt32(conexionCLOUDX.recupera_dato_recimal(" select top 1 CODI_ARCH from [DBQ_ARCH]  order by Codi_arch desc"));
                                    String CODI_ARCH = Convert.ToString(CODI_ARCHDEcimal);
                                    String B = definicion_Dbq_arch_clob + "(" + CODI_ARCH + ",'" + imprime + "')";
                                    conexionCLOUDX.EjecutarSql(B);

                                    String C = definicion_Dbq_arch + " (" + CODI_GRPO + ",'ING','X','dbq_scan_arch','dbq_read_mail',  CAST(N'" + FechaDTOS + " 00:00:00.677' AS DateTime), CAST(N'" + FechaDTOS + " 00:00:00.677' AS DateTime), 0,'D:\\DBNeTSE\\ReadMail\\WRK\\CERT_PREVACA.xslt_" + i + ".pdf',  'application/pdf', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL,'T', NULL)";
                                    conexionCLOUDX.EjecutarSql(C);
                                    int CODI_ARCHDEcimal2 = Decimal.ToInt32(conexionCLOUDX.recupera_dato_recimal(" select top 1 CODI_ARCH from [DBQ_ARCH]  order by Codi_arch desc"));
                                    String CODI_ARCH2 = Convert.ToString(CODI_ARCHDEcimal2);
                                    String D = definicion_Dbq_arch_clob + "(" + CODI_ARCH2 + ",'" + PDF64A + "')";
                                    conexionCLOUDX.EjecutarSql(D);
                                    conexionCLOUDX.CerraBD();
                                }
                                else
                                {

                                    String A = definicion_Dbq_arch + " (" + CODI_GRPO + ",'ING','X','dbq_scan_arch','dbq_read_mail',  CAST(N'" + FechaDTOS + " 00:00:00.677' AS DateTime), CAST(N'" + FechaDTOS + " 00:00:00.677' AS DateTime), 0,'D:\\DBNeTSE\\ReadMail\\WRK\\envCliE" + i + "6.xml',  'text/xml', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL,'T', NULL)";
                                    conexionCLOUDX.EjecutarSql(A);
                                    int CODI_ARCHDEcimal = Decimal.ToInt32(conexionCLOUDX.recupera_dato_recimal(" select top 1 CODI_ARCH from [DBQ_ARCH]  order by Codi_arch desc"));
                                    String CODI_ARCH = Convert.ToString(CODI_ARCHDEcimal);
                                    String B = definicion_Dbq_arch_clob + "(" + CODI_ARCH + ",'" + imprime + "')";

                                    conexionCLOUDX.EjecutarSql(B);
                                    conexionCLOUDX.CerraBD();
                                }



                            }
                            MessageBox.Show("Termine ");
                            break;

                        case 43:
                            validarCampos();

                            for (int i = Convert.ToInt32(Foliodesdedto); i <= Foliohastadto; i++)
                            {
                                ConexionBD conexionCLOUDX = new ConexionBD(Ambiente);
                                conexionCLOUDX.abrirBD();

                                decimal Dato = conexionCLOUDX.recupera_dato_recimal(" select top 1 [CODI_GRPO] from [DBQ_ARCH]  order by Codi_arch desc");
                                if (Dato == 0)
                                {
                                    Dato = 0;
                                }
                                int CODI_GRPO = Decimal.ToInt32(Dato); ;
                                CODI_GRPO = CODI_GRPO + 1;

                                String imprime = metodo52.documento43(RutEmis, DigiEmis, RutReces, DigiReces, FechaDTOS, Convert.ToInt32(i));

                                if (checkPDF.Checked == true)
                                {
                                    String PDF64A = metodo52.PDF();
                                    String PDF64B = metodo52.PDF();

                                    String A = definicion_Dbq_arch + " (" + CODI_GRPO + ",'ING','X','dbq_scan_arch','dbq_read_mail',  CAST(N'" + FechaDTOS + " 00:00:00.677' AS DateTime), CAST(N'" + FechaDTOS + " 00:00:00.677' AS DateTime), 0,'D:\\DBNeTSE\\ReadMail\\WRK\\envCliE" + i + "6.xml',  'text/xml', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL,'T', NULL)";
                                    conexionCLOUDX.EjecutarSql(A);
                                    int CODI_ARCHDEcimal = Decimal.ToInt32(conexionCLOUDX.recupera_dato_recimal(" select top 1 CODI_ARCH from [DBQ_ARCH]  order by Codi_arch desc"));
                                    String CODI_ARCH = Convert.ToString(CODI_ARCHDEcimal);
                                    String B = definicion_Dbq_arch_clob + "(" + CODI_ARCH + ",'" + imprime + "')";
                                    conexionCLOUDX.EjecutarSql(B);

                                    String C = definicion_Dbq_arch + " (" + CODI_GRPO + ",'ING','X','dbq_scan_arch','dbq_read_mail',  CAST(N'" + FechaDTOS + " 00:00:00.677' AS DateTime), CAST(N'" + FechaDTOS + " 00:00:00.677' AS DateTime), 0,'D:\\DBNeTSE\\ReadMail\\WRK\\CERT_PREVACA.xslt_" + i + ".pdf',  'application/pdf', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL,'T', NULL)";
                                    conexionCLOUDX.EjecutarSql(C);
                                    int CODI_ARCHDEcimal2 = Decimal.ToInt32(conexionCLOUDX.recupera_dato_recimal(" select top 1 CODI_ARCH from [DBQ_ARCH]  order by Codi_arch desc"));
                                    String CODI_ARCH2 = Convert.ToString(CODI_ARCHDEcimal2);
                                    String D = definicion_Dbq_arch_clob + "(" + CODI_ARCH2 + ",'" + PDF64A + "')";
                                    conexionCLOUDX.EjecutarSql(D);
                                    conexionCLOUDX.CerraBD();
                                }
                                else
                                {

                                    String A = definicion_Dbq_arch + " (" + CODI_GRPO + ",'ING','X','dbq_scan_arch','dbq_read_mail',  CAST(N'" + FechaDTOS + " 00:00:00.677' AS DateTime), CAST(N'" + FechaDTOS + " 00:00:00.677' AS DateTime), 0,'D:\\DBNeTSE\\ReadMail\\WRK\\envCliE" + i + "6.xml',  'text/xml', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL,'T', NULL)";
                                    conexionCLOUDX.EjecutarSql(A);
                                    int CODI_ARCHDEcimal = Decimal.ToInt32(conexionCLOUDX.recupera_dato_recimal(" select top 1 CODI_ARCH from [DBQ_ARCH]  order by Codi_arch desc"));
                                    String CODI_ARCH = Convert.ToString(CODI_ARCHDEcimal);
                                    String B = definicion_Dbq_arch_clob + "(" + CODI_ARCH + ",'" + imprime + "')";

                                    conexionCLOUDX.EjecutarSql(B);
                                    conexionCLOUDX.CerraBD();
                                }



                            }
                            MessageBox.Show("Termine ");
                            break;

                        case 46:
                            validarCampos();

                            for (int i = Convert.ToInt32(Foliodesdedto); i <= Foliohastadto; i++)
                            {
                                ConexionBD conexionCLOUDX = new ConexionBD(Ambiente);
                                conexionCLOUDX.abrirBD();

                                decimal Dato = conexionCLOUDX.recupera_dato_recimal(" select top 1 [CODI_GRPO] from [DBQ_ARCH]  order by Codi_arch desc");
                                if (Dato == 0)
                                {
                                    Dato = 0;
                                }
                                int CODI_GRPO = Decimal.ToInt32(Dato); ;
                                CODI_GRPO = CODI_GRPO + 1;

                                String imprime = metodo52.documento46(RutEmis, DigiEmis, RutReces, DigiReces, FechaDTOS, Convert.ToInt32(i));

                                if (checkPDF.Checked == true)
                                {
                                    String PDF64A = metodo52.PDF();
                                    String PDF64B = metodo52.PDF();

                                    String A = definicion_Dbq_arch + " (" + CODI_GRPO + ",'ING','X','dbq_scan_arch','dbq_read_mail',  CAST(N'" + FechaDTOS + " 00:00:00.677' AS DateTime), CAST(N'" + FechaDTOS + " 00:00:00.677' AS DateTime), 0,'D:\\DBNeTSE\\ReadMail\\WRK\\envCliE" + i + "6.xml',  'text/xml', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL,'T', NULL)";
                                    conexionCLOUDX.EjecutarSql(A);
                                    int CODI_ARCHDEcimal = Decimal.ToInt32(conexionCLOUDX.recupera_dato_recimal(" select top 1 CODI_ARCH from [DBQ_ARCH]  order by Codi_arch desc"));
                                    String CODI_ARCH = Convert.ToString(CODI_ARCHDEcimal);
                                    String B = definicion_Dbq_arch_clob + "(" + CODI_ARCH + ",'" + imprime + "')";
                                    conexionCLOUDX.EjecutarSql(B);

                                    String C = definicion_Dbq_arch + " (" + CODI_GRPO + ",'ING','X','dbq_scan_arch','dbq_read_mail',  CAST(N'" + FechaDTOS + " 00:00:00.677' AS DateTime), CAST(N'" + FechaDTOS + " 00:00:00.677' AS DateTime), 0,'D:\\DBNeTSE\\ReadMail\\WRK\\CERT_PREVACA.xslt_" + i + ".pdf',  'application/pdf', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL,'T', NULL)";
                                    conexionCLOUDX.EjecutarSql(C);
                                    int CODI_ARCHDEcimal2 = Decimal.ToInt32(conexionCLOUDX.recupera_dato_recimal(" select top 1 CODI_ARCH from [DBQ_ARCH]  order by Codi_arch desc"));
                                    String CODI_ARCH2 = Convert.ToString(CODI_ARCHDEcimal2);
                                    String D = definicion_Dbq_arch_clob + "(" + CODI_ARCH2 + ",'" + PDF64A + "')";
                                    conexionCLOUDX.EjecutarSql(D);
                                    conexionCLOUDX.CerraBD();
                                }
                                else
                                {

                                    String A = definicion_Dbq_arch + " (" + CODI_GRPO + ",'ING','X','dbq_scan_arch','dbq_read_mail',  CAST(N'" + FechaDTOS + " 00:00:00.677' AS DateTime), CAST(N'" + FechaDTOS + " 00:00:00.677' AS DateTime), 0,'D:\\DBNeTSE\\ReadMail\\WRK\\envCliE" + i + "6.xml',  'text/xml', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL,'T', NULL)";
                                    conexionCLOUDX.EjecutarSql(A);
                                    int CODI_ARCHDEcimal = Decimal.ToInt32(conexionCLOUDX.recupera_dato_recimal(" select top 1 CODI_ARCH from [DBQ_ARCH]  order by Codi_arch desc"));
                                    String CODI_ARCH = Convert.ToString(CODI_ARCHDEcimal);
                                    String B = definicion_Dbq_arch_clob + "(" + CODI_ARCH + ",'" + imprime + "')";

                                    conexionCLOUDX.EjecutarSql(B);
                                    conexionCLOUDX.CerraBD();
                                }



                            }
                            MessageBox.Show("Termine ");
                            break;

                        case 52:
                            validarCampos();

                            for (int i = Convert.ToInt32(Foliodesdedto); i <= Foliohastadto; i++)
                            {
                                ConexionBD conexionCLOUDX = new ConexionBD(Ambiente);
                                conexionCLOUDX.abrirBD();
                                String imprime;

                                decimal Dato = conexionCLOUDX.recupera_dato_recimal(" select top 1 [CODI_GRPO] from [DBQ_ARCH]  order by Codi_arch desc");
                                if (Dato == 0)
                                {
                                    Dato = 0;
                                }
                                int CODI_GRPO = Decimal.ToInt32(Dato); ;
                                CODI_GRPO = CODI_GRPO + 1;

                                if (CKBMADERA.Checked == true)
                                {
                                    imprime = metodo52.documento52(RutEmis, DigiEmis, RutReces, DigiReces, FechaDTOS, Convert.ToInt32(i),"Si");
                                }
                                else
                                {
                                    imprime = metodo52.documento52(RutEmis, DigiEmis, RutReces, DigiReces, FechaDTOS, Convert.ToInt32(i));
                                }
                                if (checkPDF.Checked == true)
                                {
                                    String PDF64A = metodo52.PDF();
                                    String PDF64B = metodo52.PDF();

                                    String A = definicion_Dbq_arch + " (" + CODI_GRPO + ",'ING','X','dbq_scan_arch','dbq_read_mail',  CAST(N'" + FechaDTOS + " 00:00:00.677' AS DateTime), CAST(N'" + FechaDTOS + " 00:00:00.677' AS DateTime), 0,'D:\\DBNeTSE\\ReadMail\\WRK\\envCliE" + i + "6.xml',  'text/xml', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL,'T', NULL)";
                                    conexionCLOUDX.EjecutarSql(A);
                                    int CODI_ARCHDEcimal = Decimal.ToInt32(conexionCLOUDX.recupera_dato_recimal(" select top 1 CODI_ARCH from [DBQ_ARCH]  order by Codi_arch desc"));
                                    String CODI_ARCH = Convert.ToString(CODI_ARCHDEcimal);
                                    String B = definicion_Dbq_arch_clob + "(" + CODI_ARCH + ",'" + imprime + "')";
                                    conexionCLOUDX.EjecutarSql(B);

                                    String C = definicion_Dbq_arch + " (" + CODI_GRPO + ",'ING','X','dbq_scan_arch','dbq_read_mail',  CAST(N'" + FechaDTOS + " 00:00:00.677' AS DateTime), CAST(N'" + FechaDTOS + " 00:00:00.677' AS DateTime), 0,'D:\\DBNeTSE\\ReadMail\\WRK\\CERT_PREVACA.xslt_" + i + ".pdf',  'application/pdf', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL,'T', NULL)";
                                    conexionCLOUDX.EjecutarSql(C);
                                    int CODI_ARCHDEcimal2 = Decimal.ToInt32(conexionCLOUDX.recupera_dato_recimal(" select top 1 CODI_ARCH from [DBQ_ARCH]  order by Codi_arch desc"));
                                    String CODI_ARCH2 = Convert.ToString(CODI_ARCHDEcimal2);
                                    String D = definicion_Dbq_arch_clob + "(" + CODI_ARCH2 + ",'" + PDF64A + "')";
                                    conexionCLOUDX.EjecutarSql(D);
                                    conexionCLOUDX.CerraBD();
                                }
                                else
                                {

                                    String A = definicion_Dbq_arch + " (" + CODI_GRPO + ",'ING','X','dbq_scan_arch','dbq_read_mail',  CAST(N'" + FechaDTOS + " 00:00:00.677' AS DateTime), CAST(N'" + FechaDTOS + " 00:00:00.677' AS DateTime), 0,'D:\\DBNeTSE\\ReadMail\\WRK\\envCliE" + i + "6.xml',  'text/xml', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL,'T', NULL)";
                                    conexionCLOUDX.EjecutarSql(A);
                                    int CODI_ARCHDEcimal = Decimal.ToInt32(conexionCLOUDX.recupera_dato_recimal(" select top 1 CODI_ARCH from [DBQ_ARCH]  order by Codi_arch desc"));
                                    String CODI_ARCH = Convert.ToString(CODI_ARCHDEcimal);
                                    String B = definicion_Dbq_arch_clob + "(" + CODI_ARCH + ",'" + imprime + "')";

                                    conexionCLOUDX.EjecutarSql(B);
                                    conexionCLOUDX.CerraBD();
                                }



                            }
                            MessageBox.Show("Termine ");
                            break;

                        case 56:
                            validarCampos();

                            for (int i = Convert.ToInt32(Foliodesdedto); i <= Foliohastadto; i++)
                            {
                                ConexionBD conexionCLOUDX = new ConexionBD(Ambiente);
                                conexionCLOUDX.abrirBD();

                                decimal Dato = conexionCLOUDX.recupera_dato_recimal(" select top 1 [CODI_GRPO] from [DBQ_ARCH]  order by Codi_arch desc");
                                if (Dato == 0)
                                {
                                    Dato = 0;
                                }
                                int CODI_GRPO = Decimal.ToInt32(Dato); ;
                                CODI_GRPO = CODI_GRPO + 1;

                                String imprime = metodo52.documento56(RutEmis, DigiEmis, RutReces, DigiReces, FechaDTOS, Convert.ToInt32(i));

                                if (checkPDF.Checked == true)
                                {
                                    String PDF64A = metodo52.PDF();
                                    String PDF64B = metodo52.PDF();

                                    String A = definicion_Dbq_arch + " (" + CODI_GRPO + ",'ING','X','dbq_scan_arch','dbq_read_mail',  CAST(N'" + FechaDTOS + " 00:00:00.677' AS DateTime), CAST(N'" + FechaDTOS + " 00:00:00.677' AS DateTime), 0,'D:\\DBNeTSE\\ReadMail\\WRK\\envCliE" + i + "6.xml',  'text/xml', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL,'T', NULL)";
                                    conexionCLOUDX.EjecutarSql(A);
                                    int CODI_ARCHDEcimal = Decimal.ToInt32(conexionCLOUDX.recupera_dato_recimal(" select top 1 CODI_ARCH from [DBQ_ARCH]  order by Codi_arch desc"));
                                    String CODI_ARCH = Convert.ToString(CODI_ARCHDEcimal);
                                    String B = definicion_Dbq_arch_clob + "(" + CODI_ARCH + ",'" + imprime + "')";
                                    conexionCLOUDX.EjecutarSql(B);

                                    String C = definicion_Dbq_arch + " (" + CODI_GRPO + ",'ING','X','dbq_scan_arch','dbq_read_mail',  CAST(N'" + FechaDTOS + " 00:00:00.677' AS DateTime), CAST(N'" + FechaDTOS + " 00:00:00.677' AS DateTime), 0,'D:\\DBNeTSE\\ReadMail\\WRK\\CERT_PREVACA.xslt_" + i + ".pdf',  'application/pdf', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL,'T', NULL)";
                                    conexionCLOUDX.EjecutarSql(C);
                                    int CODI_ARCHDEcimal2 = Decimal.ToInt32(conexionCLOUDX.recupera_dato_recimal(" select top 1 CODI_ARCH from [DBQ_ARCH]  order by Codi_arch desc"));
                                    String CODI_ARCH2 = Convert.ToString(CODI_ARCHDEcimal2);
                                    String D = definicion_Dbq_arch_clob + "(" + CODI_ARCH2 + ",'" + PDF64A + "')";
                                    conexionCLOUDX.EjecutarSql(D);
                                    conexionCLOUDX.CerraBD();
                                }
                                else
                                {

                                    String A = definicion_Dbq_arch + " (" + CODI_GRPO + ",'ING','X','dbq_scan_arch','dbq_read_mail',  CAST(N'" + FechaDTOS + " 00:00:00.677' AS DateTime), CAST(N'" + FechaDTOS + " 00:00:00.677' AS DateTime), 0,'D:\\DBNeTSE\\ReadMail\\WRK\\envCliE" + i + "6.xml',  'text/xml', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL,'T', NULL)";
                                    conexionCLOUDX.EjecutarSql(A);
                                    int CODI_ARCHDEcimal = Decimal.ToInt32(conexionCLOUDX.recupera_dato_recimal(" select top 1 CODI_ARCH from [DBQ_ARCH]  order by Codi_arch desc"));
                                    String CODI_ARCH = Convert.ToString(CODI_ARCHDEcimal);
                                    String B = definicion_Dbq_arch_clob + "(" + CODI_ARCH + ",'" + imprime + "')";

                                    conexionCLOUDX.EjecutarSql(B);
                                    conexionCLOUDX.CerraBD();
                                }



                            }
                            MessageBox.Show("Termine ");
                            break;

                        case 61:
                            validarCampos();

                            for (int i = Convert.ToInt32(Foliodesdedto); i <= Foliohastadto; i++)
                            {
                                ConexionBD conexionCLOUDX = new ConexionBD(Ambiente);
                                conexionCLOUDX.abrirBD();

                                decimal Dato = conexionCLOUDX.recupera_dato_recimal(" select top 1 [CODI_GRPO] from [DBQ_ARCH]  order by Codi_arch desc");
                                if (Dato == 0)
                                {
                                    Dato = 0;
                                }
                                int CODI_GRPO = Decimal.ToInt32(Dato); ;
                                CODI_GRPO = CODI_GRPO + 1;

                                String imprime = metodo52.documento61(RutEmis, DigiEmis, RutReces, DigiReces, FechaDTOS, Convert.ToInt32(i));

                                if (checkPDF.Checked == true)
                                {
                                    String PDF64A = metodo52.PDF();
                                    String PDF64B = metodo52.PDF();

                                    String A = definicion_Dbq_arch + " (" + CODI_GRPO + ",'ING','X','dbq_scan_arch','dbq_read_mail',  CAST(N'" + FechaDTOS + " 00:00:00.677' AS DateTime), CAST(N'" + FechaDTOS + " 00:00:00.677' AS DateTime), 0,'D:\\DBNeTSE\\ReadMail\\WRK\\envCliE" + i + "6.xml',  'text/xml', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL,'T', NULL)";
                                    conexionCLOUDX.EjecutarSql(A);
                                    int CODI_ARCHDEcimal = Decimal.ToInt32(conexionCLOUDX.recupera_dato_recimal(" select top 1 CODI_ARCH from [DBQ_ARCH]  order by Codi_arch desc"));
                                    String CODI_ARCH = Convert.ToString(CODI_ARCHDEcimal);
                                    String B = definicion_Dbq_arch_clob + "(" + CODI_ARCH + ",'" + imprime + "')";
                                    conexionCLOUDX.EjecutarSql(B);

                                    String C = definicion_Dbq_arch + " (" + CODI_GRPO + ",'ING','X','dbq_scan_arch','dbq_read_mail',  CAST(N'" + FechaDTOS + " 00:00:00.677' AS DateTime), CAST(N'" + FechaDTOS + " 00:00:00.677' AS DateTime), 0,'D:\\DBNeTSE\\ReadMail\\WRK\\CERT_PREVACA.xslt_" + i + ".pdf',  'application/pdf', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL,'T', NULL)";
                                    conexionCLOUDX.EjecutarSql(C);
                                    int CODI_ARCHDEcimal2 = Decimal.ToInt32(conexionCLOUDX.recupera_dato_recimal(" select top 1 CODI_ARCH from [DBQ_ARCH]  order by Codi_arch desc"));
                                    String CODI_ARCH2 = Convert.ToString(CODI_ARCHDEcimal2);
                                    String D = definicion_Dbq_arch_clob + "(" + CODI_ARCH2 + ",'" + PDF64A + "')";
                                    conexionCLOUDX.EjecutarSql(D);
                                    conexionCLOUDX.CerraBD();
                                }
                                else
                                {

                                    String A = definicion_Dbq_arch + " (" + CODI_GRPO + ",'ING','X','dbq_scan_arch','dbq_read_mail',  CAST(N'" + FechaDTOS + " 00:00:00.677' AS DateTime), CAST(N'" + FechaDTOS + " 00:00:00.677' AS DateTime), 0,'D:\\DBNeTSE\\ReadMail\\WRK\\envCliE" + i + "6.xml',  'text/xml', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL,'T', NULL)";
                                    conexionCLOUDX.EjecutarSql(A);
                                    int CODI_ARCHDEcimal = Decimal.ToInt32(conexionCLOUDX.recupera_dato_recimal(" select top 1 CODI_ARCH from [DBQ_ARCH]  order by Codi_arch desc"));
                                    String CODI_ARCH = Convert.ToString(CODI_ARCHDEcimal);
                                    String B = definicion_Dbq_arch_clob + "(" + CODI_ARCH + ",'" + imprime + "')";

                                    conexionCLOUDX.EjecutarSql(B);
                                    conexionCLOUDX.CerraBD();
                                }



                            }
                            MessageBox.Show("Termine ");
                            break;
                    }
                    
                            break;               
            }

            }

        private void label24_Click(object sender, EventArgs e)
        {

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (ComboSE.SelectedIndex)
            {
                case 0:
                    TipoAmbiente =6200;
                    break;
                default:
                    TipoAmbiente = 5200;
                    break;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label31_Click(object sender, EventArgs e)
        {

        }

        private void Checkdeshast_CheckedChanged(object sender, EventArgs e)
        {
            if (Checkdeshast.Checked == false)
            {
                lbFoliDesde.Visible = false;
                tbxFoliDesde.Visible = false;
                lbFoliHasta.Visible = false;
                tbxFoliHasta.Visible = false;
                label26.Visible = true;
                textBox6.Visible = true;
            }
            if (Checkdeshast.Checked == true)
            {
                lbFoliDesde.Visible = true;
                tbxFoliDesde.Visible = true;
                lbFoliHasta.Visible = true;
                tbxFoliHasta.Visible = true;
                label26.Visible = false;
                textBox6.Visible = false;

            }
        }

        private void textBox6_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarLetras(e);
        }

        private void tbxFoliDesde_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            ValidarLetras(e);
        }

        private void tbxFoliHasta_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            ValidarLetras(e);
        }

        private void BtnRuta_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog Folder = new FolderBrowserDialog();
            if (Folder.ShowDialog() == DialogResult.OK) {
                RutaCarpeta = Folder.SelectedPath;

            }
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog Folder = new FolderBrowserDialog();
            if (Folder.ShowDialog() == DialogResult.OK)
            {
                RutaCarpeta = Folder.SelectedPath;

            }
        }

        private void textBox7_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkBEL.Checked == false)
            {
                label11.Visible = false;
                textBox2.Visible = false;
                label10.Visible = false;
                textBox1.Visible = false;
                label33.Visible = true;
                textBox7.Visible = true;

            }
            if (checkBEL.Checked == true)
            {
                label11.Visible = true;
                textBox2.Visible = true;
                label10.Visible = true;
                textBox1.Visible = true;
                label33.Visible = false;
                textBox7.Visible = false;

            }
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarLetras(e);
        }

        private void button9_Click_1(object sender, EventArgs e)
        {
            
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "(*.txt)|*.txt|All Files (*.*)|*.*";
            saveFileDialog1.Title = "Guardar PRC";
            saveFileDialog1.FileName = "Carga_Documentos";
            saveFileDialog1.ShowDialog();
            string Archivo = saveFileDialog1.FileName;
            downloadFileToSpecificPath(RutaPRCSE+ "Carga_Documentos.txt", Archivo);
        }

        public static void downloadFileToSpecificPath(string strURLFile, string strPathToSave)
        {
            // Se encierra el código dentro de un bloque try-catch.
            try
            {
                // Se valida que la URL no esté en blanco.
                if (String.IsNullOrEmpty(strURLFile))
                {
                    // Se retorna un mensaje de error al usuario.
                    throw new ArgumentNullException("La dirección URL del documento es nula o se encuentra en blanco.");
                }// Fin del if que valida que la URL no esté en blanco.

                // Se valida que la ruta física no esté en blanco.
                if (String.IsNullOrEmpty(strPathToSave))
                {
                    // Se retorna un mensaje de error al usuario.
                    throw new ArgumentNullException("La ruta para almacenar el documento es nula o se encuentra en blanco.");
                }// Fin del if que valida que la ruta física no esté en blanco.

                // Se descargar el archivo indicado en la ruta específicada.
                using (System.Net.WebClient client = new System.Net.WebClient())
                {
                    client.DownloadFile(strURLFile, strPathToSave);
                }// Fin del using para descargar archivos.
            }// Fin del try.
            catch (Exception ex)
            {
                // Se retorna la excepción al cliente.
                throw ex;
            }// Fin del catch.
        }// Fin del método downloadFileToSpecificPath.

        private void label34_Click(object sender, EventArgs e)
        {

        }

        private void CKBMADERA_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkPDF_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "(*.txt)|*.txt|All Files (*.*)|*.*";
            saveFileDialog1.Title = "Guardar PRC";
            saveFileDialog1.FileName = "Eliminar_datos_holding";
            saveFileDialog1.ShowDialog();
            string Archivo = saveFileDialog1.FileName;
            downloadFileToSpecificPath(RutaPRCSE + "Eliminar_datos_holding.txt", Archivo);
            
        }

        private void button11_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "(*.txt)|*.txt|All Files (*.*)|*.*";
            saveFileDialog1.Title = "Guardar PRC";
            saveFileDialog1.FileName = "EnviaCliente";
            saveFileDialog1.ShowDialog();
            string Archivo = saveFileDialog1.FileName;
            downloadFileToSpecificPath(RutaPRCSE + "EnviaCliente.txt", Archivo);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "(*.txt)|*.txt|All Files (*.*)|*.*";
            saveFileDialog1.Title = "Guardar PRC";
            saveFileDialog1.FileName = "traspasoSE62";
            saveFileDialog1.ShowDialog();
            string Archivo = saveFileDialog1.FileName;
            downloadFileToSpecificPath(RutaPRCSE + "traspasoSE62.txt", Archivo);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "(*.txt)|*.txt|All Files (*.*)|*.*";
            saveFileDialog1.Title = "Guardar PRC";
            saveFileDialog1.FileName = "Carga_documentos_cf_referencia_802";
            saveFileDialog1.ShowDialog();
            string Archivo = saveFileDialog1.FileName;
            downloadFileToSpecificPath(RutaPRCCF + "Carga_documentos_cf_referencia_802.txt", Archivo);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "(*.txt)|*.txt|All Files (*.*)|*.*";
            saveFileDialog1.Title = "Guardar PRC";
            saveFileDialog1.FileName = "Carga_documentos_dte_control";
            saveFileDialog1.ShowDialog();
            string Archivo = saveFileDialog1.FileName;
            downloadFileToSpecificPath(RutaPRCCF + "Carga_documentos_dte_control.txt", Archivo);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "(*.txt)|*.txt|All Files (*.*)|*.*";
            saveFileDialog1.Title = "Guardar PRC";
            saveFileDialog1.FileName = "Carga_documentos_dte_temp";
            saveFileDialog1.ShowDialog();
            string Archivo = saveFileDialog1.FileName;
            downloadFileToSpecificPath(RutaPRCCF + "Carga_documentos_dte_temp.txt", Archivo);
        }

        private void button16_Click(object sender, EventArgs e)
        {
            Process.Start("https://dbnetcorp.atlassian.net/wiki/spaces/QA/pages/1066369033/Autenticaci+n+WSS+por+Base+de+datos");
        }
        public string CrearCarpetaDocumentosModificados(List<string> Ruta,String Eliminar="")
        {

            string Directorioprincipal= Path.GetDirectoryName(Ruta[0]); 
            string DirectorioTemporal = Directorioprincipal + @"\Modificados";

            try 
            { 
                if (Directory.Exists(DirectorioTemporal))
                {
                    if (Eliminar == "Eliminar")
                    {
                        Directory.Delete(DirectorioTemporal, true);
                        return "Directorio Eliminado";
                    }
                    return DirectorioTemporal;
                }   
                else
                {
                    Directory.CreateDirectory(DirectorioTemporal);
                    return DirectorioTemporal;
                }
            } 
            catch (Exception e)
            {
                return "Error al crear o eliminar directorio"+ e.ToString();
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            RetornaListadocumentos();
            string Cantiadad =ContarDocumentos();
            LblTotaldocumentos.Text = Cantiadad;
            TxbCantidad.Text = Cantiadad;
            label37.Visible = true;
            LblTotaldocumentos.Visible = true;
            label38.Visible = true;
            TxbCantidad.Visible = true;
            BtnCambiarFolios.Visible = true;
            label39.Visible = true;
            checkBox1.Visible = true;
            label40.Visible = true;
            checkBox2.Visible = true;


        }

        public void  ModificaDocumento() 
        {
            List<string> Documentos = RutaDocumetos;
            string DirectorioTemp = CrearCarpetaDocumentosModificados(Documentos);
            string Directorioprincipal = Path.GetDirectoryName(Documentos[0]);
            char[] charSeparators = new char[] { ';' };
            int inicial = int.Parse(TxbCantidad.Text);
            int contLineaA0 = 0;
            int contLineaA = 0;
            foreach (string s in Documentos)
            {                
                string[] Linea = File.ReadAllLines(s);
                FileInfo file = new FileInfo(s);
                var NombreTXT = file.Name;
                string DirectorioTempDocumento = DirectorioTemp + "\\" + NombreTXT;
                File.Copy(s, DirectorioTempDocumento, true);
                
                using (var reader = new StreamReader(s))
                {
                    string newdoc = "";
                    String A = "A";                    
                    foreach (string doc in Linea)
                    {
                        contLineaA0 += doc.Length - doc.Replace(";", "").Length;
                        bool puerta = false;
                        string[] data = doc.Split(charSeparators);                        
                           for (int i = 0; i < data.Length; i++)
                           {                              
                              if (data[i] == A && contLineaA0 != 11)
                              {                                
                                int cuentaFolio = data[3].Length;
                                List<string> lines = new List<string>();
                                string line;
                                contLineaA += doc.Length - doc.Replace(";", "").Length;
                                string[] parts = doc.Split(';');
                                string tipodocu = parts[1];
                                parts[3] = inicial.ToString();

                                if (tipodocu=="33" | tipodocu == "34" |  tipodocu == "43" | tipodocu == "46" | tipodocu == "52" | tipodocu == "56" | tipodocu == "61" | tipodocu == "110" | tipodocu == "111" | tipodocu == "112")
                                   {                      
                                    if (newdoc != "")
                                     {
                                        if (checkBox1.Checked == true)
                                        { 
                                            parts[18] = TXBRutEmis.Text;
                                        }
                                        if (checkBox2.Checked == true)
                                        {
                                            parts[28] = TXBRutRece.Text;
                                        }
                                        line = string.Join(";", parts);
                                        lines.Add(line);
                                        newdoc = newdoc + System.Environment.NewLine + line;
                                        inicial++;
                                        puerta = true;
                                        A = "Z";
                                        break;
                                     }
                                     else
                                     {
                                        if (checkBox1.Checked == true)
                                        {
                                            parts[18] = TXBRutEmis.Text;
                                        }
                                        if (checkBox2.Checked == true)
                                        {
                                            parts[28] = TXBRutRece.Text;
                                        }
                                        line = string.Join(";", parts);
                                        lines.Add(line);
                                        newdoc = line;
                                        inicial++;
                                        puerta = true;
                                        A = "Z";
                                        break;
                                     }
                                }else
                                {
                                    if (tipodocu == "39" | tipodocu == "41")
                                    {
                                        if (newdoc != "")
                                        {
                                            if (checkBox1.Checked == true)
                                            {
                                                parts[10] = TXBRutEmis.Text;
                                            }
                                            if (checkBox2.Checked == true)
                                            {
                                                parts[17] = TXBRutRece.Text;
                                            }
                                            line = string.Join(";", parts);
                                            lines.Add(line);
                                            newdoc = newdoc + System.Environment.NewLine + line;
                                            inicial++;
                                            puerta = true;
                                            A = "Z";
                                            break;
                                        }
                                        else
                                        {
                                            if (checkBox1.Checked == true)
                                            {
                                                parts[10] = TXBRutEmis.Text;
                                            }
                                            if (checkBox2.Checked == true)
                                            {
                                                parts[17] = TXBRutRece.Text;
                                            }
                                            line = string.Join(";", parts);
                                            lines.Add(line);
                                            newdoc = line;
                                            inicial++;
                                            puerta = true;
                                            A = "Z";
                                            break;
                                        }

                                    }
                                }
                                       
                              }
                                    if (puerta == false)
                                    {
                                        if (newdoc == "" )
                                        {
                                            newdoc = newdoc + doc;
                                            puerta=true;
                                        }
                                     else
                                        {
                                            newdoc = newdoc + System.Environment.NewLine + doc;
                                            puerta = true;
                                        }
                                     
                                    }
                                
                                    File.WriteAllText(DirectorioTempDocumento, newdoc);
                            
                            }
                     
                    }

                }

            //CrearCarpetaTemporal(Documentos, "Eliminar");     
            }
            System.Diagnostics.Process.Start(DirectorioTemp);
        }

        public string ContarDocumentos() 
        {
            try 
            {
                int contador=0; 
                List<string> Documentos = RutaDocumetos;

                if(Documentos == null) {
                    return "0";
                }
                else
                {
                    foreach (string s in Documentos)
                    {
                        contador++;
                    }
                    return contador.ToString();
                }
            }
            catch(Exception e)
            {
                return "No se logro contar "+e.ToString();
            }
        }

        public  void RetornaListadocumentos()
        {
            this.openFileDialog1.InitialDirectory = "c:\\";
            this.openFileDialog1.FileName = "";
            this.openFileDialog1.DefaultExt = ".txt";
            this.openFileDialog1.Filter = "txt files (*.txt)|*.txt";
            this.openFileDialog1.Multiselect = true;
            this.openFileDialog1.Title = "Modifica TXT CargaSE";
            List<string> Documentos = new List<string>();
            DialogResult dr = this.openFileDialog1.ShowDialog();
            
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                
                foreach (String file in openFileDialog1.FileNames)
                {
                    try
                    {
                        Documentos.Add(file);
                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show("Error  " + ex.Message);
                    }
                    RutaDocumetos = Documentos;
                }
            }
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void BtnCambiarFolios_Click(object sender, EventArgs e)
        {
            ModificaDocumento();
        }

        private void tabPage7_Click(object sender, EventArgs e)
        {

        }

        private void TxbCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarLetras(e);
        }

        private void TxbCantidad_TextChanged(object sender, EventArgs e)
        {

            if (TxbCantidad.Text != "") 
            { 
                int cantidad = int.Parse(LblTotaldocumentos.Text);   
                if (int.Parse(TxbCantidad.Text) == 0) 
                {
                    TxbCantidad.Text = "1";
                    FolioInicialtxtCambio = int.Parse(TxbCantidad.Text)+ cantidad;
                }
                else 
                { 
                FolioInicialtxtCambio = int.Parse(TxbCantidad.Text)+ cantidad;
               }
            }
            else 
            {
                MessageBox.Show("ingrese un valor numerico");
            }
        }

        private void label36_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged_2(object sender, EventArgs e)
        {
            if(checkBox1.Checked == true) 
            {
                TXBRutEmis.Visible= true;
            }
            else 
            {
                TXBRutEmis.Visible = false;
                TXBRutEmis.Text = "";
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                TXBRutRece.Visible = true;
            }
            else
            {
                TXBRutRece.Visible = false;
                TXBRutRece.Text = "";
            }
        }

        private void TXBRutEmis_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
