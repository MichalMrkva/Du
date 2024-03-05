using System;

namespace Du
{
    public struct Log
    {
        public Priority Priority;
        public DateTime CreatedAt;
        public string Desc;
        public override string ToString()
        {
            return $"{{\n\tCreatedAt: {CreatedAt};\n\tPriority: {Priority};\n\tDescription: {Desc};\n}}";
        }
    }
}
