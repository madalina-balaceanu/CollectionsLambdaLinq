using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Linq
{
    class Membru
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int BandId { get; set; }

        public Membru (int Id,int  BandId,string Name){
            this.Id = Id;
            this.BandId = BandId;
            this.Name = Name;
        }

        public override string ToString()
        {
            return "Id :"+this.Id+" Name: " + this.Name + " " + "  BandId: " + this.BandId;
        }
    }
}
