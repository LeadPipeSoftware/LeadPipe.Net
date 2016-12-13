// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq.Expressions;

namespace LeadPipe.Net.Specifications
{
    /// <summary>
    /// An ExpressionVisitor for rebinding parameters without using the Invoke method in expressions.
    /// </summary>
    /// <remarks>
    /// Matt Warren has a great series of articles on IQueryable providers. You can read it here http://goo.gl/2HxsR.
    /// </remarks>
    public sealed class ParameterRebinder : ExpressionVisitor
    {
        /// <summary>
        /// The parameter map.
        /// </summary>
        private readonly Dictionary<ParameterExpression, ParameterExpression> parameterMap;

        /// <summary>
        /// Initializes a new instance of the <see cref="ParameterRebinder"/> class.
        /// </summary>
        /// <param name="parameterMap">The parameter map.</param>
        public ParameterRebinder(Dictionary<ParameterExpression, ParameterExpression> parameterMap)
        {
            this.parameterMap = parameterMap ?? new Dictionary<ParameterExpression, ParameterExpression>();
        }

        /// <summary>
        /// Replaces parameters in expression with information from the parameter map.
        /// </summary>
        /// <param name="parameterMap">
        /// The parameter map.
        /// </param>
        /// <param name="expression">
        /// The original expression.
        /// </param>
        /// <returns>
        /// The expression with the parameters replaced.
        /// </returns>
        public static Expression ReplaceParameters(Dictionary<ParameterExpression, ParameterExpression> parameterMap, Expression expression)
        {
            return new ParameterRebinder(parameterMap).Visit(expression);
        }

        /// <summary>
        /// The Visitor pattern dispatch method.
        /// </summary>
        /// <param name="parameterExpression">
        /// A parameter expression.
        /// </param>
        /// <returns>
        /// The new visited parameter expression.
        /// </returns>
        protected override Expression VisitParameter(ParameterExpression parameterExpression)
        {
            ParameterExpression replacement;

            if (this.parameterMap.TryGetValue(parameterExpression, out replacement))
            {
                parameterExpression = replacement;
            }

            return base.VisitParameter(parameterExpression);
        }
    }
}