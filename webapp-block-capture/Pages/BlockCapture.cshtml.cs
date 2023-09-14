﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using webapp_impl_service.implementation;

namespace webapp_block_capture.Pages
{
	public class BlockCaptureModel : PageModel
    {
        private readonly ILogger<BlockCaptureModel> _logger;
        private EmployeeApplication employeeApplication;
        public List<System.Data.DataRow> dataRows;

        public BlockCaptureModel(ILogger<BlockCaptureModel> logger)
        {
            _logger = logger;
            employeeApplication = new EmployeeApplication();
            dataRows = new List<System.Data.DataRow>();
        }

        public void OnGet()
        {
            employeeApplication.SelectAllEmployees("").Select().ToList();
        }
    }
}
