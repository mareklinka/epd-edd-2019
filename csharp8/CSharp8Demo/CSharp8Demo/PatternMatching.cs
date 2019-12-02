using Xunit;

namespace CSharp8Demo
{
    public class PatternMatching
    {
        [Fact]
        public void PositionalPattern()
        {
            var r = new Rectagle { X = 12, Y = 12, H = 9, W = 2 };
            var isNiceSquare = r is (_, _, 12, 12);
            Assert.False(isNiceSquare);

            r = new Rectagle { X = 12, Y = 12, H = 9, W = 2 };
            var isAt12 = r is (12, 12, _, _);
            Assert.True(isAt12);
        }

        [Fact]
        public void PropertyPattern()
        {
            var r = new Rectagle { X = 12, Y = 12, H = 9, W = 2 };
            var isNiceSquare = r is { W: 12, H: 12 };
            Assert.False(isNiceSquare);

            r = new Rectagle { X = 12, Y = 12, H = 9, W = 2 };
            var isAt12 = r is { X: 12, Y: 12};
            Assert.True(isAt12);
        }

        [Fact]
        public void SwitchExpression()
        {
            object o  = new Rectagle();

            var someValue = o switch
            {
                Rectagle r => r switch
                {
                    _ when r.W == r.H => 0,
                    _ => 1
                },
                Ellipse e => 2,
                _ => -1
            };

            Assert.Equal(0, someValue);
        }

        [Fact]
        public void TuplePattern()
        {
            var tuple = ("a", "B");

            var x = tuple switch
            {
                ("a", "c") => "ac",
                ("v", _) => "v_",
                var (one, two) when one == two => "equal",
                _ => "nope"
            };

            Assert.Equal("nope", x);
        }

        private class Rectagle
        {
            public int X { get; set; }
            public int Y { get; set; }
            public int W { get; set; }
            public int H { get; set; }

            public void Deconstruct(out int x, out int y, out int w, out int h)
            {
                x = X;
                y = Y;
                h = H;
                w = W;
            }
        }

        private class Ellipse
        {
            public int X { get; set; }
            public int Y { get; set; }
            public int D { get; set; }

            public void Deconstruct(out int x, out int y, out int d)
            {
                x = X;
                y = Y;
                d = D;
            }
        }
    }
}
