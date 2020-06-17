using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
   public class CountDTO
    {
        public int MessageCount { get; set; }
        public int CommentCount { get; set; }

        public int PostCount { get; set; }
        public int ViewCount { get; set; }
    }
}
