using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanTin
{
    internal class Channel 
    {
        private string name;
        private int limitNews;
        private List<New> sang;
        private List<New> toi;
        private List<Anchor> listAnchors;

        private static List<Channel> chanels = new List<Channel>();
        public Channel(string name, int limitNews)
        {
            this.name = name;
            if (limitNews < 10 && limitNews > 3)
                this.limitNews = limitNews;
            else
                Console.WriteLine("So luong ban tin toi da cho 1 kenh la 10 va toi thieu la 3 ");

            chanels.Add(this);
            this.listAnchors = new List<Anchor>();
            this.toi = new List<New>();
            this.sang = new List<New>();
        }
        
        public List<New> getListPeriod(string iPeriod)
        {
            if (iPeriod == "sang")
                return this.sang;
            else if(iPeriod == "toi")
                return this.toi;
            return null;
        }


        public List<Anchor> getListAnchors() {
            return listAnchors;
        }

        public void addAnchor(string nameAnchor) {
            foreach(var anchor in chanels) { }
        }

        public string getName() { 
            return name;
        }

        public static List<Channel> getChanels()
        {
            return chanels;
        }

       // thêm bản tin vào channel
        public void channelAddBanTin(string banTinName, string period)
        {
            New foundBanTin = null;
            foreach (var banTin in New.getListNew())
            {
                if (banTin.getName() == banTinName)
                {
                    foundBanTin = banTin;
                    break;
                }                    
            }
            if (foundBanTin != null)
            {
                if (period == "sang")
                {
                    sang.Add(foundBanTin);
                    foundBanTin.getListChannels().Add(this.name);
                    foundBanTin.setChanelName(this.name);
                }

                else if (period == "toi")
                {
                        toi.Add(foundBanTin);
                        foundBanTin.getListChannels().Add(this.name);
                        foundBanTin.setChanelName(this.name);
                }
                else
                {
                    Console.WriteLine("Lam on nhap lai");
                    return;
                }
            }

        }

        public void printAll()
        {
            Console.WriteLine("Kenh " + name + " gom cac ban tin :");
            Console.WriteLine("Ban tin buoi sang: ");
            if (sang.Count == 0)
                Console.WriteLine("khong co ban tin buoi sang ");
            else
            {
                int i = 1;
                foreach (var banTin in sang)
                    Console.WriteLine(i + ". " + banTin.getName());
                i++;
            }

            Console.WriteLine("Ban tin buoi toi: ");
            if (toi.Count == 0)
                Console.WriteLine("khong co ban tin buoi toi ");
            else
            {
                int i = 1;
                foreach (var banTin in toi)
                    Console.WriteLine(i + ". " + banTin.getName());
                i++;
            }
        }

        //public void channelAddBanTin(BanTin banTinDaTao, string period) {

        //    if (period == "sang")
        //    {
        //        if (sang == null)
        //        {
        //            sang = new List<BanTin>();
        //            sang.Add(banTinDaTao);
        //            banTinDaTao.getListChanels().Add(this.name);
        //        }
        //        else 
        //        {
        //            sang.Add(banTinDaTao);
        //            banTinDaTao.getListChanels().Add(this.name);
        //        }


        //    }
        //    else if (period == "toi")
        //    {
        //        if (toi == null)
        //        {
        //            toi = new List<BanTin>();
        //            toi.Add(banTinDaTao);
        //            banTinDaTao.getListChanels().Add(this.name);
        //        }
        //        else 
        //        {
        //            toi.Add(banTinDaTao);
        //            banTinDaTao.getListChanels().Add(this.name);
        //        }

        //    }
        //    else
        //    {
        //        Console.WriteLine("Lam on nhap lai");
        //        return;
        //    }

        //}

    }
}
