using System;

using System.Windows.Forms;

namespace ClaveDbnet
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public  void BtnDesencripta_Click(object sender, EventArgs e)
        {
            if (TxbDesencripta.Text == "")
            {
                MessageBox.Show("Campo Desencripta sin Valor");
            }
            else
            { 
                String Desencripta = TxbDesencripta.Text;
                string DesencriptaSalida = Utiles.dese_vari(Desencripta);
                TxBEncripta.Text = DesencriptaSalida;
                MessageBox.Show(DesencriptaSalida);
            }

        }

        private void BtnEncripta_Click(object sender, EventArgs e)
        {
            if (TxBEncripta.Text == "")
            {
                MessageBox.Show("Campo Encripta sin Valor");
            }
            else
            { 
                String Encripta = TxBEncripta.Text;
                string EncriptaSalida = Utiles.encr_vari(Encripta);
                TxbDesencripta.Text = EncriptaSalida;
                MessageBox.Show(EncriptaSalida);
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MaximizeBox = false;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
        }
    }
}
