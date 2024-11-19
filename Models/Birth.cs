namespace Project.Models;

public class Birth
{
    public string? imie { get; set; }
    public DateTime? birth_date { get; set; }
    public string ErrorMessage { get; set; }

    public bool IsValid()
    {
        if (imie is null)
        {
            ErrorMessage = "Podaj imie";
            return false;
        }
        if (birth_date is null)
        {
            ErrorMessage = "Podaj date urodzenia";
            return false;
        }
        if (birth_date > DateTime.Now)
        {
            ErrorMessage = "Nieprawidłowa data! Prosze podać prawidłową datę";
            return false;
        }
        
        return true;
    }

    public int Birth_calc()
    {
        return DateTime.Now.Year - birth_date.Value.Year;
    }
}