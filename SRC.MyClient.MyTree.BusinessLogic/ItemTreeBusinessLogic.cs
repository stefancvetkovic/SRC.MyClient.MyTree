using SRC.MyClient.MyTree.DataAccess;
using SRC.MyClient.MyTree.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRC.MyClient.MyTree.BusinessLogic
{
    public class ItemTreeBusinessLogic
    {
        public List<ItemTree> GetRootData()
        {
            try
            {
                ItemTreeDAO dao = new ItemTreeDAO();
                return dao.RootMethod();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void InsertData(ItemTree item)
        {

            try
            {
                ItemTreeDAO dao = new ItemTreeDAO();
                //dao.InsertRow(new ItemTree { ParentId = parentId, ItemName = name });
                dao.InsertRow(item);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteItem(int id)
        {
            try
            {

                ItemTreeDAO dao = new ItemTreeDAO();
                dao.DeleteItemAndChilds(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<ItemTree> GetAllData()
        {
            try
            {
                ItemTreeDAO dao = new ItemTreeDAO();
                return dao.GetAll();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
