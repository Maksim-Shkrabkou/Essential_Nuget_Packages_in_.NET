using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace FluentAssertionsTutorial
{
    public class ValidationExamples
    {
        private List<string> _nameList = new List<string>
        {
            "Max", "Nick", "Theodore", "Artas"
        };

        [Fact]
        public void ShouldContainItemInList()
        {
            _nameList.Should().Contain("Max");
            _nameList.Should().ContainMatch("Theo*");
            _nameList[0].Should().BeEquivalentTo("MAX");
        }

        [Fact]
        public void ShouldNotContainItemInList()
        {
            _nameList.Should().NotContain("Harry");
        }
    }
}