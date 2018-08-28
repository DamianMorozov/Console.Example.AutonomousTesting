using NSubstitute;
using NUnit.Framework;
using System;

namespace ExampleNSubstitute
{
    [TestFixture]
    public class ClassPersonTest
    {
        private ClassPerson _person1;
        private ClassPerson _person2;

        [SetUp]
        public void Setup()
        {
            TestContext.WriteLine(@"--------------------------------------------------------------------------------");
            _person1 = Substitute.For<ClassPerson>(@"Name 1", 11);
            TestContext.WriteLine(@"var " + nameof(_person1) + @" = Substitute.For<ClassPerson>(""Name 1"", 11);");
            _person2 = Substitute.ForPartsOf<ClassPerson>(@"Name 3", 33);
            TestContext.WriteLine(@"var " + nameof(_person2) + @" = Substitute.ForPartsOf<ClassPerson>(""Name 3"", 33);");
            TestContext.WriteLine(@"--------------------------------------------------------------------------------");
        }

        [TearDown]
        public void Teardown()
        {
            _person1 = null;
            _person2 = null;
            // Set up default state for Design pattern Singleton
        }

        [Test]
        public void MakeTest()
        {
            TestContext.WriteLine(@"The properties have values from constructor:");
            TestContext.WriteLine(@"- " + nameof(_person1) + @".Guid = " + Convert.ToString(_person1.Guid));
            TestContext.WriteLine(@"- " + nameof(_person1) + @".Name = " + _person1.Name);
            TestContext.WriteLine(@"- " + nameof(_person1) + @".Age = " + _person1.Age);
            TestContext.WriteLine(@"The methods have default values:");
            TestContext.WriteLine(@"- " + nameof(_person1) + @".GetGuid() = " + _person1.GetGuid());
            TestContext.WriteLine(@"- " + nameof(_person1) + @".GetName() = " + _person1.GetName());
            TestContext.WriteLine(@"- " + nameof(_person1) + @".GetAge() = " + _person1.GetAge());

            TestContext.WriteLine(@"--------------------------------------------------------------------------------");
            TestContext.WriteLine(@"Set returns values for methods:");
            _person1.GetGuid().Returns(new Guid());
            TestContext.WriteLine(@"- " + nameof(_person1) + @".GetId().Returns(new Guid());");
            _person1.GetName().Returns(@"Name 2");
            TestContext.WriteLine(@"- " + nameof(_person1) + @".GetName().Returns(""Name 2"");");
            _person1.GetAge().Returns(22);
            TestContext.WriteLine(@"- " + nameof(_person1) + @".GetAge().Returns(22);");
            TestContext.WriteLine(@"Get new values from methods:");
            TestContext.WriteLine(@"- " + nameof(_person1) + @".person.GetId() = " + Convert.ToString(_person1.GetGuid()));
            TestContext.WriteLine(@"- " + nameof(_person1) + @".GetName() = " + _person1.GetName());
            TestContext.WriteLine(@"- " + nameof(_person1) + @".GetAge() = " + _person1.GetAge());

            TestContext.WriteLine(@"--------------------------------------------------------------------------------");
            TestContext.WriteLine(@"The properties have values from constructor:");
            TestContext.WriteLine(@"- " + nameof(_person2) + @".Id = " + Convert.ToString(_person2.Guid));
            TestContext.WriteLine(@"- " + nameof(_person2) + @".Name = " + _person2.Name);
            TestContext.WriteLine(@"- parti" + nameof(_person2) + @"alPerson.Age = " + _person2.Age);
            TestContext.WriteLine(@"The methods have values from constructor:");
            TestContext.WriteLine(@"- " + nameof(_person2) + @".GetId() = " + Convert.ToString(_person2.GetGuid()));
            TestContext.WriteLine(@"- " + nameof(_person2) + @".GetName() = " + _person2.GetName());
            TestContext.WriteLine(@"- " + nameof(_person2) + @".GetAge() = " + _person2.GetAge());
        }
    }
}
