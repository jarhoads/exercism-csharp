using System;

public static class TelemetryBuffer
{
    public const int ShortSize = sizeof(short);
    public const int IntSize = sizeof(int);
    public const int LongSize = sizeof(long);
    public const int MaxNumSize = sizeof(decimal);
    public const int MaxByteSize = 256;

    public static byte[] ToBuffer(long reading)
    {
        var buffered = BitConverter.GetBytes(reading);
        int size = BytesSize(reading);

        var bytes = BuildBytes(buffered, size);

        return bytes;
    }

    public static byte[] BuildBytes(byte[] buffered, int size)
    {
        // create a new array to hold the converted bytes
        byte[] bytes = new byte[buffered.Length + 1];
        bytes[0] = (byte)size;

        // copy over the converted bytes
        Array.Copy(buffered, 0, bytes, 1, buffered.Length);

        // clear out unused bytes
        var clear = (size > MaxNumSize) ? (MaxByteSize - size) : size;
        Array.Clear(bytes, (clear + 1), bytes.Length - (clear + 1));

        return bytes;
    }

    public static int BytesSize(long num)
    {
        if (num >= 4294967296 && num <= 9223372036854775807)
        {
            return MaxByteSize - LongSize;
        }
        else if (num >= 2_147_483_648 && num <= 4_294_967_295)
        {
            return IntSize;
        }
        else if (num >= 65_536 && num <= 2_147_483_647)
        {
            return MaxByteSize - IntSize;
        }
        else if (num >= 0 && num <= 65_536)
        {
            return ShortSize;
        }
        else if (num >= -32_768 && num <= -1)
        {
            return MaxByteSize - ShortSize;
        }
        else if (num >= -2_147_483_648 && num <= -32_769)
        {
            return MaxByteSize - IntSize;
        }
        else if (num >= -9_223_372_036_854_775_808 && num <= -2_147_483_649)
        {
            return MaxByteSize - LongSize;
        }
        else
        {
            return 0;
        }
    }

    public static long FromBuffer(byte[] buffer)
    {
        return ConvertBytes(buffer[0], buffer);
    }

    public static long ConvertBytes(byte size, byte[] bytes)
    {
        bool unsigned = ((int)size < MaxNumSize);
        int valSize = unsigned ? (int)size : MaxByteSize - (int)size;

        if (valSize == ShortSize)
        {
            return (unsigned) ? BitConverter.ToUInt16(bytes, 1) : BitConverter.ToInt16(bytes, 1);
        }
        else if (valSize == IntSize)
        {
            return (unsigned) ? BitConverter.ToUInt32(bytes, 1) : BitConverter.ToInt32(bytes, 1);
        }
        else if (valSize == LongSize)
        {
            return (unsigned) ? (long)BitConverter.ToUInt64(bytes, 1) : BitConverter.ToInt64(bytes, 1);
        }
        else
        {
            return 0;
        }
    }

}
