using System;

namespace Neosoft.FAMS.Application.Features.Advertisement.Queries.GetAll
{
    public class AdvertisementListQueryDto
    {
        public long AdvertisementId { get; set; }
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
        public DateTime? CreatedOn { get; set; }
        public bool? IsDeleted { get; set; }
        public short? Status { get; set; }
    }
}
