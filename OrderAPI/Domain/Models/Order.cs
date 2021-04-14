using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OrderAPI.Domain.Models

{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public long PhoneNumber { get; set; }

        public string Product { get; set; }
    }
}
