using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COVID19_UpdatesWebAPI.Net6.XUnitTest
{
    internal class TestInputData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { "Canada", String.Empty, default(DateTime) };
            yield return new object[] { "US", String.Empty, default(DateTime) };
            yield return new object[] { "Brazil", String.Empty, default(DateTime) };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
