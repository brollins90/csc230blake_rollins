//using Xunit;

//namespace ChatterBox
//{
//    public class ChatterBoxTest
//    {

//        [Fact]
//        public void PassingTest_AlwaysTrue_ReturnsTrue()
//        {
//            Assert.Equal(true, true);
//        }

//        //[Theory]
//        //[InlineData("Hi", "Hello")]
//        //[InlineData("Howdy", "Let's ride buckaroo!")]
//        //[InlineData("How are you?", "Fine, and you?")]
//        //[InlineData("Ho ho ho", "Who do you think you are, Santa?")]
//        //[InlineData("Exit", "Bye!")]
//        //public void CheckHardCodedOutput_HelloStrings_ReturnCorrectResponse(string input, string expected)
//        //{
//        //    IChatterBox chatterBox = new ChatterBox();

//        //    string actual = chatterBox.ProcessString(input);

//        //    Assert.Equal(expected, actual);
//        //}

//        [Theory]
//        [InlineData("Hello", "Hi")]
//        [InlineData("Hellooo", "Hi")]
//        [InlineData("Howdy", "Let's Ride!")]
//        [InlineData("How do you do?", "I do fine, and you?")]
//        [InlineData("Ho", "You must be quite the jolly person")]
//        [InlineData("Ho ho ho", "You must be quite the jolly person")]
//        [InlineData("Exit", "Bye!")]
//        [InlineData("Blake", "Tell me about yourself")]
//        public void CheckHardCodedOutput_HelloStrings2_ReturnCorrectResponse(string input, string expected)
//        {
//            IChatterBox chatterBox = new ChatterBox();

//            string actual = chatterBox.ProcessString(input);

//            Assert.Equal(expected, actual);
//        }
//    }
//}
