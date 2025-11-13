using Microsoft.AspNetCore.DataProtection.KeyManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySales.Models.Helpers
{
    public abstract class ResultBase
    {
        public bool Success { get; }
        public string? ErrorMessage { get; }

        protected ResultBase(bool success, string? errorMessage)
        {
            Success = success;
            ErrorMessage = errorMessage;
        }
    }

    public class Result : ResultBase
    {
        private Result(bool success, string? errorMessage) : base(success, errorMessage) { }

        public static Result Ok() => new(true, null);
        public static Result Fail(string msg) => new(false, msg);
    }


    public class Result<T> : ResultBase
    {
        public bool Success { get; }
        public T? Value { get; }
        public string? ErrorMessage { get; }


        private Result(bool success, T? value, string? errorMessage)
            : base(success, errorMessage)
        {
            Value = value;
        }

        public static Result<T> Ok(T value) => new(true, value, null);
        public static Result<T> NotFound(string key) => new(false, default, $"{key} was not found");
        public static Result<T> NotFound(string objName, string key) => new(false, default, $"{objName} with key: {key} was not found");        
        public static Result<T> Error(string msg) => new(false, default, msg);
    }

}
