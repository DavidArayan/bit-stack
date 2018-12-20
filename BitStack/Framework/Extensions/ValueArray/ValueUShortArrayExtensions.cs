#if NET_4_6
using System.Runtime.CompilerServices;
#endif

namespace BitStack {
	
	/**
	 * An Extension of the ValueUShortExtension which allows working with bits
	 * on an array of values. All functionality is piped directly to the
	 * ValueUShortExtension whenever possible. 
	 *
	 * Since Arrays are a reference type, some functions will not return 
	 * anything and will modify the array value directly.
	 *
	 * NOTICE ABOUT PERFORMANCE
	 * 
	 * UNITY_EDITOR or DEBUG flags ensure that common errors are caught. These
	 * flags are removed in production mode so don't rely on try/catch methods.
	 * If performing benchmarks, ensure that the flags are not taken into account.
	 * The flags ensure that common problems are caught in code and taken care of.
	 *
	 * CRITICAL CHANGES
	 * 20/12/2018 - for .NET 4.6 targets, all functions are hinted to use AggressiveInlining
	 */
	public static class ValueUShortArrayExtensions {
		const int BIT_LEN = 16;
		const int BYTE_LEN = BIT_LEN / 8;
		
		/**
		 * Return the state of the bit (either 1 or 0) at provided
		 * position. position value must be between [0, data.Length * 16]
		 */
		#if NET_4_6
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		#endif
		public static int BitAt(this ushort[] data, int pos) {
			int bitIndex = pos / BIT_LEN;
			
			#if UNITY_EDITOR || DEBUG
				if (pos < 0) {
					BitDebug.Exception("ushort[].BitAt(int) - bit position must not be less than 0 was " + pos);
				}
				
				if (data == null) {
					BitDebug.Exception("ushort[].BitAt(int) - array is null");
				}
				
				if (bitIndex > data.Length) {
					BitDebug.Exception("ushort[].BitAt(int) - bit bucket must not be greater than array " + data.Length + " was " + bitIndex);
				}
			#endif
			
			// pipe into the single value type
			return data[bitIndex].BitAt(pos % BIT_LEN);
		}
		
		/**
		 * Return the inverted state of the bit (either 1 or 0) at provided
		 * position. position value must be between [0, data.Length * 16]
		 */
		#if NET_4_6
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		#endif
		public static int BitInvAt(this ushort[] data, int pos) {
			int bitIndex = pos / BIT_LEN;
			
			#if UNITY_EDITOR || DEBUG
				if (pos < 0) {
					BitDebug.Exception("ushort[].BitInvAt(int) - bit position must not be less than 0 was " + pos);
				}
				
				if (data == null) {
					BitDebug.Exception("ushort[].BitInvAt(int) - array is null");
				}
				
				if (bitIndex > data.Length) {
					BitDebug.Exception("ushort[].BitInvAt(int) - bit bucket must not be greater than array " + data.Length + " was " + bitIndex);
				}
			#endif
			
			// pipe into the single value type
			return data[bitIndex].BitInvAt(pos % BIT_LEN);
		}

		/**
		 * Sets the state of the bit into the ON/1 at provided
		 * position. position value must be between [0, data.Length * 16]
		 */
		#if NET_4_6
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		#endif
		public static void SetBitAt(this ushort[] data, int pos) {
			int bitIndex = pos / BIT_LEN;
			
			#if UNITY_EDITOR || DEBUG
				if (pos < 0) {
					BitDebug.Exception("ushort[].SetBitAt(int) - bit position must not be less than 0 was " + pos);
				}
				
				if (data == null) {
					BitDebug.Exception("ushort[].SetBitAt(int) - array is null");
				}
				
				if (bitIndex > data.Length) {
					BitDebug.Exception("ushort[].SetBitAt(int) - bit bucket must not be greater than array " + data.Length + " was " + bitIndex);
				}
			#endif
			
			// pipe into the single value type
			data[bitIndex] = data[bitIndex].SetBitAt(pos % BIT_LEN);
		}

		/**
		 * Sets the state of the bit into the OFF/0 at provided
		 * position. position value must be between [0, data.Length * 16]
		 */
		#if NET_4_6
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		#endif
		public static void UnsetBitAt(this ushort[] data, int pos) {
			int bitIndex = pos / BIT_LEN;
			
			#if UNITY_EDITOR || DEBUG
				if (pos < 0) {
					BitDebug.Exception("ushort[].UnsetBitAt(int) - bit position must not be less than 0 was " + pos);
				}
				
				if (data == null) {
					BitDebug.Exception("ushort[].UnsetBitAt(int) - array is null");
				}
				
				if (bitIndex > data.Length) {
					BitDebug.Exception("ushort[].UnsetBitAt(int) - bit bucket must not be greater than array " + data.Length + " was " + bitIndex);
				}
			#endif
			
			// pipe into the single value type
			data[bitIndex] = data[bitIndex].UnsetBitAt(pos % BIT_LEN);
		}

