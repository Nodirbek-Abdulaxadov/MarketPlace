namespace Market.Data.Interfaces;

public interface IUnitOfWork
{
    IPersonInterface PersonInterface { get; }
    ICustomerInterface CustomerInterface { get; }
    IProductInterface ProductInterface { get; }
    IProductCategoryInterface ProductCategoryInterface { get; }
    IReceiptInterface ReceiptInterface { get; }
    IReceiptDetailInterface ReceiptDetailInterface { get; }
}