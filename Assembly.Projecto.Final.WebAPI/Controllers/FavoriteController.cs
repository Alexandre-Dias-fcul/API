using Assembly.Projecto.Final.Services.Dtos.IServiceDtos.OtherModelsDtos;
using Assembly.Projecto.Final.Services.Interfaces;
using Assembly.Projecto.Final.WebAPI.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace Assembly.Projecto.Final.WebAPI.Controllers
{
    public class FavoriteController : BaseController
    {
        private IFavoriteService _favoriteService;

        public FavoriteController(IFavoriteService favoriteService)
        {
            _favoriteService = favoriteService;
        }

        [HttpGet]
        public IEnumerable<FavoriteDto> GetAll()
        {
            return _favoriteService.GetAll();
        }

        [HttpGet("{id:int}")]
        public ActionResult<FavoriteDto> GetById(int id) 
        {
            return Ok(_favoriteService.GetById(id));
        }

        [HttpPost("{listingId:int}")]
        public ActionResult<FavoriteDto> Add(int listingId) 
        {
            var userIdString = User.GetId();

            if (userIdString is null) 
            {
                return NotFound("User id não encontrado.");
            }

            var userId = int.Parse(userIdString);

            CreateFavoriteDto createFavoriteDto = new()
            {
                ListingId = listingId,
                UserId = userId
            };

            return Ok(_favoriteService.Add(createFavoriteDto));
        }

        [HttpDelete("{id:int}")]
        public ActionResult<FavoriteDto> Delete(int id) 
        {
            return Ok(_favoriteService.Delete(id));
        }
    }
}
