using System;
using UnityEngine;

namespace BitStack {

	/**
	 * Simplifies the usage of Morton3 types. This struct
	 * only holds a single uint32 value which represents the morton key.
	 * Relies on functionality from ValueMortonKeyExtensions.
	 * all of these operations are also available via the uint32 interface.
	 *
	 * Morton Keys can be useful for spatial hashing, or data structures with good
	 * cache locality.
	 */
	public struct MortonKey3 : IEquatable<MortonKey3>, IEquatable<uint>, IEquatable<Vector3> {
		readonly uint mortonKey;

		public MortonKey3(uint mortonKey) {
			this.mortonKey = mortonKey;
		}
		
		public MortonKey3(int mortonKey) {
			#if UNITY_EDITOR || DEBUG
				if (mortonKey < 0) {
					BitDebug.Exception("MortonKey3(int) - morton key must be positive");
				}
			#endif
			
			this.mortonKey = (uint)mortonKey;
		}
		
		public MortonKey3(uint x, uint y, uint z) {
			#if UNITY_EDITOR || DEBUG
				if (x > 1024 || x < 0) {
					BitDebug.Exception("MortonKey3(uint, uint, uint) - morton key x component must be between 0-1023 (10 bits), was " + x);
				}
				
				if (y > 1024 || y < 0) {
					BitDebug.Exception("MortonKey3(uint, uint, uint) - morton key y component must be between 0-1023 (10 bits), was " + y);
				}
				
				if (z > 1024 || z < 0) {
					BitDebug.Exception("MortonKey3(uint, uint, uint) - morton key z component must be between 0-1023 (10 bits), was " + z);
				}
			#endif
			mortonKey = BitMath.EncodeMortonKey(x, y, z);
		}
		
		public MortonKey3(int x, int y, int z) {
			#if UNITY_EDITOR || DEBUG
				if (x > 1024 || x < 0) {
					BitDebug.Exception("MortonKey3(int, int, int) - morton key x component must be between 0-1023 (10 bits), was " + x);
				}
				
				if (y > 1024 || y < 0) {
					BitDebug.Exception("MortonKey3(int, int, int) - morton key y component must be between 0-1023 (10 bits), was " + y);
				}
				
				if (z > 1024 || z < 0) {
					BitDebug.Exception("MortonKey3(int, int, int) - morton key z component must be between 0-1023 (10 bits), was " + z);
				}
			#endif
			mortonKey = BitMath.EncodeMortonKey((uint)x, (uint)y, (uint)z);
		}
		
		public MortonKey3(Vector3 value) {
			mortonKey = value.MortonKey();
		}
		
		public uint Key {
			get {
				return mortonKey;
			}
		}
		
		public Vector3 Value {
			get {
				return Key.DecodeMortonKey3();
			}
		}
		
		public ValueTuple<uint, uint, uint> RawValue {
			get {
				return BitMath.DecodeMortonKey3(Key);
			}
		}
		
		public MortonKey3 IncX() {
			return new MortonKey3(mortonKey.MortonIncX3());
		}
		
		public MortonKey3 IncY() {
			return new MortonKey3(mortonKey.MortonIncY3());
		}
		
		public MortonKey3 IncZ() {
			return new MortonKey3(mortonKey.MortonIncZ3());
		}
		
		public MortonKey3 IncXY() {
			uint key = mortonKey;
			
			key = key.MortonIncX3();
			key = key.MortonIncY3();
			
			return new MortonKey3(key);
		}
		
		public MortonKey3 IncXZ() {
			uint key = mortonKey;
			
			key = key.MortonIncX3();
			key = key.MortonIncZ3();
			
			return new MortonKey3(key);
		}
		
		public MortonKey3 IncYZ() {
			uint key = mortonKey;
			
			key = key.MortonIncY3();
			key = key.MortonIncZ3();
			
			return new MortonKey3(key);
		}
		
		public MortonKey3 IncXYZ() {
			uint key = mortonKey;
			
			key = key.MortonIncX3();
			key = key.MortonIncY3();
			key = key.MortonIncZ3();
			
			return new MortonKey3(key);
		}
		
		public MortonKey3 DecX() {
			return new MortonKey3(mortonKey.MortonDecX3());
		}
		
		public MortonKey3 DecY() {
			return new MortonKey3(mortonKey.MortonDecY3());
		}
		
		public MortonKey3 DecZ() {
			return new MortonKey3(mortonKey.MortonDecZ3());
		}
		
