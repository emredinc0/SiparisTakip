using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.ProductDto;
using SignalR.DtoLayer.SocialMediaDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialMediaController : ControllerBase
    {
        private readonly ISocialMediaService _socialMediaService;
        private readonly IMapper _mappper;

        public SocialMediaController(ISocialMediaService socialMediaService, IMapper mappper)
        {
            _socialMediaService = socialMediaService;
            _mappper = mappper;
        }

        [HttpGet]
        public IActionResult SocialMediaList()
        {
            var value = _mappper.Map<List<ResultSocialMediaDto>>(_socialMediaService.TGetListAll());
            return Ok(value);
        }
        [HttpPost]

        public IActionResult SocialMediaContact(CreateSocialMediaDto createSocialMediaDto)
        {
            _socialMediaService.TAdd(new SocialMedia()
            {
                Title = createSocialMediaDto.Title,
                Icon = createSocialMediaDto.Icon,
                Url = createSocialMediaDto.Url,
                




            });
            return Ok("Sosyal Medya Bilgisi Eklendi");

        }
        [HttpDelete]
        public IActionResult DeleteSocialMedia(int id)
        {
            var value = _socialMediaService.TGetByID(id);
            _socialMediaService.TDelete(value);
            return Ok("Sosyal Medya Bilgisi Silindi.");
        }
        [HttpGet("GetSocialMedia")]
        public IActionResult GetSocialMedia(int id)
        {
            var value = _socialMediaService.TGetByID(id);

            return Ok(value);

        }
        [HttpPut]
        public IActionResult UpdateSocialMedia(UpdateSocialMediaDto updateSocialMediaDto)
        {
            _socialMediaService.TUpdate(new SocialMedia()
            {
                Url = updateSocialMediaDto.Url,
                Title = updateSocialMediaDto.Title,
                Icon = updateSocialMediaDto.Icon,
                SocialMediaID=updateSocialMediaDto.SocialMediaID,





            });
            return Ok("Sosyal Medya Bilgisi Güncellendi.");
        }
    }
}
