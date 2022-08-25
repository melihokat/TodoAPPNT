using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoAppNT.Business.Interfaces;
using TodoAppNT.Business.Mapping.AutoMapper;
using TodoAppNT.Business.Services;
using TodoAppNT.DataAccess.Context;
using TodoAppNT.DataAccess.UnitOfWork;

namespace TodoAppNT.Business.DependencyResolvers.Microsoft
{//Burada ISelfService ile startupu genişletiriz. Extensionlar classları genişletir. UI katmanı DataAccess i görmesin diye
    public static class DependencyExtension //Extension class static olmalı
    {
        public static void AddDependencies(this IServiceCollection services)
        {
            services.AddDbContext<TodoContext>(opt =>
            {
                opt.UseSqlServer("server=N110730\\SQLEXPRESS;database=TodoDB;integrated security=true;");
                opt.LogTo(Console.WriteLine, LogLevel.Information);
            });

            services.AddScoped<IUow, Uow>();
            services.AddScoped<IWorkService, WorkService>();

            var configuration = new MapperConfiguration(opt =>
            {
                opt.AddProfile(new WorkProfile());
            });

            var mapper = configuration.CreateMapper();

            services.AddSingleton(mapper); // mapperi gördüğün zaman IMapper ile hareket et.
        }
    }
}
