
/**
 * Represents .NET 3.5 and 4.x compat layer. Tuples are not available
 * in older .NET versions. This acts as a simple polyfill to ensure all
 * scripts work in all versions of Unity.
 */
namespace BitStack {
    #if !NET_4_6

    /**
     * Represents a 1 component Tuple
     */
	public struct ValueTuple<I1> {
		private readonly I1 i1;

		public ValueTuple(I1 item1) {
			this.i1 = item1;
		}

		public I1 Item1 { get { return this.i1; } }
    }

	/**
     * Represents a 2 component Tuple
     */
    public struct ValueTuple<I1, I2> {
		private readonly I1 i1;
		private readonly I2 i2;

        public ValueTuple(I1 item1, 
		                  I2 item2) 
		{
            this.i1 = item1;
			this.i2 = item2;
        }

		public I1 Item1 { get { return this.i1; } }
		public I2 Item2 { get { return this.i2; } }
    }

	/**
     * Represents a 3 component Tuple
     */
    public struct ValueTuple<I1, I2, I3> {
		private readonly I1 i1;
		private readonly I2 i2;
		private readonly I3 i3;

        public ValueTuple(I1 item1,
                          I2 item2,
		                  I3 item3) 
		{
            this.i1 = item1;
            this.i2 = item2;
			this.i3 = item3;
        }

        public I1 Item1 { get { return this.i1; } }
        public I2 Item2 { get { return this.i2; } }
		public I3 Item3 { get { return this.i3; } }
    }

	/**
     * Represents a 4 component Tuple
     */
    public struct ValueTuple<I1, I2, I3, I4> {
		private readonly I1 i1;
		private readonly I2 i2;
		private readonly I3 i3;
		private readonly I4 i4;

        public ValueTuple(I1 item1,
                          I2 item2,
                          I3 item3,
		                  I4 item4) 
		{
            this.i1 = item1;
            this.i2 = item2;
            this.i3 = item3;
			this.i4 = item4;
        }

        public I1 Item1 { get { return this.i1; } }
        public I2 Item2 { get { return this.i2; } }
		public I3 Item3 { get { return this.i3; } }
		public I4 Item4 { get { return this.i4; } }
    }
    
	#endif
}
