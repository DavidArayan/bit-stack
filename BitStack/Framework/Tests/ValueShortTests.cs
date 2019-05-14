using BitStack;
using NUnit.Framework;
using UnityEngine;

/**
 * Unit Tests designed to be ran by the Unity Test Runner which tests functionality
 * related to the short data type (signed short, 16 bits)
 */
public static class ValueShortTests {

    static readonly short TEST_VALUE = -29897; // 1000101100110111
    static readonly string TEST_VALUE_STR = "1000101100110111";
    static readonly string TEST_HEX = "8B37";
    static readonly int LOOP_COUNT = 16;

    // the expected bit sequence in array form
    static readonly int[] EXPTECTED_BITS = { 1, 1, 1, 0, 1, 1, 0, 0, 1, 1, 0, 1, 0, 0, 0, 1 };
    static readonly byte[] EXPECTED_BYTES = { 127, 246 };

    [Test]
    public static void Test_BitAt() {
        for (int i = 0; i < LOOP_COUNT; i++) {
            Debug.Assert(TEST_VALUE.BitAt(i) == EXPTECTED_BITS[i]);
        }
    }

    [Test]
    public static void Test_BitInvAt() {
        for (int i = 0; i < LOOP_COUNT; i++) {
            Debug.Assert(TEST_VALUE.BitInvAt(i) != (EXPTECTED_BITS[i]));
        }
    }

    [Test]
    public static void Test_Bool() {
        short posValue = 2;
        short zeroValue = 0;
        short negValue = -2;

        Debug.Assert(posValue.Bool());
        Debug.Assert(!zeroValue.Bool());
        Debug.Assert(!negValue.Bool());
    }

    [Test]
    public static void Test_SetBitAt() {
        for (int i = 0; i < LOOP_COUNT; i++) {
            Debug.Assert(TEST_VALUE.SetBitAt(i).BitAt(i) == 1, "Expected Bit Position(" + i + ") to be 1");
        }
    }

    [Test]
    public static void Test_UnsetBitAt() {
        for (int i = 0; i < LOOP_COUNT; i++) {
            Debug.Assert(TEST_VALUE.UnsetBitAt(i).BitAt(i) == 0, "Expected Bit Position(" + i + ") to be 0");
        }
    }

    [Test]
    public static void Test_SetBit() {
        for (int i = 0; i < LOOP_COUNT; i++) {
            Debug.Assert(TEST_VALUE.SetBit(i, 0).BitAt(i) == 0, "Expected Bit Position(" + i + ") to be 0");
            Debug.Assert(TEST_VALUE.SetBit(i, 1).BitAt(i) == 1, "Expected Bit Position(" + i + ") to be 1");
        }
    }

    [Test]
    public static void Test_SetUnsetBit() {
        for (int i = 0; i < LOOP_COUNT; i++) {
            Debug.Assert(TEST_VALUE.SetBit(i, 0).SetBit(i, 1).BitAt(i) == 1, "Expected Bit Position(" + i + ") to be 1");
            Debug.Assert(TEST_VALUE.SetBit(i, 1).SetBit(i, 0).BitAt(i) == 0, "Expected Bit Position(" + i + ") to be 0");
        }
    }

    [Test]
    public static void Test_ToggleBitAt() {
        short inv = TEST_VALUE;
        var invTest = (short) ~TEST_VALUE;

        for (int i = 0; i < LOOP_COUNT; i++) {
            inv = inv.ToggleBitAt(i);
        }

        Debug.Assert(inv == invTest, "Expected Toggle(" + inv + ") and InvTest(" + (invTest) + ") to Match.");

        // invert the order to ensure
        for (int i = 0; i < LOOP_COUNT; i++) {
            inv = inv.ToggleBitAt(i);
        }

        Debug.Assert(inv == TEST_VALUE, "Expected Toggle(" + inv + ") and Test(" + TEST_VALUE + ") to Match.");
    }

    [Test]
    public static void Test_PopCount() {
        var popCount = TEST_VALUE.PopCount();
        Debug.Assert(TEST_VALUE.PopCount() == 9, "Expected Value(" + popCount + ") and Test(9) + to Match");
    }

