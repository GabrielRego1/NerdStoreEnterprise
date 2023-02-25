using System.Collections.Generic;

namespace NSE.Core.Communication
{

    public class ResponseErrorMessages
    {
        public ResponseErrorMessages()
        {
            Mensagens = new List<string>();
        }
        public List<string> Mensagens { get; set; }
    }
}