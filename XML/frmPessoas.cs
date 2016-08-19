using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Xml.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XML
{
    class Pessoa
    {
        #region Atributos
        private int codigo;
        private string nome;
        private string telefone;
        #endregion

        #region Propriedades
        public int Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }

        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }


        public string Telefone
        {
            get { return telefone; }
            set { telefone = value; }
        }
        #endregion

        #region Métodos
        //Aqui ficarão os métodos
        public static List<Pessoa> ListarPessoas()
        {
            List<Pessoa> pessoas = new List<Pessoa>();
            XElement xml = XElement.Load("Pessoas.xml");
            foreach (XElement x in xml.Elements())
            {
                Pessoa p = new Pessoa()
                {
                    codigo = int.Parse(x.Attribute("codigo").Value),
                    nome = x.Attribute("nome").Value,
                    telefone = x.Attribute("telefone").Value
                };
                pessoas.Add(p);
            }
            return pessoas;
        }

        #endregion
    }

    public partial class frmPessoas : Form
    {
        public frmPessoas()
        {
            InitializeComponent();
        }

        private void frmPessoas_Load(object sender, EventArgs e)
        {
            //pessoas = Pessoa.ListarPessoas();
            //gridView.DataSource = pessoas;
        }
    }
}
