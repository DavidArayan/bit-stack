using UnityEngine;
using NUnit.Framework;
using BitStack;

/**
 *
 */
public class ValueMortonKeyTests {

	[Test]
	public void Test_MortonKeyEncodeZero() {
		Vector3 test = new Vector3(0,0,0);
		MortonKey3 mortonKey = new MortonKey3(test);
		
		Debug.Assert(mortonKey.Key == 0,
					 "Expected Test(" + test + ") to be Equal to Key(" + mortonKey.Key + ")");
	}
	
	[Test]
	public void Test_MortonKeyEncodeDecode() {
		for (int x = 4; x < 9; x++) {
			for (int y = 3; y < 10; y++) {
				for (int z = 2; z < 11; z++) {
					Vector3 test = new Vector3(x,y,z);
					MortonKey3 mortonKey = new MortonKey3(test);
					Vector3 decode = mortonKey.Value;
					
					Debug.Assert(test == decode,
								 "Expected Test(" + test + ") to be Equal to Key(" + decode + ")");
				}
			}
		}
	}
	
	[Test]
	public void Test_MortonKeyEncodeDecodeIncX() {
		for (int x = 4; x < 9; x++) {
			for (int y = 3; y < 10; y++) {
				for (int z = 2; z < 11; z++) {
					Vector3 test = new Vector3(x,y,z);
					Vector3 testInc = new Vector3(x+1,y,z);
					
					MortonKey3 mortonKey = new MortonKey3(test);
					mortonKey.IncX();
					Vector3 decode = mortonKey.Value;
					
					Debug.Assert(testInc == decode,
								 "Expected Test(" + testInc + ") to be Equal to Key(" + decode + ") via Original(" + test + ")");
				}
			}
		}
	}
	
	[Test]
	public void Test_MortonKeyEncodeDecodeIncXY() {
		for (int x = 4; x < 9; x++) {
			for (int y = 3; y < 10; y++) {
				for (int z = 2; z < 11; z++) {
					Vector3 test = new Vector3(x,y,z);
					Vector3 testInc = new Vector3(x+1,y+1,z);
					
					MortonKey3 mortonKey = new MortonKey3(test);
					mortonKey.IncXY();
					Vector3 decode = mortonKey.Value;
					
					Debug.Assert(testInc == decode,
								 "Expected Test(" + testInc + ") to be Equal to Key(" + decode + ") via Original(" + test + ")");
				}
			}
		}
	}
	
	[Test]
	public void Test_MortonKeyEncodeDecodeIncXZ() {
		for (int x = 4; x < 9; x++) {
			for (int y = 3; y < 10; y++) {
				for (int z = 2; z < 11; z++) {
					Vector3 test = new Vector3(x,y,z);
					Vector3 testInc = new Vector3(x+1,y,z+1);
					
					MortonKey3 mortonKey = new MortonKey3(test);
					mortonKey.IncXZ();
					Vector3 decode = mortonKey.Value;
					
					Debug.Assert(testInc == decode,
								 "Expected Test(" + testInc + ") to be Equal to Key(" + decode + ") via Original(" + test + ")");
				}
			}
		}
	}
	
	[Test]
	public void Test_MortonKeyEncodeDecodeIncYZ() {
		for (int x = 4; x < 9; x++) {
			for (int y = 3; y < 10; y++) {
				for (int z = 2; z < 11; z++) {
					Vector3 test = new Vector3(x,y,z);
					Vector3 testInc = new Vector3(x,y+1,z+1);
					
					MortonKey3 mortonKey = new MortonKey3(test);
					mortonKey.IncYZ();
					Vector3 decode = mortonKey.Value;
					
					Debug.Assert(testInc == decode,
								 "Expected Test(" + testInc + ") to be Equal to Key(" + decode + ") via Original(" + test + ")");
				}
			}
		}
	}
	
	[Test]
	public void Test_MortonKeyEncodeDecodeIncXYZ() {
		for (int x = 4; x < 9; x++) {
			for (int y = 3; y < 10; y++) {
				for (int z = 2; z < 11; z++) {
					Vector3 test = new Vector3(x,y,z);
					Vector3 testInc = new Vector3(x+1,y+1,z+1);
					
					MortonKey3 mortonKey = new MortonKey3(test);
					mortonKey.IncXYZ();
					Vector3 decode = mortonKey.Value;
					
					Debug.Assert(testInc == decode,
								 "Expected Test(" + testInc + ") to be Equal to Key(" + decode + ") via Original(" + test + ")");
				}
			}
		}
	}
	
	[Test]
	public void Test_MortonKeyEncodeDecodeDecX() {
		for (int x = 4; x < 9; x++) {
			for (int y = 3; y < 10; y++) {
				for (int z = 2; z < 11; z++) {
					Vector3 test = new Vector3(x,y,z);
					Vector3 testInc = new Vector3(x-1,y,z);
					
					MortonKey3 mortonKey = new MortonKey3(test);
					mortonKey.DecX();
					Vector3 decode = mortonKey.Value;
					
					Debug.Assert(testInc == decode,
								 "Expected Test(" + testInc + ") to be Equal to Key(" + decode + ") via Original(" + test + ")");
				}
			}
		}
	}
	
