
namespace BitStack {

	/**
     * Contains useful extension methods for the byte Value datatype.
     * byte is an unsigned 8 bit value.
     * 
     * For more info visit https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/byte
     */
	public static class ValueByteExtensions {
        
        /**
         * Return the state of the bit (either 1 or 0) at provided
         * position. position value must be between [0, 7]
         */
        public static int BitAt(this byte data, int pos) {
            return ((data >> pos) & 1);
        }

        /**
         * Sets the state of the bit into the ON/1 at provided
         * position. position value must be between [0, 7]
         */
		public static byte SetBitAt(this byte data, int pos) {
            return (byte)(data | 1u << pos);
        }

        /**
         * Sets the state of the bit into the OFF/0 at provided
         * position. position value must be between [0, 7]
         */
		public static byte UnsetBitAt(this byte data, int pos) {
			return (byte)(data & ~(1 << pos));
        }

        /**
         * Toggles the state of the bit into the ON/1 or OFF/0 at provided
         * position. position value must be between [0, 7].
         */
		public static byte ToggleBitAt(this byte data, int pos) {
			return (byte)(data ^ (1 << pos));
        }

        /**
         * Count the number of set bits in the provided sbyte value (8 bits)
         * A general purpose Hamming Weight or popcount function which returns the number of
         * set bits in the argument.
         */
		public static int PopCount(this byte data) {
            return ((uint)data).PopCount();
        }

        /**
         * Checks if the provided value is a power of 2.
         */
		public static bool IsPowerOfTwo(this byte value) {
            return value != 0 && (value & value - 1) == 0;
        }

        /**
         * Returns the String representation of the Bit Sequence from the provided
         * ushort. The String will contain 8 characters of 1 or 0 for each bit position
         */
		public static string BitString(this byte value) {
            System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder(8);

            for (int i = 0; i < 8; i++) {
                stringBuilder.Append(value.BitAt(i));
            }

            return stringBuilder.ToString();
        }

        /**
         * Returns the Hex Value as a String.
         */
		public static string HexString(this byte value) {
            return value.ToString("X");
        }
    }
}
