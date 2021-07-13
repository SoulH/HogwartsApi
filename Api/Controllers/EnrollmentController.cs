using Core;
using Core.Logic;
using Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HogwartsApi.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]/[action]")]
    public class EnrollmentController : ControllerBase
    {
        private readonly ILogger<EnrollmentController> _logger;
        private readonly EnrollmentManager _manager;

        public EnrollmentController(EnrollmentManager manager, ILogger<EnrollmentController> logger)
        {
            _logger = logger;
            _manager = manager;
        }

        [HttpGet]
        public ResponseData<Registration> AllRecords() => _manager.GetRecords();

        [HttpPost]
        public ResponseData<Registration> RequestEntry(Registration data) => _manager.RequestEntry(data);

        [HttpPut]
        public ResponseData<Registration> UpdateEntry(Registration data) => _manager.UpdateEntry(data);

        [HttpDelete]
        [Route("{id}")]
        public ResponseData<Registration> DeleteEntry(Guid id) => _manager.DeleteEntry(id);
    }
}
