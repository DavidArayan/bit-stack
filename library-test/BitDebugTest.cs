using System;

#if !UNITY_EDITOR
using Xunit;
#endif

using CoreGDX.BitStack.Debug;

/**
 * Test harness for testing the MortonKey10x3 functionality
 * See MortonKey10x3.completionlist for details
 */
namespace CoreGDX.BitStack.Test.Debug {
    public class BitDebugTest {

#if !UNITY_EDITOR
        [Fact]
#else
        [Test]
#endif
        public void ExceptionType_ShouldPass() {
			// checks to ensure the Exception type being thrown by BitDebug
			// is consistent as other tests will use this exception type
			// for checking
			Assert.Throws<Exception>(() => BitDebug.Exit("Test"));
        }
    }
}
