using System.ComponentModel.DataAnnotations;

namespace DentistCalendar.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Kullanıcı adı boş geçilemez.")]
        [Display(Name="Kullanıcı Adınız: ")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Ad boş geçilemez.")]
        [Display(Name = "Adınız: ")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Soyad boş geçilemez.")]
        [Display(Name = "Soyadınız: ")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Parola boş geçilemez.")]
        [Display(Name = "Parolanız: ")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Email boş geçilemez.")]
        [Display(Name = "Emailiniz: ")]
        [EmailAddress(ErrorMessage = "Lütfen email bilginizi kontrol ediniz.")]
        public string Email { get; set; }

        [Display(Name = "Randevu Rengi: ")]
        public string Color { get; set; }

        [Display(Name = "Doktorum ")]
        public bool IsDentist { get; set; }
    }
}
