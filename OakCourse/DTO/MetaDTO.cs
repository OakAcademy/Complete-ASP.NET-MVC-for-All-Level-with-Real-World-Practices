using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
   public class MetaDTO
    {
        public int MetaID { get; set; }
        public string Name { get; set; }
        [Required(ErrorMessage ="Please fill the content area")]
        public string MetaContent { get; set; }
    }
}
