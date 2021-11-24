using Microsoft.EntityFrameworkCore;
using MyMusicAppAPI.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMusicAppAPI.Database
{
    public class AppDBContext:DbContext
    {

        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {

        }
        public  DbSet<Song> Song { get; set; }
        public  DbSet<User> User { get; set; }
        public  DbSet<Category> Category { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasIndex(u => u.Username).IsUnique();
            modelBuilder.Entity<Song>().HasOne<Category>(x => x.Category).WithMany(d => d.Songs).HasForeignKey(x => x.CategoryID);
            OnModelCreatingPartial(modelBuilder);
        }
        private void OnModelCreatingPartial(ModelBuilder modelBuilder)
        {
            User admin = new User
            {
                Id = 1,
                FirstName = "admin",
                LastName = "admin",
                Email = "admin@gmail.com",
                Phone = "030222111",
                Username = "admin",

            };
            admin.PasswordSalt = HashGenerator.GenerateSalt();
            admin.PasswordHash = HashGenerator.GenerateHash(admin.PasswordSalt, "Admin1234!");

            modelBuilder.Entity<Category>().HasData(
                new Category()
                {
                    Id = 1,
                    Name = "Hip Hop"
                },
                new Category()
                {
                    Id = 2,
                    Name = "Blues"
                },
                          new Category()
                          {
                              Id = 3,
                              Name = "Rock"
                          },
                               new Category()
                               {
                                   Id = 4,
                                   Name = "Dance"
                               }
                );
            modelBuilder.Entity<Song>().HasData(
                new Song
                {
                    Id = 1,
                    Name = "Lose Yourself",
                    SongUrl = "https://www.youtube.com/watch?v=_Yhyp-_hX2s",
                    ArtistName = "Eminem",
                    CategoryID = 1,
                    EditDate = new DateTime(2021 - 11 - 20),
                    EntredDAte = new DateTime(2021 - 11 - 20),
                    isFavourite = true,
                    Rating = 5
                },

            new Song
            {
                Id = 2,
                Name = "In Da Club",
                SongUrl = "https://www.youtube.com/watch?v=5qm8PH4xAss",
                ArtistName = "50 Cent",
                CategoryID = 1,
                EditDate = new DateTime(2021, 8, 2, 9, 30, 52),
                EntredDAte = new DateTime(2021, 5, 1, 8, 30, 52),
                isFavourite = true,
                Rating = 3
            },
                new Song
                {
                    Id = 3,
                    Name = "Paint It, Black",
                    SongUrl = "https://www.youtube.com/watch?v=O4irXQhgMqg",
                    ArtistName = "The Rolling Stones",
                    CategoryID = 3,
                    EditDate = new DateTime(2008, 5, 1, 8, 30, 52),
                    EntredDAte = new DateTime(2008, 5, 1, 8, 30, 52),
                    isFavourite = false,
                    Rating = 5
                },
                    new Song
                    {
                        Id = 4,
                        Name = "Miss You",
                        SongUrl = "https://www.youtube.com/watch?v=KuRxXRuAz-I",
                        ArtistName = "The Rolling Stones",
                        CategoryID = 3,
                        EditDate = new DateTime(2008, 5, 1, 8, 30, 52),
                        EntredDAte = new DateTime(2008, 5, 1, 8, 30, 52),
                        isFavourite = false,
                        Rating = 5
                    },
                        new Song
                        {
                            Id = 5,
                            Name = "Alors On Danse",
                            SongUrl = "https://www.youtube.com/watch?v=VHoT4N43jK8",
                            ArtistName = "Stromae",
                            CategoryID = 4,
                            EditDate = new DateTime(2020, 1, 3, 5, 30, 52),
                            EntredDAte = new DateTime(2012, 2, 2, 1, 30, 52),
                            isFavourite = true,
                            Rating = 3
                        },
                   new Song
                   {
                       Id = 6,
                       Name = "This Time I'm Gone for Good",
                       SongUrl = "https://www.youtube.com/watch?v=5lrSdW8p4u4",
                       ArtistName = "Freddy Cole",
                       CategoryID = 2,
                       EditDate = new DateTime(2021, 5, 3, 2, 30, 52),
                       EntredDAte = new DateTime(2021, 5, 3, 2, 30, 52),
                       isFavourite = true,
                       Rating = 5
                   },
                        new Song
                        {
                            Id = 7,
                            Name = "House of the Rising Sun",
                            SongUrl = "https://www.youtube.com/watch?v=MOqm0qGJhpw",
                            ArtistName = "The White Buffalo",
                            CategoryID = 2,
                            EditDate = new DateTime(2021, 5, 3, 2, 30, 52),
                            EntredDAte = new DateTime(2021, 5, 3, 2, 30, 52),
                            isFavourite = false,
                            Rating = 3
                        },
                             new Song
                             {
                                 Id = 8,
                                 Name = "Not Afraid",
                                 SongUrl = "https://www.youtube.com/watch?v=j5-yKhDd64s",
                                 ArtistName = "Eminem",
                                 CategoryID = 1,
                                 EditDate = new DateTime(2021, 4, 3, 4, 30, 52),
                                 EntredDAte = new DateTime(2021, 5, 3, 2, 30, 52),
                                 isFavourite = false,
                                 Rating = 3
                             }
            );
        }
    }
}
