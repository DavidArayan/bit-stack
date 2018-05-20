using UnityEngine;
using System.Collections;
using System;

namespace BitStack {

    /**
     * Represents Extension methods for the 8 value byte tuple type.
     */
	public static class ValueTupleByteExtensions {
        
		/**
         * Combine an 8 value byte tuple into a set of unsigned long (64 bits x 1)
         */
		public static ulong CombineToULong(this ValueTuple<ValueTuple<byte, byte, byte, byte>, ValueTuple<byte, byte, byte, byte>> tuple) {
			var upper = tuple.Item1;
			var lower = tuple.Item2;

			ulong u0 = upper.Item1;
			ulong u1 = upper.Item2;
			ulong u2 = upper.Item3;
			ulong u3 = upper.Item4;

			ulong l0 = lower.Item1;
			ulong l1 = lower.Item2;
			ulong l2 = lower.Item3;
			ulong l3 = lower.Item4;

			return u0 << 56 | u1 << 48 | u2 << 40 | u3 << 32 | l0 << 24 | l1 << 16 | l2 << 8 | l3;

        }
        
		/**
         * Combine an 8 value byte tuple into a set of signed long (64 bits x 1)
         */
		public static long CombineToLong(this ValueTuple<ValueTuple<byte, byte, byte, byte>, ValueTuple<byte, byte, byte, byte>> tuple) {
			return (long) tuple.CombineToULong();
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
		public static System.ValueTuple<ValueTuple<byte, byte, byte, byte>, ValueTuple<byte, byte, byte, byte>> SplitIntoByte(this ulong value) {
			byte i0 = (byte)(value >> 56);
			byte i1 = (byte)(value >> 48);
			byte i2 = (byte)(value >> 40);
			byte i3 = (byte)(value >> 32);

			byte i4 = (byte)(value >> 24);
			byte i5 = (byte)(value >> 16);
			byte i6 = (byte)(value >> 8);
			byte i7 = (byte)(value);

			var upper = new ValueTuple<byte, byte, byte, byte>(i0, i1, i2, i3);
			var lower = new ValueTuple<byte, byte, byte, byte>(i4, i5, i6, i7);

			return new ValueTuple<ValueTuple<byte, byte, byte, byte>, ValueTuple<byte, byte, byte, byte>>(upper, lower);
		}

		/**
         * Split a single signed long value (64 bit x 1) into an 8 value byte tuple
         */
		public static ValueTuple<ValueTuple<byte, byte, byte, byte>, ValueTuple<byte, byte, byte, byte>> SplitIntoByte(this long value) {
			return ((ulong)value).SplitIntoByte();
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
