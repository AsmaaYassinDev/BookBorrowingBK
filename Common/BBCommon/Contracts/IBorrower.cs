namespace BBCommon.Contracts
{
    public interface IBorrower
    {
        int Id { get; set; }
        string Name { get; set; }
        string Email { get; set; }
        string Phone { get; set; }

    }
}