		/**
		 * Toggles the state of the bit into the ON/1 or OFF/0 at provided
		 * position. position value must be between [0, data.Length * 16].
		 */
		#if NET_4_6
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		#endif
		public static void ToggleBitAt(this ushort[] data, int pos) {
			int bitIndex = pos / BIT_LEN;
			
			#if UNITY_EDITOR || DEBUG
				if (pos < 0) {
					BitDebug.Exception("ushort[].ToggleBitAt(int) - bit position must not be less than 0 was " + pos);
				}
				
				if (data == null) {
					BitDebug.Exception("ushort[].ToggleBitAt(int) - array is null");
				}
				
				if (bitIndex > data.Length) {
					BitDebug.Exception("ushort[].ToggleBitAt(int) - bit bucket must not be greater than array " + data.Length + " was " + bitIndex);
				}
			#endif
			
			// pipe into the single value type
			data[bitIndex] = data[bitIndex].ToggleBitAt(pos % BIT_LEN);
		}
		
		/**
		 * Sets the state of the bit into the OFF/0 or ON/1 at provided
		 * position. position value must be between [0, data.Length * 16]
		 */
		#if NET_4_6
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		#endif
		public static void SetBit(this ushort[] data, int pos, int bit) {
			int bitIndex = pos / BIT_LEN;
			
			#if UNITY_EDITOR || DEBUG
				if (pos < 0) {
					BitDebug.Exception("ushort[].SetBit(int, int) - bit position must not be less than 0 was " + pos);
				}
				
				if (data == null) {
					BitDebug.Exception("ushort[].SetBit(int, int) - array is null");
				}
				
				if (bitIndex > data.Length) {
					BitDebug.Exception("ushort[].SetBit(int, int) - bit bucket must not be greater than array " + data.Length + " was " + bitIndex);
				}
			#endif
			
			// pipe into the single value type
			data[bitIndex] = data[bitIndex].SetBit(pos % BIT_LEN, bit);
		}

		/**
		 * Count the number of set bits in the provided ushort array (16 bits)
		 * A general purpose Hamming Weight or popcount function which returns the number of
		 * set bits in the argument.
		 */
		#if NET_4_6
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		#endif
		public static int PopCount(this ushort[] data) {
			#if UNITY_EDITOR || DEBUG
				if (data == null) {
					BitDebug.Exception("ushort[].PopCount() - array is null");
				}
			#endif
			
			int counter = 0;
			int length = data.Length;
			
			for (int i = 0; i < length; i++) {
				counter += data[i].PopCount();
			}
			
			return counter;
		}

		/**
		 * Returns the byte (8 bits) at provided position index
		 * Position value must be between [0, data.Length * 2]
		 */
		#if NET_4_6
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		#endif
		public static byte ByteAt(this ushort[] data, int pos) {
			int byteIndex = pos / BYTE_LEN;
			
			#if UNITY_EDITOR || DEBUG
				if (pos < 0) {
					BitDebug.Exception("ushort[].ByteAt(int) - byte position must not be less than 0 was " + pos);
				}
				
				if (data == null) {
					BitDebug.Exception("ushort[].ByteAt(int) - array is null");
				}
				
				if (byteIndex > data.Length) {
					BitDebug.Exception("ushort[].ByteAt(int) - byte bucket must not be greater than array " + data.Length + " was " + byteIndex);
				}
			#endif
			
			return data[byteIndex].ByteAt(pos % BYTE_LEN);
		}

		/**
		 * Sets and returns the byte (8 bits) at provided position index
		 * Position value must be between [0, data.Length * 2]
		 */
		#if NET_4_6
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		#endif
		public static void SetByteAt(this ushort[] data, byte newData, int pos) {
			int byteIndex = pos / BYTE_LEN;
			
			#if UNITY_EDITOR || DEBUG
				if (pos < 0) {
					BitDebug.Exception("ushort[].SetByteAt(byte, int) - byte position must not be less than 0 was " + pos);
				}
				
				if (data == null) {
					BitDebug.Exception("ushort[].SetByteAt(byte, int) - array is null");
				}
				
				if (byteIndex > data.Length) {
					BitDebug.Exception("ushort[].SetByteAt(byte, int) - byte bucket must not be greater than array " + data.Length + " was " + byteIndex);
				}
			#endif
			
			data[byteIndex] = data[byteIndex].SetByteAt(newData, pos % BYTE_LEN);
		}
	}
}
