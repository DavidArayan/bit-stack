using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using BitStack;

/**
 * Unit Tests designed to be ran by the Unity Test Runner which tests functionality
 * related to the byte data type (unsigned byte, 8 bits)
 */
public class ValueByteTests {

	private readonly static byte TEST_VALUE = 158; // 10011110
	private readonly static string TEST_VALUE_STR = "10011110";
	private readonly static string TEST_HEX = "9E";
	private readonly static int LOOP_COUNT = 8;

    // the expected bit sequence in array form
	private readonly static int[] EXPTECTED_BITS = { 0, 1, 1, 1, 1, 0, 0, 1 };

    [Test]
	public void Test_BitAt() {
		for (int i = 0; i < LOOP_COUNT; i++) {
			Debug.Assert(TEST_VALUE.BitAt(i) == EXPTECTED_BITS[i]);
		}
    }

	[Test]
    public void Test_Bool() {
		byte posValue = 2;
		byte zeroValue = 0;

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
		byte inv = TEST_VALUE;
		byte invTest = (byte)~TEST_VALUE;

		for (int i = 0; i < LOOP_COUNT; i++) {
			inv = inv.ToggleBitAt(i);
        }

		Debug.Assert(inv == invTest, 
		             "Expected Toggle(" + inv +") and InvTest(" + (invTest) + ") to Match.");

        // invert the order to ensure
		for (int i = 0; i < LOOP_COUNT; i++) {
			inv = inv.ToggleBitAt(i);
        }

		Debug.Assert(inv == TEST_VALUE, 
		             "Expected Toggle(" + inv + ") and Test(" + TEST_VALUE + ") to Match.");
    }

	[Test]
    public void Test_PopCount() {
		int popCount = TEST_VALUE.PopCount();

		Debug.Assert(TEST_VALUE.PopCount() == 5,
		             "Expected Value(" + popCount + ") and Test(5) + to Match");
    }

	[Test]
    public void Test_BitString() {
		string testStr = TEST_VALUE.BitString();

		Debug.Assert(testStr == TEST_VALUE_STR, 
		             "Expected String(" + testStr + ") and Test(" + TEST_VALUE_STR + ") to Match.");
    }

	[Test]
	public void Test_ByteFromBitString() {
		byte testByte = TEST_VALUE_STR.ByteFromBitString();

		Debug.Assert(testByte == TEST_VALUE, 
		             "Expected Byte(" + testByte + ") and Test(" + TEST_VALUE + ") to Match.");
    }

	[Test]
	public void Test_HexString() {
		string testHex = TEST_VALUE.HexString();

		Debug.Assert(testHex == TEST_HEX,
		             "Expected Hex(" + testHex + ") and Test(" + TEST_HEX + ") to Match.");
    }

	[Test]
	public void Test_IsPowerOfTwo() {
		byte pow1 = 16;
		byte pow2 = 64;
		byte pow3 = 2;
		byte nPow1 = 14;
		byte nPow2 = 33;
		byte nPow3 = 5;

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