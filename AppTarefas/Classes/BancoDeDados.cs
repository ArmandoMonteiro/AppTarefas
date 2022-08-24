using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AppTarefas.Classes
{
    public class BancoDeDados
    {
        private readonly SqlConnection conexao;

        public BancoDeDadosApi()
        {


            //string ConexaoWebCep = "Server=tcp:playgamenet.database.windows.net,1433;Initial Catalog=DbPlayGameCep11;Persist Security Info=False;User ID=JimeTurner;Password=Jt130795;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30";
            string ConexaoLocal = @"data source = DESKTOP\SQLEXPRESS; Integrated Security = SSPI; Initial Catalog = DbPlayGameCep1.1";

            conexao = new SqlConnection(ConexaoLocal);
            conexao.Open();

        }

        public void ExecutaComando(string Sql)
        {
            try
            {
                var cmd = new SqlCommand
                {
                    CommandText = Sql,
                    CommandType = System.Data.CommandType.Text,
                    Connection = conexao
                };

                cmd.ExecuteNonQuery();

            }
            catch (Exception)
            {
                throw;
            }

        }

        public SqlDataReader ExecutaComRetorno(string sql)
        {
            var cmdComandoSelec = new SqlCommand(sql, conexao);
            return cmdComandoSelec.ExecuteReader();
        }

        public int ExecutaComScalar(string sql)
        {
            try
            {
                var cmdComandoSelec = new SqlCommand(sql, conexao);

                int resulte = (int)cmdComandoSelec.ExecuteScalar();

                return resulte;
            }
            catch (Exception)
            {
                throw;
            }

        }

        public void Dispose()
        {
            if (conexao.State == System.Data.ConnectionState.Open)
                conexao.Close();
        }
    }
}
}