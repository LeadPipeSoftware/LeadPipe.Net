// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

using LeadPipe.Net.Domain;
using System;
using System.Collections.Generic;

namespace LeadPipe.Net.Data.NHibernate.Tests
{
    /// <summary>
    /// The test model.
    /// </summary>
    public class TestModel : PersistableObject<Guid>, IEntity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TestModel"/> class.
        /// </summary>
        /// <param name="testProperty">
        /// The test property.
        /// </param>
        public TestModel(string testProperty)
        {
            this.TestProperty = testProperty;
            this.TestChildren = new List<TestChildModel>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TestModel"/> class.
        /// </summary>
        protected TestModel()
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
        /// Gets or sets the mutable test property.
        /// </summary>
        public virtual string MutableTestProperty { get; set; }

        /// <summary>
        /// Gets or sets the test child.
        /// </summary>
        public virtual TestChildModel TestChild { get; set; }

        /// <summary>
        /// Gets or sets the test children.
        /// </summary>
        public virtual IList<TestChildModel> TestChildren { get; set; }

        /// <summary>
        /// Gets or sets the test property.
        /// </summary>
        public virtual string TestProperty { get; protected set; }
    }
}