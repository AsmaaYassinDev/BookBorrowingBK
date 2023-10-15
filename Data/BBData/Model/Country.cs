using BBCommon.Contracts;

namespace BBData.Model
{
    public class Country
    {
        public required string Name { get; set; }
        public int Id { get; set; }
        public required IWeekendConfiguration Weekend { get; set; }

    }
}
