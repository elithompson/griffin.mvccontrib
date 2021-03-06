﻿/*
 * Copyright (c) 2011, Jonas Gauffin. All rights reserved.
 *
 * This library is free software; you can redistribute it and/or
 * modify it under the terms of the GNU Lesser General Public
 * License as published by the Free Software Foundation; either
 * version 2.1 of the License, or (at your option) any later version.
 *
 * This library is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
 * Lesser General Public License for more details.
 *
 * You should have received a copy of the GNU Lesser General Public
 * License along with this library; if not, write to the Free Software
 * Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston,
 * MA 02110-1301 USA
 */

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;

namespace Griffin.MvcContrib.Localization
{
    /// <summary>
    /// Used to localize DatAnnotation attribute error messages
    /// </summary>
    /// <remarks>
    /// Check for instance <see cref="ResourceStringProvider"/> to get a description about the actual localization process.
    /// </remarks>
    /// <example>
    /// <code>
    /// public class MvcApplication : System.Web.HttpApplication
    /// {
    ///     protected void Application_Start()
    ///     {
    ///         var stringProvider = new ResourceStringProvider(ModelMetadataStrings.ResourceManager);
    ///         ModelValidatorProviders.Providers.Clear();
    ///         ModelValidatorProviders.Providers.Add(new LocalizedModelValidatorProvider(stringProvider));
    ///     }
    /// }
    /// </code>
    /// </example>
    public class LocalizedModelValidatorProvider : DataAnnotationsModelValidatorProvider
    {
        private readonly ILocalizedStringProvider _stringProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="LocalizedModelValidatorProvider"/> class.
        /// </summary>
        /// <param name="stringProvider">The string provider.</param>
        public LocalizedModelValidatorProvider(ILocalizedStringProvider stringProvider)
        {
            _stringProvider = stringProvider;
        }

        /// <summary>
        /// Gets a list of validators.
        /// </summary>
        /// <param name="metadata">The metadata.</param>
        /// <param name="context">The context.</param>
        /// <param name="attributes">The list of validation attributes.</param>
        /// <returns>
        /// A list of validators.
        /// </returns>
        protected override IEnumerable<ModelValidator> GetValidators(ModelMetadata metadata, ControllerContext context,
                                                                     IEnumerable<Attribute> attributes)
        {
            foreach (var attr in attributes.OfType<ValidationAttribute>())
                attr.ErrorMessage = _stringProvider.GetValidationString(attr.GetType());
            return base.GetValidators(metadata, context, attributes);
        }
    }
}