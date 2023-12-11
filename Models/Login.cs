namespace WebApplication1.Models
{
    public class Login
    {
        public int Id { get; set; }
        public string Usuario { get; set; }
        public string Senha { get; set; }
        public string TipoUsuario { get; set; }

        public Login()
        {
            this.Id = 0;
            this.Usuario = "";
            this.Senha = string.Empty;
            this.TipoUsuario = string.Empty;
        }
    }
}