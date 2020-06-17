using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class FavDAO : PostContext
    {
        public FavDTO GetFav()
        {
            FavLogoTitle fav = db.FavLogoTitles.First();

            FavDTO dto = new FavDTO();
            dto.ID = fav.ID;
            dto.Title = fav.Title;
            dto.Logo = fav.Logo;
            dto.Fav = fav.Fav;
            return dto;
        }

        public FavDTO UpdateFav(FavDTO model)
        {
            try
            {
                FavLogoTitle fav = db.FavLogoTitles.First();
                FavDTO dto = new FavDTO();
                dto.ID = fav.ID;
                dto.Fav = fav.Fav;
                dto.Logo = fav.Logo;
                fav.Title = model.Title;
                if (model.Logo != null)
                    fav.Logo = model.Logo;
                if (model.Fav != null)
                    fav.Fav = model.Fav;
                db.SaveChanges();
                return dto;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
