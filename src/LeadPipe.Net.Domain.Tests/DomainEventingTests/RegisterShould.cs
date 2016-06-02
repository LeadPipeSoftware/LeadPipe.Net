// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace LeadPipe.Net.Domain.Tests.DomainEventingTests
{
    /// <summary>
    /// The DomainEvents Register method tests.
    /// </summary>
    public class RegisterShould
    {
        /// <summary>
        /// Ensures that registered callback actions are stored in local data.
        /// </summary>
        [Test]
        public void StoreTheCallbackActionInLocalData()
        {
            DomainEvents.Clear();

            DomainEvents.Register<TestDomainEvent>(x => x.NewName = "GOT IT");

            var actions = Local.Data[DomainEvents.DomainEventActionsKey] as List<Delegate>;

            Assert.That(actions != null);

            Assert.That(actions.Count.Equals(1));
        }
    }
}