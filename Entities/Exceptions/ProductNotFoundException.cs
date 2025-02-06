namespace Entities.Exceptions
{
    public sealed class ProductNotFoundException: NotFoundException
    {
        public ProductNotFoundException(int id ) : base($"The Product with id= {id} wasn't found.")
        {
            
        }
    }
}
