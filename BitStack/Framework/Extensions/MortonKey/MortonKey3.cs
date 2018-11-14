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
		uint mortonKey;

		public MortonKey3(uint mortonKey) {
			this.mortonKey = mortonKey;
		}
		
		public MortonKey3(uint x, uint y, uint z) {
			mortonKey = BitMath.EncodeMortonKey(x, y, z);
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
		
		public void IncX() {
			mortonKey = mortonKey.MortonIncX3();
		}
		
		public void IncY() {
			mortonKey = mortonKey.MortonIncY3();
		}
		
		public void IncZ() {
			mortonKey = mortonKey.MortonIncZ3();
		}
		
		public void IncXY() {
			IncX();
			IncY();
		}
		
		public void IncXZ() {
			IncX();
			IncZ();
		}
		
		public void IncYZ() {
			IncY();
			IncZ();
		}
		
		public void IncXYZ() {
			IncX();
			IncY();
			IncZ();
		}
		
		public void DecX() {
			mortonKey = mortonKey.MortonDecX3();
		}
		
		public void DecY() {
			mortonKey = mortonKey.MortonDecY3();
		}
		
		public void DecZ() {
			mortonKey = mortonKey.MortonDecZ3();
		}
		
		public void DecXY() {
			DecX();
			DecY();
		}
		
		public void DecXZ() {
			DecX();
			DecZ();
		}
		
		public void DecYZ() {
			DecY();
			DecZ();
		}
		
		public void DecXYZ() {
			DecX();
			DecY();
			DecZ();
		}
		
		/**
		 * Overrides
		 */
		public static MortonKey3 operator +(MortonKey3 x, MortonKey3 y) {
			uint sum_x = (x.mortonKey | ValueMortonKeyExtensions.MORTON_YZ3_MASK) + (y.mortonKey & ValueMortonKeyExtensions.MORTON_X3_MASK);
			uint sum_y = (x.mortonKey | ValueMortonKeyExtensions.MORTON_XZ3_MASK) + (y.mortonKey & ValueMortonKeyExtensions.MORTON_Y3_MASK);
			uint sum_z = (x.mortonKey | ValueMortonKeyExtensions.MORTON_XY3_MASK) + (y.mortonKey & ValueMortonKeyExtensions.MORTON_Z3_MASK);
			
			return new MortonKey3((sum_x & ValueMortonKeyExtensions.MORTON_X3_MASK) | (sum_y & ValueMortonKeyExtensions.MORTON_Y3_MASK) | (sum_z & ValueMortonKeyExtensions.MORTON_Z3_MASK));
		}
		
		public static MortonKey3 operator -(MortonKey3 x, MortonKey3 y) {
			uint sum_x = (x.mortonKey | ValueMortonKeyExtensions.MORTON_X3_MASK) - (y.mortonKey & ValueMortonKeyExtensions.MORTON_X3_MASK);
			uint sum_y = (x.mortonKey | ValueMortonKeyExtensions.MORTON_Y3_MASK) - (y.mortonKey & ValueMortonKeyExtensions.MORTON_Y3_MASK);
			uint sum_z = (x.mortonKey | ValueMortonKeyExtensions.MORTON_Z3_MASK) - (y.mortonKey & ValueMortonKeyExtensions.MORTON_Z3_MASK);
			
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
	}
}
