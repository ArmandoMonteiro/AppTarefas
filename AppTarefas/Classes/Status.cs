using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AppTarefas.Classes
{
    public class Status
    {
        public int IdStatus { get; set; }
        public string DescStatus { get; set; }


        public List<Status> ListarStatus()
        {
            List<Status> ListaStatus = new List<Status>();

            BancoDeDadosApi objConexaoDB = new BancoDeDadosApi();

            string Sql = "Select IdStatus,DescStatus From TbStatus";

            SqlDataReader reader = objConexaoDB.ExecutaComRetorno(Sql);

            while (reader.Read())
            {
                Status objStatus = new Status();

                objStatus.IdStatus = int.Parse(reader["IdStatus"].ToString());
                objStatus.DescStatus = reader["DescStatus"].ToString();

                ListaStatus.Add(objStatus);
            }

            objConexaoDB.Dispose();
            return ListaStatus;
        }
        
    }
}