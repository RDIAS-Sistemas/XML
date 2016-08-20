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

namespace DB
{
    class Pagamento
    {
        #region Atributos
        private string codigoLojaErp;
        private string nsu;
        private string valorBruto;
        #endregion

        #region Propriedades
        public string CodigoLojaErp
        {
            get { return CodigoLojaErp; }
            set { CodigoLojaErp = value; }
        }

        public string NSU
        {
            get { return nsu; }
            set { nsu = value; }
        }

        public string ValorBruto
        {
            get { return valorBruto; }
            set { valorBruto = value; }
        }
        #endregion
        #region Métodos
        //Aqui ficarão os métodos
        public static List<Pagamento> ListarPagamentos()
        {
            List<Pagamento> pagamentos = new List<Pagamento>();
            XElement xml = XElement.Load("Santour.xml");
            foreach (XElement x in xml.Elements())
            {
                Pagamento p = new Pagamento()
                {
                //    codigoLojaErp = x.Attribute("codigoLojaErp").Value,
                //    nsu = x.Attribute("nsu").Value,
                //    valorBruto = x.Attribute("valorBruto").Value
                };
                //pagamentos.Add(p);
            }
            return null;
            //return pagamentos;
        }
        #endregion

    }
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

        public void AdicionarPessoa(Pessoa p)
        {
            throw new System.NotImplementedException();
        }

        public void ExcluirPessoa(int codigo)
        {
            throw new System.NotImplementedException();
        }

        public void EditarPessoa(Pessoa pessoa)
        {
            throw new System.NotImplementedException();
        }

        #endregion
    }

    public partial class frmPessoas : Form
    {
        List<Pessoa> pessoas = null;
        List<Pagamento> pagamentos = null;

        public frmPessoas()
        {
            InitializeComponent();
        }

        private void frmPessoas_Load(object sender, EventArgs e)
        {
            //pessoas = Pessoa.ListarPessoas();
            pagamentos = Pagamento.ListarPagamentos();
            dataGridViewPessoas.DataSource = pagamentos;
        }
    }
}
