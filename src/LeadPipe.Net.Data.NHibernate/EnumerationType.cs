// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

using NHibernate.Dialect;
using NHibernate.SqlTypes;
using NHibernate.Type;
using System;
using System.Data;

namespace LeadPipe.Net.Data.NHibernate
{
    /// <summary>
    /// The Enumeration Type for use with NHibernate mapping.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [Serializable]
    public class EnumerationType<T> : PrimitiveType where T : Enumeration<T>
    {
        /// <summary>
        /// Initializes a new instance of EnumerationType.
        /// </summary>
        public EnumerationType()
            : base(new SqlType(DbType.Int32))
        {
        }

        /// <summary>
        /// The default value of the type.
        /// </summary>
        public override object DefaultValue
        {
            get { return 0; }
        }

        /// <summary>
        /// The type name.
        /// </summary>
        public override string Name
        {
            get { return "enumeration"; }
        }

        /// <summary>
        /// The type's primitive type.
        /// </summary>
        public override Type PrimitiveClass
        {
            get { return typeof(int); }
        }

        /// <summary>
        /// The returned type.
        /// </summary>
        public override Type ReturnedClass
        {
            get { return typeof(T); }
        }

        /// <summary>
        /// The FromString value.
        /// </summary>
        /// <param name="xml"></param>
        /// <returns></returns>
        public override object FromStringValue(string xml)
        {
            return int.Parse(xml);
        }

        /// <summary>
        /// Gets.
        /// </summary>
        /// <param name="rs"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public override object Get(IDataReader rs, int index)
        {
            var o = rs[index];
            var value = Convert.ToInt32(o);
            return Enumeration<T>.FromInt32(value);
        }

        /// <summary>
        /// Gets
        /// </summary>
        /// <param name="rs"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public override object Get(IDataReader rs, string name)
        {
            var ordinal = rs.GetOrdinal(name);
            return Get(rs, ordinal);
        }

        /// <summary>
        /// Converts the objec to a SQL string.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="dialect"></param>
        /// <returns></returns>
        public override string ObjectToSQLString(object value, Dialect dialect)
        {
            return value.ToString();
        }

        /// <summary>
        /// Sets.
        /// </summary>
        /// <param name="cmd"></param>
        /// <param name="value"></param>
        /// <param name="index"></param>
        public override void Set(IDbCommand cmd, object value, int index)
        {
            var parameter = (IDataParameter)cmd.Parameters[index];

            var val = (Enumeration<T>)value;

            parameter.Value = val.Value;
        }
    }
}