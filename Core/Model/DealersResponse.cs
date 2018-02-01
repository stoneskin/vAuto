using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace VAuto.Core.Model {

  /// <summary>
  /// 
  /// </summary>
  [DataContract]
  public class DealersResponse {
    /// <summary>
    /// Gets or Sets DealerId
    /// </summary>
    [DataMember(Name="dealerId", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "dealerId")]
    public int? DealerId { get; set; }

    /// <summary>
    /// Gets or Sets Name
    /// </summary>
    [DataMember(Name="name", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "name")]
    public string Name { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class DealersResponse {\n");
      sb.Append("  DealerId: ").Append(DealerId).Append("\n");
      sb.Append("  Name: ").Append(Name).Append("\n");
      sb.Append("}\n");
      return sb.ToString();
    }

    /// <summary>
    /// Get the JSON string presentation of the object
    /// </summary>
    /// <returns>JSON string presentation of the object</returns>
    public string ToJson() {
      return JsonConvert.SerializeObject(this, Formatting.Indented);
    }

}
}
