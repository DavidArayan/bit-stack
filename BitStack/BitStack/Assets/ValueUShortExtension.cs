
namespace BitStack {
    
	/**
     * Contains useful extension methods for the short Value datatype.
     * ushort is an unsigned 16 bit value.
     * 
     * For more info visit https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/ushort
     */
	public static class ValueUShortExtension {

        /**
         * Return the state of the bit (either 1 or 0) at provided
         * position. position value must be between [0, 15]
         */
        public static int BitAt(this ushort data, int pos) {
            return ((data >> pos) & 1);
        }

        /**
         * Sets the state of the bit into the ON/1 at provided
         * position. position value must be between [0, 15]
         */
        public static ushort SetBitAt(this ushort data, int pos) {
            return (ushort)(data | 1u << pos);
        }

        /**
         * Sets the state of the bit into the OFF/0 at provided
         * position. position value must be between [0, 15]
         */
        public static ushort UnsetBitAt(this ushort data, int pos) {
            return (ushort)(data & ~(1u << pos));
        }

        /**
         * Toggles the state of the bit into the ON/1 or OFF/0 at provided
         * position. position value must be between [0, 15].
         */
        public static ushort ToggleBitAt(this ushort data, int pos) {
            return (ushort)(data ^ (1u << pos));
        }

        /**
         * Count the number of set bits in the provided short value (16 bits)
         * A general purpose Hamming Weight or popcount function which returns the number of
         * set bits in the argument.
         */
        public static int PopCount(this ushort data) {
			return ((uint)data).PopCount();
        }

        /**
         * Checks if the provided value is a power of 2.
         */
        public static bool IsPowerOfTwo(this ushort value) {
            return value != 0 && (value & value - 1) == 0;
        }

        /**
         * Returns the String representation of the Bit Sequence from the provided
         * ushort. The String will contain 16 characters of 1 or 0 for each bit position
         */
        public static string BitString(this ushort value) {
            System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder(16);

            for (int i = 0; i < 16; i++) {
                stringBuilder.Append(value.BitAt(i));
            }

            return stringBuilder.ToString();
        }

        /**
         * Returns the Hex Value as a String.
         */
        public static string HexString(this ushort value) {
            return value.ToString("X");
        }
    }
}
