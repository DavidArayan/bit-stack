using UnityEngine;
using NUnit.Framework;
using BitStack;
using System;

public class ValueIntArrayTests {
	const int BITS = 32;
	
	static readonly int[] TEST_VALUE_ARRAY = {-1289396, -1966734, -2139819, 2544535, 96872, 24398874, 276679832};
	static readonly int LOOP_COUNT = BITS * TEST_VALUE_ARRAY.Length;
	static readonly int LOOP_COUNT_BYTES = LOOP_COUNT / BITS;
	static readonly int[] EXPTECTED_BITS = CalcBits(TEST_VALUE_ARRAY);
	
	// NOTE -> This is Tested elsewhere and is assumed correct	
	private static int[] CalcBits(int[] value) {
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
	private static int[] GetTestArray() {
		int[] copyArray = new int[TEST_VALUE_ARRAY.Length];      
		Array.Copy(TEST_VALUE_ARRAY, copyArray, TEST_VALUE_ARRAY.Length);
		return copyArray;
	}
	
	[Test]
	public void Test_BitAt() {
		int[] TEST_VALUE = GetTestArray();
		
		for (int i = 0; i < LOOP_COUNT; i++) {
			int bit = TEST_VALUE.BitAt(i);
			
			Debug.Assert(bit == EXPTECTED_BITS[i], 
							"Expected Bit(" + bit + ") at Index(" + i + ") to be " + EXPTECTED_BITS[i]);
		}
	}
	
	[Test]
	public void Test_BitInvAt() {
		int[] TEST_VALUE = GetTestArray();
		
		for (int i = 0; i < LOOP_COUNT; i++) {
			int bit = TEST_VALUE.BitInvAt(i);
			
			Debug.Assert(TEST_VALUE.BitInvAt(i) != EXPTECTED_BITS[i], 
							"Expected Bit(" + bit + ") at Index(" + i + ") not to be " + EXPTECTED_BITS[i]);
		}
	}

	[Test]
	public void Test_SetBitAt() {
		int[] TEST_VALUE = GetTestArray();
		
		for (int i = 0; i < LOOP_COUNT; i++) {
			TEST_VALUE.SetBitAt(i);
			
			Debug.Assert(TEST_VALUE.BitAt(i) == 1,
						 "Expected Bit Position(" + i + ") to be 1");
		}
	}

	[Test]
	public void Test_UnsetBitAt() {
		int[] TEST_VALUE = GetTestArray();
		
		for (int i = 0; i < LOOP_COUNT; i++) {
			TEST_VALUE.UnsetBitAt(i);
			
			Debug.Assert(TEST_VALUE.BitAt(i) == 0,
						 "Expected Bit Position(" + i + ") to be 0");
		}
	}
	
	[Test]
	public void Test_SetBit() {
		int[] TEST_VALUE = GetTestArray();
		
		for (int i = 0; i < LOOP_COUNT; i++) {
			TEST_VALUE.SetBit(i, 0);
			
			Debug.Assert(TEST_VALUE.BitAt(i) == 0,
						 "Expected Bit Position(" + i + ") to be 0");
						 
			TEST_VALUE.SetBit(i, 1);
						 
			Debug.Assert(TEST_VALUE.BitAt(i) == 1,
						 "Expected Bit Position(" + i + ") to be 1");
		}
	}
	
	[Test]
	public void Test_SetUnsetBit() {
		int[] TEST_VALUE = GetTestArray();
		
		for (int i = 0; i < LOOP_COUNT; i++) {
			TEST_VALUE.SetBit(i, 0);
			TEST_VALUE.SetBit(i, 1);
			
			Debug.Assert(TEST_VALUE.BitAt(i) == 1,
						 "Expected Bit Position(" + i + ") to be 1");
						 
			TEST_VALUE.SetBit(i, 1);
			TEST_VALUE.SetBit(i, 0);
						 
			Debug.Assert(TEST_VALUE.BitAt(i) == 0,
						 "Expected Bit Position(" + i + ") to be 0");
		}
	}

	[Test]
	public void Test_ToggleBitAt() {
		int[] TEST_VALUE = GetTestArray();
		
		for (int i = 0; i < LOOP_COUNT; i++) {
			TEST_VALUE.ToggleBitAt(i);
			
			int inv = TEST_VALUE.BitAt(i);
			
			Debug.Assert(TEST_VALUE.BitAt(i) != EXPTECTED_BITS[i],
							"Expected Toggle(" + inv + ") and InvTest(" + EXPTECTED_BITS[i] + ") to not Match.");
		}
		
		for (int i = 0; i < LOOP_COUNT; i++) {
			TEST_VALUE.ToggleBitAt(i);
			
			int inv = TEST_VALUE.BitAt(i);
			
			Debug.Assert(TEST_VALUE.BitAt(i) == EXPTECTED_BITS[i],
							"Expected Toggle(" + inv + ") and InvTest(" + EXPTECTED_BITS[i] + ") to Match.");
		}
	}
}
