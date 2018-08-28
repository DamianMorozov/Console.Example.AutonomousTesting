using NSubstitute;
using NUnit.Framework;
using System;

namespace ExampleNSubstitute
{
    [TestFixture]
    public class ClassPersonTest
    {
        [Test]
        public void MakeTest()
        {
            TestContext.WriteLine(@"--------------------------------------------------------------------------------");
            var person = Substitute.For<ClassPerson>(@"Name 1", 11);
            TestContext.WriteLine(@"var person = Substitute.For<ClassPerson>(""Name 1"", 11);");
            TestContext.WriteLine(@"--------------------------------------------------------------------------------");

            TestContext.WriteLine(@"The properties have values from constructor:");
            TestContext.WriteLine(@"- person.Guid = " + Convert.ToString(person.Guid));
            TestContext.WriteLine(@"- person.Name = " + person.Name);
            TestContext.WriteLine(@"- person.Age = " + person.Age);
            TestContext.WriteLine(@"The methods have default values:");
            TestContext.WriteLine(@"- person.GetGuid() = " + person.GetGuid());
            TestContext.WriteLine(@"- person.GetName() = " + person.GetName());
            TestContext.WriteLine(@"- person.GetAge() = " + person.GetAge());

            TestContext.WriteLine(@"--------------------------------------------------------------------------------");
            TestContext.WriteLine(@"Set returns values for methods:");
            person.GetGuid().Returns(new Guid());
            TestContext.WriteLine(@"- person.GetId().Returns(new Guid());");
            person.GetName().Returns(@"Name 2");
            TestContext.WriteLine(@"- person.GetName().Returns(""Name 2"");");
            person.GetAge().Returns(22);
            TestContext.WriteLine(@"- person.GetAge().Returns(22);");
            TestContext.WriteLine(@"Get new values from methods:");
            TestContext.WriteLine(@"- person.person.GetId() = " + Convert.ToString(person.GetGuid()));
            TestContext.WriteLine(@"- person.GetName() = " + person.GetName());
            TestContext.WriteLine(@"- person.GetAge() = " + person.GetAge());

            TestContext.WriteLine();
            TestContext.WriteLine(@"--------------------------------------------------------------------------------");
            var partialPerson = Substitute.ForPartsOf<ClassPerson>(@"Name 3", 33);
            TestContext.WriteLine(@"var partialPerson = Substitute.ForPartsOf<ClassPerson>(""Name 3"", 33);");
            TestContext.WriteLine(@"--------------------------------------------------------------------------------");

            TestContext.WriteLine(@"The properties have values from constructor:");
            TestContext.WriteLine(@"- partialPerson.Id = " + Convert.ToString(partialPerson.Guid));
            TestContext.WriteLine(@"- partialPerson.Name = " + partialPerson.Name);
            TestContext.WriteLine(@"- partialPerson.Age = " + partialPerson.Age);
            TestContext.WriteLine(@"The methods have values from constructor:");
            TestContext.WriteLine(@"- partialPerson.GetId() = " + Convert.ToString(partialPerson.GetGuid()));
            TestContext.WriteLine(@"- partialPerson.GetName() = " + partialPerson.GetName());
            TestContext.WriteLine(@"- partialPerson.GetAge() = " + partialPerson.GetAge());
        }
    }
}
