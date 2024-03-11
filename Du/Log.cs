using System;

namespace Du
{
    public class Log
    {
        public Priority Priority {  get; set; }
        public DateTime CreatedAt { get; set; }
        public string Desc { get; set; }
        public override string ToString()
        {
            return $"{{\n\tCreatedAt: {CreatedAt};\n\tPriority: {Priority};\n\tDescription: {Desc};\n}}";
        }
    }
}
