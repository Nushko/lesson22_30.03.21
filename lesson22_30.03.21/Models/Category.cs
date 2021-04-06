
using lesson22_30._03._21.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace lesson22_30._03._21.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}