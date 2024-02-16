using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanTin
{
    internal abstract class BanTin
    {
        protected string name;
        protected double time;
        protected string noiDung;
        protected string timeStart;
        protected string timeEnd;

        public abstract void printInfo();
        public virtual double calculateTime()
        {
            return time;
        }
    }
}
