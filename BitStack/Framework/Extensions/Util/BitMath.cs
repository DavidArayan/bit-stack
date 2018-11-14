namespace BitStack {
	public sealed class BitMath {
		public static uint EncodeMortonKey(uint x, uint y, uint z) {
			var cx = MortonPart3Encode(x);
			var cy = MortonPart3Encode(y);
			var cz = MortonPart3Encode(z);
			
			return (cz << 2) + (cy << 1) + cx;
		}
		
		public static ValueTuple<uint, uint, uint> DecodeMortonKey3(uint mortonKey) {
			var cx = MortonPart3Decode(mortonKey >> 0);
			var cy = MortonPart3Decode(mortonKey >> 1);
			var cz = MortonPart3Decode(mortonKey >> 2);
			
			return new ValueTuple<uint, uint, uint>(cx, cy, cz);
		}

		public static uint EncodeMortonKey(uint x, uint y) {
			var cx = MortonPart2Encode(x);
			var cy = MortonPart2Encode(y);
			
			return (cy << 1) + cx;
		}
		
		public static ValueTuple<uint, uint> DecodeMortonKey2(uint mortonKey) {
			var cx = MortonPart3Decode(mortonKey >> 0);
			var cy = MortonPart3Decode(mortonKey >> 1);
			
			return new ValueTuple<uint, uint>(cx, cy);
		}
		
		public static uint MortonPart3Encode(uint n) {
			n &= 0x000003ff;
			
			n = (n ^ (n << 16)) & 0xff0000ff;
			n = (n ^ (n << 8)) & 0x0300f00f;
			n = (n ^ (n << 4)) & 0x030c30c3;
			n = (n ^ (n << 2)) & 0x09249249;
			
			return n;
		}
		
		public static uint MortonPart3Decode(uint n) {
			n &= 0x09249249;
			
			n = (n ^ (n >> 2)) & 0x030c30c3;
			n = (n ^ (n >> 4)) & 0x0300f00f;
			n = (n ^ (n >> 8)) & 0xff0000ff;
			n = (n ^ (n >> 16)) & 0x000003ff;
			
			return n;
		}

		public static uint MortonPart2Encode(uint n) {
			n &= 0x0000ffff;
			
			n = (n ^ (n << 8)) & 0x00ff00ff;
			n = (n ^ (n << 4)) & 0x0f0f0f0f;
			n = (n ^ (n << 2)) & 0x33333333;
			n = (n ^ (n << 1)) & 0x55555555;
			
			return n;
		}

		public static uint MortonPart2Decode(uint n) {
			n &= 0x55555555;
			
			n = (n ^ (n >> 1)) & 0x33333333;
			n = (n ^ (n >> 2)) & 0x0f0f0f0f;
			n = (n ^ (n >> 4)) & 0x00ff00ff;
			n = (n ^ (n >> 8)) & 0x0000ffff;
			
			return n;
		}
	}
}
