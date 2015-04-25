using System;

namespace Collections
{
    public class Band : IComparable
    {
        public string Name { get; private set; }
        public int StudioAlbums { get; private set; }
        public string Genre { get; private set; }
        public string Country { get; private set; }

        public Band(string name, int studioAlbums, string genre, string country)
        {
            Name = name;
            StudioAlbums = studioAlbums;
            Genre = genre;
            Country = country;
        }


        public int CompareTo(object obj) {
            
            if (obj == null) return 1;

            Band band = obj as Band;
            if (band != null)
                return band.StudioAlbums.CompareTo(this.StudioAlbums);
            else
                throw new ArgumentException("Obiectul nu este o banda");
        }

        public override string ToString()
        {
            return "\n Name : " + this.Name + "\n Genre : " + this.Genre + "\n Tara : "
                + this.Country + "\n StudioAlbums : " + this.StudioAlbums;
        }
    }
}
