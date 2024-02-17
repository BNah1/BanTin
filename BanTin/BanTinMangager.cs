using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanTin
{
    internal abstract class BanTinManager
    {
        protected double time;

        public abstract void printInfo();
        public virtual double calculateTime()
        {
            return time;
        }
    }
}
