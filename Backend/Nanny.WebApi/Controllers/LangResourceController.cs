using System.Runtime.Serialization;
using System.Threading.Tasks;
using System.Web.Http;
using Nanny.Commands;
using Nanny.Queries;

namespace Nanny.WebApi.Controllers
{
    [AllowAnonymous]
    public class LangResourceController : ApiController
    {
        private readonly LangResourceQuery _langResourceQuery;
        private readonly SaveLangResourceCommand _saveLangResourceCommand;

        public LangResourceController(LangResourceQuery langResourceQuery, SaveLangResourceCommand saveLangResourceCommand)
        {
            _langResourceQuery = langResourceQuery;
            _saveLangResourceCommand = saveLangResourceCommand;
        }

        public async Task<IHttpActionResult> Get(string id)
        {
            return Ok(await _langResourceQuery.Execute(id, System.Threading.Thread.CurrentThread.CurrentUICulture.IetfLanguageTag));
        }
        
        public async Task<IHttpActionResult> Post(LangResourcePostModel res)
        {
            await _saveLangResourceCommand.Execute(res.Id, res.Value);
            return Ok();
        }
    }

    [DataContract]
    public class LangResourcePostModel
    {
        [DataMember(Name = "id")]
        public string Id { get; set; }
        [DataMember(Name = "value")]
        public string Value { get; set; }
    }
}
