using SRC.MyClient.MyTree.BusinessLogic;
using SRC.MyClient.MyTree.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRC.MyClient.MyTree.ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            ItemTreeBusinessLogic bl = new ItemTreeBusinessLogic();
            //List<ItemTree> list = bl.GetRootData();
            //bl.DeleteItem(2);
            //InsertData(bl);
            Console.WriteLine("The end");
            Console.ReadKey();
        }

        //public static void InsertData(ItemTreeBusinessLogic bl)
        //{
        //    bl.InsertData("root1", null);
        //    bl.InsertData("level 1", 1);
        //    bl.InsertData("level 2", 2);
        //    bl.InsertData("level 2", 2);
        //    bl.InsertData("level 2", 2);
        //    bl.InsertData("level 3", 3);
        //    bl.InsertData("level 4", 4);
        //    bl.InsertData("level 5", 3);
        //    bl.InsertData("level 2", 2);
        //    bl.InsertData("level 1", 1);
        //}
    }
}
