// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RequestShould.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using LeadPipe.Net.Commands;
using NUnit.Framework;

namespace LeadPipe.Net.Tests.CommandTests
{
    /// <summary>
    /// Tests for the Request method.
    /// </summary>
    public class RequestShould
    {
        /// <summary>
        /// Tests to ensure that a response is returned for a command despite the fact that no handler is registered.
        /// </summary>
        [Test]
        public void ReturnResponseWithExceptionForCommandGivenNoHandlerIsRegistered()
        {
            // Arrange
            var ioc = new InversionOfControl();
            ioc.Register<ICommandHandler<DebugWriteCommand>, DebugWriterCommandHandler>();

            var mediator = new CommandMediator(ioc.Resolve);

            const string StringToWrite = "This is a test!";

            // Act
            var response = mediator.Request(new DebugWriteCommand { TextToWrite = StringToWrite });

            // Assert
            Assert.That(response.HasException(), Is.True);
        }

        /// <summary>
        /// Tests to ensure that a response is returned for a command when at least one handler is registered.
        /// </summary>
        [Test]
        public void ReturnResponseForCommandGivenHandlerIsRegistered()
        {
            // Arrange
            var ioc = new InversionOfControl();
            ioc.Register<ICommandMediator, CommandMediator>();
            ioc.Register<ICommandHandler<DebugWriteCommand, UnitType>, DebugWriterCommandHandler>();

            var mediator = new CommandMediator(ioc.Resolve);

            const string StringToWrite = "This is a test!";

            // Act
            var response = mediator.Request(new DebugWriteCommand { TextToWrite = StringToWrite });

            // Assert
            Assert.NotNull(response);
        }

        /// <summary>
        /// Tests to ensure that the response contains the exception when the command throws an exception.
        /// </summary>
        [Test]
        public void ReturnResponseWithExceptionForCommandGivenCommandThrowsException()
        {
            // Arrange
            var ioc = new InversionOfControl();
            ioc.Register<ICommandMediator, CommandMediator>();
            ioc.Register<ICommandHandler<ExplodingTestCommand, UnitType>, ExplodingTestCommandHandler>();

            var mediator = new CommandMediator(ioc.Resolve);

            const string ExpectedExceptionMessage = "Kaboom!";

            // Act & Assert
            var response = mediator.Request(new ExplodingTestCommand { ExceptionMessage = ExpectedExceptionMessage });

            // Assert
            Assert.NotNull(response.Exception);
            Assert.That(response.Exception.Message.Equals(ExpectedExceptionMessage));
        }

        /// <summary>
        /// Tests to ensure that the response contains the exception when the command throws an exception.
        /// </summary>
        [Test]
        public void ReturnResponseWithExecutionResultSetToFailedGivenCommandThrowsException()
        {
            // Arrange
            var ioc = new InversionOfControl();
            ioc.Register<ICommandMediator, CommandMediator>();
            ioc.Register<ICommandHandler<ExplodingTestCommand, UnitType>, ExplodingTestCommandHandler>();

            var mediator = new CommandMediator(ioc.Resolve);

            const string ExpectedExceptionMessage = "Kaboom!";

            // Act & Assert
            var response = mediator.Request(new ExplodingTestCommand { ExceptionMessage = ExpectedExceptionMessage });

            // Assert
            Assert.That(response.CommandExecutionResult.Equals(CommandExecutionResult.Failed));
        }
    }
}