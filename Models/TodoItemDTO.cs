using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
namespace TodoApi.Models 
{

    public class TodoItemDTO
    {
        public long Id { get; set; }
        public string Name { get; set; }

        [EmailAddress]
        [Required]
        public string Email { get; set; }

        [RegularExpression("^((?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])|(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[^a-zA-Z0-9])|(?=.*?[A-Z])(?=.*?[0-9])(?=.*?[^a-zA-Z0-9])|(?=.*?[a-z])(?=.*?[0-9])(?=.*?[^a-zA-Z0-9])).{8,}$", ErrorMessage = "La password deve essere almeno di 8 caratteri e contenere  3 di 4 delle richieste seguenti: lettere maiuscole (A-Z), lettere minuscole (a-z), numeri (0-9) e caratteri speciali (e.g. !@#$%^&*)")]
        [Required]
        public string Password { get; set; }
        [DefaultValue(false)]
        public bool IsComplete { get; set; }

        public Child child { get; set; }
    }

    public class Child
    {   
        
        public string ChildName { get; set; }

        [Required]
        [MinLength(1, ErrorMessage = "l'array deve contenere almeno un dato")]
        public IEnumerable<int> ArrayOb { get; set; }


        public IEnumerable<int> optionalArray { get; set; }

    }
}