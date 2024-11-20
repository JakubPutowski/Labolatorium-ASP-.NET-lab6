using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Project.Models;

public class ContactModel
{
    [HiddenInput]
    public int Id { get; set; }
    
    [Required(ErrorMessage = "Musisz wpisać imie!")]
    [MaxLength(length:20, ErrorMessage = "Imie zbyt długie")]
    [Display(Name = "Imie")]
    public string FirstName { get; set; }
    
    [Required(ErrorMessage = "Musisz wpisać nazwisko!")]
    [MaxLength(length:50, ErrorMessage = "Nazwisko zbyt długie")]
    [Display(Name = "Nazwisko")]
    public string LastName { get; set; }
    
    [EmailAddress(ErrorMessage = "Niepoprawny format adresu email!")]
    [Display(Name = "Mail")]
    public string Email { get; set; }
    
    [Phone(ErrorMessage = "Wpisz poprawny numer telefonu")]
    [RegularExpression("\\d\\d\\d \\d\\d\\d \\d\\d\\d", ErrorMessage = "Wpisz numer w formacie XXX XXX XXX!")]
    [Display(Name = "Numer telefonu")]
    public string PhoneNumber { get; set; }
    
    [Display(Name = "Data urodzenia")]
    [DataType(DataType.Date)]
    public DateTime BirthDate { get; set; }
    [Display(Name = "Kategoria")]
    public  Category Category { get; set; }
}