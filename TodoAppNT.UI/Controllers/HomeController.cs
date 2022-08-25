using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TodoAppNT.Business.Interfaces;
using TodoAppNT.Dtos.WorkDtos;

namespace TodoAppNT.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWorkService _workService; //work ile alakalı işlemler.
        private readonly IMapper _mapper;
        public HomeController(IWorkService workService, IMapper mapper)
        {
            _workService = workService; //IWorkServiceyi görünce WorkServiceyi Örnekler.DependencyExtension.
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var workList = await _workService.GetAll();

            return View(workList);
        }

        public IActionResult Create()
        {
            return View(new WorkCreateDto());
        }
        [HttpPost]
        public async Task<IActionResult> Create(WorkCreateDto dto)
        {
            if (ModelState.IsValid)
            {
                await _workService.Create(dto);
                return RedirectToAction("Index");
            }

            return View(dto);

        }
        public async Task<IActionResult> Update(int id)
        {
            var dto = await _workService.GetById(id);

            
            return View(_mapper.Map<WorkUpdateDto>(dto));
            //return View(new WorkUpdateDto
            //{
            //    Id = id,
            //    Definition = dto.Definition,
            //    IsCompleted = dto.IsCompleted,
            //});
        }

        [HttpPost]
        public async Task<IActionResult> Update(WorkUpdateDto dto)
        {
            if (ModelState.IsValid)
            {
                await _workService.Update(dto);
                return RedirectToAction("Index");
            }
            return View(dto);

        }

        public async Task<IActionResult> Remove(int id)
        {
            await _workService.Remove(id);
            return RedirectToAction("Index");
        }

    }
}
