﻿using SacriArt.Models.ShopModels;

namespace SacriArt.Domain
{
    public class AppDbInitializer
    {

        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope()) {

                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                context.Database.EnsureCreated();

                //Authors
                if (!context.Authors.Any())
                {
                    context.Authors.AddRange(new List<Author>()
                    {   
                        new Author()
                        {
                            FullName = "Eduard Kolodiy",
                            Bio = "Bio of Eduard Kolodiy"
                        },

                        new Author()
                        {
                            FullName = "Dmitry Kavsan",
                            Bio = "Bio of Dmitry Kavsan"
                        },

                        new Author()
                        {
                            FullName = "Maria Ospischeva-Pavlishin",
                            Bio = "Bio of Maria Ospischeva-Pavlishin"
                        },

                        new Author()
                        {
                            FullName = "Tatiana Kolesnik",
                            Bio = "Bio of Tatiana Kolesnik"
                        },

                        new Author()
                        {
                            FullName = "Ave",
                            Bio = "Bio of Ave"
                        },

                        new Author()
                        {
                            FullName = "Andriy Bludov",
                            Bio = "Bio of Andriy Bludov"
                        },

                        new Author()
                        {
                            FullName = "Lyudmila Rashtanova",
                            Bio = "Bio of Lyudmila Rashtanova"
                        },

                        new Author()
                        {
                            FullName = "Vadim Bondarenko",
                            Bio = "Bio of Vadim Bondarenko"
                        },

                        new Author()
                        {
                            FullName = "Alexander Roitburd",
                            Bio = "Bio of Alexander Roitburd"
                        },

                        new Author()
                        {
                            FullName = "Igor Gusev",
                            Bio = "Bio of Igor Gusev"
                        },

                        new Author()
                        {
                            FullName = "Vasyl Bazhai",
                            Bio = "Bio of Vasyl Bazhai"
                        },

                        new Author()
                        {
                            FullName = "Marina Skugareva",
                            Bio = "Bio of Marina Skugareva"
                        },

                        new Author()
                        {
                            FullName = "Petro Bevza",
                            Bio = "Bio of Petro Bevza"
                        }
                                     
                    });

                    context.SaveChanges();
                }

                //Styles
                if (!context.Styles.Any())
                {
                    context.Styles.AddRange(new List<Style>()
                    {
                        new Style ()
                        {
                            Name = "surrealism"
                        },

                        new Style ()
                        {
                            Name = "postmodernism"
                        },

                        new Style ()
                        {
                            Name = "abstractionism"
                        }

                    });

                    context.SaveChanges();
                }

                //ExhibitionTitles
                if (!context.ExhibitionTitles.Any())
                {
                    context.ExhibitionTitles.AddRange(new List<ExhibitionTitle>()
                    {
                        new ExhibitionTitle()
                        {
                            Name = "Surrealism as an attempt to escape"
                        },

                        new ExhibitionTitle()
                        {
                            Name = "Understand yourself and society"
                        },

                        new ExhibitionTitle()
                        {
                            Name = "Thought as emotion"
                        }
                       
                    });

                    context.SaveChanges();
                }

                //Paintings
                if (!context.Paintings.Any())
                {
                    context.Paintings.AddRange(new List<Painting>()
                    {
                         //surrealism
                        new Painting()
                        {
                            Name = "Self-sacrifice in the name of the ideal",
                            Year = 2012,
                            ImageUrl = "../img/Surrealism/Self-sacrifice.jpg",
                            ExhibitionTitleId = 1,
                            AuthorId = 1,
                            Size = "140 x 240 cm",
                            StyleId = 1,
                            Price = 17000
                        },

                        new Painting()
                        {
                            Name = "Water",
                            Year = 2008,
                            ImageUrl = "../img/Surrealism/Water.jpg",
                            ExhibitionTitleId = 1,
                            AuthorId = 2,
                            Size = "80 x 60 cm",
                            StyleId = 1,
                            Price = 5400
                        },

                        new Painting()
                        {
                            Name = "Seafood at the Opera",
                            Year = 2008,
                            ImageUrl = "../img/Surrealism/Seafood.jpg",
                            ExhibitionTitleId = 1,
                            AuthorId = 2,
                            Size = "150 x 200 cm",
                            StyleId = 1,
                            Price = 7300
                        },


                        new Painting()
                        {
                            Name = "I love that",
                            Year = 2014,
                            ImageUrl = "../img/Surrealism/love.jpg",
                            ExhibitionTitleId = 1,
                            AuthorId = 3,
                            Size = "175 x 170 cm",
                            StyleId = 1,
                            Price = 3900
                        },

                        new Painting()
                        {
                            Name = "Reflection II",
                            Year = 2011,
                            ImageUrl = "../img/Surrealism/Reflection.jpg",
                            ExhibitionTitleId = 1,
                            AuthorId = 4,
                            Size = "120 x 120 cm",
                            StyleId = 1,
                            Price = 1200
                        },

                        new Painting()
                        {
                            Name = "From the series EAM",
                            Year = 2012,
                            ImageUrl = "../img/Surrealism/EAM.jpg",
                            ExhibitionTitleId = 1,
                            AuthorId = 5,
                            Size = "60 x 60 cm",
                            StyleId = 1,
                            Price = 600
                        },

                        //postmodernism
                        new Painting()
                        {
                            Name = "Zeppelin",
                            Year = 2016,
                            ImageUrl = "../img/Postmodernism/Zeppelin.jpg",
                            ExhibitionTitleId = 2,
                            AuthorId = 6,
                            Size = "120 x 100 cm",
                            StyleId = 2,
                            Price = 4400
                        },

                        new Painting()
                        {
                            Name = "UFO",
                            Year = 2015,
                            ImageUrl = "../img/Postmodernism/UFO.jpg",
                            ExhibitionTitleId = 2,
                            AuthorId = 7,
                            Size = "120 x 100 cm",
                            StyleId = 2,
                            Price = 4700
                        },

                        new Painting()
                        {
                            Name = "Transition I",
                            Year = 2016,
                            ImageUrl = "../img/Postmodernism/Transition.jpg",
                            ExhibitionTitleId = 2,
                            AuthorId = 6,
                            Size = "60 x 60 cm",
                            StyleId = 2,
                            Price = 1350
                        },

                        new Painting()
                        {
                            Name = "Survival Technique",
                            Year = 2013,
                            ImageUrl = "../img/Postmodernism/survival.jpg",
                            ExhibitionTitleId = 2,
                            AuthorId = 8,
                            Size = "92 x 120 cm",
                            StyleId = 2,
                            Price = 3150
                        },

                        new Painting()
                        {
                            Name = "Portrait of old Slav",
                            Year = 2013,
                            ImageUrl = "../img/Postmodernism/Slav.jpg",
                            ExhibitionTitleId = 2,
                            AuthorId = 9,
                            Size = "170 x 140 cm",
                            StyleId = 2,
                            Price = 8900
                        },

                        new Painting()
                        {
                            Name = "Geography lesson",
                            Year = 2016,
                            ImageUrl = "../img/Postmodernism/lesson.jpg",
                            ExhibitionTitleId = 2,
                            AuthorId = 10,
                            Size = "120 x 90 cm",
                            StyleId = 2,
                            Price = 10200
                        },

                        //abstractionism
                        new Painting()
                        {
                            Name = "DB11",
                            Year = 1991,
                            ImageUrl = "../img/Abstractionism/DB11.jpg",
                            ExhibitionTitleId = 3,
                            AuthorId = 11,
                            Size = "180 x 290 cm",
                            StyleId = 3,
                            Price = 22000
                        },

                        new Painting()
                        {
                            Name = "Falcon",
                            Year = 1999,
                            ImageUrl = "../img/Abstractionism/Falcon.jpg",
                            ExhibitionTitleId = 3,
                            AuthorId = 12,
                            Size = "35 x 61 cm",
                            StyleId = 3,
                            Price = 2150
                        },


                        new Painting()
                        {
                            Name = "Faust",
                            Year = 2009,
                            ImageUrl = "../img/Abstractionism/Falcon.jpg",
                            ExhibitionTitleId = 3,
                            AuthorId = 13,
                            Size = "140 x 130 cm",
                            StyleId = 3,
                            Price = 9600
                        },


                        new Painting()
                        {
                            Name = "Find me",
                            Year = 2009,
                            ImageUrl = "../img/Abstractionism/Find me.jpg",
                            ExhibitionTitleId = 3,
                            AuthorId = 13,
                            Size = "160 x 120 cm",
                            StyleId = 3,
                            Price = 6000
                        },

                        new Painting()
                        {
                            Name = "No title",
                            Year = 2015,
                            ImageUrl = "../img/Abstractionism/notitle.jpg",
                            ExhibitionTitleId = 3,
                            AuthorId = 11,
                            Size = "200 x 180 cm",
                            StyleId = 3,
                            Price = 16000
                        },

                        new Painting()
                        {
                            Name = "Intervention 11",
                            Year = 2015,
                            ImageUrl = "../img/Abstractionism/Find me.jpg",
                            ExhibitionTitleId = 3,
                            AuthorId = 11,
                            Size = "71 x 95 cm",
                            StyleId = 3,
                            Price = 4000
                        },

                    });

                    context.SaveChanges();
                }

            }


        }



    }
}
