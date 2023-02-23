using AutoMapper;
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
        private readonly IMapper _mapper;

        public CreateActor(IMapper mapper)
        {
            _mapper = mapper;
        }
    }
}
