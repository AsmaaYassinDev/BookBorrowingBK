using BBCommon.Contracts;

namespace BBData.Model
{
    public class Country : ICountry
    {
        public Country()
        {

        }
        public Country(ICountry country)
        {
            Name = country.Name;
            StartDay = country.StartDay;
            EndDay = country.EndDay;
        }

        public  string Name { get; set; }
        public int Id { get; set; }
        public DayOfWeek StartDay { get; set; }
        public DayOfWeek EndDay { get; set; }
       
    }
}
