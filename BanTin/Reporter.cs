using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanTin
{
    internal class Reporter : People
    {
        private string name;
        private string mail;
        private string numOfNews;
        private List<LiveStream> listNews;
        private string company;

        public Reporter(string name, string mail, string numOfNews, List<LiveStream> listNews, string company)
        {
            this.name = name;
            this.mail = mail;
            this.numOfNews = numOfNews;
            this.listNews = new List<LiveStream> { };
            this.company = company;
        }
    }
}
