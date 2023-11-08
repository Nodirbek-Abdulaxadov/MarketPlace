using Market.Data.Interfaces;

namespace Market.Data.Repositories;

public class UnitOfWork : IUnitOfWork
{
    public UnitOfWork(IProductInterface productInterface,
                      ICustomerInterface customerInterface,
                      IPersonInterface personInterface,
                      IReceiptInterface receiptInterface,
                      IReceiptDetailInterface receiptDetailInterface,
                      IProductCategoryInterface productCategoryInterface)
    {
        PersonInterface = personInterface;
        CustomerInterface = customerInterface;
        ProductInterface = productInterface;
        ProductCategoryInterface = productCategoryInterface;
        ReceiptInterface = receiptInterface;
        ReceiptDetailInterface = receiptDetailInterface;
    }

    public IPersonInterface PersonInterface { get; }

    public ICustomerInterface CustomerInterface { get; }

    public IProductInterface ProductInterface { get; }

    public IProductCategoryInterface ProductCategoryInterface { get; }

    public IReceiptInterface ReceiptInterface { get; }

    public IReceiptDetailInterface ReceiptDetailInterface { get; }
}
