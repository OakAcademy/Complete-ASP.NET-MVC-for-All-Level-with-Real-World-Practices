using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
  public  class CommentDTO
    {
        public int ID { get; set; }
        public int PostID { get; set; }
        public string PostTitle { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string CommentContent { get; set; }
        public bool isApproved { get; set; }
        public DateTime AddDate { get; set; }
    }
}
