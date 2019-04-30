using UnityEngine;
using NUnit.Framework;
using BitStack;

public static sealed class ValueMortonKeyTests {

	[Test]
	public static void Test_MortonKeyEncodeZero() {
		Vector3 test = new Vector3(0,0,0);
		MortonKey3 mortonKey = new MortonKey3(test);

		Debug.Assert(mortonKey.key == 0, "Expected Test(" + test + ") to be Equal to Key(" + mortonKey.key + ")");
	}
	
	[Test]
	public static void Test_MortonKeyEncodeDecode() {
		for (int x = 4; x < 9; x++) {
			for (int y = 3; y < 10; y++) {
				for (int z = 2; z < 11; z++) {
					Vector3 test = new Vector3(x,y,z);
					MortonKey3 mortonKey = new MortonKey3(test);
					Vector3 decode = mortonKey.Value;
					
					Debug.Assert(test == decode, "Expected Test(" + test + ") to be Equal to Key(" + decode + ")");
				}
			}
		}
	}
	
	[Test]
	public static void Test_MortonKeyEncodeDecodeIncX() {
		for (int x = 4; x < 9; x++) {
			for (int y = 3; y < 10; y++) {
				for (int z = 2; z < 11; z++) {
					Vector3 test = new Vector3(x,y,z);
					Vector3 testInc = new Vector3(x+1,y,z);
					
					MortonKey3 mortonKey = new MortonKey3(test);
					MortonKey3 testKey = mortonKey.IncX();
					Vector3 decode = testKey.Value;
					
					Debug.Assert(testInc == decode, "Expected Test(" + testInc + ") to be Equal to Key(" + decode + ") via Original(" + test + ")");
				}
			}
		}
	}
	
	[Test]
	public static void Test_MortonKeyEncodeDecodeIncXY() {
		for (int x = 4; x < 9; x++) {
			for (int y = 3; y < 10; y++) {
				for (int z = 2; z < 11; z++) {
					Vector3 test = new Vector3(x,y,z);
					Vector3 testInc = new Vector3(x+1,y+1,z);
					
					MortonKey3 mortonKey = new MortonKey3(test);
					MortonKey3 testKey = mortonKey.IncXY();
					Vector3 decode = testKey.Value;
					
					
					Debug.Assert(testInc == decode, "Expected Test(" + testInc + ") to be Equal to Key(" + decode + ") via Original(" + test + ")");
				}
			}
		}
	}
	
	[Test]
	public static void Test_MortonKeyEncodeDecodeIncXZ() {
		for (int x = 4; x < 9; x++) {
			for (int y = 3; y < 10; y++) {
				for (int z = 2; z < 11; z++) {
					Vector3 test = new Vector3(x,y,z);
					Vector3 testInc = new Vector3(x+1,y,z+1);
					
					MortonKey3 mortonKey = new MortonKey3(test);
					MortonKey3 testKey = mortonKey.IncXZ();
					Vector3 decode = testKey.Value;
					
					Debug.Assert(testInc == decode, "Expected Test(" + testInc + ") to be Equal to Key(" + decode + ") via Original(" + test + ")");
				}
			}
		}
	}
	
	[Test]
	public static oid Test_MortonKeyEncodeDecodeIncYZ() {
		for (int x = 4; x < 9; x++) {
			for (int y = 3; y < 10; y++) {
				for (int z = 2; z < 11; z++) {
					Vector3 test = new Vector3(x,y,z);
					Vector3 testInc = new Vector3(x,y+1,z+1);
					
					MortonKey3 mortonKey = new MortonKey3(test);
					MortonKey3 testKey = mortonKey.IncYZ();
					Vector3 decode = testKey.Value;
					
					Debug.Assert(testInc == decode, "Expected Test(" + testInc + ") to be Equal to Key(" + decode + ") via Original(" + test + ")");
				}
			}
		}
	}
	
	[Test]
	public static void Test_MortonKeyEncodeDecodeIncXYZ() {
		for (int x = 4; x < 9; x++) {
			for (int y = 3; y < 10; y++) {
				for (int z = 2; z < 11; z++) {
					Vector3 test = new Vector3(x,y,z);
					Vector3 testInc = new Vector3(x+1,y+1,z+1);
					
					MortonKey3 mortonKey = new MortonKey3(test);
					MortonKey3 testKey = mortonKey.IncXYZ();
					Vector3 decode = testKey.Value;
					
					Debug.Assert(testInc == decode, "Expected Test(" + testInc + ") to be Equal to Key(" + decode + ") via Original(" + test + ")");
				}
			}
		}
	}
	
