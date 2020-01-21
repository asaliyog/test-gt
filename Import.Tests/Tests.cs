using NUnit.Framework;
using Import.Services;
namespace Import.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }



        [Test]
        public void TestCommandObjectCreation()
        {
            CommandValidation coc = new CommandValidation();
            var response = coc.Validate("import yogesh 1.json");
            Assert.IsTrue(response.Length == 3);
        }
    }
}