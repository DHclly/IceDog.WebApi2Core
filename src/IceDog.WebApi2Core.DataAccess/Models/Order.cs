using System;
using System.Collections.Generic;
using System.Text;

namespace IceDog.WebApi2Core.DataAccess.Models
{
    public class Order
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public DateTime OrderDate { get; set; }
    }
}
