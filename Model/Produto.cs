using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Model
{
    public class Produto
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string ProdutoId { get; set;}
        public string Nome { get; set;}
        public int Preço { get; set;}
        public string Acompanhamento { get; set;}

    }
}