// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FooSearchData.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace LeadPipe.Net.Lucene.Tests
{
    public class FooSearchData : IKeyed
    {
        public string Key { get; set; }

        public string Parrot { get; set; }

        public string Bar { get; set; }

        public string Score { get; set; }
    }
}
