﻿using MusiciansGearRegistry.Api.Security.models;

namespace MusiciansGearRegistry.Api.Security.interfaces;

public interface ILoginService
{
    LoginResult Login(LoginRequest loginInfo);
}
