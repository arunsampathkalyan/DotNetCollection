using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using CelloSaaS.Model;

namespace Secova.NxG.BAS.Model
{
    [Serializable]
    [EntityIdentifier(Name = "InteractiveQuestion")]
    public class InteractiveQuestion : BaseEntity
    {
        public InteractiveQuestion()
        {
        }

        /// <summary>
        ///  Gets or sets the Interactive Question Id
        /// </summary>
        public string QuestionId { get; set; }

        /// <summary>
        ///  Gets or sets the TenantServicePeriod Id
        /// </summary>
        public string TenantServicePeriodId { get; set; }

        /// <summary>
        ///  Gets or sets the Question Text
        /// </summary>
        public string QuestionText { get; set; }

        /// <summary>
        ///  Gets or sets the Control Type Id
        /// </summary>
        [Required(ErrorMessage = "You must select one Control Type.")]
        public string ControlTypeId { get; set; }

        ///// <summary>
        /////  Gets or sets the Control Type Name
        ///// </summary>
        public string ControlTypeName { get; set; }

        ///// <summary>
        /////  Gets or sets the Data Type
        ///// </summary>
        [Required(ErrorMessage = "You must select one Data Type.")]
        public string DataTypeId { get; set; }

        /// <summary>
        ///  Gets or sets the Default Value
        /// </summary>
        public string DefaultValue { get; set; }

        /// <summary>
        ///  Gets or sets the CSS Style
        /// </summary>
        public string CSSStyle { get; set; }

        /// <summary>
        ///  Gets or sets the Interactive Question Code
        /// </summary>
        [Required(ErrorMessage = "You must supply the value for Question Code.")]
        public string QuestionCode { get; set; }

        /// <summary>
        ///  Gets or sets the IsRequired field
        /// </summary>
        public bool IsRequired { get; set; }

        /// <summary>
        /// Gets or sets the Parent Question Id
        /// </summary>
        public string ParentQuestionId { get; set; }

        /// <summary>
        /// Gets or sets the Parent Question Value
        /// </summary>
        public string ParentQuestionValue { get; set; }

        /// <summary>
        /// Gets or sets the Start Date
        /// </summary>
        public DateTime? StartDate { get; set; }

        /// <summary>
        /// Gets or sets the End Date
        /// </summary>
        public DateTime? EndDate { get; set; }

        /// <summary>
        /// Gets or sets the Dependant Type Id
        /// </summary>
        //[RangeAttribute(1, 3, ErrorMessage = "DependantType is required")] 
        public string DependantTypeId { get; set; } //RelationshipType

        /// <summary>
        /// Gets or sets the Created By
        /// </summary>
        public string CreatedBy { get; set; }

        /// <summary>
        /// Gets or sets the Created Date
        /// </summary>
        public DateTime? CreatedDate { get; set; }

        /// <summary>
        /// Gets or sets the Updated By
        /// </summary>
        public string UpdatedBy { get; set; }

        /// <summary>
        /// Gets or sets the Updated Date
        /// </summary>
        public DateTime? UpdatedDate { get; set; }

        /// <summary>
        /// Gets or sets the Status
        /// </summary>
        public bool Status { get; set; }

        public bool IsParentQuestion { get; set; }

        public LookupControlType LookupControlType { get; set; }

        public LookupDataType LookupDataType { get; set; }

        public LookupDependantType LookupDependantType { get; set; }

        public List<InteractiveQuestionDataLookup> InteractiveQuestionDataLookup { get; set; }
    }

    public class InteractiveQuestionSearchCondition : SearchCondition
    {
        /// <summary>
        /// Gets or sets the QuestionId
        /// </summary>
        public string QuestionId { get; set; }

        /// <summary>
        /// Gets or sets the Status
        /// </summary>
        public bool? Status { get; set; }
    }
}
