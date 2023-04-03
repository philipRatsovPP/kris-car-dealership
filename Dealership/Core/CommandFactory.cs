﻿using Dealership.Commands;
using Dealership.Commands.Contracts;
using Dealership.Commands.Enums;
using Dealership.Core.Contracts;
using Dealership.Exceptions;

using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Dealership.Core
{
    public class CommandFactory : ICommandFactory
    {
        private const char SplitCommandSymbol = ' ';
        private const string CommentOpenSymbol = "{{";
        private const string CommentCloseSymbol = "}}";

        private readonly IRepository repository;

        public CommandFactory(IRepository repository)
        {
            this.repository = repository;
        }

        public ICommand Create(string commandLine)
        {
            CommandType commandType = ParseCommandType(commandLine);
            List<string> commandParameters = this.ExtractCommandParameters(commandLine);

            switch (commandType)
            {
                case CommandType.RegisterUser:
                    return new RegisterUserCommand(commandParameters, repository);
                case CommandType.Login:
                    return new LoginCommand(commandParameters, repository);
                case CommandType.Logout:
                    return new LogoutCommand(repository);
                case CommandType.AddVehicle:
                    return new AddVehicleCommand(commandParameters, repository);
                case CommandType.RemoveVehicle:
                    return new RemoveVehicleCommand(commandParameters, repository);
                case CommandType.AddComment:
                    return new AddCommentCommand(commandParameters, repository);
                case CommandType.RemoveComment:
                    return new RemoveCommentCommand(commandParameters, repository);
                case CommandType.ShowUsers:
                    // ToDo
                    throw new NotImplementedException();
                case CommandType.ShowVehicles:
                    return new ShowVehiclesCommand(commandParameters, repository);
                default:
                    throw new InvalidUserInputException($"Command with name: {commandType} doesn't exist!");
            }
        }

        // Receives a full line and extracts the command to be executed from it.
        // For example, if the input line is "FilterBy Assignee John", the method will return "FilterBy".
        private CommandType ParseCommandType(string commandLine)
        {
            string commandName = commandLine.Split(SplitCommandSymbol)[0];
            Enum.TryParse(commandName, true, out CommandType result);
            return result;
        }

        // Receives a full line and extracts the parameters that are needed for the command to execute.
        // For example, if the input line is "FilterBy Assignee John",
        // the method will return a list of ["Assignee", "John"].
        private List<string> ExtractCommandParameters(string commandLine)
        {
            List<string> parameters = new List<string>();

            var indexOfOpenComment = commandLine.IndexOf(CommentOpenSymbol);
            var indexOfCloseComment = commandLine.IndexOf(CommentCloseSymbol);
            if (indexOfOpenComment >= 0)
            {
                var commentStartIndex = indexOfOpenComment + CommentOpenSymbol.Length;
                var commentLength = indexOfCloseComment - CommentCloseSymbol.Length - indexOfOpenComment;
                string commentParameter = commandLine.Substring(commentStartIndex, commentLength);
                parameters.Add(commentParameter);

                Regex regex = new Regex("{{.+(?=}})}}");
                commandLine = regex.Replace(commandLine, string.Empty);
            }

            var indexOfFirstSeparator = commandLine.IndexOf(SplitCommandSymbol);
            parameters.AddRange(commandLine.Substring(indexOfFirstSeparator + 1).Split(new[] { SplitCommandSymbol }, StringSplitOptions.RemoveEmptyEntries));

            return parameters;
        }
    }
}
