using UnityEngine;
using NUnit.Framework;
using BitStack;

/**
 * Unit Tests designed to be ran by the Unity Test Runner which tests functionality
 * related to the sbyte data type (signed byte, 8 bits)
 */
public class ValueSByteTests {

	static readonly sbyte TEST_VALUE = -87; // 10101001
	static readonly string TEST_VALUE_STR = "10101001";
	static readonly string TEST_HEX = "A9";
	static readonly int LOOP_COUNT = 8;

	// the expected bit sequence in array form
	static readonly int[] EXPTECTED_BITS = { 1, 0, 0, 1, 0, 1, 0, 1 };

	[Test]
	public void Test_BitAt() {
		for (int i = 0; i < LOOP_COUNT; i++) {
			Debug.Assert(TEST_VALUE.BitAt(i) == EXPTECTED_BITS[i]);
		}
	}

	[Test]
	public void Test_Bool() {
		sbyte posValue = 2;
		sbyte zeroValue = 0;
		sbyte negValue = -2;

		Debug.Assert(posValue.Bool());
		Debug.Assert(!zeroValue.Bool());
		Debug.Assert(!negValue.Bool());
	}

	[Test]
	public void Test_SetBitAt() {
		for (int i = 0; i < LOOP_COUNT; i++) {
			Debug.Assert(TEST_VALUE.SetBitAt(i).BitAt(i) == 1,
						 "Expected Bit Position(" + i + ") to be 1");
		}
	}

	[Test]
	public void Test_UnsetBitAt() {
		for (int i = 0; i < LOOP_COUNT; i++) {
			Debug.Assert(TEST_VALUE.UnsetBitAt(i).BitAt(i) == 0,
						 "Expected Bit Position(" + i + ") to be 0");
		}
	}

	[Test]
	public void Test_ToggleBitAt() {
		sbyte inv = TEST_VALUE;
		var invTest = (sbyte)~TEST_VALUE;

		for (int i = 0; i < LOOP_COUNT; i++) {
			inv = inv.ToggleBitAt(i);
		}

		Debug.Assert(inv == invTest,
					 "Expected Toggle(" + inv + ") and InvTest(" + (invTest) + ") to Match.");

		// invert the order to ensure
		for (int i = 0; i < LOOP_COUNT; i++) {
			inv = inv.ToggleBitAt(i);
		}

		Debug.Assert(inv == TEST_VALUE,
					 "Expected Toggle(" + inv + ") and Test(" + TEST_VALUE + ") to Match.");
	}

	[Test]
	public void Test_PopCount() {
		var popCount = TEST_VALUE.PopCount();

		Debug.Assert(TEST_VALUE.PopCount() == 4,
					 "Expected Value(" + popCount + ") and Test(4) + to Match");
	}

	[Test]
	public void Test_BitString() {
		var testStr = TEST_VALUE.BitString();

		Debug.Assert(testStr == TEST_VALUE_STR,
					 "Expected String(" + testStr + ") and Test(" + TEST_VALUE_STR + ") to Match.");
	}

	[Test]
	public void Test_SByteFromBitString() {
		var testByte = TEST_VALUE_STR.SByteFromBitString();

		Debug.Assert(testByte == TEST_VALUE,
					 "Expected Byte(" + testByte + ") and Test(" + TEST_VALUE + ") to Match.");
	}

	[Test]
	public void Test_HexString() {
		var testHex = TEST_VALUE.HexString();

		Debug.Assert(testHex == TEST_HEX,
					 "Expected Hex(" + testHex + ") and Test(" + TEST_HEX + ") to Match.");
	}

	[Test]
	public void Test_IsPowerOfTwo() {
		sbyte pow1 = 16;
		sbyte pow2 = 64;
		sbyte pow3 = 2;
		sbyte nPow1 = 14;
		sbyte nPow2 = 33;
		sbyte nPow3 = 5;

		Debug.Assert(pow1.IsPowerOfTwo(),
					 "Expected Test(" + pow1 + ") To be Power of Two");

		Debug.Assert(pow2.IsPowerOfTwo(),
					 "Expected Test(" + pow2 + ") To be Power of Two");

		Debug.Assert(pow3.IsPowerOfTwo(),
					 "Expected Test(" + pow3 + ") To be Power of Two");

		Debug.Assert(!nPow1.IsPowerOfTwo(),
					 "Expected Test(" + nPow1 + ") To be Non Power of Two");

		Debug.Assert(!nPow2.IsPowerOfTwo(),
					 "Expected Test(" + nPow2 + ") To be Non Power of Two");

		Debug.Assert(!nPow3.IsPowerOfTwo(),
					 "Expected Test(" + nPow3 + ") To be Non Power of Two");
	}
}
