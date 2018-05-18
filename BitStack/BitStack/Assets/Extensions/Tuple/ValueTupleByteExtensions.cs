using UnityEngine;
using System.Collections;

namespace BitStack {

    /**
     * Represents Extension methods for the 8 value byte tuple type.
     */
	public static class ValueTupleByteExtensions {
        
        /**
         * Combine an 8 value byte tuple into a set of unsigned long (64 bits x 1)
         */
        public static ulong CombineToULong(this System.ValueTuple<byte, byte, byte, byte, byte, byte, byte, byte> tuple) {
            throw new System.Exception("unimplemented");
        }

		/**
         * Combine an 8 value byte tuple into a set of signed long (64 bits x 1)
         */
		public static long CombineToLong(this System.ValueTuple<byte, byte, byte, byte, byte, byte, byte, byte> tuple) {
            throw new System.Exception("unimplemented");
        }
        
		/**
         * Combine an 8 value byte tuple into a set of unsigned int (32 bits x 2)
         */
		public static System.ValueTuple<uint, uint> CombineToUInt(this System.ValueTuple<byte, byte, byte, byte, byte, byte, byte, byte> tuple) {
            throw new System.Exception("unimplemented");
        }
        
		/**
         * Combine an 8 value byte tuple into a set of signed int (32 bits x 2)
         */
		public static System.ValueTuple<int, int> CombineToInt(this System.ValueTuple<byte, byte, byte, byte, byte, byte, byte, byte> tuple) {
            throw new System.Exception("unimplemented");
        }
        
		/**
         * Combine an 8 value byte tuple into a set of unsigned short (16 bits x 4)
         */
		public static System.ValueTuple<ushort, ushort, ushort, ushort> CombineToUShort(this System.ValueTuple<byte, byte, byte, byte, byte, byte, byte, byte> tuple) {
            throw new System.Exception("unimplemented");
        }

		/**
         * Combine an 8 value byte tuple into a set of signed short (16 bits x 4)
         */
		public static System.ValueTuple<short, short, short, short> CombineToShort(this System.ValueTuple<byte, byte, byte, byte, byte, byte, byte, byte> tuple) {
			throw new System.Exception("unimplemented");
		}
        
        /**
         * Split a single unsigned long value (64 bit x 1) into an 8 value byte tuple
         */
		public static System.ValueTuple<byte, byte, byte, byte, byte, byte, byte, byte> SplitIntoByte(this ulong value) {
			throw new System.Exception("unimplemented");
		}

		/**
         * Split a single signed long value (64 bit x 1) into an 8 value byte tuple
         */
		public static System.ValueTuple<byte, byte, byte, byte, byte, byte, byte, byte> SplitIntoByte(this long value) {
            throw new System.Exception("unimplemented");
        }

		/**
         * Split a 2 value unsigned integer tuple (32 bit x 2) into an 8 value byte tuple
         */
		public static System.ValueTuple<byte, byte, byte, byte, byte, byte, byte, byte> SplitIntoByte(this System.ValueTuple<uint, uint> value) {
            throw new System.Exception("unimplemented");
        }

		/**
         * Split a 2 value signed integer tuple (32 bit x 2) into an 8 value byte tuple
         */
		public static System.ValueTuple<byte, byte, byte, byte, byte, byte, byte, byte> SplitIntoByte(this System.ValueTuple<int, int> value) {
            throw new System.Exception("unimplemented");
        }

		/**
         * Split a 4 value unsigned short tuple (16 bit x 4) into an 8 value byte tuple
         */
		public static System.ValueTuple<byte, byte, byte, byte, byte, byte, byte, byte> SplitIntoByte(this System.ValueTuple<ushort, ushort, ushort, ushort> value) {
            throw new System.Exception("unimplemented");
        }

		/**
         * Split a 4 value signed short tuple (16 bit x 4) into an 8 value byte tuple
         */
		public static System.ValueTuple<byte, byte, byte, byte, byte, byte, byte, byte> SplitIntoByte(this System.ValueTuple<short, short, short, short> value) {
            throw new System.Exception("unimplemented");
        }
    }
}
