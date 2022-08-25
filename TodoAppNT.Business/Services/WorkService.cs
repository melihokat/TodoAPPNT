using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoAppNT.Business.Interfaces;
using TodoAppNT.DataAccess.UnitOfWork;
using TodoAppNT.Dtos.WorkDtos;
using TodoAppNT.Entities.Concrete;

namespace TodoAppNT.Business.Services
{
    public class WorkService : IWorkService
    {
        int x = 20;
        private readonly IUow _uow;
        private readonly IMapper _mapper;


        public WorkService(IUow uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task Create(WorkCreateDto dto) //hepsine async diyeceğiz , savechanges async olarak çalışcak.
        {

            await _uow.GetRepository<Work>().Create(_mapper.Map<Work>(dto));
            //await _uow.GetRepository<Work>().Create(new()
            //{

            //    IsCompleted = dto.IsCompleted,
            //    Definition = dto.Definition,
            //});
            await _uow.SaveChanges();
        }

        public async Task<List<WorkListDto>> GetAll()
        {

            //var list = await _uow.GetRepository<Work>().GetAll(); //veriyi Uow ile çekiyoruz
            //var workList = new List<WorkListDto>();
            //if(list != null && list.Count > 0) //Kontrol Ediyoruz.
            //{
            //    foreach(var work in list)  //Mappleme işlemini gerçekleştiriyoruz ve geriye dönüyoruz.
            //    {
            //        workList.Add(new()
            //        {
            //            Definition=work.Definition,
            //            Id=work.Id,
            //            IsCompleted=work.IsCompleted,
            //        });
            //    }
            //}

            return _mapper.Map<List<WorkListDto>>(await _uow.GetRepository<Work>().GetAll());
        }

        public async Task<WorkListDto> GetById(int id)
        {
            return _mapper.Map<WorkListDto>(await _uow.GetRepository<Work>().GetByFilter(x => x.Id == id));
            
            


            //var work = await _uow.GetRepository<Work>().GetByFilter(x=>x.Id ==id);
            //return new()
            //{//izlemeden bize geri gönderecek.
            //    Definition = work.Definition,
            //    IsCompleted = work.IsCompleted
            //};
        }



        public async Task Remove(int id)
        {

            _uow.GetRepository<Work>().Remove(id);
            await _uow.SaveChanges();
        }

        public async Task Update(WorkUpdateDto dto)
        {

            _uow.GetRepository<Work>().Update(_mapper.Map<Work>(dto));
            //_uow.GetRepository<Work>().Update(new()
            //{
            //    Id = dto.Id,
            //    Definition = dto.Definition,
            //    IsCompleted = dto.IsCompleted
            //});

            await _uow.SaveChanges();
        }
    } //DependencyExtension kısmına bağımlılığımızı belirtmemiz gerek.
}
