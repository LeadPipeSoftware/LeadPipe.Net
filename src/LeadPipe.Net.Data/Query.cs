// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Query.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using LeadPipe.Net.Domain;

namespace LeadPipe.Net.Data
{
    public abstract class Query<TResult> : IQuery<TResult>
    {
        protected readonly IDataCommandProvider dataCommandProvider;

        protected Query(IDataCommandProvider dataCommandProvider)
        {
            this.dataCommandProvider = dataCommandProvider;
        }

        public abstract TResult GetResult();
    }
}