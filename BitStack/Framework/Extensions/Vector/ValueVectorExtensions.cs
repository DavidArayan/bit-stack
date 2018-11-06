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
            
			return MortonKey3(_x, _y, _z);
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

            return MortonKey2(_x, _y);
		}

		private static uint MortonPart3(uint n) {
            // morton n-key
            n = (n ^ (n << 16)) & 0xff0000ff;
            n = (n ^ (n << 8)) & 0x0300f00f;
            n = (n ^ (n << 4)) & 0x030c30c3;
            n = (n ^ (n << 2)) & 0x09249249;

            return n;
        }

		private static uint MortonPart2(uint n) {
            // morton n-key
            n = (n ^ (n << 8)) & 0x00ff00ff;
            n = (n ^ (n << 4)) & 0x0f0f0f0f;
            n = (n ^ (n << 2)) & 0x33333333;
            n = (n ^ (n << 1)) & 0x55555555;

            return n;
        }
        
		private static uint MortonKey3(uint x, uint y, uint z) {
			var cx = MortonPart3(x);
            var cy = MortonPart3(y);
			var cz = MortonPart3(z);

            return (cz << 2) + (cy << 1) + cx;
		}

		private static uint MortonKey2(uint x, uint y) {
            var cx = MortonPart2(x);
            var cy = MortonPart2(y);

            return (cy << 1) + cx;
        }
    }
}
