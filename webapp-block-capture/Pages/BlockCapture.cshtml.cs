using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using webapp_impl_service.implementation;
using webapp_impl_service.model;

namespace webapp_block_capture.Pages
{
	public class BlockCaptureModel : PageModel
    {
        private readonly ILogger<BlockCaptureModel> _logger;
        private EmployeeApplication employeeApplication;
        private BlockApplication blockApplication;

        [BindProperty]
        public EmployeeBlock employee { get; set; } = default!;
        public string message = "";

        public BlockCaptureModel(ILogger<BlockCaptureModel> logger)
        {
            _logger = logger;
            employeeApplication = new EmployeeApplication();
            blockApplication = new BlockApplication();
        }

        public void OnGet()
        {
            employeeApplication.SelectAllEmployees("").Select().ToList();
        }

        public IActionResult OnPostEmployeeBlock()
        {
            string result = "";
            try
            {
                if (employee != null)
                {
                    bool queryResult = blockApplication.RegistertBlock(employee);
                    result = queryResult ? "All Good!" : "Something went wrong!";
                }
            }
            catch (Exception ex)
            {
                result = "Server Error: " + ex.Message;
            }
            return Content(result);
        }
    }
}
