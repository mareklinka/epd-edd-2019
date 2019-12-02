using System;
using System.IO;
using Xunit;

namespace CSharp8Demo
{
    public class SyntacticSugar
    {
        [Fact]
        public void UsingDeclaration()
        {
            using var ms = new MemoryStream();
        }

        [Fact]
        public void NullCoalescingOperator()
        {
            var x = GetValue();
            x = x ?? string.Empty;
            Assert.NotNull(x);

            var y = GetValue();
            y ??= string.Empty;
            Assert.NotNull(y);
        }

        private string GetValue()
        {
            return null;
        }

        [Fact]
        public void StaticLocalFunctions()
        {
            var x = 12;
            
            DoStuff();
            Assert.Equal(12, 13);

            void DoStuff()
            {
                Console.Write("Did stuff" + x);
                x = 13;
            }
        }
    }
}
