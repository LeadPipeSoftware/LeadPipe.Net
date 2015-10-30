using NHibernate.Transform;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;

namespace LeadPipe.Net.Data.NHibernate
{
    /// <summary>
    /// NHibernate result set transformers.
    /// </summary>
    public static class NHibernateResultTransformers
    {
        /// <summary>
        /// The expando object result set transformer.
        /// </summary>
        public static readonly IResultTransformer ExpandoObject;

        /// <summary>
        /// Initializes static members of the <see cref="NHibernateResultTransformers"/> class.
        /// </summary>
        static NHibernateResultTransformers()
        {
            ExpandoObject = new ExpandoObjectResultSetTransformer();
        }

        /// <summary>
        /// The ExpandoObject result set transformer.
        /// </summary>
        private class ExpandoObjectResultSetTransformer : IResultTransformer
        {
            /// <summary>
            /// Transforms the list.
            /// </summary>
            /// <param name="collection">The collection.</param>
            /// <returns>IList.</returns>
            public IList TransformList(IList collection)
            {
                return collection;
            }

            /// <summary>
            /// Transforms the tuple.
            /// </summary>
            /// <param name="tuple">The tuple.</param>
            /// <param name="aliases">The aliases.</param>
            /// <returns>System.Object.</returns>
            public object TransformTuple(object[] tuple, string[] aliases)
            {
                var expando = new ExpandoObject();

                var dictionary = (IDictionary<string, object>)expando;

                for (var i = 0; i < tuple.Length; i++)
                {
                    var alias = aliases[i];

                    if (alias != null)
                    {
                        dictionary[alias] = tuple[i];
                    }
                }

                return expando;
            }
        }
    }
}