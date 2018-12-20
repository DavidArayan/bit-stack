using UnityEngine;

#if NET_4_6
using System.Runtime.CompilerServices;
#endif

namespace BitStack {

	/**
	 * Extension operations for 2 component or 3 component
	 * Morton Keys. 
	 *
	 * 2 component keys are 16 bits per component
	 * 3 component keys are 10 bits per component
	 *
	 * CRITICAL CHANGES
	 * 20/12/2018 - for .NET 4.6 targets, all functions are hinted to use AggressiveInlining
	 */
	public static class ValueMortonKeyExtensions {
		public const uint MORTON_X3_MASK = 0x9249249;
		public const uint MORTON_Y3_MASK = 0x12492492;
		public const uint MORTON_Z3_MASK = 0x24924924;

		public const uint MORTON_X2_MASK = 0x55555555;
		public const uint MORTON_Y2_MASK = 0xAAAAAAAA;

		public const uint MORTON_XY3_MASK = MORTON_X3_MASK | MORTON_Y3_MASK;
		public const uint MORTON_XZ3_MASK = MORTON_X3_MASK | MORTON_Z3_MASK;
		public const uint MORTON_YZ3_MASK = MORTON_Y3_MASK | MORTON_Z3_MASK;

		/**
		 * Given a Vector3 where each part of the vector is a 10 bit value
		 * calculate the Morton Key and return. The Morton Key can be used
		 * to effectively "Hash" this vector. Note that the components will
		 * be cast into unsigned integer values.
		 * 
		 * Maximum value of x component = 2^10 = 0-1023
		 * Maximum value of y component = 2^10 = 0-1023
		 * Maximum value of z component = 2^10 = 0-1023
		 */
		#if NET_4_6
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		#endif
		public static uint MortonKey(this Vector3 vec) {
			var _x = (uint)vec.x;
			var _y = (uint)vec.y;
			var _z = (uint)vec.z;

			return BitMath.EncodeMortonKey(_x, _y, _z);
		}

		/**
		 * Given a Morton Key previously encoded using a 3 component
		 * Vector. Decode the key and return the original 3 component Vector.
		 */
		#if NET_4_6
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		#endif
		public static Vector3 DecodeMortonKey3(this uint mortonKey) {
			var decodedKey = BitMath.DecodeMortonKey3(mortonKey);

			return new Vector3(decodedKey.Item1, decodedKey.Item2, decodedKey.Item3);
		}

		/**
		 * Given a Vector2 where each part of the vector is a 16 bit value
		 * calculate the Morton Key and return. The Morton Key can be used
		 * to effectively "Hash" this vector. Note that the components will
		 * be cast into integer values.
		 * 
		 * Maximum value of x component = 2^16 = 0-65535
		 * Maximum value of y component = 2^16 = 0-65535
		 */
		#if NET_4_6
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		#endif
		public static uint MortonKey(this Vector2 vec) {
			var _x = (uint)vec.x;
			var _y = (uint)vec.y;

			return BitMath.EncodeMortonKey(_x, _y);
		}

		/**
		 * Given a Morton Key previously encoded using a 2 component
		 * Vector. Decode the key and return the original 2 component Vector.
		 */
		#if NET_4_6
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		#endif
		public static Vector2 DecodeMortonKey2(this uint mortonKey) {
			var decodedKey = BitMath.DecodeMortonKey2(mortonKey);

			return new Vector2(decodedKey.Item1, decodedKey.Item2);
		}
		
		/**
		 * Given a 3 component Meton Key, increment the X component by 1
		 * unit and return the value. This is much more efficient than
		 * encoding/decoding for LUT operations.
		 */
		#if NET_4_6
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		#endif
		public static uint MortonIncX3(this uint mortonKey) {
			uint sum = (mortonKey | MORTON_YZ3_MASK) + 1;
			return (sum & MORTON_X3_MASK) | (mortonKey & MORTON_YZ3_MASK);
		}
		
