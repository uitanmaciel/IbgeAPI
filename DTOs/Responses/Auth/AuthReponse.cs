﻿namespace IbgeAPI.DTOs.Responses.Auth;

public class AuthReponse
{
    public string Message { get; set; } = null!;
    public string Data { get; set; } = null!;
    public string Error { get; set; } = null!;
}