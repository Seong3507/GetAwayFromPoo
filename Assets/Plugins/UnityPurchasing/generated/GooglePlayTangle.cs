#if UNITY_ANDROID || UNITY_IPHONE || UNITY_STANDALONE_OSX || UNITY_TVOS
// WARNING: Do not modify! Generated file.

namespace UnityEngine.Purchasing.Security {
    public class GooglePlayTangle
    {
        private static byte[] data = System.Convert.FromBase64String("wtaeh5a7otLnngfi2W7ERzogh9QSrM6JGiM5I9fZKyYGwt4va4yX4FyticM7gzs+sMqk9PH4g90hFZb4WCCL5QoYcg7j26SToRBvFEzOYrE4wLGdTwyx8CMds9QeHNMCtbdjao8MAg09jwwHD48MDA2A7/MNVbPHwGWjruzMQWwqGaqL/ABmcO2Rlr49jwwvPQALBCeLRYv6AAwMDAgNDkXriYosKnCyhb3WdUH8tAaTvjfo9KxZQ8dSDF1mD39D3JwgBwOYp7GCzZR6Su9mpgQSfIO3RD5nLW5MBi1M1VJ8VlWTckFqxFhOxv0v+X6ridZkJTsflVLKAmm0krMQwdESPLVAK2/wz8Ix0wX3f+LuqAsHXgbSjZ0AlqYWdRazsA8ODA0M");
        private static int[] order = new int[] { 3,9,7,11,5,9,7,11,11,13,11,13,12,13,14 };
        private static int key = 13;

        public static readonly bool IsPopulated = true;

        public static byte[] Data() {
        	if (IsPopulated == false)
        		return null;
            return Obfuscator.DeObfuscate(data, order, key);
        }
    }
}
#endif
