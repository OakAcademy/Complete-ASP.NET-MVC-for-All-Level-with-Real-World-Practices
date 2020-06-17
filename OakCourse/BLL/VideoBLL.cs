using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class VideoBLL
    {
        VideoDAO dao = new VideoDAO();
        public bool AddVideo(VideoDTO model)
        {
            Video video = new Video();
            video.Title = model.Title;
            video.VideoPath = model.VideoPath;
            video.OriginalVideoPath = model.OriginalVideoPath;
            video.AddDate = DateTime.Now;
            video.LastUpdateDate = DateTime.Now;
            video.LastUpdateUserID = UserStatic.UserID;
            int ID = dao.AddVideo(video);
            LogDAO.AddLog(General.ProcessType.VideoAdd, General.TableName.Video, ID);

            return true;
        }

        public List<VideoDTO> GetVideos()
        {
            return dao.GetVideos();
        }

        public VideoDTO GetVideoWithID(int ID)
        {
            return dao.GetVideoWithID(ID);
        }

        public bool UpdateVideo(VideoDTO model)
        {
            dao.UpdateVideo(model);
            LogDAO.AddLog(General.ProcessType.VideoUpdate, General.TableName.Video, model.ID);
            return true;
        }

        public void DeleteVideo(int ID)
        {
            dao.DeleteVideo(ID);
            LogDAO.AddLog(General.ProcessType.VideoDelete, General.TableName.Video, ID);
        }
    }
}
