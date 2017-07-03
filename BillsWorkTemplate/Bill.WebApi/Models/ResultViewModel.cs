﻿namespace Bill.WebApi.Models
{
    public class ResultViewModel<T>
    {
        public string Code { get; set; }

        public string Message { get; set; }

        public T Data { get; set; }
    }
}