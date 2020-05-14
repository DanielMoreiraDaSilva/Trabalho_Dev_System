using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    public class Franquia
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string FranquiaId { get; set;}
        public string Nome { get; set;}
        public string Cidade { get; set;}
        public string Bairro { get; set;}
        public string HorarioDeAbertura { get; set;}
        public string HorarioDeFechamento { get; set;}
    }
}