using System.Security.Cryptography;
using System.Collections.Generic;
using System;

namespace JadesToolkit.StateOfLife.Utility
{
    public static class Identifier
    {
        private static readonly HashSet<long> usedIdentifiers = new HashSet<long>();
        private static readonly RandomNumberGenerator rand;

        static Identifier()
        {
            rand = RandomNumberGenerator.Create();
        }
        public static bool VerifyUniqueIdentifier(long id) => usedIdentifiers.Contains(id);
        public static long GetUniqueIdentifier()
        {
            long generatedID;
            do
            {
                byte[] bytes = new byte[8];
                rand.GetBytes(bytes);
                long scale = BitConverter.ToInt64(bytes, 0);
                generatedID = (long)Math.Round(0 + (9 - 0) * (scale / (ulong.MaxValue + 1.0)), 0, MidpointRounding.AwayFromZero);
            }
            while (!usedIdentifiers.Add(generatedID));
            return generatedID;
        }
    }
}