using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.TestimonialDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialController : ControllerBase
    {
        private readonly ITestimonialService _testimonialService;
        private readonly IMapper _mappper;

        public TestimonialController(ITestimonialService testimonialService, IMapper mappper)
        {
            _testimonialService = testimonialService;
            _mappper = mappper;
        }

        [HttpGet]
        public IActionResult TestimonialList()
        {
            var value = _mappper.Map<List<ResultTestimonialDto>>(_testimonialService.TGetListAll());
            return Ok(value);
        }
        [HttpPost]

        public IActionResult TestimonialContact(CreateTestimonialDto createTestimonialDto)
        {
            _testimonialService.TAdd(new Testimonial()
            {
                Comment = createTestimonialDto.Comment,
                Title = createTestimonialDto.Title,
                ImageUrl = createTestimonialDto.ImageUrl,
                Name = createTestimonialDto.Name,
                Status = createTestimonialDto.Status,
                





            });
            return Ok("Sosyal Medya Bilgisi Eklendi");

        }
        [HttpDelete]
        public IActionResult DeleteTestimonial(int id)
        {
            var value = _testimonialService.TGetByID(id);
            _testimonialService.TDelete(value);
            return Ok("Müşteri Yorum Bilgisi Silindi.");
        }
        [HttpGet("GetTestimonial")]
        public IActionResult GetTestimonial(int id)
        {
            var value = _testimonialService.TGetByID(id);

            return Ok(value);

        }
        [HttpPut]
        public IActionResult UpdateTestimonial(UpdateTestimonialDto updateTestimonialDto)
        {
            _testimonialService.TUpdate(new Testimonial()
            {
               Comment=updateTestimonialDto.Comment,
               Title = updateTestimonialDto.Title,
               ImageUrl=updateTestimonialDto.ImageUrl,
               Name = updateTestimonialDto.Name,
               Status = updateTestimonialDto.Status,
               TestimonialID=updateTestimonialDto.TestimonialID





            });
            return Ok("Müşteri Yorum Bilgisi Güncellendi.");
        }
    }
}
