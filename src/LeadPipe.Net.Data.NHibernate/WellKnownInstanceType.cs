using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using NHibernate.SqlTypes;
using NHibernate.UserTypes;

namespace LeadPipe.Net.Data.NHibernate
{
    [Serializable]
    public abstract class WellKnownInstanceType<T, TId> : IUserType where T : class
    {
        //private static readonly SqlType[] ReturnSqlTypes = { SqlTypeFactory.Int32 };
        private Func<T, TId, bool> findPredicate;
        private Func<T, TId> idGetter;
        private IEnumerable<T> repository;

        /// <summary>
        /// Base constructor
        /// </summary>
        /// <param name="repository">The collection that represent a in-memory repository.</param>
        /// <param name="findPredicate">The predicate an instance by the persisted value.</param>
        /// <param name="idGetter">The getter of the persisted value.</param>
        protected WellKnownInstanceType(IEnumerable<T> repository, Func<T, TId, bool> findPredicate, Func<T, TId> idGetter)
        {
            this.repository = repository;
            this.findPredicate = findPredicate;
            this.idGetter = idGetter;
        }

        public bool IsMutable
        {
            get { return false; }
        }

        //public SqlType[] SqlTypes
        //{
        //    get { return ReturnSqlTypes; }
        //}
        public Type ReturnedType
        {
            get { return typeof(T); }
        }

        /// <summary>
        /// The SQL types for the columns mapped by this type.
        /// </summary>
        public abstract SqlType[] SqlTypes { get; }

        public object Assemble(object cached, object owner)
        {
            return cached;
        }

        public object DeepCopy(object value)
        {
            return value;
        }

        public object Disassemble(object value)
        {
            return value;
        }

        public new bool Equals(object x, object y)
        {
            if (ReferenceEquals(x, y))
            {
                return true;
            }
            if (ReferenceEquals(null, x) || ReferenceEquals(null, y))
            {
                return false;
            }
            return x.Equals(y);
        }

        public int GetHashCode(object x)
        {
            return (x == null) ? 0 : x.GetHashCode();
        }

        public object NullSafeGet(IDataReader rs, string[] names, object owner)
        {
            int index0 = rs.GetOrdinal(names[0]);
            if (rs.IsDBNull(index0))
            {
                return null;
            }
            var value = (TId)rs.GetValue(index0);
            return repository.FirstOrDefault(x => findPredicate(x, value));
        }

        public void NullSafeSet(IDbCommand cmd, object value, int index)
        {
            if (value == null)
            {
                ((IDbDataParameter)cmd.Parameters[index]).Value = DBNull.Value;
            }
            else
            {
                ((IDbDataParameter)cmd.Parameters[index]).Value = idGetter((T)value);
            }
        }

        public object Replace(object original, object target, object owner)
        {
            return original;
        }
    }

    /// <summary>
    /// A <see cref="IUserType"/> to manage relationships with a well know entities.
    /// </summary>
    /// <typeparam name="T">The type of the wellknow entity</typeparam>
    /// <remarks>
    /// <typeparamref name="T"/> is the type to use in the entity owning the relation, the type in the persistence is <see cref="int"/>.
    /// </remarks>
    [Serializable]
    public abstract class WellKnownInstanceType<T> : WellKnownInstanceType<T, int> where T : class
    {
        private static readonly SqlType[] sqlTypes = new[] { SqlTypeFactory.Int32 };

        /// <summary>
        /// Base constructor
        /// </summary>
        /// <param name="repository">The collection that represent a in-memory repository.</param>
        /// <param name="findPredicate">The predicate an instance by the persisted value.</param>
        /// <param name="idGetter">The getter of the persisted value.</param>
        protected WellKnownInstanceType(IEnumerable<T> repository, Func<T, int, bool> findPredicate, Func<T, int> idGetter) : base(repository, findPredicate, idGetter)
        {
        }

        public override SqlType[] SqlTypes
        {
            get { return sqlTypes; }
        }
    }
}