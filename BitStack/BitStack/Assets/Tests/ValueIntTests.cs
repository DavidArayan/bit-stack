using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using BitStack;

public class ValueIntTests {

	private readonly static int TEST_VALUE = -217623190; // 11110011000001110101010101101010
	private readonly static string TEST_VALUE_STR = "11110011000001110101010101101010";
	private readonly static string TEST_HEX = "F307556A";
    private readonly static int LOOP_COUNT = 32;

    // the expected bit sequence in array form
	private readonly static int[] EXPTECTED_BITS = { 0, 1, 0, 1, 0, 1, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 1, 1, 0, 0, 0, 0, 0, 1, 1, 0, 0, 1, 1, 1, 1 };

    [Test]
    public void Test_BitAt() {
        for (int i = 0; i < LOOP_COUNT; i++) {
            Debug.Assert(TEST_VALUE.BitAt(i) == EXPTECTED_BITS[i]);
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
    public void Test_ToggleBitAt() {
		int inv = TEST_VALUE;
		int invTest = (int)~TEST_VALUE;

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

        Debug.Assert(TEST_VALUE.PopCount() == 17,
                     "Expected Value(" + popCount + ") and Test(17) + to Match");
    }

    [Test]
    public void Test_BitString() {
        string testStr = TEST_VALUE.BitString();

        Debug.Assert(testStr == TEST_VALUE_STR,
                     "Expected String(" + testStr + ") and Test(" + TEST_VALUE_STR + ") to Match.");
    }
    
    [Test]
    public void Test_IntFromBitString() {
		int testInt = TEST_VALUE_STR.IntFromBitString();

		Debug.Assert(testInt == TEST_VALUE,
		             "Expected Int(" + testInt + ") and Test(" + TEST_VALUE + ") to Match.");
    }

    [Test]
    public void Test_HexString() {
        string testHex = TEST_VALUE.HexString();

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
}
