using System.Linq;
using Xunit;

namespace CSharp8Demo
{
    public class IndicesAndRanges
    {
        [Fact]
        public void Index()
        {
            var words = new[]
            {

                "The",
                "quick",
                "brown",
                "fox",
                "jumped",
                "over",
                "the",
                "lazy",
                "dog"
            };

            Assert.Equal("The", words[0]);
            Assert.Equal("dog", words[^1]);

            Assert.Equal("jumped", words[4]);
            Assert.Equal("jumped", words[^5]);
        }

        [Fact]
        public void Range()
        {
            var words = new[]
            {

                "The",
                "quick",
                "brown",
                "fox",
                "jumped",
                "over",
                "the",
                "lazy",
                "dog"
            };

            Assert.Equal("The quick brown fox jumped over the lazy dog", string.Join(" ", words[0..8]));
            Assert.Equal("The quick brown fox jumped over the lazy dog", string.Join(" ", words[..8]));
            Assert.Equal("The quick brown fox jumped over the lazy dog", string.Join(" ", words[..]));

            Assert.Equal("quick brown fox jumped", string.Join(" ", words[1..4]));

            Assert.Equal("jumped over the lazy", string.Join(" ", words[^5..^2]));
        }

        [Fact]
        public void Lists()
        {
            // lists support indices but not ranges
            var words = new[]
            {

                "The",
                "quick",
                "brown",
                "fox",
                "jumped",
                "over",
                "the",
                "lazy",
                "dog"
            }.ToList();

            Assert.Equal("jumped", words[^5]);
            //Assert.Equal("jumped over the lazy", string.Join(" ", words[^5..^2]));
        }
    }
}
