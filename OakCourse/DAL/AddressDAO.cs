using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class AddressDAO : PostContext
    {
        public int AddAddress(Address ads)
        {
			try
			{
				db.Addresses.Add(ads);
				db.SaveChanges();
				return ads.ID;
			}
			catch (Exception ex)
			{

				throw ex;
			}
        }

        public List<AddressDTO> GetAddresses()
        {
            List<Address> list = db.Addresses.Where(x => x.isDeleted == false).OrderBy(x => x.AddDate).ToList();
            List<AddressDTO> dtolist = new List<AddressDTO>();
			foreach (var item in list)
			{
				AddressDTO dto = new AddressDTO();
				dto.ID = item.ID;
				dto.AddressContent = item.Address1;
				dto.Email = item.Email;
				dto.Fax = item.Fax;
				dto.LargeMapPath = item.MapPathLarge;
				dto.Phone = item.Phone;
				dto.Phone2 = item.Phone2;
				dto.SmallMapPath = item.MapPathSmall;
				dtolist.Add(dto);

			}
			return dtolist;
        }

        public void UpdateAddress(AddressDTO model)
        {
			try
			{
				Address ads = db.Addresses.First(x => x.ID == model.ID);
				ads.Address1 = model.AddressContent;
				ads.Email = model.Email;
				ads.Fax = model.Fax;
				ads.MapPathLarge = model.LargeMapPath;
				ads.MapPathSmall = model.SmallMapPath;
				ads.Phone = model.Phone;
				ads.Phone2 = model.Phone2;
				db.SaveChanges();
			}
			catch (Exception ex)
			{

				throw ex;
			}
        }

        public void DeleteAddress(int ID)
        {
			try
			{
				Address ads = db.Addresses.First(x => x.ID == ID);
				ads.isDeleted = true;
				ads.DeletedDate = DateTime.Now;
				ads.LastUpdateDate = DateTime.Now;
				ads.LastUpdateUserID = UserStatic.UserID;
				db.SaveChanges();
			}
			catch (Exception ex)
			{

				throw ex;
			}
        }

        public static string DeleteUser(int iD)
        {
            throw new NotImplementedException();
        }
    }
}
