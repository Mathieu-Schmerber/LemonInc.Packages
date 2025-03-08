using Unity.Mathematics;
using UnityEngine;

namespace LemonInc.Core.Utilities.Extensions
{
    /// <summary>
    /// Extends Unity native types.
    /// </summary>
    public static class NativeExtensions
    {
        public static Vector2 ToVector2(this int2 value) => new(value.x, value.y);
        public static Vector3 ToVector3(this int3 value) => new(value.x, value.y, value.z);
        public static Vector2 ToVector2(this float2 value) => new(value.x, value.y);
        public static Vector3 ToVector3(this float3 value) => new(value.x, value.y, value.z);
        public static Vector2Int ToVector2Int(this int2 value) => new(value.x, value.y);
        public static Vector3Int ToVector3Int(this int3 value) => new(value.x, value.y, value.z);

        public static Vector3 ToVector3Xz(this int3 value) => new(value.x, 0, value.z);
        public static Vector3 ToVector3Xy(this int3 value) => new(value.x, value.y, 0);
        public static Vector2 ToVector2Xy(this int3 value) => new(value.x, value.y);
        public static Vector2 ToVector2Xz(this int3 value) => new(value.x, value.z);
        public static Vector2 ToVector2Yz(this int3 value) => new(value.y, value.z);

        public static Vector3Int ToVector3IntXz(this int3 value) => new(value.x, 0, value.z);
        public static Vector3Int ToVector3IntXy(this int3 value) => new(value.x, value.y, 0);
        public static Vector2Int ToVector2IntXy(this int3 value) => new(value.x, value.y);
        public static Vector2Int ToVector2IntXz(this int3 value) => new(value.x, value.z);
        public static Vector2Int ToVector2IntYz(this int3 value) => new(value.y, value.z);

        public static Vector3 ToVector3Xz(this float3 value) => new(value.x, 0, value.z);
        public static Vector3 ToVector3Xy(this float3 value) => new(value.x, value.y, 0);
        public static Vector2 ToVector2Xy(this float3 value) => new(value.x, value.y);
        public static Vector2 ToVector2Xz(this float3 value) => new(value.x, value.z);
        public static Vector2 ToVector2Yz(this float3 value) => new(value.y, value.z);
    }
}