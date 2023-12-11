using Microsoft.Data.SqlClient;

namespace WebApplication1.Repositories.ADO.SQL_SERVER
{
    public class Cachorro
    {
        public Cachorro() { }
        public void add(Models.Cachorros cachorro) 
        {
            string connectionString = Configuration.getConnectionString();

            using(SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using(SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "INSERT INTO Cachorros (nome, raca, genero, ano_nascimento, pedigree, cor, porte, descricao, foto, foto1,foto2,foto3) VALUES (@nome, @raca, @genero, @ano_nascimento, @pedigree, @cor, @porte, @descricao, @foto, @foto1,@foto2,@foto3)";

                    command.Parameters.Add(new SqlParameter("@nome", System.Data.SqlDbType.VarChar)).Value = cachorro.nome;
                    command.Parameters.Add(new SqlParameter("@raca", System.Data.SqlDbType.VarChar)).Value = cachorro.raca;
                    command.Parameters.Add(new SqlParameter("@genero", System.Data.SqlDbType.VarChar)).Value = cachorro.genero;
                    command.Parameters.Add(new SqlParameter("@ano_nascimento", System.Data.SqlDbType.Int)).Value = cachorro.ano_nascimento;
                    command.Parameters.Add(new SqlParameter("@pedigree", System.Data.SqlDbType.VarChar)).Value = cachorro.pedigree;
                    command.Parameters.Add(new SqlParameter("@cor", System.Data.SqlDbType.VarChar)).Value = cachorro.cor;
                    command.Parameters.Add(new SqlParameter("@porte", System.Data.SqlDbType.VarChar)).Value = cachorro.porte;
                    command.Parameters.Add(new SqlParameter("@descricao", System.Data.SqlDbType.VarChar)).Value = cachorro.descrição;
                    command.Parameters.Add(new SqlParameter("@foto", System.Data.SqlDbType.VarChar)).Value = cachorro.foto;
                    command.Parameters.Add(new SqlParameter("@foto1", System.Data.SqlDbType.VarChar)).Value = cachorro.foto1;
                    command.Parameters.Add(new SqlParameter("@foto2", System.Data.SqlDbType.VarChar)).Value = cachorro.foto2;
                    command.Parameters.Add(new SqlParameter("@foto3", System.Data.SqlDbType.VarChar)).Value = cachorro.foto3;


                    command.ExecuteNonQuery();
                }
            }
        }
        public List<Models.Cachorros> get()
        {
            List<Models.Cachorros> cachorros = new List<Models.Cachorros>();

            string connectionString = Configuration.getConnectionString();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT * FROM Cachorros";

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Models.Cachorros cachorro = new Models.Cachorros();
                        cachorro.id = (int)reader["id"];
                        cachorro.nome = (string)reader["nome"];
                        cachorro.raca = (string)reader["raca"];
                        cachorro.genero = (string)reader["genero"];
                        cachorro.ano_nascimento = (int)reader["ano_nascimento"];
                        cachorro.pedigree = (string)reader["pedigree"];
                        cachorro.cor = (string)reader["cor"];
                        cachorro.porte = (string)reader["porte"];
                        cachorro.descrição = (string)reader["descricao"];
                        cachorro.foto = (string)reader["foto"];
                        cachorro.foto1 = (string)reader["foto1"];
                        cachorro.foto2 = (string)reader["foto2"];
                        cachorro.foto3 = (string)reader["foto3"];


                        cachorros.Add(cachorro);
                    }
                }   
            }
            return cachorros;
        }
        public void delete(int id)
        {
            {
                string connectionString = Configuration.getConnectionString();

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = "DELETE FROM Cachorros WHERE id = @id";

                        command.Parameters.Add(new SqlParameter("@id", System.Data.SqlDbType.Int)).Value = id;

                        command.ExecuteNonQuery();
                    }
                }
            }
        }
        public Models.Cachorros getEdit(int id)
        {
            Models.Cachorros cachorro = new Models.Cachorros();

            string connectionString = Configuration.getConnectionString();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT * FROM Cachorros WHERE id = @id";

                    command.Parameters.Add(new SqlParameter("@id", System.Data.SqlDbType.Int)).Value = id;

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        cachorro.id = (int)reader["id"];
                        cachorro.nome = (string)reader["nome"];
                        cachorro.raca = (string)reader["raca"];
                        cachorro.genero = (string)reader["genero"];
                        cachorro.ano_nascimento = (int)reader["ano_nascimento"];
                        cachorro.pedigree = (string)reader["pedigree"];
                        cachorro.cor = (string)reader["cor"];
                        cachorro.porte = (string)reader["porte"];
                        cachorro.descrição = (string)reader["descricao"];
                        cachorro.foto = (string)reader["foto"];
                        cachorro.foto1 = (string)reader["foto1"];
                        cachorro.foto2 = (string)reader["foto2"];
                        cachorro.foto3 = (string)reader["foto3"];

                    }
                }
            }
            return cachorro;
        }
        public void edit(int id, Models.Cachorros cachorro)
        {
            {
                string connectionString = Configuration.getConnectionString();

                using(SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using(SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = "UPDATE Cachorros SET nome = @nome, raca = @raca, genero = @genero, ano_nascimento = @ano_nascimento, pedigree = @pedigree, cor = @cor, porte = @porte, descricao = @descricao, foto = @foto, foto1 = @foto1, foto2 = @foto2, foto3 = @foto3 WHERE id = @id";

                        command.Parameters.Add(new SqlParameter("@id", System.Data.SqlDbType.Int)).Value = id;
                        command.Parameters.Add(new SqlParameter("@nome", System.Data.SqlDbType.VarChar)).Value = cachorro.nome;
                        command.Parameters.Add(new SqlParameter("@raca", System.Data.SqlDbType.VarChar)).Value = cachorro.raca;
                        command.Parameters.Add(new SqlParameter("@genero", System.Data.SqlDbType.VarChar)).Value = cachorro.genero;
                        command.Parameters.Add(new SqlParameter("@ano_nascimento", System.Data.SqlDbType.Int)).Value = cachorro.ano_nascimento;
                        command.Parameters.Add(new SqlParameter("@pedigree", System.Data.SqlDbType.VarChar)).Value = cachorro.pedigree;
                        command.Parameters.Add(new SqlParameter("@cor", System.Data.SqlDbType.VarChar)).Value = cachorro.cor;
                        command.Parameters.Add(new SqlParameter("@porte", System.Data.SqlDbType.VarChar)).Value = cachorro.porte;
                        command.Parameters.Add(new SqlParameter("@descricao", System.Data.SqlDbType.VarChar)).Value = cachorro.descrição;
                        command.Parameters.Add(new SqlParameter("@foto", System.Data.SqlDbType.VarChar)).Value = cachorro.foto;
                        command.Parameters.Add(new SqlParameter("@foto1", System.Data.SqlDbType.VarChar)).Value = cachorro.foto1;
                        command.Parameters.Add(new SqlParameter("@foto2", System.Data.SqlDbType.VarChar)).Value = cachorro.foto2;
                        command.Parameters.Add(new SqlParameter("@foto3", System.Data.SqlDbType.VarChar)).Value = cachorro.foto3;

                        command.ExecuteNonQuery();
                    }
                }
            }
        }
        public Models.Cachorros getDetails(int id)
        {
            Models.Cachorros cachorro = new Models.Cachorros();

            string connectionString = Configuration.getConnectionString();
            using(SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using(SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT * FROM Cachorros WHERE id = @id";

                    command.Parameters.Add(new SqlParameter("@id", System.Data.SqlDbType.Int)).Value = id;

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        cachorro.id = (int)reader["id"];
                        cachorro.nome = (string)reader["nome"];
                        cachorro.raca = (string)reader["raca"];
                        cachorro.genero = (string)reader["genero"];
                        cachorro.ano_nascimento = (int)reader["ano_nascimento"];
                        cachorro.pedigree = (string)reader["pedigree"];
                        cachorro.cor = (string)reader["cor"];
                        cachorro.porte = (string)reader["porte"];
                        cachorro.descrição = (string)reader["descricao"];
                        cachorro.foto = (string)reader["foto"];
                        cachorro.foto1 = (string)reader["foto1"];
                        cachorro.foto2 = (string)reader["foto2"];
                        cachorro.foto3 = (string)reader["foto3"];

                    }
                }
            }
            return cachorro;
        }
    }
}