		public MortonKey3 DecXY() {
			uint key = mortonKey;
			
			key = key.MortonDecX3();
			key = key.MortonDecY3();
			
			return new MortonKey3(key);
		}
		
		public MortonKey3 DecXZ() {
			uint key = mortonKey;
			
			key = key.MortonDecX3();
			key = key.MortonDecZ3();
			
			return new MortonKey3(key);
		}
		
		public MortonKey3 DecYZ() {
			uint key = mortonKey;
			
			key = key.MortonDecY3();
			key = key.MortonDecZ3();
			
			return new MortonKey3(key);
		}
		
		public MortonKey3 DecXYZ() {
			uint key = mortonKey;
			
			key = key.MortonDecX3();
			key = key.MortonDecY3();
			key = key.MortonDecZ3();
			
			return new MortonKey3(key);
		}
		
		/**
		 * Overrides - MortonKey3(1,2,3) + MortonKey3(4,5,6) = MortonKey3(5,7,9)
		 */
		public static MortonKey3 operator +(MortonKey3 x, MortonKey3 y) {
			uint sum_x = (x.mortonKey | ValueMortonKeyExtensions.MORTON_YZ3_MASK) + (y.mortonKey & ValueMortonKeyExtensions.MORTON_X3_MASK);
			uint sum_y = (x.mortonKey | ValueMortonKeyExtensions.MORTON_XZ3_MASK) + (y.mortonKey & ValueMortonKeyExtensions.MORTON_Y3_MASK);
			uint sum_z = (x.mortonKey | ValueMortonKeyExtensions.MORTON_XY3_MASK) + (y.mortonKey & ValueMortonKeyExtensions.MORTON_Z3_MASK);
			
			return new MortonKey3((sum_x & ValueMortonKeyExtensions.MORTON_X3_MASK) | (sum_y & ValueMortonKeyExtensions.MORTON_Y3_MASK) | (sum_z & ValueMortonKeyExtensions.MORTON_Z3_MASK));
		}
		
		/**
		 * Overrides - MortonKey3(1,2,3) * MortonKey3(4,5,6) = MortonKey3(4,10,18)
		 */
		public static MortonKey3 operator *(MortonKey3 x, MortonKey3 y) {
			// TO-DO, these needs to be replaced with a more efficient method
			Vector3 vx = x.Value;
			Vector3 vy = y.Value;
			
			return new MortonKey3((uint)(vx.x * vy.x), (uint)(vx.y * vy.y), (uint)(vx.z * vy.z));
		}
		
		/**
		 * Overrides - MortonKey3(1,2,3) * 4 = MortonKey3(4,8,12)
		 */
		public static MortonKey3 operator *(MortonKey3 x, uint val) {
			// TO-DO, these needs to be replaced with a more efficient method
			Vector3 vx = x.Value;
			
			return new MortonKey3((uint)(vx.x * val), (uint)(vx.y * val), (uint)(vx.z * val));
		}
		
		/**
		 * Overrides - MortonKey3(4,5,6) - MortonKey3(1,2,3) = MortonKey3(3,3,3)
		 */
		public static MortonKey3 operator -(MortonKey3 x, MortonKey3 y) {
			uint sum_x = (x.mortonKey & ValueMortonKeyExtensions.MORTON_X3_MASK) - (y.mortonKey & ValueMortonKeyExtensions.MORTON_X3_MASK);
			uint sum_y = (x.mortonKey & ValueMortonKeyExtensions.MORTON_Y3_MASK) - (y.mortonKey & ValueMortonKeyExtensions.MORTON_Y3_MASK);
			uint sum_z = (x.mortonKey & ValueMortonKeyExtensions.MORTON_Z3_MASK) - (y.mortonKey & ValueMortonKeyExtensions.MORTON_Z3_MASK);
			
			return new MortonKey3((sum_x & ValueMortonKeyExtensions.MORTON_X3_MASK) | (sum_y & ValueMortonKeyExtensions.MORTON_Y3_MASK) | (sum_z & ValueMortonKeyExtensions.MORTON_Z3_MASK));
		}

		public bool Equals(MortonKey3 other) {
			return mortonKey == other.mortonKey;
		}

		public bool Equals(uint other) {
			return mortonKey == other;
		}

		public bool Equals(Vector3 other) {
			return mortonKey == other.MortonKey();
		}
		
		public MortonKey3 Copy() {
			return new MortonKey3(Key);
		}
	}
}
