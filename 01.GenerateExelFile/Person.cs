using System;

namespace _01.GenerateExelFile
{
    public class Person
    {
        private string name;
        private int age;
        private int score;
        public Person(string name, int age, int score)
        {
            this.Name = name;
            this.Age = age;
            this.Score = score;
        }
        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if(string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Name cannot be null, empty or white space!");
                }
                this.name = value;
            }
        }
        public int Age
        {
            get
            {
                return this.age;
            }
            set
            {
                if(value < 20 || value > 80)
                {
                    throw new ArgumentOutOfRangeException("Age cannot be less than 20 and more than 80");
                }
                this.age = value;
            }
        }
        public int Score
        {
            get
            {
                return this.score;
            }
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentOutOfRangeException("Score cannot be negative or more than 100");
                }
                this.score = value;
            }
        }
    }
}
