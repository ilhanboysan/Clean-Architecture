﻿using Core.Persistance.Repositories;
using Core.Security.Entities;

namespace Application.Services.Repositories;

public interface IUserOperationClaimRepository : IAsyncRepository<UserOperationClaim, int>, IRepository<UserOperationClaim, int>
{
    Task<IList<OperationClaim>> GetOperationClaimByUserIdAsync(int userId);
}

