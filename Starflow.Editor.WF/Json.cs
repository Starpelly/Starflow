using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Starflow.Editor
{
    public class Json : JsonTextWriter
    {
        public Json(TextWriter textWriter) : base(textWriter)
        {
        }
    }
}
