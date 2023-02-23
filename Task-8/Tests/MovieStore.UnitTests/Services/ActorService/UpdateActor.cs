using FluentAssertions;
using MovieStore.Application.DTOs.ActorDTOs;
using MovieStore.Application.Services;
using MovieStore.Domain.Entities;
using MovieStore.Persistence.Contexts;
using MovieStore.UnitTests.TestSetup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MovieStore.UnitTests.Services.ActorService
{
    public class UpdateActor : IClassFixture<CommonTestFixture>
    {
        private readonly IActorService _actorService;
        private readonly MovieStoreAPIDbContext _context;
        public UpdateActor(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _actorService = testFixture.ActorService;
        }
    

        [Fact]
        public async Task WhenGivenAuthorIdIsNotinDB_InvalidOperationException_ShouldBeReturn()
        {
            UpdateActorDto updateAuthor = new() { Name = "deneme", Surname = "deneme", Email = "deneme@gmail.com" };

           await FluentActions.Invoking(async () => await _actorService.UpdateActorAsync(0, updateAuthor)).Should().ThrowAsync<InvalidOperationException>().WithMessage("Actor veritabanında kayıtlı değil!");
        }
    }
}
