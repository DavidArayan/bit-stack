namespace BitStack {
	public class BitMath {
		public static uint MortonKey3(uint x, uint y, uint z) {
			var cx = MortonPart3(x);
			var cy = MortonPart3(y);
			var cz = MortonPart3(z);
			
			return (cz << 2) + (cy << 1) + cx;
		}

		public static uint MortonKey2(uint x, uint y) {
			var cx = MortonPart2(x);
			var cy = MortonPart2(y);
			
			return (cy << 1) + cx;
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
	}
}
