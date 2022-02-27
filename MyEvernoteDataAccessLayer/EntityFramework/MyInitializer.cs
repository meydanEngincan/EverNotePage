using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using MyEvernoteEntities;

namespace MyEvernoteDataAccessLayer.EntityFramework
{
    public class MyInitializer : CreateDatabaseIfNotExists<DatabaseContext>
    {
        protected override void Seed(DatabaseContext context)
        {
            EvernoteUser admin = new EvernoteUser()
            {
                Name = "Engin",
                Surname = "Meydan",
                UserName = "cancan16",
                Email = "engincanmeydan95@gmail.com",
                Password = "161616",
                IsActive = true,
                IsAdmin = true,
                ActivateGuid = Guid.NewGuid(),
                CreatedOn = DateTime.Now,
                ModifiedOn = DateTime.Now.AddMinutes(5),
                ModifiedUsername = "cancan16",
            };

            EvernoteUser standartUser = new EvernoteUser()
            {
                Name = "can",
                Surname = "meydan",
                UserName = "cancan",
                Email = "engincanmeydan16@gmail.com",
                Password = "444444",
                IsActive = true,
                IsAdmin = false,
                ActivateGuid = Guid.NewGuid(),
                CreatedOn = DateTime.Now.AddHours(1),
                ModifiedOn = DateTime.Now.AddMinutes(65),
                ModifiedUsername = "cancan16",


                //Name = "Can",
                //Surname = "Meydan",
                //ActivateGuid = Guid.NewGuid(),
                //Email = "engincanmeydan16@gmail.com",
                //IsActive = true,
                //IsAdmin = false,
                //UserName = "cancan",
                //Password = "444444",
                //CreatedOn = DateTime.Now.AddHours(1),
                //ModifiedOn = DateTime.Now.AddMinutes(65),
                //ModifiedUsername = "cancan16"
            };

            context.EverNoteUsers.Add(admin);
            context.EverNoteUsers.Add(standartUser);

            for (int i = 0; i < 8; i++)
            {
                EvernoteUser user = new EvernoteUser()
                {
                    Name = FakeData.NameData.GetFirstName(),
                    Surname = FakeData.NameData.GetSurname(),
                    Email = FakeData.NetworkData.GetEmail(),
                    ActivateGuid = Guid.NewGuid(),
                    IsActive = true,
                    IsAdmin = false,
                    UserName = $"user{i}",
                    Password = "123",
                    CreatedOn = FakeData.DateTimeData.GetDatetime(DateTime.Now.AddYears(-1), DateTime.Now),
                    ModifiedOn = FakeData.DateTimeData.GetDatetime(DateTime.Now.AddYears(-1), DateTime.Now),
                    ModifiedUsername = $"user{i}",
                };

                context.EverNoteUsers.Add(user);
            }

            context.SaveChanges();
            
            List<EvernoteUser> userList = context.EverNoteUsers.ToList();



            //Adding Fake categories
            for (int i = 0; i < 10; i++)
            {
                Category cat = new Category()
                {
                    Title = FakeData.PlaceData.GetStreetName(),
                    Description = FakeData.PlaceData.GetAddress(),
                    CreatedOn = DateTime.Now,
                    ModifiedOn = DateTime.Now,
                    ModifiedUsername = "cancan16"
                };
                context.Categories.Add(cat);



                for (int k = 0; k < FakeData.NumberData.GetNumber(5, 9); k++)
                {
                    EvernoteUser owner = userList[FakeData.NumberData.GetNumber(0, userList.Count - 1)];

                    Note note = new Note()
                    {
                        Title = FakeData.TextData.GetAlphabetical(FakeData.NumberData.GetNumber(5, 25)),
                        Text = FakeData.TextData.GetSentences(FakeData.NumberData.GetNumber(1, 3)),
                        IsDraft = false,
                        LikeCount = FakeData.NumberData.GetNumber(1, 9),
                        Owner =owner,
                        CreatedOn = FakeData.DateTimeData.GetDatetime(DateTime.Now.AddYears(-1), DateTime.Now),
                        ModifiedOn = FakeData.DateTimeData.GetDatetime(DateTime.Now.AddYears(-1), DateTime.Now),
                        ModifiedUsername = owner.UserName,
                    };
                    cat.Notes.Add(note);

                    // Adding fake comments

                    for (int j = 0; j < FakeData.NumberData.GetNumber(3, 5); j++)
                    {
                        EvernoteUser comment_owner = userList[FakeData.NumberData.GetNumber(0, userList.Count - 1)];

                        Comment comment = new Comment()
                        {
                            Text = FakeData.TextData.GetSentence(),
                            Owner =comment_owner,
                            CreatedOn = FakeData.DateTimeData.GetDatetime(DateTime.Now.AddYears(-1), DateTime.Now),
                            ModifiedOn = FakeData.DateTimeData.GetDatetime(DateTime.Now.AddYears(-1), DateTime.Now),
                            ModifiedUsername = comment_owner.UserName,
                        };
                        note.Comments.Add(comment);
                    }

                    // Adding fake likes

                    for (int m = 0; m < note.LikeCount; m++)
                    {

                        Liked like = new Liked()
                        {
                            LikedUser = userList[m]
                        };
                        note.Likes.Add(like);
                    }
                }
            }

            context.SaveChanges();
        }

    }
}
