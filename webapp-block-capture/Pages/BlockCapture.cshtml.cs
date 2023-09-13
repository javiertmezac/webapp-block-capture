using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace webapp_block_capture.Pages
{
	public class BlockCaptureModel : PageModel
    {
        private readonly ILogger<BlockCaptureModel> _logger;

        public BlockCaptureModel(ILogger<BlockCaptureModel> logger)
        {
            _logger = logger;
        }
        public void OnGet()
        {
        }
    }
}
