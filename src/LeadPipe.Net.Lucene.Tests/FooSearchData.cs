// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

namespace LeadPipe.Net.Lucene.Tests
{
    public class FooSearchData : IKeyed
    {
        public string Bar { get; set; }

        public string Key { get; set; }

        public string Parrot { get; set; }

        public string Score { get; set; }
    }
}