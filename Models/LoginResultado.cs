namespace WebApplication1.Models
{
    public class LoginResultado
    {
        public bool Sucesso { get; set; }
        public int Id { get; set; }
        public string TipoUsuario { get; set; }

        // public int QuantidadeItensCarrinho { get; set; }

        public LoginResultado()
        {            
            Id = 0;
            TipoUsuario = "";
        }
    }
}
