using UnityEngine;
using NUnit.Framework;
using BitStack;

/**
 * Unit Tests designed to be ran by the Unity Test Runner which tests functionality
 * related to the ulong data type (unsigned long, 64 bits)
 */
public class ValueULongTests {

	static readonly ulong TEST_VALUE = 47520971873972742; // 0000000010101000110101000001001001110111111011011111001000000110
	static readonly string TEST_VALUE_STR = "0000000010101000110101000001001001110111111011011111001000000110";
	static readonly string TEST_HEX = "A8D41277EDF206";
	static readonly int LOOP_COUNT = 64;

	// the expected bit sequence in array form
	static readonly int[] EXPTECTED_BITS = { 0, 1, 1, 0, 0, 0, 0, 0, 0, 1, 0, 0, 1, 1, 1, 1, 1, 0, 1, 1, 0, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 0, 0, 1, 0, 0, 1, 0, 0, 0, 0, 0, 1, 0, 1, 0, 1, 1, 0, 0, 0, 1, 0, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0 };

	[Test]
	public void Test_BitAt() {
		for (int i = 0; i < LOOP_COUNT; i++) {
			Debug.Assert(TEST_VALUE.BitAt(i) == EXPTECTED_BITS[i]);
		}
	}
	
	[Test]
	public void Test_BitInvAt() {
		for (int i = 0; i < LOOP_COUNT; i++) {
			Debug.Assert(TEST_VALUE.BitInvAt(i) == (1 - EXPTECTED_BITS[i]));
		}
	}

	[Test]
	public void Test_Bool() {
		ulong posValue = 2;
		ulong zeroValue = 0;

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
	public void Test_SetBit() {
		for (int i = 0; i < LOOP_COUNT; i++) {
			Debug.Assert(TEST_VALUE.SetBit(i, 0).BitAt(i) == 0,
						 "Expected Bit Position(" + i + ") to be 0");
						 
			Debug.Assert(TEST_VALUE.SetBit(i, 1).BitAt(i) == 1,
						 "Expected Bit Position(" + i + ") to be 1");
		}
	}
	
	[Test]
	public void Test_SetUnsetBit() {
		for (int i = 0; i < LOOP_COUNT; i++) {
			Debug.Assert(TEST_VALUE.SetBit(i, 0).SetBit(i, 1).BitAt(i) == 1,
						 "Expected Bit Position(" + i + ") to be 1");
						 
			Debug.Assert(TEST_VALUE.SetBit(i, 1).SetBit(i, 0).BitAt(i) == 0,
						 "Expected Bit Position(" + i + ") to be 0");
		}
	}

	[Test]
	public void Test_ToggleBitAt() {
		ulong inv = TEST_VALUE;
		var invTest = ~TEST_VALUE;

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

		Debug.Assert(TEST_VALUE.PopCount() == 28,
					 "Expected Value(" + popCount + ") and Test(28) + to Match");
	}

	[Test]
	public void Test_BitString() {
		var testStr = TEST_VALUE.BitString();

		Debug.Assert(testStr == TEST_VALUE_STR,
					 "Expected String(" + testStr + ") and Test(" + TEST_VALUE_STR + ") to Match.");
	}

	[Test]
	public void Test_ULongFromBitString() {
		var testLong = TEST_VALUE_STR.ULongFromBitString();

		Debug.Assert(testLong == TEST_VALUE,
					 "Expected Int(" + testLong + ") and Test(" + TEST_VALUE + ") to Match.");
	}

	[Test]
	public void Test_HexString() {
		var testHex = TEST_VALUE.HexString();

		Debug.Assert(testHex == TEST_HEX,
					 "Expected Hex(" + testHex + ") and Test(" + TEST_HEX + ") to Match.");
	}

	[Test]
	public void Test_IsPowerOfTwo() {
		ulong pow1 = 1024;
		ulong pow2 = 2048;
		ulong pow3 = 4096;
		ulong nPow1 = 1400;
		ulong nPow2 = 3300;
		ulong nPow3 = 5010;

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

		var revert = tuple.CombineToULong();

		Debug.Assert(revert == TEST_VALUE,
					 "Expected Test(" + revert + ") To be equal to Value(" + TEST_VALUE + ")");
	}

	[Test]
	public void Test_SByteTuple() {
		var tuple = TEST_VALUE.SplitIntoSByte();

		var revert = tuple.CombineToULong();

		Debug.Assert(revert == TEST_VALUE,
					 "Expected Test(" + revert + ") To be equal to Value(" + TEST_VALUE + ")");
	}

	[Test]
	public void Test_ShortTuple() {
		var tuple = TEST_VALUE.SplitIntoShort();

		var revert = tuple.CombineToULong();

		Debug.Assert(revert == TEST_VALUE,
					 "Expected Test(" + revert + ") To be equal to Value(" + TEST_VALUE + ")");
	}

	[Test]
	public void Test_UShortTuple() {
		var tuple = TEST_VALUE.SplitIntoUShort();

		var revert = tuple.CombineToULong();

		Debug.Assert(revert == TEST_VALUE,
					 "Expected Test(" + revert + ") To be equal to Value(" + TEST_VALUE + ")");
	}

	[Test]
	public void Test_IntTuple() {
		var tuple = TEST_VALUE.SplitIntoInt();

		var revert = tuple.CombineToULong();

		Debug.Assert(revert == TEST_VALUE,
					 "Expected Test(" + revert + ") To be equal to Value(" + TEST_VALUE + ")");
	}

	[Test]
	public void Test_UIntTuple() {
		var tuple = TEST_VALUE.SplitIntoUInt();

		var revert = tuple.CombineToULong();

		Debug.Assert(revert == TEST_VALUE,
					 "Expected Test(" + revert + ") To be equal to Value(" + TEST_VALUE + ")");
	}
}