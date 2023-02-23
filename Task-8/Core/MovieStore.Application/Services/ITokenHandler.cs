using MovieStore.Application.DTOs.TokenDTOs;

namespace MovieStore.Application.Services
{
    public interface ITokenHandler
    {
        TokenDto CreateAccessToken(int minute);
    }
}
