using Xunit;
using Codenation.Challenge.Models;
using Codenation.Challenge;

namespace Source.Test
{
    public sealed class ChallengeModelTest : ModelBaseTest
    {
        public ChallengeModelTest()
                    : base(new CodenationContext())
        {
            Model = "Codenation.Challenge.Models.Challenge";
            Table = "challenge";
        }

        [Fact]
        public void Should_Has_Table()
        {
            AssertTable();
        }
    }
}
