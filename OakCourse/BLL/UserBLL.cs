using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
   public class UserBLL
    {
        UserDAO userdao = new UserDAO();
        public UserDTO GetUserWithUsernameAndPassword(UserDTO model)
        {
            UserDTO dto = new UserDTO();
            dto = userdao.GetUserWithUsernameAndPassword(model);
            return dto;
        }

        public List<UserDTO> GetUsers()
        {
            return userdao.GetUsers();
        }

        public void AddUser(UserDTO model)
        {
            T_User user = new T_User();
            user.Username = model.Username;
            user.Password = model.Password;
            user.Email = model.Email;
            user.ImagePath = model.Imagepath;
            user.NameSurname = model.Name;
            user.isAdmin = model.isAdmin;
            user.AddDate = DateTime.Now;
            user.LastUpdateDate = DateTime.Now;
            user.LastUpdateUserID = UserStatic.UserID;
            int ID = userdao.AddUser(user);
            LogDAO.AddLog(General.ProcessType.UserAdd, General.TableName.User, ID);
        }

        public UserDTO GetUserWithID(int ID)
        {
            return userdao.GetUserWithID(ID);
        }

        public string UpdateUser(UserDTO model)
        {
            string oldImagePath = userdao.UpdateUser(model);
            LogDAO.AddLog(General.ProcessType.UserUpdate, General.TableName.User, model.ID);
            return oldImagePath;
        }

        public string DeleteUser(int ID)
        {
            string imagepath = userdao.DeleteUser(ID);
            LogDAO.AddLog(General.ProcessType.UserDelete, General.TableName.User, ID);
            return imagepath;
        }
    }
}
