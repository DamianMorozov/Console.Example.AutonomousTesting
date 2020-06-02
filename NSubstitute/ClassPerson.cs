using System;

namespace ExampleNSubstituteTests
{
    public class ClassPerson
    {
        public Guid Guid { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public virtual Guid GetGuid()
        {
            return Guid;
        }

        public virtual string GetName()
        {
            return Name;
        }

        public virtual int GetAge()
        {
            return Age;
        }

        public ClassPerson(string name, int age)
        {
            Guid = new Guid();
            Name = name;
            Age = age;
        }
    }
}
