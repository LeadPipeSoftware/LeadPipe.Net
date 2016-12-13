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
    /// The DomainEvents Clear method tests.
    /// </summary>
    public class ClearShould
    {
        /// <summary>
        /// Ensures that registered callback actions are cleared.
        /// </summary>
        [Test]
        public void ClearAllCallbackActions()
        {
            DomainEvents.Register<TestDomainEvent>(x => x.NewName = "GOT IT");

            DomainEvents.Clear();

            var actions = Local.Data[DomainEvents.DomainEventActionsKey] as List<Delegate>;

            Assert.That(actions == null);
        }
    }
}