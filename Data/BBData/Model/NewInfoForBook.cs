﻿using BBCommon.Contracts;

namespace BBData.Model
{
    public class NewInfoForBook : Book, INewInfoForIBook
    {
      public string Edition { get; set; } = "";
    
    }
}
