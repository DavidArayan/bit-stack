#if UNITY_EDITOR
#define BITSTACK_DEBUG
#endif

#if NET_4_6
using System.Runtime.CompilerServices;
#endif

namespace BitStack {
	
	/**
	 * An Extension of the ValueSByteExtension which allows working with bits
	 * on an array of values. All functionality is piped directly to the
	 * ValueSByteExtension whenever possible. 
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
	public static class ValueSByteArrayExtensions {
		const int BIT_LEN = 8;
		
		/**
		 * Return the state of the bit (either 1 or 0) at provided
		 * position. position value must be between [0, data.Length * 8]
		 */
		#if NET_4_6
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		#endif
		public static int BitAt(this sbyte[] data, int pos) {
			int bitIndex = pos / BIT_LEN;
			
			#if BITSTACK_DEBUG
				if (pos < 0) {
					BitDebug.Exception("sbyte[].BitAt(int) - bit position must not be less than 0 was " + pos);
				}
				
				if (data == null) {
					BitDebug.Exception("sbyte[].BitAt(int) - array is null");
				}
				
				if (bitIndex > data.Length) {
					BitDebug.Exception("sbyte[].BitAt(int) - bit bucket must not be greater than array " + data.Length + " was " + bitIndex);
				}
			#endif
			
			// pipe into the single value type
			return data[bitIndex].BitAt(pos % BIT_LEN);
		}
		
		/**
		 * Return the inverted state of the bit (either 1 or 0) at provided
		 * position. position value must be between [0, data.Length * 8]
		 */
		#if NET_4_6
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		#endif
		public static int BitInvAt(this sbyte[] data, int pos) {
			int bitIndex = pos / BIT_LEN;
			
			#if BITSTACK_DEBUG
				if (pos < 0) {
					BitDebug.Exception("sbyte[].BitInvAt(int) - bit position must not be less than 0 was " + pos);
				}
				
				if (data == null) {
					BitDebug.Exception("sbyte[].BitInvAt(int) - array is null");
				}
				
				if (bitIndex > data.Length) {
					BitDebug.Exception("sbyte[].BitInvAt(int) - bit bucket must not be greater than array " + data.Length + " was " + bitIndex);
				}
			#endif
			
			// pipe into the single value type
			return data[bitIndex].BitInvAt(pos % BIT_LEN);
		}

		/**
		 * Sets the state of the bit into the ON/1 at provided
		 * position. position value must be between [0, data.Length * 8]
		 */
		#if NET_4_6
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		#endif
		public static void SetBitAt(this sbyte[] data, int pos) {
			int bitIndex = pos / BIT_LEN;
			
			#if BITSTACK_DEBUG
				if (pos < 0) {
					BitDebug.Exception("sbyte[].SetBitAt(int) - bit position must not be less than 0 was " + pos);
				}
				
				if (data == null) {
					BitDebug.Exception("sbyte[].SetBitAt(int) - array is null");
				}
				
				if (bitIndex > data.Length) {
					BitDebug.Exception("sbyte[].SetBitAt(int) - bit bucket must not be greater than array " + data.Length + " was " + bitIndex);
				}
			#endif
			
			// pipe into the single value type
			data[bitIndex] = data[bitIndex].SetBitAt(pos % BIT_LEN);
		}

		/**
		 * Sets the state of the bit into the OFF/0 at provided
		 * position. position value must be between [0, data.Length * 8]
		 */
		#if NET_4_6
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		#endif
		public static void UnsetBitAt(this sbyte[] data, int pos) {
			int bitIndex = pos / BIT_LEN;
			
			#if BITSTACK_DEBUG
				if (pos < 0) {
					BitDebug.Exception("sbyte[].UnsetBitAt(int) - bit position must not be less than 0 was " + pos);
				}
				
				if (data == null) {
					BitDebug.Exception("sbyte[].UnsetBitAt(int) - array is null");
				}
				
				if (bitIndex > data.Length) {
					BitDebug.Exception("sbyte[].UnsetBitAt(int) - bit bucket must not be greater than array " + data.Length + " was " + bitIndex);
				}
			#endif
			
			// pipe into the single value type
			data[bitIndex] = data[bitIndex].UnsetBitAt(pos % BIT_LEN);
		}

