using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Routing;
using System.Drawing;
using System.Runtime.ConstrainedExecution;

namespace WebApplication1.Models
{
    public class Cachorros
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string genero { get; set; }
        public int ano_nascimento { get; set; }
        public string pedigree { get; set; }
        public string cor { get; set; }
        public string porte { get; set; }
        public string descrição { get; set; }
        public string foto { get; set; }
        public string foto1 { get; set; }
        public string foto2 { get; set; }
        public string foto3 { get; set; }

        public string raca { get; set; }

        public Cachorros()
        {
            this.id = 0;
            this.nome = string.Empty;
            this.genero = string.Empty;
            this.ano_nascimento = 0;
            this.pedigree = string.Empty;
            this.cor = string.Empty;
            this.porte = string.Empty;
            this.descrição = string.Empty;
            this.foto = string.Empty;
            this.foto1 = string.Empty;
            this.foto2 = string.Empty;
            this.foto3 = string.Empty;
            this.raca = string.Empty;
        }
        
    }
}
