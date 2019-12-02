using Xunit;

namespace CSharp8Demo
{
    // note to self: disable resharper, it's highly confused here
    public class DefaultInterfaceMembers
    {
        [Fact]
        public void Test()
        {
            IDefaultInterface x = new Instance();

            Assert.Equal(10, x.MyMethod());

            x.MyMethod();
            IDefaultInterface.SetWhatThe(12);

            Assert.Equal(12, x.MyMethod());

            IDefaultInterface y = new OtherInstance();
            Assert.Equal(17, y.MyMethod());
        }

        public class Instance : IDefaultInterface
        {

        }

        public class OtherInstance : IDefaultInterface
        {
            public int MyMethod()
            {
                return 17;
            }
        }

        public interface IDefaultInterface
        {
            private static int WhatThe = 10;

            int MyMethod()
            {
                return WhatThe;
            }

            static void SetWhatThe(int x)
            {
                WhatThe = x;
            }
        }
    }
}
