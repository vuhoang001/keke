﻿using Application.Services.Authentication.Common;
using Contracts.Authentication;
using Mapster;

namespace keke.Common.Mapping;

public class AuthenticationMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<AuthenticationResult, AuthenticationResponse>()
            .Map(dest => dest.Token, src => src.Token)
            .Map(dest => dest, src => src.User);
        // .Map(dest => dest.FirstName, src => src.User.FirstName)
        // .Map(dest => dest.LastName, src => src.User.LastName)
        // .Map(dest => dest.Email, src => src.User.Email)
        // .Map(dest => dest.Id, src => src.User.Id);
    }
}