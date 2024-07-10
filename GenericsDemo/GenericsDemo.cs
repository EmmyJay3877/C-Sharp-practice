using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoLibrary
{
    public class GenericsDemo
    {
        static void Main(string[] args)
        {
            
            GenericList<int> nums = new GenericList<int>();

            nums.Add(2);
            nums.Add(3);
            nums.Add(4);

            for(int i = 0; i < nums.Len(); i++)
            {
                Console.WriteLine(nums.Get(i));
            }

            GenericDict<int, string> names = new GenericDict<int, string>();

            names.Add(1, "John");
            names.Add(2, "Sam");
            names.Add(3, "Joe");


            for (int i = 1; i < names.Len() + 1; i++)
            {
                Console.WriteLine(names.TryGetValue(i));
            }

            names.Clear();

            Console.ReadLine();
        }
    }

    public class GenericDict<TKey, TValue>
    {
        public Dictionary<TKey, TValue> dict = new Dictionary<TKey, TValue>();

        public void Add(TKey key, TValue value)
        {
            dict.Add(key, value);
        }

        public int Len()
        {
            return dict.Count;
        }

        public TValue TryGetValue(TKey key)
        {
            dict.TryGetValue(key, out TValue value);

            return value;
        }

        public void Clear()
        {
            dict.Clear();
        }
    }

    public class GenericList<T>
    {
        public List<T> list = new List<T>();

        public void Add(T item)
        {
            list.Add(item);
        }

        public int Len()
        {
            return list.Count;
        }

        public T Get(int index)
        {
            return list[index];
        }
    }

}
