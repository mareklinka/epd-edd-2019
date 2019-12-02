using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace CSharp8Demo
{
    public class AsyncStreams
    {
        private readonly ITestOutputHelper _output;

        public AsyncStreams(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void SyncTest()
        {
            var factory = new Factory();
            foreach (var v in factory.GetValues())
            {
                _output.WriteLine(v + $" on thread [{Thread.CurrentThread.ManagedThreadId}]");
            }
        }

        [Fact]
        public async Task AsyncTest()
        {
            var factory = new AsyncFactory();
            await foreach (var v in factory.GetValuesAsync())
            {
                _output.WriteLine(v + $" on thread [{Thread.CurrentThread.ManagedThreadId}]");
            }
        }

        private class Factory
        {
            public IEnumerable<string> GetValues()
            {
                for (var i = 0; i < 10; ++i)
                {
                    Task.Delay(1000).Wait();

                    yield return i.ToString();
                }
            }
        }

        private class AsyncFactory
        {
            public async IAsyncEnumerable<string> GetValuesAsync()
            {
                for (var i = 0; i < 10; ++i)
                {
                    await Task.Delay(1000);

                    yield return i.ToString();
                }
            }
        }
    }
}
