using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;



namespace AppTarefas.Classes
{
    public class Tarefa
    {
        public int IdTarefa { get; set; }
        public string DescTarefa { get; set; }
        public int IdStatus { get; set; }
        public string DescStatus { get; set; }

        public void CriarTarefa(Tarefa objTarefa)
        {
            

            BancoDeDadosApi objConexaoDB = new BancoDeDadosApi();

            string Sql = "Insert Into TbTarefas (DescTarefa,IdStatus) values ('" + objTarefa.DescTarefa + "',1)";

            objConexaoDB.ExecutaComando(Sql);
            objConexaoDB.Dispose();
        }

        public List<Tarefa> ListarTarefas()
        {
            List<Tarefa> ListaTarefas = new List<Tarefa>();

            BancoDeDadosApi objConexaoDB = new BancoDeDadosApi();

            string Sql = "Select IdTarefa,DescTarefa,DescStatus "
                + "From TbTarefas, TbStatus "
                + "Where TbTarefas.IdStatus = TbStatus.IdStatus";

            SqlDataReader reader = objConexaoDB.ExecutaComRetorno(Sql);

            while (reader.Read())
            {
                Tarefa objTarefa = new Tarefa();

                objTarefa.IdTarefa = int.Parse(reader["IdTarefa"].ToString());
                objTarefa.DescTarefa = reader["DescTarefa"].ToString();
                objTarefa.DescStatus = reader["DescStatus"].ToString();

                ListaTarefas.Add(objTarefa);
            }

            objConexaoDB.Dispose();
            return ListaTarefas;
        }

        public Tarefa BuscarTarefa(int IdTarefa)
        {
            
            BancoDeDadosApi objConexaoDB = new BancoDeDadosApi();

            string Sql = "Select IdTarefa,DescTarefa "
                + "From TbTarefas "
                + "Where TbTarefas.Idtarefa = " + IdTarefa;

            SqlDataReader reader = objConexaoDB.ExecutaComRetorno(Sql);

            Tarefa objTarefa = new Tarefa();
            while (reader.Read())
            {
                objTarefa.IdTarefa = int.Parse(reader["IdTarefa"].ToString());
                objTarefa.DescTarefa = reader["DescTarefa"].ToString();
            }

            objConexaoDB.Dispose();
            return objTarefa;
        }

        public void ApagarTarefa(int IdTarefa)
        {
            BancoDeDadosApi objConexaoDB = new BancoDeDadosApi();

            string Sql = "Delete From TbTarefas Where IdTarefa = " + IdTarefa;

            objConexaoDB.ExecutaComando(Sql);
            objConexaoDB.Dispose();
        }

        public void AlterarTarefa(int IdTarefa, int IdStatus)
        {
            BancoDeDadosApi objConexaoDB = new BancoDeDadosApi();

            string Sql = "Update TbTarefas Set IdStatus = " + IdStatus + " Where IdTarefa = " + IdTarefa;

            objConexaoDB.ExecutaComando(Sql);
            objConexaoDB.Dispose();
        }
    }
}