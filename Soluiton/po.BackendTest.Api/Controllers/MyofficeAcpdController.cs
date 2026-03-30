using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using po.BackendTest.Api.Data;
using po.BackendTest.Api.Models.Entities;

namespace po.BackendTest.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MyOfficeAcpdController : ControllerBase
    {
        private readonly MyofficeAcpdContext _context;

        public MyOfficeAcpdController(MyofficeAcpdContext context)
        {
            _context = context;
        }
        [HttpGet("ping-db")]
        public async Task<IActionResult> PingDb()
        {
            try
            {
                var canConnect = await _context.Database.CanConnectAsync();
                return Ok(new { canConnect });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    message = "查詢全部資料時發生錯誤",
                    error = ex.Message,
                    innerError = ex.InnerException?.Message,
                    innerInnerError = ex.InnerException?.InnerException?.Message
                });
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MyOfficeAcpd>>> GetAll()
        {
            try
            {
                var data = await _context.MyOfficeAcpds.ToListAsync();
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    message = "查詢全部資料時發生錯誤",
                    error = ex.Message,
                    innerError = ex.InnerException?.Message,
                    innerInnerError = ex.InnerException?.InnerException?.Message
                });
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MyOfficeAcpd>> GetById(string id)
        {
            try
            {
                var data = await _context.MyOfficeAcpds.FindAsync(id);

                if (data == null)
                {
                    return NotFound(new { message = "資料不存在" });
                }

                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "查詢單筆資料時發生錯誤", error = ex.Message });
            }
        }

        [HttpPost]
        public async Task<ActionResult<MyOfficeAcpd>> Create(MyOfficeAcpd model)
        {
            try
            {
                if (model == null)
                {
                    return BadRequest(new { message = "輸入資料不可為空" });
                }

                if (string.IsNullOrWhiteSpace(model.AcpdSid))
                {
                    return BadRequest(new { message = "AcpdSid 不可為空" });
                }

                var exists = await _context.MyOfficeAcpds.AnyAsync(x => x.AcpdSid == model.AcpdSid);
                if (exists)
                {
                    return BadRequest(new { message = "AcpdSid 已存在，請勿重複新增" });
                }

                _context.MyOfficeAcpds.Add(model);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetById), new { id = model.AcpdSid }, model);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "新增資料時發生錯誤", error = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, MyOfficeAcpd model)
        {
            try
            {
                if (model == null)
                {
                    return BadRequest(new { message = "輸入資料不可為空" });
                }

                if (id != model.AcpdSid)
                {
                    return BadRequest(new { message = "URL id 與 AcpdSid 不一致" });
                }

                var existingData = await _context.MyOfficeAcpds.FindAsync(id);
                if (existingData == null)
                {
                    return NotFound(new { message = "資料不存在" });
                }

                existingData.AcpdCname = model.AcpdCname;
                existingData.AcpdEname = model.AcpdEname;
                existingData.AcpdSname = model.AcpdSname;
                existingData.AcpdEmail = model.AcpdEmail;
                existingData.AcpdStatus = model.AcpdStatus;
                existingData.AcpdStop = model.AcpdStop;
                existingData.AcpdStopMemo = model.AcpdStopMemo;
                existingData.AcpdLoginId = model.AcpdLoginId;
                existingData.AcpdLoginPwd = model.AcpdLoginPwd;
                existingData.AcpdMemo = model.AcpdMemo;
                existingData.AcpdNowDateTime = model.AcpdNowDateTime;
                existingData.AcpdNowId = model.AcpdNowId;
                existingData.AcpdUpddateTime = model.AcpdUpddateTime;
                existingData.AcpdUpdid = model.AcpdUpdid;

                await _context.SaveChangesAsync();

                return Ok(existingData);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "更新資料時發生錯誤", error = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                var data = await _context.MyOfficeAcpds.FindAsync(id);

                if (data == null)
                {
                    return NotFound(new { message = "資料不存在" });
                }

                _context.MyOfficeAcpds.Remove(data);
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "刪除資料時發生錯誤", error = ex.Message });
            }
        }
    }
}