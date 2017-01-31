using System;
using System.Collections.Generic;
using LeadPipe.Net.Extensions;
using NUnit.Framework;

namespace LeadPipe.Net.Domain.Tests.DomainEventingTests
{
    public class UnregisterShould
    {

        private class TestHandlerClass
        {
            private readonly string _instanceName;

            public TestHandlerClass(string instanceName)
            {
                _instanceName = instanceName;
            }

            public void Handle(TestDomainEvent e)
            {
                e.NewName = _instanceName;
            }

        }

        [Test]
        public void UnregisterTheCallbackAction()
        {
            const string expectedName = "Nothing happened";

            var action = new Action<TestDomainEvent>(x => x.NewName = "GOT IT");

            DomainEvents.Register(action);

            //Act
            DomainEvents.Unregister(action);

            //Assert nothing was called
            var e = new TestDomainEvent() {NewName = expectedName };
            DomainEvents.Raise(e);
            Assert.AreEqual(expectedName, e.NewName);

            //Assert no registrations remaining
            var actions = Local.Data[DomainEvents.DomainEventActionsKey] as List<Delegate>;
            Assert.That(actions.IsEmpty());
        }

        [Test]
        public void NotUnregisterACallbackForAnotherInstance()
        {
            var myInstance = new TestHandlerClass("My instance");

            const string expectedInstanceName = "Some other instance";
            var someoneElsesInstance = new TestHandlerClass(expectedInstanceName);

            DomainEvents.Register<TestDomainEvent>(myInstance.Handle);
            DomainEvents.Register<TestDomainEvent>(someoneElsesInstance.Handle);

            //Act
            DomainEvents.Unregister<TestDomainEvent>(myInstance.Handle);


            var actions = Local.Data[DomainEvents.DomainEventActionsKey] as List<Delegate>;

            //Assert that only 1 handler is registered
            Assert.That(actions.Count == 1);


            //Assert that the correct handler is registered
            var e = new TestDomainEvent();
            DomainEvents.Raise(e);
            Assert.That(e.NewName == expectedInstanceName);
        }

        [SetUp, TearDown]
        public void Cleanup()
        {
            DomainEvents.Clear();
        }
    }
}