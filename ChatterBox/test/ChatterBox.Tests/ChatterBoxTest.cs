using Xunit;

namespace ChatterBox
{
    public class ChatterBoxTest
    {

        [Fact]
        public void PassingTest_AlwaysTrue_ReturnsTrue()
        {
            Assert.Equal(true, true);
        }

        [Theory]
        [InlineData("Hi", "Hello")]
        [InlineData("Howdy", "Let's ride buckaroo!")]
        [InlineData("How are you?", "Fine, and you?")]
        [InlineData("Ho ho ho", "Who do you think you are, Santa?")]
        [InlineData("Exit", "Bye!")]
        public void CheckHardCodedOutput_HelloStrings_ReturnCorrectResponse(string input, string expected)
        {
            IChatterBox chatterBox = new ChatterBox();

            string actual = chatterBox.Input(input);

            Assert.Equal(expected, actual);
        }
    }
}
