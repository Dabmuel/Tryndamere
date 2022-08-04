using System;
using System.Collections.Generic;
using System.Text;

namespace Tryndamere.Back.Model
{
    class Credential
    {
        public String name { get; set; }

        public String url { get; set; }

        public List<CredentialData> datas { get; set; }
    }
}
