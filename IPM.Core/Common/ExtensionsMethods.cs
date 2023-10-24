namespace IPM.Core.Common
{
    public static class ExtensionMethods
    {
        public static T[] ToArray<T>(this ICollection<T> collection, int index = 0)
        {
            lock (collection)
            {
                var arr = new T[collection.Count - index];
                collection.CopyTo(arr, index);
                return arr;
            }
        }
    }
}
