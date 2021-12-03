using Academy.Week1.FinoiaLucaSpese.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Week1.FinoiaLucaSpese.Mock.Repository
{
    public class InMemoryStorages
    {
        public static List<Category> categories = new List<Category>()
        {
            new Category() { Id=1,Name = "firstCategory"},
            new Category() { Id=2,Name = "secondCategory"},
            new Category() { Id=3,Name = "thirdCategory"}
        };
        public static List<User> users = new List<User>()
        {
            new User() { Id=1, Name="Mario", Surname="Rossi"},
            new User() { Id=2, Name="Marco", Surname="Rossi"},
            new User() { Id=3, Name="Sara", Surname="Bianchi"},
        };
        public static List<Expense> expenses = new List<Expense>()
        {
            new Expense() { Id=1, Date=new DateTime(2021,11,29), Description ="descrizioneSpesa1",Amount=100,Aproved=true,CategoryId=1,UserId=1},
            new Expense() { Id=2, Date=new DateTime(2021,12,2), Description ="descrizioneSpesa2",Amount=100,Aproved=true,CategoryId=2,UserId=2},
            new Expense() { Id=3, Date=new DateTime(2021,10,29), Description ="descrizioneSpesa3",Amount=100,Aproved=false,CategoryId=3,UserId=3},
            new Expense() { Id=4, Date=new DateTime(2021,10,23), Description ="descrizioneSpesa4",Amount=100,Aproved=true,CategoryId=2,UserId=1},
            new Expense() { Id=5, Date=new DateTime(2021,11,20), Description ="descrizioneSpesa5",Amount=100,Aproved=true,CategoryId=1,UserId=2},
            new Expense() { Id=6, Date=new DateTime(2021,10,22), Description ="descrizioneSpesa6",Amount=100,Aproved=false,CategoryId=2,UserId=3},
            new Expense() { Id=7, Date=new DateTime(2021,11,23), Description ="descrizioneSpesa7",Amount=100,Aproved=true,CategoryId=1,UserId=1},
            new Expense() { Id=8, Date=new DateTime(2021,11,10), Description ="descrizioneSpesa8",Amount=100,Aproved=false,CategoryId=3,UserId=2},
            new Expense() { Id=9, Date=new DateTime(2021,12,1), Description ="descrizioneSpesa9",Amount=100,Aproved=true,CategoryId=1,UserId=3},
        };
    }
}
