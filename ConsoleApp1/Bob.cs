using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZiRgr
{
    internal class Bob
    {
        public void check(graphs answer)
        {
            if (answer == null)
                Console.WriteLine("Ошибка");

            if (answer.q == 2)
            {
                Console.WriteLine("Действительно ли граф H изоморфен G?");
                TryIsomorf(answer);
            }
            else if (answer.q == 1) 
            {
                Console.WriteLine("Каков гамильтонов цикл для графа H?");
                TryHCycle(answer);
            }
            
        }
        void TryHCycle(graphs answer)
        {
            for(int i = 0; i < answer.cellGraphList.Count; i++) {
                var a = answer.cellGraphList[i].n;
                var b = answer.cellGraphList[i].m;
                var v = answer.cellGraphList[i].value;
                if (CryptographicLibrary.quicklyRaising(v, answer.d, answer.N) != answer.encIsoGraph[a,b])
                {
                    Console.WriteLine("Такого цикла не существует");
                    return;
                }
            }
            var list1=new List<int>();
            var list2 = new List<int>();
            for (int i = 0; i < answer.cellGraphList.Count; i++)
            {
                if (list1.IndexOf(answer.cellGraphList[i].m)!=-1)
                {
                    Console.WriteLine("Такого цикла не существует");
                    return;
                }
                list1.Add(answer.cellGraphList[i].m);
                if (list2.IndexOf(answer.cellGraphList[i].n) != -1)
                {
                    Console.WriteLine("Такого цикла не существует");
                    return;
                }
                list2.Add(answer.cellGraphList[i].n);
            }
            foreach(var a in list1)
            {
                Console.Write((a+1)+" ");
            }
            Console.WriteLine();
        }
        void TryIsomorf(graphs answer)
        {

            int n=answer.encIsoGraph.GetLength(0);
            for (int i=0; i<n; i++)
            {
                for(int j=0;j<n;j++)
                {
                    if (answer.encIsoGraph[i, j] != CryptographicLibrary.quicklyRaising(answer.isoGraph[i,j],answer.d,answer.N))
                    {
                        Console.WriteLine("Граф H не соответствует F");
                        return;
                    }
                }
            }

            var H=new long[n,n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    var str = answer.isoGraph[i, j].ToString();
                    H[i, j] = int.Parse( str[str.Length-1].ToString());
                }
            }
            //ZeroNowledge.Print(H);
            var twinF  = new long[n, n];
            var dictPoint = new Dictionary<int, int>();
            for(int i=0;i<answer.newPoint.Length;i++)
            {
                dictPoint[answer.newPoint[i]] = i;
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (H[i, j] == 1)
                    {
                        twinF[dictPoint[i], dictPoint[j]] = 1;
                    }
                }
            }
            // ZeroNowledge.Print(twinF);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (twinF[i,j] != answer.graph[i,j])
                    {
                        Console.WriteLine("Граф H не изоморфен G");
                        return;
                    }
                }
            }

            Console.WriteLine("Граф H изоморфен G");
        }
       
    }
}
