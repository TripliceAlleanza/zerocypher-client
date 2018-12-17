using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ZeroCypher.Models
{
    public class RecivedPacket
    {

        public int id { get; set; }
        public string status { get; set;}

        public RecivedPacket(int id, string status)
        {
            this.id = id;
            this.status = status;
        }
            
        public RecivedPacket()
        {
        }
        public static string Serialize(RecivedPacket pak)
        {
            return JsonConvert.SerializeObject(pak);
        }
        public static RecivedPacket Dserialize(string pak)
        {
            return JsonConvert.DeserializeObject<RecivedPacket>(pak);
        }
    }
}
