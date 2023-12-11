using Microsoft.Data.SqlClient;
using WebApplication1.Models;

namespace WebApplication1.Repositories.ADO.SQLServer
{
    public class LoginDao
    {
        private readonly string connectionString;

        public LoginDao(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public bool check(Login login) 
        {
            bool result = false;

            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                // Abrir conexão do banco de dados: CarroDB
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "select id from login where usuario=@usuario and senha=@senha";
                    command.Parameters.Add(new SqlParameter("@usuario", System.Data.SqlDbType.VarChar)).Value = login.Usuario;
                    command.Parameters.Add(new SqlParameter("@senha", System.Data.SqlDbType.VarChar)).Value = login.Senha;

                    SqlDataReader dr = command.ExecuteReader();
                    result = dr.Read();
                }
            }
            
            return result;
        }

        public LoginResultado getTipo(Login login)
        {
            LoginResultado result = new LoginResultado();

            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                // Abrir conexão do banco de dados: CarroDB
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "select id, tipo from login where usuario=@usuario and senha=@senha";
                    command.Parameters.Add(new SqlParameter("@usuario", System.Data.SqlDbType.VarChar)).Value = login.Usuario;
                    command.Parameters.Add(new SqlParameter("@senha", System.Data.SqlDbType.VarChar)).Value = login.Senha;

                    using (SqlDataReader dr = command.ExecuteReader())
                    { 
                        result.Sucesso = dr.Read();

                        if (result.Sucesso)
                        {
                            result.Id = (int)dr["id"];
                            result.TipoUsuario = dr["tipo"].ToString();


                            login.Id = result.Id;
                            login.TipoUsuario = result.TipoUsuario;
                        }                    
                    }                   
                    
                }
                //...executar códigos dentro da sessão durante o login do usuário efetuado com sucesso.
            }
            return result;


        }
        public void add(Models.Login login)
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SET IDENTITY_INSERT login ON insert into login (tipo,usuario,senha) values (@tipo,@usuario,@senha) SET IDENTITY_INSERT login OFF";
                    command.Parameters.Add(new SqlParameter("@tipo", System.Data.SqlDbType.VarChar)).Value = login.TipoUsuario;
                    command.Parameters.Add(new SqlParameter("@usuario", System.Data.SqlDbType.VarChar)).Value = login.Usuario;
                    command.Parameters.Add(new SqlParameter("@senha", System.Data.SqlDbType.Char)).Value = login.Senha;


                    command.ExecuteNonQuery();
                }
            }
        }

    }
}
