// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EnumerationType.cs" company="Lead Pipe Software">
//     Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Data;
using NHibernate.Dialect;
using NHibernate.SqlTypes;
using NHibernate.Type;

namespace LeadPipe.Net.Data.NHibernate
{
    /// <summary>
    /// A primitive type declaration to support NHibernate mapping for Enumerations.
    /// </summary>
    /// <typeparam name="T">The Enumeration type.</typeparam>
    public class EnumerationType<T> : PrimitiveType where T : Enumeration<T>
    {
        public EnumerationType()
            : base(new SqlType(DbType.Int32))
        {
        }

        public override object Get(IDataReader rs, int index)
        {
            var o = rs[index];
            var value = Convert.ToInt32(o);
            return Enumeration<T>.FromInt32(value);
        }

        public override object Get(IDataReader rs, string name)
        {
            var ordinal = rs.GetOrdinal(name);
            return Get(rs, ordinal);
        }

        public override Type ReturnedClass
        {
            get { return typeof(T); }
        }

        public override object FromStringValue(string xml)
        {
            return int.Parse(xml);
        }

        public override string Name
        {
            get { return "enumeration"; }
        }

        public override void Set(IDbCommand cmd, object value, int index)
        {
            var parameter = (IDataParameter)cmd.Parameters[index];

            var val = (Enumeration<T>)value;

            parameter.Value = val.Value;
        }

        public override string ObjectToSQLString(object value, Dialect dialect)
        {
            return value.ToString();
        }

        public override Type PrimitiveClass
        {
            get { return typeof(int); }
        }

        public override object DefaultValue
        {
            get { return 0; }
        }
    }
}