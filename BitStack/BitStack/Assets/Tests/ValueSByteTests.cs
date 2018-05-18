using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using BitStack;

/**
 * Provides a test suite for the ValueByte functionality
 */
public class ValueSByteTests {

	private readonly static sbyte TEST_VALUE = -87; // 10101001
	private readonly static string TEST_VALUE_STR = "10101001";
	private readonly static string TEST_HEX = "A9";
    private readonly static int LOOP_COUNT = 8;

	// the expected bit sequence in array form
    private readonly static int[] EXPTECTED_BITS = { 1, 0, 0, 1, 0, 1, 0, 1 };

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
        sbyte invTest = (sbyte)~TEST_VALUE;

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
		int popCount = TEST_VALUE.PopCount();

        Debug.Assert(TEST_VALUE.PopCount() == 4,
                     "Expected Value(" + popCount + ") and Test(4) + to Match");
    }

    [Test]
    public void Test_BitString() {
        string testStr = TEST_VALUE.BitString();

        Debug.Assert(testStr == TEST_VALUE_STR,
                     "Expected String(" + testStr + ") and Test(" + TEST_VALUE_STR + ") to Match.");
    }

    [Test]
    public void Test_SByteFromBitString() {
        sbyte testByte = TEST_VALUE_STR.SByteFromBitString();

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
