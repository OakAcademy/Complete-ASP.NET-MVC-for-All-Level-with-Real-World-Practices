using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class SocialMediaDAO : PostContext
    {
        public int AddSocialMedia(SocialMedia social)
        {
			try
			{
				db.SocialMedias.Add(social);
				db.SaveChanges();
				return social.ID;
			}
			catch (Exception ex)
			{

				throw ex;
			}
        }

        public List<SocialMediaDTO> GetSocialMedias()
        {
            List<SocialMedia> list = db.SocialMedias.Where(x => x.isDeleted == false).ToList();
            List<SocialMediaDTO> dtolist = new List<SocialMediaDTO>();

            foreach (var item in list)
            {
                SocialMediaDTO dto = new SocialMediaDTO();
                dto.Name = item.Name;
                dto.Link = item.Link;
                dto.ImagePath = item.ImagePath;
                dto.ID = item.ID;
                dtolist.Add(dto);
            }
            return dtolist;
        }

        public string DeleteSocialMedia(int ID)
        {
            try
            {
                SocialMedia social = db.SocialMedias.First(x => x.ID == ID);
                string imagepath = social.ImagePath;
                social.isDeleted = true;
                social.DeletedDate = DateTime.Now;
                social.LastUpdateDate = DateTime.Now;
                social.LastUpdateUserID = UserStatic.UserID;
                db.SaveChanges();
                return imagepath;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public SocialMediaDTO GetSocialMediaWithID(int ID)
        {
            SocialMedia socialmedia = db.SocialMedias.First(x => x.ID == ID);
            SocialMediaDTO dto = new SocialMediaDTO();
            dto.ID = socialmedia.ID;
            dto.Name = socialmedia.Name;
            dto.Link = socialmedia.Link;
            dto.ImagePath = socialmedia.ImagePath;
            return dto;
        }

        public string UpdateSocialMedia(SocialMediaDTO model)
        {
            try
            {
                SocialMedia social = db.SocialMedias.First(x => x.ID == model.ID);
                string oldImagePath = social.ImagePath;
                social.Name = model.Name;
                social.Link = model.Link;
                if (model.ImagePath != null)
                    social.ImagePath = model.ImagePath;
                social.LastUpdateDate = DateTime.Now;
                social.LastUpdateUserID = UserStatic.UserID;
                db.SaveChanges();
                return oldImagePath;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
