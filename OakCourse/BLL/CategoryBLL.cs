using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BLL
{
    public class CategoryBLL
    {
        CategoryDAO dao = new CategoryDAO();
        public bool AddCategory(CategoryDTO model)
        {
            Category category = new Category();
            category.CategoryName = model.CategoryName;
            category.AddDate = DateTime.Now;
            category.LastUpdateDate = DateTime.Now;
            category.LastUpdateUserID = UserStatic.UserID;
            int ID = dao.AddCategory(category);
            LogDAO.AddLog(General.ProcessType.CategoryAdd, General.TableName.Category, ID);
            return true;
        }

        public static IEnumerable<SelectListItem> GetCategoriesForDropdown()
        {
            return CategoryDAO.GetCategoriesForDropdown();
        }

        public List<CategoryDTO> GetCategories()
        {
            return dao.GetCategories();
        }

        public CategoryDTO GetCategoryWithID(int ID)
        {
            return dao.GetCategoryWithID(ID);
        }

        public bool UpdateCategory(CategoryDTO model)
        {
            dao.UpdateCategory(model);
            LogDAO.AddLog(General.ProcessType.CategoryUpdate, General.TableName.Category, model.ID);
            return true;
        }
        PostBLL postbll = new PostBLL();
        public List<PostImageDTO> DeleteCategory(int ID)
        {
            List<Post> postlist = dao.DeleteCategory(ID);
            LogDAO.AddLog(General.ProcessType.CategoryDelete, General.TableName.Category, ID);
            List<PostImageDTO> imagelist = new List<PostImageDTO>();
            foreach (var item in postlist)
            {
                List<PostImageDTO> imagelist2 = postbll.DeletePost(item.ID);
                LogDAO.AddLog(General.ProcessType.PostDelete, General.TableName.post, item.ID);
                foreach (var item2 in imagelist2)
                {
                    imagelist.Add(item2);
                }
            }
            return imagelist;

        }
    }
}
