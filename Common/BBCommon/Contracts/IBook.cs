namespace BBCommon.Contracts
{
    public interface IBook
    {
        int Id { get; set; }
        string Title { get; set; }     
        string ISBN { get; set; }
        bool IsAvailable { get; set; }

    }
}
