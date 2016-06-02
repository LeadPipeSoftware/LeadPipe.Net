// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

namespace LeadPipe.Net.Lucene.Tests
{
    /// <summary>
    /// The search fields.
    /// </summary>
    public class FooSearchFields
    {
        public static readonly string Bar;
        public static readonly string Key;

        public static readonly string Parrot;

        static FooSearchFields()
        {
            Key = "Key".ToLowerInvariant();
            Parrot = "Parrot".ToLowerInvariant();
            Bar = "Bar".ToLowerInvariant();
        }
    }
}