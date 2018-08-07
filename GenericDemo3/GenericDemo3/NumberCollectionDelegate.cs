using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericDemo3
{
    public static class NumberCollectionDelegate
    {
        //比较大小（逆序）
        public static int Compare(int i, int j)
        {
            if(i < j)
            {
                return 1;
            }else if(i > j)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }

        //找出所有的偶数
        public static bool Find(int i)
        {
            if(i%2 == 0)
            {
                return true;
            }

            return false;
        }

        // public void Sort(Comparison<T> comparison) 创建一个Comparision<T>的排序对象
        public static Comparison<int> CompareDelegate = new Comparison<int>(Compare);

        // public List<T> FindAll(Predicate<T> match) 创建一个Predicate<T>的谓词对象
        public static Predicate<int> Predicate = new Predicate<int>(Find);
    }
}
