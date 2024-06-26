﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4_5.Classes
{
    public class FormOrder
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Surname { get; set; }
        public string? TypeDoc { get; set; }
        public string? DocNumber { get; set; }
        public bool? Agreement { get; set; }
    }

    public class ValidatorFormOrder<T> : AbstractValidator<FormOrder>
    {
        public ValidatorFormOrder()
        {
            RuleFor(customer => customer.FirstName)
              .NotNull()
              .NotEmpty()
              .Length(2, 30)
              .Matches(@"[A-Za-zА-Яа-я]+");

            RuleFor(customer => customer.LastName)
              .NotNull()
              .NotEmpty()
              .MaximumLength(30)
              .Matches(@"[A-Za-zА-Яа-я]+");

            RuleFor(customer => customer.Surname)
              .NotNull()
              .MaximumLength(30)
              .Matches(@"[A-Za-zА-Яа-я]*");

            RuleFor(customer => customer.TypeDoc)
              .NotNull()
              .NotEmpty()
              .MinimumLength(3)
              .Matches(@"[A-Za-zА-Яа-я]+");

            RuleFor(customer => customer.DocNumber)
              .NotNull()
              .NotEmpty()
              .MinimumLength(3)
              .Matches(@"[A-Za-zА-Яа-я0-9]+");

            RuleFor(customer => customer.Agreement)
              .NotNull()
              .NotEmpty();
        }
    }

    public class FormPayment
    {
        public string? NameHoldor { get; set; }
        public string? Validity { get; set; }
        public string? NumberCard { get; set; }
        public string? CVV { get; set; }
    }

    public class ValidatorFormPayment<T> : AbstractValidator<FormPayment>
    {
        public ValidatorFormPayment()
        {
            RuleFor(customer => customer.NameHoldor)
              .NotNull()
              .NotEmpty()
              .Length(2, 60)
              .Matches(@"[A-Za-zА-Яа-я]+\s[A-Za-zА-Яа-я]+");

            RuleFor(customer => customer.Validity)
              .NotNull()
              .NotEmpty()
              .MaximumLength(30)
              .Matches(@"\d{2}\/\d{2}");

            RuleFor(customer => customer.NumberCard)
              .NotNull()
              .NotEmpty()
              .Matches(@"\d{4}\s\d{4}\s\d{4}\s\d{4}");

            RuleFor(customer => customer.CVV)
              .NotNull()
              .NotEmpty()
              .Length(3)
              .Matches(@"\d{3}");
        }
    }

    public class FormLogIn
    {
        public string? email { get; set; }
        public string? password { get; set; }
    }

    public class ValidatorFormLogIn<T> : AbstractValidator<FormLogIn>
    {
        public ValidatorFormLogIn()
        {
            RuleFor(data => data.email)
                .NotEmpty()
                .NotNull()
                .EmailAddress();

            RuleFor(data => data.password)
                .NotNull()
                .NotEmpty()
                .Length(4, 20)
                .Matches(@"^[A-Za-zА-Яа-я0-9-_]+");
        }
    }

    public class FormSearch
    {
        public string? from { get; set; }
        public string? to { get; set; }
        public string? time { get; set; }
    }

    public class ValidatorFormSearch<T> : AbstractValidator<FormSearch>
    {
        public ValidatorFormSearch()
        {
            RuleFor(data => data.from)
                .NotEmpty()
                .NotNull()
                .Matches(@"^[A-Za-zА-Яа-я]+");

            RuleFor(data => data.to)
                .NotEmpty()
                .NotNull()
                .Matches(@"^[A-Za-zА-Яа-я]+");

            RuleFor(data => data.time)
                .NotEmpty()
                .NotNull()
                .Matches(@"(\d{2}:\d{2}:\d{2})|(\d{2}:\d{2})");
        }
    }
}
