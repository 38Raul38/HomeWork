namespace ConsoleApp2;

public interface ISale
{
    public Guid Id { get; set; }
    public Guid ShowroomId { get; set; }
    public Guid CarId { get; set; }
    public Guid UserId { get; set; }
    public DateTime SaleDate { get; set; }
}