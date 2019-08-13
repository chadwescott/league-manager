using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace LeagueManager.Api.Controllers
{
    [ApiController]
    public abstract class BaseController
    {
        protected IMapper Mapper;

        protected BaseController(IMapper mapper)
        {
            Mapper = mapper;
        }
    }
}
