using System;
using BitStack;
using NUnit.Framework;
using UnityEngine;

public static class ValueUShortArrayTests {
    const int BITS = 16;
    const int BYTES = BITS / 8;

    static readonly ushort[] TEST_VALUE_ARRAY = { 12893, 19667, 47653, 65532, 53984, 24398, 6512 };

    // looper values
    static readonly int LOOP_COUNT = BITS * TEST_VALUE_ARRAY.Length;
    static readonly int LOOP_COUNT_BYTES = BYTES * TEST_VALUE_ARRAY.Length;

    // the bit sequence of the above values as a linear array of 1 and 0
    static readonly int[] EXPTECTED_BITS = CalcBits(TEST_VALUE_ARRAY);

    // inverted variant of current bytes
    static readonly byte[] TEST_BYTES = CalcBytes(TEST_VALUE_ARRAY, true);

    // the expected byte sequence of the current values
    static readonly byte[] EXPECTED_BYTES = CalcBytes(TEST_VALUE_ARRAY, false);

    // NOTE -> This is Tested elsewhere and is assumed correct	
    static int[] CalcBits(ushort[] value) {
        int[] bits = new int[BITS * value.Length];

        int index = 0;

        for (int i = 0; i < value.Length; i++) {
            for (int j = 0; j < BITS; j++) {
                bits[index] = value[i].BitAt(j);
                index++;
            }
        }

        return bits;
    }

    // NOTE -> This is Tested elsewhere and is assumed correct	
    static byte[] CalcBytes(ushort[] value, bool invert) {
        byte[] bytes = new byte[BYTES * value.Length];

        int index = 0;

        for (int i = 0; i < value.Length; i++) {
            for (int j = 0; j < BYTES; j++) {
                // flip/invert the byte
                if (invert) {
                    bytes[index] = (byte) ~(value[i].ByteAt(j));
                } else {
                    bytes[index] = value[i].ByteAt(j);
                }

                index++;
            }
        }

        return bytes;
    }

    // NOTE -> This is Tested elsewhere and is assumed correct	
    static ushort[] GetTestArray() {
        ushort[] copyArray = new ushort[TEST_VALUE_ARRAY.Length];
        Array.Copy(TEST_VALUE_ARRAY, copyArray, TEST_VALUE_ARRAY.Length);
        return copyArray;
    }

    [Test]
    public static void Test_BitAt() {
        ushort[] TEST_VALUE = GetTestArray();

        for (int i = 0; i < LOOP_COUNT; i++) {
            int bit = TEST_VALUE.BitAt(i);
            Debug.Assert(bit == EXPTECTED_BITS[i], "Expected Bit(" + bit + ") at Index(" + i + ") to be " + EXPTECTED_BITS[i]);
        }
    }

    [Test]
    public static void Test_BitInvAt() {
        ushort[] TEST_VALUE = GetTestArray();

        for (int i = 0; i < LOOP_COUNT; i++) {
            int bit = TEST_VALUE.BitInvAt(i);
            Debug.Assert(TEST_VALUE.BitInvAt(i) != EXPTECTED_BITS[i], "Expected Bit(" + bit + ") at Index(" + i + ") not to be " + EXPTECTED_BITS[i]);
        }
    }

    [Test]
    public static void Test_SetBitAt() {
        ushort[] TEST_VALUE = GetTestArray();

        for (int i = 0; i < LOOP_COUNT; i++) {
            TEST_VALUE.SetBitAt(i);
            Debug.Assert(TEST_VALUE.BitAt(i) == 1, "Expected Bit Position(" + i + ") to be 1");
        }
    }

    [Test]
    public static void Test_UnsetBitAt() {
        ushort[] TEST_VALUE = GetTestArray();

        for (int i = 0; i < LOOP_COUNT; i++) {
            TEST_VALUE.UnsetBitAt(i);
            Debug.Assert(TEST_VALUE.BitAt(i) == 0, "Expected Bit Position(" + i + ") to be 0");
        }
    }

    [Test]
    public static void Test_SetBit() {
        ushort[] TEST_VALUE = GetTestArray();

        for (int i = 0; i < LOOP_COUNT; i++) {
            TEST_VALUE.SetBit(i, 0);
            Debug.Assert(TEST_VALUE.BitAt(i) == 0, "Expected Bit Position(" + i + ") to be 0");

            TEST_VALUE.SetBit(i, 1);
            Debug.Assert(TEST_VALUE.BitAt(i) == 1, "Expected Bit Position(" + i + ") to be 1");
        }
    }

    [Test]
    public static void Test_SetUnsetBit() {
        ushort[] TEST_VALUE = GetTestArray();

        for (int i = 0; i < LOOP_COUNT; i++) {
            TEST_VALUE.SetBit(i, 0);
            TEST_VALUE.SetBit(i, 1);

            Debug.Assert(TEST_VALUE.BitAt(i) == 1, "Expected Bit Position(" + i + ") to be 1");

            TEST_VALUE.SetBit(i, 1);
            TEST_VALUE.SetBit(i, 0);

            Debug.Assert(TEST_VALUE.BitAt(i) == 0, "Expected Bit Position(" + i + ") to be 0");
        }
    }

    [Test]
    public static void Test_ToggleBitAt() {
        ushort[] TEST_VALUE = GetTestArray();

        for (int i = 0; i < LOOP_COUNT; i++) {
            TEST_VALUE.ToggleBitAt(i);

            int inv = TEST_VALUE.BitAt(i);
            Debug.Assert(TEST_VALUE.BitAt(i) != EXPTECTED_BITS[i], "Expected Toggle(" + inv + ") and InvTest(" + EXPTECTED_BITS[i] + ") to not Match.");
        }

        for (int i = 0; i < LOOP_COUNT; i++) {
            TEST_VALUE.ToggleBitAt(i);

            int inv = TEST_VALUE.BitAt(i);
            Debug.Assert(TEST_VALUE.BitAt(i) == EXPTECTED_BITS[i], "Expected Toggle(" + inv + ") and InvTest(" + EXPTECTED_BITS[i] + ") to Match.");
        }
    }

    [Test]
    public static void Test_SetByteAt_ByteAt() {
        ushort[] TEST_VALUE = GetTestArray();

        for (int i = 0; i < LOOP_COUNT_BYTES; i++) {
            TEST_VALUE.SetByteAt(TEST_BYTES[i], i);

            byte value = TEST_VALUE.ByteAt(i);
            Debug.Assert(value == TEST_BYTES[i], "Expected Byte(" + value + ") and Test(" + TEST_BYTES[i] + ") to Match.");

            TEST_VALUE.SetByteAt(EXPECTED_BYTES[i], i);

            value = TEST_VALUE.ByteAt(i);
            Debug.Assert(value == EXPECTED_BYTES[i], "Expected Byte(" + value + ") and Test(" + EXPECTED_BYTES[i] + ") to Match.");
        }

        // in the end, all values should match the original since we have inverted operations
        // in the last test
        for (int i = 0; i < TEST_VALUE.Length; i++) {
            Debug.Assert(TEST_VALUE[i] == TEST_VALUE_ARRAY[i], "Expected Value(" + TEST_VALUE[i] + ") and Test(" + TEST_VALUE_ARRAY[i] + ") to Match.");
        }
    }
}