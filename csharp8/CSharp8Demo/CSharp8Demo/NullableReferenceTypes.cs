using System;
using Xunit;

namespace CSharp8Demo
{
    public class NullableReferenceTypes
    {
        [Fact]
        public void NullableTest()
        {
            var test = new Test();

            DoStuffWithString(test.Value);
        }

        private void DoStuffWithString(string value)
        {
            var upperString = value.ToUpper();
            Console.WriteLine(upperString);
        }

        private class Test
        {
            public string Value { get; set; }
        }
    }
}
