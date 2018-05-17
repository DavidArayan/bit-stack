using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using BitStack;

public class ValueByteTests {

	private readonly static byte TEST_VALUE = 158; // 10011110
	private readonly static string TEST_VALUE_STR = "10011110";
	private readonly static byte LOOP_COUNT = 8;

    [Test]
	public void Test_BitAt() {
		Debug.Assert(TEST_VALUE.BitAt(0) == 0);
		Debug.Assert(TEST_VALUE.BitAt(1) == 1);
		Debug.Assert(TEST_VALUE.BitAt(2) == 1);
		Debug.Assert(TEST_VALUE.BitAt(3) == 1);
		Debug.Assert(TEST_VALUE.BitAt(4) == 1);
		Debug.Assert(TEST_VALUE.BitAt(5) == 0);
		Debug.Assert(TEST_VALUE.BitAt(6) == 0);
		Debug.Assert(TEST_VALUE.BitAt(7) == 1);
    }

	[Test]
    public void Test_Bool() {
		byte POS_VALUE = 2;
		byte ZERO_VALUE = 0;

		Debug.Assert(POS_VALUE.Bool());
		Debug.Assert(!ZERO_VALUE.Bool());
    }

	[Test]
    public void Test_SetBitAt() {
		for (int i = 0; i < LOOP_COUNT; i++) {
			Debug.Assert(TEST_VALUE.SetBitAt(i).BitAt(i) == 1);
		}
    }
    
	[Test]
    public void Test_UnsetBitAt() {
		for (int i = 0; i < LOOP_COUNT; i++) {
            Debug.Assert(TEST_VALUE.UnsetBitAt(i).BitAt(i) == 0);
        }
    }
    
	[Test]
	public void Test_ToggleBitAt() {
		byte INV = TEST_VALUE;

		for (int i = 0; i < LOOP_COUNT; i++) {
			INV = INV.ToggleBitAt(i);
        }

		Debug.Assert(INV == ~TEST_VALUE);

        // invert the order to ensure
		for (int i = 0; i < LOOP_COUNT; i++) {
            INV = INV.ToggleBitAt(i);
        }

		Debug.Assert(INV == TEST_VALUE);
    }

	[Test]
    public void Test_PopCount() {
		Debug.Assert(TEST_VALUE.PopCount() == 5);
    }

	[Test]
    public void Test_BitString() {
		Debug.Assert(TEST_VALUE.BitString() == TEST_VALUE_STR);
    }

	[Test]
	public void Test_ByteFromBitString() {
		Debug.Assert(TEST_VALUE_STR.ByteFromBitString() == TEST_VALUE);
    }
}