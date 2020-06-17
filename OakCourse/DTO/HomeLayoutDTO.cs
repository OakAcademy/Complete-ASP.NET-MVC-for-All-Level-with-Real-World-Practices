using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
   public class HomeLayoutDTO
    {
        public List<CategoryDTO> Categories { get; set; }
        public SocialMediaDTO Facebook { get; set; }
        public SocialMediaDTO Twitter { get; set; }
        public SocialMediaDTO Instagram { get; set; }
        public SocialMediaDTO Youtube { get; set; }
        public SocialMediaDTO Linkedin { get; set; }
        public SocialMediaDTO GooglePlus { get; set; }
        public FavDTO FavDTO { get; set; }
        public List<MetaDTO> Metalist { get; set; }
        public AddressDTO Address { get; set; }
        public List<PostDTO> HotNews { get; set; }
    }
}
