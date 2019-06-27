using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Gof.Api.Core.Infrastructure
{
    using ExtensionMethods;

    public class QueryResponder<TResult> : IResponder
    {
        private readonly ICommandBus _commanBus;
        private readonly ControllerBase _controller;

        public QueryResponder(ICommandBus commanBus, ControllerBase controller)
        {
            this._controller = controller;
            this._commanBus = commanBus;
        }

        public async Task<ActionResult> RespondTo(object command)
        {
            if (!this._controller.ModelState.IsValid)
            {
                return this._controller.BadRequest();
            }

            var result = await this._commanBus.Send<TResult>(command);

            if (result == null)
            {
                return this._controller.NotFound();
            }

            return this._controller.Ok(result);
        }
    }
}
