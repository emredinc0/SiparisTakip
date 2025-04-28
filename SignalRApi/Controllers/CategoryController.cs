using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.CategoryDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mappper;

        public CategoryController(ICategoryService categoryService, IMapper mappper)
        {
            _categoryService = categoryService;
            _mappper = mappper;
        }
        [HttpGet]
        public IActionResult CategoryList()
        {
            var value = _mappper.Map<List<ResultCategoryDto>>(_categoryService.TGetListAll());
            return Ok(value);
        }
        [HttpPost]

        public IActionResult CreateCategory(CreateCategoryDto createCategoryDto)
        {
            _categoryService.TAdd(new Category()
            {
                CategoryName = createCategoryDto.CategoryName,
                Status = true

            });
            return Ok("Category Eklendi");

        }
        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id)
        {
            var value = _categoryService.TGetByID(id);
            _categoryService.TDelete(value);
            return Ok("Kategori Silindi.");
        }
        [HttpGet("{id}")]
        public IActionResult GetCategory(int id) {
            var value = _categoryService.TGetByID(id);

            return Ok(value);

        }
        [HttpPut]
        public IActionResult UptadeCategory(UpdateCategoryDto updateCategoryDto)
        {
            _categoryService.TUpdate(new Category()
            {
                CategoryName = updateCategoryDto.CategoryName,
                CategoryId = updateCategoryDto.CategoryId,
                Status = updateCategoryDto.Status,
            });
            return Ok("Kategori Güncellendi.");
        }

    }
}