	[Test]
	public static void Test_MortonKeyEncodeDecodeDecX() {
		for (int x = 4; x < 9; x++) {
			for (int y = 3; y < 10; y++) {
				for (int z = 2; z < 11; z++) {
					Vector3 test = new Vector3(x,y,z);
					Vector3 testInc = new Vector3(x-1,y,z);
					
					MortonKey3 mortonKey = new MortonKey3(test);
					MortonKey3 testKey = mortonKey.DecX();
					Vector3 decode = testKey.Value;
					
					Debug.Assert(testInc == decode, "Expected Test(" + testInc + ") to be Equal to Key(" + decode + ") via Original(" + test + ")");
				}
			}
		}
	}
	
	[Test]
	public static void Test_MortonKeyEncodeDecodeIncY() {
		for (int x = 4; x < 9; x++) {
			for (int y = 3; y < 10; y++) {
				for (int z = 2; z < 11; z++) {
					Vector3 test = new Vector3(x,y,z);
					Vector3 testInc = new Vector3(x,y+1,z);
					
					MortonKey3 mortonKey = new MortonKey3(test);
					MortonKey3 testKey = mortonKey.IncY();
					Vector3 decode = testKey.Value;
					
					Debug.Assert(testInc == decode, "Expected Test(" + testInc + ") to be Equal to Key(" + decode + ") via Original(" + test + ")");
				}
			}
		}
	}
	
	[Test]
	public static void Test_MortonKeyEncodeDecodeDecY() {
		for (int x = 4; x < 9; x++) {
			for (int y = 3; y < 10; y++) {
				for (int z = 2; z < 11; z++) {
					Vector3 test = new Vector3(x,y,z);
					Vector3 testInc = new Vector3(x,y-1,z);
					
					MortonKey3 mortonKey = new MortonKey3(test);
					MortonKey3 testKey = mortonKey.DecY();
					Vector3 decode = testKey.Value;
					
					Debug.Assert(testInc == decode, "Expected Test(" + testInc + ") to be Equal to Key(" + decode + ") via Original(" + test + ")");
				}
			}
		}
	}
	
	[Test]
	public static void Test_MortonKeyEncodeDecodeIncZ() {
		for (int x = 4; x < 9; x++) {
			for (int y = 3; y < 10; y++) {
				for (int z = 2; z < 11; z++) {
					Vector3 test = new Vector3(x,y,z);
					Vector3 testInc = new Vector3(x,y,z+1);
					
					MortonKey3 mortonKey = new MortonKey3(test);
					MortonKey3 testKey = mortonKey.IncZ();
					Vector3 decode = testKey.Value;
					
					Debug.Assert(testInc == decode, "Expected Test(" + testInc + ") to be Equal to Key(" + decode + ") via Original(" + test + ")");
				}
			}
		}
	}
	
	[Test]
	public static void Test_MortonKeyEncodeDecodeDecZ() {
		for (int x = 4; x < 9; x++) {
			for (int y = 3; y < 10; y++) {
				for (int z = 2; z < 11; z++) {
					Vector3 test = new Vector3(x,y,z);
					Vector3 testInc = new Vector3(x,y,z-1);
					
					MortonKey3 mortonKey = new MortonKey3(test);
					MortonKey3 testKey = mortonKey.DecZ();
					Vector3 decode = testKey.Value;
					
					Debug.Assert(testInc == decode, "Expected Test(" + testInc + ") to be Equal to Key(" + decode + ") via Original(" + test + ")");
				}
			}
		}
	}
	
	[Test]
	public static void Test_MortonKeyEncodeDecodeDecXY() {
		for (int x = 4; x < 9; x++) {
			for (int y = 3; y < 10; y++) {
				for (int z = 2; z < 11; z++) {
					Vector3 test = new Vector3(x,y,z);
					Vector3 testInc = new Vector3(x-1,y-1,z);
					
					MortonKey3 mortonKey = new MortonKey3(test);
					MortonKey3 testKey = mortonKey.DecXY();
					Vector3 decode = testKey.Value;
					
					Debug.Assert(testInc == decode, "Expected Test(" + testInc + ") to be Equal to Key(" + decode + ") via Original(" + test + ")");
				}
			}
		}
	}
	
	[Test]
	public static void Test_MortonKeyEncodeDecodeDecXZ() {
		for (int x = 4; x < 9; x++) {
			for (int y = 3; y < 10; y++) {
				for (int z = 2; z < 11; z++) {
					Vector3 test = new Vector3(x,y,z);
					Vector3 testInc = new Vector3(x-1,y,z-1);
					
					MortonKey3 mortonKey = new MortonKey3(test);
					MortonKey3 testKey = mortonKey.DecXZ();
					Vector3 decode = testKey.Value;
					
					Debug.Assert(testInc == decode, "Expected Test(" + testInc + ") to be Equal to Key(" + decode + ") via Original(" + test + ")");
				}
			}
		}
	}
	