	[Test]
	public void Test_MortonKeyEncodeDecodeIncY() {
		for (int x = 4; x < 9; x++) {
			for (int y = 3; y < 10; y++) {
				for (int z = 2; z < 11; z++) {
					Vector3 test = new Vector3(x,y,z);
					Vector3 testInc = new Vector3(x,y+1,z);
					
					MortonKey3 mortonKey = new MortonKey3(test);
					mortonKey.IncY();
					Vector3 decode = mortonKey.Value;
					
					Debug.Assert(testInc == decode,
								 "Expected Test(" + testInc + ") to be Equal to Key(" + decode + ") via Original(" + test + ")");
				}
			}
		}
	}
	
	[Test]
	public void Test_MortonKeyEncodeDecodeDecY() {
		for (int x = 4; x < 9; x++) {
			for (int y = 3; y < 10; y++) {
				for (int z = 2; z < 11; z++) {
					Vector3 test = new Vector3(x,y,z);
					Vector3 testInc = new Vector3(x,y-1,z);
					
					MortonKey3 mortonKey = new MortonKey3(test);
					mortonKey.DecY();
					Vector3 decode = mortonKey.Value;
					
					Debug.Assert(testInc == decode,
								 "Expected Test(" + testInc + ") to be Equal to Key(" + decode + ") via Original(" + test + ")");
				}
			}
		}
	}
	
	[Test]
	public void Test_MortonKeyEncodeDecodeIncZ() {
		for (int x = 4; x < 9; x++) {
			for (int y = 3; y < 10; y++) {
				for (int z = 2; z < 11; z++) {
					Vector3 test = new Vector3(x,y,z);
					Vector3 testInc = new Vector3(x,y,z+1);
					
					MortonKey3 mortonKey = new MortonKey3(test);
					mortonKey.IncZ();
					Vector3 decode = mortonKey.Value;
					
					Debug.Assert(testInc == decode,
								 "Expected Test(" + testInc + ") to be Equal to Key(" + decode + ") via Original(" + test + ")");
				}
			}
		}
	}
	
	[Test]
	public void Test_MortonKeyEncodeDecodeDecZ() {
		for (int x = 4; x < 9; x++) {
			for (int y = 3; y < 10; y++) {
				for (int z = 2; z < 11; z++) {
					Vector3 test = new Vector3(x,y,z);
					Vector3 testInc = new Vector3(x,y,z-1);
					
					MortonKey3 mortonKey = new MortonKey3(test);
					mortonKey.DecZ();
					Vector3 decode = mortonKey.Value;
					
					Debug.Assert(testInc == decode,
								 "Expected Test(" + testInc + ") to be Equal to Key(" + decode + ") via Original(" + test + ")");
				}
			}
		}
	}
	
	[Test]
	public void Test_MortonKeyEncodeDecodeDecXY() {
		for (int x = 4; x < 9; x++) {
			for (int y = 3; y < 10; y++) {
				for (int z = 2; z < 11; z++) {
					Vector3 test = new Vector3(x,y,z);
					Vector3 testInc = new Vector3(x-1,y-1,z);
					
					MortonKey3 mortonKey = new MortonKey3(test);
					mortonKey.DecXY();
					Vector3 decode = mortonKey.Value;
					
					Debug.Assert(testInc == decode,
								 "Expected Test(" + testInc + ") to be Equal to Key(" + decode + ") via Original(" + test + ")");
				}
			}
		}
	}
	
	[Test]
	public void Test_MortonKeyEncodeDecodeDecXZ() {
		for (int x = 4; x < 9; x++) {
			for (int y = 3; y < 10; y++) {
				for (int z = 2; z < 11; z++) {
					Vector3 test = new Vector3(x,y,z);
					Vector3 testInc = new Vector3(x-1,y,z-1);
					
					MortonKey3 mortonKey = new MortonKey3(test);
					mortonKey.DecXZ();
					Vector3 decode = mortonKey.Value;
					
					Debug.Assert(testInc == decode,
								 "Expected Test(" + testInc + ") to be Equal to Key(" + decode + ") via Original(" + test + ")");
				}
			}
		}
	}
	
	[Test]
	public void Test_MortonKeyEncodeDecodeDecYZ() {
		for (int x = 4; x < 9; x++) {
			for (int y = 3; y < 10; y++) {
				for (int z = 2; z < 11; z++) {
					Vector3 test = new Vector3(x,y,z);
					Vector3 testInc = new Vector3(x,y-1,z-1);
					
					MortonKey3 mortonKey = new MortonKey3(test);
					mortonKey.DecYZ();
					Vector3 decode = mortonKey.Value;
					
					Debug.Assert(testInc == decode,
								 "Expected Test(" + testInc + ") to be Equal to Key(" + decode + ") via Original(" + test + ")");
				}
			}
		}
	}
	
	[Test]
	public void Test_MortonKeyEncodeDecodeDecXYZ() {
		for (int x = 4; x < 9; x++) {
			for (int y = 3; y < 10; y++) {
				for (int z = 2; z < 11; z++) {
					Vector3 test = new Vector3(x,y,z);
					Vector3 testInc = new Vector3(x-1,y-1,z-1);
					
					MortonKey3 mortonKey = new MortonKey3(test);
					mortonKey.DecXYZ();
					Vector3 decode = mortonKey.Value;
					
					Debug.Assert(testInc == decode,
								 "Expected Test(" + testInc + ") to be Equal to Key(" + decode + ") via Original(" + test + ")");
				}
			}
		}
	}
}
