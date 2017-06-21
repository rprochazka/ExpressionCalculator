
using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace ExpressionCalculator.Api.Models
{

    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public partial class CalculationError :  IEquatable<CalculationError>
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="CalculationError" /> class.
        /// </summary>
        /// <param name="ErrorText">ErrorText.</param>
        /// <param name="Expression">Expression.</param>
        /// <param name="ExpressionId">ExpressionId.</param>
        /// <param name="ErrorPositionIndex">failing position within the expression.</param>
        public CalculationError(string ErrorText = default(string), string Expression = default(string), int? ExpressionId = default(int?), string ErrorPositionIndex = default(string))
        {
            this.ErrorText = ErrorText;
            this.Expression = Expression;
            this.ExpressionId = ExpressionId;
            this.ErrorPositionIndex = ErrorPositionIndex;
            
        }

        /// <summary>
        /// Gets or Sets ErrorText
        /// </summary>
        [DataMember(Name="ErrorText")]
        public string ErrorText { get; set; }
        /// <summary>
        /// Gets or Sets Expression
        /// </summary>
        [DataMember(Name="Expression")]
        public string Expression { get; set; }
        /// <summary>
        /// Gets or Sets ExpressionId
        /// </summary>
        [DataMember(Name="ExpressionId")]
        public int? ExpressionId { get; set; }
        /// <summary>
        /// failing position within the expression
        /// </summary>
        /// <value>failing position within the expression</value>
        [DataMember(Name="ErrorPositionIndex")]
        public string ErrorPositionIndex { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class CalculationError {\n");
            sb.Append("  ErrorText: ").Append(ErrorText).Append("\n");
            sb.Append("  Expression: ").Append(Expression).Append("\n");
            sb.Append("  ExpressionId: ").Append(ExpressionId).Append("\n");
            sb.Append("  ErrorPositionIndex: ").Append(ErrorPositionIndex).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="obj">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((CalculationError)obj);
        }

        /// <summary>
        /// Returns true if CalculationError instances are equal
        /// </summary>
        /// <param name="other">Instance of CalculationError to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(CalculationError other)
        {

            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return 
                (
                    this.ErrorText == other.ErrorText ||
                    this.ErrorText != null &&
                    this.ErrorText.Equals(other.ErrorText)
                ) && 
                (
                    this.Expression == other.Expression ||
                    this.Expression != null &&
                    this.Expression.Equals(other.Expression)
                ) && 
                (
                    this.ExpressionId == other.ExpressionId ||
                    this.ExpressionId != null &&
                    this.ExpressionId.Equals(other.ExpressionId)
                ) && 
                (
                    this.ErrorPositionIndex == other.ErrorPositionIndex ||
                    this.ErrorPositionIndex != null &&
                    this.ErrorPositionIndex.Equals(other.ErrorPositionIndex)
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            // credit: http://stackoverflow.com/a/263416/677735
            unchecked // Overflow is fine, just wrap
            {
                int hash = 41;
                // Suitable nullity checks etc, of course :)
                    if (this.ErrorText != null)
                    hash = hash * 59 + this.ErrorText.GetHashCode();
                    if (this.Expression != null)
                    hash = hash * 59 + this.Expression.GetHashCode();
                    if (this.ExpressionId != null)
                    hash = hash * 59 + this.ExpressionId.GetHashCode();
                    if (this.ErrorPositionIndex != null)
                    hash = hash * 59 + this.ErrorPositionIndex.GetHashCode();
                return hash;
            }
        }

        #region Operators

        public static bool operator ==(CalculationError left, CalculationError right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(CalculationError left, CalculationError right)
        {
            return !Equals(left, right);
        }

        #endregion Operators

    }
}
