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
		byte posValue = 2;
		byte zeroValue = 0;

		Debug.Assert(posValue.Bool());
		Debug.Assert(!zeroValue.Bool());
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
		Debug.Assert(TEST_VALUE.PopCount() == 5);
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
}