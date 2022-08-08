using System;
using System.Collections.Generic;

namespace back.Model
{
    public partial class Content
    {
        public int Id { get; set; }
        public byte[] Bytes { get; set; } = null!;
    }
}
