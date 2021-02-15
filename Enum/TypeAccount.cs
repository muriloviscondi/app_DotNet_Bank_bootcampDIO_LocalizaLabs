using System.ComponentModel.DataAnnotations;

namespace app_DotNet_Bank_bootcampDIO_LocalizaLabs
{
  public enum TypeAccount
  {
    [Display(Name = "Pessoa Física")]
    NaturalPerson = 1,

    [Display(Name = "Pessoa Jurídica")]
    LegalPerson = 2,
  }
}