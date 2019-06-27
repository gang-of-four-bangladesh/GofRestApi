using System;

namespace Gof.Api.Dto
{
    [Serializable]
    public class ProductInfo
    {
        public string Name { get; set; }

        public string Description { get; set; }
    }
}