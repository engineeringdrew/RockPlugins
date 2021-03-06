/* 
 * Push API
 *
 * No description provided (generated by Swagger Codegen https://github.com/swagger-api/swagger-codegen)
 *
 * OpenAPI spec version: 1.0.0
 * Contact: api@subsplash.com
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */
using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;

namespace com.subsplash.Model
{
    /// <summary>
    /// A Platform Endpoint represents the device end of a communication channel used for push notifications.
    /// </summary>
    [DataContract]
        public partial class PlatformEndpoint :  IEquatable<PlatformEndpoint>, IValidatableObject
    {
        /// <summary>
        /// Defines Platform
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
                public enum PlatformEnum
        {
            /// <summary>
            /// Enum Itunes for value: itunes
            /// </summary>
            [EnumMember(Value = "itunes")]
            Itunes = 1,
            /// <summary>
            /// Enum Googleplay for value: google_play
            /// </summary>
            [EnumMember(Value = "google_play")]
            Googleplay = 2        }
        /// <summary>
        /// Gets or Sets Platform
        /// </summary>
        [DataMember(Name="platform", EmitDefaultValue=false)]
        public PlatformEnum? Platform { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="PlatformEndpoint" /> class.
        /// </summary>
        /// <param name="id">The unique identifier of the platform endpoint.</param>
        /// <param name="appKey">appKey.</param>
        /// <param name="token">Unique token assigned to the device after it registers with its corresponding push notification service (APNS, GCM, or FCM)..</param>
        /// <param name="legacyAppInstallId">Unique ID of an app install (legacy). Required if &#x60;app_install_id&#x60; is not provided.</param>
        /// <param name="appInstallId">Unique ID of an app install. Required if &#x60;legacy_app_install_id&#x60; is not provided.</param>
        /// <param name="awsSnsEndpointArn">Platform Endpoint Amazon Resource Name..</param>
        /// <param name="platform">platform.</param>
        /// <param name="links">links.</param>
        /// <param name="embedded">Embedded properties of Platform Endpoint..</param>
        public PlatformEndpoint(Guid? id = default(Guid?), string appKey = default(string), string token = default(string), int? legacyAppInstallId = default(int?), byte[] appInstallId = default(byte[]), string awsSnsEndpointArn = default(string), PlatformEnum? platform = default(PlatformEnum?), SelfLink links = default(SelfLink), Object embedded = default(Object))
        {
            this.Id = id;
            this.AppKey = appKey;
            this.Token = token;
            this.LegacyAppInstallId = legacyAppInstallId;
            this.AppInstallId = appInstallId;
            this.AwsSnsEndpointArn = awsSnsEndpointArn;
            this.Platform = platform;
            this.Links = links;
            this.Embedded = embedded;
        }
        
        /// <summary>
        /// The unique identifier of the platform endpoint
        /// </summary>
        /// <value>The unique identifier of the platform endpoint</value>
        [DataMember(Name="id", EmitDefaultValue=false)]
        public Guid? Id { get; set; }

        /// <summary>
        /// Gets or Sets AppKey
        /// </summary>
        [DataMember(Name="app_key", EmitDefaultValue=false)]
        public string AppKey { get; set; }

        /// <summary>
        /// Moment when the platform endpoint was created.
        /// </summary>
        /// <value>Moment when the platform endpoint was created.</value>
        [DataMember(Name="created_at", EmitDefaultValue=false)]
        public DateTime? CreatedAt { get; private set; }

        /// <summary>
        /// Moment when the platform endpoint was last changed.
        /// </summary>
        /// <value>Moment when the platform endpoint was last changed.</value>
        [DataMember(Name="updated_at", EmitDefaultValue=false)]
        public DateTime? UpdatedAt { get; private set; }

        /// <summary>
        /// Moment when the platform endpoint was deleted.
        /// </summary>
        /// <value>Moment when the platform endpoint was deleted.</value>
        [DataMember(Name="deleted_at", EmitDefaultValue=false)]
        public DateTime? DeletedAt { get; private set; }

        /// <summary>
        /// Unique token assigned to the device after it registers with its corresponding push notification service (APNS, GCM, or FCM).
        /// </summary>
        /// <value>Unique token assigned to the device after it registers with its corresponding push notification service (APNS, GCM, or FCM).</value>
        [DataMember(Name="token", EmitDefaultValue=false)]
        public string Token { get; set; }

        /// <summary>
        /// Unique ID of an app install (legacy). Required if &#x60;app_install_id&#x60; is not provided
        /// </summary>
        /// <value>Unique ID of an app install (legacy). Required if &#x60;app_install_id&#x60; is not provided</value>
        [DataMember(Name="legacy_app_install_id", EmitDefaultValue=false)]
        public int? LegacyAppInstallId { get; set; }

        /// <summary>
        /// Unique ID of an app install. Required if &#x60;legacy_app_install_id&#x60; is not provided
        /// </summary>
        /// <value>Unique ID of an app install. Required if &#x60;legacy_app_install_id&#x60; is not provided</value>
        [DataMember(Name="app_install_id", EmitDefaultValue=false)]
        public byte[] AppInstallId { get; set; }

        /// <summary>
        /// Platform Endpoint Amazon Resource Name.
        /// </summary>
        /// <value>Platform Endpoint Amazon Resource Name.</value>
        [DataMember(Name="aws_sns_endpoint_arn", EmitDefaultValue=false)]
        public string AwsSnsEndpointArn { get; set; }


        /// <summary>
        /// Gets or Sets Links
        /// </summary>
        [DataMember(Name="_links", EmitDefaultValue=false)]
        public SelfLink Links { get; set; }

        /// <summary>
        /// Embedded properties of Platform Endpoint.
        /// </summary>
        /// <value>Embedded properties of Platform Endpoint.</value>
        [DataMember(Name="_embedded", EmitDefaultValue=false)]
        public Object Embedded { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class PlatformEndpoint {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  AppKey: ").Append(AppKey).Append("\n");
            sb.Append("  CreatedAt: ").Append(CreatedAt).Append("\n");
            sb.Append("  UpdatedAt: ").Append(UpdatedAt).Append("\n");
            sb.Append("  DeletedAt: ").Append(DeletedAt).Append("\n");
            sb.Append("  Token: ").Append(Token).Append("\n");
            sb.Append("  LegacyAppInstallId: ").Append(LegacyAppInstallId).Append("\n");
            sb.Append("  AppInstallId: ").Append(AppInstallId).Append("\n");
            sb.Append("  AwsSnsEndpointArn: ").Append(AwsSnsEndpointArn).Append("\n");
            sb.Append("  Platform: ").Append(Platform).Append("\n");
            sb.Append("  Links: ").Append(Links).Append("\n");
            sb.Append("  Embedded: ").Append(Embedded).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }
  
        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public virtual string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            return this.Equals(input as PlatformEndpoint);
        }

        /// <summary>
        /// Returns true if PlatformEndpoint instances are equal
        /// </summary>
        /// <param name="input">Instance of PlatformEndpoint to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(PlatformEndpoint input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Id == input.Id ||
                    (this.Id != null &&
                    this.Id.Equals(input.Id))
                ) && 
                (
                    this.AppKey == input.AppKey ||
                    (this.AppKey != null &&
                    this.AppKey.Equals(input.AppKey))
                ) && 
                (
                    this.CreatedAt == input.CreatedAt ||
                    (this.CreatedAt != null &&
                    this.CreatedAt.Equals(input.CreatedAt))
                ) && 
                (
                    this.UpdatedAt == input.UpdatedAt ||
                    (this.UpdatedAt != null &&
                    this.UpdatedAt.Equals(input.UpdatedAt))
                ) && 
                (
                    this.DeletedAt == input.DeletedAt ||
                    (this.DeletedAt != null &&
                    this.DeletedAt.Equals(input.DeletedAt))
                ) && 
                (
                    this.Token == input.Token ||
                    (this.Token != null &&
                    this.Token.Equals(input.Token))
                ) && 
                (
                    this.LegacyAppInstallId == input.LegacyAppInstallId ||
                    (this.LegacyAppInstallId != null &&
                    this.LegacyAppInstallId.Equals(input.LegacyAppInstallId))
                ) && 
                (
                    this.AppInstallId == input.AppInstallId ||
                    (this.AppInstallId != null &&
                    this.AppInstallId.Equals(input.AppInstallId))
                ) && 
                (
                    this.AwsSnsEndpointArn == input.AwsSnsEndpointArn ||
                    (this.AwsSnsEndpointArn != null &&
                    this.AwsSnsEndpointArn.Equals(input.AwsSnsEndpointArn))
                ) && 
                (
                    this.Platform == input.Platform ||
                    (this.Platform != null &&
                    this.Platform.Equals(input.Platform))
                ) && 
                (
                    this.Links == input.Links ||
                    (this.Links != null &&
                    this.Links.Equals(input.Links))
                ) && 
                (
                    this.Embedded == input.Embedded ||
                    (this.Embedded != null &&
                    this.Embedded.Equals(input.Embedded))
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hashCode = 41;
                if (this.Id != null)
                    hashCode = hashCode * 59 + this.Id.GetHashCode();
                if (this.AppKey != null)
                    hashCode = hashCode * 59 + this.AppKey.GetHashCode();
                if (this.CreatedAt != null)
                    hashCode = hashCode * 59 + this.CreatedAt.GetHashCode();
                if (this.UpdatedAt != null)
                    hashCode = hashCode * 59 + this.UpdatedAt.GetHashCode();
                if (this.DeletedAt != null)
                    hashCode = hashCode * 59 + this.DeletedAt.GetHashCode();
                if (this.Token != null)
                    hashCode = hashCode * 59 + this.Token.GetHashCode();
                if (this.LegacyAppInstallId != null)
                    hashCode = hashCode * 59 + this.LegacyAppInstallId.GetHashCode();
                if (this.AppInstallId != null)
                    hashCode = hashCode * 59 + this.AppInstallId.GetHashCode();
                if (this.AwsSnsEndpointArn != null)
                    hashCode = hashCode * 59 + this.AwsSnsEndpointArn.GetHashCode();
                if (this.Platform != null)
                    hashCode = hashCode * 59 + this.Platform.GetHashCode();
                if (this.Links != null)
                    hashCode = hashCode * 59 + this.Links.GetHashCode();
                if (this.Embedded != null)
                    hashCode = hashCode * 59 + this.Embedded.GetHashCode();
                return hashCode;
            }
        }

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        IEnumerable<System.ComponentModel.DataAnnotations.ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }
}
