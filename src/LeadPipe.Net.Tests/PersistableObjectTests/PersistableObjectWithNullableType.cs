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

namespace LeadPipe.Net.Tests.PersistableObjectTests
{
    public class PersistableObjectWithNullableType : PersistableObject<Guid>
    {
        public PersistableObjectWithNullableType(string testProperty)
        {
            this.TestProperty = testProperty;
        }

        /// <summary>
        ///   Gets or sets the test property.
        /// </summary>
        public virtual string TestProperty { get; protected set; }
    }
}