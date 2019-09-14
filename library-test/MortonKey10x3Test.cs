using System;

#if !UNITY_EDITOR
using Xunit;
#endif

using CoreGDX.BitStack.Indexing;

/**
 * Test harness for testing the MortonKey10x3 functionality
 * See MortonKey10x3.completionlist for details
 */
namespace CoreGDX.BitStack.Test.Indexing {
    public class MortonKey10x3Test {

#if !UNITY_EDITOR
        [Fact]
#else
        [Test]
#endif
        public void ZeroInit_ShouldPass() {
			int val = 0;
			uint uval = 0;

			new MortonKey10x3(val, val, val);
			new MortonKey10x3(uval, uval, uval);
			new MortonKey10x3(val);
			new MortonKey10x3(uval);
        }

#if !UNITY_EDITOR
        [Fact]
#else
        [Test]
#endif
		public void MaxInit_ShouldPass() {
			int val = 1023;
			uint uval = 1023;

			new MortonKey10x3(val, val, val);
			new MortonKey10x3(uval, uval, uval);
			new MortonKey10x3(val * val * val);
			new MortonKey10x3(uval * uval * uval);
        }

#if !UNITY_EDITOR
        [Fact]
#else
        [Test]
#endif
		public void MaxInit_Int_ShouldFail() {
			int val = 1024;

			Assert.Throws<Exception>(() => new MortonKey10x3(val, val, val));
        }

#if !UNITY_EDITOR
        [Fact]
#else
        [Test]
#endif
		public void NegInit_Int_ShouldFail() {
			int val = -1;

			Assert.Throws<Exception>(() => new MortonKey10x3(val, val, val));
        }

#if !UNITY_EDITOR
        [Fact]
#else
        [Test]
#endif
		public void MaxInit_UInt_ShouldFail() {
			uint val = 1024;

			Assert.Throws<Exception>(() => new MortonKey10x3(val, val, val));
        }

#if !UNITY_EDITOR
        [Fact]
#else
        [Test]
#endif
		public void MaxInit_IntTotal_ShouldPass() {
			int val = 1023;

			new MortonKey10x3(val * val * val);
        }

#if !UNITY_EDITOR
        [Fact]
#else
        [Test]
#endif
		public void NegInit_IntTotal_ShouldFail() {
			int val = -1;

			Assert.Throws<Exception>(() => new MortonKey10x3(val));
        }

#if !UNITY_EDITOR
        [Fact]
#else
        [Test]
#endif
		public void MaxInit_UIntTotal_ShouldPass() {
			uint val = 1023;

			new MortonKey10x3(val * val * val);
        }
    }
}
