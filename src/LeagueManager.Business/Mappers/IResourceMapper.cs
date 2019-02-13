using LeagueManager.Database.Models;

namespace LeagueManager.Business.Mappers
{
    internal interface IResourceMapper<TM, TR>
        where TR : class, IHasId
    {
        TM ToModel(TR resource);

        TR ToResource(TM model);
    }
}
