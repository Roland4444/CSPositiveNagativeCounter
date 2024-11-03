// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;
using System.Linq;
namespace Exersice
{
    public class PositiveNegativeCounter
    {
        public static void Main(String[] args)
        {
            var s = new PositiveNegativeCounter();
            var lst1 = new List<int>{-1, 0, 1};
            var lst2 = new List<int>{-2, -5, 10};
            var lst3 = new List<int>{11, 23, -5, 0};
            var lst4 = new List<int>{43, 0, 23, -2,-3, 4,-1};
            var listLst = new List<List<int>>{lst1, lst2, lst3, lst4};
            listLst.Select(a => s.PositiveNegativeCount(a)).ToList().ForEach(result =>  Console.WriteLine($" {result}"));
            var lst21 = s.ListFromString("-1 0 1");
            var lst22 = s.ListFromString("-2 -5 10");
            var lst23 = s.ListFromString("11 23 -5 0");
            var lst24 = s.ListFromString("43 0 23 -2 -3 4 -1");
            var listLst2 = new List<List<int>>{lst21, lst22, lst23, lst24};
            listLst2.Select(a => s.PositiveNegativeCount(a)).ToList().ForEach(result =>  Console.WriteLine($" {result}"));
        }   

        public long PositiveNegativeCount(List<int> a)
        {
            return TranformLst(a.Where(x => x != 0).ToList(), new List<int>()).Where(x => x < 0).ToList().Count();
        }

        public List<int> TranformLst(List<int> input, List<int> result) 
        {
            if (!input.Any()) return result;
            if (input.Count() == 1) return result;
            var hdtail = input.HeadTail();
            var hd = hdtail.Item1;
            var tail = hdtail.Item2;
            var hdtail2 = tail.HeadTail();
            var hd2 = hdtail2.Item1;
            result.Add(hd * hd2);
            return TranformLst(tail, result);
        }     

        public List<int> ListFromString(string input)
        {
            return input.Split(' ').ToList().Select(a=> int.Parse(a)).ToList();
        }
    }

       
    public static class ListExtensions
    {
        public static Tuple<T, List<T>> HeadTail<T>(this List<T> source) 
        {
            var tail = new List<T>();
            if (source.Count()>1)
                tail = source.GetRange(1, source.Count()-1);
            return Tuple.Create(source[0], tail);
        }
    }
}



