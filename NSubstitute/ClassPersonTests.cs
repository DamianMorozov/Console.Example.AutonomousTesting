using NSubstitute;
using NUnit.Framework;
using System;

namespace ExampleNSubstituteTests
{
    [TestFixture]
    public class ClassPersonTests
    {
        private ClassPerson _person1;
        private ClassPerson _person2;

        /// <summary>
        /// Setup Design pattern Singleton and private fields
        /// </summary>
        [SetUp]
        public void Setup()
        {
            TestContext.WriteLine(@"--------------------------------------------------------------------------------");
            TestContext.WriteLine(@"Setup:");
            _person1 = Substitute.For<ClassPerson>(@"Name 1", 11);
            TestContext.WriteLine($@"{nameof(_person1)} = Substitute.For<ClassPerson>(@""Name 1"", 11);");
            _person2 = Substitute.ForPartsOf<ClassPerson>(@"Name 3", 33);
            TestContext.WriteLine($@"{nameof(_person2)} = Substitute.ForPartsOf<ClassPerson>(@""Name 3"", 33);");
            TestContext.WriteLine(@"--------------------------------------------------------------------------------");
        }

        /// <summary>
        /// Reset Design pattern Singleton and private fields to default state
        /// </summary>
        [TearDown]
        public void Teardown()
        {
            _person1 = null;
            _person2 = null;
        }

        [Test]
        public void Substitute_For()
        {
            TestContext.WriteLine(@"The properties have values from constructor:");
            TestContext.WriteLine($@"- {nameof(_person1)}.Guid = " + Convert.ToString(_person1.Guid));
            TestContext.WriteLine($@"- {nameof(_person1)}.Name = " + _person1.Name);
            TestContext.WriteLine($@"- {nameof(_person1)}.Age = " + _person1.Age);
            TestContext.WriteLine(@"The methods have default values:");
            TestContext.WriteLine($@"- {nameof(_person1)}.GetGuid() = " + _person1.GetGuid());
            TestContext.WriteLine($@"- {nameof(_person1)}.GetName() = " + _person1.GetName());
            TestContext.WriteLine($@"- {nameof(_person1)}.GetAge() = " + _person1.GetAge());

            TestContext.WriteLine(@"--------------------------------------------------------------------------------");
            TestContext.WriteLine(@"Set returns values for methods:");
            _person1.GetGuid().Returns(new Guid());
            TestContext.WriteLine($@"- {nameof(_person1)}.GetId().Returns(new Guid());");
            _person1.GetName().Returns(@"Name 2");
            TestContext.WriteLine($@"- {nameof(_person1)}.GetName().Returns(""Name 2"");");
            _person1.GetAge().Returns(22);
            TestContext.WriteLine($@"- {nameof(_person1)}.GetAge().Returns(22);");
            TestContext.WriteLine(@"Get new values from methods:");
            TestContext.WriteLine($@"- {nameof(_person1)}.person.GetId() = " + Convert.ToString(_person1.GetGuid()));
            TestContext.WriteLine($@"- {nameof(_person1)}.GetName() = " + _person1.GetName());
            TestContext.WriteLine($@"- {nameof(_person1)}.GetAge() = " + _person1.GetAge());

            TestContext.WriteLine(@"--------------------------------------------------------------------------------");
            TestContext.WriteLine(@"The properties have values from constructor:");
            TestContext.WriteLine($@"- {nameof(_person2)}.Id = " + Convert.ToString(_person2.Guid));
            TestContext.WriteLine($@"- {nameof(_person2)}.Name = " + _person2.Name);
            TestContext.WriteLine($@"- {nameof(_person2)}.Age = " + _person2.Age);
            TestContext.WriteLine(@"The methods have values from constructor:");
            TestContext.WriteLine($@"- {nameof(_person2)}.GetId() = " + Convert.ToString(_person2.GetGuid()));
            TestContext.WriteLine($@"- {nameof(_person2)}.GetName() = " + _person2.GetName());
            TestContext.WriteLine($@"- {nameof(_person2)}.GetAge() = " + _person2.GetAge());

            TestContext.WriteLine(@"--------------------------------------------------------------------------------");
            TestContext.WriteLine(@"Set returns values for methods:");
            _person2.GetGuid().Returns(new Guid());
            TestContext.WriteLine($@"- {nameof(_person2)}.GetId().Returns(new Guid());");
            _person2.GetName().Returns(@"Name 2");
            TestContext.WriteLine($@"- {nameof(_person2)}.GetName().Returns(""Name 2"");");
            _person2.GetAge().Returns(22);
            TestContext.WriteLine($@"- {nameof(_person2)}.GetAge().Returns(22);");
            TestContext.WriteLine(@"Get new values from methods:");
            TestContext.WriteLine($@"- {nameof(_person2)}.person.GetId() = " + Convert.ToString(_person1.GetGuid()));
            TestContext.WriteLine($@"- {nameof(_person2)}.GetName() = " + _person1.GetName());
            TestContext.WriteLine($@"- {nameof(_person2)}.GetAge() = " + _person1.GetAge());
        }

        [Test]
        public void ClassPersonIsNull_CompareAgeWithZero_IsFalse()
        {
            ClassPerson person = null;
            TestContext.WriteLine(@"ClassPerson person = null;");
            TestContext.WriteLine(@"ClassPerson person.Age: " + person?.Age);
            TestContext.WriteLine(@"--------------------------------------------------------------------------------");

            var result = false;
            if (person?.Age > 0)
                result = true;
            TestContext.WriteLine(@"person?.Age > 0  -- " + result);
            Assert.IsFalse(result);

            result = false;
            if (person?.Age > -1)
                result = true;
            TestContext.WriteLine(@"person?.Age > -1  -- " + result);
            Assert.IsFalse(result);

            result = false;
            if (person?.Age == null)
                result = true;
            TestContext.WriteLine(@"person?.Age == null  -- " + result);
            Assert.IsTrue(result);
        }

        /// <summary>
        /// Create new object
        /// </summary>
        /// <returns></returns>
        public ClassPerson MakePerson()
        {
            var person = new ClassPerson(@"Name", 30);
            return person;
        }

        [Test]
        public void ClassPersonIsMake_CompareAgeWithZero_IsTrue()
        {
            ClassPerson person = MakePerson();
            TestContext.WriteLine(@"ClassPerson person = MakePerson();");
            TestContext.WriteLine(@"ClassPerson person.Age: " + person?.Age);
            TestContext.WriteLine(@"--------------------------------------------------------------------------------");

            var result = false;
            if (person?.Age > 0)
                result = true;
            TestContext.WriteLine(@"person?.Age > 0  -- " + result);
            Assert.IsTrue(result);
        }
    }
}
