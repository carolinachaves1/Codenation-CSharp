using Xunit;
using Codenation.Challenge.Models;
using Codenation.Challenge;

namespace Source.Test
{
    public sealed class UserModelTest : ModelBaseTest
    {
        public UserModelTest()
                    : base(new CodenationContext())
        {
            Model = "Codenation.Challenge.Models.User";
            Table = "user";
        }

        [Fact]
        public void Should_Has_Table()
        {
            AssertTable();
        }
    }
}
