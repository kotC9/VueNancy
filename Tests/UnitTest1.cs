using System;
using Xunit;

namespace VueNancy.XUnitTest
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            int a = 5;
            if (a == 5)
                return;
            int b = 3;
        }
    }
}
