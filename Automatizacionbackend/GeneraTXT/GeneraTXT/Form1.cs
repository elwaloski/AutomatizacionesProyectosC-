using System;
using System.Diagnostics;
using System.Text;
using System.Xml;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace GeneraTXT
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }
        string Accion = "";
        string RutaCarpeta = "";
        string NuevaRutaCarpeta = "";
        int Tipo_docu = 0;
        string fecha = "";
        string fechaVenc = "";
        string FechaTED = "";
        string Periodo = "";
        string RutEmpresa = "";
        string DigiEmpresa = "";
        string rutaEjecucion = AppDomain.CurrentDomain.BaseDirectory;
        string RutaDefecto = "Documentos";
        string Documento = "";
        Int64 Foliodesde = 1;
        Int64 CantidadTotal = 10;
        string contenidoJsonFactura = @"{
    ""AsignacionFolio"": ""NO"",
    ""VersionDocumento"": ""F22"",
    ""TipoContenido"": ""txt"",
    ""Carga"": ""SI"",
    ""Documento"": {
        ""txt"": ""base64""
       }
}";
        string contenidoJsonBoleta = @"{
    ""AsignacionFolio"": ""NO"",
    ""VersionDocumento"": ""F2"",
    ""TipoContenido"": ""txt"",
    ""Carga"": ""SI"",
    ""Documento"": {
        ""txt"": ""base64""
    }
}";
        private void btnDirectorio_Click(object sender, EventArgs e)
        {

        }

        private void BtnDirectorio_Click_1(object sender, EventArgs e)
        {
            FolderBrowserDialog Folder = new FolderBrowserDialog();
            if (Folder.ShowDialog() == DialogResult.OK)
            {
                RutaCarpeta = Folder.SelectedPath;
                TxbDirectorio.Visible = true;
                TxbDirectorio.Text = RutaCarpeta;
            }
        }

        private void TxbDirectorio_TextChanged(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cbxAccion.SelectedIndex = 0;
            cbxTipoDocumento.SelectedIndex = 0;
            txbRut.Text = "78079790";
            txbDigi.Text = "8";
            dtFechEmis.Value = DateTime.Now;
            dtFechVenc.Value = DateTime.Now.AddDays(90);
            txbCantidadTotal.Text = "10";
            txbFolioDesde.Text = "1";
            RutaCarpeta = Path.Combine(rutaEjecucion);
            TxbDirectorio.ReadOnly = true;
            TxbDirectorio.Text = RutaCarpeta;
            //TxbDirectorio.Visible = false;

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Seguro Desea Salir?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void cbxTipoDocumento_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbxTipoDocumento.SelectedIndex)
            {
                case 0:
                    Tipo_docu = 33;
                    break;
                case 1:
                    Tipo_docu = 34;
                    break;
                case 2:
                    Tipo_docu = 39;
                    break;
                case 3:
                    Tipo_docu = 41;
                    break;
                case 4:
                    Tipo_docu = 43;
                    break;
                case 5:
                    Tipo_docu = 46;
                    break;
                case 6:
                    Tipo_docu = 52;
                    break;
                case 7:
                    Tipo_docu = 56;
                    break;
                case 8:
                    Tipo_docu = 61;
                    break;
                case 9:
                    Tipo_docu = 110;
                    break;
                case 10:
                    Tipo_docu = 111;
                    break;
                default:
                    Tipo_docu = 112;
                    break;
            }
        }

        private void txbRut_TextChanged(object sender, EventArgs e)
        {
            RutEmpresa = txbRut.Text;
        }

        private void dtFechEmis_ValueChanged(object sender, EventArgs e)
        {
            fecha = dtFechEmis.Value.ToString("yyyy-MM-dd");
            Periodo = dtFechEmis.Value.ToString("yyyyMM");
            FechaTED = dtFechEmis.Value.ToString("yyyy-MM-ddTHH:mm:ss");
        }

        private void dtFechVenc_ValueChanged(object sender, EventArgs e)
        {
            fechaVenc = dtFechVenc.Value.ToString("yyyy-MM-dd");
        }

        private void txbDigi_TextChanged(object sender, EventArgs e)
        {
            DigiEmpresa = txbDigi.Text;
        }
        private void validarCampos()
        {
            if (txbFolioDesde.Text == "")
            {
                MessageBox.Show("Los campos Folio Desde no pueden quedar vacios, Se asignaran valores por defecto");
                txbFolioDesde.Text = "1";
            }

            if (this.dtFechEmis.Value.CompareTo(this.dtFechVenc.Value) == 1)

            {
                MessageBox.Show("La fecha desde no puede ser mayor que Fecha vencimiento");
                fechaVenc = dtFechEmis.Value.ToString("yyyy-MM-dd");
                dtFechVenc.Value = DateTime.Now.AddDays(90);
            }
            if (txbCantidadTotal.Text == "")
            {
                MessageBox.Show("La cantidad total no puede ir vacia se asignara valor por defecto");
                txbCantidadTotal.Text = "10";
            }

            if (RutEmpresa == "" | DigiEmpresa == "")
            {
                txbRut.Text = "78079790";
                txbDigi.Text = "8";
                RutEmpresa = "78079790";
                DigiEmpresa = "8";
                MessageBox.Show("Dejo vacio un dato ya sea Rut o digito verificador .... Se asignaran Valores por defecto");
            }
            string Rutasincambios = Path.Combine(rutaEjecucion, RutaDefecto);
            if (RutaCarpeta == Rutasincambios)
            {

                if (!Directory.Exists(RutaCarpeta))
                {
                    Directory.CreateDirectory(RutaCarpeta);
                }
            }
            else
            {
                String RutaCarpetaDocumentos = Path.Combine(RutaCarpeta, RutaDefecto);

                if (!Directory.Exists(RutaCarpetaDocumentos))
                {
                    Directory.CreateDirectory(RutaCarpetaDocumentos);
                }
            }


        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            validarCampos();
            if (Accion == "TXT")
            {
                switch (Tipo_docu)
                {
                    #region 33TXT
                    case 33:
                        validarCampos();
                        NuevaRutaCarpeta = Path.Combine(RutaCarpeta, RutaDefecto);
                        creaDirectorio(NuevaRutaCarpeta + "\\33\\");

                        if (ckbLeyMadera.Checked == true)
                        {
                            for (int i = 1; i <= CantidadTotal; i++)
                            {
                                Documento = "A0;Perú y Colombia. En;17:27;2220;Kapaza;878;val5;val6;val7;val8;val9;\n" +
                                          "A;33;1.0;" + Foliodesde + ";" + fecha + ";;;;;;3;" + fecha + ";2020-11-20;2020-11-20;PE;5462;45;" + fechaVenc + ";" + RutEmpresa + "-" + DigiEmpresa + ";DBNET;TIC;;;8;SANTIAGO;;;;78079790-8;;DBNET;TIC;065-2265500;AV SIEMPRE VIVA;PUERTO MONTT;LLANQUIHUE;;;;;;;;;;200000;0;;19.00;38000;;;;;;238000;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;\n" +
                                          "A1;620200;\n" +
                                          "B;1;;Jarabe p/preparar bebidas;;;;;1;;;;200000;;;;;;;;;200000;;;;;;;;\n" +
                                          "G;String 1;Sring 2;1;\n" +
                                          "H;1;2;3;4;String 5;String 6;1;\n" +
                                          "M; 1;Waldo.gonzalez@dbnetcorp.com;Waldo.gonzalez@dbnetcorp.com;Waldo.gonzalez@dbnetcorp.com;PDF de pruebas;";

                                StreamWriter writer2 = new StreamWriter(NuevaRutaCarpeta + "\\33\\" + "E0" + RutEmpresa + "T" + Tipo_docu + "0000" + Foliodesde + ".txt", false, Encoding.Default);

                                writer2.WriteLine(Documento.TrimEnd('\n'));
                                writer2.Close();
                                Foliodesde++;
                            }
                            Foliodesde = int.Parse(txbFolioDesde.Text);
                        }
                        else
                        {
                            for (int i = 1; i <= CantidadTotal; i++)
                            {
                                Documento = "A0;Perú y Colombia. En;17:27;2220;Kapaza;878;val5;val6;val7;val8;val9;\n" +
                                            "A;33;1.0;" + Foliodesde + ";" + fecha + ";;;;;;3;" + fecha + ";2020-11-20;2020-11-20;PE;5462;45;" + fechaVenc + ";" + RutEmpresa + "-" + DigiEmpresa + ";DBNET;TIC;;;8;SANTIAGO;;;;78079790-8;;DBNET;TIC;065-2265500;AV SIEMPRE VIVA;PUERTO MONTT;LLANQUIHUE;;;;;;;;;;200000;0;;19.00;38000;;;;;;238000;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;\n" +
                                            "A1;620200;\n" +
                                            "B;1;;Jarabe p/preparar bebidas;;;;;1;;;;200000;;;;;;;;;200000;;;;;;;;\n" +
                                            "M; 1;Waldo.gonzalez@dbnetcorp.com;Waldo.gonzalez@dbnetcorp.com;Waldo.gonzalez@dbnetcorp.com;PDF de pruebas;";

                                StreamWriter writer2 = new StreamWriter(NuevaRutaCarpeta + "\\33\\" + "E0" + RutEmpresa + "T" + Tipo_docu + "0000" + Foliodesde + ".txt", false, Encoding.Default);
                                writer2.WriteLine(Documento.TrimEnd('\n'));
                                writer2.Close();
                                Foliodesde++;
                            }

                            Foliodesde = int.Parse(txbFolioDesde.Text);
                        }
                        AbrirCarpeta(NuevaRutaCarpeta + "\\33\\");
                        break;
                    #endregion

                    #region 34TXT
                    case 34:
                        validarCampos();
                        NuevaRutaCarpeta = Path.Combine(RutaCarpeta, RutaDefecto);
                        creaDirectorio(NuevaRutaCarpeta + "\\34\\");

                        for (int i = 1; i <= CantidadTotal; i++)
                        {
                            Documento = "A0;\\; - V1; DE  - V2;GRUPO  - V3; POR- ; SAP - V5;V6;V7;V8;V9;\n" +
                                        "A;34;1.0;" + Foliodesde + ";" + fecha + ";;;;;;2;;;;;;;" + fechaVenc + ";" + RutEmpresa + "-" + DigiEmpresa + ";DBNET;SERVICIOS DE CAPACITACION;AGROCAPACITA;;RAMON FREIRE N 986;OSORNO;OSORNO;SOLIS YENNY SOLEDAD;;78079790-8;0010070299;DBNET;SERVICIO VETERINARIO;+56987654321;HERTA FUCHSLOCHER 1001;OSORNO;OSORNO;;;;;PATENTE;;FDO. MIRAMONTES;LOS MUERMOS;LOS MUERMOS;0;40000;;;;;;;;;40000;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;\n" +
                                        "A1;620200;\n" +
                                        "B;1;;SIPEC WEB TRAZABILIDAD ANIMAL;;;;;1;;;UN;40000.000000;;;;;;;;;40000;;;;;;;;\n" +
                                        "B2;INT1;94700003;\n" +
                                        "M; 1;Waldo.gonzalez@dbnetcorp.com;Waldo.gonzalez@dbnetcorp.com;Waldo.gonzalez@dbnetcorp.com;PDF de pruebas;";

                            StreamWriter writer2 = new StreamWriter(NuevaRutaCarpeta + "\\34\\" + "E0" + RutEmpresa + "T" + Tipo_docu + "0000" + Foliodesde + ".txt", false, Encoding.Default);

                            writer2.WriteLine(Documento.TrimEnd('\n'));
                            writer2.Close();
                            Foliodesde++;
                        }
                        Foliodesde = int.Parse(txbFolioDesde.Text);

                        AbrirCarpeta(NuevaRutaCarpeta + "\\34\\");
                        break;
                    #endregion

                    #region 39TXT
                    case 39:
                        validarCampos();
                        NuevaRutaCarpeta = Path.Combine(RutaCarpeta, RutaDefecto);
                        creaDirectorio(NuevaRutaCarpeta + "\\39\\");

                        if (CKBGeoReferencia.Checked == true)
                        {
                            for (int i = 1; i <= CantidadTotal; i++)
                            {
                                Documento = "A0;;INGRESO 7 PERSONAS POR 30 DIAS;;|||||;;CON CHEQUE;|772.83|28700.20|TERMINAL MOLO|1||22-09-2020|ALEJANDRA VASQUEZ ACEVEDO|OTROS|||;;0;1.00;\n" +
                                            "A;39;1.0;" + Foliodesde + ";" + fecha + ";3;;;;" + fechaVenc + ";" + RutEmpresa + "-" + DigiEmpresa + ";Dbnet;DEPOSITO Y ALMACENAM. Y OTROS SERV.;;AV. JORGE BARRERA N 62;IQUIQUE;IQUIQUE;66666666-6;66666666;CBT ING.Y CONSTR. LTDA;;RECINTO PORTUARIO S N;IQUIQUE;IQUIQUE;;;;81147;;15418;96565;;;;;RutProvSW;RznSocProvSW;\n" +
                                            "B;1;;21 UND PERMISO ACCESO PERSONAS 1 A 10 DIAS;;1.000000;UND;96565;96565;\n" +
                                            "B2;INT;LSP 46560;\n" +
                                            "G;LatitudEmision;LongitudEmision;1;";

                                StreamWriter writer2 = new StreamWriter(NuevaRutaCarpeta + "\\39\\" + "\\E0" + RutEmpresa + "T" + Tipo_docu + "0000" + Foliodesde + ".txt", false, Encoding.Default);

                                writer2.WriteLine(Documento.TrimEnd('\n'));
                                writer2.Close();
                                Foliodesde++;
                            }
                            Foliodesde = int.Parse(txbFolioDesde.Text);
                        }
                        else
                        {
                            for (int i = 1; i <= CantidadTotal; i++)
                            {
                                Documento = "A0;;INGRESO 7 PERSONAS POR 30 DIAS;;|||||;;CON CHEQUE;|772.83|28700.20|TERMINAL MOLO|1||22-09-2020|ALEJANDRA VASQUEZ ACEVEDO|OTROS|||;;0;1.00;\n" +
                                            "A;39;1.0;" + Foliodesde + ";" + fecha + ";3;;;;" + fechaVenc + ";" + RutEmpresa + "-" + DigiEmpresa + ";Dbnet;DEPOSITO Y ALMACENAM. Y OTROS SERV.;;AV. JORGE BARRERA N 62;IQUIQUE;IQUIQUE;66666666-6;66666666;CBT ING.Y CONSTR. LTDA;;RECINTO PORTUARIO S N;IQUIQUE;IQUIQUE;;;;81147;;15418;96565;;;;;;;\n" +
                                            "B;1;;21 UND PERMISO ACCESO PERSONAS 1 A 10 DIAS;;1.000000;UND;96565;96565;\n" +
                                            "B2;INT;LSP 46560;";


                                StreamWriter writer2 = new StreamWriter(NuevaRutaCarpeta + "\\39\\" + "\\E0" + RutEmpresa + "T" + Tipo_docu + "0000" + Foliodesde + ".txt", false, Encoding.Default);

                                writer2.WriteLine(Documento.TrimEnd('\n'));
                                writer2.Close();
                                Foliodesde++;
                            }
                            Foliodesde = int.Parse(txbFolioDesde.Text);
                        }
                        AbrirCarpeta(NuevaRutaCarpeta + "\\39\\");
                        break;
                    #endregion

                    #region 41TXT
                    case 41:
                        validarCampos();
                        NuevaRutaCarpeta = Path.Combine(RutaCarpeta, RutaDefecto);
                        creaDirectorio(NuevaRutaCarpeta + "\\41\\");

                        if (CKBGeoReferencia.Checked == true)
                        {
                            for (int i = 1; i <= CantidadTotal; i++)
                            {
                                Documento = "A0;FE_NORACID_SCL01;0094311104-CVARELA-Bol-0040005476;SERVICIOS ULTRACORP;;;;;219;;Hecho no gravado DL 825 de 1974;\n" +
                                            "A;41;1.0;" + Foliodesde + ";" + fecha + ";3 ;;;;" + fechaVenc + ";" + RutEmpresa + "-" + DigiEmpresa + ";Dbnet;Arriendo de Oficinas con Muebles;;Avda. El Bosque Norte 500;LAS CONDES;;9250199-K;0000115971;MAIK BUROSE ;;FRAY LEON  12334 LAS CONDES  LAS CONDES;LAS CONDES;LAS CONDES;;;;0;32104;;32104;;;;32104;RutProvSW;RznSocProvSW;\n" +
                                            "B;1 ;1;Servicio: Arriendo de estacionamiento compartido;;1;;32104;32104;\n" +
                                            "B;2 ;1;Precio vta unitario CLP 32.104 por 1 UN = CLP 32.104,00;;1;;0;0;\n" +
                                            "G;LatitudEmision;LongitudEmision;1;";

                                StreamWriter writer2 = new StreamWriter(NuevaRutaCarpeta + "\\41\\" + "\\E0" + RutEmpresa + "T" + Tipo_docu + "0000" + Foliodesde + ".txt", false, Encoding.Default);

                                writer2.WriteLine(Documento.TrimEnd('\n'));
                                writer2.Close();
                                Foliodesde++;
                            }

                            Foliodesde = int.Parse(txbFolioDesde.Text);
                        }
                        else
                        {

                            for (int i = 1; i <= CantidadTotal; i++)
                            {
                                Documento = "A0;FE_NORACID_SCL01;0094311104-CVARELA-Bol-0040005476;SERVICIOS ULTRACORP;;;;;219;;Hecho no gravado DL 825 de 1974;\n" +
                                            "A;41;1.0;" + Foliodesde + ";" + fecha + ";3 ;;;;" + fechaVenc + ";" + RutEmpresa + "-" + DigiEmpresa + ";Dbnet;Arriendo de Oficinas con Muebles;;Avda. El Bosque Norte 500;LAS CONDES;;9250199-K;0000115971;MAIK BUROSE ;;FRAY LEON  12334 LAS CONDES  LAS CONDES;LAS CONDES;LAS CONDES;;;;0;32104;;32104;;;;32104;;;\n" +
                                            "B;1 ;1;Servicio: Arriendo de estacionamiento compartido;;1;;32104;32104;\n" +
                                            "B;2 ;1;Precio vta unitario CLP 32.104 por 1 UN = CLP 32.104,00;;1;;0;0;";

                                StreamWriter writer2 = new StreamWriter(NuevaRutaCarpeta + "\\41\\" + "\\E0" + RutEmpresa + "T" + Tipo_docu + "0000" + Foliodesde + ".txt", false, Encoding.Default);

                                writer2.WriteLine(Documento.TrimEnd('\n'));
                                writer2.Close();
                                Foliodesde++;
                            }
                            Foliodesde = int.Parse(txbFolioDesde.Text);
                        }
                        AbrirCarpeta(NuevaRutaCarpeta + "\\41\\");
                        break;
                    #endregion

                    #region 43TXT
                    case 43:
                        validarCampos();
                        NuevaRutaCarpeta = Path.Combine(RutaCarpeta, RutaDefecto);
                        creaDirectorio(NuevaRutaCarpeta + "\\43\\");

                        for (int i = 1; i <= CantidadTotal; i++)
                        {
                            Documento = "A0;;;;;;;;;;;\n" +
                                        "A;43;1.0;" + Foliodesde + ";" + fecha + ";;;;;;2;;;;;;0;" + fechaVenc + ";" + RutEmpresa + "-" + DigiEmpresa + ";DBNET Ingenieria de Software;venta de confites;;;18 sep 1234; HUECHURABA;SANTIAGO;;;78079790-8;111;dbnet;Papas;511551;dbnet; CERRILLOS;SANTIAGO;;;;;;;;;;33;0;0;19.00;6;0;0;;0;0;39;0;0;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;\n" +
                                        "A1;620200;\n" +
                                        "B;1;;a;a;;;;1;;;;3;;;;0;0;0;0;;3;;;;;;;;\n" +
                                        "B2;INT1;123;\n" +
                                        "B2;DUN14;2;\n" +
                                        "B5;22;\n" +
                                        "M; 1;Waldo.gonzalez@dbnetcorp.com;Waldo.gonzalez@dbnetcorp.com;Waldo.gonzalez@dbnetcorp.com;PDF de pruebas;";

                            StreamWriter writer2 = new StreamWriter(NuevaRutaCarpeta + "\\43\\" + "E0" + RutEmpresa + "T" + Tipo_docu + "0000" + Foliodesde + ".txt", false, Encoding.Default);

                            writer2.WriteLine(Documento.TrimEnd('\n'));
                            writer2.Close();
                            Foliodesde++;
                        }
                        Foliodesde = int.Parse(txbFolioDesde.Text);

                        AbrirCarpeta(NuevaRutaCarpeta + "\\43\\");
                        break;
                    #endregion

                    #region 46TXT
                    case 46:
                        validarCampos();
                        NuevaRutaCarpeta = Path.Combine(RutaCarpeta, RutaDefecto);
                        creaDirectorio(NuevaRutaCarpeta + "\\46\\");
                        for (int i = 1; i <= CantidadTotal; i++)
                        {
                            Documento = "A0;;;;;;;;;;;\n" +
                                        "A;46;1.0;" + Foliodesde + ";" + fecha + ";;;;;;;;;;;;;;" + RutEmpresa + "-" + DigiEmpresa + ";UNIVERSIDAD DE LOS LAGOS;EDUCACION;;;AVENIDA FUCHSLOCHER 1305;OSORNO;;;;10777715-6;;JOSE LEONEL VILLARROEL CASANOVA;OTRAS ACTIV.DE SERV.PERSONALES N.C.P.;.;CARRETERA AUSTRAL KILOMETRO 30 .;PUERTO MONTT;PUERTO MONTT;;;;;;;;;;126000;0;;019.00;23940;;;;;;126000;;;;;;;;;;CREDITO;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;\n" +
                                        "A1;620200;\n" +
                                        "A2;15;19.00;23940;\n" +
                                        "B;1;;COMPRA DE 63 KILOGRAMOS DE PESCADO FRESCO PARA ALIMENTO DE CONGRIOS VALOR UNITAR;IO $2.000.- EL KILOGRAMO.;;;;63;;;;2000;;;;;;;;15;126000;;;;;;;;\n" +
                                        "M; 1;Waldo.gonzalez@dbnetcorp.com;Waldo.gonzalez@dbnetcorp.com;Waldo.gonzalez@dbnetcorp.com;PDF de pruebas;";

                            StreamWriter writer2 = new StreamWriter(NuevaRutaCarpeta + "\\46\\" + "E0" + RutEmpresa + "T" + Tipo_docu + "0000" + Foliodesde + ".txt", false, Encoding.Default);

                            writer2.WriteLine(Documento.TrimEnd('\n'));
                            writer2.Close();
                            Foliodesde++;
                        }
                        Foliodesde = int.Parse(txbFolioDesde.Text);
                        AbrirCarpeta(NuevaRutaCarpeta + "\\46\\");
                        break;
                    #endregion

                    #region 52TXT
                    case 52:
                        validarCampos();
                        NuevaRutaCarpeta = Path.Combine(RutaCarpeta, RutaDefecto);
                        creaDirectorio(NuevaRutaCarpeta + "\\52\\");

                        if (ckbLeyMadera.Checked == true)
                        {

                            for (int i = 1; i <= CantidadTotal; i++)
                            {
                                Documento = "A;52;1.0;" + Foliodesde + ";" + fecha + ";;;;;;;;;;;;;" + fechaVenc + ";" + RutEmpresa + "-" + DigiEmpresa + ";DBNET;TIC;;;8;SANTIAGO;;;;78079790-8;;DBNET;TIC2;065-2265500;AV ALGO;PUERTO MONTT;LLANQUIHUE;;;;;;;;;;259439;0;;19.00;49293;;;;;;237048;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;\n" +
                                            "A1;620200;\n" +
                                            "B;1;;Elote;;;;;1;;;;259439;;;;;;;;;259439;;;;;;;;\n" +
                                            "G;String 1;Sring 2;1;\n" +
                                            "H;1;2;3;4;String 5;String 6;1;\n" +
                                            "M; 1;Waldo.gonzalez@dbnetcorp.com;Waldo.gonzalez@dbnetcorp.com;Waldo.gonzalez@dbnetcorp.com;PDF de pruebas;";

                                StreamWriter writer2 = new StreamWriter(NuevaRutaCarpeta + "\\52\\" + "E0" + RutEmpresa + "T" + Tipo_docu + "0000" + Foliodesde + ".txt", false, Encoding.Default);

                                writer2.WriteLine(Documento.TrimEnd('\n'));
                                writer2.Close();
                                Foliodesde++;
                            }
                            Foliodesde = int.Parse(txbFolioDesde.Text);
                        }
                        else
                        {
                            for (int i = 1; i <= CantidadTotal; i++)
                            {
                                Documento = "A;52;1.0;" + Foliodesde + ";" + fecha + ";;;;;;;;;;;;;" + fechaVenc + ";" + RutEmpresa + "-" + DigiEmpresa + ";DBNET;TIC;;;8;SANTIAGO;;;;78079790-8;;DBNET;TIC2;065-2265500;AV ALGO;PUERTO MONTT;LLANQUIHUE;;;;;;;;;;259439;0;;19.00;49293;;;;;;237048;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;\n" +
                                            "A1;620200;\n" +
                                            "B;1;;Elote;;;;;1;;;;259439;;;;;;;;;259439;;;;;;;;\n" +
                                            "M; 1;Waldo.gonzalez@dbnetcorp.com;Waldo.gonzalez@dbnetcorp.com;Waldo.gonzalez@dbnetcorp.com;PDF de pruebas;";

                                StreamWriter writer2 = new StreamWriter(NuevaRutaCarpeta + "\\52\\" + "E0" + RutEmpresa + "T" + Tipo_docu + "0000" + Foliodesde + ".txt", false, Encoding.Default);

                                writer2.WriteLine(Documento.TrimEnd('\n'));
                                writer2.Close();
                                Foliodesde++;
                            }
                            Foliodesde = int.Parse(txbFolioDesde.Text);
                        }
                        AbrirCarpeta(NuevaRutaCarpeta + "\\52\\");
                        break;
                    #endregion

                    #region 56TXT
                    case 56:
                        validarCampos();
                        NuevaRutaCarpeta = Path.Combine(RutaCarpeta, RutaDefecto);
                        creaDirectorio(NuevaRutaCarpeta + "\\56\\");
                        for (int i = 1; i <= CantidadTotal; i++)
                        {
                            Documento = "A;56;1.0;" + Foliodesde + ";" + fecha + ";;;;;;;;;;;;;" + fechaVenc + ";" + RutEmpresa + "-" + DigiEmpresa + ";DBNET;TIC;;;8;SANTIAGO;;;;78079790-8;1234567894;DBNET;TIC;065-2265500;AV SIEMPRE VIVA;PUERTO MONTT;LLANQUIHUE;;;;;;;;;;199200;0;;19.00;37848;;;;;;237048;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;\n" +
                                        "A1;620200;\n" +
                                        "A2;50;9;20;\n" +
                                        "B;1;;Coliflor;;;;;1;;;;864145;;;;;;;;;864145;;;;R;100;;;\n" +
                                        "B;2;;Dátil;;;;;1;;;;977481;;;;;;;;;977481;;;;R;;200;;\n" +
                                        "B;3;;Betabel;;;;;1;;;;842942;;;;;;;;;842942;;;;R;;;300;\n" +
                                        "B;4;;Ajo;;;;;1;;;;349403;;;;;;;;;349403;;;;R;100;200;300;\n" +
                                        "D;1;801;;53333;;2015-04-22;;;\n" +
                                        "M; 1;Waldo.gonzalez@dbnetcorp.com;Waldo.gonzalez@dbnetcorp.com;Waldo.gonzalez@dbnetcorp.com;PDF de pruebas;";

                            StreamWriter writer2 = new StreamWriter(NuevaRutaCarpeta + "\\56\\" + "E0" + RutEmpresa + "T" + Tipo_docu + "0000" + Foliodesde + ".txt", false, Encoding.Default);

                            writer2.WriteLine(Documento.TrimEnd('\n'));
                            writer2.Close();
                            Foliodesde++;
                        }
                        Foliodesde = int.Parse(txbFolioDesde.Text);
                        AbrirCarpeta(NuevaRutaCarpeta + "\\56\\");
                        break;
                    #endregion

                    #region 61TXT
                    case 61:
                        validarCampos();
                        NuevaRutaCarpeta = Path.Combine(RutaCarpeta, RutaDefecto);
                        creaDirectorio(NuevaRutaCarpeta + "\\61\\");

                        for (int i = 1; i <= CantidadTotal; i++)
                        {
                            Documento = "A;61;1.0;" + Foliodesde + ";" + fecha + ";;;;;;3;;;;;;;" + fechaVenc + ";" + RutEmpresa + "-" + DigiEmpresa + ";DBNET;TIC;;;8;SANTIAGO;;;;78079790-8;1234567893;DBNET;TIC;065-2265500;AV SIEMPRE VIVA;PUERTO MONTT;LLANQUIHUE;;;;;;;;;;199200;0;;19.00;37848;;;;;;237048;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;\n" +
                                        "A1;620200;\n" +
                                        "A2;17;9;20;\n" +
                                        "B;1;;Coliflor;;;;;1;;;;864145;;;;;;;;;864145;;;;R;100;;;\n" +
                                        "B;2;;Dátil;;;;;1;;;;977481;;;;;;;;;977481;;;;R;;200;;\n" +
                                        "B;3;;Betabel;;;;;1;;;;842942;;;;;;;;;842942;;;;R;;;300;\n" +
                                        "B;4;;Ajo;;;;;1;;;;349403;;;;;;;;;349403;;;;R;100;200;300;\n" +
                                        "D;1;801;;285613;;2015-04-22;;;\n" +
                                        "M; 1;Waldo.gonzalez@dbnetcorp.com;Waldo.gonzalez@dbnetcorp.com;Waldo.gonzalez@dbnetcorp.com;PDF de pruebas;";

                            StreamWriter writer2 = new StreamWriter(NuevaRutaCarpeta + "\\61\\" + "E0" + RutEmpresa + "T" + Tipo_docu + "0000" + Foliodesde + ".txt", false, Encoding.Default);

                            writer2.WriteLine(Documento.TrimEnd('\n'));
                            writer2.Close();
                            Foliodesde++;
                        }
                        Foliodesde = int.Parse(txbFolioDesde.Text);
                        AbrirCarpeta(NuevaRutaCarpeta + "\\61\\");
                        break;
                    #endregion

                    #region 110TXT
                    case 110:
                        validarCampos();
                        NuevaRutaCarpeta = Path.Combine(RutaCarpeta, RutaDefecto);
                        creaDirectorio(NuevaRutaCarpeta + "\\110\\");
                        for (int i = 1; i <= CantidadTotal; i++)
                        {
                            Documento = "A0;;0095000025;;;;;;;;;\n" +
                                        "A;110;1.0;" + Foliodesde + ";" + fecha + ";;;;;;2;;;;;;;" + fechaVenc + ";" + RutEmpresa + "-" + DigiEmpresa + ";SALMONES MULTIEXPORT S.A.;GIRO MULTIEXPORT;S100;;Avda Cardonal 2501;Puerto Montt;Puerto Montt;;;55555555-5;0012000678;OOO AKRA;.;;NAB. REKI SMOLENKI, D.14, LITER A,;ST PETERSBURG;ST PETERSBURG;;;;;;;;;;0;1000.00;;;;;;;;;1000.00;;;;;;;;;;Cobr Directa (Crédito) 30 días;;;;;;;;;;;;;1;;;;;;;;;;;;;;;;;;;;;;;;;DOLAR USA;;;;;;;;;;;;;\n" +
                                        "A1;620200;\n" +
                                        "A3;22;10;;;;;\n" +
                                        "B;1;;FROZEN ATLANTIC SALMON HON IND. B 0,5-1 KG IQF;;;;;100;;;KG;10.00;;;;;;;;;1000.00;;;;;;;;\n" +
                                        "B2;INT1;3000002;\n" +
                                        "M; 1;Waldo.gonzalez@dbnetcorp.com;Waldo.gonzalez@dbnetcorp.com;Waldo.gonzalez@dbnetcorp.com;PDF de pruebas;";

                            StreamWriter writer2 = new StreamWriter(NuevaRutaCarpeta + "\\110\\" + "E0" + RutEmpresa + "T" + Tipo_docu + "0000" + Foliodesde + ".txt", false, Encoding.Default);

                            writer2.WriteLine(Documento.TrimEnd('\n'));
                            writer2.Close();
                            Foliodesde++;
                        }
                        Foliodesde = int.Parse(txbFolioDesde.Text);

                        AbrirCarpeta(NuevaRutaCarpeta + "\\110\\");
                        break;
                    #endregion

                    #region 111TXT
                    case 111:
                        validarCampos();
                        NuevaRutaCarpeta = Path.Combine(RutaCarpeta, RutaDefecto);
                        creaDirectorio(NuevaRutaCarpeta + "\\111\\");
                        for (int i = 1; i <= CantidadTotal; i++)
                        {
                            Documento = "A0;\\SRP-VENLACETEST\\HPM602;;;;;0;0;;25.00;0;\n" +
                                        "A;111;1.0;" + Foliodesde + ";" + fecha + ";;;;;;1;;;;;;;" + fechaVenc + ";" + RutEmpresa + "-" + DigiEmpresa + ";MARIENBERG;PRODUCCION Y COMERCIALIZACION DE ELEMENTOS PARA LA INDUSTRIA;;;SANTA MARTA;MAIPÚ;SANTIAGO;GERENCIA;;55555555-5;20-23644496-2;CERMINARO JUAN MANUEL;IMPORTADORES DE PISOS Y ALFOMBRAS;(+5411)6860 1925;AV JUAN MANUEL DE ROSAS 138 – CASTELAR –MORON (1712);CASTELAR  MORON;BUENOS AIRES;U_CASILLA_CORR;;;;;;;;;0;25.00;;;;;;;;;25.00;;;;;;;;;;Depósito y/o Transferencia;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;0;;;;;DOLAR USA;;;;PESO CL;667.550000;;16689;;;;;16689.00;\n" +
                                        "A1;620200;\n" +
                                        "B;1;;Diferencia por tipo de Cambio al pagar Neto de FV 88989;Diferencia por tipo de Cambio al pagar Neto de FV 88989;;;;1;;;;25.00;;;;0.0;0;;;;25.00;;;;;;;;\n" +
                                        "D;1;110;;13;;2019-02-27;3;;\n" +
                                        "M; 1;Waldo.gonzalez@dbnetcorp.com;Waldo.gonzalez@dbnetcorp.com;Waldo.gonzalez@dbnetcorp.com;PDF de pruebas;";

                            StreamWriter writer2 = new StreamWriter(NuevaRutaCarpeta + "\\111\\" + "E0" + RutEmpresa + "T" + Tipo_docu + "0000" + Foliodesde + ".txt", false, Encoding.Default);

                            writer2.WriteLine(Documento.TrimEnd('\n'));
                            writer2.Close();
                            Foliodesde++;
                        }
                        Foliodesde = int.Parse(txbFolioDesde.Text);
                        AbrirCarpeta(NuevaRutaCarpeta + "\\111\\");
                        break;
                    #endregion

                    #region 112TXT
                    case 112:
                        validarCampos();
                        NuevaRutaCarpeta = Path.Combine(RutaCarpeta, RutaDefecto);
                        creaDirectorio(NuevaRutaCarpeta + "\\112\\");

                        for (int i = 1; i <= CantidadTotal; i++)
                        {
                            Documento = "A;112;1.0;" + Foliodesde + ";" + fecha + ";;;;;;;;;;;;;" + fechaVenc + ";" + RutEmpresa + "-" + DigiEmpresa + ";GE HEALTHCARE INTERNATIONAL LLC AGENCIA EN CHILE;REP DE OTROS EQ ELECT Y OPTICOS N.C.P.;;;Isidora Goyenechea 2800,Piso 21;Santiago;Las Condes;;;78079790-8;;GE HEALTHCARE COLOMBIA S.A.S.;VENTA AL POR MAYOR NO ESPECIALIZADA;;CALLE 103 NO. 14 A-43;Bogota;BOGOTA, D.C.;110111;;;;;;CALLE 103 NO. 14 A-43;Bogota;BOGOTA, D.C.;0;87840.76;;;;;;;;;87840.76;;;;;;1;;;;;1;;;;;;;;;;;1;8;;;;;;;;;;;;;;;;;;;;;;;;202;DOLAR USA;;;;PESO CL;693;60873646.68;;;;;;60873646.68;\n" +
                            "A1;620200;\n" +
                            "B;1;1;Por la provision de un equipo modelo marca GE Segun propuesta definitiva FDON; Por la provision de un equipo modelo marca GE Segun propuesta definitiva FDON;;10;;2583.55176;;;10;34;;;;;;;;;87840.76;;;;;;;;\n" +
                            "D;1;110;;18;;2019-05-13;3;Corrige montos;\n" +
                            "D;2;801;;56756;;2019-05-13;;;\n" +
                             "M; 1;Waldo.gonzalez@dbnetcorp.com;Waldo.gonzalez@dbnetcorp.com;Waldo.gonzalez@dbnetcorp.com;PDF de pruebas;";

                            StreamWriter writer2 = new StreamWriter(NuevaRutaCarpeta + "\\112\\" + "E0" + RutEmpresa + "T" + Tipo_docu + "0000" + Foliodesde + ".txt", false, Encoding.Default);

                            writer2.WriteLine(Documento.TrimEnd('\n'));
                            writer2.Close();
                            Foliodesde++;

                        }
                        Foliodesde = int.Parse(txbFolioDesde.Text);
                        AbrirCarpeta(NuevaRutaCarpeta + "\\112\\");
                        break;
                        #endregion
                }
            }

            if (Accion == "TXT API2020")
            {
                switch (Tipo_docu)
                {
                    #region 33TXTJson
                    case 33:
                        validarCampos();
                        NuevaRutaCarpeta = Path.Combine(RutaCarpeta, RutaDefecto);
                        creaDirectorio(NuevaRutaCarpeta + "\\33\\");

                        if (ckbLeyMadera.Checked == true)
                        {
                            for (int i = 1; i <= CantidadTotal; i++)
                            {
                                JObject json = JObject.Parse(contenidoJsonFactura);

                                Documento = "A0;Perú y Colombia. En;17:27;2220;Kapaza;878;val5;val6;val7;val8;val9;\n" +
                                          "A;33;1.0;" + Foliodesde + ";" + fecha + ";;;;;;3;" + fecha + ";2020-11-20;2020-11-20;PE;5462;45;" + fechaVenc + ";" + RutEmpresa + "-" + DigiEmpresa + ";DBNET;TIC;;;8;SANTIAGO;;;;78079790-8;;DBNET;TIC;065-2265500;AV SIEMPRE VIVA;PUERTO MONTT;LLANQUIHUE;;;;;;;;;;200000;0;;19.00;38000;;;;;;238000;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;\n" +
                                          "A1;620200;\n" +
                                          "B;1;;Jarabe p/preparar bebidas;;;;;1;;;;200000;;;;;;;;;200000;;;;;;;;\n" +
                                          "G;String 1;Sring 2;1;\n" +
                                          "H;1;2;3;4;String 5;String 6;1;\n" +
                                          "M; 1;Waldo.gonzalez@dbnetcorp.com;Waldo.gonzalez@dbnetcorp.com;Waldo.gonzalez@dbnetcorp.com;PDF de pruebas;";
                                string base64 = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(Documento));
                                json["Documento"]["txt"] = base64;
                                string resultadoFinal = json.ToString(Newtonsoft.Json.Formatting.Indented);

                                StreamWriter writer2 = new StreamWriter(NuevaRutaCarpeta + "\\33\\" + "JsonE0" + RutEmpresa + "T" + Tipo_docu + "0000" + Foliodesde + ".txt", false, Encoding.Default);

                                writer2.WriteLine(resultadoFinal.TrimEnd());
                                writer2.Close();
                                Foliodesde++;
                            }
                            Foliodesde = int.Parse(txbFolioDesde.Text);
                        }
                        else
                        {

                            for (int i = 1; i <= CantidadTotal; i++)
                            {
                                JObject json = JObject.Parse(contenidoJsonFactura);

                                Documento = "A0;Perú y Colombia. En;17:27;2220;Kapaza;878;val5;val6;val7;val8;val9;\n" +
                                          "A;33;1.0;" + Foliodesde + ";" + fecha + ";;;;;;3;" + fecha + ";2020-11-20;2020-11-20;PE;5462;45;" + fechaVenc + ";" + RutEmpresa + "-" + DigiEmpresa + ";DBNET;TIC;;;8;SANTIAGO;;;;78079790-8;;DBNET;TIC;065-2265500;AV SIEMPRE VIVA;PUERTO MONTT;LLANQUIHUE;;;;;;;;;;200000;0;;19.00;38000;;;;;;238000;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;\n" +
                                          "A1;620200;\n" +
                                          "B;1;;Jarabe p/preparar bebidas;;;;;1;;;;200000;;;;;;;;;200000;;;;;;;;\n" +
                                          "M; 1;Waldo.gonzalez@dbnetcorp.com;Waldo.gonzalez@dbnetcorp.com;Waldo.gonzalez@dbnetcorp.com;PDF de pruebas;";
                                string base64 = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(Documento));
                                json["Documento"]["txt"] = base64;
                                string resultadoFinal = json.ToString(Newtonsoft.Json.Formatting.Indented);

                                StreamWriter writer2 = new StreamWriter(NuevaRutaCarpeta + "\\33\\" + "JsonE0" + RutEmpresa + "T" + Tipo_docu + "0000" + Foliodesde + ".txt", false, Encoding.Default);

                                writer2.WriteLine(resultadoFinal.TrimEnd());
                                writer2.Close();
                                Foliodesde++;
                            }
                            Foliodesde = int.Parse(txbFolioDesde.Text);
                        }
                        AbrirCarpeta(NuevaRutaCarpeta + "\\33\\");
                        break;
                    #endregion

                    #region 34TXT
                    case 34:
                        validarCampos();
                        NuevaRutaCarpeta = Path.Combine(RutaCarpeta, RutaDefecto);
                        creaDirectorio(NuevaRutaCarpeta + "\\34\\");

                        for (int i = 1; i <= CantidadTotal; i++)
                        {
                            JObject json = JObject.Parse(contenidoJsonFactura);

                            Documento = "A0;\\; - V1; DE  - V2;GRUPO  - V3; POR- ; SAP - V5;V6;V7;V8;V9;\n" +
                                        "A;34;1.0;" + Foliodesde + ";" + fecha + ";;;;;;2;;;;;;;" + fechaVenc + ";" + RutEmpresa + "-" + DigiEmpresa + ";DBNET;SERVICIOS DE CAPACITACION;AGROCAPACITA;;RAMON FREIRE N 986;OSORNO;OSORNO;SOLIS YENNY SOLEDAD;;78079790-8;0010070299;DBNET;SERVICIO VETERINARIO;+56987654321;HERTA FUCHSLOCHER 1001;OSORNO;OSORNO;;;;;PATENTE;;FDO. MIRAMONTES;LOS MUERMOS;LOS MUERMOS;0;40000;;;;;;;;;40000;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;\n" +
                                        "A1;620200;\n" +
                                        "B;1;;SIPEC WEB TRAZABILIDAD ANIMAL;;;;;1;;;UN;40000.000000;;;;;;;;;40000;;;;;;;;\n" +
                                        "B2;INT1;94700003;\n" +
                                        "M; 1;Waldo.gonzalez@dbnetcorp.com;Waldo.gonzalez@dbnetcorp.com;Waldo.gonzalez@dbnetcorp.com;PDF de pruebas;";

                            string base64 = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(Documento));
                            json["Documento"]["txt"] = base64;
                            string resultadoFinal = json.ToString(Newtonsoft.Json.Formatting.Indented);

                            StreamWriter writer2 = new StreamWriter(NuevaRutaCarpeta + "\\34\\" + "JsonE0" + RutEmpresa + "T" + Tipo_docu + "0000" + Foliodesde + ".txt", false, Encoding.Default);

                            writer2.WriteLine(resultadoFinal.TrimEnd());
                            writer2.Close();
                            Foliodesde++;
                        }
                        Foliodesde = int.Parse(txbFolioDesde.Text);

                        AbrirCarpeta(NuevaRutaCarpeta + "\\34\\");
                        break;
                    #endregion

                    #region 39TXT
                    case 39:
                        validarCampos();
                        NuevaRutaCarpeta = Path.Combine(RutaCarpeta, RutaDefecto);
                        creaDirectorio(NuevaRutaCarpeta + "\\39\\");

                        if (CKBGeoReferencia.Checked == true)
                        {

                            for (int i = 1; i <= CantidadTotal; i++)
                            {
                                JObject json = JObject.Parse(contenidoJsonFactura);

                                Documento = "A0;;INGRESO 7 PERSONAS POR 30 DIAS;;|||||;;CON CHEQUE;|772.83|28700.20|TERMINAL MOLO|1||22-09-2020|ALEJANDRA VASQUEZ ACEVEDO|OTROS|||;;0;1.00;\n" +
                                                "A;39;1.0;" + Foliodesde + ";" + fecha + ";3;;;;" + fechaVenc + ";" + RutEmpresa + "-" + DigiEmpresa + ";Dbnet;DEPOSITO Y ALMACENAM. Y OTROS SERV.;;AV. JORGE BARRERA N 62;IQUIQUE;IQUIQUE;66666666-6;66666666;CBT ING.Y CONSTR. LTDA;;RECINTO PORTUARIO S N;IQUIQUE;IQUIQUE;;;;81147;;15418;96565;;;;;RutProvSW;RznSocProvSW;\n" +
                                                "B;1;;21 UND PERMISO ACCESO PERSONAS 1 A 10 DIAS;;1.000000;UND;96565;96565;\n" +
                                                "B2;INT;LSP 46560;\n" +
                                                "G;LatitudEmision;LongitudEmision;1;";

                                string base64 = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(Documento));
                                json["Documento"]["txt"] = base64;
                                string resultadoFinal = json.ToString(Newtonsoft.Json.Formatting.Indented);

                                StreamWriter writer2 = new StreamWriter(NuevaRutaCarpeta + "\\39\\" + "\\JsonE0" + RutEmpresa + "T" + Tipo_docu + "0000" + Foliodesde + ".txt", false, Encoding.Default);

                                writer2.WriteLine(resultadoFinal.TrimEnd());
                                writer2.Close();
                                Foliodesde++;
                            }
                            Foliodesde = int.Parse(txbFolioDesde.Text);
                        }
                        else
                        {

                            for (int i = 1; i <= CantidadTotal; i++)
                            {
                                JObject json = JObject.Parse(contenidoJsonFactura);

                                Documento = "A0;;INGRESO 7 PERSONAS POR 30 DIAS;;|||||;;CON CHEQUE;|772.83|28700.20|TERMINAL MOLO|1||22-09-2020|ALEJANDRA VASQUEZ ACEVEDO|OTROS|||;;0;1.00;\n" +
                                            "A;39;1.0;" + Foliodesde + ";" + fecha + ";3;;;;" + fechaVenc + ";" + RutEmpresa + "-" + DigiEmpresa + ";Dbnet;DEPOSITO Y ALMACENAM. Y OTROS SERV.;;AV. JORGE BARRERA N 62;IQUIQUE;IQUIQUE;66666666-6;66666666;CBT ING.Y CONSTR. LTDA;;RECINTO PORTUARIO S N;IQUIQUE;IQUIQUE;;;;81147;;15418;96565;;;;;;;\n" +
                                            "B;1;;21 UND PERMISO ACCESO PERSONAS 1 A 10 DIAS;;1.000000;UND;96565;96565;\n" +
                                            "B2;INT;LSP 46560;";

                                string base64 = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(Documento));
                                json["Documento"]["txt"] = base64;
                                string resultadoFinal = json.ToString(Newtonsoft.Json.Formatting.Indented);

                                StreamWriter writer2 = new StreamWriter(NuevaRutaCarpeta + "\\39\\" + "\\JsonE0" + RutEmpresa + "T" + Tipo_docu + "0000" + Foliodesde + ".txt", false, Encoding.Default);

                                writer2.WriteLine(resultadoFinal.TrimEnd());
                                writer2.Close();
                                Foliodesde++;
                            }
                            Foliodesde = int.Parse(txbFolioDesde.Text);

                        }
                        AbrirCarpeta(NuevaRutaCarpeta + "\\39\\");
                        break;
                    #endregion

                    #region 41TXT
                    case 41:
                        validarCampos();
                        NuevaRutaCarpeta = Path.Combine(RutaCarpeta, RutaDefecto);
                        creaDirectorio(NuevaRutaCarpeta + "\\41\\");

                        if (CKBGeoReferencia.Checked == true)
                        {
                            for (int i = 1; i <= CantidadTotal; i++)
                            {
                                JObject json = JObject.Parse(contenidoJsonFactura);

                                Documento = "A0;FE_NORACID_SCL01;0094311104-CVARELA-Bol-0040005476;SERVICIOS ULTRACORP;;;;;219;;Hecho no gravado DL 825 de 1974;\n" +
                                           "A;41;1.0;" + Foliodesde + ";" + fecha + ";3 ;;;;" + fechaVenc + ";" + RutEmpresa + "-" + DigiEmpresa + ";Dbnet;Arriendo de Oficinas con Muebles;;Avda. El Bosque Norte 500;LAS CONDES;;9250199-K;0000115971;MAIK BUROSE ;;FRAY LEON  12334 LAS CONDES  LAS CONDES;LAS CONDES;LAS CONDES;;;;0;32104;;32104;;;;32104;RutProvSW;RznSocProvSW;\n" +
                                           "B;1 ;1;Servicio: Arriendo de estacionamiento compartido;;1;;32104;32104;\n" +
                                           "B;2 ;1;Precio vta unitario CLP 32.104 por 1 UN = CLP 32.104,00;;1;;0;0;\n" +
                                           "G;LatitudEmision;LongitudEmision;1;";

                                string base64 = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(Documento));
                                json["Documento"]["txt"] = base64;
                                string resultadoFinal = json.ToString(Newtonsoft.Json.Formatting.Indented);

                                StreamWriter writer2 = new StreamWriter(NuevaRutaCarpeta + "\\41\\" + "\\JsonE0" + RutEmpresa + "T" + Tipo_docu + "0000" + Foliodesde + ".txt", false, Encoding.Default);

                                writer2.WriteLine(resultadoFinal.TrimEnd());
                                writer2.Close();
                                Foliodesde++;
                            }
                            Foliodesde = int.Parse(txbFolioDesde.Text);

                        }
                        else
                        {

                            for (int i = 1; i <= CantidadTotal; i++)
                            {
                                JObject json = JObject.Parse(contenidoJsonFactura);

                                Documento = "A0;FE_NORACID_SCL01;0094311104-CVARELA-Bol-0040005476;SERVICIOS ULTRACORP;;;;;219;;Hecho no gravado DL 825 de 1974;\n" +
                                                 "A;41;1.0;" + Foliodesde + ";" + fecha + ";3 ;;;;" + fechaVenc + ";" + RutEmpresa + "-" + DigiEmpresa + ";Dbnet;Arriendo de Oficinas con Muebles;;Avda. El Bosque Norte 500;LAS CONDES;;9250199-K;0000115971;MAIK BUROSE ;;FRAY LEON  12334 LAS CONDES  LAS CONDES;LAS CONDES;LAS CONDES;;;;0;32104;;32104;;;;32104;;;\n" +
                                                 "B;1 ;1;Servicio: Arriendo de estacionamiento compartido;;1;;32104;32104;\n" +
                                                 "B;2 ;1;Precio vta unitario CLP 32.104 por 1 UN = CLP 32.104,00;;1;;0;0;";

                                string base64 = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(Documento));
                                json["Documento"]["txt"] = base64;
                                string resultadoFinal = json.ToString(Newtonsoft.Json.Formatting.Indented);

                                StreamWriter writer2 = new StreamWriter(NuevaRutaCarpeta + "\\41\\" + "\\JsonE0" + RutEmpresa + "T" + Tipo_docu + "0000" + Foliodesde + ".txt", false, Encoding.Default);

                                writer2.WriteLine(resultadoFinal.TrimEnd());
                                writer2.Close();
                                Foliodesde++;
                            }
                            Foliodesde = int.Parse(txbFolioDesde.Text);

                        }
                        AbrirCarpeta(NuevaRutaCarpeta + "\\41\\");
                        break;
                    #endregion

                    #region 43TXT
                    case 43:
                        validarCampos();
                        NuevaRutaCarpeta = Path.Combine(RutaCarpeta, RutaDefecto);
                        creaDirectorio(NuevaRutaCarpeta + "\\43\\");

                        for (int i = 1; i <= CantidadTotal; i++)
                        {
                            JObject json = JObject.Parse(contenidoJsonFactura);

                            Documento = "A0;;;;;;;;;;;\n" +
                                         "A;43;1.0;" + Foliodesde + ";" + fecha + ";;;;;;2;;;;;;0;" + fechaVenc + ";" + RutEmpresa + "-" + DigiEmpresa + ";DBNET Ingenieria de Software;venta de confites;;;18 sep 1234; HUECHURABA;SANTIAGO;;;78079790-8;111;dbnet;Papas;511551;dbnet; CERRILLOS;SANTIAGO;;;;;;;;;;33;0;0;19.00;6;0;0;;0;0;39;0;0;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;\n" +
                                         "A1;620200;\n" +
                                         "B;1;;a;a;;;;1;;;;3;;;;0;0;0;0;;3;;;;;;;;\n" +
                                         "B2;INT1;123;\n" +
                                         "B2;DUN14;2;\n" +
                                         "B5;22;\n" +
                                         "M; 1;Waldo.gonzalez@dbnetcorp.com;Waldo.gonzalez@dbnetcorp.com;Waldo.gonzalez@dbnetcorp.com;PDF de pruebas;";

                            string base64 = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(Documento));
                            json["Documento"]["txt"] = base64;
                            string resultadoFinal = json.ToString(Newtonsoft.Json.Formatting.Indented);

                            StreamWriter writer2 = new StreamWriter(NuevaRutaCarpeta + "\\43\\" + "JsonE0" + RutEmpresa + "T" + Tipo_docu + "0000" + Foliodesde + ".txt", false, Encoding.Default);

                            writer2.WriteLine(resultadoFinal.TrimEnd());
                            writer2.Close();
                            Foliodesde++;
                        }
                        Foliodesde = int.Parse(txbFolioDesde.Text);

                        AbrirCarpeta(NuevaRutaCarpeta + "\\43\\");
                        break;
                    #endregion

                    #region 46TXT
                    case 46:
                        validarCampos();
                        NuevaRutaCarpeta = Path.Combine(RutaCarpeta, RutaDefecto);
                        creaDirectorio(NuevaRutaCarpeta + "\\46\\");

                        for (int i = 1; i <= CantidadTotal; i++)
                        {
                            JObject json = JObject.Parse(contenidoJsonFactura);

                            Documento = "A0;;;;;;;;;;;\n" +
                                         "A;46;1.0;" + Foliodesde + ";" + fecha + ";;;;;;;;;;;;;;" + RutEmpresa + "-" + DigiEmpresa + ";UNIVERSIDAD DE LOS LAGOS;EDUCACION;;;AVENIDA FUCHSLOCHER 1305;OSORNO;;;;10777715-6;;JOSE LEONEL VILLARROEL CASANOVA;OTRAS ACTIV.DE SERV.PERSONALES N.C.P.;.;CARRETERA AUSTRAL KILOMETRO 30 .;PUERTO MONTT;PUERTO MONTT;;;;;;;;;;126000;0;;019.00;23940;;;;;;126000;;;;;;;;;;CREDITO;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;\n" +
                                         "A1;620200;\n" +
                                         "A2;15;19.00;23940;\n" +
                                         "B;1;;COMPRA DE 63 KILOGRAMOS DE PESCADO FRESCO PARA ALIMENTO DE CONGRIOS VALOR UNITAR;IO $2.000.- EL KILOGRAMO.;;;;63;;;;2000;;;;;;;;15;126000;;;;;;;;\n" +
                                         "M; 1;Waldo.gonzalez@dbnetcorp.com;Waldo.gonzalez@dbnetcorp.com;Waldo.gonzalez@dbnetcorp.com;PDF de pruebas;";

                            string base64 = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(Documento));
                            json["Documento"]["txt"] = base64;
                            string resultadoFinal = json.ToString(Newtonsoft.Json.Formatting.Indented);

                            StreamWriter writer2 = new StreamWriter(NuevaRutaCarpeta + "\\46\\" + "JsonE0" + RutEmpresa + "T" + Tipo_docu + "0000" + Foliodesde + ".txt", false, Encoding.Default);

                            writer2.WriteLine(resultadoFinal.TrimEnd());
                            writer2.Close();
                            Foliodesde++;
                        }
                        Foliodesde = int.Parse(txbFolioDesde.Text);

                        AbrirCarpeta(NuevaRutaCarpeta + "\\46\\");
                        break;
                    #endregion

                    #region 52TXT
                    case 52:
                        validarCampos();
                        NuevaRutaCarpeta = Path.Combine(RutaCarpeta, RutaDefecto);
                        creaDirectorio(NuevaRutaCarpeta + "\\52\\");
                        if (ckbLeyMadera.Checked == true)
                        {
                            for (int i = 1; i <= CantidadTotal; i++)
                            {
                                JObject json = JObject.Parse(contenidoJsonFactura);

                                Documento = "A;52;1.0;" + Foliodesde + ";" + fecha + ";;;;;;;;;;;;;" + fechaVenc + ";" + RutEmpresa + "-" + DigiEmpresa + ";DBNET;TIC;;;8;SANTIAGO;;;;78079790-8;;DBNET;TIC2;065-2265500;AV ALGO;PUERTO MONTT;LLANQUIHUE;;;;;;;;;;259439;0;;19.00;49293;;;;;;237048;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;\n" +
                                                "A1;620200;\n" +
                                                "B;1;;Elote;;;;;1;;;;259439;;;;;;;;;259439;;;;;;;;\n" +
                                                "G;String 1;Sring 2;1;\n" +
                                                "H;1;2;3;4;String 5;String 6;1;\n" +
                                                "M; 1;Waldo.gonzalez@dbnetcorp.com;Waldo.gonzalez@dbnetcorp.com;Waldo.gonzalez@dbnetcorp.com;PDF de pruebas;";

                                string base64 = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(Documento));
                                json["Documento"]["txt"] = base64;
                                string resultadoFinal = json.ToString(Newtonsoft.Json.Formatting.Indented);

                                StreamWriter writer2 = new StreamWriter(NuevaRutaCarpeta + "\\52\\" + "JsonE0" + RutEmpresa + "T" + Tipo_docu + "0000" + Foliodesde + ".txt", false, Encoding.Default);

                                writer2.WriteLine(resultadoFinal.TrimEnd());
                                writer2.Close();
                                Foliodesde++;
                            }
                            Foliodesde = int.Parse(txbFolioDesde.Text);
                        }
                        else
                        {
                            for (int i = 1; i <= CantidadTotal; i++)
                            {
                                JObject json = JObject.Parse(contenidoJsonFactura);

                                Documento = "A;52;1.0;" + Foliodesde + ";" + fecha + ";;;;;;;;;;;;;" + fechaVenc + ";" + RutEmpresa + "-" + DigiEmpresa + ";DBNET;TIC;;;8;SANTIAGO;;;;78079790-8;;DBNET;TIC2;065-2265500;AV ALGO;PUERTO MONTT;LLANQUIHUE;;;;;;;;;;259439;0;;19.00;49293;;;;;;237048;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;\n" +
                                            "A1;620200;\n" +
                                            "B;1;;Elote;;;;;1;;;;259439;;;;;;;;;259439;;;;;;;;\n" +
                                            "M; 1;Waldo.gonzalez@dbnetcorp.com;Waldo.gonzalez@dbnetcorp.com;Waldo.gonzalez@dbnetcorp.com;PDF de pruebas;";



                                string base64 = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(Documento));
                                json["Documento"]["txt"] = base64;
                                string resultadoFinal = json.ToString(Newtonsoft.Json.Formatting.Indented);

                                StreamWriter writer2 = new StreamWriter(NuevaRutaCarpeta + "\\52\\" + "JsonE0" + RutEmpresa + "T" + Tipo_docu + "0000" + Foliodesde + ".txt", false, Encoding.Default);

                                writer2.WriteLine(resultadoFinal.TrimEnd());
                                writer2.Close();
                                Foliodesde++;
                            }
                            Foliodesde = int.Parse(txbFolioDesde.Text);

                        }
                        AbrirCarpeta(NuevaRutaCarpeta + "\\52\\");
                        break;
                    #endregion

                    #region 56TXT
                    case 56:
                        validarCampos();
                        NuevaRutaCarpeta = Path.Combine(RutaCarpeta, RutaDefecto);
                        creaDirectorio(NuevaRutaCarpeta + "\\56\\");

                        for (int i = 1; i <= CantidadTotal; i++)
                        {
                            JObject json = JObject.Parse(contenidoJsonFactura);

                            Documento = "A;56;1.0;" + Foliodesde + ";" + fecha + ";;;;;;;;;;;;;" + fechaVenc + ";" + RutEmpresa + "-" + DigiEmpresa + ";DBNET;TIC;;;8;SANTIAGO;;;;78079790-8;1234567894;DBNET;TIC;065-2265500;AV SIEMPRE VIVA;PUERTO MONTT;LLANQUIHUE;;;;;;;;;;199200;0;;19.00;37848;;;;;;237048;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;\n" +
                                       "A1;620200;\n" +
                                       "A2;50;9;20;\n" +
                                       "B;1;;Coliflor;;;;;1;;;;864145;;;;;;;;;864145;;;;R;100;;;\n" +
                                       "B;2;;Dátil;;;;;1;;;;977481;;;;;;;;;977481;;;;R;;200;;\n" +
                                       "B;3;;Betabel;;;;;1;;;;842942;;;;;;;;;842942;;;;R;;;300;\n" +
                                       "B;4;;Ajo;;;;;1;;;;349403;;;;;;;;;349403;;;;R;100;200;300;\n" +
                                       "D;1;801;;53333;;2015-04-22;;;\n" +
                                       "M; 1;Waldo.gonzalez@dbnetcorp.com;Waldo.gonzalez@dbnetcorp.com;Waldo.gonzalez@dbnetcorp.com;PDF de pruebas;";

                            string base64 = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(Documento));
                            json["Documento"]["txt"] = base64;
                            string resultadoFinal = json.ToString(Newtonsoft.Json.Formatting.Indented);

                            StreamWriter writer2 = new StreamWriter(NuevaRutaCarpeta + "\\56\\" + "JsonE0" + RutEmpresa + "T" + Tipo_docu + "0000" + Foliodesde + ".txt", false, Encoding.Default);

                            writer2.WriteLine(resultadoFinal.TrimEnd());
                            writer2.Close();
                            Foliodesde++;
                        }
                        Foliodesde = int.Parse(txbFolioDesde.Text);

                        AbrirCarpeta(NuevaRutaCarpeta + "\\56\\");
                        break;
                    #endregion

                    #region 61TXT
                    case 61:
                        validarCampos();
                        NuevaRutaCarpeta = Path.Combine(RutaCarpeta, RutaDefecto);
                        creaDirectorio(NuevaRutaCarpeta + "\\61\\");

                        for (int i = 1; i <= CantidadTotal; i++)
                        {
                            JObject json = JObject.Parse(contenidoJsonFactura);

                            Documento = "A;61;1.0;" + Foliodesde + ";" + fecha + ";;;;;;3;;;;;;;" + fechaVenc + ";" + RutEmpresa + "-" + DigiEmpresa + ";DBNET;TIC;;;8;SANTIAGO;;;;78079790-8;1234567893;DBNET;TIC;065-2265500;AV SIEMPRE VIVA;PUERTO MONTT;LLANQUIHUE;;;;;;;;;;199200;0;;19.00;37848;;;;;;237048;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;\n" +
                                        "A1;620200;\n" +
                                        "A2;17;9;20;\n" +
                                        "B;1;;Coliflor;;;;;1;;;;864145;;;;;;;;;864145;;;;R;100;;;\n" +
                                        "B;2;;Dátil;;;;;1;;;;977481;;;;;;;;;977481;;;;R;;200;;\n" +
                                        "B;3;;Betabel;;;;;1;;;;842942;;;;;;;;;842942;;;;R;;;300;\n" +
                                        "B;4;;Ajo;;;;;1;;;;349403;;;;;;;;;349403;;;;R;100;200;300;\n" +
                                        "D;1;801;;285613;;2015-04-22;;;\n" +
                                        "M; 1;Waldo.gonzalez@dbnetcorp.com;Waldo.gonzalez@dbnetcorp.com;Waldo.gonzalez@dbnetcorp.com;PDF de pruebas;";

                            string base64 = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(Documento));
                            json["Documento"]["txt"] = base64;
                            string resultadoFinal = json.ToString(Newtonsoft.Json.Formatting.Indented);

                            StreamWriter writer2 = new StreamWriter(NuevaRutaCarpeta + "\\61\\" + "JsonE0" + RutEmpresa + "T" + Tipo_docu + "0000" + Foliodesde + ".txt", false, Encoding.Default);

                            writer2.WriteLine(resultadoFinal.TrimEnd());
                            writer2.Close();
                            Foliodesde++;
                        }
                        Foliodesde = int.Parse(txbFolioDesde.Text);
                        AbrirCarpeta(NuevaRutaCarpeta + "\\61\\");
                        break;
                    #endregion

                    #region 110TXT
                    case 110:
                        validarCampos();
                        NuevaRutaCarpeta = Path.Combine(RutaCarpeta, RutaDefecto);
                        creaDirectorio(NuevaRutaCarpeta + "\\110\\");

                        for (int i = 1; i <= CantidadTotal; i++)
                        {
                            JObject json = JObject.Parse(contenidoJsonFactura);

                            Documento = "A0;;0095000025;;;;;;;;;\n" +
                                         "A;110;1.0;" + Foliodesde + ";" + fecha + ";;;;;;2;;;;;;;" + fechaVenc + ";" + RutEmpresa + "-" + DigiEmpresa + ";SALMONES MULTIEXPORT S.A.;GIRO MULTIEXPORT;S100;;Avda Cardonal 2501;Puerto Montt;Puerto Montt;;;55555555-5;0012000678;OOO AKRA;.;;NAB. REKI SMOLENKI, D.14, LITER A,;ST PETERSBURG;ST PETERSBURG;;;;;;;;;;0;1000.00;;;;;;;;;1000.00;;;;;;;;;;Cobr Directa (Crédito) 30 días;;;;;;;;;;;;;1;;;;;;;;;;;;;;;;;;;;;;;;;DOLAR USA;;;;;;;;;;;;;\n" +
                                         "A1;620200;\n" +
                                         "A3;22;10;;;;;\n" +
                                         "B;1;;FROZEN ATLANTIC SALMON HON IND. B 0,5-1 KG IQF;;;;;100;;;KG;10.00;;;;;;;;;1000.00;;;;;;;;\n" +
                                         "B2;INT1;3000002;\n" +
                                         "M; 1;Waldo.gonzalez@dbnetcorp.com;Waldo.gonzalez@dbnetcorp.com;Waldo.gonzalez@dbnetcorp.com;PDF de pruebas;";

                            string base64 = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(Documento));
                            json["Documento"]["txt"] = base64;
                            string resultadoFinal = json.ToString(Newtonsoft.Json.Formatting.Indented);

                            StreamWriter writer2 = new StreamWriter(NuevaRutaCarpeta + "\\110\\" + "JsonE0" + RutEmpresa + "T" + Tipo_docu + "0000" + Foliodesde + ".txt", false, Encoding.Default);

                            writer2.WriteLine(resultadoFinal.TrimEnd());
                            writer2.Close();
                            Foliodesde++;
                        }
                        Foliodesde = int.Parse(txbFolioDesde.Text);
                        AbrirCarpeta(NuevaRutaCarpeta + "\\110\\");
                        break;
                    #endregion

                    #region 111TXT
                    case 111:
                        validarCampos();
                        NuevaRutaCarpeta = Path.Combine(RutaCarpeta, RutaDefecto);
                        creaDirectorio(NuevaRutaCarpeta + "\\111\\");

                        for (int i = 1; i <= CantidadTotal; i++)
                        {
                            JObject json = JObject.Parse(contenidoJsonFactura);

                            Documento = "A0;\\SRP-VENLACETEST\\HPM602;;;;;0;0;;25.00;0;\n" +
                                       "A;111;1.0;" + Foliodesde + ";" + fecha + ";;;;;;1;;;;;;;" + fechaVenc + ";" + RutEmpresa + "-" + DigiEmpresa + ";MARIENBERG;PRODUCCION Y COMERCIALIZACION DE ELEMENTOS PARA LA INDUSTRIA;;;SANTA MARTA;MAIPÚ;SANTIAGO;GERENCIA;;55555555-5;20-23644496-2;CERMINARO JUAN MANUEL;IMPORTADORES DE PISOS Y ALFOMBRAS;(+5411)6860 1925;AV JUAN MANUEL DE ROSAS 138 – CASTELAR –MORON (1712);CASTELAR  MORON;BUENOS AIRES;U_CASILLA_CORR;;;;;;;;;0;25.00;;;;;;;;;25.00;;;;;;;;;;Depósito y/o Transferencia;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;0;;;;;DOLAR USA;;;;PESO CL;667.550000;;16689;;;;;16689.00;\n" +
                                       "A1;620200;\n" +
                                       "B;1;;Diferencia por tipo de Cambio al pagar Neto de FV 88989;Diferencia por tipo de Cambio al pagar Neto de FV 88989;;;;1;;;;25.00;;;;0.0;0;;;;25.00;;;;;;;;\n" +
                                       "D;1;110;;13;;2019-02-27;3;;\n" +
                                       "M; 1;Waldo.gonzalez@dbnetcorp.com;Waldo.gonzalez@dbnetcorp.com;Waldo.gonzalez@dbnetcorp.com;PDF de pruebas;";

                            string base64 = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(Documento));
                            json["Documento"]["txt"] = base64;
                            string resultadoFinal = json.ToString(Newtonsoft.Json.Formatting.Indented);

                            StreamWriter writer2 = new StreamWriter(NuevaRutaCarpeta + "\\111\\" + "JsonE0" + RutEmpresa + "T" + Tipo_docu + "0000" + Foliodesde + ".txt", false, Encoding.Default);

                            writer2.WriteLine(resultadoFinal.TrimEnd());
                            writer2.Close();
                            Foliodesde++;
                        }
                        Foliodesde = int.Parse(txbFolioDesde.Text);
                        AbrirCarpeta(NuevaRutaCarpeta + "\\111\\");
                        break;
                    #endregion

                    #region 112TXT
                    case 112:
                        validarCampos();
                        NuevaRutaCarpeta = Path.Combine(RutaCarpeta, RutaDefecto);
                        creaDirectorio(NuevaRutaCarpeta + "\\112\\");

                        for (int i = 1; i <= CantidadTotal; i++)
                        {
                            JObject json = JObject.Parse(contenidoJsonFactura);

                            Documento = "A;112;1.0;" + Foliodesde + ";" + fecha + ";;;;;;;;;;;;;" + fechaVenc + ";" + RutEmpresa + "-" + DigiEmpresa + ";GE HEALTHCARE INTERNATIONAL LLC AGENCIA EN CHILE;REP DE OTROS EQ ELECT Y OPTICOS N.C.P.;;;Isidora Goyenechea 2800,Piso 21;Santiago;Las Condes;;;78079790-8;;GE HEALTHCARE COLOMBIA S.A.S.;VENTA AL POR MAYOR NO ESPECIALIZADA;;CALLE 103 NO. 14 A-43;Bogota;BOGOTA, D.C.;110111;;;;;;CALLE 103 NO. 14 A-43;Bogota;BOGOTA, D.C.;0;87840.76;;;;;;;;;87840.76;;;;;;1;;;;;1;;;;;;;;;;;1;8;;;;;;;;;;;;;;;;;;;;;;;;202;DOLAR USA;;;;PESO CL;693;60873646.68;;;;;;60873646.68;\n" +
                             "A1;620200;\n" +
                             "B;1;1;Por la provision de un equipo modelo marca GE Segun propuesta definitiva FDON; Por la provision de un equipo modelo marca GE Segun propuesta definitiva FDON;;10;;2583.55176;;;10;34;;;;;;;;;87840.76;;;;;;;;\n" +
                             "D;1;110;;18;;2019-05-13;3;Corrige montos;\n" +
                             "D;2;801;;56756;;2019-05-13;;;\n" +
                              "M; 1;Waldo.gonzalez@dbnetcorp.com;Waldo.gonzalez@dbnetcorp.com;Waldo.gonzalez@dbnetcorp.com;PDF de pruebas;";

                            string base64 = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(Documento));
                            json["Documento"]["txt"] = base64;
                            string resultadoFinal = json.ToString(Newtonsoft.Json.Formatting.Indented);

                            StreamWriter writer2 = new StreamWriter(NuevaRutaCarpeta + "\\112\\" + "JsonE0" + RutEmpresa + "T" + Tipo_docu + "0000" + Foliodesde + ".txt", false, Encoding.Default);

                            writer2.WriteLine(resultadoFinal.TrimEnd());
                            writer2.Close();
                            Foliodesde++;
                        }
                        Foliodesde = int.Parse(txbFolioDesde.Text);
                        AbrirCarpeta(NuevaRutaCarpeta + "\\112\\");
                        break;
                        #endregion
                }
            }

            if (Accion == "JSON GATEWAY")
            {
                JSON gateway = new JSON();

                switch (Tipo_docu)
                {
                    #region 33TXTJson
                    case 33:
                        validarCampos();
                        NuevaRutaCarpeta = Path.Combine(RutaCarpeta, RutaDefecto);
                        creaDirectorio(NuevaRutaCarpeta + "\\33\\");
                        if (ckbLeyMadera.Checked == true)
                        {
                            string json33 = gateway.JSON33Gateway(CantidadTotal, fecha, fechaVenc, NuevaRutaCarpeta, RutEmpresa, Tipo_docu, Foliodesde);
                        }
                        else
                        {
                            string json33 = gateway.JSON33Gateway(CantidadTotal, fecha, fechaVenc, NuevaRutaCarpeta, RutEmpresa, Tipo_docu, Foliodesde);
                        }
                        Foliodesde = int.Parse(txbFolioDesde.Text);
                        AbrirCarpeta(NuevaRutaCarpeta + "\\33\\");
                        break;
                    #endregion

                    #region 34TXT
                    case 34:
                        validarCampos();
                        NuevaRutaCarpeta = Path.Combine(RutaCarpeta, RutaDefecto);
                        creaDirectorio(NuevaRutaCarpeta + "\\34\\");
                        string json34 = gateway.JSON34Gateway(CantidadTotal, fecha, fechaVenc, NuevaRutaCarpeta, RutEmpresa, Tipo_docu, Foliodesde);
                        Foliodesde = int.Parse(txbFolioDesde.Text);
                        AbrirCarpeta(NuevaRutaCarpeta + "\\34\\");
                        break;
                    #endregion

                    #region 39TXT
                    case 39:
                        validarCampos();
                        NuevaRutaCarpeta = Path.Combine(RutaCarpeta, RutaDefecto);
                        creaDirectorio(NuevaRutaCarpeta + "\\39\\");
                        if (ckbLeyMadera.Checked == true)
                        {
                            string json39 = gateway.JSON39Gateway(CantidadTotal, fecha, fechaVenc, NuevaRutaCarpeta, RutEmpresa, Tipo_docu, Foliodesde);
                        }
                        else
                        {
                            string json39 = gateway.JSON39Gateway(CantidadTotal, fecha, fechaVenc, NuevaRutaCarpeta, RutEmpresa, Tipo_docu, Foliodesde);
                        }
                        Foliodesde = int.Parse(txbFolioDesde.Text);
                        AbrirCarpeta(NuevaRutaCarpeta + "\\39\\");
                        break;
                    #endregion

                    #region 41TXT
                    case 41:
                        validarCampos();
                        NuevaRutaCarpeta = Path.Combine(RutaCarpeta, RutaDefecto);
                        creaDirectorio(NuevaRutaCarpeta + "\\41\\");
                        if (ckbLeyMadera.Checked == true)
                        {
                            string json41 = gateway.JSON41Gateway(CantidadTotal, fecha, fechaVenc, NuevaRutaCarpeta, RutEmpresa, Tipo_docu, Foliodesde);
                        }
                        else
                        {
                            string json41 = gateway.JSON41Gateway(CantidadTotal, fecha, fechaVenc, NuevaRutaCarpeta, RutEmpresa, Tipo_docu, Foliodesde);
                        }
                        Foliodesde = int.Parse(txbFolioDesde.Text);
                        AbrirCarpeta(NuevaRutaCarpeta + "\\41\\");
                        break;
                    #endregion

                    #region 43TXT
                    case 43:
                        validarCampos();
                        NuevaRutaCarpeta = Path.Combine(RutaCarpeta, RutaDefecto);
                        creaDirectorio(NuevaRutaCarpeta + "\\43\\");
                        string json43 = gateway.JSON43Gateway(CantidadTotal, fecha, fechaVenc, NuevaRutaCarpeta, RutEmpresa, Tipo_docu, Foliodesde);
                        Foliodesde = int.Parse(txbFolioDesde.Text);
                        AbrirCarpeta(NuevaRutaCarpeta + "\\43\\");
                        break;
                    #endregion

                    #region 46TXT
                    case 46:
                        validarCampos();
                        NuevaRutaCarpeta = Path.Combine(RutaCarpeta, RutaDefecto);
                        creaDirectorio(NuevaRutaCarpeta + "\\46\\");
                        string json46 = gateway.JSON46Gateway(CantidadTotal, fecha, fechaVenc, NuevaRutaCarpeta, RutEmpresa, Tipo_docu, Foliodesde);
                        Foliodesde = int.Parse(txbFolioDesde.Text);
                        AbrirCarpeta(NuevaRutaCarpeta + "\\46\\");
                        break;
                    #endregion

                    #region 52TXT
                    case 52:
                        validarCampos();
                        NuevaRutaCarpeta = Path.Combine(RutaCarpeta, RutaDefecto);
                        creaDirectorio(NuevaRutaCarpeta + "\\52\\");
                        if (ckbLeyMadera.Checked == true)
                        {
                            string json52 = gateway.JSON52Gateway(CantidadTotal, fecha, fechaVenc, NuevaRutaCarpeta, RutEmpresa, Tipo_docu, Foliodesde);
                        }
                        else
                        {
                            string json52 = gateway.JSON52Gateway(CantidadTotal, fecha, fechaVenc, NuevaRutaCarpeta, RutEmpresa, Tipo_docu, Foliodesde);
                        }
                        Foliodesde = int.Parse(txbFolioDesde.Text);
                        AbrirCarpeta(NuevaRutaCarpeta + "\\52\\");
                        break;
                    #endregion

                    #region 56TXT
                    case 56:
                        validarCampos();
                        NuevaRutaCarpeta = Path.Combine(RutaCarpeta, RutaDefecto);
                        creaDirectorio(NuevaRutaCarpeta + "\\56\\");
                        string json56 = gateway.JSON56Gateway(CantidadTotal, fecha, fechaVenc, NuevaRutaCarpeta, RutEmpresa, Tipo_docu, Foliodesde);
                        Foliodesde = int.Parse(txbFolioDesde.Text);
                        AbrirCarpeta(NuevaRutaCarpeta + "\\56\\");
                        break;
                    #endregion

                    #region 61TXT
                    case 61:
                        validarCampos();
                        NuevaRutaCarpeta = Path.Combine(RutaCarpeta, RutaDefecto);
                        creaDirectorio(NuevaRutaCarpeta + "\\61\\");
                        string json61 = gateway.JSON61Gateway(CantidadTotal, fecha, fechaVenc, NuevaRutaCarpeta, RutEmpresa, Tipo_docu, Foliodesde);
                        Foliodesde = int.Parse(txbFolioDesde.Text);
                        AbrirCarpeta(NuevaRutaCarpeta + "\\61\\");
                        break;
                    #endregion

                    #region 110TXT
                    case 110:
                        validarCampos();
                        NuevaRutaCarpeta = Path.Combine(RutaCarpeta, RutaDefecto);
                        creaDirectorio(NuevaRutaCarpeta + "\\110\\");
                        string json110 = gateway.JSON110Gateway(CantidadTotal, fecha, fechaVenc, NuevaRutaCarpeta, RutEmpresa, Tipo_docu, Foliodesde);
                        Foliodesde = int.Parse(txbFolioDesde.Text);
                        AbrirCarpeta(NuevaRutaCarpeta + "\\110\\");
                        break;
                    #endregion

                    #region 111TXT
                    case 111:
                        validarCampos();
                        NuevaRutaCarpeta = Path.Combine(RutaCarpeta, RutaDefecto);
                        creaDirectorio(NuevaRutaCarpeta + "\\111\\");
                        string json111 = gateway.JSON111Gateway(CantidadTotal, fecha, fechaVenc, NuevaRutaCarpeta, RutEmpresa, Tipo_docu, Foliodesde);
                        Foliodesde = int.Parse(txbFolioDesde.Text);
                        AbrirCarpeta(NuevaRutaCarpeta + "\\111\\");
                        break;
                    #endregion

                    #region 112TXT
                    case 112:
                        validarCampos();
                        NuevaRutaCarpeta = Path.Combine(RutaCarpeta, RutaDefecto);
                        creaDirectorio(NuevaRutaCarpeta + "\\112\\");
                        string json112 = gateway.JSON112Gateway(CantidadTotal, fecha, fechaVenc, NuevaRutaCarpeta, RutEmpresa, Tipo_docu, Foliodesde);
                        Foliodesde = int.Parse(txbFolioDesde.Text);
                        AbrirCarpeta(NuevaRutaCarpeta + "\\112\\");
                        break;
                        #endregion
                }
            }
            if (Accion == "JSON API2020")
            {

            }
            if (Accion == "SEM API2020")
            {

            }

        } 
        

        private void txbFolioDesde_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Cancela la tecla
            }
        }

        private void txbCantidadTotal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Cancela la tecla
            }
        }

        private void txbRut_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Cancela la tecla
            }
        }

        private void txbDigi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) &&
                !char.IsDigit(e.KeyChar) &&
                e.KeyChar != 'k' && e.KeyChar != 'K')
            {
                e.Handled = true; // Bloquea todo lo demás
            }
        }
        public String creaDirectorio(String ruta)
        {

            if (!System.IO.Directory.Exists(ruta))
            {
                System.IO.Directory.CreateDirectory(ruta);
            }
            return ruta;
        }
        public void AbrirCarpeta(string ruta)
        {
            var startInfo = new ProcessStartInfo(ruta)
            {
                UseShellExecute = true,
                Verb = "open"
            };

            Process.Start(startInfo);
        }

        private void txbCantidadTotal_TextChanged(object sender, EventArgs e)
        {
            CantidadTotal = int.Parse(txbCantidadTotal.Text);
        }

        private void txbFolioDesde_TextChanged(object sender, EventArgs e)
        {
            Foliodesde = int.Parse(txbFolioDesde.Text);
        }

        private void cbxAccion_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbxAccion.SelectedIndex)
            {
                case 0:
                    Accion = "TXT";
                    break;
                case 1:
                    Accion = "TXT API2020";
                    break;
                case 2:
                    Accion = "JSON GATEWAY";
                    break;
                case 3:
                    Accion = "JSON API2020";
                    break;
                case 4:
                    Accion = "SEM API2020";
                    break;
            }

        }
    }
}
