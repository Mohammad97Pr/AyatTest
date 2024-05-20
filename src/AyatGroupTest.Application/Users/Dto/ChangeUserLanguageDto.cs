using System.ComponentModel.DataAnnotations;

namespace AyatGroupTest.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}