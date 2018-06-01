using UnityEngine;
using NUnit.Framework;
using BitStack;

/**
 * Unit Tests designed to be ran by the Unity Test Runner which tests functionality
 * related to the ushort data type (unsigned short, 16 bits)
 */
public class ValueUShortTests {

	static readonly ushort TEST_VALUE = 47964; // 1011101101011100
	static readonly string TEST_VALUE_STR = "1011101101011100";
	static readonly string TEST_HEX = "BB5C";
	static readonly int LOOP_COUNT = 16;

	// the expected bit sequence in array form
	static readonly int[] EXPTECTED_BITS = { 0, 0, 1, 1, 1, 0, 1, 0, 1, 1, 0, 1, 1, 1, 0, 1 };

	[Test]
	public void Test_BitAt() {
		for (int i = 0; i < LOOP_COUNT; i++) {
			Debug.Assert(TEST_VALUE.BitAt(i) == EXPTECTED_BITS[i]);
		}
	}

	[Test]
	public void Test_Bool() {
		ushort posValue = 2;
		ushort zeroValue = 0;

		Debug.Assert(posValue.Bool());
		Debug.Assert(!zeroValue.Bool());
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
		ushort inv = TEST_VALUE;
		var invTest = (ushort)~TEST_VALUE;

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

		Debug.Assert(TEST_VALUE.PopCount() == 10,
					 "Expected Value(" + popCount + ") and Test(10) + to Match");
	}

	[Test]
	public void Test_BitString() {
		var testStr = TEST_VALUE.BitString();

		Debug.Assert(testStr == TEST_VALUE_STR,
					 "Expected String(" + testStr + ") and Test(" + TEST_VALUE_STR + ") to Match.");
	}

	[Test]
	public void Test_UShortFromBitString() {
		var testShort = TEST_VALUE_STR.UShortFromBitString();

		Debug.Assert(testShort == TEST_VALUE,
					 "Expected Short(" + testShort + ") and Test(" + TEST_VALUE + ") to Match.");
	}

	[Test]
	public void Test_HexString() {
		var testHex = TEST_VALUE.HexString();

		Debug.Assert(testHex == TEST_HEX,
					 "Expected Hex(" + testHex + ") and Test(" + TEST_HEX + ") to Match.");
	}

	[Test]
	public void Test_IsPowerOfTwo() {
		ushort pow1 = 128;
		ushort pow2 = 256;
		ushort pow3 = 512;
		ushort nPow1 = 140;
		ushort nPow2 = 330;
		ushort nPow3 = 501;

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

	[Test]
	public void Test_ByteTuple() {
		var tuple = TEST_VALUE.SplitIntoByte();

		var revert = tuple.CombineToUShort();

		Debug.Assert(revert == TEST_VALUE,
					 "Expected Test(" + revert + ") To be equal to Value(" + TEST_VALUE + ")");
	}

	[Test]
	public void Test_SByteTuple() {
		var tuple = TEST_VALUE.SplitIntoSByte();

		var revert = tuple.CombineToUShort();

		Debug.Assert(revert == TEST_VALUE,
					 "Expected Test(" + revert + ") To be equal to Value(" + TEST_VALUE + ")");
	}
}
