using Microsoft.AspNetCore.Mvc;

namespace APIContas.Controllers;

public abstract class BaseController : ControllerBase
{
   protected BaseController() { }   

    protected new ActionResult Response(object result)
    {
        if (result.ToString().Contains("error") ||
                  result.ToString().Contains("mapping") ||
                  result.ToString().Contains("Sequence") ||
                  result.ToString().Contains("cannot") ||
                  result.ToString().Contains("severed") ||
                  result.ToString().Contains("inativado") ||
                  result.ToString().Contains("Id não"))
        {
            return Ok(new
            {
                Success = false,
                Message = "Error",
                Data = result.ToString().Replace("error","")
            });
        }

        return Ok(new
        {
            Success = true,
            Message = "Success",
            Data = result
        });
    }
}
