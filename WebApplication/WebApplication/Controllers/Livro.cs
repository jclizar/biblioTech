using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


using Npgsql;
using System.Data;

public class Livro
{

    //############################### ATRIBTOS ###############################//
    private int idlivro;
    private int ano;
    private int edicao;
    private string autor;
    private string editora;
    private string titulo;
    private string idioma;

    //############################# Propriedades ##############################//
    public int IdLivro { get => idlivro; set => idlivro = value; }
    public int Ano { get => ano; set => ano = value; }
    public int Edicao { get => edicao; set => edicao = value; }

    public string Autor { get => autor; set => autor = value; }
    public string Editora { get => editora; set => editora = value; }
    public string Titulo { get => titulo; set => titulo = value; }
    public string Idioma { get => idioma; set => idioma = value; }


    //############################### MÉTODOS ###############################//

    //Cadastrar
    public void inserir()
    {
        try
        {
            NpgsqlConnection conBanco;
            String strConexao;

            // String de conexão
            strConexao = "Server=localhost;User Id=postgres; Port=5432; " +
                         "Password=admin; Database=biblioteca";

            conBanco = new NpgsqlConnection(strConexao);

            // Comandos SQL
            //-----------------------------------------------------------
            NpgsqlCommand cmdSQL;
            String strComando;



            strComando = "INSERT INTO livro(titulo, autor, ano, edicao, editora, idioma) " +
                         "VALUES(@titulo, @autor, @ano, @edicao, @editora, @idioma)";

            cmdSQL = new NpgsqlCommand(strComando, conBanco);


            NpgsqlParameter o_Parametro = new NpgsqlParameter();
            o_Parametro.ParameterName = "@titulo";
            o_Parametro.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Varchar;
            o_Parametro.Value = titulo;
            o_Parametro.Size = 100;
            cmdSQL.Parameters.Add(o_Parametro);

            o_Parametro = new NpgsqlParameter();
            o_Parametro.ParameterName = "@autor";
            o_Parametro.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Varchar;
            o_Parametro.Value = autor;
            o_Parametro.Size = 100;
            cmdSQL.Parameters.Add(o_Parametro);

            o_Parametro = new NpgsqlParameter();
            o_Parametro.ParameterName = "@ano";
            o_Parametro.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Integer;
            o_Parametro.Value = ano;
            cmdSQL.Parameters.Add(o_Parametro);

            o_Parametro = new NpgsqlParameter();
            o_Parametro.ParameterName = "@edicao";
            o_Parametro.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Integer;
            o_Parametro.Value = edicao;
            cmdSQL.Parameters.Add(o_Parametro);

            o_Parametro = new NpgsqlParameter();
            o_Parametro.ParameterName = "@editora";
            o_Parametro.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Varchar;
            o_Parametro.Value = editora;
            o_Parametro.Size = 100;
            cmdSQL.Parameters.Add(o_Parametro);

            o_Parametro = new NpgsqlParameter();
            o_Parametro.ParameterName = "@idioma";
            o_Parametro.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Varchar;
            o_Parametro.Value = idioma;
            o_Parametro.Size = 100;
            cmdSQL.Parameters.Add(o_Parametro);


            // Operações
            conBanco.Open();

            // Prepare() é obrigatório ser chamada para configurar
            // internamente o comando SQL e os parametros informados.                
            cmdSQL.Prepare();
            cmdSQL.ExecuteNonQuery();

            conBanco.Close();

        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message + "\nLivro.cadastrar");
        }
    }

    //Selecionar
    public DataTable selecionar()
    {
        try
        {
            NpgsqlConnection conBanco;
            String strConexao;
            DataTable dtLivro = new DataTable();

            // String de conexão
            strConexao = "Server=localhost;User Id=postgres; Port=5432; " +
                         "Password=admin; Database=biblioteca";

            conBanco = new NpgsqlConnection(strConexao);


            string strComando;
            strComando = "Select * From livro Order By idlivro";

            NpgsqlDataAdapter daPesquisa;
            daPesquisa = new NpgsqlDataAdapter(strComando, conBanco);


            //-----------------------------------------------------------
            // Executando as operações
            //-----------------------------------------------------------
            conBanco.Open();

            daPesquisa.Fill(dtLivro);

            conBanco.Close();

            return dtLivro;


        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message + "\nLivro.selecionar");
        }
    }

    public DataTable obterPorIDLivro()
    {
        try
        {
            NpgsqlConnection conBanco;
            String strConexao;
            DataTable dtLivro = new DataTable();

            // String de conexão
            strConexao = "Server=localhost;User Id=postgres; Port=5432; " +
                         "Password=admin; Database=biblioteca";

            conBanco = new NpgsqlConnection(strConexao);


            // Preparando o comando SQL
            string strComando;
            strComando = "Select * From livro Where idlivro = @idlivro";

            NpgsqlDataAdapter daPesquisa;
            daPesquisa = new NpgsqlDataAdapter(strComando, conBanco);

            NpgsqlParameter o_Parametro;
            o_Parametro = new NpgsqlParameter();
            o_Parametro.ParameterName = "@idlivro";
            o_Parametro.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Integer;
            o_Parametro.Value = idlivro;

            daPesquisa.SelectCommand.Parameters.Add(o_Parametro);


            // Executando as operações
            conBanco.Open();

            daPesquisa.Fill(dtLivro);

            conBanco.Close();

            return dtLivro;

        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message + "\nLivro.obterPorIDLivro");
        }
    }
    public void atualizar()
    {
        try
        {
            NpgsqlConnection conBanco;
            String strConexao;

            //-----------------------------------------------------------
            //  Preparando conexão com o banco de dados
            //-----------------------------------------------------------
            // String de conexão
            strConexao = "Server=localhost;User Id=postgres; Port=5432; " +
                         "Password=admin; Database=biblioteca";

            conBanco = new NpgsqlConnection(strConexao);


            //-----------------------------------------------------------
            // Preparando o comando SQL
            //-----------------------------------------------------------
            NpgsqlCommand cmdSQL;
            String strComando;

            //strComando = "INSERT INTO produto(nome, preco, qtdestoque) " +
            //             "VALUES('Pão', 3.5, 100)";                       

            //strComando = "INSERT INTO produto(nome,preco,qtdestoque) " + $"VALUES('{nome}', {preco}, {qtdEstoque})";


            strComando = "UPDATE livro SET titulo = @titulo, autor = @autor, ano = @ano, edicao = @edicao,  " +
                         "editora = @editora, idioma = @idioma where idlivro = @idlivro";


            cmdSQL = new NpgsqlCommand(strComando, conBanco);

            NpgsqlParameter o_Parametro = new NpgsqlParameter();
            o_Parametro.ParameterName = "@titulo";
            o_Parametro.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Varchar;
            o_Parametro.Value = titulo;
            o_Parametro.Size = 100;
            cmdSQL.Parameters.Add(o_Parametro);

            o_Parametro = new NpgsqlParameter();
            o_Parametro.ParameterName = "@autor";
            o_Parametro.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Varchar;
            o_Parametro.Value = autor;
            o_Parametro.Size = 100;
            cmdSQL.Parameters.Add(o_Parametro);

            o_Parametro = new NpgsqlParameter();
            o_Parametro.ParameterName = "@ano";
            o_Parametro.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Integer;
            o_Parametro.Value = ano;
            cmdSQL.Parameters.Add(o_Parametro);

            o_Parametro = new NpgsqlParameter();
            o_Parametro.ParameterName = "@edicao";
            o_Parametro.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Integer;
            o_Parametro.Value = edicao;
            cmdSQL.Parameters.Add(o_Parametro);

            o_Parametro = new NpgsqlParameter();
            o_Parametro.ParameterName = "@editora";
            o_Parametro.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Varchar;
            o_Parametro.Value = editora;
            o_Parametro.Size = 100;
            cmdSQL.Parameters.Add(o_Parametro);

            o_Parametro = new NpgsqlParameter();
            o_Parametro.ParameterName = "@idioma";
            o_Parametro.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Varchar;
            o_Parametro.Value = idioma;
            o_Parametro.Size = 100;
            cmdSQL.Parameters.Add(o_Parametro);

            o_Parametro = new NpgsqlParameter();
            o_Parametro.ParameterName = "@idlivro";
            o_Parametro.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Integer;
            o_Parametro.Value = idlivro;
            cmdSQL.Parameters.Add(o_Parametro);


            // Executando as operações
            conBanco.Open();

            // Prepare() é obrigatório ser chamada para configurar
            // internamente o comando SQL e os parametros informados.                
            cmdSQL.Prepare();
            cmdSQL.ExecuteNonQuery();

            conBanco.Close();

        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message + "\nLivro.atualizar");
        }
    }
    public void excluir()
    {
        try
        {
            NpgsqlConnection conBanco;
            String strConexao;

            //-----------------------------------------------------------
            //  Preparando conexão com o banco de dados
            //-----------------------------------------------------------
            // String de conexão
            strConexao = "Server=localhost;User Id=postgres; Port=5432; " +
                         "Password=admin; Database=biblioteca";

            conBanco = new NpgsqlConnection(strConexao);


            //-----------------------------------------------------------
            // Preparando o comando SQL
            //-----------------------------------------------------------
            NpgsqlCommand cmdSQL;
            String strComando;

            strComando = "Delete From livro where idlivro = @idlivro";

            cmdSQL = new NpgsqlCommand(strComando, conBanco);

            NpgsqlParameter o_Parametro;
            o_Parametro = new NpgsqlParameter();
            o_Parametro.ParameterName = "@idlivro";
            o_Parametro.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Integer;
            o_Parametro.Value = idlivro;
            cmdSQL.Parameters.Add(o_Parametro);


            //-----------------------------------------------------------
            // Executando as operações
            //-----------------------------------------------------------
            conBanco.Open();

            // Prepare() é obrigatório ser chamada para configurar
            // internamente o comando SQL e os parametros informados.                
            //cmdSQL.Prepare();
            cmdSQL.ExecuteNonQuery();

            conBanco.Close();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message + "\nLivro.excluir");
        }
    }
    public void resetIndexTable()
    {
        try
        {
            NpgsqlConnection conBanco;
            String strConexao;

            //-----------------------------------------------------------
            //  Preparando conexão com o banco de dados
            //-----------------------------------------------------------
            // String de conexão
            strConexao = "Server=localhost;User Id=postgres; Port=5432; " +
                         "Password=admin; Database=biblioteca";

            conBanco = new NpgsqlConnection(strConexao);


            //-----------------------------------------------------------
            // Preparando o comando SQL
            //-----------------------------------------------------------
            NpgsqlCommand cmdSQL;
            String strComando;

            strComando = "ALTER SEQUENCE livro_idlivro_seq RESTART WITH 1";


            cmdSQL = new NpgsqlCommand(strComando, conBanco);

            // Executando as operações
            conBanco.Open();
            // Prepare() é obrigatório ser chamada para configurar
            // internamente o comando SQL e os parametros informados.                
            cmdSQL.Prepare();
            cmdSQL.ExecuteNonQuery();
            conBanco.Close();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message + "\nLivro.resetIndexTable");
        }
    }

}