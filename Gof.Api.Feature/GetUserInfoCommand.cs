using System;

namespace Gof.Api.Feature
{
    [Serializable]
    public class GetUserInfoCommand
    {
        public int UserId { get; set; }
    }
}