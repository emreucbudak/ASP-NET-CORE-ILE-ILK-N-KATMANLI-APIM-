namespace DTOLAR
{
    [Serializable]
    public record ProductDto
    {

        public int ProductId { get; init; }
        public string ProductName { get; init; }
        public string CategoryName { get; init; }
    }
}
