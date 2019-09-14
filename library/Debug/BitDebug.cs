#region preprocessor defines
#if DEBUG
#define BITSTACK_DEBUG
#endif

#if BITSTACK_METHOD_INLINE
using System.Runtime.CompilerServices;
#endif
#endregion

#region imports
using System;
#endregion

namespace CoreGDX.BitStack.Debug {
#if BITSTACK_DEBUG
	public class BitDebug {
		private const string DebugErrorMessage = "NOTICE: debug messages are only enabled in debug mode, debug code is stripped in production builds";

#if BITSTACK_METHOD_INLINE
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
		public static void Exit(string data) {
			throw new Exception($"{data} \n {DebugErrorMessage}");
		}
	}
#endif
}