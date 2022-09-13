using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Interceptors;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Aspects.Autofac.Validation
{
    public class ValidationAspect : MethodInterception
    {
        private Type _validatorType;
        public ValidationAspect(Type validatorType)
        {
            // defensive coding, check if given type is IValidator type
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
            {
                throw new System.Exception("This is not a validation class");
            }

            _validatorType = validatorType;
        }
        protected override void OnBefore(IInvocation invocation)
        {
            // creating an instance of the validator(productValidator) in runtime
            // its like : ProductValdiator p = new ProductValidator();
            var validator = (IValidator)Activator.CreateInstance(_validatorType);
            // the entitytpe in that case is product
            // _validatorType is ProductValidator and the base type the inherited class of productValidator is
            // AbstractValidator, we get the first generic argument of the basetype so its Product
            // go check ProductValidator.cs
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];
            // go check the arguments(parameters) of the invoraction(add method) where type of the parameter is
            // equal to entityType so Product
            // we do this because the method can have more than one parameters
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType);
            // for each parameter of the method (ex : add(Product product) )
            foreach (var entity in entities)
            {
                // validate the product that you want to add
                ValidationTool.Validate(validator, entity);
            }
        }
    }
}
