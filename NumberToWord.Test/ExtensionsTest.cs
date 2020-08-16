using NUnit.Framework;
namespace NumberToWord.Test
{
    public class ExtensionsTest
    {
        [Test]
        public void ToWord_Zero_Test()
        {
            decimal number = 0;
            var word = number.ToWord().ToUpperInvariant();
            Assert.AreEqual("ZERO ONLY", word);
        }
        [Test]
        public void ToWord_Random_Number_SUCCESS_Test_1()
        {
            decimal number = 100740;
            var word = number.ToWord().ToUpperInvariant();
            Assert.AreEqual("ONE LAKH SEVEN HUNDRED FORTY ONLY", word);
        }
        [Test]
        public void ToWord_Random_Number_SUCCESS_Test_2()
        {
            decimal number = 302328.28M;
            var word = number.ToWord().ToUpperInvariant();
            Assert.AreEqual("THREE LAKH TWO THOUSAND THREE HUNDRED TWENTY EIGHT AND TWO EIGHT PAISA ONLY", word);
        }
        [Test]
        public void ToWord_Random_Number_SUCCESS_Test_3()
        {
            decimal number = 1302328;
            var word = number.ToWord().ToUpperInvariant();
            Assert.AreEqual("THIRTEEN LAKH TWO THOUSAND THREE HUNDRED TWENTY EIGHT ONLY", word);
        }
    }
}
