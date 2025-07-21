﻿using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace keke.Controllers;

[ApiController]
public class ApiController : ControllerBase
{
    protected IActionResult Problem(List<Error> errors)
    {
        if (errors.Count == 0)
        {
            return Problem();
        }

        return errors.All(errs => errs.Type == ErrorType.Validation) ? ValidationProblem(errors) : Problem(errors[0]);
    }

    private ObjectResult Problem(Error error)
    {
        var statusCode = error.Type switch
        {
            ErrorType.Conflict     => StatusCodes.Status409Conflict,
            ErrorType.Validation   => StatusCodes.Status400BadRequest,
            ErrorType.NotFound     => StatusCodes.Status404NotFound,
            ErrorType.Unauthorized => StatusCodes.Status401Unauthorized,
            _                      => StatusCodes.Status500InternalServerError
        };
        return Problem(statusCode: statusCode, title: error.Description);
    }

    private IActionResult ValidationProblem(List<Error> errors)
    {
        var modelStateDictionary = new ModelStateDictionary();

        foreach (var error in errors)
        {
            var fieldName = !string.IsNullOrEmpty(error.Code) ? error.Code : "general";
            modelStateDictionary.AddModelError(fieldName, error.Description);
        }

        return ValidationProblem(
            modelStateDictionary: modelStateDictionary,
            title: "One or more validation errors occurred",
            detail: "Please check the errors property for details",
            instance: HttpContext.Request.Path
        );
    }
}