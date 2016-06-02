// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

using LeadPipe.Net.Specifications;

namespace LeadPipe.Net.Data.NHibernate.Tests
{
    /// <summary>
    /// The test model specifications.
    /// </summary>
    public static class TestModelSpecifications
    {
        /// <summary>
        /// The test property does NOT start with abc or ends with xyz.
        /// </summary>
        /// <returns></returns>
        public static ISpecification<TestModel> NotTestPropertyStartsWithABCOrEndsWithXYZ()
        {
            return new NotSpecification<TestModel>(TestPropertyStartsWithABC());
        }

        /// <summary>
        /// The test property ends with xyz.
        /// </summary>
        /// <returns>
        /// Test Models that end with XYZ.
        /// </returns>
        public static ISpecification<TestModel> TestPropertyEndsWithXYZ()
        {
            return new AdHocSpecification<TestModel>(x => x.TestProperty.EndsWith("XYZ"));
        }

        /// <summary>
        /// The test property starts with abc.
        /// </summary>
        /// <returns>
        /// Test Models that start with ABC.
        /// </returns>
        public static ISpecification<TestModel> TestPropertyStartsWithABC()
        {
            return new AdHocSpecification<TestModel>(x => x.TestProperty.StartsWith("ABC"));
        }

        /// <summary>
        /// The test property starts with abc and ends with xyz.
        /// </summary>
        /// <returns>
        /// Test Models that start with ABC and end with XYZ.
        /// </returns>
        public static ISpecification<TestModel> TestPropertyStartsWithABCAndEndsWithXYZ()
        {
            return new AndSpecification<TestModel>(TestPropertyStartsWithABC(), TestPropertyEndsWithXYZ());
        }

        /// <summary>
        /// The test property starts with abc or ends with xyz.
        /// </summary>
        /// <returns>
        /// Test Models that start with ABC or end with XYZ.
        /// </returns>
        public static ISpecification<TestModel> TestPropertyStartsWithABCOrEndsWithXYZ()
        {
            return new OrSpecification<TestModel>(TestPropertyStartsWithABC(), TestPropertyEndsWithXYZ());
        }
    }
}