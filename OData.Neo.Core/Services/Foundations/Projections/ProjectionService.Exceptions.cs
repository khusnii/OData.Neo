﻿//-----------------------------------------------------------------------
// Copyright (c) .NET Foundation and Contributors. All rights reserved.
// See License.txt in the project root for license information.
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OData.Neo.Core.Models.ProjectedTokens;
using OData.Neo.Core.Models.ProjectedTokens.Exceptions;

namespace OData.Neo.Core.Services.Foundations.Projections
{
    public partial class ProjectionService
    {
        private delegate ProjectedToken[] ReturningProjectedTokensFunction();

        private ProjectedToken[] TryCatch(ReturningProjectedTokensFunction returningProjectedTokensFunction)
        {
            try
            {
                return returningProjectedTokensFunction();
            }
            catch (NullProjectedTokenException nullProjectedTokenException)
            {
                throw new ProjectedTokenValidationException(nullProjectedTokenException);
            }
        }
    }
}
