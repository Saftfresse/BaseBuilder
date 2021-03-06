﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseBuilder.Classes
{
    class CitizenManager
    {
        List<string> surnamesMale = new List<string>();
        List<int> surnamesMaleTaken = new List<int>();
        List<string> surnamesFemale = new List<string>();
        List<int> surnamesFemaleTaken = new List<int>();
        List<string> lastnames = new List<string>();
        List<int> lastnamesTaken = new List<int>();
        Random r = new Random();

        List<Citizen> citizens = new List<Citizen>();

        public CitizenManager()
        {
            SurnamesMale.AddRange(new[] { "Vernon", "Oliver", "Richard", "Jerome", "Brett", "Carl", "Jermaine", "Craig", "Seth", "Carter", "Delbert", "Bruce", "Joe", "Jerry", "Carlos", "Ted", "Alejandro", "Scott", "Francis", "Emmett", "Tommy", "Benny", "Glen", "Kyle", "Darren", "Louis", "Brody", "Jeremiah", "Maurice", "Billie", "Billy", "Alvin", "Victor", "Jose", "Todd", "Sean", "Bryce", "Ruben", "Charlie", "Leonard", "Samuel", "Fredrick", "Roy", "Chris", "Johnny", "Larry", "Manuel" });
            SurnamesFemale.AddRange(new[] { "Elaine", "Addie", "Evelyn", "Bessie", "Vivian", "Joy", "Kelli", "Anne", "Ava", "Sandra", "Marguerite", "Louise", "Donna", "Jackie", "Lois", "Whitney", "Renee", "Ariel", "Brianna", "Delores", "Sylvia", "Myrtle", "Elsie", "Veronica", "Sheryl", "Theresa", "Marie", "Kristin", "Riley", "Ola", "Helen", "Lucy", "Eileen", "Carla", "Rita", "Angie", "Terri", "Leah", "Rachael", "Grace", "Carolyn", "Lynda", "Gloria", "Tammy", "Jeanette", "Monique", "Monica", "Desiree", "Kara" });
            Lastnames.AddRange(new[] { "Saunders", "Reilly", "Larsen", "Heath", "Knight", "Tate", "Branch", "Hatfield", "Battle", "Watkins", "Craft", "Taylor", "Perkins", "Fischer", "Kelly", "Howe", "Frost", "Macdonald", "McKay", "Mercer", "Petersen", "Bullock", "Allen", "Nelson", "Christensen", "Snyder", "Love", "Chandler", "Simmons", "McIntosh", "McCall", "Vaughn", "Burnett", "Sampson", "Manning", "Irwin", "Green", "Stark", "Sellers", "Bright", "Garrison", "Curtis", "Morrison", "Wagner", "Osborn", "Walls", "Monroe", "Rhodes", "Farmer", "Wyatt", "Holden", "Hall", "Boyle", "Meyer", "Davis", "Gamble", "Harrison", "Downs", "McCoy", "Newton", "Greer", "Gardner", "Noble", "McBride", "Wood", "Ryan", "Robertson", "Doyle", "Flores", "Crane", "Knowles", "Hurst", "Carver", "Callahan", "Haynes", "Wolfe", "Baxter", "Lester", "McCarthy", "Fowler", "Stein", "Washington", "Richards", "McMahon", "Warren", "Vaughan", "Hopkins", "Lynn", "Cobb", "Raymond", "Lindsey", "Simpson", "Bond", "Williamson" });

        }

        string getSurName(List<string> input, List<int> taken)
        {
            int nameIndex = r.Next(0, input.Count);
            int attempts = 0;
            while (taken.FindAll(x => x == nameIndex).Count > 0 && attempts < input.Count)
            {
                nameIndex = r.Next(0, input.Count);
                attempts++;
            }
            if (attempts >= input.Count)
            {
                taken.Clear();
                nameIndex = r.Next(0, input.Count);
            }
            taken.Add(nameIndex);
            return input[nameIndex];
        }

        string getLastName()
        {
            int lastNameIndex = r.Next(0, Lastnames.Count);
            int attempts = 0;
            while (lastnamesTaken.FindAll(x => x == lastNameIndex).Count > 0 && attempts < Lastnames.Count)
            {
                lastNameIndex = r.Next(0, Lastnames.Count);
                attempts++;
            }
            if (attempts >= Lastnames.Count)
            {
                lastnamesTaken.Clear();
                lastNameIndex = r.Next(0, Lastnames.Count);
            }
            lastnamesTaken.Add(lastNameIndex);
            return lastnames[lastNameIndex];
        }

        public Citizen GetRandomCitizen()
        {
            return GetRandomCitizen(r.Next(0, 3) == 0 ? Citizen.Sex.Female : Citizen.Sex.Male);
        }

        public Citizen GetRandomCitizen(Citizen.Sex _sex)
        {
            Citizen c = new Citizen();
            c.CitizenSex = _sex;
            if (_sex == Citizen.Sex.Male)
            {
                string name = getSurName(SurnamesMale, surnamesMaleTaken) + " " + getLastName();
                c.Name = name;
                c.Story = "A normal male citizen from decent parents";
            }
            else
            {
                string name = getSurName(SurnamesFemale, surnamesFemaleTaken) + " " + getLastName();
                c.Profession = Citizen.Professions.Maid;
                c.Name = name;
                c.Story = "A normal female citizen from decent parents";
            }
            return c;
        }

        public List<string> SurnamesMale { get => surnamesMale; set => surnamesMale = value; }
        public List<string> SurnamesFemale { get => surnamesFemale; set => surnamesFemale = value; }
        public List<string> Lastnames { get => lastnames; set => lastnames = value; }
        internal List<Citizen> Citizens { get => citizens; set => citizens = value; }
    }
}
