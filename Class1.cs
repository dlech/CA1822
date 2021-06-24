using System.Threading;
using System.Threading.Tasks;

namespace CA1822
{
    public partial class Class1
    {
        public partial Task Example(CancellationToken token = default);
        // -----------------^
        // incorrectly triggers CA1822
    }

    partial class Class1
    {
        private readonly int timeout;

        public Class1(int timeout)
        {
            this.timeout = timeout;
        }
        
        public async partial Task Example(CancellationToken token)
        {
            await Task.Delay(timeout, token);
        }
    }
}
