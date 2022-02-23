using System;

namespace core.Domain
{
    public class MCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ParentId { get; set; }
        public string Status { get; set; }
        
    }
}
