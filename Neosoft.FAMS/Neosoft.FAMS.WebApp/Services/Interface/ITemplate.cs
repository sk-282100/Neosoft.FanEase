using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Neosoft.FAMS.Application.Features.Template.Commands.TemplateVideo;
using Neosoft.FAMS.Application.Features.Template.Queries;
using Neosoft.FAMS.Application.Features.Template.Queries.GetAllById;

namespace Neosoft.FAMS.WebApp.Services.Interface
{
    public interface Itemplate
    {
        public List<TemplateListDto> GetAllTemplate();
        public TemplateListDto GetTemplate(long id);
        public Task<long> AddTemplateVideo(TemplateVideoMappedCommand mappedCommand);
        public List<GetAllTemplateByIdDto> GetAdvertiseByVideoId(long id);
    }
}
