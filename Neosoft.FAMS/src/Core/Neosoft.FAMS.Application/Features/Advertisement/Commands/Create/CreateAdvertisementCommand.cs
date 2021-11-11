using MediatR;
using Neosoft.FAMS.Application.Responses;
using System;

namespace Neosoft.FAMS.Application.Features.Advertisement.Commands.Create
{
    public class CreateAdvertisementCommand : IRequest<Response<long>>
    {
        public string Title { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public short? ContentTypeId { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public string VideoPath { get; set; }
        public string Url { get; set; }
        public long? PlacementId { get; set; }
        public long? CreatedBy { get; set; }
        public bool? IsDeleted { get; set; }
        public short? Status { get; set; }
        public DateTime? CreatedOn { get; set; }

    }
}
