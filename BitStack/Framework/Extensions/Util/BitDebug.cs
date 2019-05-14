#if UNITY_EDITOR
#define BITSTACK_DEBUG
#endif

#if NET_4_6 && !BITSTACK_DISABLE_INLINE
#define BITSTACK_METHOD_INLINE
#endif

using System;

#if BITSTACK_METHOD_INLINE
using System.Runtime.CompilerServices;
#endif

#if BITSTACK_DEBUG
namespace BitStack {
    public static class BitDebug {
        private const string DEBUG_ERR = "NOTICE: debug messages are only enabled in editor and debug mode, debug code is stripped in production builds.";

#if BITSTACK_METHOD_INLINE
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
        public static void Exception(string data) {
            throw new Exception(data + "\n" + DEBUG_ERR);
        }
    }
}
#endif