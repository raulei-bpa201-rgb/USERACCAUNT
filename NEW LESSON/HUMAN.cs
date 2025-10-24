using System;
namespace HUMAN
{
    public class Human
    {

        public string name;

        public string surname;

        public int age;

        public string gender;

        public string nation;

        public Human(string name, string surname,int age, string gender, string nation) 
        { 
            this.name = name;
            this.surname = surname;
            this.age = age;
            this.gender = gender;
            this.nation = nation;
        }   

        public void getFullName()
        {
            Console.WriteLine($"{name} {surname}");
        }

        public int getBirthYear()
        {
            DateTime currentDateTime = DateTime.Now;

            int currentYear = currentDateTime.Year;

            return currentYear - this.age;
        }
    }
}
