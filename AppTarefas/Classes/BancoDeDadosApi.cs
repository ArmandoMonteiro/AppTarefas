using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppTarefas.Classes
{
    public class BancoDeDadosApi
    {
        private readonly SqlConnection conexao;

        public BancoDeDadosApi()
        {
            conexao = new SqlConnection((@"data source = DESKTOP\SQLEXPRESS; Integrated Security = SSPI; Initial Catalog = DbTarefas"));
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

