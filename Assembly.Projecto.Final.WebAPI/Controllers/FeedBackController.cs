using Assembly.Projecto.Final.Services.Dtos.IServiceDtos.OtherModelsDtos;
using Assembly.Projecto.Final.Services.Interfaces;
using Assembly.Projecto.Final.WebAPI.Extensions;
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

        [HttpGet]
        public IEnumerable<FeedBackDto> GetAll()
        {
            return _feedBackService.GetAll();
        }

        [HttpGet("{id:int}")]
        public ActionResult<FeedBackDto> GetById(int id)
        {
            return Ok(_feedBackService.GetById(id));
        }

        [HttpPost]
        public ActionResult<FeedBackDto> Add([FromBody] CreateFeedBackServiceDto createFeedBackServiceDto)
        {
            var userIdString = User.GetId();

            if (userIdString is null)
            {
                return NotFound("User id não foi encontrado.");
            }

            int userId = int.Parse(userIdString);

            CreateFeedBackDto createFeedBackDto = new()
            {
                Rate = createFeedBackServiceDto.Rate,
                Comment = createFeedBackServiceDto.Comment,
                CommentDate = createFeedBackServiceDto.CommentDate,
                ListingId = createFeedBackServiceDto.ListingId,
                UserId = userId
            };

            return Ok(_feedBackService.Add(createFeedBackDto));
        }

        [HttpPut("{id:int}")]
        public ActionResult<FeedBackDto> Update([FromRoute] int id, [FromBody] FeedBackServiceDto feedBackServiceDto)
        {
            if (id != feedBackServiceDto.Id)
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
                Rate = feedBackServiceDto.Rate,
                Comment = feedBackServiceDto.Comment,
                CommentDate = feedBackServiceDto.CommentDate,
                ListingId = feedBackServiceDto.ListingId,
                UserId = userId
            };

            return Ok(_feedBackService.Update(feedBackDto));
        }

        [HttpDelete("{id:int}")]
        public ActionResult<FeedBackDto> Delete(int id) 
        {
            return Ok(_feedBackService.Delete(id));
        }
    }
}
