public enum Operators
{
    Unknown, Add, Mul, Sub, Div,
}
public class Calculator
{
    public Operators? op { get; set; }
    public double? A { get; set; }
    public double? B { get; set; }
    public string ErrorMessage;
    public String Op
    {
        get
        {
            switch (op)
            {
                case Operators.Add:
                    return "+";
                case Operators.Sub:
                    return "-";
                case Operators.Mul:
                    return "*";
                case Operators.Div:
                    return "/";
                default:
                    return "";
            }
        }
    }

    public bool IsValid()
    {
        if (A is null)
        {
            ErrorMessage = "Podaj parametr a";
            return false;
        }
        if (B is null)
        {
            ErrorMessage = "Podaj parametr b";
            return false;
        }
        if (op is null)
        {
            ErrorMessage = "Podaj operator";
            return false;
        }

        return true;
    }

    public double Calculate() {
        switch (op)
        {
            case Operators.Add:
                return (double) (A + B);
            case Operators.Sub:
                return (double) (A - B);
            case Operators.Mul:
                return (double) (A * B);
            case Operators.Div:
                if (B!= 0)
                {
                    return (double)(A / B);
                }
                else
                {
                    return double.NaN;
                }
            default: return double.NaN;
        }
    }
}