using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace PublicProject.Models
{
    public class Password
    {
        [JsonPropertyName("passwords")]
        public string Passwords { get; set; }
    }
}
