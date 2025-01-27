namespace CoffeeBeanLib;
public class CoffeeBeanAlt
{
    private string? _name;
    private string? _beanType;
    private int _roasting;
    private double _price;

    public int Id { get; set; }

    public string? Name
    {
        get => _name;
        set
        {
            if (string.IsNullOrWhiteSpace(value) || value.Length < 2)
                throw new ArgumentException("Name must be at least 2 characters long.");
            _name = value;
        }
    }

    public string? BeanType
    {
        get => _beanType;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                _beanType = string.Empty;
            _beanType = value;
        }
        //set
        //{
        //    if (string.IsNullOrWhiteSpace(value))
        //        throw new ArgumentException("BeanType cannot be empty.");
        //    _beanType = value;
        //}
    }

    public int Roasting
    {
        get => _roasting;
        set
        {
            if (value < 1 || value > 9)
                throw new ArgumentException("Roasting must be between 1 and 9.");
            _roasting = value;
        }
    }

    public double Price
    {
        get => _price;
        set
        {
            if (value <= 0)
                throw new ArgumentException("Price must be a positive value.");
            _price = value;
        }
    }

    public override string ToString()
    {
        return $"Id: {Id}, Name: {Name}, BeanType: {BeanType}, Roasting: {Roasting}, Price: {Price}";
    }
}