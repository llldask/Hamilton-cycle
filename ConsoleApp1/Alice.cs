using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZiRgr
{
    internal class cellGraph
    {
        public cellGraph(int n,int m, long value)
        {
            this.n = n;
            this.m = m; 
            this.value = value;
        }
        public int n;
        public int m;
        public long value;
    }
    internal class graphs
    {
        public long[,] isoGraph;
        public long[,] encIsoGraph;
        public int[] newPoint;
        public long[,] graph;
        public long d;
        public long N;
        public int q;
        public List<cellGraph> cellGraphList;
    }
    internal class Alice
    {
        long[,] graph;
        long[,] isoGraph;
        long[,] encIsoGraph;
        int[] Hgraph;
        int[] HIsograph;
        int[] newPoint;
        
        public long N;
        long d;
        public Alice()
        {
            var g= ZeroNowledge.fileToArray();
            graph = new long[g.GetLength(0), g.GetLength(0)];
            for (int i = 0; i < g.GetLength(0); i++)
            {
                for (int j = 0; j < g.GetLength(0); j++)
                    graph[i, j] = g[i, j];  
            }
            Console.WriteLine("Граф");
            ZeroNowledge.Print(graph);
            Hgraph = ZeroNowledge.fileToHArray();
            Console.WriteLine("Гамильтонов цикл");
            ZeroNowledge.Print(Hgraph);
            keyRSA();

        }
        void keyRSA()
        {
            long P = RandomNaturalNumber.Create(60, 200);
            long Q = RandomNaturalNumber.Create(60, 200);
            N = P * Q;
           // N = 55;
            
            long f = (P - 1) * (Q - 1);
            d = CryptographicLibrary.relativelyPrime(f);
           // d = 3;
            Console.WriteLine("N="+N+" d="+d);
        }

        int[] newNumberIsomorf (int n)
        {
            var res=new int[n];
            for(int i = 0;i<n;i++)
            {
                res[i] = -1;
            }
            for (int i = 0; i < n; i++)
            {
                Random rnd = new Random();
                var x = rnd.Next(0,n);
               // Console.WriteLine(Array.IndexOf(res, 5));
                while (Array.IndexOf(res,x)!=-1)
                {
                    x = rnd.Next(0, n);
                }
                res[i] = x;
            }
            return res;
        }
        void isomorphicGraph ()
        {
            int n = graph.GetLength(0);
            newPoint = newNumberIsomorf(n);
            isoGraph=new long[n,n];
            for (int i = 0;i<n;i++)
            {
                for(int j = 0;j<n;j++)
                {
                    if (graph[i,j]==1)
                    {
                        isoGraph[newPoint[i], newPoint[j]] = 1;
                    }
                }
            }
            ZeroNowledge.Print(isoGraph);
            
            HIsograph = new int[n];
            for (int i = 0; i < n; i++)
            {
                HIsograph[i] = newPoint[Hgraph[i]-1]+1;
            }
            Console.WriteLine("new point");
            ZeroNowledge.Print(newPoint);
            Console.WriteLine("Гамильтонов цикл");
            ZeroNowledge.Print(HIsograph);
        }
        void randomNumberConcate()
        {
            Random rnd = new Random();
            int n = isoGraph.GetLength(0);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    var x = rnd.Next(1, 9).ToString();
                    isoGraph[i, j] =  int.Parse (x + isoGraph[i, j].ToString());   
                }
            }
            ZeroNowledge.Print(isoGraph);
        }
        void encryption()
        {
            
            
            int n = isoGraph.GetLength(0);
            encIsoGraph=new long[n,n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {

                    encIsoGraph[i, j] = CryptographicLibrary.quicklyRaising(isoGraph[i, j], d, N);
                }
            }
            ZeroNowledge.Print(encIsoGraph);
        }
        List<cellGraph> GetCellGraphList()
        {
            var cellList = new List<cellGraph>();
            for(int i = 0;i< HIsograph.Length-1;i++)
            {
                var a = HIsograph[i]-1;
                var b = HIsograph[i+1] - 1;
                cellList.Add(new cellGraph(a, b, isoGraph[a, b]));
            }
            var a2 = HIsograph[HIsograph.Length - 1] - 1;
            var b2 = HIsograph[0] - 1;
            cellList.Add(new cellGraph(a2, b2, isoGraph[a2, b2]));
            return cellList;
        }
        public graphs Answer(int q)
        {
            var res= new graphs();
            res.encIsoGraph = encIsoGraph;
            res.d = d;
            res.N = N;
            res.q = q;
            if(q == 1)
            {
                res.cellGraphList= GetCellGraphList();
                return res;
            }
            else if(q == 2) 
            {
                res.isoGraph = isoGraph;
                res.newPoint = newPoint;
                
                res.graph = graph;
                return res;
            }
            else { return null; }
        }
        public void matrixForBob()
        {
            isomorphicGraph();
            randomNumberConcate();
            encryption();
        }

    }
}
