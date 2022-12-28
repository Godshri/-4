using System.Globalization;
using Задание_1;

var user1 = new User("WildLandowner", "Mikhail", "Saltykov-Shchedrin", "wild@gmail.com",
                     Functions.StringToDateTime("27-01-1826"),
                     Functions.StringToDateTime("10-05-1889"));

Console.WriteLine(user1.ToString());

User user2 = User.FillingObjectFromString("Dumas, Alexander, Pushkin, ironmask@gmail.com, 06-06-1799");
Console.WriteLine(user2.ToString());

User user3 = User.FillingObjectFromString("TheArtOfDreaming, Carlos , Castaneda, leonid@gmail.com, 25-12-1925");
Console.WriteLine(user3.ToString());



Console.ReadLine();