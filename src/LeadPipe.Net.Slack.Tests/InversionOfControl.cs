// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace LeadPipe.Net.Slack.Tests
{
    public class InversionOfControl
    {
        private readonly IDictionary<Type, object> registrations = new ConcurrentDictionary<Type, object>();

        public void Register<TFrom, TTo>()
        {
            registrations[typeof(TFrom)] = typeof(TTo);
        }

        public void Register<TFrom>(TFrom instance)
        {
            registrations[typeof(TFrom)] = instance;
        }

        public T Resolve<T>() where T : class
        {
            return (T)Resolve(typeof(T));
        }

        public object Resolve(Type type)
        {
            var result = registrations[type];

            if (ReferenceEquals(result, null)) return null;

            if (result is Type) return Activator.CreateInstance((Type)result);

            return result;
        }
    }
}