namespace CoffeeBeanLib;
public class CoffeeBeanRepository
{
    private readonly List<CoffeeBean> _coffeeBeans;
    private int _nextId;

    public CoffeeBeanRepository()
    {
        _coffeeBeans = [];
        _nextId = 1;

        Add(new CoffeeBean { Name = "MediumArabicDream", BeanType = "Arabica", Roasting = 6, Price = 90.0 });
        Add(new CoffeeBean { Name = "DarkArabicDream", BeanType = "Arabica", Roasting = 9, Price = 75.0 });
        Add(new CoffeeBean { Name = "LightArabicDream", BeanType = "Arabica", Roasting = 4, Price = 65.0 });
        Add(new CoffeeBean { Name = "MediumRobustaDream", BeanType = "Robusta", Roasting = 7, Price = 85.0 });
        Add(new CoffeeBean { Name = "MediumBlendedDream", BeanType = "Arabica/Liberica", Roasting = 7, Price = 75.0 });
    }

    /// <summary>
    /// Retrieves all CoffeeBeans.
    /// </summary>
    /// <param> There is no input parameter </param>
    /// <returns> A list of CoffeeBeans </returns>
    /// <remarks> Here we see the returntype is a List of objects (CoffeeBeans). In the code block we see the keyword 'return' and it returns the variable _coffeeBean </remarks>
    public List<CoffeeBean> GetAll()
    {
        return _coffeeBeans;
    }

    /// <summary>
    /// Retrieves a CoffeeBean by its Id.
    /// </summary>
    /// <param name="id">The Id of the CoffeeBean.</param>
    /// <returns>The CoffeeBean object.</returns>
    /// <exception cref="ArgumentException">Thrown when no CoffeeBean is found with the given Id.</exception>
    /// <remarks> Uses the null-coalescing operator (??) to throw an exception if no CoffeeBean is found with the given Id. </remarks>
    public CoffeeBean GetById(int id)
    {
        return _coffeeBeans.FirstOrDefault(cb => cb.Id == id) ?? throw new ArgumentException("No CoffeeBean with such Id");
    }

    public CoffeeBean? GetById2(int id)
    {
        foreach(CoffeeBean? coffeeBean in _coffeeBeans)
        {
            if (coffeeBean.Id == id)
            {
                return coffeeBean;
            }
        }
        return null;
    }

    public CoffeeBean? GetById3(int id) // Probably the solution the teachers want to see
    {
        return _coffeeBeans.FirstOrDefault(cb => cb.Id == id);
    }

    public void Add(CoffeeBean coffeeBean)
    {
        try
        {
            coffeeBean.ValidateName();
            coffeeBean.ValidateRoasting();
            coffeeBean.ValidatePrice();

            coffeeBean.Id = _nextId++;
            _coffeeBeans.Add(coffeeBean);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Error adding CoffeeBean: {ex.Message}");
        }
    }

    public void Update(int id, CoffeeBean coffeeBean)
    {
        try
        {
            coffeeBean.ValidateName();
            coffeeBean.ValidateRoasting();
            coffeeBean.ValidatePrice();

            var existingCoffeeBean = GetById(id);
            if (existingCoffeeBean != null)
            {
                existingCoffeeBean.Name = coffeeBean.Name;
                existingCoffeeBean.BeanType = coffeeBean.BeanType;
                existingCoffeeBean.Roasting = coffeeBean.Roasting;
                existingCoffeeBean.Price = coffeeBean.Price;
            }
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Error updating CoffeeBean: {ex.Message}");
        }
    }

    public void Remove(int id)
    {
        var coffeeBean = GetById(id);
        if (coffeeBean != null)
        {
            _coffeeBeans.Remove(coffeeBean);
        }
    }

    public CoffeeBean? Remove2(int id) //The way the assignment wants it
    {
        CoffeeBean? coffeeBean = GetById3(id);
        if (coffeeBean != null)
        {
            _coffeeBeans.Remove(coffeeBean);
        }
        return coffeeBean;
    }
}
