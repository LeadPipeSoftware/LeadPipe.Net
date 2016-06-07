// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Linq;
using LeadPipe.Net.Commands;
using LeadPipe.Net.Extensions;
using NUnit.Framework;

namespace LeadPipe.Net.Tests.CommandTests
{
    /// <summary>
    /// Tests for the Submit method.
    /// </summary>
    public class SubmitShould
    {
        /// <summary>
        /// Tests to ensure that a response is returned for a command when at least one handler is registered.
        /// </summary>
        [Test]
        public void ReturnResponseForCommandGivenHandlerIsRegistered()
        {
            // Arrange
            var ioc = new InversionOfControl();
            ioc.Register<ICommandMediator, CommandMediator>();
            ioc.Register<ICommandHandler<DebugWriteCommand, UnitType>, DebugWriteCommandHandler>();

            var mediator = new CommandMediator(ioc.Resolve);

            const string StringToWrite = "This is a test!";

            // Act
            var response = mediator.Submit(new DebugWriteCommand { TextToWrite = StringToWrite });

            // Assert
            Assert.NotNull(response);
        }

        /// <summary>
        /// Tests to ensure that the response contains the exception when the command throws an exception.
        /// </summary>
        [Test]
        public void ReturnResponseWithExceptionForCommandGivenCommandThrowsExceptionAndThrowExceptionIsFalse()
        {
            // Arrange
            var ioc = new InversionOfControl();
            ioc.Register<ICommandMediator, CommandMediator>();
            ioc.Register<ICommandHandler<ExplodingTestCommand, UnitType>, ExplodingTestCommandHandler>();

            var mediator = new CommandMediator(ioc.Resolve, false);

            const string ExpectedExceptionMessage = "Kaboom!";

            // Act & Assert
            var response = mediator.Submit(new ExplodingTestCommand { ExceptionMessage = ExpectedExceptionMessage });

            // Assert
            Assert.NotNull(response.Exception);
            Assert.That(response.Exception.Message.Equals(ExpectedExceptionMessage));
        }

        /// <summary>
        /// Tests to ensure that the response contains the exception when the command throws an exception.
        /// </summary>
        [Test]
        public void ThrowExceptionForGivenCommandGivenCommandThrowsExceptionAndThrowExceptionsIsTrue()
        {
            // Arrange
            var ioc = new InversionOfControl();
            ioc.Register<ICommandMediator, CommandMediator>();
            ioc.Register<ICommandHandler<ExplodingTestCommand, UnitType>, ExplodingTestCommandHandler>();

            var mediator = new CommandMediator(ioc.Resolve);

            const string ExpectedExceptionMessage = "Kaboom!";

            // Act & Assert
            Assert.Throws<Exception>(() => mediator.Submit(new ExplodingTestCommand { ExceptionMessage = ExpectedExceptionMessage }));
        }

        /// <summary>
        /// Tests to ensure that a response is returned for a command despite the fact that no handler is registered.
        /// </summary>
        [Test]
        public void ReturnResponseWithExecutionResultSetToFailedGivenNoHandlerIsRegisteredAndThrowExceptionIsFalse()
        {
            // Arrange
            var ioc = new InversionOfControl();
            ioc.Register<ICommandHandler<DebugWriteCommand>, DebugWriteCommandHandler>();

            var mediator = new CommandMediator(ioc.Resolve, false);

            const string StringToWrite = "This is a test!";

            // Act
            var response = mediator.Submit(new DebugWriteCommand { TextToWrite = StringToWrite });

            // Assert
            Assert.That(response.CommandExecutionResult.Equals(CommandExecutionResult.Failed));
        }

        /// <summary>
        /// Tests to ensure that a response is returned for a command despite the fact that no handler is registered.
        /// </summary>
        [Test]
        public void ThrowCommandHandlerNotFoundExceptionGivenNoHandlerIsRegisteredAndThrowExceptionIsTrue()
        {
            // Arrange
            var ioc = new InversionOfControl();
            ioc.Register<ICommandHandler<DebugWriteCommand>, DebugWriteCommandHandler>();

            var mediator = new CommandMediator(ioc.Resolve);

            const string StringToWrite = "This is a test!";

            // Act & Assert
            Assert.Throws<CommandHandlerNotFoundException>(() => mediator.Submit(new DebugWriteCommand { TextToWrite = StringToWrite }));
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

            var mediator = new CommandMediator(ioc.Resolve, false);

            const string ExpectedExceptionMessage = "Kaboom!";

            // Act & Assert
            var response = mediator.Submit(new ExplodingTestCommand { ExceptionMessage = ExpectedExceptionMessage });

            // Assert
            Assert.That(response.CommandExecutionResult.Equals(CommandExecutionResult.Failed));
        }

        /// <summary>
        /// Tests to ensure that the response contains the exception when the command throws an exception.
        /// </summary>
        [Test]
        public void ThrowExceptionGivenCommandThrowsExceptionAndThrowExceptionEnabled()
        {
            // Arrange
            var ioc = new InversionOfControl();
            ioc.Register<ICommandMediator, CommandMediator>();
            ioc.Register<ICommandHandler<ExplodingTestCommand, UnitType>, ExplodingTestCommandHandler>();

            var mediator = new CommandMediator(ioc.Resolve);

            const string ExpectedExceptionMessage = "Kaboom!";

            // Act & Assert
            Assert.Throws<Exception>(() => mediator.Submit(new ExplodingTestCommand { ExceptionMessage = ExpectedExceptionMessage }));
        }

        /// <summary>
        /// Tests to ensure that the response contains the validation results when the command fails validation.
        /// </summary>
        [Test]
        public void ReturnResponseWithValidationResultsGivenCommandFailsValidation()
        {
            // Arrange
            var ioc = new InversionOfControl();
            ioc.Register<ICommandMediator, CommandMediator>();
            ioc.Register<ICommandHandler<DebugWriteWithValidationCommand, UnitType>, DebugWriteWithValidationCommandHandler>();

            var mediator = new CommandMediator(ioc.Resolve);

            const string ExpectedValidationMessage = "You must supply a value for TextToWrite!";

            // Act & Assert
            var response = mediator.Submit(new DebugWriteWithValidationCommand() { TextToWrite = "Blarg" });

            // Assert
            Assert.That(response.CommandExecutionResult.Equals(CommandExecutionResult.Failed));
            Assert.That(response.ValidationResults.Any().IsTrue());
            Assert.That(response.ValidationResults.First().ErrorMessage.Equals(ExpectedValidationMessage));
        }
    }
}