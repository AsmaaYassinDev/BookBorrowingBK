using BBCommon.Contracts;

namespace BBBusiness.Model
{
    public class NewInfoForBook : Book, INewInfoForIBook
    {
      public string Edition { get; set; } = "";
      
    }
}
