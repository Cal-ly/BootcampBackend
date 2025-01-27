namespace CoffeeBeanLib;
public class CoffeeBean
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string BeanType { get; set; } = string.Empty;
    public int Roasting { get; set; }
    public double Price { get; set; }

    public void Validate()
    {
        ValidateName();
        ValidateRoasting();
        ValidatePrice();
    }

    public void ValidateName()
    {
        if (string.IsNullOrWhiteSpace(Name) || Name.Length < 2)
            throw new ArgumentException("Name must be at least 2 characters long.");
    }

    public void ValidateRoasting()
    {
        if (Roasting < 1 || Roasting > 9)
            throw new ArgumentException("Roasting must be between 1 and 9.");
    }

    public void ValidatePrice()
    {
        if (Price <= 0)
            throw new ArgumentException("Price must be a positive value.");
    }

    public override string ToString()
    {
        return $"Id: {Id}, Name: {Name}, BeanType: {BeanType}, Roasting: {Roasting}, Price: {Price}";
    }
}