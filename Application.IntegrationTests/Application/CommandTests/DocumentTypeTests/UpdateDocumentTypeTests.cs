﻿using BjBygg.Application.Application.Commands.DocumentTypeCommands.Update;
using BjBygg.Application.Common;
using BjBygg.Application.Common.Exceptions;
using CleanArchitecture.Core;
using CleanArchitecture.Core.Entities;
using FluentAssertions;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Application.IntegrationTests.Application.CommandTests.DocumentTypeTests
{
    using static AppTesting;

    public class UpdateDocumentTypeTests : AppTestBase
    {
        [Test]
        public void ShouldRequireValidDocumentTypeId()
        {
            var command = new UpdateDocumentTypeCommand
            {
                Id = "notvalid",
                Name = "New Name"
            };

            FluentActions.Invoking(() =>
                SendAsync(command)).Should().Throw<EntityNotFoundException>();
        }

        [Test]
        public async Task ShouldUpdateDocumentType()
        {
            var user = await RunAsDefaultUserAsync(Roles.Leader);

            await AddAsync(new DocumentType() { Id = "test", Name = "test" });

            var command = new UpdateDocumentTypeCommand
            {
                Id = "test",
                Name = "Updated Name"
            };

            await SendAsync(command);

            var entity = await FindAsync<DocumentType>("test");

            entity.Name.Should().Be(command.Name);
            entity.UpdatedBy.Should().NotBeNull();
            entity.UpdatedBy.Should().Be(user.UserName);
            entity.UpdatedAt.Should().BeCloseTo(DateTimeHelper.Now(), 1000);
        }
    }
}
