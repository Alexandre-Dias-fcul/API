using Assembly.Projecto.Final.Services.Dtos.IServiceDtos.OtherModelsDtos;
using Assembly.Projecto.Final.Services.Interfaces;
using Assembly.Projecto.Final.WebAPI.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Assembly.Projecto.Final.WebAPI.Controllers
{
    public class FeedBackController : BaseController
    {
        private IFeedBackService _feedBackService;

        public FeedBackController(IFeedBackService feedBackService)
        {
            _feedBackService = feedBackService;
        }

        [Authorize(Roles = "User,Admin")]
        [HttpGet]
        public IEnumerable<FeedBackDto> GetAll()
        {
            return _feedBackService.GetAll();
        }

        [Authorize(Roles = "User,Admin")]
        [HttpGet("{id:int}")]
        public ActionResult<FeedBackDto> GetById(int id)
        {
            return Ok(_feedBackService.GetById(id));
        }

        [AllowAnonymous]
        [HttpGet("GetByListingId/{idListing:int}")]

        public IEnumerable<FeedBackDto> GetByListingId(int idListing)
        {
            return _feedBackService.GetByListingId(idListing);
        }

        [Authorize(Roles = "User")]
        [HttpPost]
        public ActionResult<FeedBackDto> Add([FromBody] CreateFeedBackControllerDto createFeedBackControllerDto)
        {
            var userIdString = User.GetId();

            if (userIdString is null)
            {
                return NotFound("User id não foi encontrado.");
            }

            int userId = int.Parse(userIdString);

            CreateFeedBackDto createFeedBackDto = new()
            {
                Rate = createFeedBackControllerDto.Rate,
                Comment = createFeedBackControllerDto.Comment,
                CommentDate = createFeedBackControllerDto.CommentDate,
                ListingId = createFeedBackControllerDto.ListingId,
                UserId = userId
            };

            return Ok(_feedBackService.Add(createFeedBackDto));
        }

        [Authorize(Roles = "User")]
        [HttpPut("{id:int}")]
        public ActionResult<FeedBackDto> Update([FromRoute] int id, [FromBody] FeedBackControllerDto feedBackControllerDto)
        {
            if (id != feedBackControllerDto.Id)
            {
                return BadRequest("Os ids não coincidem.");
            }

            var userIdString = User.GetId();

            if (userIdString is null)
            {
                return NotFound("User id não foi encontrado.");
            }

            int userId = int.Parse(userIdString);

            FeedBackDto feedBackDto = new()
            {
                Rate = feedBackControllerDto.Rate,
                Comment = feedBackControllerDto.Comment,
                CommentDate = feedBackControllerDto.CommentDate,
                ListingId = feedBackControllerDto.ListingId,
                UserId = userId
            };

            return Ok(_feedBackService.Update(feedBackDto));
        }

        [Authorize(Roles = "User,Admin")]
        [HttpDelete("{id:int}")]
        public ActionResult<FeedBackDto> Delete(int id) 
        {
            return Ok(_feedBackService.Delete(id));
        }
    }
}
