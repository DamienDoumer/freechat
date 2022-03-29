using System;

namespace Models.Base
{
    public class BaseModel : BindableModel
    {
        public string Id { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
