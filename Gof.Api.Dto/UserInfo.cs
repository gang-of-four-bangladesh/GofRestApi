using System;

namespace Gof.Api.Dto
{
    [Serializable]
    public class UserInfo
    {
        public int UserId { get; set; }

        public string Name { get; set; }

        public string PhoneNumber { get; set; }

        public string Password { get; set; }
    }
}