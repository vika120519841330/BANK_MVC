using System.ComponentModel.DataAnnotations;
using BANK_MVC_ONION_DI.Validation;
using FluentValidation.Attributes;

namespace BANK_MVC_ONION_DI.Models
{
    [Validator(typeof(ClientModelValidator))]
    public class Client_ViewModel
    {
        [Key]
        //[Required(ErrorMessage = "Идентификатор клиента не установлен")]
        //[Range(1, 1000000, ErrorMessage = "Значение идентификационного номера клиента вышло за допустимые пределы")]
        [Display(Name = "ID клиента:")]
        public int Id { get; set; }

        //[Required(ErrorMessage = "Наименование клиента не установлено")]
        //[MinLength(3, ErrorMessage = "Наименование клиента должно содержать не менее 3 символов")]
        //[MaxLength(50, ErrorMessage = "Наименование клиента должно содержать не более 50 символов")]
        [Display(Name = "Клиент:")]
        public string ClientTitle { get; set; }

        //[Required(ErrorMessage = "Статус клиента не установлен")]
        [Display(Name = "Клиент является юридическим лицом:")]
        public bool ClientMarkJuridical { get; set; }

        //Условная валидация для этого поля прописана в отдельном классе - ClientModelValidator 
        [Display(Name = "УНП / Номер паспорта")]
        public string ClientTaxpayNum { get; set; }

        //[Required(ErrorMessage = "Контактный номер телефона не установлен", AllowEmptyStrings = true)]
        //[RegularExpression(@"^\+(375)-\d{2}-\d{3}-\d{2}-\d{2}$", ErrorMessage = "Номер телефона должен иметь формат (+375)-хx-xxx-xx-xx")]
        [Display(Name = "Номер телефона")]
        public string ClientPhone { get; set; }

        //[Required(ErrorMessage = "Адрес электронной почты не установлен")]
        //[EmailAddress(ErrorMessage = "Введенное значение не соответсвует адресу электронной почты")]
        [Display(Name = "Электронная почта")]
        public string ClientEMail { get; set; }
        
    }
}