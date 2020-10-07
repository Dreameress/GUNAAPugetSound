﻿using System;
using System.Collections.Generic;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using GUNAAPugetSound.Helpers;
using Microsoft.AspNetCore.Http;

namespace GUNAAPugetSound.Middleware
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {
                var response = context.Response;
                response.ContentType = "application/json";

                response.StatusCode = error switch
                {
                    AppException e =>
                    // custom application error
                    (int) HttpStatusCode.BadRequest,
                    KeyNotFoundException e =>
                    // not found error
                    (int) HttpStatusCode.NotFound,
                    _ => (int) HttpStatusCode.InternalServerError
                };

                var result = JsonSerializer.Serialize(new { message = error?.Message });
                //_logger.LogError($"Something went wrong: {result}");
                await response.WriteAsync(result);
            }
        }
    }
}