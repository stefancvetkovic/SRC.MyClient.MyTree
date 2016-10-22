using SRC.MyClient.MyTree.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace SRC.MyClient.MyTree.DataAccess
{
    public class ItemTreeDAO
    {
        public List<ItemTree> RootMethod()
        {
            try
            {
                List<ItemTree> listRoot = new List<ItemTree>();
                using (TreeModelEntities context = new TreeModelEntities())
                {
                    listRoot.AddRange(context.ItemTrees.Where(x => x.ParentId == null));
                    foreach (ItemTree itemTree in listRoot)
                        Recursion(itemTree, context);
                }
                return listRoot;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void Recursion(ItemTree itemTree, TreeModelEntities context)
        {
            try
            {
                if (context.ItemTrees.Any(x => x.ParentId == itemTree.Id))
                {
                    itemTree.ChildList.AddRange(context.ItemTrees.Where(x => x.ParentId == itemTree.Id));
                    foreach (var item in itemTree.ChildList)
                        Recursion(item, context);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void InsertRow(ItemTree itemTree)
        {
            try
            {
                using (TreeModelEntities context = new TreeModelEntities())
                {
                    context.ItemTrees.Add(itemTree);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteItemAndChilds(int id)
        {
            try
            {
                Dictionary<int, int> dictItemsToDelete = new Dictionary<int, int>();

                using (TreeModelEntities context = new TreeModelEntities())
                {
                    ItemTree itemTree = context.ItemTrees.FirstOrDefault(x => x.Id == id);
                    if (itemTree != null)
                    {
                        dictItemsToDelete.Add(id, 0);
                        RecursionDelete(itemTree, context, dictItemsToDelete, 0);
                        dictItemsToDelete = dictItemsToDelete.OrderByDescending(x => x.Value).Select(t => new { t.Key, t.Value }).ToDictionary(t => t.Key, t => t.Value);

                        using (TransactionScope ts = new TransactionScope())
                        {
                            foreach (KeyValuePair<int, int> kvPair in dictItemsToDelete)
                            {
                                ItemTree item = context.ItemTrees.FirstOrDefault(x => x.Id == kvPair.Key);
                                context.ItemTrees.Remove(item);
                                context.SaveChanges();
                            }
                            ts.Complete();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void RecursionDelete(ItemTree itemTree, TreeModelEntities context, Dictionary<int, int> dictionary, int level)
        {
            try
            {
                //Da li item ima decu?
                if (context.ItemTrees.Any(x => x.ParentId == itemTree.Id))
                {
                    level++;
                    foreach (var item in context.ItemTrees.Where(x => x.ParentId == itemTree.Id))
                        dictionary.Add(item.Id, level);

                    itemTree.ChildList.AddRange(context.ItemTrees.Where(x => x.ParentId == itemTree.Id));

                    foreach (var item in itemTree.ChildList)
                        RecursionDelete(item, context, dictionary, level);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ItemTree> GetAll()
        {
            try
            {
                using (TreeModelEntities context = new TreeModelEntities())
                {
                    return context.ItemTrees.ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
