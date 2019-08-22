namespace CoreGDX.BitStack.Indexing {
    /**
     * Simple SpatialKey interface that all indexing structures
     * implement. This is used internally to ensure the structures
     * conform to a single interface.
     */
    public interface ISpatialKey<T> where T : struct {
        T Key { get; }
        uint X { get; }
        uint Y { get; }
        uint Z { get; }
    }
}