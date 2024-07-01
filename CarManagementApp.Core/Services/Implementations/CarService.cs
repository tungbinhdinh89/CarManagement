using Bogus;
using CarManagementApp.Domain.Common;
using CarManagementApp.Domain.Entities;
using CarManagementApp.Domain.Models;
using CarManagementApp.Infrastructure.Data;
using CarManagementApp.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;

namespace CarManagementApp.Core.Services.Implementations
{
    public class CarService(IDbContextFactory<ApplicationDbContext> dbContextFactory) : ICarService // new syntax: (record-like constructor)
    {
        public Task<Result<CarModel>> AddCarAsync(CarModel car)
        {
            throw new NotImplementedException();
        }

        public Task<Result<bool>> DeleteCarAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Result<List<CarModel>>> GenerateRandomCarAsync(int count)
        {
            if (count <= 0)
            {
                throw new ArgumentException("Count must be greater than zero", nameof(count));
            }

            using var db = dbContextFactory.CreateDbContext();

            var faker = new Faker<CarEntity>()
                .RuleFor(e => e.Name, f => f.Vehicle.Manufacturer())
                .RuleFor(e => e.Model, f => f.Vehicle.Model())
                .RuleFor(e => e.Make, f => f.Vehicle.Type())
                .RuleFor(e => e.Year, f => f.Date.Past(30, DateTime.Now.AddYears(-20)))
                .RuleFor(e => e.CreatedAt, f => f.Date.Past(10));

            var randomCars = faker.Generate(count);

            db.Cars.AddRange(randomCars);
            await db.SaveChangesAsync();

            var result = randomCars.Select(e => new CarModel
            {
                Id = e.Id,
                Name = e.Name,
                Model = e.Model,
                Make = e.Make,
                Year = e.Year,
                CreatedAt = e.CreatedAt,

            }).ToList();

            return new Result<List<CarModel>>(result);
        }

        public Task<CarModel> GetCarByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Paging<CarModel>> GetCarListAsync(PagingRequest? filter = null)
        {
            filter ??= new();
            using var db = dbContextFactory.CreateDbContext();
            var current = filter.Current;
            var take = filter.PerPage;
            var query = db.Cars.OrderByDescending(x => x.Id).AsQueryable();

            if (!string.IsNullOrWhiteSpace(filter.Search))
            {
                var q = filter.Search.Trim().ToLower();
                query = query.Where(x => x.Make.Contains(q));
            }

            if (!string.IsNullOrWhiteSpace(filter.SortBy))
            {

                var sort = filter.SortBy.Trim();
                query = sort switch
                {
                    // Sort is method import form Extension QueryExtension
                    nameof(CarEntity.Name) => query.Sort(x => x.Name, filter.IsAsc),
                    nameof(CarEntity.Make) => query.Sort(x => x.Make, filter.IsAsc),
                    _ => query
                };
            }

            var paging = await query.ToPagingAsync(u => new CarModel { Id = u.Id, Model = u.Model, Name = u.Name, Make = u.Make }, current, take);
            return paging;
        }

        public Task<Result<CarModel>> UpdateCarAsync(int id, CarModel car)
        {
            throw new NotImplementedException();
        }
    }
}
