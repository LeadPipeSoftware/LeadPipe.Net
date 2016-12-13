// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

using NHibernate;

namespace LeadPipe.Net.Data.NHibernate
{
    /// <summary>
    /// The active data session manager.
    /// </summary>
    public class ActiveDataSessionManager : IActiveDataSessionManager<ISession>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ActiveDataSessionManager" /> class.
        /// </summary>
        public ActiveDataSessionManager()
        {
            this.SessionKey = "LeadPipe.Net.Data.NHibernate.SessionKey";
        }

        /// <summary>
        /// Gets or sets the current data session.
        /// </summary>
        public virtual ISession Current
        {
            get
            {
                return (ISession)Local.Data[this.SessionKey];
            }

            protected set
            {
                Local.Data[this.SessionKey] = value;
            }
        }

        /// <summary>
        /// Gets a value indicating whether this instance has active data session.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance has active data session; otherwise, <c>false</c>.
        /// </value>
        public bool HasActiveDataSession
        {
            get
            {
                return this.Current != null;
            }
        }

        /// <summary>
        /// Gets or sets the session key.
        /// </summary>
        public string SessionKey { get; set; }

        /// <summary>
        /// The clear active data session.
        /// </summary>
        public void ClearActiveDataSession()
        {
            if (this.Current != null)
            {
                this.Current.Dispose();
            }

            this.Current = null;
        }

        /// <summary>
        /// The set active data session.
        /// </summary>
        /// <param name="dataSession">The data session.</param>
        public void SetActiveDataSession(ISession dataSession)
        {
            if (this.Current != null)
            {
                this.Current.Dispose();
            }

            this.Current = dataSession;
        }
    }
}