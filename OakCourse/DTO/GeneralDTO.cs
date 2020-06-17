using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class GeneralDTO
    {
        public List<PostDTO> SliderPost { get; set; }
        public List<PostDTO> PopularPost { get; set; }
        public List<PostDTO> MostViewedPost { get; set; }
        public List<PostDTO> BreakingPost { get; set; }
        public List<VideoDTO> Videos { get; set; }
        public List<AdsDTO> Adslist { get; set; }
        public PostDTO PostDetail { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
        public string Subject { get; set; }
        public string SearchText { get; set; }
        public int PostID { get; set; }
        public List<PostDTO> CategoryPostList { get; set; }
        public string CategoryName { get; set; }
        public AddressDTO Address { get; set; }



    }
}
