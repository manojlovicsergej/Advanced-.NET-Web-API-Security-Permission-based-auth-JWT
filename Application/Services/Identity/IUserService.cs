﻿using Common.Requests.Identity;
using Common.Responses.Identity;
using Common.Responses.Wrappers;

namespace Application.Services.Identity;

public interface IUserService
{
    Task<IResponseWrapper> RegisterUserAsync(UserRegistrationRequest request, CancellationToken cancellationToken);
    Task<IResponseWrapper> GetUserByIdAsync(string userId);
    Task<IResponseWrapper> GetAllUsersAsync(CancellationToken cancellationToken);
    Task<IResponseWrapper> UpdateUserAsync(UpdateUserRequest request, CancellationToken cancellationToken);
    Task<IResponseWrapper> ChangeUserPasswordAsync(ChangePasswordRequest request, CancellationToken cancellationToken);
    Task<IResponseWrapper> ChangeUserStatusAsync(ChangeUserStatusRequest request, CancellationToken cancellationToken);
    Task<IResponseWrapper> GetRolesAsync(string userId,CancellationToken cancellationToken);
    Task<IResponseWrapper> UpdateUserRolesAsync(UpdateUserRolesRequest request, CancellationToken cancellationToken);
    Task<IResponseWrapper<UserResponse>> GetUserByEmailAsync(string email, CancellationToken cancellationToken);
}