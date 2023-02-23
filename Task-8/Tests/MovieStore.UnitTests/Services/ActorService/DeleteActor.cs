using FluentAssertions;
using MovieStore.Application.Services;
using MovieStore.Domain.Entities;
using MovieStore.Persistence.Contexts;
using MovieStore.UnitTests.TestSetup;
using Xunit;

namespace MovieStore.UnitTests.Services.ActorService
{
    public class DeleteActor : IClassFixture<CommonTestFixture>
    {
        private readonly IActorService _actorService;
        private readonly MovieStoreAPIDbContext _context;
        public DeleteActor(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _actorService = testFixture.ActorService;
        }

        [Fact]
        public async Task WhenValidInputsAreGiven_Actor_ShouldBeDeleted()
        {
            Actor createActor = new() { Name = "deneme", Surname = "deneme", Email = "deneme@gmail.com" };
            await _actorService.AddAsync(createActor);

            await FluentActions.Invoking(async () => await _actorService.RemoveAsync(createActor.Id)).Invoke();
            Actor deletedActor = _context.Actors.FirstOrDefault(x => x.Id == createActor.Id);

            deletedActor.Should().BeNull();
        }

        [Fact]
        public async Task WhenInvalidInputsAreGiven_Actor_ShouldBeNotDeleted()
        {
            await FluentActions.Invoking(async () => await _actorService.RemoveAsync(0)).Should().ThrowAsync<InvalidOperationException>().WithMessage($"{typeof(Actor).Name} veritabanında kayıtlı değil!");
        }
    }
}
