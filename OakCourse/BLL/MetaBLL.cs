using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class MetaBLL
    {
        MetaDAO dao = new MetaDAO();
        public bool AddMeta(MetaDTO model)
        {
            Meta meta = new Meta();
            meta.Name = model.Name;
            meta.MetaContent = model.MetaContent;
            meta.AddDate = DateTime.Now;
            meta.LastUpdateUserID = UserStatic.UserID;
            meta.LastUpdateDate = DateTime.Now;
            int MetaID = dao.AddMeta(meta);
            LogDAO.AddLog(General.ProcessType.MetaAdd, General.TableName.Meta, MetaID);
            return true;

            
        }

        public List<MetaDTO> GetMetaData()
        {
            List<MetaDTO> dtolist = new List<MetaDTO>();
            dtolist = dao.GetMetaData();
            return dtolist;
        }

        public MetaDTO GetMetaWithID(int ID)
        {
            MetaDTO metadto = new MetaDTO();
            metadto = dao.GetMetaWithID(ID);
            return metadto;
        }

        public bool UpdateMeta(MetaDTO model)
        {
            dao.UpdateMeta(model);
            LogDAO.AddLog(General.ProcessType.MetaUpdate, General.TableName.Meta, model.MetaID);
            return true;
        }

        public void DeleteMeta(int ID)
        {
            dao.DeleteMeta(ID);
            LogDAO.AddLog(General.ProcessType.MetaDelete, General.TableName.Meta, ID);
        }
    }
}
