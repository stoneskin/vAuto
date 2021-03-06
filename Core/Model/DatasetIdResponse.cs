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
  public class DatasetIdResponse {
    /// <summary>
    /// Gets or Sets DatasetId
    /// </summary>
    [DataMember(Name="datasetId", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "datasetId")]
    public string DatasetId { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class DatasetIdResponse {\n");
      sb.Append("  DatasetId: ").Append(DatasetId).Append("\n");
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
