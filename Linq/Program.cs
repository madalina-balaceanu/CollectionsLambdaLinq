﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Linq
{
    class Program
    {
        private static List<Band> GetBands()
        {
            return new List<Band>
            {
                new Band(1, "Led Zeppelin", 9, "Hard Rock", "England"),
                new Band(2, "Judas Priest", 17, "Heavy Metal", "England"),
                new Band(3, "Phoenix", 10, "Rock", "Romania"),
                new Band(4, "Black Sabbath", 19, "Heavy Metal", "England"),
                new Band(5, "Rammstein", 6, "Industrial Metal", "Germany"),
                new Band(6, "Black Keys", 8, "Indie Rock", "United States"),
                new Band(7, "Muse", 6, "Alternative Rock", "England")
            };
        }

        private static List<Song> GetSongs()
        {
            return new List<Song>
            {
                new Song(1, "Song1", 1),
                new Song(2, "Song2", 1),
                new Song(3, "Song3", 2),
                new Song(4, "Song4", 3),
                new Song(5, "Song5", 4),
                new Song(6, "Song6", 4),
                new Song(7, "Song7", 5),
                new Song(8, "Song8", 6)
            };
        }

        private static List<Membru> GetMembers()
        {
            return new List<Membru>
            {
                new Membru(1,1,"Membrul 1"),
                new Membru(2,2,"Membrul 2"),
                new Membru(3,3,"Membrul 3"),
                new Membru(4,4,"Membrul 4"),
                new Membru(5,5,"Membrul 5"),
                new Membru(6,6,"Membrul 6"),
                new Membru(7,7,"Membrul 7"),
                new Membru(8,8,"Membrul 8"),
                new Membru(9,1,"Membrul 9"),
                new Membru(10,2,"Membrul 10"),
                new Membru(11,3,"Membrul 11"),
                new Membru(12,4,"Membrul 12"),
                new Membru(13,5,"Membrul 13"),
                new Membru(14,6,"Membrul 14"),
                new Membru(15,7,"Membrul 15"),
                new Membru(16,8,"Membrul 16"),
                new Membru(17,5,"Membrul 17")
            };
        }

        private static readonly IEnumerable<Band> Bands = GetBands();

        private static readonly IEnumerable<Song> Songs = GetSongs();

        private static readonly IEnumerable<Membru> Members = GetMembers();

        static void Main(string[] args)
        {
            //ShowList(Bands);

            var bandMinAlbums = Bands.Min(b => b.StudioAlbums);
            Console.WriteLine(bandMinAlbums.ToString());

            var bandMaxAlbums = Bands.Max(b => b.StudioAlbums);
            Console.WriteLine(bandMaxAlbums.ToString());

            //var filteredBands = StartsWith("L");
            //ShowList(filteredBands);
            //---
            //var filteredBands = StartsWithLinq1("L");
            //ShowList(filteredBands);

            //OrderByNrOfStudioAlbums();
            //Console.WriteLine();
            //OrderByNrOfStudioAlbumsLinq();

            //GroupByCountryLync1();
            //Console.WriteLine();
            //GroupByCountryLync2();
            Console.WriteLine("Sortare dupa gen de muzica");
            GroupByGenreLync1();
            Console.WriteLine();

            GroupByGenreLync2();
            Console.WriteLine();

            //GetSongsForBandsLinq1();
            //Console.WriteLine();
            //GetSongsForBandsLinq2();

            //GetSongsForAllBandsLinq1();
            //Console.WriteLine();
            //GetSongsForAllBandsLinq2();

            //GetSongsForAllBandsGroupJoin1();
            //Console.WriteLine();
            //GetSongsForAllBandsGroupJoin2();

            Console.WriteLine("Grupare membri");

            Console.WriteLine("GetMembersForBandsLinq1()");
            GetMembersForBandsLinq1();
            Console.WriteLine();

            Console.WriteLine("GetMembersForBandsLinq2()");
            GetMembersForBandsLinq2();
            Console.WriteLine();


            Console.WriteLine("GetMembersForAllBandsLinq1()");
            GetMembersForAllBandsLinq1();
            Console.WriteLine();

            Console.WriteLine("GetMembersForAllBandsLinq2()");
            GetMembersForAllBandsLinq2();
            Console.WriteLine();

            Console.WriteLine("GetMembersForAllBandsGroupJoin1()");
            GetMembersForAllBandsGroupJoin1();
            Console.WriteLine();

            Console.WriteLine("GetMembersForAllBandsGroupJoin2()");
            GetMembersForAllBandsGroupJoin2();
            Console.WriteLine();




            StudioAlbumsGreaterThan(6);
            Console.ReadLine();
        }

        #region StartsWith

        public static IEnumerable<Band> StartsWith(string filterName)
        {
            var filteredResults = new List<Band>();

            foreach (var band in Bands)
            {
                if (band.Name.StartsWith(filterName))
                {
                    filteredResults.Add(band);
                }
            }

            return filteredResults;
        }

        public static IEnumerable<Band> StartsWithLinq1(string filterName)
        {
            var filteredBands = from band in Bands
                                where band.Name.StartsWith(filterName)
                                select band;

            return filteredBands;
        }

        public static IEnumerable<Band> StartsWithLinq2(string filterName)
        {
            var filterBands = Bands.Where(b => b.Name.StartsWith(filterName));

            return filterBands;
        }

        #endregion

        #region StudioAlbumsGreaterThan - TODO

        public static void StudioAlbumsGreaterThan(int noOfAlbums)
        {
           // var myBands = GetBands().Where(b=>b.StudioAlbums > noOfAlbums);

            var myBands = from band in GetBands()
                          where band.StudioAlbums > noOfAlbums
                          select band;


            ShowList(myBands);
        }

        #endregion

        #region OrderByNrOfStudioAlbums

        public static void OrderByNrOfStudioAlbums()
        {
            var myBands = GetBands();

            Band aux;
            for (var index1 = 0; index1 < myBands.Count(); index1++)
            {
                for (var index2 = 0; index2 < myBands.Count(); index2++)
                {
                    if (myBands[index1].StudioAlbums < myBands[index2].StudioAlbums)
                    {
                        aux = myBands[index1];
                        myBands[index1] = myBands[index2];
                        myBands[index2] = aux;
                    }
                }
            }

            ShowList(myBands);
        }

        public static void OrderByNrOfStudioAlbumsLinq()
        {
            var myBands = GetBands();

            var orderedBands = myBands.OrderBy(b => b.StudioAlbums);

            ShowList(orderedBands);
        }

        #endregion

        #region GroupByCountry

        public static void GroupByCountryLync1()
        {
            var groupedBands = 
                        from band in Bands
                         group band by band.Country into bC
                         select new
                         {
                             Country = bC.Key,
                             NumberOfBands = bC.Count()
                         };

            foreach (var group in groupedBands)
            {
                Console.WriteLine("Country: " + group.Country + " NumberOfBands: " + group.NumberOfBands);
            }
        }

        public static void GroupByCountryLync2()
        {
            var groupedBands = Bands.GroupBy(b => b.Country).Select(g => new { Country = g.Key, NumberOfBands = g.Count()});

            foreach (var group in groupedBands)
            {
                Console.WriteLine("Country: " + group.Country + " NumberOfBands: " + group.NumberOfBands);
            }
        }

        #endregion

        #region GroupByGenre - TODO

        public static void GroupByGenreLync1()
        { 
            //.....Your code here......
            var groupedBands =
                        from band in Bands
                        group band by band.Genre into bC
                        select new
                        {
                            Genre = bC.Key,
                            NumberOfBands = bC.Count()
                        };

            foreach (var group in groupedBands)
            {
                Console.WriteLine("Genre: " + group.Genre + " NumberOfBands: " + group.NumberOfBands);
            }
        }

        public static void GroupByGenreLync2()
        {
            //.....Your code here......
            var groupedBands = Bands.GroupBy(b => b.Genre).Select(g => new { Genre = g.Key, NumberOfBands = g.Count() });

            foreach (var group in groupedBands)
            {
                Console.WriteLine("Genre: " + group.Genre + " NumberOfBands: " + group.NumberOfBands);
            }
        }
        
        #endregion

        #region GetSongsForAllBands()

        //INNER JOIN
        public static void GetSongsForBandsLinq1()
        {
            var bandSongs = from band in Bands
                       join song in Songs on band.Id equals song.BandId
                       select new { 
                            Band = band.Name,
                            Song = song.Name
                       };

            foreach (var bandSong in bandSongs)
            {
                Console.WriteLine("Band: " + bandSong.Band + " Song:" + bandSong.Song);
            }
        }

        //INNER JOIN
        public static void GetSongsForBandsLinq2()
        {
            var bandSongs = Bands.Join(Songs, b => b.Id, s => s.BandId, (band, song) => new
            {
                Band = band.Name,
                Song = song.Name
            });

            foreach (var bandSong in bandSongs)
            {
                Console.WriteLine("Band: " + bandSong.Band + " Song:" + bandSong.Song);
            }
        }

        //LEFT JOIN
        public static void GetSongsForAllBandsLinq1()
        {
            var bandSongsResult = from band in Bands
                            join song in Songs on band.Id equals song.BandId into bandSongs
                            from item in bandSongs.DefaultIfEmpty(new Song(0, "-", 0))
                            select new
                            {
                                Band = band.Name,
                                Song = item.Name
                            };

            foreach (var bandSong in bandSongsResult)
            {
                Console.WriteLine("Band: " + bandSong.Band + " Song:" + bandSong.Song);
            }
        }

        //LEFT JOIN
        public static void GetSongsForAllBandsLinq2()
        { 
            var bandSongsResult =
                Bands.GroupJoin(
                Songs,
                b => b.Id,
                s => s.BandId,
                (band, song) => new
                {
                    Band = band.Name,
                    Song = song.DefaultIfEmpty(new Song(0, "-", 0))
                })
                .SelectMany(a => a.Song.Select(s => new { Band = a.Band, Song = s.Name}));
            
            foreach (var bandSong in bandSongsResult)
            {
                Console.WriteLine("Band: " + bandSong.Band + " Song:" + bandSong.Song);
            }

        }

        //GROUP JOIN
        public static void GetSongsForAllBandsGroupJoin1()
        {
            var bandSongsResult = from band in Bands
                                  join song in Songs on band.Id equals song.BandId into bandSongs
                                  select new { BandName = band.Name, Songs = bandSongs };

            foreach(var band in bandSongsResult)
            {
                Console.WriteLine(band.BandName);

                foreach (var song in band.Songs)
                {
                    Console.WriteLine("---" + song.Name);
                }
            }
        }

        //GROUP JOIN
        public static void GetSongsForAllBandsGroupJoin2()
        {
            var bandSongsResult = Bands.GroupJoin(Songs, b => b.Id, s => s.BandId, (band, songs) => new { BandName = band.Name, Songs = songs});

            foreach (var band in bandSongsResult)
            {
                Console.WriteLine(band.BandName);

                foreach (var song in band.Songs)
                {
                    Console.WriteLine("---" + song.Name);
                }
            }
        }

        #endregion

        public static void ShowList(IEnumerable<Band> bands)
        {
            foreach (var band in bands)
                Console.WriteLine(band.ToString());
        }

        #region GetMembersForAllBands()

        //INNER JOIN
        public static void GetMembersForBandsLinq1()
        {
            var bandMembers = from band in Bands
                            join membru in Members on band.Id equals membru.BandId
                            select new
                            {
                                Band = band.Name,
                                membru = membru.Name
                            };

            foreach (var bandMember in bandMembers)
            {
                Console.WriteLine("Band: " + bandMember.Band + " Membru:" + bandMember.membru);
            }
        }

        //INNER JOIN
        public static void GetMembersForBandsLinq2()
        {
            var bandMembers = Bands.Join(Members, b => b.Id, s => s.BandId, (band, member) => new
            {
                Band = band.Name,
                Member = member.Name
            });

            foreach (var bandMember in bandMembers)
            {
                Console.WriteLine("Band: " + bandMember.Band + " Member :" + bandMember.Member);
            }
        }

        //LEFT JOIN
        public static void GetMembersForAllBandsLinq1()
        {
            var bandMemebersResult = from band in Bands
                                  join membru in Members on band.Id equals membru.BandId into bandMembers
                                  from item in bandMembers.DefaultIfEmpty(new Membru(0,0,"-"))
                                  select new
                                  {
                                      Band = band.Name,
                                      Member = item.Name
                                  };

            foreach (var bandMember in bandMemebersResult)
            {
                Console.WriteLine("Band: " + bandMember.Band + " Member :" + bandMember.Member);
            }
        }

        //LEFT JOIN
        public static void GetMembersForAllBandsLinq2()
        {
            var bandMembersResult =
                Bands.GroupJoin(
                Members,
                b => b.Id,
                s => s.BandId,
                (band, membru) => new
                {
                    Band = band.Name,
                    Membru = membru.DefaultIfEmpty(new Membru(0, 0,"-"))
                })
                .SelectMany(a => a.Membru.Select(s => new { Band = a.Band, Membru = s.Name }));

            foreach (var bandMember in bandMembersResult)
            {
                Console.WriteLine("Band: " + bandMember.Band + " Member:" + bandMember.Membru);
            }

        }

        //GROUP JOIN
        public static void GetMembersForAllBandsGroupJoin1()
        {
            var bandMembersResult = from band in Bands
                                  join membru in Members on band.Id equals membru.BandId into bandMembers
                                  select new { BandName = band.Name, Membru = bandMembers };

            foreach (var band in bandMembersResult)
            {
                Console.WriteLine(band.BandName);

                foreach (var membru in band.Membru)
                {
                    Console.WriteLine("---" + membru.Name);
                }
            }
        }

        //GROUP JOIN
        public static void GetMembersForAllBandsGroupJoin2()
        {
            var bandMembersResult = Bands.GroupJoin(Members, b => b.Id, s => s.BandId, (band, members) => new { BandName = band.Name, Members = members });

            foreach (var band in bandMembersResult)
            {
                Console.WriteLine(band.BandName);

                foreach (var membru in band.Members)
                {
                    Console.WriteLine("---" + membru.Name);
                }
            }
        }

        #endregion

        //HOME TODO - de creat entitatea Membru (Id, BandId, Name)
        //De implementat toate metodele de la join, group join Ex: (GetMembersForBandsLinq1)
    }
}
