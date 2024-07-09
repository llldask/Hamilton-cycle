using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZiRgr
{
    internal class DecToBinList
    {
        private List<int> res = new List<int>();
        public List<int> DToB(long x)
        {
            //res = new List<int>();
            if (x == 0)
            {
                res.Add(0);
                return res;
            }

            if (x == 1)
            {
                res.Add(1);
                //res.Reverse();
                return res;
            }
            res.Add((int)(x % 2));
            DToB(x / 2);
            return res;
        }
    }
}
