using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanTin
{
    public class Anchor : Author, People
    {
        private string name;
        private string mail;
        private List<LiveStream> listNews;
        private string company;
        private int numOfDays;
        private List<string> listChannels;
        private List<string> listDays;
        private static List<Anchor> listAnchorsOfChannel;

        public Anchor(string name, string company, string mail) : base(name, company, mail)
        {
            this.name = name;
            this.mail = mail;
            this.company = company;
            this.numOfDays = 0;
            this.listDays = new List<string>();
            this.listChannels = new List<string>();

            if (listAnchorsOfChannel == null)
                listAnchorsOfChannel = new List<Anchor>();

            listAnchorsOfChannel.Add(this);
        }

        public List<Anchor> getListAnchors()
        {
            return listAnchorsOfChannel;
        }
        public List<string> getListChannels()
        {
            return this.listChannels;
        }
        public List<string> getListDays()
        {
            return this.listChannels;
        }
    }
}



