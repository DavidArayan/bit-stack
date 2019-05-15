#if UNITY_EDITOR
#define BITSTACK_DEBUG
#endif

#if NET_4_6 && !BITSTACK_DISABLE_INLINE
#define BITSTACK_METHOD_INLINE
#endif

using System;
using UnityEngine;

namespace BitStack {
    /**
     * Basic interface that all IKeyIndex types such as MortonKeys, LinearKeys etc
     * must implement
     */
    public interface IKeyIndex<T> {
        uint key {
            get;
        }

        uint x {
            get;
        }

        uint y {
            get;
        }

        uint z {
            get;
        }

        Vector3 Value {
            get;
        }

        ValueTuple<uint, uint, uint> RawValue {
            get;
        }

        T IncX();

        T IncY();

        T IncZ();

        T IncXY();

        T IncXZ();

        T IncYZ();

        T IncXYZ();

        T DecX();

        T DecY();

        T DecZ();

        T DecXY();

        T DecXZ();

        T DecYZ();

        T DecXYZ();

        uint Mod(uint modulo);

        uint Mask(uint mask);
    }
}