	[Test]
	public static void Test_MortonKeyEncodeDecodeDecYZ() {
		for (int x = 4; x < 9; x++) {
			for (int y = 3; y < 10; y++) {
				for (int z = 2; z < 11; z++) {
					Vector3 test = new Vector3(x,y,z);
					Vector3 testInc = new Vector3(x,y-1,z-1);
					
					MortonKey3 mortonKey = new MortonKey3(test);
					MortonKey3 testKey = mortonKey.DecYZ();
					Vector3 decode = testKey.Value;
					
					Debug.Assert(testInc == decode, "Expected Test(" + testInc + ") to be Equal to Key(" + decode + ") via Original(" + test + ")");
				}
			}
		}
	}
	
	[Test]
	public static void Test_MortonKeyEncodeDecodeDecXYZ() {
		for (int x = 4; x < 9; x++) {
			for (int y = 3; y < 10; y++) {
				for (int z = 2; z < 11; z++) {
					Vector3 test = new Vector3(x,y,z);
					Vector3 testInc = new Vector3(x-1,y-1,z-1);
					
					MortonKey3 mortonKey = new MortonKey3(test);
					MortonKey3 testKey = mortonKey.DecXYZ();
					Vector3 decode = testKey.Value;
					
					Debug.Assert(testInc == decode, "Expected Test(" + testInc + ") to be Equal to Key(" + decode + ") via Original(" + test + ")");
				}
			}
		}
	}
	
	[Test]
	public static void Test_MortonKeyAdd() {
		for (int x = 4; x < 9; x++) {
			for (int y = 3; y < 10; y++) {
				for (int z = 2; z < 11; z++) {
					Vector3 xa = new Vector3(z, y, x);
					Vector3 ya = new Vector3(x, z, y);
					
					MortonKey3 xm = new MortonKey3(xa);
					MortonKey3 ym = new MortonKey3(ya);
					
					MortonKey3 sum = xm + ym;
					Vector3 testInc = xa + ya;
					Vector3 decode = sum.Value;
					
					Debug.Assert(testInc == decode, "Expected Test(" + testInc + ") to be Equal to Key(" + decode + ")");
				}
			}
		}
	}
	
	[Test]
	public static void Test_MortonKeySub() {
		for (int x = 4; x < 6; x++) {
			for (int y = 8; y < 10; y++) {
				for (int z = 12; z < 16; z++) {
					Vector3 xa = new Vector3(z, y, z);
					Vector3 ya = new Vector3(x, x, y);
					
					MortonKey3 xm = new MortonKey3(xa);
					MortonKey3 ym = new MortonKey3(ya);
					
					MortonKey3 sum = xm - ym;
					Vector3 testInc = xa - ya;
					Vector3 decode = sum.Value;
					
					Debug.Assert(testInc == decode, "Expected Test(" + testInc + ") to be Equal to Key(" + decode + ")");
				}
			}
		}
	}
	
	[Test]
	public static void Test_MortonKeyMul() {
		for (int x = 4; x < 6; x++) {
			for (int y = 8; y < 10; y++) {
				for (int z = 12; z < 16; z++) {
					Vector3 xa = new Vector3(z, y, z);
					Vector3 ya = new Vector3(x, x, y);
					
					MortonKey3 xm = new MortonKey3(xa);
					MortonKey3 ym = new MortonKey3(ya);
					
					MortonKey3 sum = xm * ym;
					Vector3 testInc = xa;
					
					testInc.x *= ya.x;
					testInc.y *= ya.y;
					testInc.z *= ya.z;
					
					Vector3 decode = sum.Value;

					Debug.Assert(testInc == decode, "Expected Test(" + testInc + ") to be Equal to Key(" + decode + ")");
				}
			}
		}
	}
	
	[Test]
	public static void Test_MortonKeyMulVal() {
		for (int x = 4; x < 6; x++) {
			for (int y = 8; y < 10; y++) {
				for (int z = 12; z < 16; z++) {
					Vector3 xa = new Vector3(z, y, z);
					
					MortonKey3 xm = new MortonKey3(xa);
					
					MortonKey3 sum = xm * 5;
					Vector3 testInc = xa * 5;
					
					Vector3 decode = sum.Value;
					
					Debug.Assert(testInc == decode, "Expected Test(" + testInc + ") to be Equal to Key(" + decode + ")");
				}
			}
		}
	}
}
