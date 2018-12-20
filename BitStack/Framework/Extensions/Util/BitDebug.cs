#if UNITY_EDITOR
#define BITSTACK_DEBUG
#endif

using System;

#if NET_4_6
using System.Runtime.CompilerServices;
#endif

namespace BitStack {
	#if BITSTACK_DEBUG
	
	public class BitDebug {
		public const string DEBUG_ERR = "NOTICE: debug messages are only enabled in editor and debug mode, debug code is stripped in production builds.";

		#if NET_4_6
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		#endif
		public static void Exception(string data) {
			throw new Exception(data + "\n" + DEBUG_ERR);
		}
	}
	
	#endif
}
