using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace DTO
{
  public  class AdsDTO
    {
        public int ID { get; set; }
        [Required(ErrorMessage ="Please fill the name Area")]
        public string Name { get; set; }
        public string ImagePath { get; set; }
        [Required(ErrorMessage = "Please fill the link Area")]
        public string Link { get; set; }
        [Required(ErrorMessage = "Please fill the imagesize Area")]
        public string Imagesize { get; set; }
        [Display(Name ="Ads Image")]
        public HttpPostedFileBase AdsImage { get; set; }

    }
}
