﻿using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Application
{
    public static class Dependencyinjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services) 
        {

            return services;
        }
    }
}