using System.Collections.Generic;

namespace CoreLibrary.Models
{
    public class AuthorizationResponce
    {
        public bool Success { get; set; }
        public Client Client { get; set; }
        public List<Error> Errors { get; set; }

    }
}
