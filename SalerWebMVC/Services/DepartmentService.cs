﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalerWebMVC.Models;
using SalerWebMVC.Data;
using Microsoft.EntityFrameworkCore;

namespace SalerWebMVC.Services
{
    public class DepartmentService
    {
        private readonly SalerWebMVCContext _context;

        public DepartmentService(SalerWebMVCContext context)
        {
            _context = context;
        }

        public async Task<List<Department>> FindAllAsync()
        {
            return await _context.Department.OrderBy(x => x.Name).ToListAsync();
        }
    }
}
