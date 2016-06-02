// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace LeadPipe.Net.Data.NHibernate.Tests
{
    /// <summary>
    /// A query that returns all the test models that have a test property that starts with ABC.
    /// </summary>
    public class TestModelsWithTestPropertiesThatStartWithABC : Query<TestModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TestModelsWithTestPropertiesThatStartWithABC"/> class.
        /// </summary>
        /// <param name="dataCommandProvider">The data command provider.</param>
        public TestModelsWithTestPropertiesThatStartWithABC(IDataCommandProvider dataCommandProvider)
            : base(dataCommandProvider)
        {
        }

        /// <summary>
        /// Gets the result.
        /// </summary>
        /// <returns></returns>
        public override IEnumerable<TestModel> GetResult()
        {
            return base.dataCommandProvider.Query<TestModel>().Where(x => x.TestProperty.StartsWith("ABC"));
        }
    }
}