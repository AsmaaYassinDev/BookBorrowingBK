using BBCommon.Contracts;

namespace BBBusiness.Model
{
    public class Country:ICountry
    {
        public required string Name { get; set; }
        public int Id { get; set; }
        public DayOfWeek StartDay { get; set; }
        public DayOfWeek EndDay { get; set; }

    }
}
