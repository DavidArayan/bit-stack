using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using BitStack;

public class ValueULongTests {

	private readonly static ulong TEST_VALUE = 47520971873972742; // 0000000010101000110101000001001001110111111011011111001000000110
	private readonly static string TEST_VALUE_STR = "0000000010101000110101000001001001110111111011011111001000000110";
	private readonly static string TEST_HEX = "A8D41277EDF206";
    private readonly static int LOOP_COUNT = 64;

    // the expected bit sequence in array form
	private readonly static int[] EXPTECTED_BITS = { 0, 1, 1, 0, 0, 0, 0, 0, 0, 1, 0, 0, 1, 1, 1, 1, 1, 0, 1, 1, 0, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 0, 0, 1, 0, 0, 1, 0, 0, 0, 0, 0, 1, 0, 1, 0, 1, 1, 0, 0, 0, 1, 0, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0 };

    [Test]
    public void Test_BitAt() {
        for (int i = 0; i < LOOP_COUNT; i++) {
            Debug.Assert(TEST_VALUE.BitAt(i) == EXPTECTED_BITS[i]);
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
    public void Test_ToggleBitAt() {
        ulong inv = TEST_VALUE;
        ulong invTest = (ulong)~TEST_VALUE;

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

        Debug.Assert(TEST_VALUE.PopCount() == 28,
                     "Expected Value(" + popCount + ") and Test(28) + to Match");
    }

    [Test]
    public void Test_BitString() {
        string testStr = TEST_VALUE.BitString();

        Debug.Assert(testStr == TEST_VALUE_STR,
                     "Expected String(" + testStr + ") and Test(" + TEST_VALUE_STR + ") to Match.");
    }

    [Test]
    public void Test_ULongFromBitString() {
        ulong testLong = TEST_VALUE_STR.ULongFromBitString();

		Debug.Assert(testLong == TEST_VALUE,
		             "Expected Int(" + testLong + ") and Test(" + TEST_VALUE + ") to Match.");
    }

    [Test]
    public void Test_HexString() {
        string testHex = TEST_VALUE.HexString();

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

		ulong revert = tuple.CombineToULong();
        
		Debug.Assert(revert == TEST_VALUE,
		             "Expected Test(" + revert + ") To be equal to Value(" + TEST_VALUE + ")");
	}

	[Test]
    public void Test_SByteTuple() {
        var tuple = TEST_VALUE.SplitIntoSByte();

        ulong revert = tuple.CombineToULong();

        Debug.Assert(revert == TEST_VALUE,
                     "Expected Test(" + revert + ") To be equal to Value(" + TEST_VALUE + ")");
    }
}