﻿using Application.Services.Repositories;
using Core.Persistance.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class BrandRepository : EfRepositoryBase<Brand, Guid, BaseDbContext>, IBrandRepository
{
    public BrandRepository(BaseDbContext context) : base(context)
    {
    }
}
