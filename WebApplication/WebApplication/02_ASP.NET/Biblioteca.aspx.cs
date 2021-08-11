using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;

namespace WebApplication._02_ASP.NET
{
    public partial class Biblioteca : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //chama apenas na primeira carga da pagina
            if (!Page.IsPostBack)
            {
                obterLivro();
            }
        }

        protected void gvLivro_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void btnInserir_Click(object sender, EventArgs e)
        {
            try
            {
                lbnMsgTable.Text = string.Empty;
                Livro o_Livro = new Livro();//classe Livro

                
                // Valida se esses campos estão preenchidos
                if (txtTitulo.Text.ToString().Trim() == "")//trim tira os espaços
                {
                    lbnMsg.Text = "Por favor informe o título do livro!";
                    txtTitulo.Focus();
                    return;
                }
                if (txtAutor.Text.ToString().Trim() == "")//trim tira os espaços
                {
                    lbnMsg.Text = "Por favor informe o nome do autor!";
                    txtAutor.Focus();
                    return;
                }

                //Caso não preencha o campo o valor na tabela aparece ZERO
                int edicaoVar = 0;
                if (txtEdicao.Text.ToString() != "")
                {
                    edicaoVar = int.Parse(txtEdicao.Text.ToString());
                }
                else
                {
                    lbnMsgTable.Text = "*Campos númericos não informados são registrados como zero";
                }

                //Caso não preencha o campo o valor na tabela aparece ZERO
                int anoVar = 0;
                if (txtAno.Text.ToString() != "")
                {
                    anoVar = int.Parse(txtAno.Text.ToString());
                }
                else
                {
                    lbnMsgTable.Text = "*Campos númericos não informados são registrados como zero";
                }



                //cadastra no banco
                o_Livro.Titulo = txtTitulo.Text;
                o_Livro.Autor = txtAutor.Text;
                o_Livro.Ano = anoVar;
                o_Livro.Edicao = edicaoVar;
                o_Livro.Editora = txtEditora.Text;
                o_Livro.Idioma = txtIdioma.Text;

                o_Livro.inserir();//chamando o método

                lbnMsg.Text = "Livro cadastrado com sucesso!";

                limparCampos();
                obterLivro();//recarregar a tabela, atualiza o GridView

            }
            catch (Exception ex)
            {
                lbnMsg.Text = "Erro: " + ex.Message;
            }
        }

        protected void btnAlterar_Click(object sender, EventArgs e) 
        {
            try
            {
                lbnMsgTable.Text = string.Empty;
                int idlivro;
                String titulo = "";
                String autor = "";
                String editora = "";
                String idioma = "";

                int ano = 0;
                int edicao = 0;

                

                // Valida se esses campos estão preenchidos
                if (txtTitulo.Text.ToString().Trim() == "")//trim tira os espaços
                {
                    lbnMsg.Text = "Por favor informe o título do livro!";
                    txtTitulo.Focus();
                    return;
                }
                else
                {
                    titulo = txtTitulo.Text.ToString();
                }

                if (txtAutor.Text.ToString().Trim() == "")//trim tira os espaços
                {
                    lbnMsg.Text = "Por favor informe o nome do autor!";
                    txtAutor.Focus();
                    return;
                }
                else
                {
                    autor = txtAutor.Text.ToString();
                }

                // Obtem o ID Produto
                idlivro = int.Parse(txtIDLivro.Text.ToString());

                if (txtEdicao.Text.ToString() != "")
                {
                    edicao = int.Parse(txtEdicao.Text.ToString());
                }
                else
                {
                    lbnMsgTable.Text = "*Campos númericos não informados são registrados como zero";
                }

                //Caso não preencha o campo o valor na tabela aparece ZERO
                if (txtAno.Text.ToString() != "")
                {
                    ano = int.Parse(txtAno.Text.ToString());
                }
                else
                {
                    lbnMsgTable.Text = "*Campos númericos não informados são registrados como zero";
                }


                editora = txtEditora.Text.ToString();
                idioma = txtIdioma.Text.ToString(); ;

                Livro o_Livro = new Livro();
                o_Livro.IdLivro = idlivro;
                o_Livro.Titulo = titulo;
                o_Livro.Autor = autor;
                o_Livro.Ano = ano;
                o_Livro.Edicao = edicao;
                o_Livro.Editora = editora;
                o_Livro.Idioma = idioma;
                o_Livro.atualizar();


                limparCampos();
                obterLivro();
            }
            catch (Exception ex)
            {
                lbnMsg.Text = "Erro: " + ex.Message;
            }
        }

        protected void btnLimpar_Click(object sender, EventArgs e)
        {
            limparCampos();
        }


        protected void ImgEditar_Click(object sender, ImageClickEventArgs e)
        {
            try
            {

                int idlivro = Convert.ToInt32((sender as ImageButton).CommandArgument); //recuperar IDprodutpo do gridview

                //Chama o metodo para retornar os dados
                Livro o_Livro = new Livro();
                o_Livro.IdLivro = idlivro;

                DataTable dtLivro;
                dtLivro = o_Livro.obterPorIDLivro();

                txtIDLivro.Text = dtLivro.Rows[0]["idlivro"].ToString();
                txtTitulo.Text = dtLivro.Rows[0]["titulo"].ToString();
                txtAutor.Text = dtLivro.Rows[0]["autor"].ToString();
                txtAno.Text = dtLivro.Rows[0]["ano"].ToString();
                txtEdicao.Text = dtLivro.Rows[0]["edicao"].ToString();
                txtEditora.Text = dtLivro.Rows[0]["editora"].ToString();
                txtIdioma.Text = dtLivro.Rows[0]["idioma"].ToString();
                    
                //Trata o campo para não dar erro no limite min max do input, caso queira apagar/excluir
                if (txtAno.Text == "0")
                {
                    txtAno.Text = "";
                }
                if (txtEdicao.Text == "0")
                {
                    txtEdicao.Text = "";
                }

                // Ajustar os botões
                btnInserir.Enabled = false;
                btnAlterar.Enabled = true;//true

                lbnMsg.Text = string.Empty;
            }
            catch (Exception ex)
            {
                lbnMsg.Text = "Erro: " + ex.Message;
            }
        }

        protected void ImgExcluir_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                // Recupera o IDProduto do Grid View
                int idlivro;
                idlivro = Convert.ToInt32((sender as ImageButton).CommandArgument);

                // Chama o método para retornar os dados do produto
                Livro o_Livro = new Livro();
                o_Livro.IdLivro = idlivro;

                o_Livro.excluir();

                obterLivro();
                limparCampos();
                lbnMsgTable.Text = string.Empty; 
            }
            catch (Exception ex)
            {
                lbnMsg.Text = "Erro: " + ex.Message;
            }
        }

        private void obterLivro()
        {
            try
            {
                Livro o_Livro = new Livro();
                DataTable dtLivro;

                dtLivro = o_Livro.selecionar();


                if (dtLivro != null)
                {
                    if (dtLivro.Rows.Count == 0)
                    {
                        //do your code 
                        o_Livro.resetIndexTable();//função que reseta o index do id, caso tenha zero linhas 
                    }
                }

                gvLivro.DataSource = dtLivro;
                gvLivro.DataBind();

                btnInserir.Enabled = true;
                btnAlterar.Enabled = false;
                btnLimpar.Enabled = true;
            }
            catch (Exception ex)
            {
                lbnMsg.Text = "Erro: " + ex.Message;
            }
        }

        protected void limparCampos()
        {
            txtIDLivro.Text = string.Empty;
            txtTitulo.Text = string.Empty;
            txtAutor.Text = string.Empty;
            txtEditora.Text = string.Empty;
            txtIdioma.Text = string.Empty;
                  
            txtAno.Text = string.Empty;
            txtEdicao.Text = string.Empty;

            lbnMsg.Text = string.Empty;

            btnInserir.Enabled = true;
            btnAlterar.Enabled = false;
            btnLimpar.Enabled = true;
        }

    }
}