    [Test]
    public static void Test_BitString() {
        var testStr = TEST_VALUE.BitString();
        Debug.Assert(testStr == TEST_VALUE_STR, "Expected String(" + testStr + ") and Test(" + TEST_VALUE_STR + ") to Match.");
    }

    [Test]
    public static void Test_ShortFromBitString() {
        var testShort = TEST_VALUE_STR.ShortFromBitString();
        Debug.Assert(testShort == TEST_VALUE, "Expected Short(" + testShort + ") and Test(" + TEST_VALUE + ") to Match.");
    }

    [Test]
    public static void Test_HexString() {
        var testHex = TEST_VALUE.HexString();
        Debug.Assert(testHex == TEST_HEX, "Expected Hex(" + testHex + ") and Test(" + TEST_HEX + ") to Match.");
    }

    [Test]
    public static void Test_IsPowerOfTwo() {
        short pow1 = 128;
        short pow2 = 256;
        short pow3 = 512;
        short nPow1 = 140;
        short nPow2 = 330;
        short nPow3 = 501;

        Debug.Assert(pow1.IsPowerOfTwo(), "Expected Test(" + pow1 + ") To be Power of Two");
        Debug.Assert(pow2.IsPowerOfTwo(), "Expected Test(" + pow2 + ") To be Power of Two");
        Debug.Assert(pow3.IsPowerOfTwo(), "Expected Test(" + pow3 + ") To be Power of Two");
        Debug.Assert(!nPow1.IsPowerOfTwo(), "Expected Test(" + nPow1 + ") To be Non Power of Two");
        Debug.Assert(!nPow2.IsPowerOfTwo(), "Expected Test(" + nPow2 + ") To be Non Power of Two");
        Debug.Assert(!nPow3.IsPowerOfTwo(), "Expected Test(" + nPow3 + ") To be Non Power of Two");
    }

    [Test]
    public static void Test_ByteTuple() {
        var tuple = TEST_VALUE.SplitIntoByte();

        var revert = tuple.CombineToShort();
        Debug.Assert(revert == TEST_VALUE, "Expected Test(" + revert + ") To be equal to Value(" + TEST_VALUE + ")");
    }

    [Test]
    public static void Test_SByteTuple() {
        var tuple = TEST_VALUE.SplitIntoSByte();

        var revert = tuple.CombineToShort();
        Debug.Assert(revert == TEST_VALUE, "Expected Test(" + revert + ") To be equal to Value(" + TEST_VALUE + ")");
    }

    [Test]
    public static void Test_GetByte() {
        var tuple = TEST_VALUE.SplitIntoByte();

        byte[] test_data = { tuple.Item1, tuple.Item2 };

        for (int i = 0; i < 2; i++) {
            byte testValue = TEST_VALUE.ByteAt(i);
            Debug.Assert(test_data[i] == testValue, "Expected Test(" + test_data[i] + ") To be equal to Value(" + testValue + ")");
        }
    }

    [Test]
    public static void Test_SetByteAt() {
        var tuple = TEST_VALUE.SplitIntoByte();

        byte[] test_data = { tuple.Item1, tuple.Item2 };

        for (int i = 0; i < (LOOP_COUNT / 8); i++) {
            short newValue = TEST_VALUE.SetByteAt(EXPECTED_BYTES[i], i);
            var new_tuple = newValue.SplitIntoByte();

            byte[] new_test_data = { new_tuple.Item1, new_tuple.Item2 };
            Debug.Assert(new_test_data[i] == EXPECTED_BYTES[i], "Expected First Test(" + new_test_data[i] + ") To be equal to Value(" + EXPECTED_BYTES[i] + ")");

            // perform the inverse operation - this is to ensure the old value
            // can be placed over the new value properly
            newValue = newValue.SetByteAt(test_data[i], i);
            new_tuple = newValue.SplitIntoByte();
            new_test_data = new byte[] { new_tuple.Item1, new_tuple.Item2 };

            Debug.Assert(new_test_data[i] == test_data[i], "Expected Second Test(" + new_test_data[i] + ") To be equal to Value(" + test_data[i] + ")");
        }
    }
}