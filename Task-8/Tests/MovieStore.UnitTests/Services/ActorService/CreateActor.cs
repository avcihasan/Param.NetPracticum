using AutoMapper;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using MovieStore.Application.DTOs.ActorDTOs;
using MovieStore.Application.Repositories;
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
    public class CreateActor : IClassFixture<CommonTestFixture>
    {
        private readonly IActorService _actorService;
        public CreateActor(CommonTestFixture testFixture)
        {
            _actorService=testFixture.ActorService; 
        }

        [Fact]
        public async Task WhenValidInputsAreGiven_Actor_ShouldBeCreated()
        {
            Actor createActor = new() {Name="deneme", Surname="deneme",Email = "deneme@gmail.com"};
            Actor newActor=await FluentActions.Invoking(async () => await _actorService.AddAsync(createActor)).Invoke();
            Actor actor = await _actorService.GetByIdAsync(newActor.Id);
            actor.Should().NotBeNull();
            actor.Name.Should().Be(createActor.Name);
            actor.Email.Should().Be(createActor.Email);
            actor.Surname.Should().Be(createActor.Surname);
            actor.UserName.Should().Be(createActor.UserName);
        }
    }
}
