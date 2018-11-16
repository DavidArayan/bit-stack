using System;
namespace BitStack {
	#if UNITY_EDITOR || DEBUG
	
	public class BitDebug {
		public const string DEBUG_ERR = "NOTICE: debug messages are only enabled in editor and debug mode, debug code is stripped in production builds.";
		
		public static void Exception(string data) {
			throw new Exception(data + "\n" + DEBUG_ERR);
		}
	}
	
	#endif
}
