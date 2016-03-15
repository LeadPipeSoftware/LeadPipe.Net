using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace LeadPipe.Net.Tests.CommandTests
{
    public class InversionOfControl
    {

        private readonly IDictionary<Type, object> _registrations = new ConcurrentDictionary<Type, object>();

        public void Register<TFrom, TTo>()
        {
            _registrations[typeof (TFrom)] = typeof (TTo);
        }

        public void Register<TFrom>(TFrom instance)
        {
            _registrations[typeof (TFrom)] = instance;
        }

        public T Resolve<T>() where T : class
        {
            return (T) Resolve(typeof (T));
        }

        public object Resolve(Type type)
        {
            var result = _registrations[type];

            if (ReferenceEquals(result, null)) return null;

            if (result is Type) return Activator.CreateInstance((Type)result);

            return result;
        }
    }
}