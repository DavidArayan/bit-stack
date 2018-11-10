using UnityEngine;

namespace BitStack {
	public static class ValueVectorExtensions {
		/**
		 * Given a Vector3 where each part of the vector is a 10 bit value
		 * calculate the Morton Key and return. The Morton Key can be used
		 * to effectively "Hash" this vector. Note that the components will
		 * be cast into integer values.
		 * 
		 * Maximum value of x component = 2^10 = 0-1023
		 * Maximum value of y component = 2^10 = 0-1023
		 * Maximum value of z component = 2^10 = 0-1023
		 */
		public static uint MortonKey(this Vector3 vec) {
			var _x = (uint)vec.x;
			var _y = (uint)vec.y;
			var _z = (uint)vec.z;

			return BitMath.MortonKey3(_x, _y, _z);
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
		public static uint MortonKey(this Vector2 vec) {
			var _x = (uint)vec.x;
			var _y = (uint)vec.y;
			
			return BitMath.MortonKey2(_x, _y);
		}
	}
}
