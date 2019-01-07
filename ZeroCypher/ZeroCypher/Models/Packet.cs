using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ZeroCypher.Models {
   public class Packet {

        public int id { get; set; }
        public string message { get; set; }
        public string key { get; set; }
        public bool mode { get; set; }
        public string algorithm { get; set; }
        public string status { get; set; }


        public Packet() {
        }

        public Packet(string msg, string key, bool mod, string algorithm, string status) {
            this.message = msg;
            this.key = key;
            this.mode = mod;
            this.algorithm = algorithm;
            this.status = status;
        }

        public void SetHashCode() {
            id = GetHashCode();
        }
        public override bool Equals(object obj) {
            var packet = obj as Packet;
            return packet != null &&
                   message == packet.message &&
                   key == packet.key &&
                   mode == packet.mode &&
                   algorithm == packet.algorithm &&
                   status == packet.status;
        }

        public override int GetHashCode() {
            var hashCode = -594347158;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(message);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(key);
            hashCode = hashCode * -1521134295 + mode.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(algorithm);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(status);
            return hashCode;
        }

        public static bool operator ==(Packet packet1, Packet packet2) {
            return EqualityComparer<Packet>.Default.Equals(packet1, packet2);
        }

        public static bool operator !=(Packet packet1, Packet packet2) {
            return !(packet1 == packet2);
        }

        public static string Serialize(Packet pak, bool indent) {
            if (indent)
                return JsonConvert.SerializeObject(pak, Formatting.Indented);
            else
                return JsonConvert.SerializeObject(pak, Formatting.None);
        }
        public static Packet Dserialize(string pak) {
            return JsonConvert.DeserializeObject<Packet>(pak);
        }
    }
}
