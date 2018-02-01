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
  public class VehicleResponse {
    /// <summary>
    /// Gets or Sets VehicleId
    /// </summary>
    [DataMember(Name="vehicleId", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "vehicleId")]
    public int? VehicleId { get; set; }

    /// <summary>
    /// Gets or Sets Year
    /// </summary>
    [DataMember(Name="year", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "year")]
    public int? Year { get; set; }

    /// <summary>
    /// Gets or Sets Make
    /// </summary>
    [DataMember(Name="make", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "make")]
    public string Make { get; set; }

    /// <summary>
    /// Gets or Sets Model
    /// </summary>
    [DataMember(Name="model", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "model")]
    public string Model { get; set; }

    /// <summary>
    /// Gets or Sets DealerId
    /// </summary>
    [DataMember(Name="dealerId", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "dealerId")]
    public int? DealerId { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class VehicleResponse {\n");
      sb.Append("  VehicleId: ").Append(VehicleId).Append("\n");
      sb.Append("  Year: ").Append(Year).Append("\n");
      sb.Append("  Make: ").Append(Make).Append("\n");
      sb.Append("  Model: ").Append(Model).Append("\n");
      sb.Append("  DealerId: ").Append(DealerId).Append("\n");
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
