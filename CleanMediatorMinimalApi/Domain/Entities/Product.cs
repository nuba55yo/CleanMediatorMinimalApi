namespace CleanMediatorMinimalApi.Domain.Entities;

public class Product
{
    public Guid Id { get; set; } // ใช้ GUID เป็น ID เพื่อไม่ให้ชนกัน
    public string Name { get; set; } = default!;
    public decimal Price { get; set; }
}