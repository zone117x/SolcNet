﻿using System;
using System.Text;

namespace SolCodeGen.AbiEncoding.Encoders
{
    public class StringEncoder : AbiTypeEncoder<string>
    {
        // utf-8 encoded and this value is interpreted as of bytes type and encoded further.
        // Note that the length used in this subsequent encoding is the number of bytes of 
        // the utf-8 encoded string, not its number of characters.

        public override int GetEncodedSize()
        {
            var len = Encoding.UTF8.GetByteCount(_val);
            int padded = PadLength(len, 32);
            return 32 + padded;
        }

        public override Span<byte> Encode(Span<byte> buffer)
        {
            Span<byte> utf8 = Encoding.UTF8.GetBytes(_val);
            int len = utf8.Length;
            buffer = UInt256Encoder.EncodeUnchecked(buffer, len);
            utf8.CopyTo(buffer);
            int padded = PadLength(len, 32);
            return buffer.Slice(padded);
        }
    }

}