using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Threading.Tasks;

namespace WebFrontEnd.Controllers
{
    public class GuessController : ApiController
    {
        [HttpGet]
        [Route("guess/guess/{number}/{guid}")]
        public Task<int> Guess(int number,System.Guid guid)
        {
            return Orleans.GrainClient.GrainFactory.GetGrain<GuessInterfaces.IGuessGame>(guid).Guess(number);
        }

        [HttpGet]
        [Route("guess/create/{min}/{max}")]
        public Task<System.Guid> Create(int min, int max)
        {
            return Orleans.GrainClient.GrainFactory.GetGrain<GuessInterfaces.IGuessGame>(Guid.NewGuid()).CreateGame(min,max);
        }
    }
}
