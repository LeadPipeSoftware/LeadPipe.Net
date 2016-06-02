// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

using NUnit.Framework;

namespace LeadPipe.Net.Domain.Tests.DomainEventingTests
{
    /// <summary>
    /// The DomainEvents Raise method tests.
    /// </summary>
    public class RaiseShould
    {
        /// <summary>
        /// Ensures that registered callback actions are stored in local data.
        /// </summary>
        [Test]
        public void RaiseRegisteredCallbackActions()
        {
            var testEntity = new TestEntity("FOO", "PEANUT");

            var newName = string.Empty;

            DomainEvents.Register<TestDomainEvent>(x => newName = x.NewName);

            testEntity.ChangeName("BAR");

            Assert.That(newName.Equals("BAR"));
        }
    }
}