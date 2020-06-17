using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class AddressBLL
    {
        AddressDAO dao = new AddressDAO();
        public bool AddAdress(AddressDTO model)
        {
            Address ads = new Address();
            ads.Address1 = model.AddressContent;
            ads.Email = model.Email;
            ads.Phone = model.Phone;
            ads.Phone2 = model.Phone2;
            ads.Fax = model.Fax;
            ads.MapPathLarge = model.LargeMapPath;
            ads.MapPathSmall = model.SmallMapPath;
            ads.AddDate = DateTime.Now;
            ads.LastUpdateDate = DateTime.Now;
            ads.LastUpdateUserID = UserStatic.UserID;
            int ID = dao.AddAddress(ads);
            LogDAO.AddLog(General.ProcessType.AddressAdd, General.TableName.Address, ID);
            return true;

        }

        public List<AddressDTO> GetAddresses()
        {
            return dao.GetAddresses();
        }

        public bool UpdateAddress(AddressDTO model)
        {
            dao.UpdateAddress(model);
            LogDAO.AddLog(General.ProcessType.AddressUpdate, General.TableName.Address, model.ID);
            return true;
        }

        public void DeleteAddress(int ID)
        {
            dao.DeleteAddress(ID);
            LogDAO.AddLog(General.ProcessType.AddressDelete, General.TableName.Address, ID);
        }
    }
}
