using NHibernate;
using System.Collections.Generic;

namespace LeadPipe.Net.Data.NHibernate
{
    /// <summary>
    /// NHibernate extension methods.
    /// </summary>
    public static class NHibernateExtensions
    {
        /// <summary>
        /// Returns query results as a dynamic list.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <returns>IList&lt;dynamic&gt;.</returns>
        public static IList<dynamic> AsDynamicList(this IQuery query)
        {
            return query.SetResultTransformer(NHibernateResultTransformers.ExpandoObject)
                        .List<dynamic>();
        }
    }
}