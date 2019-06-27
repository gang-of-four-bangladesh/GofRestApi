using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Gof.Api.Core.Infrastructure
{
    public interface IResponder
    {
        Task<ActionResult> RespondTo(object command);
    }
}
