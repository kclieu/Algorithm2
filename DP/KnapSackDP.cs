using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algos
{
    //public class Item
    //{
    //    public int ID;
    //    public double Weight;
    //    public double Price;

    //    public Item(int id, double weight, double price)
    //    {
    //        ID = id;
    //        Weight = weight;
    //        Price = price;
    //    }

    //    public override string ToString()
    //    {
    //        return "ID="+ID+", Weight=" + Weight + ",Price=" + Price;
    //    }
    //}
    //public static class KnapSackDP
    //{
    //    public static List<Item> FindItemsToPack(List<Item> items, double capacity, double totalValue)
    //    {
    //        double[,] price = new double[items.Count + 1, items.Count + 1];
    //        bool[,] keep = new bool[items.Count + 1, items.Count + 1];

    //        for (int i = 0; i < items.Count; i++)
    //        {
    //            Item currentItem = items[i];

    //            for (int space = 0; space < capacity; space++)
    //            {
    //                if (space >= currentItem.Weight)
    //                { 
    //                    double remainingSpace = space - currentItem.Weight;
    //                    double remainingSpaceValue = 0;

    //                    if (remainingSpace > 0)
    //                    {
    //                        remainingSpaceValue = price[i - 1, remainingSpace];
    //                    }
    //                }
    //            }

    //        }
    //    }
    //}
}
