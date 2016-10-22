using SRC.MyClient.MyTree.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRC.MyClient.MyTree.DataAccess
{
    public class ItemTreeDAO
    {
        public List<ItemTree> RootMethod()
        {
            List<ItemTree> listRoot = new List<ItemTree>();
            using (TreeModelEntities context = new TreeModelEntities())
            {
                listRoot.AddRange(context.ItemTrees.Where(x => x.ParentId == null));
                foreach (var item in listRoot)
                    Recursion(item, context);
            }
            return listRoot;
        }

        private void Recursion(ItemTree itemTree, TreeModelEntities context)
        {
            if (context.ItemTrees.Any(x => x.ParentId == itemTree.Id))
            {
                itemTree.ChildList.AddRange(context.ItemTrees.Where(x => x.ParentId == itemTree.Id));
                foreach (var item in itemTree.ChildList)
                    Recursion(item, context);
            }
        }

        public void InsertRow(ItemTree itemTree)
        {
            using (TreeModelEntities context = new TreeModelEntities())
            {
                context.ItemTrees.Add(itemTree);
                context.SaveChanges();
            }
        }
    }
}
