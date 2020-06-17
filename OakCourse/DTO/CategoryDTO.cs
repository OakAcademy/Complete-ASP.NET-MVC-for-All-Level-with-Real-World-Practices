using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
   public class CategoryDTO
    {
        public int ID { get; set; }
        [Required(ErrorMessage ="Please fill the Category Name Area")]
        public string CategoryName { get; set; }
    }
}
