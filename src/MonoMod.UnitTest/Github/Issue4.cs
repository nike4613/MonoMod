extern alias New;
using New::MonoMod.RuntimeDetour;
using System;
using Xunit;
using Xunit.Abstractions;

namespace MonoMod.UnitTest.Github
{
    public class Issue4 : TestBase
    {
        public Issue4(ITestOutputHelper helper) : base(helper)
        {
        }

        [Fact]
        public void HookToStringAlwaysWorks()
        {
            // Verify that the hook is consistently applied
            using var hook = new Hook(
                typeof(object).GetMethod("ToString"), 
                (object self) => "hehe"
            );

            // Run multiple times to check consistent behavior
            for (int i = 0; i < 10; i++)
            {
                string result = new object().ToString();
                Assert.Equal("hehe", result);
            }
        }
    }
}