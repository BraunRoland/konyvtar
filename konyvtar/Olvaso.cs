using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace konyvtar
{
    class Olvaso
    {
        private string nev;
        private int eletkor;
        private string mufaj;
        private bool hirlevel;
        private bool sms;
        private string tagsag;

		public Olvaso(string nev, int eletkor, string mufaj, bool hirlevel, bool sms, string tagsag)
		{
			this.Nev = nev;
			this.Eletkor = eletkor;
			this.Mufaj = mufaj;
			this.Hirlevel = hirlevel;
			this.Sms = sms;
			this.Tagsag = tagsag;
		}

		public string Nev { get => nev; set => nev = value; }
		public int Eletkor { get => eletkor; set => eletkor = value; }
		public string Mufaj { get => mufaj; set => mufaj = value; }
		public bool Hirlevel { get => hirlevel; set => hirlevel = value; }
		public bool Sms { get => sms; set => sms = value; }
		public string Tagsag { get => tagsag; set => tagsag = value; }
	}
}
