using System;
using System.Collections.Generic;
using System.Text;

namespace Tryndamere.Back.Model
{
    class ProfileMetaData
    {
        public DateTime created { get; set; }

        public DateTime lastModified { get; set; }

        public String name { get; set; }

        public String description { get; set; }
    }
}
