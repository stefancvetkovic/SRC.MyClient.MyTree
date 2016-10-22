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
            ItemTreeDAO dao = new ItemTreeDAO();
            return dao.RootMethod();
        }

        public void InsertData(string name, int? parentId)
        {
            ItemTreeDAO dao = new ItemTreeDAO();
            dao.InsertRow(new ItemTree { ParentId = parentId, ItemName = name });
        }
    }
}
