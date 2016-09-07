using Adwaer.Entity;

namespace Nanny.Domain.Entities
{
    public class EmailPublish : EntityBase<int>
    {
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public string BccList { get; set; }
        public string CcList { get; set; }
        public bool Socceed { get; set; }
        public string Error { get; set; }
    }
}