		/**
		 * Toggles the state of the bit into the ON/1 or OFF/0 at provided
		 * position. position value must be between [0, data.Length * 8].
		 */
		#if NET_4_6
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		#endif
		public static void ToggleBitAt(this sbyte[] data, int pos) {
			int bitIndex = pos / BIT_LEN;
			
			#if BITSTACK_DEBUG
				if (pos < 0) {
					BitDebug.Exception("sbyte[].ToggleBitAt(int) - bit position must not be less than 0 was " + pos);
				}
				
				if (data == null) {
					BitDebug.Exception("sbyte[].ToggleBitAt(int) - array is null");
				}
				
				if (bitIndex > data.Length) {
					BitDebug.Exception("sbyte[].ToggleBitAt(int) - bit bucket must not be greater than array " + data.Length + " was " + bitIndex);
				}
			#endif
			
			// pipe into the single value type
			data[bitIndex] = data[bitIndex].ToggleBitAt(pos % BIT_LEN);
		}
		
		/**
		 * Sets the state of the bit into the OFF/0 or ON/1 at provided
		 * position. position value must be between [0, data.Length * 8]
		 */
		#if NET_4_6
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		#endif
		public static void SetBit(this sbyte[] data, int pos, int bit) {
			int bitIndex = pos / BIT_LEN;
			
			#if BITSTACK_DEBUG
				if (pos < 0) {
					BitDebug.Exception("sbyte[].SetBit(int, int) - bit position must not be less than 0 was " + pos);
				}
				
				if (data == null) {
					BitDebug.Exception("sbyte[].SetBit(int, int) - array is null");
				}
				
				if (bitIndex > data.Length) {
					BitDebug.Exception("sbyte[].SetBit(int, int) - bit bucket must not be greater than array " + data.Length + " was " + bitIndex);
				}
			#endif
			
			// pipe into the single value type
			data[bitIndex] = data[bitIndex].SetBit(pos % BIT_LEN, bit);
		}

		/**
		 * Count the number of set bits in the provided sbyte array (8 bits)
		 * A general purpose Hamming Weight or popcount function which returns the number of
		 * set bits in the argument.
		 */
		#if NET_4_6
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		#endif
		public static int PopCount(this sbyte[] data) {
			#if BITSTACK_DEBUG
				if (data == null) {
					BitDebug.Exception("sbyte[].PopCount() - array is null");
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
		 * Position value must be between [0, data.Length]
		 */
		#if NET_4_6
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		#endif
		public static byte ByteAt(this sbyte[] data, int pos) {
			#if BITSTACK_DEBUG
				if (pos < 0) {
					BitDebug.Exception("sbyte[].ByteAt(int) - byte position must not be less than 0 was " + pos);
				}
				
				if (data == null) {
					BitDebug.Exception("sbyte[].ByteAt(int) - array is null");
				}
				
				if (pos > data.Length) {
					BitDebug.Exception("sbyte[].ByteAt(int) - byte bucket must not be greater than array " + data.Length + " was " + pos);
				}
			#endif
			
			return (byte)data[pos];
		}

		/**
		 * Sets and returns the byte (8 bits) at provided position index
		 * Position value must be between [0, data.Length]
		 */
		#if NET_4_6
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		#endif
		public static void SetByteAt(this sbyte[] data, byte newData, int pos) {
			#if BITSTACK_DEBUG
				if (pos < 0) {
					BitDebug.Exception("sbyte[].SetByteAt(byte, int) - byte position must not be less than 0 was " + pos);
				}
				
				if (data == null) {
					BitDebug.Exception("sbyte[].SetByteAt(byte, int) - array is null");
				}
				
				if (pos > data.Length) {
					BitDebug.Exception("sbyte[].SetByteAt(byte, int) - byte bucket must not be greater than array " + data.Length + " was " + pos);
				}
			#endif
			
			data[pos] = (sbyte)newData;
		}
	}
}

