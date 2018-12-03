using UnityEngine;
using NUnit.Framework;
using BitStack;

/**
 * Unit Tests designed to be ran by the Unity Test Runner which tests functionality
 * related to the int data type (signed int, 32 bits).
 * 
 * NOTICE: Unit Tests are not compiled into production builds. These are to ensure
 * that existing functionality continues to perform as expected. It's very easy to
 * break unexpected things while making small changes or improvements.
 * 
 * Always run unit tests for correctness whenever the core functionality changes
 */
public class ValueIntTests {

	static readonly int TEST_VALUE = -217623190; // 11110011000001110101010101101010
	static readonly string TEST_VALUE_STR = "11110011000001110101010101101010";
	static readonly string TEST_HEX = "F307556A";
	static readonly int LOOP_COUNT = 32;

	// the expected bit sequence in array form
	static readonly int[] EXPTECTED_BITS = { 0, 1, 0, 1, 0, 1, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 1, 1, 0, 0, 0, 0, 0, 1, 1, 0, 0, 1, 1, 1, 1 };
	static readonly byte[] EXPECTED_BYTES = { 127, 246, 0, 187 };
	
	static readonly byte TEST_BYTE = 173;

	[Test]
	public void Test_BitAt() {
		for (int i = 0; i < LOOP_COUNT; i++) {
			Debug.Assert(TEST_VALUE.BitAt(i) == EXPTECTED_BITS[i]);
		}
	}
	
	[Test]
	public void Test_BitInvAt() {
		for (int i = 0; i < LOOP_COUNT; i++) {
			Debug.Assert(TEST_VALUE.BitInvAt(i) != (EXPTECTED_BITS[i]));
		}
	}

	[Test]
	public void Test_Bool() {
		int posValue = 2;
		int zeroValue = 0;
		int negValue = -2;

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
		int inv = TEST_VALUE;
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

		Debug.Assert(TEST_VALUE.PopCount() == 17,
					 "Expected Value(" + popCount + ") and Test(17) + to Match");
	}

	[Test]
	public void Test_BitString() {
		var testStr = TEST_VALUE.BitString();

		Debug.Assert(testStr == TEST_VALUE_STR,
					 "Expected String(" + testStr + ") and Test(" + TEST_VALUE_STR + ") to Match.");
	}

	[Test]
	public void Test_IntFromBitString() {
		var testInt = TEST_VALUE_STR.IntFromBitString();

		Debug.Assert(testInt == TEST_VALUE,
					 "Expected Int(" + testInt + ") and Test(" + TEST_VALUE + ") to Match.");
	}

	[Test]
	public void Test_HexString() {
		var testHex = TEST_VALUE.HexString();

		Debug.Assert(testHex == TEST_HEX,
					 "Expected Hex(" + testHex + ") and Test(" + TEST_HEX + ") to Match.");
	}

	[Test]
	public void Test_IsPowerOfTwo() {
		int pow1 = 8192;
		int pow2 = 2048;
		int pow3 = 4096;
		int nPow1 = 21400;
		int nPow2 = 3300;
		int nPow3 = 5010;

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

		var revert = tuple.CombineToInt();

		Debug.Assert(revert == TEST_VALUE,
					 "Expected Test(" + revert + ") To be equal to Value(" + TEST_VALUE + ")");
	}

	[Test]
	public void Test_SByteTuple() {
		var tuple = TEST_VALUE.SplitIntoSByte();

		var revert = tuple.CombineToInt();

		Debug.Assert(revert == TEST_VALUE,
					 "Expected Test(" + revert + ") To be equal to Value(" + TEST_VALUE + ")");
	}

	[Test]
	public void Test_ShortTuple() {
		var tuple = TEST_VALUE.SplitIntoShort();

		var revert = tuple.CombineToInt();

		Debug.Assert(revert == TEST_VALUE,
					 "Expected Test(" + revert + ") To be equal to Value(" + TEST_VALUE + ")");
	}

	[Test]
	public void Test_UShortTuple() {
		var tuple = TEST_VALUE.SplitIntoUShort();

		var revert = tuple.CombineToInt();

		Debug.Assert(revert == TEST_VALUE,
					 "Expected Test(" + revert + ") To be equal to Value(" + TEST_VALUE + ")");
	}
	
	[Test]
	public void Test_GetByte() {
		var tuple = TEST_VALUE.SplitIntoByte();
		
		byte[] test_data = {tuple.Item1, tuple.Item2, tuple.Item3, tuple.Item4};
		
		for (int i = 0; i < (LOOP_COUNT / 8); i++) {
			byte testValue = TEST_VALUE.ByteAt(i);
			
			Debug.Assert(test_data[i] == testValue,
					 "Expected Test(" + test_data[i] + ") To be equal to Value(" + testValue + ")");
		}
	}

	[Test]
	public void Test_SetByteAt() {
		var tuple = TEST_VALUE.SplitIntoByte();
		
		byte[] test_data = {tuple.Item1, tuple.Item2, tuple.Item3, tuple.Item4};
		
		for (int i = 0; i < (LOOP_COUNT / 8); i++) {
			int newValue = TEST_VALUE.SetByteAt(EXPECTED_BYTES[i], i);
			var new_tuple = newValue.SplitIntoByte();

			byte[] new_test_data = {new_tuple.Item1, new_tuple.Item2, new_tuple.Item3, new_tuple.Item4};
			
			Debug.Assert(new_test_data[i] == EXPECTED_BYTES[i],
					 "Expected First Test(" + new_test_data[i] + ") To be equal to Value(" + EXPECTED_BYTES[i] + ")");

			// perform the inverse operation - this is to ensure the old value
			// can be placed over the new value properly
			newValue = newValue.SetByteAt(test_data[i], i);
			new_tuple = newValue.SplitIntoByte();
			new_test_data = new byte[] {new_tuple.Item1, new_tuple.Item2, new_tuple.Item3, new_tuple.Item4};

			Debug.Assert(new_test_data[i] == test_data[i],
					 "Expected Second Test(" + new_test_data[i] + ") To be equal to Value(" + test_data[i] + ")");
		}
	}
}
