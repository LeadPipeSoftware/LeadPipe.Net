// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

using LeadPipe.Net.Domain;
using System;

namespace LeadPipe.Net.Data.NHibernate.Tests
{
    /// <summary>
    /// The test model.
    /// </summary>
    public class TestChildModel : PersistableObject<Guid>, IEntity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TestChildModel"/> class.
        /// </summary>
        /// <param name="testProperty">
        /// The test property.
        /// </param>
        public TestChildModel(string testProperty)
        {
            this.TestProperty = testProperty;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TestChildModel"/> class.
        /// </summary>
        protected TestChildModel()
        {
        }

        /// <summary>
        /// Gets the entity key.
        /// </summary>
        public virtual string Key
        {
            get
            {
                return this.TestProperty;
            }
        }

        /// <summary>
        /// Gets or sets the test property.
        /// </summary>
        public virtual string TestProperty { get; protected set; }
    }
}