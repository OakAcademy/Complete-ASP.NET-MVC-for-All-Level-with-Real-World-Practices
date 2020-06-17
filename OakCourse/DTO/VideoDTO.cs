using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class VideoDTO
    {
        public int ID { get; set; }
        public string VideoPath { get; set; }
        [Required(ErrorMessage ="Please fill the Video area")]
        public string OriginalVideoPath { get; set; }

        [Required(ErrorMessage = "Please fill the Title area")]
        public string Title  { get; set; }
        public DateTime AddDate { get; set; }
    }
}
