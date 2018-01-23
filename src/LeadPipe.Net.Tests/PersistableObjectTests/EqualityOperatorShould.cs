// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved. Licensed under the MIT License. Please see the LICENSE file in
// the project root for full license information. --------------------------------------------------------------------------------------------------------------------

// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved. Licensed under the MIT License. Please see the LICENSE file in
// the project root for full license information. --------------------------------------------------------------------------------------------------------------------

// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved. Licensed under the MIT License. Please see the LICENSE file in
// the project root for full license information. --------------------------------------------------------------------------------------------------------------------

using System;
using NUnit.Framework;

namespace LeadPipe.Net.Tests.PersistableObjectTests
{
    /// <summary>
    ///   PersistableObject == tests.
    /// </summary>
    [TestFixture]
    public class EqualityOperatorShould
    {
        [Test]
        public void ReturnFalseGivenIKeyedValuesDoNotMatch()
        {
            var obj1 = new IKeyedPersistableObjectWithNullableType("FOO");
            var obj2 = new IKeyedPersistableObjectWithNullableType("BAR");

            Assert.IsFalse(obj1 == obj2);
        }

        [Test]
        public void ReturnFalseGivenOneIKeyedValueIsNull()
        {
            var obj1 = new IKeyedPersistableObjectWithNullableType("FOO");
            var obj2 = new IKeyedPersistableObjectWithNullableType(null);

            Assert.IsFalse(obj1 == obj2);
        }

        [Test]
        public void ReturnFalseGivenOneSidValueIsNull()
        {
            var obj1 = new PersistableObjectWithNullableType("MYKEY") { Sid = Guid.NewGuid() };
            var obj2 = new PersistableObjectWithNullableType("MYKEY");

            Assert.IsFalse(obj1 == obj2);
        }

        [Test]
        public void ReturnFalseGivenSidValuesDoNotMatch()
        {
            var obj1 = new PersistableObjectWithNullableType("MYKEY") { Sid = Guid.NewGuid() };
            var obj2 = new PersistableObjectWithNullableType("MYKEY") { Sid = Guid.NewGuid() };

            Assert.IsFalse(obj1 == obj2);
        }

        [Test]
        public void ReturnTrueGivenIKeyedValuesMatch()
        {
            var obj1 = new IKeyedPersistableObjectWithNullableType("MYKEY");
            var obj2 = new IKeyedPersistableObjectWithNullableType("MYKEY");

            Assert.IsTrue(obj1 == obj2);
        }

        [Test]
        public void ReturnTrueGivenSidValuesMatch()
        {
            var sid = Guid.NewGuid();
            var obj1 = new PersistableObjectWithNullableType("MYKEY") { Sid = sid };
            var obj2 = new PersistableObjectWithNullableType("MYKEY") { Sid = sid };

            Assert.IsTrue(obj1 == obj2);
        }
    }
}