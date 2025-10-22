using MovieRental.Rental;

public class Customer
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;

    public ICollection<Rental> Rentals { get; set; } = new List<Rental>();
}