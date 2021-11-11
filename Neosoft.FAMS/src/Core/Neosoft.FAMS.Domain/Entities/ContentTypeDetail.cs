#nullable disable

namespace Neosoft.FAMS.Domain.Entities
{
    public partial class ContentTypeDetail
    {
        public long ContentTypeId { get; set; }
        public string ContentType { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
