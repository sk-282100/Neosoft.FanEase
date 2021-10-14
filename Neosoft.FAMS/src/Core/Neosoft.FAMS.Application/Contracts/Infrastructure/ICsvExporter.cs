using Neosoft.FAMS.Application.Features.Events.Queries.GetEventsExport;
using System.Collections.Generic;

namespace Neosoft.FAMS.Application.Contracts.Infrastructure
{
    public interface ICsvExporter
    {
        byte[] ExportEventsToCsv(List<EventExportDto> eventExportDtos);
    }
}
