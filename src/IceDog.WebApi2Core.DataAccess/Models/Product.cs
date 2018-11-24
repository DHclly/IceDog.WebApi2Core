using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace IceDog.WebApi2Core.DataAccess.Models
{
    public class Product
    {
        public int Id { get; set; }

        public bool IsDiscontinued { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }
    }
}