		/**
		 * Given a 3 component Meton Key, increment the Y component by 1
		 * unit and return the value. This is much more efficient than
		 * encoding/decoding for LUT operations.
		 */
		#if NET_4_6
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		#endif
		public static uint MortonIncY3(this uint mortonKey) {
			uint sum = (mortonKey | MORTON_XZ3_MASK) + 2;
			return (sum & MORTON_Y3_MASK) | (mortonKey & MORTON_XZ3_MASK);
		}
		
		/**
		 * Given a 3 component Meton Key, increment the Z component by 1
		 * unit and return the value. This is much more efficient than
		 * encoding/decoding for LUT operations.
		 */
		#if NET_4_6
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		#endif
		public static uint MortonIncZ3(this uint mortonKey) {
			uint sum = (mortonKey | MORTON_XY3_MASK) + 1;
			return (sum & MORTON_Z3_MASK) | (mortonKey & MORTON_XY3_MASK);
		}

		/**
		 * Given a 3 component Meton Key, decrement the X component by 1
		 * unit and return the value. This is much more efficient than
		 * encoding/decoding for LUT operations.
		 */
		#if NET_4_6
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		#endif
		public static uint MortonDecX3(this uint mortonKey) {
			uint diff = (mortonKey & MORTON_X3_MASK) - 1;
			return (diff & MORTON_X3_MASK) | (mortonKey & MORTON_YZ3_MASK);
		}
		
		/**
		 * Given a 3 component Meton Key, decrement the Y component by 1
		 * unit and return the value. This is much more efficient than
		 * encoding/decoding for LUT operations.
		 */
		#if NET_4_6
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		#endif
		public static uint MortonDecY3(this uint mortonKey) {
			uint diff = (mortonKey & MORTON_Y3_MASK) - 2;
			return (diff & MORTON_Y3_MASK) | (mortonKey & MORTON_XZ3_MASK);
		}
		
		/**
		 * Given a 3 component Meton Key, decrement the Z component by 1
		 * unit and return the value. This is much more efficient than
		 * encoding/decoding for LUT operations.
		 */
		#if NET_4_6
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		#endif
		public static uint MortonDecZ3(this uint mortonKey) {
			uint diff = (mortonKey & MORTON_Z3_MASK) - 1;
			return (diff & MORTON_Z3_MASK) | (mortonKey & MORTON_XY3_MASK);
		}
		
		/**
		 * Given a 2 component Meton Key, increment the X component by 1
		 * unit and return the value. This is much more efficient than
		 * encoding/decoding for LUT operations.
		 */
		#if NET_4_6
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		#endif
		public static uint MortonIncX2(this uint mortonKey) {
			uint sum = (mortonKey | MORTON_Y2_MASK) + 2;
			return (sum & MORTON_X2_MASK) | (mortonKey & MORTON_Y2_MASK);
		}
		
		/**
		 * Given a 2 component Meton Key, increment the Y component by 1
		 * unit and return the value. This is much more efficient than
		 * encoding/decoding for LUT operations.
		 */
		#if NET_4_6
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		#endif
		public static uint MortonIncY2(this uint mortonKey) {
			uint sum = (mortonKey | MORTON_X2_MASK) + 1;
			return (sum & MORTON_Y2_MASK) | (mortonKey & MORTON_X2_MASK);
		}
		
		/**
		 * Given a 2 component Meton Key, decrement the X component by 1
		 * unit and return the value. This is much more efficient than
		 * encoding/decoding for LUT operations.
		 */
		#if NET_4_6
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		#endif
		public static uint MortonDecX2(this uint mortonKey) {
			uint diff = (mortonKey & MORTON_X2_MASK) - 2;
			return (diff & MORTON_X2_MASK) | (mortonKey & MORTON_Y2_MASK);
		}
		
		/**
		 * Given a 2 component Meton Key, decrement the Y component by 1
		 * unit and return the value. This is much more efficient than
		 * encoding/decoding for LUT operations.
		 */
		#if NET_4_6
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		#endif
		public static uint MortonDecY2(this uint mortonKey) {
			uint diff = (mortonKey & MORTON_Y2_MASK) - 1;
			return (diff & MORTON_Y2_MASK) | (mortonKey & MORTON_X2_MASK);
		}
	}
}
