// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// </auto-generated>

namespace Microsoft.Azure.Management.ServiceFabric.Fluent.Models
{
    using Microsoft.Rest;
    using Newtonsoft.Json;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Describes a section in the fabric settings of the cluster.
    /// </summary>
    public partial class SettingsSectionDescription
    {
        /// <summary>
        /// Initializes a new instance of the SettingsSectionDescription class.
        /// </summary>
        public SettingsSectionDescription()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the SettingsSectionDescription class.
        /// </summary>
        /// <param name="name">The section name of the fabric settings.</param>
        /// <param name="parameters">The collection of parameters in the
        /// section.</param>
        public SettingsSectionDescription(string name, IList<SettingsParameterDescription> parameters)
        {
            Name = name;
            Parameters = parameters;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets the section name of the fabric settings.
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the collection of parameters in the section.
        /// </summary>
        [JsonProperty(PropertyName = "parameters")]
        public IList<SettingsParameterDescription> Parameters { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (Name == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "Name");
            }
            if (Parameters == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "Parameters");
            }
            if (Parameters != null)
            {
                foreach (var element in Parameters)
                {
                    if (element != null)
                    {
                        element.Validate();
                    }
                }
            }
        }
    }
}
