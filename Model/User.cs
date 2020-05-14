using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    public class User
    {
        public enum RegraEnum {admin, user};
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string UserId { get; set;}
        public string Nome {get; set;}
        public string Senha { get; set;}
        public string Regra { get; set;}
    }
}