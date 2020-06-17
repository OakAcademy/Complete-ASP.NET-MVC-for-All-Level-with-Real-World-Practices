using System;
using System.Collections.Generic;
using System.Data.Metadata.Edm;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class UserDAO : PostContext
    {
        public UserDTO GetUserWithUsernameAndPassword(UserDTO model)
        {
            UserDTO dto = new UserDTO();
            T_User user = db.T_User.FirstOrDefault(x=>x.Username==model.Username && x.Password==model.Password);
            if(user!=null && user.ID!=0)
            {
                dto.ID = user.ID;
                dto.Username = user.Username;
                dto.Name = user.NameSurname;
                dto.Imagepath = user.ImagePath;
                dto.isAdmin = user.isAdmin;
            }
            return dto;
        }

        public List<UserDTO> GetUsers()
        {
            List<T_User> list = db.T_User.Where(x => x.isDeleted == false).OrderBy(x => x.AddDate).ToList();
            List<UserDTO> userlist = new List<UserDTO>();
            foreach (var item in list)
            {
                UserDTO dto = new UserDTO();
                dto.ID = item.ID;
                dto.Name = item.NameSurname;
                dto.Username = item.Username;
                dto.Imagepath = item.ImagePath;
                userlist.Add(dto);
            }
            return userlist;
        }

        public UserDTO GetUserWithID(int ID)
        {
            T_User user = db.T_User.First(x => x.ID == ID);
            UserDTO dto = new UserDTO();
            dto.ID = user.ID;
            dto.Name = user.NameSurname;
            dto.Username = user.Username;
            dto.Password = user.Password;
            dto.isAdmin = user.isAdmin;
            dto.Email = user.Email;
            dto.Imagepath = user.ImagePath;
            return dto;
        }

        public string DeleteUser(int ID)
        {
            try
            {
                T_User user = db.T_User.First(x => x.ID == ID);
                user.isDeleted = true;
                user.DeletedDate = DateTime.Now;
                user.LastUpdateDate = DateTime.Now;
                user.LastUpdateUserID = UserStatic.UserID;
                db.SaveChanges();
                return user.ImagePath;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public string UpdateUser(UserDTO model)
        {
            try
            {
                T_User user = db.T_User.First(x => x.ID == model.ID);
                string oldImagePath = user.ImagePath;
                user.NameSurname = model.Name;
                user.Username = model.Username;
                if (model.Imagepath != null)
                    user.ImagePath = model.Imagepath;
                user.Email = model.Email;
                user.Password = model.Password;
                user.LastUpdateDate = DateTime.Now;
                user.LastUpdateUserID = UserStatic.UserID;
                user.isAdmin = model.isAdmin;
                db.SaveChanges();
                return oldImagePath;
               
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public int AddUser(T_User user)
        {
            try
            {
                db.T_User.Add(user);
                db.SaveChanges();
                return user.ID;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}
