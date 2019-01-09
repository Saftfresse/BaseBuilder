using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseBuilder.Classes
{
    class Citizen
    {
        string name;
        string story;
        double health = 100.0;
        double happiness = 75.0;
        Building house;
        Sex sex = Sex.Male;
        Professions profession = Professions.Builder;

        public enum Professions
        {
            Smith,
            Guard,
            Builder,
            Maid
        }

        public enum Sex
        {
            Male,
            Female
        }

        public Citizen()
        {

        }

        public string Name { get => name; set => name = value; }
        public string Story { get => story; set => story = value; }
        public double Health { get => health; set => health = value; }
        public double Happiness { get => happiness; set => happiness = value; }
        public Sex CitizenSex { get => sex; set => sex = value; }
        internal Professions Profession { get => profession; set => profession = value; }
        internal Building House { get => house; set => house = value; }
    }
}
